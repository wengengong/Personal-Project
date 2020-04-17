using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_project
{
    class handlers
    {
        circuit temp;
        public handlers(ref circuit c)
        {
            temp = c;
        }
        public void resistor (string name)
        {
            MessageBox.Show("works");

        }

    }
}
