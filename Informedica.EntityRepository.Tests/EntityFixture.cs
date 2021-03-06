namespace Informedica.EntityRepository.Tests
{
    internal static class EntityFixture
    {
        public static Testing.TestEntity CreateIntIdEntity()
        {
            return CreateEntityWithId(1);
        }

        public static Testing.TestEntity CreateEntityWithId(int id)
        {
            var ent = new TestEntity(id) {Name = "TestEntity"};
            return ent;
        }
    }
}