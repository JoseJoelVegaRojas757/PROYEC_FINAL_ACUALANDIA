using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Tipo
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idTipo;
        public string nomTipo;
        public Tipo()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_TIPO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idTipo", idTipo);
            comando.Parameters.AddWithValue("@nomTipo", nomTipo);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "El tipo se ha guardado correctamente";
            return msj;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_TIPO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idTipo", idTipo);
            comando.Parameters.AddWithValue("@nomTipo", nomTipo);
            comando.Connection = con;
            con.Open();
            msj = "El tipo se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_TIPO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idTipo", idTipo);
            comando.Parameters.AddWithValue("@nomTipo", nomTipo);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El tipo se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
