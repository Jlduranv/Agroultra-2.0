using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace EVALUACION_2_TP.Controllers
{
    public class AsistenciaController : Controller
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
            sentencia.CommandText = "select * from asistencia";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "<table class='table' border = 3 bgcolor = '7AFF7A' width = '570'><tr bgcolor = '00CC0A' >";

            mensaje = mensaje + "<td> Rut <td> Hora de entrada <td> Hora de salida <td> Acciones";
            while (dr.Read())
            {

                mensaje = mensaje + "<tr><td>" + dr["rut"].ToString();
                mensaje = mensaje + "<td>" + dr["hora_entrada"].ToString();
                mensaje = mensaje + "<td>" + dr["hora_salida"].ToString();
                mensaje = mensaje + "<td><a href='/Asistencia/Mostrar_Modificar/" + dr["rut"].ToString() + "'>Modificar </a>";
                mensaje = mensaje + "<a href = '/Asistencia/Eliminar/" + dr["rut"].ToString() + "'onclick='return confirm(\"Estas seguro?\")'> Eliminar</a>";

            }
            mensaje = mensaje + "</td></tr></table>";
            ViewBag.lista = mensaje;
            con.Close();
            return View("/Views/Asistencia/Consultar.cshtml");
        }
        public ActionResult Mostrar_Crear()
        {
            return View("/Views/Asistencia/Mostrar_Crear.cshtml");
        }
        public ActionResult Mostrar_Modificar(string id)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from asistencia where rut = '" + id + "'";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "Asistencia encontrada";
            if (dr.Read())
            {
                ViewBag.rut = dr["rut"].ToString();
                ViewBag.hora_entrada = dr["hora_entrada"].ToString();
                ViewBag.hora_salida = dr["hora_salida"].ToString();
                return View("/Views/Asistencia/Mostrar_Modificar.cshtml");
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
            sentencia.CommandText = "delete from asistencia where rut = @rut";
            sentencia.Parameters.Add(new SqlParameter("rut", id));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "ASISTENCIA ELIMINADO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return RedirectToAction("Consultar");

        }

        public ActionResult Agregar(string rut, string hora_entrada, string hora_salida)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "insert into asistencia (rut, hora_entrada, hora_salida) values (@rut, @hora_entrada, @hora_salida)";
            sentencia.Parameters.Add(new SqlParameter("rut", rut));
            sentencia.Parameters.Add(new SqlParameter("hora_entrada", hora_entrada));
            sentencia.Parameters.Add(new SqlParameter("hora_salida", hora_salida));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "ASISTENCIA GRABADO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return RedirectToAction("Consultar");


        }
        public ActionResult Modificar(string rut, string hora_entrada, string hora_salida)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "update asistencia set hora_entrada = @hora_entrada, hora_salida = @hora_salida where rut = @rut";
            sentencia.Parameters.Add(new SqlParameter("rut", rut));
            sentencia.Parameters.Add(new SqlParameter("hora_entrada", hora_entrada));
            sentencia.Parameters.Add(new SqlParameter("hora_salida", hora_salida));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "ASISTENCIA MODIFICADO";
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