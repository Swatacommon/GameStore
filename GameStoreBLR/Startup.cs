using Azure.Storage.Blobs;
using DAL;
using GameStoreBLR.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;

namespace GameStoreBLR {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDistributedMemoryCache();

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSingleton(x => new BlobServiceClient(Configuration.GetValue<string>("AzureBlobStorageConntectionString")));
            services.AddSingleton<IBlobService, BlobService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(options => {
                      options.RequireHttpsMetadata = false;
                      options.TokenValidationParameters = new TokenValidationParameters {
                          // укзывает, будет ли валидироваться издатель при валидации токена
                          ValidateIssuer = true,
                          // строка, представляющая издателя
                          ValidIssuer = AuthOptions.ISSUER,
                          // будет ли валидироваться потребитель токена
                          ValidateAudience = true,
                          // установка потребителя токена
                          ValidAudience = AuthOptions.AUDIENCE,
                          // будет ли валидироваться время существования
                          ValidateLifetime = true,

                          // установка ключа безопасности
                          IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                          // валидация ключа безопасности
                          ValidateIssuerSigningKey = true,
                      };
                  });

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            services.AddScoped<GameStoreContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa => {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
