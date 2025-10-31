using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Domicilio
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idDom, numEx, numInt, idCol;
        public string calle, calle1, calle2, referencias;

        public Domicilio()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_DOMICILIO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idDom", idDom);
            comando.Parameters.AddWithValue("@calle", calle);
            comando.Parameters.AddWithValue("@calle1", calle1);
            comando.Parameters.AddWithValue("@calle2", calle2);
            comando.Parameters.AddWithValue("@numExterior", numEx);
            comando.Parameters.AddWithValue("@numInterior", numInt);
            comando.Parameters.AddWithValue("@idCol", idCol);
            comando.Parameters.AddWithValue("@referencias", referencias);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El Domicilio se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_DOMICILIO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idDom", idDom);
            comando.Parameters.AddWithValue("@calle", calle);
            comando.Parameters.AddWithValue("@calle1", calle1);
            comando.Parameters.AddWithValue("@calle2", calle2);
            comando.Parameters.AddWithValue("@numExterior", numEx);
            comando.Parameters.AddWithValue("@numInterior", numInt);
            comando.Parameters.AddWithValue("@idCol", idCol);
            comando.Parameters.AddWithValue("@referencias", referencias);
            comando.Connection = con;
            con.Open();
            msj = "El Domicilio se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_DOMICILIO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idDom", idDom);
            comando.Parameters.AddWithValue("@calle", calle);
            comando.Parameters.AddWithValue("@calle1", calle1);
            comando.Parameters.AddWithValue("@calle2", calle2);
            comando.Parameters.AddWithValue("@numExterior", numEx);
            comando.Parameters.AddWithValue("@numInterior", numInt);
            comando.Parameters.AddWithValue("@idCol", idCol);
            comando.Parameters.AddWithValue("@referencias", referencias);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "La Colonia se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
