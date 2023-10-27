using ASP.NET_CORE_7_MVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_7_MVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.greeting = "Hello world";
            ViewData["greeting2"] = "I am using viewData";
            TempData["greeting3"] = "I am using TempData";
            return View();
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person) 
        { 
            return View(); 
        }
    }
}
