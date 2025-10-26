using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Herramientas
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public Herramientas()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public int consecutivo(string campo, string tabla)
        {
            int id = 0;
            string consulta = $"\r\nSELECT isnull(MAX({campo})+1,1) AS MAXID FROM {tabla}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader lector = cmd.ExecuteReader();
            if (lector.Read())
            {
                id = int.Parse(lector["MAXID"].ToString());
            }
            con.Close();
            return id;
        }
    }
}
