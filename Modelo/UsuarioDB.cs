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
    public class UsuarioDB : ConexionMYSQL
    {
        public DataTable GetClientes()
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            DataTable dataTable = new DataTable();
            cmd.CommandText = "ObtenerUsuarios";
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            dataTable.Load(dr);
            return dataTable;
        }

        public Usuario GetCliente(int ID)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "ObtenerUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ID", ID);

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read()) // Verifica si hay resultados
                {
                    Usuario cliente = new Usuario
                    {
                        Doc = dr.GetInt32("Documento"),
                        email = dr.GetString("Correo"),
                        phone = dr.GetString("Telefono"),
                        name = dr.GetString("Nombre"),
                        address = dr.GetString("Direccion"),
                        role = dr.GetString("Rol")
                    };
                    return cliente;
                }
            }
            return null; // Retorna null si no se encuentra el cliente
        }

        public void DeleteCliente(int ID)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "EliminarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ID", ID);
            MySqlDataReader dr = cmd.ExecuteReader();
        }

        public void Update(int ID, Usuario cliente)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "EditarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_Doc", cliente.Doc);
            cmd.Parameters.AddWithValue("@_email", cliente.email);
            cmd.Parameters.AddWithValue("@_phone", cliente.phone);
            cmd.Parameters.AddWithValue("@_name", cliente.name);
            cmd.Parameters.AddWithValue("@_address", cliente.address);
            cmd.Parameters.AddWithValue("@_role", cliente.role);
            cmd.Parameters.AddWithValue("@_ID", ID);
            MySqlDataReader dr = cmd.ExecuteReader();
        }

        public void Create( Usuario cliente)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "CrearUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_Doc", cliente.Doc);
            cmd.Parameters.AddWithValue("@_email", cliente.email);
            cmd.Parameters.AddWithValue("@_phone", cliente.phone);
            cmd.Parameters.AddWithValue("@_name", cliente.name);
            cmd.Parameters.AddWithValue("@_role", cliente.role);
            cmd.Parameters.AddWithValue("@_address", cliente.address);
            MySqlDataReader dr = cmd.ExecuteReader();
        }
    }
}
