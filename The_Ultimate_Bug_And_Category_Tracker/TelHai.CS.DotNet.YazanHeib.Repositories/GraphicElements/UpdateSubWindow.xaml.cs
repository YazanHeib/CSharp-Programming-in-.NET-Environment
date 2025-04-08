using System.Windows;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;

namespace TelHai.CS.DotNet.YazanHeib.Repositories.GraphicElements
{
    /// <summary>
    /// Interaction logic for UpdateSubWindow.xaml
    /// </summary>
    public partial class UpdateSubWindow : Window
    {

        private Category _categoryToUpdate { get; set; }

        private CategorySqlRepository _categoryUpdateRepo;
        private int _categoryId;
        public UpdateSubWindow(int id)
        {
            InitializeComponent();
            this._categoryId = id;
            _categoryUpdateRepo = CategorySqlRepository.GetSqlRepositoryInstance;
            LoadComboBox();
        }



        /// <summary>
        /// At This Function we will load All The Parent Category ID To The Combo Box.
        /// </summary>
        private void LoadComboBox()
        {
            List<Category> categories = _categoryUpdateRepo.GetAll();
            List<int> idCategories = getAllCateGoryId(categories);

            if (categories.Count == 0)
            {
                UpdateparentIdComboBox.ItemsSource = "-";
            }
            else
            {
                UpdateparentIdComboBox.ItemsSource = idCategories;
            }
        }


        /// <summary>
        /// At This Function Will Update An category To The Data Base.
        /// </summary>
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            // getting the name of Sub-Category, and Get The Combo Box selected Parent Id.
            string updatedName = UpdateNameTextBox.Text.Trim();
            string selectedItemComboBox = UpdateparentIdComboBox.SelectedIndex.ToString();


            // convert the selected parent id to int, and init a int for the id.
            int updatedParentId = (int)UpdateparentIdComboBox.SelectedItem;
            int id;


            if (int.TryParse(UpdateIdTextbox.Text.Trim(), out id))
            {

                // Check If The User Has Add A Data For Text Block.
                if (string.IsNullOrWhiteSpace(updatedName) || id == null)
                {
                    MessageBox.Show("Error : Plaese Enter A Valid Values, And Try Again.");
                }
                else
                {
                    _categoryToUpdate = new Category
                    {
                        Id = id,
                        CategoryName = updatedName,
                        ParentCategoryId = updatedParentId
                    };

                    // try to update the Category to the data base.
                    try
                    {

                        _categoryUpdateRepo.Update(_categoryId, _categoryToUpdate);

                        // close the Window.
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
                MessageBox.Show("Error : Failed To Add The Category");
            }

        }


        /// <summary>
        /// This method will get a list of categories and return a list of id to init it at the combo box.
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
