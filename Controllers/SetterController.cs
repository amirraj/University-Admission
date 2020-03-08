using Admission.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Admission.Controllers
{
    public class SetterController : Controller
    {
        // GET: Setter
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(QuestionViewModel ques)
        {
            try
                {
                    if (ModelState.IsValid)
                    {
                        using (Varsity_Admission db = new Varsity_Admission())
                        {
                            Question question = new Question();
                            question.E_Year = ques.E_Year;
                            question.Q_Body = ques.Q_Body;
                            question.Op_1 = ques.Op_1;
                            question.Op_2 = ques.Op_2;
                            question.Op_3 = ques.Op_3;
                            question.Op_4 = ques.Op_4;
                            question.Op_5 = ques.Op_5;
                            question.Q_Answer = ques.Q_Answer;

                            db.Questions.Add(question);
                            db.SaveChanges();

                            ViewBag.success_insert = "Data inserted successfully";
                            ModelState.Clear();
                            return View();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            
            return View();
            
        }

        public ActionResult SeeYear()
        {
            //Varsity_Admission examEntity = new Varsity_Admission();
            //var getYear = examEntity.Exams.ToList();
            //SelectList list = new SelectList(getYear, "E_Id", "E_Year");
            //ViewBag.year = list;
            return View();

            
        }

        [HttpPost]
        public ActionResult SeeYear(int? year)
        {
            try
            {
                
                    if (year == null)
                    {
                        ViewBag.error = "Invalid Request !";
                    }
                    else
                        return RedirectToAction("SeeQues", new { Id = year });
                    //ModelState.Clear();
                    // ViewBag.error.clear();

            }
            catch (Exception e)
            {
                throw e;
                //ViewBag.err = "Error !";
            }

            return View();
        }

        public ActionResult SeeQues(int id)
        {
            
            Varsity_Admission queEntity = new Varsity_Admission();

            var ques = queEntity.Questions
               .Where(q => q.E_Year == id);

            var queList = ques.ToList();
            if(!queList.Any())
            {
                ViewBag.empty = "No Data Found! ";
            }
            return View(queList);
        }

        public ActionResult Edit(int? id)
        {
            Varsity_Admission queEntity = new Varsity_Admission();
            Question que = queEntity.Questions.Find(id);
            return View(que);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Q_Id,E_Year,Q_Body,Op_1,Op_2,Op_3,Op_4,Op_5,Q_Answer")] Question qstn)
        {
            Varsity_Admission queEntity = new Varsity_Admission();
            int yr;
            if (ModelState.IsValid)
            {
                queEntity.Entry(qstn).State = EntityState.Modified;
                queEntity.SaveChanges();
                yr = qstn.E_Year;
                return RedirectToAction("SeeQues", new { Id = yr });
            }
            //  return View(prson);
            else
            {
                return View();
            }

        }


        public ActionResult Delete(int? id)
        {
            Varsity_Admission queEntity = new Varsity_Admission();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Employee employee = db.Employees.Find(id);
            Question que = queEntity.Questions.Find(id);
            if (que == null)
            {
                return HttpNotFound();
            }
            return View(que);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Varsity_Admission queEntity = new Varsity_Admission();
            Question qs = queEntity.Questions.Find(id);
            int yr = qs.E_Year;
            queEntity.Questions.Remove(qs);
            queEntity.SaveChanges();
            return RedirectToAction("SeeQues", new { Id = yr });
            //return RedirectToAction("Index");
        }
    }
}