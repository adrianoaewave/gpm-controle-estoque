using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Services.Api.Controllers
{
    public class ItemController : ApiController
    {
        private readonly IItemAppService _itemAppService;

        public ItemController(
            IItemAppService itemAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _itemAppService = itemAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("item-management")]
        public IActionResult Get()
        {
            return Response(_itemAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("item-management/{id:id}")]
        public IActionResult Get(int id)
        {
            var itemViewModel = _itemAppService.GetById(id);

            return Response(itemViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteItemData")]
        [Route("item-management")]
        public IActionResult Post([FromBody]ItemViewModel itemViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(itemViewModel);
            }

            _itemAppService.Register(itemViewModel);

            return Response(itemViewModel);
        }

        [HttpPut]
        //[Authorize(Policy = "CanWriteItemData")]
        [Route("item-management")]
        public IActionResult Put([FromBody]ItemViewModel itemViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(itemViewModel);
            }

            _itemAppService.Update(itemViewModel);

            return Response(itemViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveItemData")]
        [Route("item-management")]
        public IActionResult Delete(int id)
        {
            _itemAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("item-management/history/{id:int}")]
        public IActionResult History(int id)
        {
            var itemHistoryData = _itemAppService.GetAllHistory(id);
            return Response(itemHistoryData);
        }
    }
}