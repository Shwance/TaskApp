using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using TaskApp.Dal;
using TaskApp.Logging;

namespace TaskApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
                            IApplicationBuilder app
                            , IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            String _connectionString = "data source=sql5028.smarterasp.net;initial catalog=DB_A09B09_GeoLocation;User Id=DB_A09B09_GeoLocation_admin;Password=jjuuddee1133;integrated security=false";

            ILoggingRepository loggingRepository = new SQLLoggingRepository(_connectionString);
            TaskApp.Logging.ILogger logger = new DBLogger(loggingRepository);

            app.UseFileServer();

            logger.Log("Application started and Configured successfuly", LogLevel.Information);

        }
    }
}
