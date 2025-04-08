using System;


namespace TelHai.CS.DotNet.YazanHeib.Repositories.Models
{

    /*
     * Category Model.
     */
    public class Category
    {

        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<Category> SubCategoriesList { get; set; } = new List<Category>();


        /// <summary>
        /// To String Method.
        /// </summary>
        /// <returns>String That Describe The Category.</returns>
        public override string ToString()
        {
            return $"Id : {Id}, Category Name : {CategoryName}, Parent Category Id : {ParentCategoryId}.";
        }
    }
}
