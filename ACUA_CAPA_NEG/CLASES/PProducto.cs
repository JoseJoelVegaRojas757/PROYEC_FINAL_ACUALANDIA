using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class PProducto
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idPprod, idPed, idProd, cantidad;
        public decimal precio, subtotal;

        public PProducto()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PPRODUCTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idPprod", idPprod);
            comando.Parameters.AddWithValue("@idPed", idPed);
            comando.Parameters.AddWithValue("@idProd", idProd);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "El pedido se ha guardado correctamente";
            return msj;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PPRODUCTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idPprod", idPprod);
            comando.Parameters.AddWithValue("@idPed", idPed);
            comando.Parameters.AddWithValue("@idProd", idProd);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;

            con.Open();
            msj = "El Pedido se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PPRODUCTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idPprod", idPprod);
            comando.Parameters.AddWithValue("@idPed", idPed);
            comando.Parameters.AddWithValue("@idProd", idProd);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Pedido se ha eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
