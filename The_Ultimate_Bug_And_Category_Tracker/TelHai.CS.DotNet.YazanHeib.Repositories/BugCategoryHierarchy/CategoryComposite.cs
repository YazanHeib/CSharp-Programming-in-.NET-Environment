using TelHai.CS.DotNet.YazanHeib.Repositories.Models;


namespace TelHai.CS.DotNet.YazanHeib.Repositories.BugCategoryHierarchy
{
    public class CategoryComposite
    {
        public Category Category { get; set; }

        // List Of The Bug's
        public List<Bug> bugsList = new List<Bug>();

        // List Of 'CategoryComposite' That Will Contain Category and his sub-Category.
        public List<CategoryComposite> categoryComposites = new List<CategoryComposite>();
    }
}
