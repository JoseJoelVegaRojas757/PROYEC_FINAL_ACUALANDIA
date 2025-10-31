using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class InvProducto
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idInv, idProd, existencia, idProv, minimo;

        public InvProducto()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_INVPRODUCTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idInv", idInv);
            comando.Parameters.AddWithValue("@idProd", idProd);
            comando.Parameters.AddWithValue("@existencia", existencia);
            comando.Parameters.AddWithValue("@idProv", idProv);
            comando.Parameters.AddWithValue("@minimo", minimo);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El Inventario se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_INVPRODUCTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idInv", idInv);
            comando.Parameters.AddWithValue("@idProd", idProd);
            comando.Parameters.AddWithValue("@existencia", existencia);
            comando.Parameters.AddWithValue("@idProv", idProv);
            comando.Parameters.AddWithValue("@minimo", minimo);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Inventario se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_INVPRODUCTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idInv", idInv);
            comando.Parameters.AddWithValue("@idProd", idProd);
            comando.Parameters.AddWithValue("@existencia", existencia);
            comando.Parameters.AddWithValue("@idProv", idProv);
            comando.Parameters.AddWithValue("@minimo", minimo);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Inventario se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
