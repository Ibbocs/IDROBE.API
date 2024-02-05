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
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.Services.AddPersistence(builder.Configuration); //persistance layer services...
            builder.Services.AddApplication(); //application layer services...
            builder.Services.AddCustomMapper(); //mapper layer services...
            builder.Services.AddInfrastructure(builder.Configuration); //infrastructure layer services...
            builder.Services.AddPresentationAPI();

            //ConfigureServices metoduna ekleyin
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()          // Tüm originlere izin ver (daha güvenli bir yapı için sadece belirli originlere izin verebilirsiniz)
                        .AllowAnyMethod()          // Tüm HTTP metodlarına izin ver
                        .AllowAnyHeader()          // Tüm HTTP başlıklarına izin ver
                        .WithExposedHeaders("Header1", "Header2") // Tarayıcı tarafından görülebilecek özel başlıkları belirtmek için
                        .SetIsOriginAllowedToAllowWildcardSubdomains(); // Altbölge ve alt alan adlarını etkinleştir (Opsiyonel)
                        //.AllowCredentials();       // İsteğin kimlik bilgilerini göndermesine izin ver (true olarak ayarlandığında sadece belirli originlere izin verilebilir)
                });
            });//todo credentiali acmaliayam, origin falan verib.-Cors

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //loging

            // Configure metoduna ekleyin (UseCors'un UseMvc'den önce olması önemlidir)
            app.UseCors("MyCorsPolicy");

            //exception midilvare
            app.UseCustomExceptionHandlingMiddleware();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
