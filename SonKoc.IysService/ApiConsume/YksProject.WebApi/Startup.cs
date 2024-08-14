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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YksProject.BusinessLayer.Abstract;
using YksProject.BusinessLayer.Concrete;
using YksProject.DataAccessLayer.Abstract;
using YksProject.DataAccessLayer.Concrete;
using YksProject.DataAccessLayer.EntityFramework;
using YksProject.EntityLayer.Concrete;
using YksProject.WebApi.Service;

namespace YksProject.WebApi
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
                options.RequireHttpsMetadata = false;  // Canlıya Alındığında Değiştirilecek *-Enes-*
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = "http://localhost", // Canlıya Alındığında Değiştirilecek *-Enes-*
                    ValidAudience = "http://localhost", // Canlıya Alındığında Değiştirilecek *-Enes-*
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yks2uygulamamizz")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
           
                    
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

            services.AddScoped<IAbonelikDal, EfAbonelikDal>();
            services.AddScoped<IAbonelikService, AbonelikManager>();

           

            services.AddScoped<IKisiDal, EfKisiDal>();
            services.AddScoped<IKisiService, KisiManager>();

            services.AddScoped<IReferanslarimizDal, EfReferanslarimizDal>();
            services.AddScoped<IReferanslarimizService, ReferanslarimizManager>();

            
            services.AddScoped<IDerslerDal, EfDerslerDal>();
            services.AddScoped<IDerslerService, DerslerManager>();

            services.AddScoped<IBolumlerDal, EfBolumlerDal>();
            services.AddScoped<IBolumlerService, BolumlerManager>();

            services.AddScoped<IReferanslarimizService, ReferanslarimizManager>();

            services.AddScoped<IYapilacaklarDal, EfYapilacaklarDal>();
            services.AddScoped<IYapilacaklarService, YapilacaklarManager>();



            services.AddScoped<IMedyaKutuphanesiDal, EfMedyaKutuphanesiDal>();
            services.AddScoped<IMedyaKutuphanesiService, MedyaKutuphanesiManager>();

            services.AddScoped<IRollerDal, EfRollerDal>();
            services.AddScoped<IRollerService, RollerManager>();

            services.AddScoped<IUyelikPaketleriDal, EfUyelikPaketleriDal>();
            services.AddScoped<IUyelikPaketleriService, UyelikPaketleriManager>();


            services.AddScoped<IPaketUyeTipleriDal, EfPaketUyeTipleriDal>();
            services.AddScoped<IPaketUyeTipleriService, PaketUyeTipleriManager>();


            services.AddScoped<IHomePostDal, EfHomePostDal>();
            services.AddScoped<IHomePostService, HomePostManager>();

            services.AddScoped<IKonularDal, EfKonularDal>();
            services.AddScoped<IKonularService, KonularManager>();

            services.AddScoped<IBildirimlerDal, EfBildirimlerDal>();
            services.AddScoped<IBildirimlerService, BildirimlerManager>();

            services.AddScoped<IGununSozuDal, EfGununSozuDal>();
            services.AddScoped<IGununSozuService, GununSozuManager>();

            services.AddScoped<IPromoKeyDal, EfPromoKeyDal>();
            services.AddScoped<IPromoKeyService, PromoKeyManager>();

            services.AddScoped<ITamamlanmisKonularDal, EfTamamlanmisKonularDal>();
            services.AddScoped<ITamamlanmisKonularService, TamamlanmisKonularManager>();

            services.AddScoped<ITokenCreateService, TokenCreateService>();

            services.AddAutoMapper(typeof(Startup));


            services.AddCors(opt =>
            {
                opt.AddPolicy("YksApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YksProject.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YksProject.WebApi v1"));
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
