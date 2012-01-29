namespace Informedica.EntityRepository.xTests
{
    static internal class RepositoryFixture
    {
        public static Repository<Tests.TestEntity, int> CreateIntEntityRepository()
        {
            var fakeRepos = CreateFakeRepository();
            return new Repository<Tests.TestEntity, int>(fakeRepos);
        }

        private static IRepository<Tests.TestEntity, int> CreateFakeRepository()
        {
            return new FakeRepository();
        }
    }
}