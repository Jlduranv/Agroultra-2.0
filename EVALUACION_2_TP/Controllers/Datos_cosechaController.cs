using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace EVALUACION_2_TP.Controllers
{
    public class Datos_cosechaController : Controller
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
            sentencia.CommandText = "select * from datos_cosecha";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "<table class='table' border = 3 bgcolor = '7AFF7A' width = '570'><tr bgcolor = '00CC0A' >";
           
            mensaje = mensaje + "<td> RUT <td> KILOS <td> FECHA <td> HORA <td> FRUTO <td>ACCIONES";
            while (dr.Read())
            {

                mensaje = mensaje + "<tr><td>" + dr["rut"].ToString();
                mensaje = mensaje + "<td>" + dr["kilos"].ToString();
                mensaje = mensaje + "<td>" + dr["fecha"].ToString();
                mensaje = mensaje + "<td>" + dr["hora"].ToString();
                mensaje = mensaje + "<td>" + dr["tipo_fruto"].ToString();
                mensaje = mensaje + "<td><a href='/Datos_cosecha/Mostrar_Modificar/" + dr["rut"].ToString() + "'>Modificar </a>";
                mensaje = mensaje + "<a href = '/Datos_cosecha/Eliminar/" + dr["rut"].ToString() + "'onclick='return confirm(\"Estas seguro?\")'> Eliminar</a>";

            }
            mensaje = mensaje + "</td></tr></table>";
            ViewBag.lista = mensaje;
            con.Close();
            return View("/Views/Datos_cosecha/Consultar.cshtml");
        }
        public ActionResult Mostrar_Crear()
        {
            return View("/Views/Datos_cosecha/Mostrar_Crear.cshtml");
        }
        public ActionResult Mostrar_Modificar(string id)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from datos_cosecha where rut = '" + id + "'";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "Usuario encontrado";
            if (dr.Read())
            {
                ViewBag.rut = dr["rut"].ToString();
                ViewBag.kilos = dr["kilos"].ToString();
                ViewBag.fecha = dr["fecha"].ToString();
                ViewBag.hora = dr["hora"].ToString();
                ViewBag.fruto = dr["tipo_fruto"].ToString();
                return View("/Views/Datos_cosecha/Mostrar_Modificar.cshtml");
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
            sentencia.CommandText = "delete from datos_cosecha where rut = @rut";
            sentencia.Parameters.Add(new SqlParameter("rut", id));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "DATO ELIMINADO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return RedirectToAction("Consultar");

        }

        public ActionResult Agregar(string rut, string kilos, string fecha, string hora, string fruto)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "insert into datos_cosecha (rut, kilos, fecha, hora, tipo_fruto) values (@rut, @kilos, @fecha, @hora, @fruto)";
            sentencia.Parameters.Add(new SqlParameter("rut", rut));
            sentencia.Parameters.Add(new SqlParameter("kilos", kilos));
            sentencia.Parameters.Add(new SqlParameter("fecha", fecha));
            sentencia.Parameters.Add(new SqlParameter("hora", hora));
            sentencia.Parameters.Add(new SqlParameter("fruto", fruto));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "DATO GRABADO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return RedirectToAction("Consultar");


        }
        public ActionResult Modificar(string rut, string kilos, string fecha, string hora, string fruto)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "update datos_cosecha set kilos = @kilos, fecha = @fecha, hora = @hora, tipo_fruto = @fruto where rut = @rut";
            sentencia.Parameters.Add(new SqlParameter("rut", rut));
            sentencia.Parameters.Add(new SqlParameter("kilos", kilos));
            sentencia.Parameters.Add(new SqlParameter("fecha", fecha));
            sentencia.Parameters.Add(new SqlParameter("hora", hora));
            sentencia.Parameters.Add(new SqlParameter("fruto", fruto));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "DATO MODIFICADO";
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