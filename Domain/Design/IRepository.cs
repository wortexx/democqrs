using System;

namespace Domain.Design
{
    public interface IRepository<out TAggregateRoot> where TAggregateRoot : RootAggregate
    {
        void Save(RootAggregate aggregate, int expectedVersion);
        TAggregateRoot GetById(Guid id);
        void Save(RootAggregate aggregate);
    }
}