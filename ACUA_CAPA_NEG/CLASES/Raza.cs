using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Raza
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idRaza, idTipo;
        public string nomRaza;
        public Raza()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_RAZA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idRaza", idRaza);
            comando.Parameters.AddWithValue("@idTipo", idTipo);
            comando.Parameters.AddWithValue("@nomRaza", nomRaza);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "La Raza se ha guardado correctamente";
            return msj;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_RAZA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idRaza", idRaza);
            comando.Parameters.AddWithValue("@idTipo", idTipo);
            comando.Parameters.AddWithValue("@nomRaza", nomRaza);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "La Raza se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_RAZA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idRaza", idRaza);
            comando.Parameters.AddWithValue("@idTipo", idTipo);
            comando.Parameters.AddWithValue("@nomRaza", nomRaza);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "La Raza se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
