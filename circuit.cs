using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DraggableControls;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;


namespace personal_project
{
    class circuit 
    {
        public List<Component> elements = new List<Component>();
        public List<Tuple<string, string>> connections = new List<Tuple<string, string>>();
        int element_counter = 0;
        Matrix<double> a = DenseMatrix.OfArray(new double[,]
        {
            {1, 2},
            {3, 4}
        });

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
                    if(ajacent[a, b] == 1 && treenodes[a] == 0 && treenodes[b] == 1)
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
            List<Tuple<string, string>> unused = new List<Tuple<string, string>>();
            for (int a = 0; a < elements.Count; a++)
            {
                for (int b = 0; b < elements.Count; b++)
                {
                    string startname = elements[a].name;
                    string endname = elements[b].name;
                    if (adj[a, b] == 1 && tree[a, b] == 0 && connections.Contains(new Tuple<string, string>(startname, endname)))
                    {
                        unused.Add(new Tuple<string, string>(startname, endname));
                    }
                }
            }
            foreach (Tuple<string, string> t in unused)
            {
                Console.WriteLine(t.Item1 + "," + t.Item2);
            }

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
            for (int i = 0; i < unused.Count; i++)
            {

            }

            return loops;
        }
    }
}
