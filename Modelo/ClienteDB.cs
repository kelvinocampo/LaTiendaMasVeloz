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
    public class ClienteDB : ConexionMYSQL
    {
        public DataTable GetClientes()
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            DataTable dataTable = new DataTable();
            cmd.CommandText = "ObtenerClientes";
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            dataTable.Load(dr);
            return dataTable;
        }

        public Cliente GetCliente(int ID)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "ObtenerCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ID", ID);

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read()) // Verifica si hay resultados
                {
                    Cliente cliente = new Cliente
                    {
                        Doc = dr.GetInt32("Documento"),
                        email = dr.GetString("Correo"),
                        phone = dr.GetString("Telefono"),
                        name = dr.GetString("Nombre"),
                        address = dr.GetString("Direccion")
                    };
                    return cliente;
                }
            }
            return null; // Retorna null si no se encuentra el cliente
        }

        public void DeleteCliente(int ID)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "EliminarCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ID", ID);
            MySqlDataReader dr = cmd.ExecuteReader();
        }

        public void Update(int ID, Cliente cliente)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "EditarCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_Doc", cliente.Doc);
            cmd.Parameters.AddWithValue("@_email", cliente.email);
            cmd.Parameters.AddWithValue("@_phone", cliente.phone);
            cmd.Parameters.AddWithValue("@_name", cliente.name);
            cmd.Parameters.AddWithValue("@_address", cliente.address);
            cmd.Parameters.AddWithValue("@_ID", ID);
            MySqlDataReader dr = cmd.ExecuteReader();
        }

        public void Create( Cliente cliente)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "CrearCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_Doc", cliente.Doc);
            cmd.Parameters.AddWithValue("@_email", cliente.email);
            cmd.Parameters.AddWithValue("@_phone", cliente.phone);
            cmd.Parameters.AddWithValue("@_name", cliente.name);
            cmd.Parameters.AddWithValue("@_address", cliente.address);
            MySqlDataReader dr = cmd.ExecuteReader();
        }
    }
}
