using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Ventas
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idVenta, idTra, idCliente, idPaq;
        public string fVenta;
        public bool tipo, estado;
        public decimal total;

        public Ventas()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_VENTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idVenta", idVenta);
            comando.Parameters.AddWithValue("@fVenta", fVenta);
            comando.Parameters.AddWithValue("@idTra", idTra);
            comando.Parameters.AddWithValue("@idCli", idCliente);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@idPaq", idPaq);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@total", total);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "La Venta se ha guardado correctamente";
            return msj;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_VENTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idVenta", idVenta);
            comando.Parameters.AddWithValue("@fVenta", fVenta);
            comando.Parameters.AddWithValue("@idTra", idTra);
            comando.Parameters.AddWithValue("@idCli", idCliente);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@idPaq", idPaq);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@total", total);
            comando.Connection = con;
            con.Open();
            msj = "La Venta ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_VENTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idVenta", idVenta);
            comando.Parameters.AddWithValue("@fVenta", fVenta);
            comando.Parameters.AddWithValue("@idTra", idTra);
            comando.Parameters.AddWithValue("@idCli", idCliente);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@idPaq", idPaq);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@total", total);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El tipo se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
