using System;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;



namespace TelHai.CS.DotNet.YazanHeib.Repositories.Repositories
{

    /// <summary>
    /// - implementation of IBugRepository.
    /// - Mock (Test/Fake/) Repository to store Bug Data.
    /// </summary>
    public class MockRepository : IBugRepository
    {

        // Internal list to store Bug Data.
        private List<Bug> _listBugs;

        /// <summary>
        /// -- Init Mock Repository With HardCoded.
        /// </summary>
        public MockRepository()
        {
            _listBugs = new List<Bug>();


        }

        /// <summary>
        /// Add A Bug To The List.
        /// </summary>
        /// <param name="bugToAdd">The Bug To Be Added.</param>
        public void Add(Bug bugToAdd)
        {
            // Generate BugId and assign it to paameterized Bug Object.
            bugToAdd.BugID = _listBugs.Any() ? _listBugs.Max(b => b.BugID) + 1 : 1;

            // add to list.
            _listBugs.Add(bugToAdd);
        }


        /// <summary>
        /// Delete a Bug from the list of the bug's with given ID.
        /// </summary>
        /// <param name="id">The unique identifier of the bug to be removed.</param>
        public void Delete(int id)
        {
            _listBugs.RemoveAll((b) => b.BugID == id);
        }


        /// <summary>
        /// method will return a Bug by given ID from the list.
        /// </summary>
        /// <param name="id">The unique identifier of the bug will get</param>
        /// <returns>Bug : of the given Id</returns>
        public Bug? Get(int id)
        {
            return _listBugs.Where((b) => b.BugID == id).FirstOrDefault();
        }


        /// <summary>
        /// update a Bug in the Bug list.
        /// </summary>
        /// <param name="bug">the bug will update</param>
        public void Update(int id, Bug bug)
        {
            // Found Item.
            var existingBug = _listBugs.FirstOrDefault(b => b.BugID == bug.BugID);

            // update Each property of Bug Object Parmter.
            if (existingBug != null)
            {
                existingBug.Title = bug.Title;
                existingBug.Description = bug.Description;
                existingBug.Status = bug.Status;
            }
        }


        /// <summary>
        /// this method will return a list of all the the Bugs.
        /// </summary>
        /// <returns> List<Bug> </returns>
        public List<Bug> GetAll()
        {
            return _listBugs;
        }

    }
}
