using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Abono
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();


        public int idAbono, idApartado;
        public string Monto;

        public Abono()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ABONO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idAbono", idAbono);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@monto", Monto);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El abono del Producto se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ABONO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idAbono", idAbono);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@monto", Monto);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El abono del Producto se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_ABONO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@OP", 3);
            comando.Parameters.AddWithValue("@idAbono", idAbono);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@monto", Monto);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El abono del Producto se ha Eliminado correctamente";
            con.Close();
            return msj;
        }

    }
}
