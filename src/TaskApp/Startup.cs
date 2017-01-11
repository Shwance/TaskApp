using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

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
                            , IHostingEnvironment env
                            , ILoggerFactory loggerFactory)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            String _connectionString = "data source=sql5028.smarterasp.net;initial catalog=DB_A09B09_GeoLocation;User Id=DB_A09B09_GeoLocation_admin;Password=jjuuddee1133;integrated security=false";
            String _command = "insert into [Log]([Description],[TimeStamp],LogLevel) values ('From the deployed app to the smarterAsp DB','2017-01-05',1)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(_command,conn))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();   

                }
            }

        }
    }
}
