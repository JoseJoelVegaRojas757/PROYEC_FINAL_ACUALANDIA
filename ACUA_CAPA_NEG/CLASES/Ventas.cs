using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Ventas
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idV, idTrabajador, idCliente;
        public string fVenta, MetodoP, Estado;
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
            comando.Parameters.AddWithValue("@idV", idV);
            comando.Parameters.AddWithValue("@idCli", idCliente);
            comando.Parameters.AddWithValue("@idTra", idTrabajador);
            comando.Parameters.AddWithValue("@Fecha_Venta", fVenta);
            comando.Parameters.AddWithValue("@Metodo_Pago", MetodoP);
            comando.Parameters.AddWithValue("@Total", total);
            comando.Parameters.AddWithValue("@Estado", Estado);
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
            comando.Parameters.AddWithValue("@idV", idV);
            comando.Parameters.AddWithValue("@idCli", idCliente);
            comando.Parameters.AddWithValue("@idTra", idTrabajador);
            comando.Parameters.AddWithValue("@Fecha_Venta", fVenta);
            comando.Parameters.AddWithValue("@Metodo_Pago", MetodoP);
            comando.Parameters.AddWithValue("@Total", total);
            comando.Parameters.AddWithValue("@Estado", Estado);
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
            comando.Parameters.AddWithValue("@idV", idV);
            comando.Parameters.AddWithValue("@idCli", idCliente);
            comando.Parameters.AddWithValue("@idTra", idTrabajador);
            comando.Parameters.AddWithValue("@Fecha_Venta", fVenta);
            comando.Parameters.AddWithValue("@Metodo_Pago", MetodoP);
            comando.Parameters.AddWithValue("@Total", total);
            comando.Parameters.AddWithValue("@Estado", Estado);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "La Venta se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
