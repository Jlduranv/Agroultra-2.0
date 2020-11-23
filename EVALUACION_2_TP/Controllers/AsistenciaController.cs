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
            var mensaje = "<table class='table' border = 3 bgcolor = 'ebbbbb' width = '570' ><tr bgcolor = '975d72' >";

            mensaje = mensaje + "<td> ID Asistencia <td> Hora de entrada <td> Hora de salida <td> Acciones";
            while (dr.Read())
            {

                mensaje = mensaje + "<tr><td>" + dr["id_asistencia"].ToString();
                mensaje = mensaje + "<td>" + dr["hora_entrada"].ToString();
                mensaje = mensaje + "<td>" + dr["hora_salida"].ToString();
                mensaje = mensaje + "<td><a href='/Asistencia/Mostrar_Modificar/" + dr["id_asistencia"].ToString() + "'>Modificar </a>";
                mensaje = mensaje + "<a href = '/Asistencia/Eliminar/" + dr["id_asistencia"].ToString() + "'onclick='return confirm(\"Estas seguro?\")'> Eliminar</a>";

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
            sentencia.CommandText = "select * from asistencia where id_asistencia = '" + id + "'";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "Asistencia encontrada";
            if (dr.Read())
            {
                ViewBag.id_asistencia = dr["id_asistencia"].ToString();
                ViewBag.hora_entrada = dr["hora_entrada"].ToString();
                ViewBag.hora_fecha = dr["hora_salida"].ToString();
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
            sentencia.CommandText = "delete from asistencia where id_asistencia = @id_asistencia";
            sentencia.Parameters.Add(new SqlParameter("id_asistencia", id));
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

        public ActionResult Agregar(int id_asistencia, string hora_entrada, string hora_salida)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "insert into asistencia (id_asistencia, hora_entrada, hora_salida) values (@id_asistencia, @hora_entrada, @hora_salida)";
            sentencia.Parameters.Add(new SqlParameter("id_asistencia", id_asistencia));
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
        public ActionResult Modificar(int id_asistencia, string hora_entrada, string hora_salida)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "update asistencia set hora_entrada = @hora_entrada, hora_salida = @hora_salida where id_asistencia = @id_asistencia";
            sentencia.Parameters.Add(new SqlParameter("id_asistencia", id_asistencia));
            sentencia.Parameters.Add(new SqlParameter("hora_entrada", hora_entrada));
            sentencia.Parameters.Add(new SqlParameter("hora_salida",hora_salida));
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