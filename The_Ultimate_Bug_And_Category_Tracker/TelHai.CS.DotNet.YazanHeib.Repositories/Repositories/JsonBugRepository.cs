using Newtonsoft.Json;
using System.IO;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;
using Formatting = Newtonsoft.Json.Formatting;

namespace TelHai.CS.DotNet.YazanHeib.Repositories.Repositories
{

    /// <summary>
    /// - Implemetation of IBugRepository.
    /// - Crud Operation From File.
    /// </summary>
    public class JsonBugRepository : IBugRepository
    {

        private readonly string defaultFilePath = "bugs.json";
        private string filePath;
        private List<Bug> bugs;


        public string FilePath { get => filePath; }
        public string JSONString { get; set; }
        public int ItemCounts { get; set; }
        public int FileSize { get; set; }



        /// <summary>
        /// C'tor : parmter ctor that initializes the repository with a specific file path.
        /// </summary>
        /// <param name="filePath">path of JSON file where bugs wil be stored.</param>
        public JsonBugRepository(string filePath)
        {
            this.filePath = filePath;
            bugs = new List<Bug>();
        }


        /// <summary>
        /// Default constructor that initializes the repository with the default file path.
        /// </summary>
        public JsonBugRepository()
        {
            filePath = defaultFilePath;
            bugs = new List<Bug>();
        }


        /// <summary>
        /// add a parmter bug to the list.
        /// </summary>
        /// <param name="bug">bug will add to the list of the bugs</param>
        public void Add(Bug bug)
        {
            // Read list From File.
            var bugs = GetAll();

            // Add Item With Max Index ID.
            bug.BugID = bugs.Any() ? bugs.Max(b => b.BugID) + 1 : 1;

            // Add To list.
            bugs.Add(bug);
            SaveToFile(bugs);
        }


        /// <summary>
        /// delete a Bug from the list.
        /// </summary>
        /// <param name="bugId">ID of the bug will delete</param>
        public void Delete(int bugId)
        {
            if (bugs.RemoveAll(b => b.BugID == bugId) > 0)
                SaveToFile(bugs);
        }


        /// <summary>
        /// update a Bug in the Bug list.
        /// </summary>
        /// <param name="bug"></param>
        public void Update(int id, Bug bug)
        {
            var existingBug = bugs.FirstOrDefault(b => b.BugID == bug.BugID);

            // Update Each Property of Bug Object Parmter.
            if (existingBug != null)
            {
                existingBug.Title = bug.Title;
                existingBug.Description = bug.Description;
                existingBug.Status = bug.Status;
                SaveToFile(bugs);
            }
        }


        /// <summary>
        /// save current List to List.
        /// </summary>
        private void SaveToFile(List<Bug> bugs)
        {
            string json = JsonConvert.SerializeObject(bugs, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }



        /// <summary>
        ///  get all the bugs at the list.
        /// </summary>
        /// <returns>List<Bug> : list of all the bugs.</Bug></returns>
        public List<Bug> GetAll()
        {
            if (!File.Exists(filePath))
                return new List<Bug>();

            string json = File.ReadAllText(filePath);
            List<Bug> filesJsonAsListObjects = JsonConvert.DeserializeObject<List<Bug>>(json) ?? new List<Bug>();

            return filesJsonAsListObjects;
        }

        /// <summary>
        /// find a Bug at the list by given ID.
        /// </summary>
        /// <param name="id">id of the bug that will get</param>
        /// <returns></returns>
        public Bug? Get(int id)
        {
            var bugs = GetAll();
            return bugs.Find(b => b.BugID == id);
        }
    }
}
