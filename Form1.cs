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
        static readonly Point nullpoint = new Point (-1, -1);
        Point start = nullpoint;
        Point end = nullpoint;
        string startname = "";
        string endname = "";
        static string target = "";
        string state = "";
        Graphics line;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            line = CreateGraphics();
            //add the buttons to the flow layout panel
            component_flowLayoutPanel.Controls.Add(resistor_btn);
            component_flowLayoutPanel.Controls.Add(battery_btn);
            component_flowLayoutPanel.Controls.Add(LED_btn);
            component_flowLayoutPanel.Controls.Add(switch_btn);
            component_flowLayoutPanel.Controls.Add(joint_btn);
        }

        //button handlers
        private void resistor_btn_Click(object sender, EventArgs e)
        {
            state = "";
            updatebuttons();
            makebox(Color.Green, "resistor", 35, 20, 0, 0, 500, 2);
        }

        private void battery_btn_Click(object sender, EventArgs e)
        {
            state = "";
            updatebuttons();
            makebox(Color.Yellow, "battery", 35, 35, 1.5, 0, 0, 2);
        }

        private void LED_btn_Click(object sender, EventArgs e)
        {
            state = "";
            updatebuttons();
            makebox(Color.LightYellow, "LED", 35, 35, 0.5, 0, 10 , 2);
        }
        private void switch_btn_Click(object sender, EventArgs e)
        {
            state = "";
            updatebuttons();
            makebox(Color.Blue, "switch", 35, 35, 0, 0, 0, 2);
        }

        private void joint_btn_Click(object sender, EventArgs e)
        {
            state = "";
            updatebuttons();
            makebox(Color.Black, "joint", 8, 8, 0, 0, 0, double.PositiveInfinity);
        }

        public void makebox (Color colour, string name,int x, int y, double v, double c, double r, double n)
        {
            //creates component and picturebox in the circuit
            //then returns the picturebox and adds the picture box to form
            this.Controls.Add(circuit.addelement(colour, name, x, y, v, c, r, n));
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

            if (start == nullpoint)
            {
                //sets start to center of picture box
                start = temp.Location + new Size(temp.Width / 2, temp.Height / 2);
                startname = temp.Name;
                if (circuit.get(startname).numconnections <= circuit.numaccour(startname))
                {
                    MessageBox.Show("you can't connect from this component,\nit already has the maximum number of connectiongs it can have");
                    start = nullpoint;
                    startname = "";
                    return;
                }
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
                if (circuit.get(endname).numconnections <= circuit.numaccour(endname))
                {
                    MessageBox.Show("you can't connect to this component,\nit already has the maximum number of connectiongs it can have");
                    end = nullpoint;
                    endname = "";
                    return;
                }
                //checks if the 2 elements are already connected
                if (circuit.connections.Contains(new Tuple<string, string>(startname, endname)) || circuit.connections.Contains(new Tuple<string, string>(endname, startname)))
                {
                    System.Console.WriteLine("already exists");
                    start = nullpoint;
                    startname = "";
                    end = nullpoint;
                    endname = "";
                    return;
                } 
                else
                {
                    //adds the connection and draws the line
                    circuit.addconnection(startname, endname);
                    draw_line(start, end);
                    //clears start and end points
                    start = nullpoint;
                    startname = "";
                    end = nullpoint;
                    endname = "";
                }  
            }
        }

        private void disconnect_btn_Click(object sender, EventArgs e)
        {
            if (state != "disconnecting")
            {
                if (circuit.connections.Count < 1)
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
                circuit.removeconnection(startname, endname);
                startname = "";
                endname = "";
            }
            MouseButtons b = new MouseButtons();
            MouseEventArgs t = new MouseEventArgs(b, 1, 0, 0, 0);
            refreshline(sender, t);
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
            circuit.connections.RemoveAll(containelement);
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

        private void simulate_btn_Click(object sender, EventArgs e)
        {
            state = "";
            updatebuttons();

            int[,] adj = circuit.genadjacency();
            for (int a = 0; a < circuit.elements.Count; a++)
            {
                for (int b = 0; b < circuit.elements.Count; b++)
                {
                    Console.Write(adj[a,b] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            int[,] tree = circuit.gentree(adj);
            for (int a = 0; a < circuit.elements.Count; a++)
            {
                for (int b = 0; b < circuit.elements.Count; b++)
                {
                    Console.Write(tree[a, b] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            int[,] temp = circuit.findloops(adj, tree);

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
            foreach (Tuple<string, string> connection in circuit.connections)
            {
                Component start = circuit.elements.Find(x => x.name == connection.Item1);
                Component end = circuit.elements.Find(x => x.name == connection.Item2);
                draw_line(start.box.Location + new Size(start.box.Width / 2, start.box.Height / 2), end.box.Location + new Size(end.box.Width / 2, end.box.Height / 2));
            }
        }
    }
}
