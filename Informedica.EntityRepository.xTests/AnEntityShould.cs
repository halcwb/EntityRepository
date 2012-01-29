using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Informedica.EntityRepository.xTests
{
    [TestClass]
    public class AnEntityShould
    {
        private static readonly Tests.AnEntityShould Tests = new Tests.AnEntityShould();

        [TestMethod]
        public void ReturnTrueWhenEntityIsTransient()
        {
            Tests.ReturnTrueWhenEntityIsTransient(new TestEntity());
        }

        [TestMethod]
        public void BeIdenticalAsAnotherEntityWithTheSameIdentity()
        {
            var ent1 = EntityFixture.CreateEntityWithId(1);
            ent1.Name = "Entity";
            var ent2 = EntityFixture.CreateEntityWithId(2);
            ent2.Name = "Entity";

            Tests.BeIdenticalAsAnotherEntityWithTheSameIdentity(ent1, ent2);
        }
    }
}