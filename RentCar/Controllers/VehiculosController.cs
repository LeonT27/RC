using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class VehiculosController : Controller
    {
        private RC db = new RC();

        // GET: Vehiculos
        public ActionResult Index()
        {
            var vehiculo = db.Vehiculo.Include(v => v.Marca).Include(v => v.Modelo).Include(v => v.TipoCombustible).Include(v => v.TipoVehiculo);
            return View(vehiculo.ToList());
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            ViewBag.IdMarca = new SelectList(db.Marca.Where(m => m.Estado == true), "Id", "Descripcion");
            ViewBag.IdModelo = new SelectList(db.Modelo.Where(m => m.Estado == true), "Id", "Descripcion");
            ViewBag.IdTipoCombustible = new SelectList(db.TipoCombustible.Where(m => m.Estado == true), "Id", "Descripcion");
            ViewBag.IdTipoVehiculo = new SelectList(db.TipoVehiculo.Where(m => m.Estado == true), "Id", "Descripcion");
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,NoChasis,NoMotor,NoPlaca,IdTipoVehiculo,IdMarca,IdModelo,IdTipoCombustible,Estado")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMarca = new SelectList(db.Marca.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelo.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdModelo);
            ViewBag.IdTipoCombustible = new SelectList(db.TipoCombustible.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdTipoCombustible);
            ViewBag.IdTipoVehiculo = new SelectList(db.TipoVehiculo.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdTipoVehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMarca = new SelectList(db.Marca.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelo.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdModelo);
            ViewBag.IdTipoCombustible = new SelectList(db.TipoCombustible.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdTipoCombustible);
            ViewBag.IdTipoVehiculo = new SelectList(db.TipoVehiculo.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdTipoVehiculo);
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,NoChasis,NoMotor,NoPlaca,IdTipoVehiculo,IdMarca,IdModelo,IdTipoCombustible,Estado")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMarca = new SelectList(db.Marca.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelo.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdModelo);
            ViewBag.IdTipoCombustible = new SelectList(db.TipoCombustible.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdTipoCombustible);
            ViewBag.IdTipoVehiculo = new SelectList(db.TipoVehiculo.Where(m => m.Estado == true), "Id", "Descripcion", vehiculo.IdTipoVehiculo);
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            db.Vehiculo.Remove(vehiculo);
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
