using System;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories.RepositoryFactories
{
    class MockRepoFactory : IRepoFactory
    {
        /// <summary>
        /// C'tor
        /// </summary>
        public MockRepoFactory() { }


        /// <summary>
        /// Returns A Bug Repository Using Mock Storage.
        /// </summary>
        public IBugRepository Repository()
        {
            return new MockRepository();
        }


        /// <summary>
        /// Creating a category repository is not supported in Mock.
        /// </summary>
        public CategorySqlRepository CreateCategoryRepository()
        {
            throw new NotImplementedException("Error : Not Implemented.");
        }
    }
}
