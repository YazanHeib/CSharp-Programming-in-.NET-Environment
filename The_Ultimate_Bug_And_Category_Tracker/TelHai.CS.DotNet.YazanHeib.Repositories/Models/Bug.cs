using System;


namespace TelHai.CS.DotNet.YazanHeib.Repositories.Models
{

    /*
     * Bug Model.
     */
    public class Bug
    {

        public int BugID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int CategoryId { get; set; } // The New Field For The Category Association.


        /// <summary>
        /// ToString Method
        /// </summary>
        /// <returns>String That Describe The Bug.</returns>
        public override string ToString()
        {
            return $"Bug Id: {BugID}, Title: {Title}, Description: {Description}, Status: {Status}, Category Id: {CategoryId}.";
        }

    }
}
