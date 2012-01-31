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
            var repos = RepositoryFixture.CreateIntEntityRepository();
            Tests.HaveZeroItemsWhenFirstCreated(repos);
        }

        [TestMethod]
        public void ThrowAnErrorWhenANullReferenceIsAdded()
        {
            try
            {
                var repos = RepositoryFixture.CreateIntEntityRepository();
                repos.Add(null);
                Assert.Fail("Repository should throw an error when null is added");
            }
            catch (Exception e)
            {
                Assert.IsNotInstanceOfType(e, typeof(AssertFailedException));
            }
        }

        [TestMethod]
        public void HaveOneItemWhenAnEntityIsAdded()
        {
            var repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.HaveOneItemWhenAnEntityIsAdded(repos, EntityFixture.CreateIntIdEntity());
        }

        [TestMethod]
        public void ReturnTheEntityThatWasAdded()
        {
            var repos = RepositoryFixture.CreateIntEntityRepository();
            var ent = EntityFixture.CreateIntIdEntity();

            Tests.ReturnTheEntityThatWasAdded(repos, ent);
        }

        [TestMethod]
        public void HaveTwoItemsWhenTwoEntitiesAreAdded()
        {
            var repos = RepositoryFixture.CreateIntEntityRepository();
            var entity1 = EntityFixture.CreateEntityWithId(1);
            var entity2 = EntityFixture.CreateEntityWithId(2);

            entity1.Name = "Entity1";
            entity2.Name = "Entity2";

            Tests.HaveTwoItemsWhenTwoEntitiesAreAdded(repos, entity1, entity2);
        }

        [TestMethod]
        public void NotAcceptTheSameEntityTwice()
        {
            var repos = RepositoryFixture.CreateIntEntityRepository();
            var ent = EntityFixture.CreateIntIdEntity();

            Tests.NotAcceptTheSameEntityTwice(repos, ent);
        }

        [TestMethod]
        public void NotAcceptADifferentEntityWithTheSameId()
        {
            var entity1 = EntityFixture.CreateEntityWithId(1);
            var entity2 = EntityFixture.CreateEntityWithId(1);
            var repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.NotAcceptAnEntityWithTheSameIdentityTwice(repos, entity1, entity2);
        }

        [TestMethod]
        public void ReturnAnEntityById()
        {
            var entity1 = EntityFixture.CreateEntityWithId(1);
            var entity2 = EntityFixture.CreateEntityWithId(2);
            var repos = RepositoryFixture.CreateIntEntityRepository();

            entity1.Name = "TestIdentity1";
            entity2.Name = "TestIdentity2";
            
            Tests.ReturnAnEntityById(repos, entity1, entity2);
        }

        [TestMethod]
        public void NotAcceptAnEntityWithTheSameIdentityTwice()
        {
            var entity1 = EntityFixture.CreateEntityWithId(1);
            var entity2 = EntityFixture.CreateEntityWithId(2);
            var repos = RepositoryFixture.CreateIntEntityRepository();

            entity1.Name = "Entity1";
            entity2.Name = "Entity1";

            Tests.NotAcceptAnEntityWithTheSameIdentityTwice(repos, entity1, entity2);
        }

        [TestMethod]
        public void RemoveTestEntity()
        {
            var entity1 = EntityFixture.CreateEntityWithId(1);
            var repos = RepositoryFixture.CreateIntEntityRepository();
            
            Tests.RemoveTestEntity(repos, entity1);
        }

        [TestMethod]
        public void RemoveTestEntityById()
        {
            const int id = 1;
            var entity1 = EntityFixture.CreateEntityWithId(id);
            var repos = RepositoryFixture.CreateIntEntityRepository();
            
            Tests.RemoveTestEntityById(repos, entity1);
        }

        [TestMethod]
        public void ThrowAnErrorWhenTryingToRemoveNullReference()
        {
            var repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.ThrowAnErrorWhenTryingToRemoveNullReference(repos);

        }

        [TestMethod]
        public void ThrowAnErrorWhenTryingToRemoveNonAddedEntity()
        {
            var ent = EntityFixture.CreateIntIdEntity();
            var repos = RepositoryFixture.CreateIntEntityRepository();
            
            Tests.ThrowAnErrorWhenTryingToRemoveNonAddedEntity(repos, ent);
        }

    }
}
