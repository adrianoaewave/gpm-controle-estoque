using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Services.Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService,
                               INotificationHandler<DomainNotification> notifications,
                               IMediatorHandler mediator) : base(notifications, mediator)
        {
            _orderAppService = orderAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order-management")]
        public IActionResult Get()
        {
            return Response(_orderAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order-management/{id:int}")]
        public IActionResult Get(int id)
        {
            var orderViewModel = _orderAppService.GetById(id);

            return Response(orderViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteOrderData")]
        [Route("order-management")]
        public IActionResult Post([FromBody]OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(orderViewModel);
            }

            _orderAppService.Register(orderViewModel);

            return Response(orderViewModel);
        }

        [HttpPut]
        //[Authorize(Policy = "CanWriteOrderData")]
        [Route("order-management")]
        public IActionResult Put([FromBody]OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(orderViewModel);
            }

            _orderAppService.Update(orderViewModel);

            return Response(orderViewModel);
        }

        [HttpDelete]
        //[Authorize(Policy = "CanRemoveOrderData")]
        [Route("order-management")]
        public IActionResult Delete(int id)
        {
            _orderAppService.Remove(id);

            return Response();
        }
    }
}