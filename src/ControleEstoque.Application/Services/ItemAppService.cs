using AutoMapper;
using AutoMapper.QueryableExtensions;
using ControleEstoque.Application.EventSourcedNormalizers;
using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Commands.Items;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Application.Services
{
    public class ItemAppService : IItemAppService
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ItemAppService(IMapper mapper,
                              IItemRepository itemRepository,
                              IMediatorHandler bus,
                              IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }
  
        public IEnumerable<ItemViewModel> GetAll()
        {
            return _itemRepository.GetAll().ProjectTo<ItemViewModel>(_mapper.ConfigurationProvider);
        }

        public ItemViewModel GetById(int id)
        {
            return _mapper.Map<ItemViewModel>(_itemRepository.GetById(id));
        }

        public void Register(ItemViewModel itemViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewItemCommand>(itemViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ItemViewModel itemViewModel)
        {
            var updateCommand = _mapper.Map<UpdateItemCommand>(itemViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveItemCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<ItemHistoryData> GetAllHistory(int id)
        {
            return ItemHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
