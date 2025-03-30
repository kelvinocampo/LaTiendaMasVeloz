using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entities
{
    public class Producto
    {
        public int stock { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public DateTime creationDate { get; set; }
    }
}
