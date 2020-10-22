using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAnalisis2.Models;

namespace ProyectoAnalisis2.Controllers
{
    public class T_ProductoController : Controller
    {
        private Analigrupo5Entities db = new Analigrupo5Entities();

        // GET: T_Producto
        public ActionResult Index()
        {
            List<T_Producto> productos = db.T_Producto.Where(x=>x.Cantidad>0 && x.Id_tipo==1).ToList();
            return View(productos);
        }

        // GET: T_Producto
        public ActionResult Servicios()
        {
            List<T_Producto> productos = db.T_Producto.Where(x => x.Cantidad > 0 && x.Id_tipo == 2).ToList();
            return View(productos);
        }

        // GET: T_Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Producto t_Producto = db.T_Producto.Find(id);
            if (t_Producto == null)
            {
                return HttpNotFound();
            }
            return View(t_Producto);
        }

        // GET: T_Producto/Create
        public ActionResult Create()
        {
            ViewBag.Id_Color = new SelectList(db.T_color, "Id_Color", "Descripcion_Color");
            ViewBag.Id_Proveedor = new SelectList(db.T_Proveedor, "Id_proveedor", "Nombre_proveedor");
            ViewBag.Id_tipo = new SelectList(db.T_Tipo, "Id_tipo", "Descripcion_tipo");
            return View();
        }

        // POST: T_Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T_Producto t_Producto, HttpPostedFileBase file_imagen)
        {
            if (ModelState.IsValid)
            {
                MemoryStream target = new MemoryStream();
                file_imagen.InputStream.CopyTo(target);
                byte[] imageArray = target.ToArray();
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                t_Producto.imagen = "data:image/png;base64," + base64ImageRepresentation;
                db.T_Producto.Add(t_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Color = new SelectList(db.T_color, "Id_Color", "Descripcion_Color", t_Producto.Id_Color);
            ViewBag.Id_Proveedor = new SelectList(db.T_Proveedor, "Id_proveedor", "Nombre_proveedor", t_Producto.Id_Proveedor);
            ViewBag.Id_tipo = new SelectList(db.T_Tipo, "Id_tipo", "Descripcion_tipo", t_Producto.Id_tipo);
            return View(t_Producto);
        }

        // GET: T_Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Producto t_Producto = db.T_Producto.Find(id);
            if (t_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Color = new SelectList(db.T_color, "Id_Color", "Descripcion_Color", t_Producto.Id_Color);
            ViewBag.Id_Proveedor = new SelectList(db.T_Proveedor, "Id_proveedor", "Nombre_proveedor", t_Producto.Id_Proveedor);
            ViewBag.Id_tipo = new SelectList(db.T_Tipo, "Id_tipo", "Descripcion_tipo", t_Producto.Id_tipo);
            return View(t_Producto);
        }

        // POST: T_Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(T_Producto t_Producto, HttpPostedFileBase file_imagen)
        {
            if (ModelState.IsValid)
            {
                MemoryStream target = new MemoryStream();
                file_imagen.InputStream.CopyTo(target);
                byte[] imageArray = target.ToArray();
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                T_Producto productoEdit = db.T_Producto.Find(t_Producto.Id_producto);
                productoEdit.Id_tipo = t_Producto.Id_tipo;
                productoEdit.Id_Color = t_Producto.Id_Color;
                productoEdit.Id_Proveedor = t_Producto.Id_Proveedor;
                productoEdit.Nombre_oproducto = t_Producto.Nombre_oproducto;
                productoEdit.Descripcion = t_Producto.Descripcion;
                productoEdit.Fecha_ingreso = t_Producto.Fecha_ingreso;
                productoEdit.Cantidad = t_Producto.Cantidad;
                productoEdit.imagen = "data:image/png;base64," + base64ImageRepresentation;
                db.Entry(productoEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Color = new SelectList(db.T_color, "Id_Color", "Descripcion_Color", t_Producto.Id_Color);
            ViewBag.Id_Proveedor = new SelectList(db.T_Proveedor, "Id_proveedor", "Nombre_proveedor", t_Producto.Id_Proveedor);
            ViewBag.Id_tipo = new SelectList(db.T_Tipo, "Id_tipo", "Descripcion_tipo", t_Producto.Id_tipo);
            return View(t_Producto);
        }

        // GET: T_Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Producto t_Producto = db.T_Producto.Find(id);
            if (t_Producto == null)
            {
                return HttpNotFound();
            }
            return View(t_Producto);
        }

        // POST: T_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Producto t_Producto = db.T_Producto.Find(id);
            db.T_Producto.Remove(t_Producto);
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
