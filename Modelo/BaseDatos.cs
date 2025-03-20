using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Modelo.Entities;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class BaseDatos : ConexionMYSQL
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

        public void DeleteCliente(int Doc)
        {
            MySqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "EliminarCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@doc_cliente", Doc);
            MySqlDataReader dr = cmd.ExecuteReader();
        }
    }
}