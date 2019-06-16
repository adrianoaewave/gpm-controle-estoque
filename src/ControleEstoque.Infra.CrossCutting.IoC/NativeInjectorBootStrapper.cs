using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.Services;
using ControleEstoque.Domain.CommandHandlers;
using ControleEstoque.Domain.Commands.Customers;
using ControleEstoque.Domain.Commands.Items;
using ControleEstoque.Domain.Commands.Products;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Core.Events;
using ControleEstoque.Domain.Core.Notifications;
using ControleEstoque.Domain.EventHandlers;
using ControleEstoque.Domain.Events.Customers;
using ControleEstoque.Domain.Events.Items;
using ControleEstoque.Domain.Events.Products;
using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Infra.CrossCutting.Bus;
using ControleEstoque.Infra.CrossCutting.Identity.Authorization;
using ControleEstoque.Infra.CrossCutting.Identity.Models;
using ControleEstoque.Infra.CrossCutting.Identity.Services;
using ControleEstoque.Infra.Data.Context;
using ControleEstoque.Infra.Data.EventSourcing;
using ControleEstoque.Infra.Data.Repository;
using ControleEstoque.Infra.Data.Repository.EventSourcing;
using ControleEstoque.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ControleEstoque.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IItemAppService, ItemAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            services.AddScoped<INotificationHandler<ItemRegisteredEvent>, ItemEventHandler>();
            services.AddScoped<INotificationHandler<ItemUpdatedEvent>, ItemEventHandler>();
            services.AddScoped<INotificationHandler<ItemRemovedEvent>, ItemEventHandler>();

            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewItemCommand, bool>, ItemCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateItemCommand, bool>, ItemCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveItemCommand, bool>, ItemCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, bool>, ProductCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ControleEstoqueContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}