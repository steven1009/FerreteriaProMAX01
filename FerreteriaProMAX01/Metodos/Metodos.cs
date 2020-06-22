using FerreteriaProMAX01.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FerreteriaProMAX01.Metodos
{
    public class Metodos
    {
        private string conn = "Data Source=DESKTOP-48V98DF;integrated Security=sspi;initial catalog=FERRETERIADB;";
        public int USUARIO_LOGINL(String usuario, String contraseña)
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("UserPassword", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@usuario", usuario);
            testCMD.Parameters.AddWithValue("@password", contraseña);
            var r = 0;
            if(testCMD.ExecuteScalar()==null)
            {
                return r;
            }
            r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
        public int BuscarProd(int id_Producto)
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("BuscarProducto", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@idProducto", id_Producto);
            var r = 0;
            if (testCMD.ExecuteScalar() == null)
            {
                return r;
            }
            r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
        public List<Persona> Get(String nombre)
        {
            DataTable dt = new DataTable();
            using (SqlConnection PubsConn = new SqlConnection(conn))
            {
                SqlCommand testCMD = new SqlCommand("BuscarNombre", PubsConn);
                PubsConn.Open();
                testCMD.CommandType = CommandType.StoredProcedure;
                testCMD.Parameters.AddWithValue("@nombre", nombre);
                using (var da = new SqlDataAdapter(testCMD))
                {
                    da.Fill(dt);
                }
                var persona = from item in dt.AsEnumerable()
                              select new Persona
                              {
                                Cedula = Convert.ToString(item["Cedula"]),
                                nombre = Convert.ToString(item["Nombre"]),
                                Primer_Apellido = Convert.ToString(item["Primer_Apellido"]),
                                Codigo = Convert.ToInt32(item["Codigo"]),
                              };
                return persona.ToList();
            }
        }
    }
}