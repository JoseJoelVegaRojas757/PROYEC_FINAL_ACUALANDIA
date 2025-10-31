using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Categoria
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int Id;
        public string Nombre;
        public Categoria()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CATEGORIA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idCat", Id);
            comando.Parameters.AddWithValue("@nomCat", Nombre);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "La categoria se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CATEGORIA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idCat", Id);
            comando.Parameters.AddWithValue("@nomCat", Nombre);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "La categoria se ha actualizado correctamente";
            return mensaje;

        }

        public string Eliminar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CATEGORIA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@OP", 3);
            comando.Parameters.AddWithValue("@idCat", Id);
            comando.Parameters.AddWithValue("@nomCat", Nombre);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "La categoria se ha Eliminado correctamente";
            return mensaje;
        }


    }
}
