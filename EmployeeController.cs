using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using practice_asp.net_mvc.Models;
using static practice_asp.net_mvc.Models.Employee;

namespace practice_asp.net_mvc.Controllers
{
    public class EmployeeController : Controller
    {
        
            private EmpDBContext db = new EmpDBContext();
            // GET: Employee

            public ActionResult Index()
            {
                var employees = from e in db.Employees
                                orderby e.Id
                                select e;
                return View(employees);
            }

            // GET: Employee/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Employee/Create
            [HttpPost]
            public ActionResult Create(Employee emp)
            {
                try
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: Employee/Edit/5
            public ActionResult Edit(int id)
            {
                var employee = db.Employees.Single(m => m.Id== id);
                return View(employee);
            }

            // POST: Employee/Edit/5
            [HttpPost]
            public ActionResult Edit(int id, FormCollection collection)
            {
                try
                {
                    var employee = db.Employees.Single(m => m.Id == id);
                    if (TryUpdateModel(employee))
                    {
                        //To Do:- database code
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(employee);
                }
                catch
                {
                    return View();
                }
            }
        }
    
}