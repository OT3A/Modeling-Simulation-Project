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
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;


                    Data data = new Data(file, sys);
                    SelectionMethod.TableCalculation(sys);
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" , "siko", "siko", "siko", "siko", "siko"};
            dataGridView1.Rows.Add(row0);
            dataGridView1.Columns[0].DisplayIndex = 0;
        }
    }
}
