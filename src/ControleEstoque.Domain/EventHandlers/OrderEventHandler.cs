using ControleEstoque.Domain.Events.Orders;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.EventHandlers
{
    public class OrderEventHandler :
        INotificationHandler<OrderRegisteredEvent>,
        INotificationHandler<OrderUpdatedEvent>,
        INotificationHandler<OrderRemovedEvent>
    {
        public Task Handle(OrderUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(OrderRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(OrderRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
