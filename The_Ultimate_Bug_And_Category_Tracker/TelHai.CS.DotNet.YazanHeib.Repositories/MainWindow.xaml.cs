using System.Windows;
using TelHai.CS.DotNet.YazanHeib.Repositories.BugCategoryHierarchy;
using TelHai.CS.DotNet.YazanHeib.Repositories;



namespace TelHai.CS.DotNet.YazanHeib.Repositories
{
    /// </summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Open a Bug Window.
        /// </summary>
        private void openBugWindow_Click(object sender, RoutedEventArgs e)
        {
            BugWindow bugCategory = new BugWindow();
            bugCategory.Show();
        }


        /// <summary>
        /// Open a Category Window Button.
        /// </summary>
        private void openCategoryWindow_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow();
            categoryWindow.Show();
        }


        /// <summary>
        /// Close The Program Button.
        /// </summary>
        private void closeApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        /// <summary>
        /// Save All Bug's And Categories To File.
        /// </summary>
        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // try To save The data.
                SaveDataToFile saveDataToFile = new SaveDataToFile("Category_And_Bug_Data.txt");
                saveDataToFile.saveDataInTreeStructure();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}