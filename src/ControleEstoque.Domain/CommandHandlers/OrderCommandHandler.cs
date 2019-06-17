using ControleEstoque.Domain.Commands.Orders;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Core.Notifications;
using ControleEstoque.Domain.Events.Orders;
using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.CommandHandlers
{
    public class OrderCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewOrderCommand, bool>,
        IRequestHandler<UpdateOrderCommand, bool>,
        IRequestHandler<RemoveOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler Bus;

        public OrderCommandHandler(IOrderRepository orderRepository,
                                  IUnitOfWork uow,
                                  IMediatorHandler bus,
                                  INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _orderRepository = orderRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var order = new Order(0, message.OrderDate, message.DeliveryDays, message.IdCustomer, message.DeliveryDescription, 
                                  message.Observation, message.ERPCode);

            _orderRepository.Add(order);

            if (Commit())
            {
                Bus.RaiseEvent(new OrderRegisteredEvent(order.Id, order.OrderDate, order.DeliveryDays, order.IdCustomer, order.DeliveryDescription,
                                                        order.Observation, order.ERPCode));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var order = new Order(message.Id, message.OrderDate, message.DeliveryDays, message.IdCustomer, message.DeliveryDescription,
                                  message.Observation, message.ERPCode);

            _orderRepository.Update(order);

            if (Commit())
            {
                Bus.RaiseEvent(new OrderUpdatedEvent(order.Id, order.OrderDate, order.DeliveryDays, order.IdCustomer, order.DeliveryDescription,
                                                        order.Observation, order.ERPCode));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _orderRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new OrderRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _orderRepository.Dispose();
        }
    }
}
