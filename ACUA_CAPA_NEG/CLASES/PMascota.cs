using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class PMascota
    {

        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idPmas, idPed, idMas, cantidad;
        public decimal precio, subtotal;

        public PMascota()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PMASCOTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idPmas", idPmas);
            comando.Parameters.AddWithValue("@idPed", idPed);
            comando.Parameters.AddWithValue("@idMas", idPmas);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El pedido se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PMASCOTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idPmas", idPmas);
            comando.Parameters.AddWithValue("@idPed", idPed);
            comando.Parameters.AddWithValue("@idMas", idPmas);
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
            comando.CommandText = "SP_PMASCOTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idPmas", idPmas);
            comando.Parameters.AddWithValue("@idPed", idPed);
            comando.Parameters.AddWithValue("@idMas", idPmas);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@subtotal", subtotal);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Paquete se ha eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}