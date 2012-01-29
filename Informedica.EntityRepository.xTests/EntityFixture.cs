namespace Informedica.EntityRepository.xTests
{
    static internal class EntityFixture
    {
        public static Tests.TestEntity CreateIntIdEntity()
        {
            return CreateEntityWithId(1);
        }

        public static Tests.TestEntity CreateEntityWithId(int id)
        {
            var ent = new TestEntity(id) {Name = "TestEntity"};
            return ent;
        }

    }
}