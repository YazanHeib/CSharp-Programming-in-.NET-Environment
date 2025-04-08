using System;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;


namespace TelHai.CS.DotNet.YazanHeib.Repositories.Repositories
{
    /*
    / Interface To Represent
    / Repository Of Multiple Bug Items
    */

    public interface IBugRepository
    {
        /*
         * Get All Bugs Data.
         */
        List<Bug> GetAll();

        /*
         * Get Specific Bug Object.
         */
        Bug Get(int id);

        /*
         * Add A New Bug Object.
         */
        void Add(Bug bugToAdd);

        /*
         * Delete Specific Bug By Id.
         */
        void Delete(int id);

        /*
         *  Update A Specific Bug.
         */
        void Update(int id, Bug bug);

    }
}
