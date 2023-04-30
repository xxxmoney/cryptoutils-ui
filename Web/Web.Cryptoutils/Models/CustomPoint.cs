using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Cryptoutils.Models
{
    public struct CustomPoint
    {
        public string X;
        public string Y;

        public CustomPoint(string x, string y)
        {
            X = x;
            Y = y;
        }
    }
}
