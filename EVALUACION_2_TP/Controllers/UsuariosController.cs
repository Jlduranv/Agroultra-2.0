﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace EVALUACION_2_TP.Controllers
{
    public class UsuariosController : Controller
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
            sentencia.CommandText = "select * from usuarios";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "<table class='table' border = 3 bgcolor = '7AFF7A' width = '570'><tr bgcolor = '00CC0A' >";

            mensaje = mensaje + "<td> RUT <td> NOMBRE <td> APELLIDO <td> CODIGO <td> NIVEL <td> EMAIL <td>TELEFONO <td>CLAVE <td> ACCIONES";
            while (dr.Read())
            {

                mensaje = mensaje + "<tr><td>" + dr["rut"].ToString();
                mensaje = mensaje + "<td>" + dr["nombre"].ToString();
                mensaje = mensaje + "<td>" + dr["apellido"].ToString();
                mensaje = mensaje + "<td>" + dr["codigo"].ToString();
                mensaje = mensaje + "<td>" + dr["nivel"].ToString();
                mensaje = mensaje + "<td>" + dr["email"].ToString();
                mensaje = mensaje + "<td>" + dr["telefono"].ToString();
                mensaje = mensaje + "<td>" + dr["clave"].ToString();
                mensaje = mensaje + "<td><a href='/Usuarios/Mostrar_Modificar/" + dr["rut"].ToString() + "'>Modificar </a>";
                mensaje = mensaje + "<a href = '/Usuarios/Eliminar/" + dr["rut"].ToString() + "'onclick='return confirm(\"Estas seguro?\")'> Eliminar</a>";

            }
            mensaje = mensaje + "</td></tr></table>";
            ViewBag.lista = mensaje;
            con.Close();
            return View("/Views/Usuarios/Consultar.cshtml");
        }
        public ActionResult Mostrar_Crear()
        {
            return View("/Views/Usuarios/Mostrar_Crear.cshtml");
        }
        public ActionResult Mostrar_Modificar(string id)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from usuarios where rut = '" + id + "'";
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "Usuario encontrado";
            if (dr.Read())
            {
                ViewBag.rut = dr["rut"].ToString();
                ViewBag.nombre = dr["nombre"].ToString();
                ViewBag.apellido = dr["apellido"].ToString();
                ViewBag.codigo = dr["codigo"].ToString();
                ViewBag.nivel = dr["nivel"].ToString();
                ViewBag.email = dr["email"].ToString();
                ViewBag.telefono = dr["telefono"].ToString();
                ViewBag.clave = dr["clave"].ToString();
                return View("/Views/Usuarios/Mostrar_Modificar.cshtml");
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
            sentencia.CommandText = "delete from usuarios where rut = @rut";
            sentencia.Parameters.Add(new SqlParameter("rut", id));
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

        public ActionResult Agregar(string rut, string nombre, string apellido, string codigo, int nivel, string email, string telefono, string clave)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "insert into usuarios (rut,nombre, apellido, codigo, nivel, email, telefono, clave) values (@rut, @nombre, @apellido, @codigo, @nivel, @email, @telefono, @clave)";
            sentencia.Parameters.Add(new SqlParameter("rut", rut));
            sentencia.Parameters.Add(new SqlParameter("nombre", nombre));
            sentencia.Parameters.Add(new SqlParameter("apellido", apellido));
            sentencia.Parameters.Add(new SqlParameter("codigo", codigo));
            sentencia.Parameters.Add(new SqlParameter("nivel", nivel));
            sentencia.Parameters.Add(new SqlParameter("email", email));
            sentencia.Parameters.Add(new SqlParameter("telefono", telefono));
            sentencia.Parameters.Add(new SqlParameter("clave", clave));
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
        public ActionResult Modificar(string rut, string nombre, string apellido, string codigo, int nivel, string email, string telefono, string clave)
        {
            SqlConnection con = new BD().Conexion();
            var sentencia = new SqlCommand();
            sentencia.Connection = con;
            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            sentencia.CommandText = "update usuarios set nombre = @nombre, apellido = @apellido, codigo = @codigo, nivel = @nivel, email = @email, telefono = @telefono, clave = @clave where rut = @rut";
            sentencia.Parameters.Add(new SqlParameter("rut", rut));
            sentencia.Parameters.Add(new SqlParameter("nombre", nombre));
            sentencia.Parameters.Add(new SqlParameter("apellido", apellido));
            sentencia.Parameters.Add(new SqlParameter("codigo", codigo));
            sentencia.Parameters.Add(new SqlParameter("nivel", nivel));
            sentencia.Parameters.Add(new SqlParameter("email", email));
            sentencia.Parameters.Add(new SqlParameter("telefono", telefono));
            sentencia.Parameters.Add(new SqlParameter("clave", clave));
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