using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using DraggableControls;
using Newtonsoft.Json;
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
        ToolTip t = new ToolTip();
        List<elemebt_object> buttons = new List<elemebt_object>();
        handlers handler;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //line graphic
            line = CreateGraphics();
            handler = new handlers(ref circuit);

            try
            {
                //import buttons
                using (StreamReader file = File.OpenText(@"buttons"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    buttons = (List<elemebt_object>)serializer.Deserialize(file, typeof(List<elemebt_object>));
                }
                foreach (elemebt_object elem in buttons)
                {
                    Button temp = new Button();
                    temp.Text = elem.name;
                    temp.Name = elem.name;
                    temp.Size = new Size(63, 22);
                    temp.BackColor = Color.Gainsboro;
                    temp.Click += new EventHandler(general_button_handler);
                    component_flowLayoutPanel.Controls.Add(temp);
                }
            }
            catch
            {
                MessageBox.Show("Failed to load buttons, check if there is a \"buttons\" file");
            }
        }

        //general button handler
        public void general_button_handler(object sender, EventArgs e)
        {
            Button temp = (sender as Button);
            state = "";
            updatebuttons();
            //find the button data
            elemebt_object data = buttons.Find(i => i.name == temp.Name);
            // make the component
            makebox(data.colour, data.name, data.width, data.hight, data.voltage, data.current, data.resistance, data.numconnections);
        }

        public void makebox (Color colour, string name,int x, int y, double v, double c, double r, double n)
        {
            //creates component and picturebox in the circuit
            //then returns the picturebox and adds the picture box to form
            PictureBox temp = circuit.addelement(colour, name, x, y, v, c, r, n);
            temp.DoubleClick += new EventHandler(add_handler);
            this.Controls.Add(temp);
        }

        public void add_handler(object sender, EventArgs e)
        {
            try
            {
                //if there is a handler method with the same name as the sender it will run it
                PictureBox temp = (sender as PictureBox);
                typeof(handlers).GetMethod(circuit.get(temp.Name).type).Invoke(handler, new object[] { temp.Name });
            }
            catch {}
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
            else if (temp.Location + new Size(temp.Width / 2, temp.Height / 2) == start)
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
                    System.Console.WriteLine("connection already exists");
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
            //cremove all existing tooltips
            foreach(Component c in circuit.elements)
            {
                t.RemoveAll();
            }
            //get adjacency matrix
            int[,] adj = circuit.genadjacency();
            //check matrix
            for (int a = 0; a < circuit.elements.Count; a++)
            {
                for (int b = 0; b < circuit.elements.Count; b++)
                {
                    Console.Write(adj[a,b] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            //generate a tree
            int[,] tree = circuit.gentree(adj);
            //check tree
            for (int a = 0; a < circuit.elements.Count; a++)
            {
                for (int b = 0; b < circuit.elements.Count; b++)
                {
                    Console.Write(tree[a, b] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            //find loops/cycles in graph
            int[,] loops = circuit.findloops(adj, tree);
            //check loops
            for (int a = 0; a < (loops.Length / circuit.elements.Count) ; a++)
            {
                for (int b = 0; b < circuit.elements.Count; b++)
                {
                    Console.Write(loops[a, b] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            //orient loops/cycles
            int[,] orientloops = circuit.orientloops(loops);
            //check orientation
            for (int a = 0; a < (orientloops.Length / circuit.elements.Count); a++)
            {
                for (int b = 0; b < circuit.elements.Count; b++)
                {
                    Console.Write(orientloops[a, b] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            //generate circuit equations and solve
            try
            {
                double[] current = circuit.solve(orientloops);
                //check equations
                foreach (double d in current)
                {
                    Console.Write(d + " ");
                }
                Console.Write("\n");
                //update circuit UI
                for (int a = 0; a < (orientloops.Length / circuit.elements.Count); a++)
                {
                    for (int b = 0; b < circuit.elements.Count; b++)
                    {
                        if (orientloops[a, b] > 0)
                        {
                            //set tooltip 
                            t.SetToolTip(circuit.elements[b].box,
                                "Voltage: " + (circuit.elements[b].resistance * current[a] * -1) + "\n" +
                                "target V: " + circuit.elements[b].voltage + "\n" +
                                "C: " + current[a]);
                        }
                    }
                }
            }
            catch
            {
                //error message if failed to solve
                MessageBox.Show("Failed to solve, this may be because:\nthe circuit is incomplete / no cycles\nthere was a problem when constructing the circuit\n \n please try rebuilding");
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
            foreach (Tuple<string, string> connection in circuit.connections)
            {
                Component start = circuit.elements.Find(x => x.name == connection.Item1);
                Component end = circuit.elements.Find(x => x.name == connection.Item2);
                draw_line(start.box.Location + new Size(start.box.Width / 2, start.box.Height / 2), end.box.Location + new Size(end.box.Width / 2, end.box.Height / 2));
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog path = new SaveFileDialog();
            path.ShowDialog();
            if (path.FileName != "")
            {
                circuit.save(path.FileName);
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();
            if (path.ShowDialog() == DialogResult.OK)
            {
                //remove_btn all the boxes
                foreach (Component c in circuit.elements)
                {
                    this.Controls.Remove(c.box);
                }
                //clears lines
                line.Clear(Color.White);
                //load saved circuit
                circuit.load(path.FileName);
                //update UI
                foreach(Component c in circuit.elements)
                {
                    c.box.MouseUp += new MouseEventHandler(refreshline);
                    this.Controls.Add(c.box);
                }
                MouseButtons b = new MouseButtons();
                MouseEventArgs t = new MouseEventArgs(b, 1, 0, 0, 0);
                refreshline(sender, t);
            }
        }
    }
}
