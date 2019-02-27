using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbTesting
{
   public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            //* all accept
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });


           // secretKey = Configuration.GetSection("JwtSetting").GetSection("Key").Value;
           // audience = Configuration.GetSection("JwtSetting").GetSection("audience").Value;
           // issuer = Configuration.GetSection("JwtSetting").GetSection("issuer").Value;

           // signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

           // connStr = Configuration.GetSection("DbSetting").GetSection("ConnectionString").Value;
           // sysConnStr = Configuration.GetSection("DbSetting").GetSection("SysConnection").Value;

           // services.AddDbContext<BaseContext>(
           //      e =>
           //      {
           //          e.UseLazyLoadingProxies()
           //          .EnableSensitiveDataLogging()
           //          .UseSqlServer(connStr);
           //      });
           // services.AddDbContext<SysDbContext>(
           //e =>
           //{
           //    e.UseLazyLoadingProxies()
           //    .EnableSensitiveDataLogging()
           //    .UseSqlServer(sysConnStr);
           //});
            services.AddMvc();
          

        }
    }
}
