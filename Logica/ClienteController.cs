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
            ClienteDB clienteDB = new ClienteDB();
            DataTable dataTable = new DataTable();
            dataTable= clienteDB.GetClientes();
            return dataTable;
        }

        public void Delete(int ID)
        {
            ClienteDB clienteDB = new ClienteDB();
            clienteDB.DeleteCliente(ID);
        }

        public void Update(int ID, int Doc, string email, string phone, string name, string address)
        {
            ClienteDB clienteDB = new ClienteDB();
            Cliente cliente = new Cliente();
            cliente.Doc = Doc;
            cliente.email = email;
            cliente.phone = phone;
            cliente.name = name;
            cliente.address = address;
            clienteDB.Update(ID, cliente);
        }
        public void Create( int Doc, string email, string phone, string name, string address)
        {
            ClienteDB clienteDB = new ClienteDB();
            Cliente cliente = new Cliente();
            cliente.Doc = Doc;
            cliente.email = email;
            cliente.phone = phone;
            cliente.name = name;
            cliente.address = address;
            clienteDB.Create(cliente);
        }
    }
}
