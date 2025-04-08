using System.Windows;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;


namespace TelHai.CS.DotNet.YazanHeib.Repositories.GraphicElements
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private Category _categoryToUpdate { get; set; }

        private CategorySqlRepository _categoryUpdateRepo;
        private int _categoryId;

        public UpdateWindow(int id)
        {
            InitializeComponent();
            this._categoryId = id;
            _categoryUpdateRepo = CategorySqlRepository.GetSqlRepositoryInstance;
        }



        /// <summary>
        /// At This Function Will Update An category To The Data Base.
        /// </summary>
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            // getting the name of The Category.
            string updatedName = updateNameTextBox.Text.Trim();


            // init A int For The Id.
            int id;


            if (int.TryParse(updateIdTextbox.Text.Trim(), out id))
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
                        ParentCategoryId = null
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
    }
}
