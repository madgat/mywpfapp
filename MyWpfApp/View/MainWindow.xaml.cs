using System.Windows;
using System.Windows.Controls;
using MyApp.ViewModel;

namespace MyApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;    

        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var bllEmployee = new BLL.Employee();
            main.DataContext= bllEmployee.GetData();
        }

        private void dgEmployees_SelectedCellsChanged(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            var dg = sender as DataGrid;
            var vm = dg.CurrentCell.Item as EmployeViewModel;
            spButtons.DataContext = vm;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            var bllEmployee = new BLL.Employee();
            main.DataContext = bllEmployee.GetData();
        }
    }
}
