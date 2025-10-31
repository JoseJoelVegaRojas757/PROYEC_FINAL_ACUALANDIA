using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Mascota
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idMas, idRaza;
        public string caracteristicas;

        public Mascota()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_MASCOTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idMas", idMas);
            comando.Parameters.AddWithValue("@caracteristicas", caracteristicas);
            comando.Parameters.AddWithValue("@idRaza", idRaza);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "La Mascota se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_MASCOTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idMas", idMas);
            comando.Parameters.AddWithValue("@caracteristicas", caracteristicas);
            comando.Parameters.AddWithValue("@idRaza", idRaza);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "La Mascota se ha actualizado correctamente";

            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_MASCOTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idMas", idMas);
            comando.Parameters.AddWithValue("@caracteristicas", caracteristicas);
            comando.Parameters.AddWithValue("@idRaza", idRaza);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "La Mascota se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
