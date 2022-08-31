using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stackoverflow.Data.Dal;
using Stackoverflow.Jwt;
using Stackoverflow.Data.Dal.Repository.Abstract;
using Stackoverflow.Data.Dal.Repository.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Stackoverflow_api
{

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IAuthService), typeof(AuthService));
            services.AddTransient(typeof(ITokenHelper), typeof(JwtHelper));

            services.AddControllers();
            services.AddDbContext<EfContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CForumConnection")));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,

                };
            });

            //services.AddAuthentication("FiverSecurityScheme")
            // .AddCookie("FiverSecurityScheme", options =>
            // {
            //     options.AccessDeniedPath = new PathString("/Security/Access");
            //     options.LoginPath = new PathString("/Home/login");
            // });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", configurePolicy: builder => builder.WithOrigins("https://localhost:44371"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("https://localhost:44371").AllowAnyHeader());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                 
            });
        }
    }
}
