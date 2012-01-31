using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Informedica.EntityRepository.Tests
{
    [TestClass]
    public class AnEntityShould
    {
        private static readonly Testing.AnEntityShould Tests = new Testing.AnEntityShould();

        [TestMethod]
        public void ReturnTrueWhenEntityIsTransient()
        {
            Tests.ReturnTrueWhenEntityIsTransient(new TestEntity());
        }

        [TestMethod]
        public void BeIdenticalAsAnotherEntityWithTheSameIdentity()
        {
            Testing.TestEntity ent1 = EntityFixture.CreateEntityWithId(1);
            ent1.Name = "Entity";
            Testing.TestEntity ent2 = EntityFixture.CreateEntityWithId(2);
            ent2.Name = "Entity";

            Tests.BeIdenticalAsAnotherEntityWithTheSameIdentity(ent1, ent2);
        }
    }
}