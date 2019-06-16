using ControleEstoque.Domain.Commands.ItemProducts;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Core.Notifications;
using ControleEstoque.Domain.Events.ItemProducts;
using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.CommandHandlers
{
    public class ItemProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewItemProductCommand, bool>,
        IRequestHandler<UpdateItemProductCommand, bool>,
        IRequestHandler<RemoveItemProductCommand, bool>
    {
        private readonly IItemProductRepository _itemProductRepository;
        private readonly IMediatorHandler Bus;

        public ItemProductCommandHandler(IItemProductRepository itemProductRepository,
                                         IUnitOfWork uow,
                                         IMediatorHandler bus,
                                         INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _itemProductRepository = itemProductRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewItemProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var itemProduct = new ItemProduct(message.IdItem, message.IdProduct, message.ItemProductQuantity);

            _itemProductRepository.Add(itemProduct);

            if (Commit())
            {
                Bus.RaiseEvent(new ItemProductRegisteredEvent(itemProduct.IdItem, itemProduct.IdProduct, itemProduct.ItemProductQuantity));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateItemProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var itemProduct = new ItemProduct(message.IdItem, message.IdProduct, message.ItemProductQuantity);

            _itemProductRepository.Update(itemProduct);

            if (Commit())
            {
                Bus.RaiseEvent(new ItemProductUpdatedEvent(itemProduct.IdItem, itemProduct.IdProduct, itemProduct.ItemProductQuantity));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveItemProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _itemProductRepository.Remove(message.IdItem, message.IdProduct);

            if (Commit())
            {
                Bus.RaiseEvent(new ItemProductRemovedEvent(message.IdItem, message.IdProduct));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _itemProductRepository.Dispose();
        }
    }
}
