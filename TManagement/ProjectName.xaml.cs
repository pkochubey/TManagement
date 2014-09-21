using System.Windows;

namespace TManagement
{
    public partial class ProjectName : Window
    {
        public ProjectName(string projectName)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;

            ProjectNameTextBox.Text = projectName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}