using ProyectoAnalisis2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAnalisis2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(T_Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                using (Analigrupo5Entities db = new Analigrupo5Entities())
                {
                    var obj = db.T_Usuarios.Where(a => a.Usuario.Equals(usuarios.Usuario) && a.Passw.Equals(usuarios.Passw)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id_usuario.ToString();
                        Session["UserName"] = obj.Usuario.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(usuarios);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Esta página está diseñada para la venta de árticulos y servicios de higiene contra el COVID-19.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto de la página";

            return View();
        }
    }
}