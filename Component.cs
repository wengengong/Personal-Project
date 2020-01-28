using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_project
{
    class Component : circuit_element
    {
        public double voltage { get; set; }
        public double current { get; set; }
        public double resistance { get; set; }

        public Component()
        {
            voltage = 0;
            current = 0;
            resistance = 0;
        }
    }
}
