using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admission.Models;
namespace Admission.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentViewModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Varsity_Admission db = new Varsity_Admission())
                    {
                        var userWithSameEmail = db.Students.Where(m => m.S_Email == student.S_Email).SingleOrDefault();
                        if (userWithSameEmail == null)
                        {
                            Student stud = new Student();
                            stud.S_Name = student.S_Name;
                            stud.S_Email = student.S_Email;
                            stud.S_Phone = student.S_Phone;

                            db.Students.Add(stud);
                            db.SaveChanges();

                            string mail = stud.S_Email;
                            Login log_instance = new Login();
                            log_instance.L_Email = mail;
                            log_instance.L_Password = student.L_Password;
                            log_instance.L_Designation = "student";

                            db.Logins.Add(log_instance);
                            db.SaveChanges();
                            ViewBag.success_msg = "Registration Successful";
                            return View();
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Email already exists !");
                            ViewBag.error_msg = "Email already exists !";
                            return View(student);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            //return View();
            return RedirectToAction("Index");

            //return View(student);
        }






    }
}