using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TelHai.CS.DotNet.YazanHeib.Repositories.Models;
using TelHai.CS.DotNet.YazanHeib.Repositories.Repositories;
using TelHai.CS.DotNet.YazanHeib.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories
{
    /// <summary>
    /// Interaction logic for BugCategory.xaml
    /// </summary>
    public partial class BugWindow : Window
    {
        IBugRepository _bugsRepo;
        private CategorySqlRepository _categorySqlRepo;
        private int _selectedCategoryId;
        public BugWindow()
        {
            InitializeComponent();
            _bugsRepo = Factories.GetBugRepository<SqlRepository>();
            _categorySqlRepo = CategorySqlRepository.GetSqlRepositoryInstance;
            LoadBugs();
            this._selectedCategoryId = -1;
        }


        /// <summary>
        /// Load The Bug's List To The Grid.
        /// </summary>
        private void LoadBugs()
        {
            var listBugs = _bugsRepo.GetAll();
            BugDataGrid.ItemsSource = listBugs;
        }


        /// <summary>
        /// Adding a Bug To The Data Base Button.
        /// </summary>
        private void AddBug_Click(object sender, RoutedEventArgs e)
        {
            // get the Title,Status And The Description from The User.
            string descriptionText = DescriptionTextBox.Text.ToString();
            string status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string titleText = TitleTextBox.Text.ToString();


            // Check if the user Give an Valid Title Description, And Not Null.
            if (string.IsNullOrWhiteSpace(titleText) || string.IsNullOrWhiteSpace(descriptionText) || status == null)
            {
                MessageBox.Show("Please Enter a Valid Parmters To Contenue.");
                return;
            }
            else
            {
                // Create An New Bug With Data User Give.
                Bug bug = new Bug
                {
                    Title = titleText,
                    Description = descriptionText,
                    Status = status,
                    CategoryId = _selectedCategoryId,
                };
                //add it to the data Base
                _bugsRepo.Add(bug);
            }

            // and Show The Result.

            LoadBugs();


            // Set The Text Bug's to The Default.
            TitleTextBox.Text = "";
            DescriptionTextBox.Text = "";
            StatusComboBox.SelectedIndex = -1;
        }


        /// <summary>
        /// Delete A Bug From The Data Base Button.
        /// </summary>
        private void DeleteBug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BugDataGrid.SelectedItem is Bug bugItem)
                {
                    // Delete the Bugs From Ahe List, And Update The List To Grid.
                    _bugsRepo.Delete(bugItem.BugID);
                    LoadBugs();
                }
                else
                {
                    MessageBox.Show("Error : Plaese Choose A Bug To Delete, And Try Again.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Update A Bug At The Data Base Button.
        /// </summary>
        private void UpdateBug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if any Bug had Chooes to Update.
                if (BugDataGrid.SelectedItem is Bug bugItem)
                {
                    // get the New Title,Status And The Description from The User.
                    string descriptionText = DescriptionTextBox.Text.Trim();
                    string status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                    string titleText = TitleTextBox.Text.Trim();


                    // Check if the user Give an Valid Title Description, And Not Null.
                    if (string.IsNullOrWhiteSpace(titleText) || string.IsNullOrWhiteSpace(descriptionText) || status == null)
                    {
                        MessageBox.Show("Please Enter a Valid Parameters To Continue.");
                        return;
                    }


                    // Create An Bug To Update With Data User Give.
                    Bug bug = new Bug
                    {
                        BugID = bugItem.BugID,
                        Title = titleText,
                        Description = descriptionText,
                        Status = status,
                        CategoryId = _selectedCategoryId
                    };

                    // add it to the data Base, and Show The Result By Load The Bugs List.
                    _bugsRepo.Update(bugItem.BugID, bug);
                    LoadBugs();


                    // Set The Text Bug's to The Default.
                    TitleTextBox.Text = "";
                    DescriptionTextBox.Text = "";
                    StatusComboBox.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Please Choose A Bug From The List");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// This runs when the title textbox gets focus.
        /// If the text is the default message, it clears the text and sets color to black.
        /// </summary>
        private void TitleTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Please Enter A Title:")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }


        /// <summary>
        /// This runs when the title textbox loses focus.
        /// If the text is empty, it sets a default message and changes color to gray.
        /// </summary>
        private void TitleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Please Enter A Title:";
                textBox.Foreground = Brushes.Gray;
            }
        }


        /// <summary>
        /// This runs when the description textbox gets focus.
        /// If the text is the default message, it clears the text and sets color to black.
        /// </summary>
        private void DescriptionTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Please Enter A Description:")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }


        /// <summary>
        /// This runs when the description textbox loses focus.
        /// If the text is empty, it sets a default message and changes color to gray.
        /// </summary>
        private void DescriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Please Enter A Description:";
                textBox.Foreground = Brushes.Gray;
            }
        }


        /// <summary>
        /// Close This Window and Return To THe Main Window.
        /// </summary>
        private void ReturnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            // By this linr will get the main App of The Program.
            Window MainProgramWindow = Application.Current.MainWindow;

            // check if main program is closed, If Closed Open a New One And Return To.
            // OtherWise Return To MainWindow.

            if (MainProgramWindow != null)
            {
                MainProgramWindow.Show();
                Close();

            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }

        /// <summary>
        /// return the id of categories as a list.
        /// </summary>
        private List<int> GetAllCategoryId(List<Category> categories)
        {
            List<int> idList = new List<int>();

            foreach (var category in categories)
            {
                idList.Add(category.Id);
            }
            return idList;
        }

        /// <summary>
        /// At This Method Will Get The Category Id From User, By 'ChooseCateWindow' Class.
        /// </summary>
        private void SelectCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            ChooseCateWindow chooseCateWindow = new ChooseCateWindow();
            chooseCateWindow.ShowDialog();

            _selectedCategoryId = chooseCateWindow.SelectCategoryId;
        }
    }
}

