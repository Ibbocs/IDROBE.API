using IDrobeAPI.Persistence;
using IDrobeAPI.Application;
using IDrobe.Mapper;
using IDrobeAPI.Infrastructure;

namespace IDrobeAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var env = builder.Environment;
            builder.Configuration.SetBasePath(env.ContentRootPath) //IdrobeAPI.API path'i
                .AddJsonFile("appsettings.json", optional:false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.Services.AddPersistence(builder.Configuration); //persistance layer services...
            builder.Services.AddApplication(); //application layer services...
            builder.Services.AddCustomMapper(); //mapper layer services...
            builder.Services.AddInfrastructure(builder.Configuration); //infrastructure layer services...
            builder.Services.AddPresentationAPI();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //exception midilvare
            app.UseCustomExceptionHandlingMiddleware();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
