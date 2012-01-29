using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Informedica.EntityRepository.xTests
{
    [TestClass]
    public class AnEntityRepositoryShould
    {
        private static readonly Tests.AnEntityRepositoryShould Tests = new Tests.AnEntityRepositoryShould();

        [TestMethod]
        public void ThrowAnErrorWhenInitiatedWithAnNullReference()
        {
            Tests.ThrowAnErrorWhenInitiatedWithAnNullReference(NewRepostitory);
        }

        private static void NewRepostitory()
        {
            new Repository<Tests.TestEntity, int>(null);
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
            var ent1 = EntityFixture.CreateEntityWithId(1);
            var ent2 = EntityFixture.CreateEntityWithId(2);

            Tests.HaveTwoItemsWhenTwoEntitiesAreAdded(repos, ent1, ent2);
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
            var ent1 = EntityFixture.CreateEntityWithId(1);
            var ent2 = EntityFixture.CreateEntityWithId(1);
            var repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.NotAcceptAnEntityWithTheSameIdentityTwice(repos, ent1, ent2);
        }

        [TestMethod]
        public void ReturnAnEntityById()
        {
            var ent1 = EntityFixture.CreateEntityWithId(1);
            var ent2 = EntityFixture.CreateEntityWithId(2);
            var repos = RepositoryFixture.CreateIntEntityRepository();
            
            Tests.ReturnAnEntityById(repos, ent1, ent2);
        }

        [TestMethod]
        public void NotAcceptAnEntityWithTheSameIdentityTwice()
        {
            var ent1 = EntityFixture.CreateEntityWithId(1);
            var ent2 = EntityFixture.CreateEntityWithId(2);
            var repos = RepositoryFixture.CreateIntEntityRepository();

            Tests.NotAcceptAnEntityWithTheSameIdentityTwice(repos, ent1, ent2);
        }

        [TestMethod]
        public void RemoveTestEntity()
        {
            var ent1 = EntityFixture.CreateEntityWithId(1);
            var repos = RepositoryFixture.CreateIntEntityRepository();
            
            Tests.RemoveTestEntity(repos, ent1);
        }

        [TestMethod]
        public void RemoveTestEntityById()
        {
            const int id = 1;
            var ent1 = EntityFixture.CreateEntityWithId(id);
            var repos = RepositoryFixture.CreateIntEntityRepository();
            
            Tests.RemoveTestEntityById(repos, ent1);
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
