using System.Windows;

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
            dgEmployees.ItemsSource = bllEmployee.GetData();
        }
    }
}
