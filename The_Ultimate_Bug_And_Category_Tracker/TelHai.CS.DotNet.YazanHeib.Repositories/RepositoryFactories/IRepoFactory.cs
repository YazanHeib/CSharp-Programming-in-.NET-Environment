using System;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories.RepositoryFactories
{
    /// <summary>
    /// Interface That Define A Factory Of Create A Different Types Of Repositories.
    /// </summary>
    public interface IRepoFactory
    {
        /// <summary>
        /// At This Methos Will Create A Bug And return It.
        /// </summary>
        /// <returns>Bug Repository</returns>
        public IBugRepository Repository();


        /// <summary>
        /// At This Methos Will Create A Category Repository And return It.
        /// </summary>
        /// <returns>Category Repository</returns>
        public CategorySqlRepository CreateCategoryRepository();
    }
}
