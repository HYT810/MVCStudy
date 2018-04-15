using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DAL
{
    public class EmployeeDAL
    {
        public int InsertData(Employees emp)
        {
            using (MyDBContext context = new MyDBContext())
            {
                context.Employees.Add(emp);
                return context.SaveChanges();
            }
        }

        public List<Employees> GetEmployees()
        {
            using (MyDBContext context = new MyDBContext())
            {
                List<Employees>list = context.Employees.ToList();               
                return list;
            }
        }
    }
}
