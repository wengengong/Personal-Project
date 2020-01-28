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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Component test = new Component();
            test.name = "bob!!!!!!!!!";
            circuit circuit = new circuit();
            circuit.add(test);
            Console.WriteLine(circuit.get(test).name);

        }

    }
}
