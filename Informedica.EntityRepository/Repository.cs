using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Informedica.EntityRepository.Entities;
using Informedica.EntityRepository.Exceptions;

namespace Informedica.EntityRepository
{
    public class Repository<TEnt, TId> : IRepository<TEnt, TId>
        where TEnt : class, IEntity<TEnt, TId>
    {
        private readonly IRepository<TEnt, TId> _repository;

        public Repository(IRepository<TEnt, TId> repository)
        {
            Contract.Requires<NullReferenceException>(repository != null);

            _repository = repository;
        }

        #region IRepository<TEnt,TId> Members

        /// <summary>
        /// Adds an entity to the repository
        /// </summary>
        /// <param name="entity"></param>
        [Pure]
        public void Add(TEnt entity)
        {
            Contract.Requires<NullReferenceException>(entity != null);
            Contract.Requires<DuplicateEntityException>(!ContainsEntity(entity));

            _repository.Add(entity);
        }

        [Pure]
        public void Remove(TEnt entity)
        {
            Contract.Requires<NullReferenceException>(entity != null);
            Contract.Requires<DoesNotContainEntityException>(Contains(entity));

            _repository.Remove(entity);
        }

        public void Remove(TId id)
        {
            Remove(_repository.GetById(id));
        }

        #endregion

        [Pure]
        public bool ContainsEntity(TEnt entity)
        {
            Contract.Requires<NullReferenceException>(entity != null);

            if (Contains(entity)) return true;
            if (this.SingleOrDefault(e => e.Id.Equals(entity.Id)) != null) return true;
            return this.SingleOrDefault(e => e.IsIdentical(entity)) != null;
        }

        #region Implementation of IRepository<TEnt,TId>

        public TEnt GetById(TId id)
        {
            return _repository.GetById(id);
        }

        public bool Contains(TEnt entity)
        {
            return _repository.Contains(entity);
        }

        public int Count
        {
            get { return _repository.Count; }
        }

        #endregion

        #region Implementation of IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<TEnt> GetEnumerator()
        {
            return _repository.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}