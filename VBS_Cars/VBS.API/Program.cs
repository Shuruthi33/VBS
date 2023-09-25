
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
                options.AddPolicy(name: "AllowSpecificOrigins",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}