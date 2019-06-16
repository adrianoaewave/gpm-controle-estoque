using System;
using System.Collections.Generic;
using ControleEstoque.Application.EventSourcedNormalizers;
using ControleEstoque.Application.ViewModels;

namespace ControleEstoque.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(int id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(int id);
        IList<CustomerHistoryData> GetAllHistory(int id);
    }
}
