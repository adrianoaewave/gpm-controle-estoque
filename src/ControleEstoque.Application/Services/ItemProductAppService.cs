using AutoMapper;
using AutoMapper.QueryableExtensions;
using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Commands.ItemProducts;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Application.Services
{
    public class ItemProductAppService : IItemProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IItemProductRepository _itemProductRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ItemProductAppService(IMapper mapper,
                                     IItemProductRepository itemProductRepository,
                                     IMediatorHandler bus,
                                     IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _itemProductRepository = itemProductRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<ItemProductViewModel> GetAll()
        {
            return _itemProductRepository.GetAll().ProjectTo<ItemProductViewModel>(_mapper.ConfigurationProvider);
        }

        public ItemProductViewModel GetById(int idItem, int idProduct)
        {
            return _mapper.Map<ItemProductViewModel>(_itemProductRepository.GetById(idItem, idProduct));
        }

        public void Register(ItemProductViewModel itemViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewItemProductCommand>(itemViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ItemProductViewModel itemProductViewModel)
        {
            var updateCommand = _mapper.Map<UpdateItemProductCommand>(itemProductViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(int idItem, int idProduct)
        {
            var removeCommand = new RemoveItemProductCommand(idItem, idProduct);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
