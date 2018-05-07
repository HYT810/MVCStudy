using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace BLL
{
    public class EmployeeBLL
    {
        public bool InsertData(Employees emp)
        {
            EmployeeDAL empDAL = new EmployeeDAL();
            int n = empDAL.InsertData(emp);
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Employees> GetEmployees()
        {
            EmployeeDAL empDAL = new EmployeeDAL();
            List<Employees> list = empDAL.GetEmployees();
            return list;
        }
    }
}
