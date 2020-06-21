using System;
using System.Data;
using System.Data.SqlClient;

namespace FerreteriaProMAX01.Metodos
{
    public class Metodos
    {
        private string conn = "Data Source=DESKTOP-FKU2C7A;integrated Security=sspi;initial catalog=FERRETERIADB;";
        public int USUARIO_LOGINL(String usuario, String contraseña)
        {
            DataTable dt = new DataTable();
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
    }
}