using System.Windows;
using TelHai.CS.DotNet.YazanHeib.Repositories.GraphicElements;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {

        private CategorySqlRepository _categoryBugRepo { get; set; }
        public CategoryWindow()
        {
            InitializeComponent();
            _categoryBugRepo = CategorySqlRepository.GetSqlRepositoryInstance;
            LoadCategory();
        }


        /// <summary>
        /// Load All The Categories And The Sub-Categories To The Data Grid, And Create A New Column To
        /// Set The Type of Category.
        /// </summary>
        private void LoadCategory()
        {
            List<Category> categories = _categoryBugRepo.GetAll();

            // create a new list for the data grid.
            // if we have a Category the 'parent Id' will contain 'None'
            var toDataGridList = categories.Select(category => new
            {
                id = category.Id,
                categoryName = category.CategoryName,
                parentCategoryId = category.ParentCategoryId.HasValue ? category.ParentCategoryId.ToString() : "NONE",
                categoryType = category.ParentCategoryId.HasValue ? "Sub-Category" : "Category"
            }).ToList();


            // set the list to the data grid.
            CategoryDataGrid.ItemsSource = toDataGridList;
        }


        /// <summary>
        /// Add a new Category to the Data Base.
        /// </summary>
        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addSubWindow = new AddWindow();
            addSubWindow.ShowDialog();

            //load the result.
            LoadCategory();
        }


        /// <summary>
        /// Delete Category From The Date Base Button.
        /// </summary>
        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            // if we had choose a category or sub - category to delete.
            try
            {
                if (CategoryDataGrid.SelectedItem != null)
                {
                    // Get The Selected Category By The User.
                    int selectedCategorybyUser = (int)CategoryDataGrid.SelectedItem.GetType().GetProperty("id").GetValue(CategoryDataGrid.SelectedItem, null);

                    // Delete the Bugs From Ahe List, And Update The List To Grid.
                    _categoryBugRepo.Delete(selectedCategorybyUser);
                    LoadCategory();
                }
                else
                {
                    MessageBox.Show("Error : Plaese Select A Category From The Table, And Try Again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Update Category From The Date Base Button.
        /// </summary>
        private void UpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            // if The User Has Choose a Category For Update.
            try
            {
                var categoryToUpdate = CategoryDataGrid.SelectedItem;

                if (categoryToUpdate != null)
                {

                    // Chceck if THe User Choose a Category or Sub-Category, and Open The appropriate window.
                    string parentCategoryId = categoryToUpdate.GetType().GetProperty("parentCategoryId").GetValue(categoryToUpdate, null).ToString();
                    string UpdateCategoryType = parentCategoryId == "NONE" ? "Category" : "Sub-Category";


                    // Convert The Category Id To Int To Send It To The Update Function At The Window.\
                    int selectedId = (int)categoryToUpdate.GetType().GetProperty("id").GetValue(categoryToUpdate, null);

                    if (UpdateCategoryType == "Category")
                    {
                        UpdateWindow updateWindow = new UpdateWindow(selectedId);
                        updateWindow.ShowDialog();
                    }
                    else
                    {
                        UpdateSubWindow updateSubWindow = new UpdateSubWindow(selectedId);
                        updateSubWindow.ShowDialog();
                    }

                    //load the result.
                    LoadCategory();
                }
                // if The User Don't Choose Any Category.
                else
                {
                    MessageBox.Show("Error : Please Choose an Category, And Try Again.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Add a Sub Category to The Data Base.
        /// </summary>
        private void AddSubCategory_Click(object sender, RoutedEventArgs e)
        {
            AddSubWindow addSubWindow = new AddSubWindow();
            addSubWindow.ShowDialog();

            //load the result.
            LoadCategory();
        }


        /// <summary>
        /// return To Main Window Button.
        /// </summary>
        private void ReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            // By this line will get the main App of run Program.
            Window MainProgramWindow = Application.Current.MainWindow;

            // check if main program is closed, If Closed Open a New One And Return To.
            // OtherWise Return To MainWindow.
            if (MainProgramWindow != null)
            {
                MainProgramWindow.Show();
                this.Close();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
