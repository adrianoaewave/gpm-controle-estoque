using AutoMapper;
using ControleEstoque.Application.ViewModels;
using ControleEstoque.Domain.Commands.Customers;
using ControleEstoque.Domain.Commands.ItemProducts;
using ControleEstoque.Domain.Commands.Items;
using ControleEstoque.Domain.Commands.Products;

namespace ControleEstoque.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name));

            CreateMap<ItemViewModel, RegisterNewItemCommand>()
                .ConstructUsing(c => new RegisterNewItemCommand(c.Name, c.QuantidadeEstoque, c.ERPCode));
            CreateMap<ItemViewModel, UpdateItemCommand>()
                .ConstructUsing(c => new UpdateItemCommand(c.Id, c.Name, c.QuantidadeEstoque, c.ERPCode));

            CreateMap<ItemProductViewModel, RegisterNewItemProductCommand>()
                .ConstructUsing(c => new RegisterNewItemProductCommand(c.IdItem, c.IdProduct, c.ItemProductQuantity));
            CreateMap<ItemProductViewModel, UpdateItemProductCommand>()
                .ConstructUsing(c => new UpdateItemProductCommand(c.IdItem, c.IdProduct, c.ItemProductQuantity));

            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(c => new RegisterNewProductCommand(c.Name, c.ERPCode));
            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(c => new UpdateProductCommand(c.Id, c.Name, c.ERPCode));
        }
    }
}
