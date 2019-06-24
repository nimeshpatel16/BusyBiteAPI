using Autofac;
using Envision.MDM.Facility.Service;
using Envision.MDM.Facility.Service.Interfaces;
using Envision.MDM.Location.Domain.AggregatesModel;
using Envision.MDM.Location.Infrastructure.Repositories.Queries;
using System;

namespace Envision.MDM.Location.API.Helper.AutoFacModules
{
    public class ApplicationModule
        : Autofac.Module
    {
        private readonly string _queriesConnectionString = string.Empty;

        public ApplicationModule(string queriesConnectionString)
        {
            _queriesConnectionString = queriesConnectionString ?? throw new ArgumentNullException(nameof(queriesConnectionString));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new FacilityQueriesRepository(_queriesConnectionString))
                .As<IFacilityQueriesRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new OutStandingQueriesRepository(_queriesConnectionString))
                .As<IOutStandingQueriesRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FacilityService>().As<IFacilityService>();
            builder.RegisterType<OutStandingService>().As<IOutStandingService>();

        }
    }
}
