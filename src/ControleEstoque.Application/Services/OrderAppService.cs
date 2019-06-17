using AutoMapper;
using AutoMapper.QueryableExtensions;
using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Commands.Orders;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Interfaces;
using ControleEstoque.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public OrderAppService(IMapper mapper,
                              IOrderRepository orderRepository,
                              IMediatorHandler bus,
                              IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            return _orderRepository.GetAll().ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
        }

        public OrderViewModel GetById(int id)
        {
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }

        public void Register(OrderViewModel orderViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewOrderCommand>(orderViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(OrderViewModel orderViewModel)
        {
            var updateCommand = _mapper.Map<UpdateOrderCommand>(orderViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveOrderCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
