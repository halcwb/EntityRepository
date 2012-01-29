using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Informedica.EntityRepository.Tests
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

        public void HaveZeroItemsWhenFirstCreated(IRepository<TestEntity, int> repos)
        {
            Assert.AreEqual(0, repos.Count);
        }

        public void ThrowAnErrorWhenANullReferenceIsAdded(IRepository<TestEntity, int> repos)
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

        public void HaveOneItemWhenAnEntityIsAdded(IRepository<TestEntity, int> repos, TestEntity entity)
        {
            repos.Add(entity);

            Assert.AreEqual(1, repos.Count);
        }

        public void ReturnTheEntityThatWasAdded(IRepository<TestEntity, int> repos, TestEntity entity )
        {
            repos.Add(entity);

            Assert.AreEqual(entity, repos.First());
        }

        public void HaveTwoItemsWhenTwoEntitiesAreAdded(IRepository<TestEntity, int> repos, TestEntity entity1, TestEntity entity2)
        {
            entity1.Name = "Entity1";
            entity2.Name = "Entity2";
            repos.Add(entity1);
            repos.Add(entity2);

            Assert.AreEqual(2, repos.Count());
        }

        public void NotAcceptTheSameEntityTwice(IRepository<TestEntity, int> repos, TestEntity entity)
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

        public void NotAcceptADifferentEntityWithTheSameId(IRepository<TestEntity, int> repos, TestEntity entity1, TestEntity entity2)
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

        public void ReturnAnEntityById(IRepository<TestEntity, int> repos, TestEntity entity1, TestEntity entity2)
        {
            entity1.Name = "TestIdentity1";
            entity2.Name = "TestIdentity2";

            repos.Add(entity1);
            repos.Add(entity2);
            Assert.AreEqual(entity1, repos.Single(e => e.Id.Equals(entity1.Id)));
            Assert.AreEqual(entity2, repos.Single(e => e.Id.Equals(entity2.Id)));
        }

        public void NotAcceptAnEntityWithTheSameIdentityTwice(IRepository<TestEntity, int> repos, TestEntity entity1, TestEntity entity2)
        {
            entity1.Name = "Entity1";
            entity2.Name = "Entity1";

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

        public void RemoveTestEntity(IRepository<TestEntity, int> repos, TestEntity entity1)
        {
            entity1.Name = "Entity1";

            repos.Add(entity1);
            Assert.AreEqual(1, repos.Count());

            repos.Remove(entity1);
            Assert.AreEqual(0, repos.Count());
        }

        public void RemoveTestEntityById(IRepository<TestEntity, int> repos, TestEntity entity1)
        {
            const int id = 1;
            entity1.Name = "TestEntity1";

            repos.Add(entity1);
            repos.Remove(id);
            Assert.AreEqual(0, repos.Count());
        }

        public void ThrowAnErrorWhenTryingToRemoveNullReference(IRepository<TestEntity, int> repos)
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

        public void ThrowAnErrorWhenTryingToRemoveNonAddedEntity(IRepository<TestEntity, int> repos, TestEntity entity)
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
