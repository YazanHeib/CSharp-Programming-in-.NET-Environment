using System;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories.RepositoryFactories
{
    /// <summary>
    /// Factory For Repositories That Will Use A SQL Data-Base.
    /// </summary>
    class SqlRepoFactory : IRepoFactory
    {
        private string _connectionString;


        /// <summary>
        /// C'tor.
        /// </summary>
        public SqlRepoFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }


        /// <summary>
        /// Returns A Bug Repository Using SQL.
        /// </summary>
        public IBugRepository Repository()
        {
            return new SqlRepository(_connectionString);
        }


        /// <summary>
        /// Returns A Category Repository Using SQL.
        /// </summary>
        public CategorySqlRepository CreateCategoryRepository()
        {
            return CategorySqlRepository.GetSqlRepositoryInstance;
        }
    }
}
