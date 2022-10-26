using MultiQueueModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiQueueSimulation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

            

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var temp = chart1.Series["Server Busy Time"].Points;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 280;

            for (int i = 0; i< server.busy.Length; i++)
            {
                temp.AddXY(i, server.busy[i]);
                Console.WriteLine(server.busy[i]);
            }
        }
        public Form2(Server s)
        {
            InitializeComponent();
            this.server = s;
        }

        public Server server { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
