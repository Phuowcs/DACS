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
    public class LichThiController : Controller
    {
        private testDACScontext db = new testDACScontext();

        // GET: LichThi
        public ActionResult Index()
        {
            var cT_Lich_thi = db.CT_Lich_thi.Include(c => c.LICHTHI).Include(c => c.LOP);
            return View(cT_Lich_thi.ToList());
        }

        public ActionResult LichthiSearch(int? searchString)
        {
            if (searchString == null)
                return Redirect("Index");
            var hv = db.BIENLAIHOCPHIs.Where(p => p.MAHV == searchString).ToList();
            if (hv.Count == 0)
                return HttpNotFound("Không có thông tin học viên!");
            List<int> malop = new List<int>();
            foreach(var item in hv)
            {
                malop.Add(item.MALOP);
            }
            var kq = db.CT_Lich_thi.ToList();
            kq.Clear();
            foreach (var item in malop)
            {
                CT_Lich_thi k = db.CT_Lich_thi.Where(c => c.MALOP == item).FirstOrDefault();
                kq.Add(k);
            }
            //var result = db.CT_Lich_thi.Include(c => c.LICHTHI).Include(c => c.LOP).Where(c => c.LOP.BIENLAIHOCPHIs.FirstOrDefault().MAHV == searchString).ToList();
            //var result = db.CT_Lich_thi.Include(c => c.LICHTHI).Include(c => c.LOP).Where(c => c.MALOP == malop[0] || c.MALOP == malop[1]).ToList();
            //var result = db.CT_Lich_thi.(c => c.Lop).Where(p => p.MAHV == searchString).ToList();
            if (kq.Count > 0)
                return View("Index", kq);
            return View("Index");
        }

        // GET: LichThi/Details/5
        public ActionResult Details(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Lich_thi cT_Lich_thi = db.CT_Lich_thi.Find(id1,id2);
            if (cT_Lich_thi == null)
            {
                return HttpNotFound();
            }
            return View(cT_Lich_thi);
        }

        // GET: LichThi/Create
        public ActionResult Create()
        {
            ViewBag.MALT = new SelectList(db.LICHTHIs, "MALT", "MALT");
            ViewBag.MALOP = new SelectList(db.LOPs, "MALOP", "TENLOP");
            return View();
        }

        // POST: LichThi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOP,MALT,NGAYTHI,GIOBD,SOPHUT,PHONG,GHICHU")] CT_Lich_thi cT_Lich_thi)
        {
            if (ModelState.IsValid)
            {
                db.CT_Lich_thi.Add(cT_Lich_thi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MALT = new SelectList(db.LICHTHIs, "MALT", "MALT", cT_Lich_thi.MALT);
            ViewBag.MALOP = new SelectList(db.LOPs, "MALOP", "TENLOP", cT_Lich_thi.MALOP);
            return View(cT_Lich_thi);
        }

        // GET: LichThi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Lich_thi cT_Lich_thi = db.CT_Lich_thi.Find(id);
            if (cT_Lich_thi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALT = new SelectList(db.LICHTHIs, "MALT", "MALT", cT_Lich_thi.MALT);
            ViewBag.MALOP = new SelectList(db.LOPs, "MALOP", "TENLOP", cT_Lich_thi.MALOP);
            return View(cT_Lich_thi);
        }

        // POST: LichThi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOP,MALT,NGAYTHI,GIOBD,SOPHUT,PHONG,GHICHU")] CT_Lich_thi cT_Lich_thi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_Lich_thi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MALT = new SelectList(db.LICHTHIs, "MALT", "MALT", cT_Lich_thi.MALT);
            ViewBag.MALOP = new SelectList(db.LOPs, "MALOP", "TENLOP", cT_Lich_thi.MALOP);
            return View(cT_Lich_thi);
        }

        // GET: LichThi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Lich_thi cT_Lich_thi = db.CT_Lich_thi.Find(id);
            if (cT_Lich_thi == null)
            {
                return HttpNotFound();
            }
            return View(cT_Lich_thi);
        }

        // POST: LichThi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_Lich_thi cT_Lich_thi = db.CT_Lich_thi.Find(id);
            db.CT_Lich_thi.Remove(cT_Lich_thi);
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
