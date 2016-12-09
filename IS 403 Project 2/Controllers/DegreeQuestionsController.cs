using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IS_403_Project_2.Models;

namespace IS_403_Project_2.Controllers
{
    public class DegreeQuestionsController : Controller
    {
        private ISFAQContext db = new ISFAQContext();


        // GET: DegreeQuestions
        public ActionResult Index()
        {
            return View(db.DegreeQuestions.ToList());
        }

        [Authorize]
        public ActionResult FAQ(int? id)
        {
            //find all the quesions for the given degree
            var questions = from m in db.DegreeQuestions
            select m;

            if (id != null)
            {
                questions = questions.Where(s => s.degreeID == id);
            }
            ViewBag.degree = id;
            return View(questions); 
        }

        public ActionResult Ask(int? id)
        {
            if (id !=null)
            {
                ViewBag.degree = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ask([Bind(Include = "degreeQuestionID,degreeID,userID,question,answer")] DegreeQuestion degreeQuestion)
        {
            degreeQuestion.answer = "--Not Answered--";
            if (ModelState.IsValid)
            {
                db.DegreeQuestions.Add(degreeQuestion);
                db.SaveChanges();
                return RedirectToAction("FAQ", new { id = degreeQuestion.degreeID});
            }

            return View(degreeQuestion);
        }

        public ActionResult Answer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestion degreeQuestion = db.DegreeQuestions.Find(id);
            if (degreeQuestion == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Answer([Bind(Include = "degreeQuestionID,degreeID,userID,question,answer")] DegreeQuestion degreeQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degreeQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FAQ", new { id = degreeQuestion.degreeID});
            }
            return View(degreeQuestion);
        }

        // GET: DegreeQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestion degreeQuestion = db.DegreeQuestions.Find(id);
            if (degreeQuestion == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestion);
        }

        // GET: DegreeQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DegreeQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "degreeQuestionID,degreeID,userID,question,answer")] DegreeQuestion degreeQuestion)
        {
            if (ModelState.IsValid)
            {
                db.DegreeQuestions.Add(degreeQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(degreeQuestion);
        }

        // GET: DegreeQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestion degreeQuestion = db.DegreeQuestions.Find(id);
            if (degreeQuestion == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestion);
        }

        // POST: DegreeQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "degreeQuestionID,degreeID,userID,question,answer")] DegreeQuestion degreeQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degreeQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degreeQuestion);
        }

        // GET: DegreeQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestion degreeQuestion = db.DegreeQuestions.Find(id);
            if (degreeQuestion == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestion);
        }

        // POST: DegreeQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DegreeQuestion degreeQuestion = db.DegreeQuestions.Find(id);
            db.DegreeQuestions.Remove(degreeQuestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
