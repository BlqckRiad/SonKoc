using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SonKocApp.BusinessLayer.Abstract;
using SonKocApp.BusinessLayer.Concrete;
using SonKocApp.ChatApi.Hubs;
using SonKocApp.DataAccessLayer.Abstract;
using SonKocApp.DataAccessLayer.Concrete;
using SonKocApp.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonKocApp.ChatApi
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

            services.AddDbContext<Context>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();


            services.AddScoped<IKisiDal, EfKisiDal>();
            services.AddScoped<IKisiService, KisiManager>();

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

            services.AddControllers();

            // Add SignalR
            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SonKocApp.ChatApi", Version = "v1" });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SonKocApp.ChatApi v1"));
            }


            app.UseRouting();

            app.UseCors("YksApiCors");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Map SignalR hub
                endpoints.MapHub<ChatHub>("/SonKoc-Chat").RequireCors("YksApiCors");
            });
        }
    }
}
