using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Application.Interfaces.Repositories;
using IDrobeAPI.Domain.Identity;
using IDrobeAPI.Persistence.Context;
using IDrobeAPI.Persistence.Implementation.Repositories;
using IDrobeAPI.Persistence.Implementation.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.
            UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //Repository And UnitOfWork
            RegisterRepositories(services);
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            // Get all repository interfaces from the assembly
            var repositoryInterfaces = typeof(IRepository<>).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.Name.EndsWith("Repository"));

            // Register repositories
            foreach (var repositoryInterface in repositoryInterfaces)
            {
                var repositoryImplementations = typeof(ReadRepository<>).Assembly.GetTypes()
                    .Where(type => type.IsClass && !type.IsAbstract && repositoryInterface.IsAssignableFrom(type));

                foreach (var implementation in repositoryImplementations)
                {
                    services.AddScoped(repositoryInterface, implementation);
                }
            }

            // Unit of Work registration
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        //private static void RegisterServices(IServiceCollection services)
        //{
        //    // Get all service interfaces from the assembly
        //    var serviceInterfaces = typeof(ServiceRegistration).Assembly.GetTypes()
        //        .Where(type => type.IsInterface && type.Name.EndsWith("Service"));

        //    // Register services
        //    foreach (var serviceInterface in serviceInterfaces)
        //    {
        //        var serviceImplementations = typeof(ServiceRegistration).Assembly.GetTypes()
        //            .Where(type => type.IsClass && !type.IsAbstract && serviceInterface.IsAssignableFrom(type));

        //        foreach (var implementation in serviceImplementations)
        //        {
        //            services.AddScoped(serviceInterface, implementation);
        //        }
        //    }
        //}

    }
}
