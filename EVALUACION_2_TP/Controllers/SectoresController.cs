using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace EVALUACION_2_TP.Controllers
{
    public class SectoresController : Controller
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
            sentencia.CommandText = "select * from sectores";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "<table class='table' border = 3 bgcolor = 'ebbbbb' width = '570' ><tr bgcolor = '975d72' >";

            mensaje = mensaje + "<td> ID SECTORES <td> NOMBRE SECTOR <td> ACCIONES";
            while (dr.Read())
            {

                mensaje = mensaje + "<tr><td>" + dr["Id_sectores"].ToString();
                mensaje = mensaje + "<td>" + dr["nombre"].ToString();
                mensaje = mensaje + "<td><a href='/Sectores/Mostrar_Modificar/" + dr["Id_sectores"].ToString() + "'>Modificar </a>";
                mensaje = mensaje + "<a href = '/Sectores/Eliminar/" + dr["Id_sectores"].ToString() + "'onclick='return confirm(\"Estas seguro?\")'> Eliminar</a>";

            }
            mensaje = mensaje + "</td></tr></table>";
            ViewBag.lista = mensaje;
            con.Close();
            return View("/Views/Sectores/Consultar.cshtml");
        }
        public ActionResult Mostrar_Crear()
        {
            return View("/Views/Sectores/Mostrar_Crear.cshtml");
        }
        public ActionResult Mostrar_Modificar(string id)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from sectores where Id_sectores = '" + id + "'";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "Sector encontrado";
            if (dr.Read())
            {
                ViewBag.Id_sectores = dr["Id_sectores"].ToString();
                ViewBag.nombre = dr["nombre"].ToString();
                return View("/Views/Sectores/Mostrar_Modificar.cshtml");
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
            sentencia.CommandText = "delete from sectores where Id_sectores = @Id_sectores";
            sentencia.Parameters.Add(new SqlParameter("Id_sectores", id));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "SECTOR ELIMINADO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return RedirectToAction("Consultar");

        }

        public ActionResult Agregar(int Id_sectores, string nombre)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "insert into sectores (Id_sectores,nombre) values (@Id_sectores, @nombre)";
            sentencia.Parameters.Add(new SqlParameter("Id_sectores", Id_sectores));
            sentencia.Parameters.Add(new SqlParameter("nombre",nombre));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "SECTOR GRABADO";
            }
            else
            {
                mensaje = "ERROR";
            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return RedirectToAction("Consultar");


        }
        public ActionResult Modificar(int Id_sectores, string nombre)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "update sectores set nombre = @nombre where Id_sectores = @Id_sectores";
            sentencia.Parameters.Add(new SqlParameter("Id_sectores", Id_sectores));
            sentencia.Parameters.Add(new SqlParameter("nombre", nombre));
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "SECTOR MODIFICADO";
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