using TelHai.CS.DotNet.YazanHeib.Repositories.Models;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;


namespace TelHai.CS.DotNet.YazanHeib.Repositories.BugCategoryHierarchy
{

    /// <summary>
    ///  - At this Class Will Read All The Bug And Category From The Data Base's. 
    ///  - And Bulid a Hierarchical Structure That Descibe Them.
    ///  - And Also Associate Each Category With Its Related Bugs. 
    /// </summary>
    public class CategoryBugMapper
    {
        private readonly CategorySqlRepository _categorySqlRepo;
        private readonly SqlRepository _sqlRepository;


        public CategoryBugMapper()
        {
            this._categorySqlRepo = CategorySqlRepository.GetSqlRepositoryInstance;
            this._sqlRepository = new SqlRepository();
        }


        /// <summary>
        /// Gets The Category List That Is In The Data-Base With Their ٍٍٍSub-categories And The Bugs.
        /// </summary>
        /// <returns>List Of Categories, That Contain it's Sub-Categories And The Bugs.</returns>
        public List<CategoryComposite> GetCategoryComposites()
        {
            // Init Two List That Will Contain The Bug And The Categories That Will Get Them By GetAll Method.
            List<Category> categories = _categorySqlRepo.GetAll();
            List<Bug> bugs = _sqlRepository.GetAll();


            // Dictionary For CategoryComposite, That Will Describe The Categories And There Bugs.
            Dictionary<int, CategoryComposite> categoryMap = categories.ToDictionary(
            cat => cat.Id, cat => new CategoryComposite { Category = cat });


            // Add The Sub-Categories To Their Parent Categories.
            foreach (var category in categories)
            {
                if (category.ParentCategoryId.HasValue && categoryMap.ContainsKey(category.ParentCategoryId.Value))
                {
                    categoryMap[category.ParentCategoryId.Value].categoryComposites.Add(categoryMap[category.Id]);
                }
            }


            // To Link The Bug's To Their Categories.
            foreach (var bug in bugs)
            {
                if (categoryMap.ContainsKey(bug.CategoryId))
                {
                    categoryMap[bug.CategoryId].bugsList.Add(bug);
                }
            }

            // Return The Categories.
            return categoryMap.Values.Where(c => !c.Category.ParentCategoryId.HasValue).ToList();
        }
    }
}
