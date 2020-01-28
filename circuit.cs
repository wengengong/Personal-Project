using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_project
{
    class circuit 
    {
        private List<circuit_element> elements = new List<circuit_element>();

        public void add(circuit_element e)
        {
            elements.Add(e);
        }
        public circuit_element get(circuit_element e)
        {
            return elements[elements.IndexOf(e)];
        }
    }
}
