using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.UI.Web.Controllers
{
    public class ItemProductController : BaseController
    {
        private readonly IItemProductAppService _itemProductAppService;

        public ItemProductController(IItemProductAppService itemProductAppService,
                                     INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _itemProductAppService = itemProductAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("item-product-management/list-all")]
        public IActionResult Index()
        {
            return View(_itemProductAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("item-product-management/item-details/{id:int}")]
        public IActionResult Details(int? idItem, int? idProduct)
        {
            if (idItem == null || idProduct == null)
            {
                return NotFound();
            }

            var itemProductViewModel = _itemProductAppService.GetById(idItem.Value, idProduct.Value);

            if (itemProductViewModel == null)
            {
                return NotFound();
            }

            return View(itemProductViewModel);
        }

        [HttpGet]
        //[Authorize(Policy = "CanWriteItemProductData")]
        [Route("item-product-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteItemData")]
        [Route("item-product-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemProductViewModel itemProductViewModel)
        {
            if (!ModelState.IsValid) return View(itemProductViewModel);
            _itemProductAppService.Register(itemProductViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Item Product Registered!";

            return View(itemProductViewModel);
        }

        [HttpGet]
        //Authorize(Policy = "CanWriteItemProductData")]
        [Route("item-product-management/edit-item/{id:int}")]
        public IActionResult Edit(int? idItem, int? idProduct)
        {
            if (idItem == null || idProduct == null)
            {
                return NotFound();
            }

            var itemProductViewModel = _itemProductAppService.GetById(idItem.Value, idProduct.Value);

            if (itemProductViewModel == null)
            {
                return NotFound();
            }

            return View(itemProductViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteItemProductData")]
        [Route("item-product-management/edit-item/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ItemProductViewModel itemProductViewModel)
        {
            if (!ModelState.IsValid) return View(itemProductViewModel);

            _itemProductAppService.Update(itemProductViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Item Product Updated!";

            return View(itemProductViewModel);
        }

        [HttpGet]
        //[Authorize(Policy = "CanRemoveItemProductData")]
        [Route("item-product-management/remove-item/{id:int}")]
        public IActionResult Delete(int? idItem, int? idProduct)
        {
            if (idItem == null || idProduct == null)
            {
                return NotFound();
            }

            var itemProductViewModel = _itemProductAppService.GetById(idItem.Value, idProduct.Value);

            if (itemProductViewModel == null)
            {
                return NotFound();
            }

            return View(itemProductViewModel);
        }

        [HttpPost, ActionName("Delete")]
        //[Authorize(Policy = "CanRemoveItemProductData")]
        [Route("item-product-management/remove-item/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idItem, int idProduct)
        {
            _itemProductAppService.Remove(idItem, idProduct);

            if (!IsValidOperation()) return View(_itemProductAppService.GetById(idItem, idProduct));

            ViewBag.Sucesso = "Item Product Removed!";
            return RedirectToAction("Index");
        }
    }
}