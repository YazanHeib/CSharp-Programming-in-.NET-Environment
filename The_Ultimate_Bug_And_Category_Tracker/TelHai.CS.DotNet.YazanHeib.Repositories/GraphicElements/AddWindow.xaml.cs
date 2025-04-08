using System.Windows;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories.GraphicElements
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private CategorySqlRepository _categoryRepo;

        public AddWindow()
        {
            InitializeComponent();
            _categoryRepo = CategorySqlRepository.GetSqlRepositoryInstance;
        }


        /// <summary>
        /// Add A new Category To The Category Data Base.
        /// </summary>
        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            // Geting The Category Name From The Text Box.
            string categoryName = NameTextBox.Text.Trim();

            // set a int val to init the Id Of the category.
            int id;


            // add the category to The Data Base.
            if (int.TryParse(IdTextbox.Text.Trim(), out id))
            {
                // Check If The User Has Add A Data For Text Block.
                if (string.IsNullOrWhiteSpace(categoryName) || id == null)
                {
                    MessageBox.Show("Error : Plaese Enter A Valid Values, And Try Again.");
                }
                else
                {
                    Category category = new Category
                    {
                        Id = id,
                        CategoryName = categoryName,
                        ParentCategoryId = null
                    };

                    // try to Add the Category To The Data base.
                    try
                    {
                        _categoryRepo.Add(category);

                        // close The Window and return to management Category Window.
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

                // OtherWise, That the id is not number.
                MessageBox.Show("Error : Invalid ID! Please enter a valid number, please Enter ID and Try Again.");
            }
        }
    }
}

