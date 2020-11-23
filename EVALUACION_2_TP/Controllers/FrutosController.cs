using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace EVALUACION_2_TP.Controllers
{
    public class FrutosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Consultar()
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from frutos";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "<table class='table' border = 3 bgcolor = 'ebbbbb' width = '570' ><tr bgcolor = '975d72' >";

            mensaje = mensaje + "<td> ID FRUTOS <td> FRUTOS <td> ACCIONES";
            while (dr.Read())
            {

                mensaje = mensaje + "<tr><td>" + dr["id_fruto"].ToString();
                mensaje = mensaje + "<td>" + dr["tipo_fruto"].ToString();
                mensaje = mensaje + "<td><a href='/Frutos/Mostrar_Modificar/" + dr["id_fruto"].ToString() + "'>Modificar </a>";
                mensaje = mensaje + "<a href = '/Frutos/Eliminar/" + dr["id_fruto"].ToString() + "'onclick='return confirm(\"Estas seguro?\")'> Eliminar</a>";

            }
            mensaje = mensaje + "</td></tr></table>";
            ViewBag.lista = mensaje;
            con.Close();
            return View("/Views/Frutos/Consultar.cshtml");
        }
        public ActionResult Mostrar_Crear()
        {
            return View("/Views/Frutos/Mostrar_Crear.cshtml");
        }
        public ActionResult Mostrar_Modificar(string id)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from frutos where id_fruto = '" + id + "'";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "Fruto encontrado";
            if (dr.Read())
            {
                ViewBag.id_fruto = dr["id_fruto"].ToString();
                ViewBag.tipo_fruto = dr["tipo_fruto"].ToString();
                return View("/Views/Frutos/Mostrar_Modificar.cshtml");
            }

            con.Close();
            ViewBag.mensage = mensaje;

            return RedirectToAction("Consultar");
        }
        public ActionResult Eliminar(string id)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "delete from frutos where id_fruto = @id_fruto";
            sentencia.Parameters.Add(new SqlParameter("id_fruto", id));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "USUARIO ELIMINADO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return RedirectToAction("Consultar");

        }

        public ActionResult Agregar(int id_fruto, string fruto)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "insert into frutos (id_fruto,tipo_fruto) values (@id_fruto, @tipo_fruto)";
            sentencia.Parameters.Add(new SqlParameter("id_fruto", id_fruto));
            sentencia.Parameters.Add(new SqlParameter("tipo_fruto",fruto));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "REGISTRO GRABADO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return RedirectToAction("Consultar");


        }
        public ActionResult Modificar(int id_fruto, string tipo_fruto)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "update frutos set tipo_fruto = @tipo_fruto where id_fruto = @id_fruto";
            sentencia.Parameters.Add(new SqlParameter("id_fruto", id_fruto));
            sentencia.Parameters.Add(new SqlParameter("tipo_fruto", tipo_fruto));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "REGISTRO MODIFICADO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return RedirectToAction("Consultar");
        }

    }
}