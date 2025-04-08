using System.Windows;
using System.Windows.Controls;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories
{
    /// <summary>
    /// Interaction logic for ChooseCateWindow.xaml
    /// </summary>
    public partial class ChooseCateWindow : Window
    {
        public int SelectCategoryId { get; private set; }
        private CategorySqlRepository _categorySqlRepo;

        /// <summary>
        /// C'tor.
        /// </summary>
        public ChooseCateWindow()
        {
            InitializeComponent();
            _categorySqlRepo = CategorySqlRepository.GetSqlRepositoryInstance;
            LoadCategoriesData();
            this.SelectCategoryId = -1;
        }


        /// <summary>
        /// At This Method Will Load All The Data From The Data-Base Into The Tree Veiw.
        /// </summary>
        private void LoadCategoriesData()
        {
            List<Category> categories = _categorySqlRepo.GetAll();

            // Search For Categories That Don't Have A Parent ID.
            var rootCategories = categories.Where(c => c.ParentCategoryId == null).ToList();


            // Create A Node, And Add It To The Tree Veiw.
            foreach (var category in rootCategories)
            {
                TreeViewItem treeVeiw = CreateCategoryNode(category, categories);
                CategoryTreeView.Items.Add(treeVeiw);
            }
        }



        /// <summary>
        /// Create A Node For The Categories.
        /// </summary>
        private TreeViewItem CreateCategoryNode(Category category, List<Category> categories)
        {
            TreeViewItem item = new TreeViewItem
            {
                // Show The Category Name And Id In The Tree Veiw.
                Header = $"[{category.Id}] {category.CategoryName}",
                Tag = category.Id
            };

            // Search For Sub-Categories.
            var subCategories = categories.Where(c => c.ParentCategoryId == category.Id).ToList();

            foreach (var sub in subCategories)
            {
                item.Items.Add(CreateCategoryNode(sub, categories));
            }
            return item;
        }


        /// <summary>
        /// At This Method Will Get What The User, Convert To int And Init To His Field. 
        /// </summary>
        private void TreeView_SelectedItemChanged(object sender, EventArgs e)
        {
            if (CategoryTreeView.SelectedItem is TreeViewItem userSelectItem)
            {
                SelectCategoryId = (int)userSelectItem.Tag;
            }
        }


        /// <summary>
        /// Select Button Method, Will Check That The User Had Choose A ID From The Tree And Close The Window.
        /// </summary>
        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check if Number Thar User Choose Is Valid, And Close The Window.
            if (SelectCategoryId != -1)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Plaese Choose A Category, And Try Again.");
            }
        }
    }
}
