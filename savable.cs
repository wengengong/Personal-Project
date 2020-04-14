using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_project
{
    class savable
    {
        public List<elemebt_object> elements = new List<elemebt_object>();
        public List<Tuple<string, string>> connections = new List<Tuple<string, string>>();
        public int element_counter;
    }
}
