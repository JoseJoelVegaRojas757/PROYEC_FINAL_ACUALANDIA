using System.Data;
using System.Data.SqlClient;

namespace ACUA_CAPA_NEG.CLASES
{
    public class Producto
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idProd, idCat;
        public string codigo, nomProducto;
        public decimal pCompra, ivaCompra, pVenta, ivaVenta, pOferta;
        public bool oferta, estatus;

        public Producto()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PRODUCTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idProd", idProd);
            comando.Parameters.AddWithValue("@idCat", idCat);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@nomProducto", nomProducto);
            comando.Parameters.AddWithValue("@pCompra", pCompra);
            comando.Parameters.AddWithValue("@ivaCompra", ivaCompra);
            comando.Parameters.AddWithValue("@pVenta", pVenta);
            comando.Parameters.AddWithValue("@ivaVenta", ivaVenta);
            comando.Parameters.AddWithValue("@oferta", oferta);
            comando.Parameters.AddWithValue("@pOferta", pOferta);
            comando.Parameters.AddWithValue("@estatus", estatus);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "El Producto se ha guardado correctamente";
            return msj;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PRODUCTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idProd", idProd);
            comando.Parameters.AddWithValue("@idCat", idCat);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@nomProducto", nomProducto);
            comando.Parameters.AddWithValue("@pCompra", pCompra);
            comando.Parameters.AddWithValue("@ivaCompra", ivaCompra);
            comando.Parameters.AddWithValue("@pVenta", pVenta);
            comando.Parameters.AddWithValue("@ivaVenta", ivaVenta);
            comando.Parameters.AddWithValue("@oferta", oferta);
            comando.Parameters.AddWithValue("@pOferta", pOferta);
            comando.Parameters.AddWithValue("@estatus", estatus);
            comando.Connection = con;

            con.Open();
            msj = "El Producto se ha actualizado correctamente";
            con.Close();
            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PRODUCTO";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idProd", idProd);
            comando.Parameters.AddWithValue("@idCat", idCat);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@nomProducto", nomProducto);
            comando.Parameters.AddWithValue("@pCompra", pCompra);
            comando.Parameters.AddWithValue("@ivaCompra", ivaCompra);
            comando.Parameters.AddWithValue("@pVenta", pVenta);
            comando.Parameters.AddWithValue("@ivaVenta", ivaVenta);
            comando.Parameters.AddWithValue("@oferta", oferta);
            comando.Parameters.AddWithValue("@pOferta", pOferta);
            comando.Parameters.AddWithValue("@estatus", estatus);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            msj = "El Producto se ha Eliminado correctamente";
            con.Close();
            return msj;
        }
    }
}
