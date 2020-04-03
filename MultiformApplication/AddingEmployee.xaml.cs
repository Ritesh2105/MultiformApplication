using System.Windows;

namespace MultiformApplication
{
    /// <summary>
    /// Interaction logic for AddingEmployee.xaml
    /// </summary>
    public partial class AddingEmployee : Window
    {
        VM vm;
        public AddingEmployee(VM vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
        }
        private void Add_Employee_Click(object sender, RoutedEventArgs e)
        {
            Employee newEmployee = new Employee()
            {
                Employee_ID = vm.ID,
                Name = vm.Name,
                Position = vm.Position,
                Hourly_pay_rate = vm.PayRate
            };
            Db db = Db.GetInstance();
            db.Insert(newEmployee);
            vm.Employees.Add(newEmployee);
            vm.Reset();
            Close();
        }
    }
}
