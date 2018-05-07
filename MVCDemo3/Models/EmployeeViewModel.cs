using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo3.Models
{
    public class EmployeeViewModel
    {
        
        public string EmployeeName { get; set; }        
        public int EmployeeSalary { get; set; }
        public string Color { get; set; }
        
    }
}