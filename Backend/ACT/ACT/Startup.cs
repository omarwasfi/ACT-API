using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Serilog;
using ACT.DBContext;
using Microsoft.EntityFrameworkCore;
using ACT.Services.ApiDbAccess.SUN;
using ACT.Services.ApiDbAccess.SUN_HDR;
using ACT.Services.ApiDbAccess.SUN_DETAIL;
using ACT.Services.ApiDbAccess.OPERA;
using ACT.Services.ApiDbAccess.OPERA_REPORT;
using ACT.Services.ApiDbAccess.HRMS;
using ACT.Services.ApiDbAccess.HRMS_REPORT;
using ACT.Services.Execute;
using ACT.Services.ApiDbAccess.OPERA_SUN;

namespace ACT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddDbContext<ApiDbContext>(options =>
              options
              .UseSqlite(
                   Configuration.GetConnectionString("ApiDbContextConnection")));

            services.AddScoped<ISUN_Configuration, SUN_Configuration>();
            services.AddScoped<ISUN_HDR_Configuration, SUN_HDR_Configuration>();
            services.AddScoped<ISUN_DETAIL_Configuration, SUN_DETAIL_Configuration>();
            
            services.AddScoped<IOPERA_Configuration, OPERA_Configuration>();
            services.AddScoped<IOPERA_REPORT_Configuration, OPERA_REPORT_Configuration>();

            services.AddScoped<IHRMS_Configuration, HRMS_Configuration>();
            services.AddScoped<IHRMS_REPORT_Configuration, HRMS_REPORT_Configuration>();

            services.AddScoped<IOPERA_REPORT_SUN_HDR, OPERA_REPORT_SUN_HDR>();

            services.AddScoped<IExecuteOpera, ExecuteOpera>();

            


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ACT API",
                    Description = "Integration between opera and hrms with sun",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "omar wasfi",
                        Email = "contact@omarwasfi.com",
                        Url = new Uri("https://twitter.com/spboyer"),
                        
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
