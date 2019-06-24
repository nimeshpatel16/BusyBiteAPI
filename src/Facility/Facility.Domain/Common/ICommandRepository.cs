using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.MDM.Location.Domain.Common
{
    public interface ICommandRepository<T> where T : IAggregateRoot
    {
        IUnitofWork UnitofWork { get; }
    }
}
