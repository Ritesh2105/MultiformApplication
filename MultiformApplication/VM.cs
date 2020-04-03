using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MultiformApplication
{
    public class VM : INotifyPropertyChanged
    {
        private BindingList<Employee> employees;
        public BindingList<Employee> Employees
        {
            get { return employees; }
            set { employees = value; onChange(); }
        }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set { selectedEmployee = value; onChange(); }
        }
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; onChange(); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; onChange(); }
        }
        private string position;
        public string Position
        {
            get { return position; }
            set { position = value; onChange(); }
        }
        private decimal payRate;
        public decimal PayRate
        {
            get { return payRate; }
            set { payRate = value; onChange(); }
        }
        public void Reset()
        {
            ID = 0;
            Name = string.Empty;
            position = string.Empty;
            PayRate = 0;
        }
        public VM()
        {
            Db db = Db.GetInstance();
            db.CreateDatabase();
            List<Employee> es = db.Read();
            Employees = new BindingList<Employee>(db.Read());
        }
        #region propertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void onChange([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
