using KurumService.BusinessLayer.Abstract;
using KurumService.BusinessLayer.Concrete;
using KurumService.DataAccessLayer.Abstract;
using KurumService.DataAccessLayer.Concrete;
using KurumService.DataAccessLayer.EntityFramework;
using KurumService.WebApi.Service;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumService.WebApi
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
                options.RequireHttpsMetadata = false;  // Canl?ya Al?nd???nda De?i?tirilecek *-Enes-*
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = "http://localhost", // Canl?ya Al?nd???nda De?i?tirilecek *-Enes-*
                    ValidAudience = "http://localhost", // Canl?ya Al?nd???nda De?i?tirilecek *-Enes-*
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
            services.AddCors(opt =>
            {
                opt.AddPolicy("YksApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddDbContext<Context>();

            services.AddScoped<IKisiDal, EfKisiDal>();
            services.AddScoped<IKisiService, KisiManager>();

            services.AddScoped<IKurumDal, EfKurumDal>();
            services.AddScoped<IKurumService, KurumManager>();

            services.AddScoped<ITokenCreateService, TokenCreateService>();





            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KurumService.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KurumService.WebApi v1"));
            }

            app.UseHttpsRedirection();

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
