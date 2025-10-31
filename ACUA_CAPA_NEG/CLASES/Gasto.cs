using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Gasto
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int id, monto;
        public string descripcion;
        public Gasto()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_GASTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@monto", monto);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El gasto se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_GASTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@monto", monto);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El gasto se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_GASTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@monto", monto);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El gasto se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
