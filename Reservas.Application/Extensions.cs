using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Application.Services;
using Reservas.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IReservaService, ReservaService>();
            services.AddTransient<IReservaFactory, ReservaFactory>();



            return services;
        }
    }
}
