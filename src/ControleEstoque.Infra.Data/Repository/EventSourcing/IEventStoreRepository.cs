using System;
using System.Collections.Generic;
using ControleEstoque.Domain.Core.Events;

namespace ControleEstoque.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(int aggregateId);
    }
}