using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Entities;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class ProductoDB : ConexionMYSQL
    {
        public DataTable GetAll()
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            DataTable dataTable = new DataTable();
            cmd.CommandText = "ObtenerProductos";
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            dataTable.Load(dr);
            return dataTable;
        }

        public Producto Get(int ID)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "ObtenerProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ID", ID);

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read()) // Verifica si hay resultados
                {
                    Producto producto = new Producto
                    {
                        name = dr.GetString("Nombre"),
                        creationDate = dr.GetDateTime("Fecha_Creacion"),
                        price = dr.GetInt32("Precio"),
                        stock = dr.GetInt32("Cantidad")
                    };

                    return producto;
                }
            }
            return null; // Retorna null si no se encuentra el usuario
        }

        public void Delete(int ID)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "EliminarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ID", ID);
            MySqlDataReader dr = cmd.ExecuteReader();
        }

        public void Update(int ID, Producto producto)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "EditarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_price", producto.price);
            cmd.Parameters.AddWithValue("@_stock", producto.stock);
            cmd.Parameters.AddWithValue("@_creationDate", producto.creationDate);
            cmd.Parameters.AddWithValue("@_name", producto.name);
            cmd.Parameters.AddWithValue("@_ID", ID);
            MySqlDataReader dr = cmd.ExecuteReader();
        }

        public void Create(Producto producto)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "CrearProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_price", producto.price);
            cmd.Parameters.AddWithValue("@_stock", producto.stock);
            cmd.Parameters.AddWithValue("@_creationDate", producto.creationDate);
            cmd.Parameters.AddWithValue("@_name", producto.name);
            MySqlDataReader dr = cmd.ExecuteReader();
        }
    }
}
