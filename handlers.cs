using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
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

        public void resistor(string name)
        {
            string input = Interaction.InputBox("change resistance", "input", "500");
            try
            {
                //get new resistance value
                temp.get(name).resistance = Convert.ToDouble(input);
                System.Console.WriteLine("resistance is now " + temp.get(name).resistance);
            }
            catch
            {
                MessageBox.Show("invalid input");
            }
        }

        public void Switch(string name)
        {
            if(temp.get(name).box.BackColor == Color.Blue)
            {
                //replace with images later
                temp.get(name).box.BackColor = Color.Red;
            }
            else
            {
                //replace with images later
                temp.get(name).box.BackColor = Color.Blue;
            }
        }

    }
}
