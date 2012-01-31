using System.Collections.Generic;
using Informedica.EntityRepository.Entities;

namespace Informedica.EntityRepository
{
    public interface IRepository<TEnt, in TId>: IEnumerable<TEnt>
        where TEnt: class, IEntity<TEnt, TId> 
    {
        TEnt GetById(TId id);

        bool Contains(TEnt entity);
        void Add(TEnt entity);
        void Remove(TEnt entity);
        void Remove(TId id);
        int Count { get; }
    }
}
