using ControleEstoque.Application.EventSourcedNormalizers;
using ControleEstoque.Application.ViewModels;
using System.Collections.Generic;

namespace ControleEstoque.Application.Interfaces
{
    public interface IItemAppService
    {
        void Register(ItemViewModel itemViewModel);
        IEnumerable<ItemViewModel> GetAll();
        ItemViewModel GetById(int id);
        void Update(ItemViewModel itemViewModel);
        void Remove(int id);
        IList<ItemHistoryData> GetAllHistory(int id);
    }
}
