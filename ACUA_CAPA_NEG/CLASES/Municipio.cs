using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Municipio
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idMun;
        public string nombre;

        public Municipio()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_MUNICIPIO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idMun", idMun);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El municipio se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_MUNICIPIO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idMun", idMun);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Connection = con;
            con.Open();
            msj = "El abono del Producto se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_MUNICIPIO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idMun", idMun);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El municipio se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
