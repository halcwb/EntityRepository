namespace Informedica.EntityRepository.Tests
{
    internal static class RepositoryFixture
    {
        public static Repository<Testing.TestEntity, int> CreateIntEntityRepository()
        {
            IRepository<Testing.TestEntity, int> fakeRepos = CreateFakeRepository();
            return new Repository<Testing.TestEntity, int>(fakeRepos);
        }

        private static IRepository<Testing.TestEntity, int> CreateFakeRepository()
        {
            return new FakeRepository();
        }
    }
}