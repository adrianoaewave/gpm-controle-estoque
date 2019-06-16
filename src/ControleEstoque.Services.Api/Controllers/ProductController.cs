using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Core.Bus;
using ControleEstoque.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Services.Api.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(
            IProductAppService productAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product-management")]
        public IActionResult Get()
        {
            return Response(_productAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product-management/{id:int}")]
        public IActionResult Get(int id)
        {
            var productViewModel = _productAppService.GetById(id);

            return Response(productViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteProductData")]
        [Route("product-management")]
        public IActionResult Post([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _productAppService.Register(productViewModel);

            return Response(productViewModel);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteProductData")]
        [Route("product-management")]
        public IActionResult Put([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _productAppService.Update(productViewModel);

            return Response(productViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveProductData")]
        [Route("product-management")]
        public IActionResult Delete(int id)
        {
            _productAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("product-management/history/{id:int}")]
        public IActionResult History(int id)
        {
            var productHistoryData = _productAppService.GetAllHistory(id);
            return Response(productHistoryData);
        }
    }
}