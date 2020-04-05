using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Botzilla.Core.Abstractions;
using Botzilla.Core.Repository;
using Botzilla.Core.Repository.RepositoryImplementation;
using Botzilla.Core.Services;
using Botzilla.Core.Services.ServiceContract;
using Botzilla.Core.Services.ServiceImplementation;
using Botzilla.Domain.Domain;
using Botzilla.Domain.DomainBaseClasses;
using Botzilla.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Botzilla
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
            //services.AddScoped<RoleManager<Role>>();

            services.AddControllers();
            services.AddCors();
            services.AddScoped<DbContext, ApplicationDbContext>();

            //services
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IEmailContactService, EmailContactService>();
            services.AddScoped<IEmailSubjectService, EmailSubjectService>();
            services.AddScoped<IEducationLevelService, EducationLevelService>();


            //services.AddScoped</*IFileService*/, FileService>();

            //services.AddSingleton<CountryService>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();


            //repositories
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(ITrackableRepository<>), typeof(TrackableRepository<>));
            services.AddTransient<ITrackableRepository<Country>, TrackableRepository<Country>>();
            services.AddTransient<ITrackableRepository<News>, TrackableRepository<News>>();
            services.AddTransient<ITrackableRepository<DocumentBase>, TrackableRepository<DocumentBase>>();
            services.AddTransient<ITrackableRepository<NewsImage>, TrackableRepository<NewsImage>>();
            services.AddTransient<ITrackableRepository<EmailContact>, TrackableRepository<EmailContact>>();
            services.AddTransient<ITrackableRepository<EmailSubject>, TrackableRepository<EmailSubject>>();
            services.AddTransient<ITrackableRepository<EducationLevel>, TrackableRepository<EducationLevel>>();



            services.Configure<DocumentSettings>(Configuration.GetSection(nameof(DocumentSettings)));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[] {
                    "Botzilla.Core"
                });
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            });



            // builder.AddEntityFrameworkStores<RobotlijaContext>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication().AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "https://spark.ooo",
                    ValidIssuer = "https://spark.ooo",
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("A-VERY-STRONG-KEY-HERE"))
                };

            });

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            //}).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = false;
            //    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
            //            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});

            services.AddAutoMapper(typeof(Startup));

            //swagger configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    opt => opt.MigrationsAssembly("Botzilla.Infrastructure"))
               );
        }



            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
               

                app.UseHttpsRedirection();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

                });

            app.UseRouting();

            //app.UseIdentity();app.UseCors(
            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            ); //This needs to set everything allowed
            
            app.UseAuthentication();
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
}
