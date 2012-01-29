using Informedica.EntityRepository.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Informedica.EntityRepository.Tests
{
    public class AnEntityShould
    {
        public void BeIdenticalAsAnotherEntityWithTheSameIdentity<TEnt, TId>(IEntity<TEnt, TId> ent1, IEntity<TEnt, TId> ent2) 
            where TEnt: IEntity<TEnt, TId>
        {
            Assert.IsTrue(ent1.IsIdentical((TEnt) ent2), "Entities should be able to test for identity");
        }


        public void ReturnTrueWhenEntityIsTransient<TEnt, TId>(IEntity<TEnt, TId> testEntity)
            where TEnt: IEntity<TEnt, TId>
        {
            Assert.IsTrue(testEntity.IsTransient(), "An entity with id not set should be transient");
        }
    }
}