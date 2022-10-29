using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueTesting;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            String path = "G:\\Projects\\Modeling-Simulation-Project\\MultiQueueSimulation\\MultiQueueSimulation\\TestCases\\TestCase1.txt";
            SimulationSystem system = new SimulationSystem();
            Data data = new Data(path, system);
            SelectionMethod.TableCalculation(system);
            string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            MessageBox.Show(result);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 temp_form = new Form1(system);
            Application.Run(temp_form);
          

        }
    }
}

