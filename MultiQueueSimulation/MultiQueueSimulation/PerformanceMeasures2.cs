using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueSimulation
{
    class PerformanceMeasures2
    {
        public int ServerID { get; set; } 
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; }
        public decimal Utilization { get; set; }

        //passing data to graid view 2
        public PerformanceMeasures2(int serverID, decimal idleProbability, decimal averageServiceTime,decimal utilization)
        {
            ServerID = serverID;
            IdleProbability = idleProbability;
            AverageServiceTime = averageServiceTime;
            Utilization = utilization;
        }
        public PerformanceMeasures2()
        {

        }
    }
}
