using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_project
{
    class Component : circuit_element
    {
        public double voltage { get; set; }
        public double current { get; set; }
        public double resistance { get; set; }

        public PictureBox image;

        public Component(double voltage, double current, double resistance, PictureBox image)
        {
            this.voltage = voltage;
            this.current = current;
            this.resistance = resistance;
            this.image = image;
        }


    }
}
