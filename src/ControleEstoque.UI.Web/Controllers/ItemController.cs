using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.UI.Web.Controllers
{
    [Authorize]
    public class ItemController : BaseController
    {
        private readonly IItemAppService _itemAppService;

        public ItemController(IItemAppService itemAppService,
                              INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _itemAppService = itemAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("item-management/list-all")]
        public IActionResult Index()
        {
            return View(_itemAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("item-management/item-details/{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemViewModel = _itemAppService.GetById(id.Value);

            if (itemViewModel == null)
            {
                return NotFound();
            }

            return View(itemViewModel);
        }

        [HttpGet]
        //[Authorize(Policy = "CanWriteItemData")]
        [Route("item-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteItemData")]
        [Route("item-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemViewModel itemViewModel)
        {
            if (!ModelState.IsValid) return View(itemViewModel);
            _itemAppService.Register(itemViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Item Registered!";

            return View(itemViewModel);
        }

        [HttpGet]
        //Authorize(Policy = "CanWriteItemData")]
        [Route("item-management/edit-item/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemViewModel = _itemAppService.GetById(id.Value);

            if (itemViewModel == null)
            {
                return NotFound();
            }

            return View(itemViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteItemData")]
        [Route("item-management/edit-item/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ItemViewModel itemViewModel)
        {
            if (!ModelState.IsValid) return View(itemViewModel);

            _itemAppService.Update(itemViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Item Updated!";

            return View(itemViewModel);
        }

        [HttpGet]
        //[Authorize(Policy = "CanRemoveItemData")]
        [Route("item-management/remove-item/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemViewModel = _itemAppService.GetById(id.Value);

            if (itemViewModel == null)
            {
                return NotFound();
            }

            return View(itemViewModel);
        }

        [HttpPost, ActionName("Delete")]
        //[Authorize(Policy = "CanRemoveCustomerData")]
        [Route("item-management/remove-item/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _itemAppService.Remove(id);

            if (!IsValidOperation()) return View(_itemAppService.GetById(id));

            ViewBag.Sucesso = "Item Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("item-management/item-history/{id:int}")]
        public JsonResult History(int id)
        {
            var itemHistoryData = _itemAppService.GetAllHistory(id);
            return Json(itemHistoryData);
        }
    }
}