using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagicEnglish.Models;


namespace MagicEnglish.Controllers
{
    public class LecturesController : Controller
    {
        private MagicEnglishModel db = new MagicEnglishModel();

        public static Lecture temp = new Lecture();

        // GET: Lectures
        public ActionResult Index()
        {
            return View(db.Lectures.ToList());
        }

        // GET: Lectures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        public ActionResult ErrorInfor()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        // GET: Lectures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NAME,Description,Date,Score,Score_num")] Lecture lecture)
        {
            bool same = false;
            foreach (Lecture lec in db.Lectures.ToList())
            {
                if(lec.Date == lecture.Date)
                {
                    same = true;
                }
            }
            if(same == false)
            {
                if (ModelState.IsValid)
                {
                    // Validation of Score and Score number
                    if (float.Parse(lecture.Score) > 5 || float.Parse(lecture.Score) < 0 || lecture.Score_num < 0)
                    {
                        return RedirectToAction("ErrorInfor");
                    } 
                    else
                    {
                        db.Lectures.Add(lecture);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                return RedirectToAction("Error");
            }
          

            return View(lecture);
        }

        // GET: Lectures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NAME,Description,Date,Score,Score_num")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        public ActionResult Rate(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            temp = lecture;
            if (lecture == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> selection = new List<SelectListItem>();
            selection.Add(new SelectListItem() { Text = "★", Value = "1", Selected = false });
            selection.Add(new SelectListItem() { Text = "★★", Value = "2", Selected = false });
            selection.Add(new SelectListItem() { Text = "★★★", Value = "3", Selected = false });
            selection.Add(new SelectListItem() { Text = "★★★★", Value = "4", Selected = false });
            selection.Add(new SelectListItem() { Text = "★★★★★", Value = "5", Selected = true });
            ViewBag.Select = selection;
            return View(lecture);
        }
        [HttpPost]
        public ActionResult Rate(FormCollection form)
        {
            string rate = form["Select"];
            int rateScore = 0;
            int.TryParse(rate, out rateScore);
            double dou = double.Parse(temp.Score);
            double finalScore = (dou * temp.Score_num + rateScore) / (temp.Score_num + 1);
            temp.Score = String.Format("{0:F}", finalScore);
            temp.Score_num++;

            if (ModelState.IsValid)
            {
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(temp);
        }

        public ActionResult Book(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        [HttpPost, ActionName("Book")]
        [ValidateAntiForgeryToken]
        public ActionResult BookConfirmed(int id)
        {
            return RedirectToAction("Index");
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            db.Lectures.Remove(lecture);
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
