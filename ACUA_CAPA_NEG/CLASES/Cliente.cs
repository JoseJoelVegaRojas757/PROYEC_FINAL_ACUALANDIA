using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Cliente
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idCli, idDom;
        public string Nombre, Paterno, Materno, Telefono, RSociales, Nacimiento;

        public Cliente()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CLIENTE";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idCli", idCli);
            comando.Parameters.AddWithValue("@idDom", idDom);
            comando.Parameters.AddWithValue("@cli_Nombre", Nombre);
            comando.Parameters.AddWithValue("@cli_Paterno", Paterno);
            comando.Parameters.AddWithValue("@cli_Materno", Materno);
            comando.Parameters.AddWithValue("@cli_Tel", Telefono);
            comando.Parameters.AddWithValue("@cli_Sociales", RSociales);
            comando.Parameters.AddWithValue("@cli_Nacimiento", Nacimiento);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "El Cliente se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CLIENTE";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idCli", idCli);
            comando.Parameters.AddWithValue("@idDom", idDom);
            comando.Parameters.AddWithValue("@cli_Nombre", Nombre);
            comando.Parameters.AddWithValue("@cli_Paterno", Paterno);
            comando.Parameters.AddWithValue("@cli_Materno", Materno);
            comando.Parameters.AddWithValue("@cli_Tel", Telefono);
            comando.Parameters.AddWithValue("@cli_Sociales", RSociales);
            comando.Parameters.AddWithValue("@cli_Nacimiento", Nacimiento);
            comando.Connection = con;
            con.Open();
            msj = "El Cliente se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CLIENTE";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idCli", idCli);
            comando.Parameters.AddWithValue("@idDom", idDom);
            comando.Parameters.AddWithValue("@cli_Nombre", Nombre);
            comando.Parameters.AddWithValue("@cli_Paterno", Paterno);
            comando.Parameters.AddWithValue("@cli_Materno", Materno);
            comando.Parameters.AddWithValue("@cli_Tel", Telefono);
            comando.Parameters.AddWithValue("@cli_Sociales", RSociales);
            comando.Parameters.AddWithValue("@cli_Nacimiento", Nacimiento);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Cliente se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }

}
