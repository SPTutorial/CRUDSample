using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDSample
{
    public interface ISQLite
    {
        SQLiteConnection GetConnectionWithCreateDatabase();

        bool SaveEmployee(Employee employee);

        List<Employee> GetEmployees();

        bool UpdateEmployee(Employee employee);
        void DeleteEmployee(int Id);
    }
}
