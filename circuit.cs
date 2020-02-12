using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DraggableControls;

namespace personal_project
{
    class circuit 
    {
        public List<Component> elements = new List<Component>();
        public List<Tuple<string, string>> connections = new List<Tuple<string, string>>();
        int element_counter = 0;

        public PictureBox addelement(Color colour, string name, int x, int y, double v, double c, double r, double n)
        {
            PictureBox temp = new PictureBox();
            temp.SizeMode = PictureBoxSizeMode.StretchImage;
            temp.ClientSize = new Size(x, y);
            temp.Location = new Point(100, 40);
            temp.BackColor = colour;
            temp.Name = name + element_counter;
            element_counter++;
            temp.Visible = true;
            temp.Draggable(true);
            //test.Image = Image.FromFile("images\\resistor.jpg");    add images later, replace colour with image file
            //creates the resistor object
            Component element = new Component(temp.Name, v, c, r, n, temp, name);
            elements.Add(element);
            return temp;
        }
        public Component get(string name)
        {
            return elements.Find(x => x.name == name);
        }

        public void addconnection(string start, string end)
        {
            //adds the connection to the list
            connections.Add(new Tuple<string, string>(start, end));
        }

        public void removeconnection(string start, string end)
        {
            //removes the connection from the list
            connections.Remove(new Tuple<string, string>(start, end));
            connections.Remove(new Tuple<string, string>(end, start));
        }

        public double numaccour(string name)
        {
            double numaccour = 0;
            foreach (Tuple<string, string> c in connections)
            {
                if (c.Item1 == name || c.Item2 == name)
                {
                    numaccour++;
                }
            }
            return numaccour;
        }
    }
}
