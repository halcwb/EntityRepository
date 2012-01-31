namespace Informedica.EntityRepository.Tests
{
    public class TestEntity: Testing.TestEntity
    {

        public TestEntity(int id) : base(id) {}

        public TestEntity()
        {
            
        }

        public new string Name { get; set; }

        #region Overrides of Entity<TestEntity,int>

        public bool IsIdentical(TestEntity entity)
        {
            return Name == entity.Name;
        }

        #endregion
    }
}