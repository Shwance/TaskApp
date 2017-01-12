using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TaskApp.Dal;
using TaskApp.Logging;
using Microsoft.Extensions.Logging;

namespace TaskApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            String _connectionString = "XXXX";
            ILoggingRepository loggingRepository = new SQLLoggingRepository(_connectionString);
            TaskApp.Logging.ILogger logger = new DBLogger(loggingRepository);
            services.AddSingleton<ITaskAppRepository>(new SQLTaskAppRepository(_connectionString,logger));
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

            app.UseFileServer();
            app.UseMvc();
            
        }
    }
}
