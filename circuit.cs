using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_project
{
    class circuit 
    {
        public List<Component> elements = new List<Component>();

        public void add(Component e)
        {
            elements.Add(e);
        }
        public Component get(string name)
        {
            return elements.Find(x => x.name == name);
        }
    }
}
