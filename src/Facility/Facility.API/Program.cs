using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Envision.MDM.Location.API
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// This method register two scencial services to host this application using IIS service.
        /// UseKestrel(): This registers the IServer interface for Kestrel as the server that 
        ///               will be used to host your application.
        /// UseIISIntegration(): This tells ASP.NET that IIS will be working as a reverse proxy in front of Kestrel.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration();
                
    }
}
