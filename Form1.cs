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
        static string target = "";
        Graphics line;
        string state = "";
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
            makebox(Color.Green, "resistor", 0, 0, 500);
        }

        private void battery_btn_Click(object sender, EventArgs e)
        {
            makebox(Color.Yellow, "battery", 1.5, 0, 0);
        }

        private void LED_btn_Click(object sender, EventArgs e)
        {
            makebox(Color.LightYellow, "LED", 0.5, 0, 10);
        }
        private void switch_btn_Click(object sender, EventArgs e)
        {
            makebox(Color.Blue, "switch", 0, 0, 0);
        }
        public void makebox (Color colour, string name, double v, double c, double r)
        {
            PictureBox temp = new PictureBox();
            temp.SizeMode = PictureBoxSizeMode.StretchImage;
            temp.ClientSize = new Size(35, 35);
            temp.Location = new Point(100, 40);
            temp.BackColor = colour;
            temp.Name = name + element_counter;
            element_counter++;
            temp.Visible = true;
            temp.Draggable(true);
            //test.Image = Image.FromFile("images\\resistor.jpg");    add images later
            //creates the resistor object
            Component element = new Component(temp.Name, v, c, r, temp, name);
            //adds the resistor to the circuit model
            circuit.add(element);
            //adds the picture box to form
            this.Controls.Add(element.box);
        }

        private void connect_btn_Click(object sender, EventArgs e)
        {
            if (state != "connecting") 
            {
                if (circuit.elements.Count < 2)
                {
                    MessageBox.Show("There not enought elements to connect together");
                }
                else
                {
                    state = "connecting";
                    updatebuttons();
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
                state = "";
                updatebuttons();
                //makes dragable and removes event handler
                foreach (Component c in circuit.elements)
                {
                    c.box.Draggable(true);
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
                //sets end and draws a line
                end = temp.Location + new Size(temp.Width / 2, temp.Height / 2);
                endname = temp.Name;
                //checks if the 2 elements are already connected
                if (connections.Contains(new Tuple<string, string>(startname, endname)) || connections.Contains(new Tuple<string, string>(endname, startname)))
                {
                    System.Console.WriteLine("already exists");
                } 
                else
                {
                    //adds the connection
                    addconnection(startname, endname);
                    draw_line(start, end);
                    //clears start and end points
                    start = nullpoint;
                    startname = "";
                    end = nullpoint;
                    endname = "";
                }  
            }
        }

        public void addconnection(string start, string end)
        {
            //adds the connection to the list
            connections.Add(new Tuple<string, string>(start, end));
        }

        private void disconnect_btn_Click(object sender, EventArgs e)
        {
            if (state != "disconnecting")
            {
                if (connections.Count < 1)
                {
                    MessageBox.Show("there are no connections to disconnect");
                }
                else
                {
                    state = "disconnecting";
                    updatebuttons();
                    foreach (Component c in circuit.elements)
                    {
                        c.box.Draggable(false);
                        c.box.Click += new EventHandler(disconnecting);
                    }
                }
            }
            else
            {
                state = "";
                updatebuttons();
                foreach (Component c in circuit.elements)
                {
                    c.box.Draggable(true);
                }
            }
        }

        public void disconnecting(object sender, EventArgs e)
        {
            PictureBox temp = (sender as PictureBox);
            Point nullpoint = new Point(-1, -1);

            if (startname == "")
            {
                startname = temp.Name;
            }
            else if (startname == temp.Name)
            {
                startname = "";
            }
            else
            {
                endname = temp.Name;
                removeconnection(startname, endname);
                startname = "";
                endname = "";
            }
            MouseButtons b = new MouseButtons();
            MouseEventArgs t = new MouseEventArgs(b, 1, 0, 0, 0);
            refreshline(sender, t);
        }

        public void removeconnection(string start, string end)
        {
            //removes the connection from the list
            connections.Remove(new Tuple<string, string>(start, end));
            connections.Remove(new Tuple<string, string>(end, start));
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            if (state != "removing")
            {
                if (circuit.elements.Count < 1)
                {
                    MessageBox.Show("there are no elements to remove");
                }
                else
                {
                    state = "removing";
                    updatebuttons();
                    foreach (Component c in circuit.elements)
                    {
                        c.box.Draggable(false);
                        c.box.Click += new EventHandler(removing);
                    }
                }
            } 
            else
            {
                state = "";
                updatebuttons();
                foreach (Component c in circuit.elements)
                {
                    c.box.Draggable(true);
                }
            }
        }

        public void removing(object sender, EventArgs e)
        {
            PictureBox temp = (sender as PictureBox);
            target = temp.Name;
            //remove from connections list 
            connections.RemoveAll(containelement);
            //remove from component list
            circuit.elements.RemoveAll(x => x.name == target);
            this.Controls.Remove(temp);
            //refresh the line
            MouseButtons b = new MouseButtons();
            MouseEventArgs t = new MouseEventArgs(b, 1, 0, 0, 0);
            refreshline(sender, t);
        }

        public static bool containelement(Tuple<string, string> t)
        {
            if (t.Item1 == target || t.Item2 == target)
            {
            return true;
            }
            else
            {
            return false;
            }
        }

        public void updatebuttons()
        {
            //clear all button colours
            connect_btn.BackColor = Color.Gainsboro;
            disconnect_btn.BackColor = Color.Gainsboro;
            remove_btn.BackColor = Color.Gainsboro;
            //update button colours if needed
            if(state == "connecting")
            {
                connect_btn.BackColor = Color.Green;
            }
            if (state == "disconnecting")
            {
                disconnect_btn.BackColor = Color.Red;
            }
            if (state == "removing")
            {
                remove_btn.BackColor = Color.Red;
            }
            //remove all handlers 
            foreach (Component c in circuit.elements)
            {
                c.box.Click -= new EventHandler(connecting);
                c.box.Click -= new EventHandler(disconnecting);
                c.box.Click -= new EventHandler(removing);
                c.box.MouseUp -= new MouseEventHandler(refreshline);
            }
            if (state == "")
            {
                foreach (Component c in circuit.elements)
                {
                    c.box.MouseUp += new MouseEventHandler(refreshline);
                }
            }
        }

        //draws a line connecting to lines
        public void draw_line(Point start, Point end)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            line.DrawLine(pen, start.X, start.Y, start.X, end.Y);
            line.DrawLine(pen, start.X, end.Y, end.X, end.Y);
        }

        //refresh lines
        public void refreshline(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //clears all the lines
            line.Clear(Color.White);
            //redraws all the lines 
            foreach (Tuple<string, string> connection in connections)
            {
                Component start = circuit.elements.Find(x => x.name == connection.Item1);
                Component end = circuit.elements.Find(x => x.name == connection.Item2);
                draw_line(start.box.Location + new Size(start.box.Width / 2, start.box.Height / 2), end.box.Location + new Size(end.box.Width / 2, end.box.Height / 2));
            }
        }
    }
}
