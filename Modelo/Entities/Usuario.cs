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
    public class Usuario
    {
        public int Doc { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string role { get; set; }

    }
}
