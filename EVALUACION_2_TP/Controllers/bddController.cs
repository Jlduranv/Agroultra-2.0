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
        [HttpPost]
        public ActionResult mostrar(string user, string pass)
        {
            //conexion Pablo
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pablosotosaavedra\source\repos\Jlduranv\Agroultra-2.0\bdd_agro.mdf;Integrated Security=True;Connect Timeout=30");
            //conexion Emilio
            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from usuarios where nombre = '"+user+"' and clave = '"+pass+"'";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "El ususario NO existe";        
            while (dr.Read())
            {
                mensaje = "El ususario SI existe";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return View("/Views/bdd/respuesta.cshtml");
        }
    }
}