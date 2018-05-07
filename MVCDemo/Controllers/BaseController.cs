using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    //控制器入门,我们看下控制器的基本用法,注意:当我们创建一个控制器,VS会自动帮我们在View文件夹下创建一个同名的视图文件夹
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
        //1.我们在浏览器中通过http://localhost:port/Controller/Action就可以访问到对应的返回值 
        public string GetString()
        {
            return "Hello,MVC";
        }

        //2.和上面用一样的方式访问返回对象,我们得到的结果是对象.ToString(),返回类的完全限定名
        public TestModel GetModel()
        {
            TestModel model = new TestModel() { Age = 20, Name = "hyt" };
            return model;
        }

        //3.在控制器的方法上面添加[NonAction],就表明这个方法不是动作方法,不能再浏览器中进行访问
        [NonAction]
        public string GetModelName()
        {
            TestModel model = new TestModel() { Age = 20, Name = "hyt" };
            return model.Name;
        }

    }

    public class TestModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}