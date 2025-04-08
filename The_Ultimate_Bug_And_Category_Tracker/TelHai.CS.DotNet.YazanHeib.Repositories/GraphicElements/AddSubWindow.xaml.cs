using System.Windows;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories.GraphicElements
{
    /// <summary>
    /// Interaction logic for AddSubWindow.xaml
    /// </summary>
    public partial class AddSubWindow : Window
    {

        private CategorySqlRepository _categoryRepo;

        public AddSubWindow()
        {
            InitializeComponent();
            _categoryRepo = CategorySqlRepository.GetSqlRepositoryInstance;
            LoadParentID();
        }


        /// <summary>
        /// At This Method will Load all The Catgory id To Choose at it The Sub Category. 
        /// </summary>
        private void LoadParentID()
        {
            List<Category> categories = _categoryRepo.GetAll();
            List<int> categoriesId = getAllCateGoryId(categories);

            // If We Don't Have Any Category, We Can't Add A Sub-Category.
            // And In The Combo Box Will Show This "-".

            if (categoriesId.Count == 0)
            {
                parentIdComboBox.ItemsSource = "-";
            }
            else
            {
                parentIdComboBox.ItemsSource = categoriesId;
            }
        }


        /// <summary>
        /// Add A Category To The Data Base Button,
        /// </summary>
        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            // Getting The Category Name, The Parent Category ID, And Also Initializing An Integer Sub ID.
            string subCategoryName = NameTextBox.Text.Trim();
            int parentId = (int)parentIdComboBox.SelectedItem;
            int id;

            if (int.TryParse(IdTextbox.Text.Trim(), out id))
            {
                // Check If The User Has Add A Data For Text Block.
                if (string.IsNullOrWhiteSpace(subCategoryName) || id == null)
                {
                    MessageBox.Show("Error : Please Enter A Valid Values, And Try Again.");
                }
                else
                {
                    Category _categoryToAdd = new Category
                    {
                        Id = id,
                        CategoryName = subCategoryName,
                        ParentCategoryId = parentId
                    };

                    // Try To Add The Subcategory To The Database.
                    try
                    {
                        _categoryRepo.Add(_categoryToAdd);

                        // Close The Window.
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                // OtherWise, That The Id Is Not Number.
                MessageBox.Show("Error : Invalid ID! Please enter a valid number, please Enter ID and Try Again.");
            }
        }


        /// <summary>
        /// This Method Will Get A List Of Categories And Return A List Of IDs To Initialize It In The Combo Box.
        /// </summary>
        private List<int> getAllCateGoryId(List<Category> list)
        {
            List<int> idResult = new List<int>();


            foreach (var category in list)
            {
                idResult.Add(category.Id);
            }
            return idResult;
        }
    }
}
