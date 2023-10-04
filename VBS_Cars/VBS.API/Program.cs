
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VBS.DBEngine;
using VBS.Repository.Interface;
using VBS.Repository.Repository;
using VBS.Service.Interface;
using VBS.Service.Service;

namespace VBS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("https://localhost:7170")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: "AllowAll",
            //                      policy =>
            //                      {
            //                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //                      });
            //});



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {

                    In = ParameterLocation.Header,
                    Description = "Insert Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "Jwt",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme{
                        Reference = new OpenApiReference{
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                        },
                        new String[]{ }
                    }

                });
            }
                );
            var Key = Encoding.ASCII.GetBytes("vehiclebsffffffffffffff");
            builder.Services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //SQL handler
            builder.Services.AddTransient<IDapperHandler, DapperHandler>();


            builder.Services.AddTransient<IAuthenticateRepository, AuthenticateRepository>();

            builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();

            // User SERVICE REPOSITORY
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();

            //Vehicle Service Repository
            builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
            builder.Services.AddTransient<IVehicleService, VehicleService>();

            //booking Service Repository
            builder.Services.AddTransient<IBookingRepository, BookingRepository>();
            builder.Services.AddTransient<IBookingService, BookingService>();

            //Feedback Service Repository
            builder.Services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddTransient<IFeedbackService, FeedbackService>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthentication();


            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("AllowSpecificOrigin");
            app.Run();
        }
    }
}