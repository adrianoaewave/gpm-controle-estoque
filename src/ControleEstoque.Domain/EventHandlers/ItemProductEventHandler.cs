using ControleEstoque.Domain.Events.ItemProducts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.EventHandlers
{
    public class ItemProductEventHandler :
        INotificationHandler<ItemProductRegisteredEvent>,
        INotificationHandler<ItemProductUpdatedEvent>,
        INotificationHandler<ItemProductRemovedEvent>
    {
        public Task Handle(ItemProductUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ItemProductRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ItemProductRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
