using ControleEstoque.Application.ViewModels;
using System.Collections.Generic;

namespace ControleEstoque.Application.Interfaces
{
    public interface IOrderAppService
    {
        void Register(OrderViewModel orderViewModel);
        IEnumerable<OrderViewModel> GetAll();
        OrderViewModel GetById(int id);
        void Update(OrderViewModel orderViewModel);
        void Remove(int id);
    }
}
