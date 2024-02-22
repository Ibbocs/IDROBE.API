using FluentValidation;
using FluentValidation.AspNetCore;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Beheviors;
using IDrobeAPI.Application.Exceptions.Middlewares;
using IDrobeAPI.Application.Features.SendQueries.Commands;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly);
            //middleware de service kimi vermek lazim
            //services.AddTransient<ExceptionMiddlewareFirst>();
            //services.AddTransient<ExceptionMiddleware>();

            //fullent validation
            services.AddValidatorsFromAssembly(assembly);

            services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateSendQueryCommandRequest>());
            //services.AddValidatorsFromAssemblyContaining(typeof(SendQueryModelValidator));
            //services.AddTransient<SendQueryModelValidator>();

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-US");//mesajlarin languagesi
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

            //Rules
            //services.AddTransient<ProductRules>();//bu formada hamsin elave elemeilsen
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));//bu formada tek yerden hamsin elave edirik rullari, amma base rule'dan inheretance edilmis

            //services.AddSingleton<IActionResponse, ActionResponse>();
            //services.AddScoped(typeof(IGenericActionResponse<>), typeof(GenericActionResponse<>));
        }

        public static void UseCustomExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            //app.UseMiddleware<ExceptionMiddlewareFirst>();
        }


        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            //rullari assembly icinde tapib hamsin ioc elave edir
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }
    }
}
