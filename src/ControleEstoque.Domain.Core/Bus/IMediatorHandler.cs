using System.Threading.Tasks;
using ControleEstoque.Domain.Core.Commands;
using ControleEstoque.Domain.Core.Events;


namespace ControleEstoque.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
