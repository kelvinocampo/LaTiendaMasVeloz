using System;
using System.Data;
using Modelo.Entities;
using Modelo;

namespace Logica
{
    public class FacturaController
    {
        public DataTable GetAll(int ID, string type)
        {
            string cleanType = type == "Entrada" ? "IN" : "OUT";
            FacturaDB facturaDB = new FacturaDB();
            return facturaDB.GetAll(ID, cleanType);
        }

        public Factura Get(int ID, string type)
        {
            string cleanType = type == "Entrada" ? "IN" : "OUT";
            FacturaDB facturaDB = new FacturaDB();
            return facturaDB.Get(ID, cleanType);
        }

        public int Create(int workerID, DateTime creationDate, int entityID, string type)
        {
            FacturaDB facturaDB = new FacturaDB();
            string cleanType = type == "Entrada" ? "IN" : "OUT";
            Factura factura = new Factura
            {
                worker = workerID,
                creationDate = creationDate,
                entity = entityID,
                type = cleanType
            };
            return facturaDB.Create(factura);
        }

        public void CreateDetail(int billID, int price, int productID, int quantity, string type)
        {
            FacturaDB facturaDB = new FacturaDB();
            string cleanType = type == "Entrada" ? "IN" : "OUT";
            Detalle detalle = new Detalle
            {
                price = price,
                productID = productID,
                quantity = quantity,
                type = cleanType
            };
            facturaDB.CreateDetail(billID, detalle);
        }
    }
}