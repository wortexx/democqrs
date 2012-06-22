using System;

namespace SimpleCQRS.Domain.Design
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        TAggregateRoot GetById(Guid id);
    }
}