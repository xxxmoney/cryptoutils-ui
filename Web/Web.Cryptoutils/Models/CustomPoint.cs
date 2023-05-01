using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Models
{
    public struct CustomPoint
    {
        public string X { get; set; }
        public string Y { get; set; }

        public CustomPoint(string x, string y)
        {
            X = x;
            Y = y;
        }
    }
}
