using System.Windows;

namespace MultiformApplication
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        VM vm;
        public EmployeeWindow(VM vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Db db = Db.GetInstance();
            db.Update(vm.SelectedEmployee);
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Db db = Db.GetInstance();
            db.Delete(vm.SelectedEmployee);
            vm.Employees.Remove(vm.SelectedEmployee);
            Close();
        }
    }
}
