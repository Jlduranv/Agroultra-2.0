using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EVALUACION_2_TP.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        
        public ActionResult Registro_Fruto()
        {
            return View();
        }
        public ActionResult Registro_Sectores()
        {
            return View();
        }
        public ActionResult Menu_Opciones()
        {
            return View();
        }
        public ActionResult Menu_Registros()
        {
            return View();
        }
        public ActionResult Registro_Usuario()
        {
            return View();
        }
        public ActionResult Registro_Asistencia()
        {
            return View();
        }
        public ActionResult Registro_Produccion()
        {
            return View();
        }
        public ActionResult Ingreso()
        {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}