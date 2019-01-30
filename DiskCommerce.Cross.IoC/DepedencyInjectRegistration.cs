using DiskCommerce.Commom.Notifications;
using DiskCommerce.Commom.Publisher;
using DiskCommerce.Database.Context;
using DiskCommerce.Database.Repositories;
using DiskCommerce.Database.UnitOfWork;
using DiskCommerce.Domain.Commands;
using DiskCommerce.Domain.Events;
using DiskCommerce.Domain.Interfaces;
using DiskCommerce.Domain.Services;
using DiskCommerce.Infrastructure.ExternalServices.SpotifyService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiskCommerce.Cross.IoC
{
    public static class DepedencyInjectRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Publisher 
            services.AddScoped<IPublisher, Publisher>();

            // Domain Services
            services.AddScoped<ISpotifyService, SpotifyService>();
            services.AddScoped<ICashBackCalculatorService, CashBackCalculatorService>();
            services.AddScoped<ICashBackConfigurationService, CashBackConfigurationService>();
            
            //Repository
            services.AddScoped<IDiskReadRepositoy, ReadOnlyDiskCollection>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<ICashBackRepository, CashBackRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Context
            //services.AddScoped<DiskEcommerceContext>();
            //services.AddScoped<DbContextOptions<DiskEcommerceContext>>();
            services.AddDbContext<DiskEcommerceContext>(opt => opt.UseInMemoryDatabase("eDiskCommerce",null));

            //Commands
            services.AddScoped<IRequestHandler<PlaceOrderCommand,Unit>, PlaceOrderCommandHandler>();

            //Events
            services.AddScoped<INotificationHandler<OrderPlacedEvent>, OrderPlacedEventHandler>();
            services.AddScoped<DomainNotificationHandler>();

           
        }
    }
}
