using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo3.Models
{
    public class EmployeeViewModelList
    {
        public List<EmployeeViewModel> EmployeeList { get; set; }
        public string UserName { get; set; }

        public FootViewModel FooterData { get; set; }//New Property
    }
}