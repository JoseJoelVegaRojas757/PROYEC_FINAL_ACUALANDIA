using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUA_CAPA_NEG.CLASES
{
    public class VentaD
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idV, idTrabajador, idCliente;
        public string fVenta, MetodoP, Estado;
        public decimal total;

        public VentaD()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public int Guardar()
        {
            comando.Connection = con;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_VENTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idVenta", idV);
            comando.Parameters.AddWithValue("@idCli", idCliente);
            comando.Parameters.AddWithValue("@idTra", idTrabajador);
            comando.Parameters.AddWithValue("@fVenta", fVenta);
            comando.Parameters.AddWithValue("@MetodoP", MetodoP);
            comando.Parameters.AddWithValue("@Total", total);
            comando.Parameters.AddWithValue("@ESTADO", Estado);

            con.Open();
            // Capturamos el ID que arroja el SELECT @idVenta del SP corregido
            int idGenerado = Convert.ToInt32(comando.ExecuteScalar());
            con.Close();
            return idGenerado;
        }
        // NUEVO: Guardar cada producto en el detalle
        public void GuardarDetalle(int idVentaPadre, int idProducto, int cantidad, decimal precio)
        {
            SqlCommand cmdD = new SqlCommand();
            cmdD.Connection = con;
            cmdD.CommandType = CommandType.StoredProcedure;
            cmdD.CommandText = "SP_VENTA_DETALLE";
            cmdD.Parameters.AddWithValue("@idV", idVentaPadre);
            cmdD.Parameters.AddWithValue("@idProd", idProducto);
            cmdD.Parameters.AddWithValue("@Cantidad", cantidad);
            cmdD.Parameters.AddWithValue("@Precio_Unitario", precio);

            con.Open();
            cmdD.ExecuteNonQuery();
            con.Close();
        }
        public string Actualizar()
        {
            comando.Connection = con;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_VENTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1); // El SP usa op 1 para Insert/Update
            comando.Parameters.AddWithValue("@idVenta", idV);
            comando.Parameters.AddWithValue("@idCli", idCliente);
            comando.Parameters.AddWithValue("@idTra", idTrabajador);
            comando.Parameters.AddWithValue("@fVenta", fVenta);
            comando.Parameters.AddWithValue("@MetodoP", MetodoP);
            comando.Parameters.AddWithValue("@Total", total);
            comando.Parameters.AddWithValue("@ESTADO", Estado);

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            return "Venta actualizada correctamente";
        }
        public string Eliminar()
        {
            // IMPORTANTE: Antes de eliminar la Venta, hay que eliminar sus detalles
            comando.Connection = con;
            comando.CommandText = "DELETE FROM VENTA_DETALLE WHERE idV = @id; DELETE FROM VENTA WHERE idV = @id;";
            comando.CommandType = CommandType.Text;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@id", idV);

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            return "Venta y sus detalles eliminados";
        }

        public DataTable ListarDetalle(int idVenta)
        {
            DataTable tabla = new DataTable();
            comando.Connection = con;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT idProd, Cantidad, Precio_Unitario, Importe FROM VENTA_DETALLE WHERE idV = @id";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@id", idVenta);

            con.Open();
            SqlDataReader leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.Close();
            return tabla;
        }
    }
}
