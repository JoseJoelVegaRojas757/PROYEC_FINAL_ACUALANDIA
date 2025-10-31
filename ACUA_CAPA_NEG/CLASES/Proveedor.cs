using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Proveedor
    {

        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idProv;
        public string nomProveedor, telOficina, correo;

        public Proveedor()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PROVEEDOR";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idProv", idProv);
            comando.Parameters.AddWithValue("@nomProveedor", nomProveedor);
            comando.Parameters.AddWithValue("@telOficina", telOficina);
            comando.Parameters.AddWithValue("@correo", correo);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "El Proveedor se ha guardado correctamente";
            return msj;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PROVEEDOR";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idProv", idProv);
            comando.Parameters.AddWithValue("@nomProveedor", nomProveedor);
            comando.Parameters.AddWithValue("@telOficina", telOficina);
            comando.Parameters.AddWithValue("@correo", correo);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Proveedor se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CINTERNO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idProv", idProv);
            comando.Parameters.AddWithValue("@nomProveedor", nomProveedor);
            comando.Parameters.AddWithValue("@telOficina", telOficina);
            comando.Parameters.AddWithValue("@correo", correo);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Proveedor se ha Eliminado correctamente";
            con.Close();
            return msj;
        }


    }
}
