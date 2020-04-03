using System.Collections.Generic;
using System.Data.SqlClient;

namespace MultiformApplication
{
    public class Db
    {
        private const string DROP_DATABASE = "DROP DATABASE Personnel;";
        private const string CONN_STRING = "Server=.\\SQLEXPRESS;Trusted_Connection=True;";
        private const string CREATE_DATABASE = "IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE name = 'Personnel') CREATE DATABASE Personnel;";
        private const string USE_DATABASE = "USE Personnel;";
        private const string CREATE_TABLE = "IF NOT EXISTS(SELECT TABLE_NAME FROM Personnel.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Employee') CREATE Table Employee(Employee_ID int Primary Key, Name nvarchar(max), Position nvarchar(max), Hourly_pay_rate decimal(5,2));";
        private const string READ_COMMAND = "SELECT * FROM EMPLOYEE";
        private const string INSERT_COMMAND = "INSERT INTO EMPLOYEE(Employee_ID, Name, Position, Hourly_pay_rate) VALUES(@Employee_ID, @Name, @Position, @Hourly_pay_rate)";
        private const string UPDATE_COMMAND = "UPDATE EMPLOYEE SET Name = @Name, Position = @Position, Hourly_pay_rate = @Hourly_pay_rate WHERE Employee_ID = @Employee_ID";
        private const string DELETE_COMMAND = "DELETE FROM EMPLOYEE WHERE Employee_ID=@Employee_ID";
        private const string INSERT_VALUES_COMMAND = "IF EXISTS(SELECT TABLE_NAME FROM Personnel.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Employee') INSERT INTO EMPLOYEE(Employee_ID, Name, Position, Hourly_pay_rate) VALUES(1,'Jack','Manager',200),(2,'Jill','Team Lead',180),(3,'Jacob','Developer',210)";
        private static Db db;
        private readonly SqlConnection conn;
        static public Db GetInstance()
        {
            if (db == null)
                db = new Db();
            return db;
        }
        private Db()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }
        public void CreateDatabase()
        {
            SqlCommand cmd_drop_database = new SqlCommand(DROP_DATABASE, conn);
            SqlCommand cmd_create_database = new SqlCommand(CREATE_DATABASE, conn);
            SqlCommand cmd_use_database = new SqlCommand(USE_DATABASE, conn);
            SqlCommand cmd_create_table = new SqlCommand(CREATE_TABLE, conn);
            SqlCommand cmd_insert_values = new SqlCommand(INSERT_VALUES_COMMAND, conn);
            cmd_drop_database.ExecuteNonQuery();
            cmd_create_database.ExecuteNonQuery();
            cmd_use_database.ExecuteNonQuery();
            cmd_create_table.ExecuteNonQuery();
            cmd_insert_values.ExecuteNonQuery();
        }
        public List<Employee> Read()
        {
            List<Employee> employees = new List<Employee>();
            SqlCommand cmd = new SqlCommand(READ_COMMAND, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int e = rdr.GetOrdinal("Employee_ID");
                int n = rdr.GetOrdinal("Name");
                int p = rdr.GetOrdinal("Position");
                int h = rdr.GetOrdinal("Hourly_pay_rate");
                employees.Add(new Employee
                {
                    Employee_ID = rdr.IsDBNull(e) ? 0 : rdr.GetInt32(e),
                    Name = rdr.IsDBNull(n) ? null : rdr.GetString(n),
                    Position = rdr.IsDBNull(p) ? null : rdr.GetString(p),
                    Hourly_pay_rate = rdr.IsDBNull(h) ? 0 : rdr.GetDecimal(h)
                });
            }
            rdr.Close();
            return employees;
        }
        public int Insert(Employee e)
        {
            SqlCommand cmd = new SqlCommand(INSERT_COMMAND, conn);
            cmd.Parameters.AddWithValue("@Employee_ID", e.Employee_ID);
            cmd.Parameters.AddWithValue("@Name", e.Name ?? "");
            cmd.Parameters.AddWithValue("@Position", e.Position ?? "");
            cmd.Parameters.AddWithValue("@Hourly_pay_rate", e.Hourly_pay_rate);

            return cmd.ExecuteNonQuery();
        }
        public int Update(Employee e)
        {
            SqlCommand cmd = new SqlCommand(UPDATE_COMMAND, conn);
            cmd.Parameters.AddWithValue("@Employee_ID", e.Employee_ID);
            cmd.Parameters.AddWithValue("@Name", e.Name ?? "");
            cmd.Parameters.AddWithValue("@Position", e.Position ?? "");
            cmd.Parameters.AddWithValue("@Hourly_pay_rate", e.Hourly_pay_rate);
            return cmd.ExecuteNonQuery();
        }
        public int Delete(Employee e)
        {
            SqlCommand cmd = new SqlCommand(DELETE_COMMAND, conn);
            cmd.Parameters.AddWithValue("@Employee_ID", e.Employee_ID);
            return cmd.ExecuteNonQuery();
        }
    }
}
