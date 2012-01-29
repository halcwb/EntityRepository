using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Informedica.EntityRepository.xTests
{
    internal class FakeRepository : IRepository<Tests.TestEntity, int>
    {
        private readonly IList<Tests.TestEntity> _entities = new List<Tests.TestEntity>();

        #region Implementation of IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<Tests.TestEntity> GetEnumerator()
        {
            return _entities.GetEnumerator();
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

        #region Implementation of IRepository<TestEntity,int>

        public Tests.TestEntity GetById(int id)
        {
            return _entities.SingleOrDefault(e => e.Id.Equals(id));
        }

        public bool Contains(Tests.TestEntity entity)
        {
            return _entities.Contains(entity);
        }

        public void Add(Tests.TestEntity entity)
        {
            _entities.Add(entity);
        }

        public void Remove(Tests.TestEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Remove(int id)
        {
            var ent = _entities.Single(e => e.Id == id);
            _entities.Remove(ent);
        }

        public int Count
        {
            get { return _entities.Count; }
        }

        #endregion
    }
}