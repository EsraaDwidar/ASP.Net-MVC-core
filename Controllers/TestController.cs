using Lab3_MVC.Interfaces;
using Lab3_MVC.Models;
using Lab3_MVC.MyFilter;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_MVC.Controllers
{
    [MyExceptionHandling]
    public class TestController : Controller
    {
        ITIContext db = new ITIContext();
        IDeptRepo deptRepo;

        public TestController(IDeptRepo _deptRepo)
        {
            deptRepo = _deptRepo;
        }

        public ActionResult Show([FromServices] IDeptRepo _r)
        {
            return Content($"{deptRepo.GetHashCode().ToString()} : {_r.GetHashCode().ToString()}");
        }
        public IActionResult Index()
        {
            int x = int.Parse("20fff");
            return Content(x.ToString());
        }
        [MyAthurizeFilter]

        public IActionResult Add()
        {
            return Content("add");
        }

        public IActionResult Login()
        {
            return Content("login");
        }


        public IActionResult Create()
        {
            int x = int.Parse("20fff");
            return Content(x.ToString());
        }

        public IActionResult CreateCookies()
        {
            int id = 20;
            string name = "aly";
            //   Response.Cookies.Append("sid",id.ToString(), new CookieOptions() { Expires=DateTime.Now.AddDays(5)});
            //  Response.Cookies.Append("fname", name);
            HttpContext.Session.SetInt32("id", id);
            HttpContext.Session.SetString("name", name);

            return Content("Data Created");

        }


        public IActionResult ShowCookies()
        {
            //int id = int.Parse(Request.Cookies["sid"]);
            // string name = Request.Cookies["fname"];
            int id = HttpContext.Session.GetInt32("id") ?? 0;
            string name = HttpContext.Session.GetString("name");
            return Content($"{id}:{name}");

        }

        public IActionResult IndexCookies()
        {
            return View();

        }
    }
}
