using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IS_403_Project_2.Models;
using System.Web.Security;

namespace IS_403_Project_2.Controllers
{
    public class DegreesController : Controller
    {
        private ISFAQContext db = new ISFAQContext();

        // GET: Degrees
        
        public ActionResult Index()
        {
            return View(db.Degrees.ToList());
        }

        
        public ActionResult Degree(int? id)
        {

            Degree degree = db.Degrees.Find(id);

            if (id != null)
            {
                return View(degree);
            }
            else
            {
                return View();
            }
        }

        public ActionResult ChooseDegree()
        {
            return View();
        }

        // GET: Degrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // GET: Degrees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DegreeID,dName,dCoord,dCoordTitle,dCoordOffice,dCoordPhD,dCoordMas,dCoordBach,picture")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Degrees.Add(degree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(degree);
        }

        // GET: Degrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DegreeID,dName,dCoord,dCoordTitle,dCoordOffice,dCoordPhD,dCoordMas,dCoordBach,picture")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Degree degree = db.Degrees.Find(id);
            db.Degrees.Remove(degree);
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

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();

            //if (string.Equals(email, "greg@test.com") && (string.Equals(password, "greg")))
            IEnumerable<Users> users = db.Database.SqlQuery<Users>("SELECT * FROM Users WHERE userEmail = '" + email + "' AND password = '" + password + "'");

            if (users.Count() == 1)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("ChooseDegree", "Degrees");
            }
            else
            {
                return View();
            }
        }
    }
}
