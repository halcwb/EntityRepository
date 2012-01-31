using System;
using System.Linq;
using Informedica.EntityRepository.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Informedica.EntityRepository.Testing
{
    public class AnEntityRepositoryShould
    {
        public void ThrowAnErrorWhenInitiatedWithAnNullReference(Action newRepostitory)
        {
            try
            {
                newRepostitory.Invoke();
                Assert.Fail("Repository should not be created with empty list");
            }
            catch (Exception e)
            {
                Assert.IsNotInstanceOfType(e, typeof(AssertFailedException));
            }
        }

        public void HaveZeroItemsWhenFirstCreated<TEnt,TId>(IRepository<TEnt, TId> repos) 
            where TEnt : class, IEntity<TEnt, TId>
        {
            Assert.AreEqual(0, repos.Count);
        }

        public void ThrowAnErrorWhenANullReferenceIsAdded<TEnt, TId>(IRepository<TEnt, TId> repos)
            where TEnt : class, IEntity<TEnt, TId>
        {
            try
            {
                repos.Add(null);
                Assert.Fail("Repository should throw an error when null is added");
            }
            catch (Exception e)
            {
                Assert.IsNotInstanceOfType(e, typeof(AssertFailedException));
            }
        }

        public void HaveOneItemWhenAnEntityIsAdded<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity)
            where TEnt : class, IEntity<TEnt, TId>
        {
            repos.Add(entity);

            Assert.AreEqual(1, repos.Count);
        }

        public void ReturnTheEntityThatWasAdded<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity)
            where TEnt : class, IEntity<TEnt, TId>
        {
            repos.Add(entity);

            Assert.AreEqual(entity, repos.First());
        }

        public void HaveTwoItemsWhenTwoEntitiesAreAdded<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity1, TEnt entity2)
            where TEnt : class, IEntity<TEnt, TId>
        {
            repos.Add(entity1);
            repos.Add(entity2);

            Assert.AreEqual(2, repos.Count);
        }

        public void NotAcceptTheSameEntityTwice<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity)
            where TEnt : class, IEntity<TEnt, TId>
        {
            try
            {

                repos.Add(entity);
                repos.Add(entity);
                Assert.Fail("Repository should not acccept the same entity twice");
            }
            catch (Exception e)
            {
                Assert.IsNotInstanceOfType(e, typeof(AssertFailedException));
            }
        }

        public void NotAcceptADifferentEntityWithTheSameId<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity1, TEnt entity2)
            where TEnt : class, IEntity<TEnt, TId>
        {
            repos.Add(entity1);

            try
            {
                repos.Add(entity2);
                Assert.Fail("A different entity with the same id cannot be added");
            }
            catch (Exception e)
            {
                Assert.IsNotInstanceOfType(e, typeof(AssertFailedException));
            }
        }

        public void ReturnAnEntityById<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity1, TEnt entity2)
            where TEnt : class, IEntity<TEnt, TId>
        {
            repos.Add(entity1);
            var id1 = entity1.Id;
            repos.Add(entity2);
            var id2 = entity2.Id;

            Assert.AreEqual(entity1, repos.GetById(id1));
            Assert.AreEqual(entity2, repos.GetById(id2));
        }

        public void NotAcceptAnEntityWithTheSameIdentityTwice<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity1, TEnt entity2)
            where TEnt : class, IEntity<TEnt, TId>
        {
            repos.Add(entity1);
            try
            {
                repos.Add(entity2);
                Assert.Fail("An entity with the same identity should not be accepted twice");
            }
            catch (Exception e)
            {
                Assert.IsNotInstanceOfType(e, typeof(AssertFailedException));
            }
        }

        public void RemoveTestEntity<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity)
            where TEnt : class, IEntity<TEnt, TId>
        {
            repos.Add(entity);
            Assert.AreEqual(1, repos.Count());

            repos.Remove(entity);
            Assert.AreEqual(0, repos.Count());
        }

        public void RemoveTestEntityById<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity)
            where TEnt : class, IEntity<TEnt, TId>
        {
            repos.Add(entity);
            var id = entity.Id;
            repos.Remove(id);
            Assert.AreEqual(0, repos.Count());
        }

        public void ThrowAnErrorWhenTryingToRemoveNullReference<TEnt, TId>(IRepository<TEnt, TId> repos)
            where TEnt : class, IEntity<TEnt, TId>
        {

            try
            {
                repos.Remove(null);
                Assert.Fail("Repository can not remover null reference");
            }
            catch (Exception e)
            {
                Assert.IsNotInstanceOfType(e, typeof(AssertFailedException));
            }            
        }

        public void ThrowAnErrorWhenTryingToRemoveNonAddedEntity<TEnt, TId>(IRepository<TEnt, TId> repos, TEnt entity)
            where TEnt : class, IEntity<TEnt, TId>
        {
            try
            {
                repos.Remove(entity);
                Assert.Fail("Repository can not remove an entity it does not contain");
            }
            catch (Exception e)
            {
                Assert.IsNotInstanceOfType(e, typeof(AssertFailedException));
            }
        }

    }
}
