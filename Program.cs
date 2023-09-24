
using AppointmentschedularService.Data;
using AppointmentschedularService.Repository.IRepository;
using AppointmentschedularService.Repository.RepositoryImpl;
using AppointmentschedularService.Services.IServices;
using AppointmentschedularService.Services.ServicesImpl;
using Microsoft.EntityFrameworkCore;

namespace AppointmentschedularService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var provider=builder.Services.BuildServiceProvider();
            var configuration=provider.GetRequiredService<IConfiguration>();

            builder.Services.AddDbContext<DataContext>(item => item.UseSqlServer(configuration.GetConnectionString("MyConn")));
            builder.Services.AddTransient<IUserService, UserServiceImpl>();
            builder.Services.AddTransient<IAppointmentService, AppointmentServiceImpl>();
            builder.Services.AddTransient<IRepository, RepositoryImpl>();


            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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