using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_project
{
    class Component 
    {
        public string name { get; set; }
        public double voltage { get; set; }
        public double current { get; set; }
        public double resistance { get; set; }
        public string type { get; set; }

        public PictureBox box;

        public Component(string name,  double voltage, double current, double resistance, PictureBox image, string type)
        {
            this.name = name;
            this.voltage = voltage;
            this.current = current;
            this.resistance = resistance;
            this.box = image;
            this.type = type;
        }
    }
}
