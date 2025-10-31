using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class PADetalle
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idAdetalle, idApartado, idProducto, cantidad;
        public decimal anticipo, precio, subtotal;

        public PADetalle()
        {
            con.ConnectionString = x.ConexionSql;
        }
        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PADETALLE";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idAdetalle", idAdetalle);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@idProducto", idProducto);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@anticipo", anticipo);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El Apartado del producto se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PADETALLE";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idAdetalle", idAdetalle);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@idProducto", idProducto);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@anticipo", anticipo);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Apartado del producto se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PADETALLE";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idAdetalle", idAdetalle);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@idProducto", idProducto);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@anticipo", anticipo);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Apartado del producto se ha eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
