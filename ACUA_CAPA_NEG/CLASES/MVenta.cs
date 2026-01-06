using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUA_CAPA_NEG.CLASES
{
    public class MVenta
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public int idMas;
        public int mas_raza;
        public decimal pCompra;
        public string codigo;
        public decimal ivacompra;
        public decimal pventa;
        public decimal ivaventa;
        public decimal oferta;
        public decimal poferta;
        public int estatus;
        

        public MVenta()
        {
            con.ConnectionString = x.ConexionSql;
        }

        public string Guardar()
        {
            string mensaje = "";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "SP_MVENTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 1);
            comando.Parameters.AddWithValue("@idMas", idMas);
            comando.Parameters.AddWithValue("@mas_raza", mas_raza);
            comando.Parameters.AddWithValue("@pCompra", pCompra);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@mas_ivaCompra", ivacompra);
            comando.Parameters.AddWithValue("@pVenta", pventa);
            comando.Parameters.AddWithValue("@mas_ivaVenta", ivaventa);
            comando.Parameters.AddWithValue("@oferta", oferta);
            comando.Parameters.AddWithValue("@pOferta", poferta);
            comando.Parameters.AddWithValue("@estatus", estatus);
            comando.Connection = con;

            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            mensaje = "La Venta se ha guardado correctamente";
            return mensaje;
        }

        public string Actualizar()
        {
            string msj = "";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "SP_MVENTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 2);
            comando.Parameters.AddWithValue("@idMas", idMas);
            comando.Parameters.AddWithValue("@mas_raza", mas_raza);
            comando.Parameters.AddWithValue("@pCompra", pCompra);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@mas_ivaCompra", ivacompra);
            comando.Parameters.AddWithValue("@pVenta", pventa);
            comando.Parameters.AddWithValue("@mas_ivaVenta", ivaventa);
            comando.Parameters.AddWithValue("@oferta", oferta);
            comando.Parameters.AddWithValue("@pOferta", poferta);
            comando.Parameters.AddWithValue("@estatus", estatus);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "La Venta se ha actualizado correctamente";

            return msj;
        }

        public string Eliminar()
        {
            string msj = "";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "SP_MVENTA";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@op", 3);
            comando.Parameters.AddWithValue("@idMas", idMas);
            comando.Parameters.AddWithValue("@mas_raza", mas_raza);
            comando.Parameters.AddWithValue("@pCompra", pCompra);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@mas_ivaCompra", ivacompra);
            comando.Parameters.AddWithValue("@pVenta", pventa);
            comando.Parameters.AddWithValue("@mas_ivaVenta", ivaventa);
            comando.Parameters.AddWithValue("@oferta", oferta);
            comando.Parameters.AddWithValue("@pOferta", poferta);
            comando.Parameters.AddWithValue("@estatus", estatus);
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
            msj = "La Venta se ha eliminado correctamente";
            return msj;
        }



    }
}
