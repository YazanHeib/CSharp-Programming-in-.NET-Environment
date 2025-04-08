using System;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories.RepositoryFactories
{
    /// <summary>
    /// Create A Factory For Creating Repositories Will Use The Json File To Data.
    /// </summary>
    public class JsonRepoFactory : IRepoFactory
    {
        private string _jsonFilePath;


        /// <summary>
        /// C'tor 
        /// </summary>
        /// <param name="jsonFilePath">The File Name</param>
        public JsonRepoFactory(string jsonFilePath)
        {
            this._jsonFilePath = jsonFilePath;
        }


        /// <summary>
        /// Creating a category repository is not supported in JSON storage.
        /// </summary>
        public CategorySqlRepository CreateCategoryRepository()
        {
            throw new NotImplementedException("Error : Not Implemented.");
        }


        /// <summary>
        /// Create And Returns A New Bug Repository Using JSON.
        /// </summary>
        /// <returns>Bug Repository</returns>
        public IBugRepository Repository()
        {
            return new JsonBugRepository(_jsonFilePath);
        }
    }
}
