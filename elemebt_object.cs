using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace personal_project
{
    class elemebt_object
    {
        public string name { get; set; }
        public double voltage { get; set; }
        public double current { get; set; }
        public double resistance { get; set; }
        public double numconnections { get; set; }
        public string type { get; set; }
        public string box_name { get; set; }
        public Color colour { get; set; }
        public int width { get; set; }
        public int hight { get; set; }
        public Point location { get; set; }

    }
}
