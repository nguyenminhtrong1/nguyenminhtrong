using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using khachhang.Models;

namespace khachhang.Controllers
{
    public class KHsController : Controller
    {
        private khachhangDbContext db = new khachhangDbContext();

        // GET: KHs
        public ActionResult Index()
        {
            return View(db.Khachhang.ToList());
        }

        // GET: KHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KH kH = db.Khachhang.Find(id);
            if (kH == null)
            {
                return HttpNotFound();
            }
            return View(kH);
        }

        // GET: KHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDkhachhang,Name,Address,PhoneNumber")] KH kH)
        {
            if (ModelState.IsValid)
            {
                db.Khachhang.Add(kH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kH);
        }

        // GET: KHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KH kH = db.Khachhang.Find(id);
            if (kH == null)
            {
                return HttpNotFound();
            }
            return View(kH);
        }

        // POST: KHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDkhachhang,Name,Address,PhoneNumber")] KH kH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kH);
        }

        // GET: KHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KH kH = db.Khachhang.Find(id);
            if (kH == null)
            {
                return HttpNotFound();
            }
            return View(kH);
        }

        // POST: KHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KH kH = db.Khachhang.Find(id);
            db.Khachhang.Remove(kH);
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
