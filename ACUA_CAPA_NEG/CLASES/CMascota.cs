using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class CMascota
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idCmas, idMas, idCli, consumible;
        public string cFecha;
        public CMascota()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CMASCOTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idCmas", idCmas);
            comando.Parameters.AddWithValue("@idMas", idMas);
            comando.Parameters.AddWithValue("@idCli", idCli);
            comando.Parameters.AddWithValue("@consumible", consumible);
            comando.Parameters.AddWithValue("@cFecha", cFecha);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El Consumo de la Mascota se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CMASCOTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idCmas", idCmas);
            comando.Parameters.AddWithValue("@idMas", idMas);
            comando.Parameters.AddWithValue("@idCli", idCli);
            comando.Parameters.AddWithValue("@consumible", consumible);
            comando.Parameters.AddWithValue("@cFecha", cFecha);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El Consumo de la Mascota se ha actualizado correctamente";
            return mensaje;
        }

        public string Eliminar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CMASCOTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idCmas", idCmas);
            comando.Parameters.AddWithValue("@idMas", idMas);
            comando.Parameters.AddWithValue("@idCli", idCli);
            comando.Parameters.AddWithValue("@consumible", consumible);
            comando.Parameters.AddWithValue("@cFecha", cFecha);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El Consumo de la Mascota se ha eliminado correctamente";
            return mensaje;
        }
    }
}
