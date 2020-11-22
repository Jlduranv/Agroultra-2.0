using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace EVALUACION_2_TP
{
    public class BD
    {
        public SqlConnection Conexion()
        {
            //conexion Pablo
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pablosotosaavedra\source\repos\Jlduranv\Agroultra-2.0\bdd_agro.mdf;Integrated Security=True;Connect Timeout=30");
            //conexion Emilio
            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //conexion Cintia
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\bdd_agroultra (1)\bdd.mdf;Integrated Security=True;Connect Timeout=30");
            //jose luis
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\bdd_agroultra\bdd.mdf");
            return con;
        }

    }
}