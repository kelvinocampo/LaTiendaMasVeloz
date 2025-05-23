﻿using System;
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
        public DataTable GetAll()
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            DataTable dataTable = new DataTable();
            cmd.CommandText = "ObtenerUsuarios";
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            dataTable.Load(dr);
            return dataTable;
        }

        public Usuario Get(int ID)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "ObtenerUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ID", ID);

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read()) // Verifica si hay resultados
                {
                    Usuario usuario = new Usuario
                    {
                        Doc = dr.GetInt32("Documento"),
                        email = dr.GetString("Correo"),
                        phone = dr.GetString("Telefono"),
                        name = dr.GetString("Nombre"),
                        address = dr.GetString("Direccion"),
                        role = dr.GetString("Rol")
                    };
                    return usuario;
                }
            }
            return null; // Retorna null si no se encuentra el usuario
        }

        public void Delete(int ID)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "EliminarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ID", ID);
            MySqlDataReader dr = cmd.ExecuteReader();
        }

        public void Update(int ID, Usuario usuario)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "EditarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_Doc", usuario.Doc);
            cmd.Parameters.AddWithValue("@_email", usuario.email);
            cmd.Parameters.AddWithValue("@_phone", usuario.phone);
            cmd.Parameters.AddWithValue("@_name", usuario.name);
            cmd.Parameters.AddWithValue("@_address", usuario.address);
            cmd.Parameters.AddWithValue("@_role", usuario.role);
            cmd.Parameters.AddWithValue("@_ID", ID);
            MySqlDataReader dr = cmd.ExecuteReader();
        }

        public void Create(Usuario usuario)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "CrearUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_Doc", usuario.Doc);
            cmd.Parameters.AddWithValue("@_email", usuario.email);
            cmd.Parameters.AddWithValue("@_phone", usuario.phone);
            cmd.Parameters.AddWithValue("@_name", usuario.name);
            cmd.Parameters.AddWithValue("@_role", usuario.role);
            cmd.Parameters.AddWithValue("@_address", usuario.address);
            MySqlDataReader dr = cmd.ExecuteReader();
        }
    }
}
