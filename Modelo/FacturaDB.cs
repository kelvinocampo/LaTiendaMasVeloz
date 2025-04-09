using System;
using System.Data;
using MySql.Data.MySqlClient;
using Modelo.Entities;

namespace Modelo
{
    public class FacturaDB : ConexionMYSQL
    {
        public Factura Get(int ID, string type)
        {
            using (var connection = GetConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "ObtenerFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_ID", ID);
                cmd.Parameters.AddWithValue("@_type", type);

                string entityType = type == "IN" ? "Proveedor" : "Cliente";

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Factura
                        {
                            worker = dr.GetString("Trabajador"),
                            entity = dr.GetString(entityType),
                            creationDate = dr.GetDateTime("Fecha_Creacion"),
                            type = dr.GetString("type")
                        };
                    }
                }
            }
            return null; // Retorna null si no se encuentra la factura
        }

        public DataTable GetAll(int ID, string type)
        {
            using (var connection = GetConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                DataTable dataTable = new DataTable();
                cmd.CommandText = "ObtenerDetallesFactura";
                cmd.Parameters.AddWithValue("@_ID", ID);
                cmd.Parameters.AddWithValue("@_type", type);
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    dataTable.Load(dr);
                }
                return dataTable;
            }
        }

        public int Create(Factura factura)
        {
            using (var connection = GetConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "CrearFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_type", factura.type);
                cmd.Parameters.AddWithValue("@_entityID", factura.entity); // Asegúrate de que sea del tipo correcto
                cmd.Parameters.AddWithValue("@_creationDate", factura.creationDate);
                cmd.Parameters.AddWithValue("@_workerID", factura.worker); // Asegúrate de que sea del tipo correcto

                int lastInsertId = 0;
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        lastInsertId = dr.GetInt32("ID");
                    }
                }

                return lastInsertId;
            }
        }

        public void CreateDetail(int billID, Detalle detalle)
        {
            using (var connection = GetConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "CrearDetalleFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_type", detalle.type);
                cmd.Parameters.AddWithValue("@_billID", billID);
                cmd.Parameters.AddWithValue("@_productID", detalle.productID);
                cmd.Parameters.AddWithValue("@_quantity", detalle.quantity);
                cmd.Parameters.AddWithValue("@_price", detalle.price);
                cmd.ExecuteNonQuery();
            }
        }
    }
}