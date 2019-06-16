using ControleEstoque.Domain.Commands.Items;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Core.Notifications;
using ControleEstoque.Domain.Events.Items;
using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.CommandHandlers
{
    public class ItemCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewItemCommand, bool>,
        IRequestHandler<UpdateItemCommand, bool>,
        IRequestHandler<RemoveItemCommand, bool>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMediatorHandler Bus;

        public ItemCommandHandler(IItemRepository itemRepository,
                                  IUnitOfWork uow,
                                  IMediatorHandler bus,
                                  INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _itemRepository = itemRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewItemCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var item = new Item(0, message.Name, message.QuantidadeEstoque, message.ERPCode);

            _itemRepository.Add(item);

            if (Commit())
            {
                Bus.RaiseEvent(new ItemRegisteredEvent(item.Id, item.Name, item.QuantidadeEstoque, item.ERPCode));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateItemCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var item = new Item(message.Id, message.Name, message.QuantidadeEstoque, message.ERPCode);

            _itemRepository.Update(item);

            if (Commit())
            {
                Bus.RaiseEvent(new ItemUpdatedEvent(item.Id, item.Name, item.QuantidadeEstoque, item.ERPCode));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveItemCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _itemRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ItemRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _itemRepository.Dispose();
        }
    }
}
