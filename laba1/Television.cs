using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    public class Television
    {
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Manufacturer { get; set; }
    }

    public class TelevisionCollection
    {
        public List<Television> Televisions { get; set; }

        public TelevisionCollection()
        {
            Televisions = new List<Television>();
        }
    }
}
