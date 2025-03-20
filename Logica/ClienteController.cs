using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Modelo.Entities;

namespace Logica
{
    public class ClienteController
    {
        public DataTable GetAll()
        {
            BaseDatos baseDatos = new BaseDatos();
            DataTable dataTable = new DataTable();
            dataTable=baseDatos.GetClientes();
            return dataTable;
        }

        public void Delete(int Doc)
        {
            BaseDatos baseDatos = new BaseDatos();
            baseDatos.DeleteCliente(Doc);
        }
    }
}
