using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Entities;
using Modelo;
using System.Collections;

namespace Logica
{
    public class ProductoController
    {
        public DataTable GetAll()
        {
            ProductoDB productoDB = new ProductoDB();
            DataTable dataTable = new DataTable();
            dataTable = productoDB.GetAll();
            return dataTable;
        }

        public void Delete(int ID)
        {
            ProductoDB productoDB = new ProductoDB();
            productoDB.Delete(ID);
        }

        public void Update(int ID, string name, int price, int stock, DateTime creationDate)
        {
            ProductoDB productoDB = new ProductoDB();
            Producto producto = new Producto();
            producto.name = name;
            producto.price = price;
            producto.stock = stock;
            producto.creationDate = creationDate;

            bool productoExist = GetByID(ID);

            if (productoExist)
            {
                productoDB.Update(ID, producto);
            }
            else
            {
                Create(name, price, stock, creationDate);
            }
        }

        public bool GetByID(int ID)
        {
            ProductoDB productoDB = new ProductoDB();
            var producto = productoDB.Get(ID);

            if (producto == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Create(string name, int price, int stock, DateTime creationDate)
        {
            ProductoDB productoDB = new ProductoDB();
            Producto producto = new Producto();
            producto.name = name;
            producto.price = price;
            producto.stock = stock;
            producto.creationDate = creationDate;
            productoDB.Create(producto);
        }
    }
}