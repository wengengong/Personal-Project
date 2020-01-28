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
        circuit circuit = new circuit();
        int element_counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void resistor_btn_Click(object sender, EventArgs e)
        {
            PictureBox test = new PictureBox();
            test.SizeMode = PictureBoxSizeMode.StretchImage;
            test.ClientSize = new Size(100, 40);
            test.Location = new Point(10, 10);
            test.Visible = true;
            test.Draggable(true);
            test.Image = Image.FromFile("images\\resistor.jpg");
            test.Name = "resistor" + element_counter++;
            Component element = new Component(0, 0, 100, test);
            element.name = test.Name;
            this.Controls.Add(element.image);
            circuit.add(element);
        }
    }
}
