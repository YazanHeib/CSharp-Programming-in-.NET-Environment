using System.IO;
using System.Windows;


namespace TelHai.CS.DotNet.YazanHeib.Repositories.BugCategoryHierarchy
{
    /// <summary>
    /// - At This Class Will Save All The Data To File.
    /// - That Will Describe The Data in Tree structure.
    /// </summary>
    public class SaveDataToFile
    {
        private readonly string _fileName;
        private readonly CategoryBugMapper categoryBugMapper;


        // C'tor
        public SaveDataToFile(string fileName)
        {
            this._fileName = fileName;
            categoryBugMapper = new CategoryBugMapper();
        }


        /// <summary>
        /// Saves The Categories That in The Data Base as a Tree Structure Format And Writes It To A File.
        /// </summary>
        public void saveDataInTreeStructure()
        {
            // Get All The Categories.
            List<CategoryComposite> categoeys = categoryBugMapper.GetCategoryComposites();


            using (StreamWriter ToFileWriter = new StreamWriter(this._fileName))
            {

                //Check If We Have Data To Save.
                if (categoeys.Count == 0)
                {
                    MessageBox.Show("Error : There No Data To Save, Plaese Enter A Data And Try Again.");
                }
                // Write Each Category In A Structured Format.
                foreach (var category in categoeys)
                {
                    WriteCategory(category, ToFileWriter, 0);
                }
            }

            // Geting The Full Path Of The File.
            string fileFullPath = Path.GetFullPath(this._fileName);

            // Show The Success Message, And The Path Of The File.
            MessageBox.Show($"Data Saved Successfully In The {fileFullPath} File.");
        }


        /// <summary>
        /// Writes The categories And Its Subcategories/Bugs To A File In A Structured Format.
        /// </summary>
        private void WriteCategory(CategoryComposite category, StreamWriter writer, int stepInto)
        {
            string whiteSpaceInside = new string(' ', stepInto * 4);

            // First, Will Write The Category Name And It's Id.
            writer.WriteLine($"{whiteSpaceInside} - {category.Category.CategoryName} (Category ID: {category.Category.Id})");

            // And Here Will Write All The Bug's
            foreach (var bug in category.bugsList)
            {
                writer.WriteLine($"{whiteSpaceInside}          * Bug: {bug.Title} ( Bug ID: {bug.BugID})");
            }

            // Write All The Sub-Categories.
            foreach (var subCategory in category.categoryComposites)
            {
                WriteCategory(subCategory, writer, stepInto + 2);
            }
        }
    }
}
