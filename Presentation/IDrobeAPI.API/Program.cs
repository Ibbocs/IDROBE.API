using IDrobeAPI.Persistence;

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
