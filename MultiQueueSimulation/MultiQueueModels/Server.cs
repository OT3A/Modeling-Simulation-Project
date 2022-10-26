using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
            //this.is_idle = true;
        }
        public Server(int id)
        {
            this.TimeDistribution = new List<TimeDistribution>();
            //this.is_idle = true;
            busy = new int [1000];
            this.ID = id;
        }



        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;

        //public bool is_idle { get; set; }

        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }
        public int TotalCustomers { get; set; }
        public int[] busy { get; set; }
    }
}
