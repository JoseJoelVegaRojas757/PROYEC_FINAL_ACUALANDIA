using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Trabajador
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idTra, traDom, idPuesto;
        public string traNombre, traPaterno, traMaterno, traTel, traNacimiento, traSociales;
        public Trabajador()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_TRABAJADOR";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idTra", idTra);
            comando.Parameters.AddWithValue("@traNombre", traNombre);
            comando.Parameters.AddWithValue("@traPaterno", traPaterno);
            comando.Parameters.AddWithValue("@traMaterno", traMaterno);
            comando.Parameters.AddWithValue("@traDom", traDom);
            comando.Parameters.AddWithValue("@traTel", traTel);
            comando.Parameters.AddWithValue("@idPuesto", idPuesto);
            comando.Parameters.AddWithValue("@traNacimiento", traNacimiento);
            comando.Parameters.AddWithValue("@traSociales", traSociales);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "El Trabajador se ha guardado correctamente";
            return msj;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_TRABAJADOR";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idTra", idTra);
            comando.Parameters.AddWithValue("@traNombre", traNombre);
            comando.Parameters.AddWithValue("@traPaterno", traPaterno);
            comando.Parameters.AddWithValue("@traMaterno", traMaterno);
            comando.Parameters.AddWithValue("@traDom", traDom);
            comando.Parameters.AddWithValue("@traTel", traTel);
            comando.Parameters.AddWithValue("@idPuesto", idPuesto);
            comando.Parameters.AddWithValue("@traNacimiento", traNacimiento);
            comando.Parameters.AddWithValue("@traSociales", traSociales);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Trabajador se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_TRABAJADOR";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idTra", idTra);
            comando.Parameters.AddWithValue("@traNombre", traNombre);
            comando.Parameters.AddWithValue("@traPaterno", traPaterno);
            comando.Parameters.AddWithValue("@traMaterno", traMaterno);
            comando.Parameters.AddWithValue("@traDom", traDom);
            comando.Parameters.AddWithValue("@traTel", traTel);
            comando.Parameters.AddWithValue("@idPuesto", idPuesto);
            comando.Parameters.AddWithValue("@traNacimiento", traNacimiento);
            comando.Parameters.AddWithValue("@traSociales", traSociales);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Trabajador se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
