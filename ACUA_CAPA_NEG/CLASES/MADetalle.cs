using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class MADetalle
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idAdetalle, idApartado, idMascota, cantidad;
        public decimal precio, anticipo, subtotal;

        public MADetalle()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_MADETALLE";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idAdetalle", idAdetalle);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@idMascota", idMascota);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@anticipo", anticipo);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
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
            comando.CommandText = "SP_MADETALLE";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idAdetalle", idAdetalle);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@idMascota", idMascota);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@anticipo", anticipo);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;
            con.Open();
            msj = "La mascota ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_MADETALLE";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idAdetalle", idAdetalle);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@idMascota", idMascota);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@anticipo", anticipo);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "La mascota se ha Eliminado correctamente";
            con.Close();
            return msj;
        }


    }
}
