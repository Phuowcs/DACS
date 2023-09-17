using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testDACS.Models;

namespace testDACS.Controllers
{
    public class ChungnhanController : Controller
    {
        private testDACScontext db = new testDACScontext();

        // GET: Chungnhan
        public ActionResult Index()
        {
            var cHUNGCHIs = db.CHUNGCHIs.Include(c => c.Du_thi);
            return View(cHUNGCHIs.ToList());
        }

        public ActionResult ChungnhanSearch(int? searchString)
        {
            if (searchString == null)
                return Redirect("Index");
            var result = db.CHUNGCHIs.Include(c => c.Du_thi).Where(p => p.MAHV == searchString).ToList();
            if (result.Count > 0)
                return View("Index", result);
            return HttpNotFound("Không có thông tin học viên!");
        }

        // GET: Chungnhan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUNGCHI cHUNGCHI = db.CHUNGCHIs.Find(id);
            if (cHUNGCHI == null)
            {
                return HttpNotFound();
            }
            return View(cHUNGCHI);
        }

        // GET: Chungnhan/Create
        public ActionResult Create()
        {
            ViewBag.MAHV = new SelectList(db.Du_thi, "MAHV", "MAHV");
            return View();
        }

        // POST: Chungnhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MACC,TENCC,MAHV,MAMH")] CHUNGCHI cHUNGCHI)
        {
            if (ModelState.IsValid)
            {
                db.CHUNGCHIs.Add(cHUNGCHI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHV = new SelectList(db.Du_thi, "MAHV", "MAHV", cHUNGCHI.MAHV);
            return View(cHUNGCHI);
        }

        // GET: Chungnhan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUNGCHI cHUNGCHI = db.CHUNGCHIs.Find(id);
            if (cHUNGCHI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHV = new SelectList(db.Du_thi, "MAHV", "MAHV", cHUNGCHI.MAHV);
            return View(cHUNGCHI);
        }

        // POST: Chungnhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MACC,TENCC,MAHV,MAMH")] CHUNGCHI cHUNGCHI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUNGCHI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHV = new SelectList(db.Du_thi, "MAHV", "MAHV", cHUNGCHI.MAHV);
            return View(cHUNGCHI);
        }

        // GET: Chungnhan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUNGCHI cHUNGCHI = db.CHUNGCHIs.Find(id);
            if (cHUNGCHI == null)
            {
                return HttpNotFound();
            }
            return View(cHUNGCHI);
        }

        // POST: Chungnhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHUNGCHI cHUNGCHI = db.CHUNGCHIs.Find(id);
            db.CHUNGCHIs.Remove(cHUNGCHI);
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
