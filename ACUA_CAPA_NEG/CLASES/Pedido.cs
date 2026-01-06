using System;
using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Pedido
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idPed, idTrans;
        public DateTime fPedido, fEntrega; 
        public string estado; 
        public decimal total;


        public Pedido()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PEDIDO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@OP", 1);
            comando.Parameters.AddWithValue("@idPed", idPed); 
            comando.Parameters.AddWithValue("@idTrans", idTrans);
            comando.Parameters.AddWithValue("@fPedido", fPedido);
            comando.Parameters.AddWithValue("@fEntrega", fEntrega);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@total", total);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "Pedido guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string mensaje = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PEDIDO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@OP", 1);
            comando.Parameters.AddWithValue("@idPed", idPed); 
            comando.Parameters.AddWithValue("@idTrans", idTrans);
            comando.Parameters.AddWithValue("@fPedido", fPedido);
            comando.Parameters.AddWithValue("@fEntrega", fEntrega);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@total", total);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "Pedido guardado correctamente";
            return mensaje;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PEDIDO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@OP", 3);
            comando.Parameters.AddWithValue("@idPed", idPed);
            comando.Parameters.AddWithValue("@idTrans", idTrans);
            comando.Parameters.AddWithValue("@fPedido", fPedido);
            comando.Parameters.AddWithValue("@fEntrega", fEntrega);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@total", total);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            msj = "Pedido eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
