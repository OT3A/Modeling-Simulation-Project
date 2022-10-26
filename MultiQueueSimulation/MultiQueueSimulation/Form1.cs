using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;
using System.IO;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        public string file { get; set; }
        public Form1()
        {

            InitializeComponent();
        }

        public int temp { get; set; }
        public SimulationSystem sys { get; set; }
        public Form1(SimulationSystem temp) {
            this.sys = temp;
            InitializeComponent();
        }

        private void Select_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();


            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    sys = new SimulationSystem();
                    Data data = new Data(file, sys);
                    SelectionMethod.TableCalculation(sys);
                    dataGridView1.DataSource = sys.SimulationTable;


                    List<PerformanceMeasures> temp = new List<PerformanceMeasures>();    
                       
                    for(int i = 0; i<sys.Servers.Count;i++)
                    {
                        temp.Add(new PerformanceMeasures(i+1,sys.Servers[i].IdleProbability, sys.Servers[i].AverageServiceTime));
                    }
                    dataGridView2.DataSource = temp;
                    textBox1.Text = sys.WaitingProbability.ToString();
                    textBox2.Text = sys.AverageWaitingTime.ToString();

                    comboBox1.Items.Clear();
                    for (int i = 1; i <= sys.Servers.Count; i++)
                        comboBox1.Items.Add(i);
                }
                catch (IOException)
                {

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            Form2 frm = new Form2(sys.Servers[0]);
            frm.Show();
           //     this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = comboBox1.SelectedIndex;
            Form2 frm = new Form2(sys.Servers[x]);
            frm.Show();
        }
    }
}
