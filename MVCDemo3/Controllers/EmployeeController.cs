using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using MVCDemo3.Filter;
using MVCDemo3.Models;

namespace MVCDemo3.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //public ActionResult GetData()
        //{ }

        public void InsertData()
        {
            EmployeeBLL empBLL = new EmployeeBLL();
            Employees emp = new Employees() { EmployeeId = 1, FirstName = "peter", LastName = "james", Salary = 20000 };
            empBLL.InsertData(emp);
        }

        //给项目默认的视图添加[Authorize]帮助我们跳转到登录页面
        [Authorize]
        public ActionResult Index()
        {
            EmployeeBLL empBLL = new EmployeeBLL();
            List<Employees> empModelList = empBLL.GetEmployees();
            EmployeeViewModelList empViewModelList = new EmployeeViewModelList();
            empViewModelList.UserName = User.Identity.Name;
            empViewModelList.EmployeeList = new List<EmployeeViewModel>();
            if (empModelList.Count() > 0)
            {
                foreach (Employees item in empModelList)
                {
                    EmployeeViewModel model = new EmployeeViewModel();
                    model.EmployeeName = item.FirstName + " " + item.LastName;
                    model.EmployeeSalary = item.Salary;
                    if (item.Salary > 10000)
                    {
                        model.Color = "green";
                    }
                    else
                    {
                        model.Color = "red";
                    }                    
                    empViewModelList.EmployeeList.Add(model);
                }
            }
            empViewModelList.FooterData = new FootViewModel();
            empViewModelList.FooterData.CompanyName = "宇宙超级科技有限公司";
            empViewModelList.FooterData.Year = "2018";
            return View("Index", empViewModelList);
        }
        [AdminFilter]
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        //通过form标签提交数据到服务器
        //获取标签的name属性
        //只要name属性值和对象的属性值相同就可以在这里获取
        //原理:
        //1.在 ASP.NET MVC 中，存有一个概念，叫做 Model Binder
        //2.无论何时一个包含参数的请求向 Action 方法发送时，Model Binder 都会自动执行。
        //3.Model Binder 将会遍历方法的所有原始参数，然后将它们与发送过来的数据的参数的名称相对比。（发送过来的数据意味着要么是 Posted 数据，或者是查询字符串）。当匹配成功时，会依照发送过来的数据分配给参数。
        //4.当 Model Binder 遍历完每一个类参数中的每一个属性后，然后和发送过来的数据做对比。当匹配成功后，依照发送过来的数据分配给参数。
        [AdminFilter]
        public ActionResult SaveEmployee(Employees e, string BtnSub)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEmployee");
            }
            else
            {
                switch (BtnSub)
                {
                    case "Save Employee":
                        return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                    case "Cancle":
                        return RedirectToAction("Index");
                }
                return new EmptyResult();
            }
            
        }

        public ActionResult GetAddNewView()
        {
            if (Convert.ToBoolean(Session["IsAdmin"])  == true)
            {
                return PartialView("AddNew");
            }
            else
            {
                return new EmptyResult();
            }
        }
        
    }
}