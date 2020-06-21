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
        private string conn = "Data Source=DESKTOP-FKU2C7A;integrated Security=sspi;initial catalog=FERRETERIADB;";
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
        public List<Persona> Get(String nombre)
        {
            DataTable dt = new DataTable();
            using (SqlConnection PubsConn = new SqlConnection(conn))
            {
                SqlCommand testCMD = new SqlCommand("UserPassword", PubsConn);
                PubsConn.Open();
                testCMD.CommandType = CommandType.StoredProcedure;
                testCMD.Parameters.AddWithValue("@usuario", nombre);
                var r = 0;
                using (var da = new SqlDataAdapter(testCMD))
                {
                    da.Fill(dt);
                }
                var persona = from item in dt.AsEnumerable()
                              select new Persona
                              {
                                idPersona = Convert.ToInt32(item["idPersona"])
                              };
                return persona.ToList();
            }
        }
    }
}