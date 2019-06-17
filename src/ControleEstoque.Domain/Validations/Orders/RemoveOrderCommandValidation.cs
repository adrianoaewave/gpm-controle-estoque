using ControleEstoque.Domain.Commands.Orders;

namespace ControleEstoque.Domain.Validations.Orders
{
    public class RemoveOrderCommandValidation : OrderValidation<RemoveOrderCommand>
    {
        public RemoveOrderCommandValidation()
        {
            ValidateId();
        }
    }
}
