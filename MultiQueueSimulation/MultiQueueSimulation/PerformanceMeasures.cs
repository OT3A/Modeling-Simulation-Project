using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueSimulation
{
    class PerformanceMeasures
    {
        public int ServerID { get; set; } 
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; }

        public PerformanceMeasures(int serverID, decimal idleProbability, decimal averageServiceTime)
        {
            ServerID = serverID;
            IdleProbability = idleProbability;
            AverageServiceTime = averageServiceTime;
        }
        public PerformanceMeasures()
        {

        }
    }
}
