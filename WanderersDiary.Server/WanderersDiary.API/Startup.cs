using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.API.Services.Auth;
using WanderersDiary.API.Services.Email;
using WanderersDiary.Entities;
using WanderersDiary.Entities.Models.User;

namespace WanderersDiary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSecurity(services);

            ConfigureUtilityServices(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WanderersDiary.API", Version = "v1" });
            });
        }

        private void ConfigureUtilityServices(IServiceCollection services)
        {
            services.TryAddScoped<IEmailService, EmailService>();
        }

        private void ConfigureSecurity(IServiceCollection services)
        {
            services.TryAddSingleton<ISystemClock, SystemClock>();
            services.TryAddScoped<IJwtGenerator, JwtGenerator>();

            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireAuthenticatedUser().Build();
                option.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddDbContext<WDDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"))
            );

            services.AddIdentityCore<Wanderer>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
                options.Password = GetPasswordOptions();
            })
                .AddEntityFrameworkStores<WDDbContext>()
                .AddDefaultTokenProviders()
                .AddSignInManager<SignInManager<Wanderer>>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>();

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();
            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenValidationParameters;
                    options.SaveToken = true;
                }
            );           
        }

        private PasswordOptions GetPasswordOptions()
        {
            return new PasswordOptions
            {
                RequireDigit = false,
                RequiredLength = 5,
                RequiredUniqueChars = 0,
                RequireLowercase = false,
                RequireNonAlphanumeric = false,
                RequireUppercase = false
            };
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
            };
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WanderersDiary.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @".well-known")),
                RequestPath = new PathString("/.well-known"),
                ServeUnknownFileTypes = true
            });
        }
    }
}
