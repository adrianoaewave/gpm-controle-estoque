using ControleEstoque.Application.ViewModels;
using System.Collections.Generic;

namespace ControleEstoque.Application.Interfaces
{
    public interface IItemProductAppService
    {
        void Register(ItemProductViewModel itemProductViewModel);
        IEnumerable<ItemProductViewModel> GetAll();
        ItemProductViewModel GetById(int idItem, int idProduct);
        void Update(ItemProductViewModel itemProductViewModel);
        void Remove(int idItem, int idProduct);
    }
}
