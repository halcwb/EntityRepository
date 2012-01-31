using Informedica.EntityRepository.Entities;

namespace Informedica.EntityRepository.Testing
{
    public abstract class TestEntity : Entity<TestEntity, int>
    {
        protected TestEntity()
        {
        }

        protected TestEntity(int id) : base(id)
        {
        }

        public string Name { get; set; }

        #region Overrides of Entity<TestEntity,int>

        public override bool IsIdentical(TestEntity entity)
        {
            return Name == entity.Name;
        }

        #endregion
    }
}