using System.Windows;

namespace MultiformApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddingEmployee ae = new AddingEmployee(vm);
            ae.ShowDialog();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow ew = new EmployeeWindow(vm);
            ew.ShowDialog();
        }
    }
}
