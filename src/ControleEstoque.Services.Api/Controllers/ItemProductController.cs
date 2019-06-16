using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Services.Api.Controllers
{
    public class ItemProductController : ApiController
    {
        private readonly IItemProductAppService _itemProductAppService;

        public ItemProductController(
            IItemProductAppService itemProductAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _itemProductAppService = itemProductAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("item-product-management")]
        public IActionResult Get()
        {
            return Response(_itemProductAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("item-product/{id:int}")]
        public IActionResult Get(int idItem, int idProduct)
        {
            var itemProductViewModel = _itemProductAppService.GetById(idItem, idProduct);

            return Response(itemProductViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteItemProductData")]
        [Route("item-product-management")]
        public IActionResult Post([FromBody]ItemProductViewModel itemProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(itemProductViewModel);
            }

            _itemProductAppService.Register(itemProductViewModel);

            return Response(itemProductViewModel);
        }

        [HttpPut]
        //[Authorize(Policy = "CanWriteItemProductData")]
        [Route("item-product-management")]
        public IActionResult Put([FromBody]ItemProductViewModel itemProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(itemProductViewModel);
            }

            _itemProductAppService.Update(itemProductViewModel);

            return Response(itemProductViewModel);
        }

        [HttpDelete]
        //[Authorize(Policy = "CanRemoveItemProductData")]
        [Route("item-product-management")]
        public IActionResult Delete(int idItem, int idProduct)
        {
            _itemProductAppService.Remove(idItem, idProduct);

            return Response();
        }
    }
}