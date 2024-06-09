using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Collections.Immutable;
using webApi.Dal;
using WebShiffi.Bal;
using WebShiffi.BL;
using WebShiffi.Dal;
using WebShiffi.DAL;

namespace AngularServer1
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
            services.AddLogging();
            services.AddAutoMapper(typeof(Startup));
            services.AddLogging();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IGiftDal, GiftDal>();
            services.AddScoped<IGiftService, GiftService>();
            services.AddScoped<IDonorDal, DonorDal>();
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IOrdersDal, OrdersDal>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<IWinnerService, WinnerService>();
            services.AddScoped<IWinnerDal, WinnerDal>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ChineseSaleContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ChiniesSaleContext")));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "development web site")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = Configuration["Jwt:Issuer"],
              ValidAudience = Configuration["Jwt:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
          };
      });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "shifi", Version = "v1" });

                // Add the security definition for JWT Bearer token
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                // Add the security requirement for JWT Bearer token
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

                // Configure Swagger to include the security header
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddMvc();
            services.AddControllers();
            services.AddRazorPages();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();




            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/orders"), donorApp =>
            {
                app.UseMiddleware<AuthenticationMiddleware>();
            });
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/Gift"), donorApp =>
            {
                app.UseMiddleware<AuthenticationMiddleware>();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //לא בטוח שאפשר להוריד

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });


        }

    }
}
