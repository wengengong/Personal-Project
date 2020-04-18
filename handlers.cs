using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
            string input = Interaction.InputBox("change resistance", "input", "500");
            try
            {
                temp.get(name).resistance = Convert.ToDouble(input);
                System.Console.WriteLine("resistance is now " + temp.get(name).resistance);
            }
            catch
            {
                MessageBox.Show("invalid input");
            }
        }
    }
}
