using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Apartado
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();


        public int idApartado, idTrabajador, idCliente, anticipo, faltante, total;
        public string fApartado;

        public Apartado()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_APARTADO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@idTrabajador", idTrabajador);
            comando.Parameters.AddWithValue("@idCliente", idCliente);
            comando.Parameters.AddWithValue("@fApartado", fApartado);
            comando.Parameters.AddWithValue("@anticipo", anticipo);
            comando.Parameters.AddWithValue("@faltante", faltante);
            comando.Parameters.AddWithValue("@total,", total);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El apartado se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_APARTADO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@idTrabajador", idTrabajador);
            comando.Parameters.AddWithValue("@idCliente", idCliente);
            comando.Parameters.AddWithValue("@fApartado", fApartado);
            comando.Parameters.AddWithValue("@anticipo", anticipo);
            comando.Parameters.AddWithValue("@faltante", faltante);
            comando.Parameters.AddWithValue("@total,", total);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El apartado se ha actualizado correctamente";
            return mensaje;
        }

        public string Eliminar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_APARTADO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idApartado", idApartado);
            comando.Parameters.AddWithValue("@idTrabajador", idTrabajador);
            comando.Parameters.AddWithValue("@idCliente", idCliente);
            comando.Parameters.AddWithValue("@fApartado", fApartado);
            comando.Parameters.AddWithValue("@anticipo", anticipo);
            comando.Parameters.AddWithValue("@faltante", faltante);
            comando.Parameters.AddWithValue("@total,", total);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El apartado se ha guardado correctamente";
            return mensaje;
        }

    }
}
