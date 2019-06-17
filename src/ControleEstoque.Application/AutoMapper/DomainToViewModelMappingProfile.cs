using AutoMapper;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Models;

namespace ControleEstoque.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Item, ItemViewModel>();
            CreateMap<ItemProduct, ItemProductViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
