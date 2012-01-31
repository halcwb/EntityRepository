namespace Informedica.EntityRepository.Tests
{
    static internal class RepositoryFixture
    {
        public static Repository<Testing.TestEntity, int> CreateIntEntityRepository()
        {
            var fakeRepos = CreateFakeRepository();
            return new Repository<Testing.TestEntity, int>(fakeRepos);
        }

        private static IRepository<Testing.TestEntity, int> CreateFakeRepository()
        {
            return new FakeRepository();
        }
    }
}