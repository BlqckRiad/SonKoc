using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SinavService.BusinessLayer.Abstract;
using SinavService.BusinessLayer.Concrete;
using SinavService.DataAccessLayer.Abstract;
using SinavService.DataAccessLayer.Concrete;
using SinavService.DataAccessLayer.EntityFramework;
using SinavService.SinavApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavService.SinavApi
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = "http://localhost",
                    ValidAudience = "http://localhost",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yks2uygulamamizz")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:6079")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });





            services.AddCors(options =>
            {
                options.AddPolicy("YksApiCors", builder =>
                {
                    builder.WithOrigins("http://localhost:6079") // veya istediğiniz belirli kökenleri burada listeyin
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials(); // Gerekirse credentials'ı izin verin.
                });
            });

            services.AddDbContext<Context>();
            services.AddScoped<IHelperFunctions, HelperFunctions>();
            
            services.AddScoped<ISinavDal, EfSinavDal>();
            services.AddScoped<ISinavService, SinavManager>();

            services.AddScoped<ISinavTipleriDal, EfSinavlTipleriDal>();
            services.AddScoped<ISinavTipleriService, SinavTipleriManager>();

            services.AddScoped<ITytSinavGirisTablosuDal, EfTytSinavGirisTablosuDal>();
            services.AddScoped<ITytSinavGirisTablosuService, TytSinavGirisTablosuManager>();

            services.AddScoped<IAytSayDal, EfAytSayDal>();
            services.AddScoped<IAytSayService, AytSayManager>();

            services.AddScoped<IAytEaDal, EfAytEaDal>();
            services.AddScoped<IAytEaService, AytEaManager>();

            services.AddScoped<IAytSozelDal, EfAytSozelDal>();
            services.AddScoped<IAytSozelService, AytSozelManager>();

            services.AddScoped<IAytDilDal, EfAytDilDal>();
            services.AddScoped<IAytDilService, AytDilManager>();

            services.AddScoped<ITytHedefDal, EfTytHedefDal>();
            services.AddScoped<ITytHedefService, TytHedefManager>();

            services.AddScoped<IAytSayHedefDal, EfAytSayHedefDal>();
            services.AddScoped<IAytSayHedefService, AytSayHedefManager>();

            services.AddScoped<IAytSozelHedefDal, EfAytSozelHedefDal>();
            services.AddScoped<IAytSozelHedefService, AytSozelHedefManager>();

            services.AddScoped<IAytEaHedefDal, EfAytEaHedefDal>();
            services.AddScoped<IAytEaHedefService, AytEaHedefManager>();


            services.AddScoped<IAytYdHedefDal, EfAytYdHedefDal>();
            services.AddScoped<IAytYdHedefService, AytYdHedefManager>();

            services.AddScoped<IHedefGenelTanimlariDal, EfHedefGenelTanimlariDal>();
            services.AddScoped<IHedefGenelTanimlariService, HedefGenelTanimlariManager>();


            services.AddControllers();

            // Add SignalR
            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SinavService.SinavApi", Version = "v1" });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SinavService.SinavApi v1"));
            }


            app.UseRouting();

            app.UseCors("YksApiCors");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
