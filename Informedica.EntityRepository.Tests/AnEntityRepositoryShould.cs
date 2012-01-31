using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Informedica.EntityRepository.Tests
{
    [TestClass]
    public class AnEntityRepositoryShould
    {
        private static readonly Testing.AnEntityRepositoryShould Tests = new Testing.AnEntityRepositoryShould();

        [TestMethod]
        public void ThrowAnErrorWhenInitiatedWithAnNullReference()
        {
            Tests.ThrowAnErrorWhenInitiatedWithAnNullReference(NewRepostitory);
        }

        private static void NewRepostitory()
        {
            new Repository<TestEntity, int>(null);
        }

        [TestMethod]
        public void HaveZeroItemsWhenFirstCreated()
        {
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();
            Tests.HaveZeroItemsWhenFirstCreated(repos);
        }

        [TestMethod]
        public void ThrowAnErrorWhenANullReferenceIsAdded()
        {
            try
            {
                Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();
                repos.Add(null);
                Assert.Fail("Repository should throw an error when null is added");
            }
            catch (Exception e)
            {
                Assert.IsNotInstanceOfType(e, typeof (AssertFailedException));
            }
        }

        [TestMethod]
        public void HaveOneItemWhenAnEntityIsAdded()
        {
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.HaveOneItemWhenAnEntityIsAdded(repos, EntityFixture.CreateIntIdEntity());
        }

        [TestMethod]
        public void ReturnTheEntityThatWasAdded()
        {
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();
            Testing.TestEntity ent = EntityFixture.CreateIntIdEntity();

            Tests.ReturnTheEntityThatWasAdded(repos, ent);
        }

        [TestMethod]
        public void HaveTwoItemsWhenTwoEntitiesAreAdded()
        {
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();
            Testing.TestEntity entity1 = EntityFixture.CreateEntityWithId(1);
            Testing.TestEntity entity2 = EntityFixture.CreateEntityWithId(2);

            entity1.Name = "Entity1";
            entity2.Name = "Entity2";

            Tests.HaveTwoItemsWhenTwoEntitiesAreAdded(repos, entity1, entity2);
        }

        [TestMethod]
        public void NotAcceptTheSameEntityTwice()
        {
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();
            Testing.TestEntity ent = EntityFixture.CreateIntIdEntity();

            Tests.NotAcceptTheSameEntityTwice(repos, ent);
        }

        [TestMethod]
        public void NotAcceptADifferentEntityWithTheSameId()
        {
            Testing.TestEntity entity1 = EntityFixture.CreateEntityWithId(1);
            Testing.TestEntity entity2 = EntityFixture.CreateEntityWithId(1);
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.NotAcceptAnEntityWithTheSameIdentityTwice(repos, entity1, entity2);
        }

        [TestMethod]
        public void ReturnAnEntityById()
        {
            Testing.TestEntity entity1 = EntityFixture.CreateEntityWithId(1);
            Testing.TestEntity entity2 = EntityFixture.CreateEntityWithId(2);
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();

            entity1.Name = "TestIdentity1";
            entity2.Name = "TestIdentity2";

            Tests.ReturnAnEntityById(repos, entity1, entity2);
        }

        [TestMethod]
        public void NotAcceptAnEntityWithTheSameIdentityTwice()
        {
            Testing.TestEntity entity1 = EntityFixture.CreateEntityWithId(1);
            Testing.TestEntity entity2 = EntityFixture.CreateEntityWithId(2);
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();

            entity1.Name = "Entity1";
            entity2.Name = "Entity1";

            Tests.NotAcceptAnEntityWithTheSameIdentityTwice(repos, entity1, entity2);
        }

        [TestMethod]
        public void RemoveTestEntity()
        {
            Testing.TestEntity entity1 = EntityFixture.CreateEntityWithId(1);
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.RemoveTestEntity(repos, entity1);
        }

        [TestMethod]
        public void RemoveTestEntityById()
        {
            const int id = 1;
            Testing.TestEntity entity1 = EntityFixture.CreateEntityWithId(id);
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.RemoveTestEntityById(repos, entity1);
        }

        [TestMethod]
        public void ThrowAnErrorWhenTryingToRemoveNullReference()
        {
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.ThrowAnErrorWhenTryingToRemoveNullReference(repos);
        }

        [TestMethod]
        public void ThrowAnErrorWhenTryingToRemoveNonAddedEntity()
        {
            Testing.TestEntity ent = EntityFixture.CreateIntIdEntity();
            Repository<Testing.TestEntity, int> repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.ThrowAnErrorWhenTryingToRemoveNonAddedEntity(repos, ent);
        }
    }
}