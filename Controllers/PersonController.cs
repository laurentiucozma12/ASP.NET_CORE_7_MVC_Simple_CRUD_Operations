using ASP.NET_CORE_7_MVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP.NET_CORE_7_MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.greeting = "Hello world";
            ViewData["greeting2"] = "I am using ViewData";
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
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Account has been created with success!";

                return RedirectToAction("AddPerson");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Your account has not been created!";

                return View();
            }
        }
        
        public IActionResult DisplayPersons()
        {
            var persons = _ctx.Person.ToList();
            return View(persons);
        }

        public IActionResult EditPerson(int id)
        {
            var person = _ctx.Person.Find(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _ctx.Person.Update(person);
                _ctx.SaveChanges();

                TempData["msg"] = "Account has been updated with success!";

                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Your account has not been updated!";

                return View();
            }
        }

        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = _ctx.Person.Find(id);
                if(person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Your account has not been deleted!";

                return View();
            }

            return RedirectToAction("DisplayPersons");
        }
    }
}
