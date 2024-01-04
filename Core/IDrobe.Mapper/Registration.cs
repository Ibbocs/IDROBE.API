using AutoMapper;
using IDrobe.Mapper.AutoMapper;
using IDrobeAPI.Application.Interfaces.IAutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IDrobe.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<ICustomMapper, CustomMapper>();

        }
    }
}
