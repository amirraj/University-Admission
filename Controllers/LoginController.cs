using Admission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Admission.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login logs)
        {
            try
            {
                string email;
                string Sname;
                string Settername;
                string designation;
                using (Varsity_Admission db = new Varsity_Admission())
                {
                    //Login logusr = new Login();
                    var usr = db.Logins.Single(u => u.L_Email == logs.L_Email && u.L_Password == logs.L_Password);
                    //if (usr != null && logs.L_Designation == "student")

                    if (usr != null)
                    {
                       
                        designation = usr.L_Designation.ToString();

                        if(designation == "student")
                        {
                            Session["studentlogin"] = true;

                            email = usr.L_Email.ToString();
                            Session["student_id"] = usr.L_Id.ToString();
                            Session["student_mail"] = email;
                            //return RedirectToAction("LoggedIn");
                            var usr2 = db.Students.Where(u => u.S_Email == email).Select(u => new
                            {
                                S_name = u.S_Name
                            }).Single();

                            Sname = usr2.S_name.ToString();
                            Session["student_name"] = Sname;
                            return RedirectToAction("Index", "Student");
                        }
                       
                        if (designation == "setter")
                        {
                            Session["setterlogin"] = true;
                            email = usr.L_Email.ToString();
                            Session["setter_id"] = usr.L_Id.ToString();
                            Session["setter_mail"] = email;
                            //return RedirectToAction("LoggedIn");
                            var usr2 = db.Setters.Where(u => u.Se_Email == email).Select(u => new
                            {
                                Setter_name = u.Se_Name
                            }).Single();

                            Settername = usr2.Setter_name.ToString();
                            Session["setter_name"] = Settername;
                            return RedirectToAction("Index","Setter");
                        }
                        if (designation == "admin")
                        {
                            Session["adminlogin"] = true;
                            return RedirectToAction("Index", "Admin");
                        }
                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email or password is wrong!");
                        return View();
                    }
                }
            }
            catch (Exception e)
            {
                //throw e;
                ModelState.AddModelError("", "Email or password is wrong!");
                return View();
            }

            //return RedirectToAction("Index");
            return RedirectToAction("LoggedIn");
        }

        //public ActionResult LoggedIn()
        //{
        //    if (Session["student_id"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();  
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}