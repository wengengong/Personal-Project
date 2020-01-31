using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DraggableControls;

namespace personal_project
{
    public partial class Form1 : Form
    {
        //globle veriables
        circuit circuit = new circuit();
        int element_counter = 0;
        Point start = new Point (-1,-1);
        Point end = new Point(-1, -1);
        string startname = "";
        string endname = "";
        Graphics line;
        bool connect = false;
        List<Tuple<string, string>> connections = new List<Tuple<string, string>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            line = CreateGraphics();
        }

        private void resistor_btn_Click(object sender, EventArgs e)
        {
            //creates a picture box for the resistor
            PictureBox temp = new PictureBox();
            temp.SizeMode = PictureBoxSizeMode.StretchImage;
            temp.ClientSize = new Size(35, 35);
            temp.Location = new Point(50, 50);
            temp.BackColor = Color.Green;
            temp.Name = "resistor" + element_counter;
            element_counter++;
            temp.Visible = true;
            temp.Draggable(true);
            //test.Image = Image.FromFile("images\\resistor.jpg");    add images later
            //creates the resistor object
            Component element = new Component(temp.Name, 0, 0, 100, temp, "resistor");
            //adds the resistor to the circuit model
            circuit.add(element);
            //adds the picture box to form
            this.Controls.Add(element.box);
        }

        private void connect_btn_Click(object sender, EventArgs e)
        {
            if (connect == false) 
            {
                if (circuit.elements.Count < 2)
                {
                    MessageBox.Show("There not enought elements to connect together");
                }
                else
                {
                    connect = true;
                    connect_btn.BackColor = Color.LightGreen;
                    //make the components non draggable and adds event handler for the picturebox
                    foreach (Component c in circuit.elements)
                    {
                        c.box.Draggable(false);
                        c.box.Click += new EventHandler(connecting);
                    }
                }
            }
            else
            {
                connect = false;
                connect_btn.BackColor = Color.Gainsboro;
                //makes dragable and removes event handler
                foreach (Component c in circuit.elements)
                {
                    c.box.Draggable(true);
                    c.box.Click -= new EventHandler(connecting);
                }
            }
        }

        private void connecting(object sender, EventArgs e)
        {
            PictureBox temp = (sender as PictureBox);
            Point nullpoint = new Point(-1, -1);

            if (start == nullpoint)
            {
                //sets start to center of picture box
                start = temp.Location + new Size(temp.Width / 2, temp.Height / 2);
                startname = temp.Name;
            }
            else if (temp.Location == start)
            {
                //remove start point if clicked again
                start = nullpoint;
                startname = "";
            } 
            else
            {
                //will need to check if the connection already exists

                //sets end and draws a line
                end = temp.Location + new Size(temp.Width / 2, temp.Height / 2);
                endname = temp.Name;
                addconnection(startname, endname);
                draw_line(start, end);
                //clears start and end points
                start = nullpoint;
                end = nullpoint;
            }
        }

        public void draw_line(Point start, Point end)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            line.DrawLine(pen, start.X, start.Y, start.X, end.Y);
            line.DrawLine(pen, start.X, end.Y, end.X, end.Y);
        }

        public void refreshline()
        {

        }

        public void addconnection(string start, string end)
        {
            //adds the connection to the list
            connections.Add(new Tuple<string, string>(start, end));
        }

        public void removeconnection(string start, string end)
        {
            //removes connection from the list
            Tuple<string, string> t = new Tuple<string, string>(start, end);
            connections.Remove(t);
        }
    }
}
