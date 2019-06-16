using ControleEstoque.Application.EventSourcedNormalizers;
using ControleEstoque.Application.ViewModels;
using System.Collections.Generic;

namespace ControleEstoque.Application.Interfaces
{
    public interface IProductAppService
    {
        void Register(ProductViewModel productViewModel);
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel GetById(int id);
        void Update(ProductViewModel productViewModel);
        void Remove(int id);
        IList<ProductHistoryData> GetAllHistory(int id);
    }
}
