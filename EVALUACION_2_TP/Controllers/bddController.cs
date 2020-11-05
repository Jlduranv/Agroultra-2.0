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
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from usuarios";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "";
            while(dr.Read())
            {
                mensaje = mensaje + dr["nombre"].ToString();

            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return View("/Views/bdd/respuesta.cshtml");
        }
    }
}