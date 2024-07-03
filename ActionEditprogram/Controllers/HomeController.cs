using ActionEditprogram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionEditprogram.Controllers
{
    public class HomeController : Controller
    {
        public static List<Employee> empList = new List<Employee>
        {
            new Employee
            {
                UserId = 1,
                UserName = "Pratikshya",
                company = "Google",
                Salary = 40000
            },
            new Employee
            {
                UserId = 2,
                UserName = "Ritika",
                company = "Zomato",
                Salary = 42000
            },
            new Employee
            {
                UserId = 3,
                UserName = "Pragati",
                company = "Wipro",
                Salary = 30000
            },
            new Employee
            {
                UserId = 4,
                UserName = "Princy",
                company = "Deloite",
                Salary = 60000
            },
            new Employee
            {
                UserId = 5,
                UserName = "Anil Yadav",
                company = "Swiggy",
                Salary = 43000
            }

        };
        // GET: Home
        public ActionResult Index()
        {
            var employees = from e in empList
                           orderby e.UserId
                           select e;
            return View(employees);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var employee = empList.Single(m => m.UserId == id);
            return View(employee);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,Employee emp)
        {
            try
            {
                // TODO: Add insert logic here
                empList.Add(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = empList.Single(m => m.UserId == id);
            return View(emp);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var emp = empList.Single(m => m.UserId == id);
                TryUpdateModel(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = empList.Single(m => m.UserId == id);
            return View(employee);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                empList.RemoveAll(m => m.UserId == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
