using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DraggableControls;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Newtonsoft.Json;

namespace personal_project
{
    class circuit 
    {
        public List<Component> elements = new List<Component>();
        public List<Tuple<string, string>> connections = new List<Tuple<string, string>>();
        public int element_counter = 0;

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

        public int[ , ] genadjacency()
        {
            //make a n by n array as an adjacency matrix for the circuit components
            int[ , ] adjacency_matrix = new int[elements.Count, elements.Count];
            for (int a = 0; a < elements.Count; a++)
            {
                for (int b = 0; b < elements.Count; b++)
                {
                    //fills with 0's to start
                    adjacency_matrix[a, b] = 0;
                }
            }
            //turns each connection into a 1
            foreach (Tuple<string, string> c in connections)
            {
                adjacency_matrix[elements.IndexOf(get(c.Item1)), elements.IndexOf(get(c.Item2))] = 1;
                adjacency_matrix[elements.IndexOf(get(c.Item2)), elements.IndexOf(get(c.Item1))] = 1;
            }

            return adjacency_matrix;
        }


        public int[,] gentree(int[,] ajacent)
        {
            int[] treenodes = new int[elements.Count];
            int[,] treeconnections = new int[elements.Count, elements.Count];
            //start tree nodes
            for (int i = 0; i < elements.Count; i++)
            {
                treenodes[i] = 0;
            }
            treenodes[0] = 1;
            //start tree connections
            for (int a = 0; a < elements.Count; a++)
            {
                for (int b = 0; b < elements.Count; b++)
                {
                    treeconnections[a, b] = 0;
                }
            }
            //find a tree (assumes the graph is all connected)
            for (int a = 0; a < elements.Count; a++)
            {
                for (int b = 0; b < elements.Count; b++)
                {
                    if (ajacent[a,b] == 1 && treenodes[a] == 1 && treenodes[b] == 0)
                    {
                        treeconnections[a,b] = 1;
                        treeconnections[b,a] = 1;
                        treenodes[b] = 1;
                    }
                    if(ajacent[a,b] == 1 && treenodes[a] == 0 && treenodes[b] == 1)
                    {
                        treeconnections[a, b] = 1;
                        treeconnections[b, a] = 1;
                        treenodes[b] = 1;
                    }
                }
            }

            return treeconnections;
        }

        public int[,] findloops(int[,] adj, int[,] tree)
        {
            //find all the unused edges
            List< Tuple<int, int>> unused = new List<Tuple<int, int>>();
            for (int a = 0; a < elements.Count; a++)
            {
                for (int b = 0; b < elements.Count; b++)
                {
                    string startname = elements[a].name;
                    string endname = elements[b].name;
                    if (adj[a, b] == 1 && tree[a, b] == 0 && (connections.Contains(new Tuple<string, string>(startname, endname))))
                    {
                        unused.Add(new Tuple<int, int>(a, b));
                    }
                }
            }

            Console.WriteLine(unused.Count + " unused edges");

            //set up array to store loops
            int[,] loops = new int[unused.Count , elements.Count];
            for (int a = 0; a < unused.Count; a++)
            {
                for (int b = 0; b < elements.Count; b++)
                {
                    loops[a, b] = 0;
                }
            }

            //find loops
            int counter = 0;
            int[,] copy = new int[elements.Count, elements.Count];
            foreach (Tuple<int, int> unusededge in unused)
            {
                //copy = tree;
                //add one of the unused edges to a copy of the tree
                for (int a = 0; a < elements.Count; a++)
                {
                    for (int b = 0; b < elements.Count; b++)
                    {
                        copy[a, b] = tree[a, b];
                    }
                }
                copy[unusededge.Item1, unusededge.Item2] = 1;
                copy[unusededge.Item2, unusededge.Item1] = 1;

                //prune the graph
                bool removed = true;
                while (removed == true)
                {
                    removed = false;
                    //for each node in the graph
                    for (int i = 0; i < elements.Count; i++)
                    {
                        //counts the number of connections it has
                        int connections = 0;
                        for (int a = 0; a < elements.Count; a++)
                        {
                            connections += copy[i, a];
                        }
                        //if it only has one connection remove it
                        if (connections == 1)
                        {
                            for (int a = 0; a < elements.Count; a++)
                            {
                                copy[i, a] = 0;
                                copy[a, i] = 0;
                            }
                            removed = true;
                        }
                        //repeat until only the loop remains
                    }
                }

                //add the loop to the array
                for (int i = 0; i < elements.Count; i++)
                {
                    int connections = 0;
                    for (int a = 0; a < elements.Count; a++)
                    {
                        connections += copy[i, a];
                    }
                    if (connections > 1)
                    {
                        loops[counter,i] = 1;
                    }
                }
                counter++;
            }

            counter = 0;
            return loops;
        }

        public int[,] orientloops(int[,] loops)
        {
            int numloops = loops.Length / elements.Count;
            //set up array to store oriented loops
            int[,] orientedloops = new int[numloops, elements.Count];
            for(int a = 0; a < numloops; a++)
            {
                for(int b = 0; b < elements.Count; b++)
                {
                    orientedloops[a, b] = 0;
                }
            }
            //for each loop
            
            for(int i = 0; i < numloops; i++)
            {
                int counter = 1;
                int current = 0;
                int[] loopcopy = new int[elements.Count];
                for(int a = 0; a < elements.Count; a++)
                {
                    loopcopy[a] = loops[i, a];
                }

                //select the first element
                for(int a = 0; a < elements.Count; a++)
                {
                    if(loops[i,a] == 1)
                    {
                        orientedloops[i, a] = counter;
                        current = a;
                        loopcopy[a] = 0;
                        counter++;
                        break;
                    }
                }

                /*while there are still edges in the loop, remove them one by one
                  and giving them an orderfrom 1 to n until there are no edges left*/
                bool edgesleft = true;
                while (edgesleft == true)
                {
                    edgesleft = false;
                    for(int a = 0; a < elements.Count; a++)
                    {
                        //if the element has not been used and there is a connection from the current element to it then it is removed 
                        if (loopcopy[a] == 1 && (connections.Contains(new Tuple<string, string>(elements[a].name, elements[current].name)) || connections.Contains(new Tuple<string, string>(elements[current].name, elements[a].name))))
                        {
                            orientedloops[i,a] = counter;
                            current = a;
                            loopcopy[a] = 0;
                            counter++;
                            edgesleft = true;
                            break;
                        }
                    }
                }
            }
            return orientedloops;
        }

        public double[] solve(int[,] directedloops)
        {
            int numloops = directedloops.Length / elements.Count;
            double[,] resistances = new double[numloops, numloops];
            for (int a = 0; a < numloops; a++)
            {
                for (int b = 0; b < numloops; b++)
                {
                    resistances[a, b] = 0;
                }
            }
            //for each loop, sum the resistance of that loop and all adjacent loops
            for (int a = 0; a < numloops; a++)
            {
                for(int b = 0; b < numloops; b++)
                {
                    if(b == a)
                    {
                        //sum resistances of all elemets in the loop
                        double sum = 0;
                        for(int i = 0; i < elements.Count; i++)
                        {
                            if(directedloops[a,i] > 0)
                            {
                                sum += elements[i].resistance;
                            }
                        }
                        resistances[a, b] = sum;
                    }
                    else
                    {
                        //checks if this loop is adjacent
                        bool adj = false;
                        List<int> shared = new List<int>();
                        for(int i = 0; i < elements.Count; i++)
                        {
                            if (directedloops[a,i] > 0 && directedloops[b,i] > 0)
                            {
                                shared.Add(i);
                                adj = true;
                            }
                        }
                        //if the loop is adjacent sum shared elements
                        if (adj == true && shared.Count > 1)
                        {
                            double sum = 0;
                            foreach (int i in shared)
                            {
                                sum += elements[i].resistance;
                            }
                            //work out if the loop diredtions are the same or opposed
                            double loop1 = directedloops[a, shared[0]];
                            double loop2 = directedloops[b, shared[0]];
                            for (int i = 1; i < shared.Count; i ++)
                            {
                                loop1 -= directedloops[a, shared[i]];
                                loop2 -= directedloops[b, shared[i]];
                            }
                            if(loop1 < 0 && loop2 < 0)
                            {
                                //if the loops are going in the same direction add the resistance
                                resistances[a, b] = sum;
                            }
                            else
                            {
                                // if they are opposed then subtract the resistance
                                resistances[a, b] = (sum * -1);
                            }
                        }
                    }
                }
            }

            for(int a = 0; a < numloops; a++)
            {
                for(int b = 0; b < numloops; b++)
                {
                    Console.Write(resistances[a,b] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
            var coefficients = Matrix<double>.Build.DenseOfArray(resistances);

            //sum all the voltage sources in each loop
            double[] vsum = new double[numloops];
            for(int i = 0; i < numloops; i++)
            {
                double sum = 0;
                for(int a = 0; a < elements.Count; a++)
                {
                    //if the element produces voltage
                    if(elements[a].voltage > 0)
                    {
                        sum += elements[a].voltage;
                    }
                }
                vsum[i] = sum;
            }
            var target = Vector<double>.Build.Dense(vsum);
            //solve equations and return current
            var loopcurrents = coefficients.Solve(target).ToArray();
            return loopcurrents;
        }

        public void save(string path)
        {
            //convert to savable format since i can't save windows form objects
            savable temp = new savable();
            foreach(Component c in elements)
            {
                element_object elem = new element_object();
                elem.name = c.name;
                elem.voltage = c.voltage;
                elem.current = c.current;
                elem.resistance = c.resistance;
                elem.numconnections = c.numconnections;
                elem.type = c.type;
                elem.box_name = c.box.Name;
                elem.colour = c.box.BackColor;
                elem.width = c.box.ClientSize.Width;
                elem.hight = c.box.ClientSize.Height;
                elem.location = c.box.Location;
                temp.elements.Add(elem);
            }
            foreach(Tuple<string,string> t in connections)
            {
                temp.connections.Add(t);
            }
            temp.element_counter = element_counter;
            //save to json
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, temp);
            }
        }

        public void load(string path)
        {
            //clear lists
            elements.Clear();
            connections.Clear();
            element_counter = 0;
            //load file
            savable temp = new savable();
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                temp = (savable)serializer.Deserialize(file, typeof(savable));
            }
            foreach(element_object e in temp.elements)
            {
                PictureBox p = new PictureBox();
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.ClientSize = new Size(e.width, e.hight);
                p.Location = e.location;
                p.BackColor = e.colour;
                p.Name = e.type + element_counter;
                element_counter++;
                p.Visible = true;
                p.Draggable(true);
                Component c = new Component(e.name, e.voltage, e.current, e.resistance, e.numconnections, p, e.type);
                elements.Add(c);
            }
            foreach(Tuple<string,string> t in temp.connections)
            {
                connections.Add(t);
            }
            element_counter = temp.element_counter;
        }
    }
}
