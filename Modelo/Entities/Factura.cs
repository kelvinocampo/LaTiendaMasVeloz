using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modelo.Entities
{
    public class Detalle
    {
        public string type { get; set; }
        public int productID { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
    public class Factura
    {
        public object worker { get; set; }
        public string type { get; set; }
        public object entity { get; set; }
        public DateTime creationDate { get; set; }
    }
}
