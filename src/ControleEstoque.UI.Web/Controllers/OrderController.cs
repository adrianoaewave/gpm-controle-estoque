using ControleEstoque.Application.Interfaces;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.UI.Web.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService,
                              INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _orderAppService = orderAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order-management/list-all")]
        public IActionResult Index()
        {
            return View(_orderAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order-management/item-details/{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderViewModel = _orderAppService.GetById(id.Value);

            if (orderViewModel == null)
            {
                return NotFound();
            }

            return View(orderViewModel);
        }

        [HttpGet]
        //[Authorize(Policy = "CanWriteOrderData")]
        [Route("order-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteOrderData")]
        [Route("order-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid) return View(orderViewModel);
            _orderAppService.Register(orderViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Order Registered!";

            return View(orderViewModel);
        }

        [HttpGet]
        //Authorize(Policy = "CanWriteOrderData")]
        [Route("order-management/edit-item/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderViewModel = _orderAppService.GetById(id.Value);

            if (orderViewModel == null)
            {
                return NotFound();
            }

            return View(orderViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteOrderData")]
        [Route("order-management/edit-item/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid) return View(orderViewModel);

            _orderAppService.Update(orderViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Order Updated!";

            return View(orderViewModel);
        }

        [HttpGet]
        //[Authorize(Policy = "CanRemoveOrderData")]
        [Route("order-management/remove-item/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderViewModel = _orderAppService.GetById(id.Value);

            if (orderViewModel == null)
            {
                return NotFound();
            }

            return View(orderViewModel);
        }

        [HttpPost, ActionName("Delete")]
        //[Authorize(Policy = "CanRemoveCustomerData")]
        [Route("order-management/remove-order/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _orderAppService.Remove(id);

            if (!IsValidOperation()) return View(_orderAppService.GetById(id));

            ViewBag.Sucesso = "Item Removed!";
            return RedirectToAction("Index");
        }
    }
}