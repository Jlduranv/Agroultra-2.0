using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;



namespace EVALUACION_2_TP.Controllers
{
    public class bddController : Controller
    {
        // GET: bdd
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult mostrar()
        {
            SqlConnection con = new SqlConnection(data);
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from contactos";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "";
            while(dr.Read())
            {
                mensaje = mensaje + dr["rut"].ToString();

            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return View("/Views/bdd/respuestas.cshtml");
        }
    }
}