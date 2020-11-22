using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace EVALUACION_2_TP.Controllers
{
    public class bddController : Controller
    {
        // GET: bdd
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult mostrar(string user, string pass)
        {

            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from usuarios where nombre = '" + user + "' and clave = '" + pass + "'";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "El usuario NO existe y/o la contraseña es incorrecta";
            if (dr.Read())
            {
                string nivel = dr["nivel"].ToString();
                //con.Close();
                if (nivel == "1")
                {
                    mensaje = "Usuario(a): " + user + "";
                    ViewBag.mensaje = mensaje;
                    return RedirectToAction("Menu_Opciones", "Home");
                }
                else
                {
                    mensaje = "Bienvenido(a) " + user + "";
                    ViewBag.mensaje = mensaje;
                    return RedirectToAction("Vista_Usuario", "Home");
                }
            }

            con.Close();
            ViewBag.mensage = mensaje;
            return View("/Views/bdd/respuesta.cshtml");
        }

        public ActionResult agregar()
        {
            return View();
        }
    }
}