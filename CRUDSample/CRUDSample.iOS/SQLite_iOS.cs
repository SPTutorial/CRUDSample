using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CRUDSample.iOS;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace CRUDSample.iOS
{
    public class SQLite_iOS : ISQLite
    {
        SQLiteConnection con;
        public SQLiteConnection GetConnectionWithCreateDatabase()
        {
            string fileName = "sampleDatabase.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, fileName);
            con = new SQLiteConnection(path);
            con.CreateTable<Employee>();
            return con;
        }
        public bool SaveEmployee(Employee employee)
        {
            bool res = false;
            try
            {
                con.Insert(employee);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
        public List<Employee> GetEmployees()
        {
            string sql = "SELECT * FROM Employee";
            List<Employee> employees = con.Query<Employee>(sql);
            return employees;
        }
        public bool UpdateEmployee(Employee employee)
        {
            bool res = false;
            try
            {
                string sql = $"UPDATE Employee SET Name='{employee.Name}',Address='{employee.Address}',PhoneNumber='{employee.PhoneNumber}'," +
                                $"Email='{employee.Email}' WHERE Id={employee.Id}";
                con.Execute(sql);
                res = true;
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public void DeleteEmployee(int Id)
        {
            string sql = $"DELETE FROM Employee WHERE Id={Id}";
            con.Execute(sql);
        }
    }
}