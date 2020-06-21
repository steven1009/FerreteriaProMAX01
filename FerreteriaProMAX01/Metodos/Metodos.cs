using System;
using System.Data;
using System.Data.SqlClient;

namespace FerreteriaProMAX01.Metodos
{
    public class Metodos
    {
        public int USUARIO_LOGINL(String usuario, String contraseña)
        {
            DataTable dt = new DataTable();
            SqlConnection PubsConn = new SqlConnection("Data Source=DESKTOP-48V98DF;integrated Security=sspi;initial catalog=FERRETERIADB;");
            SqlCommand testCMD = new SqlCommand("UserPassword", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@usuario", usuario);
            testCMD.Parameters.AddWithValue("@password", contraseña);
            var r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
    }
}