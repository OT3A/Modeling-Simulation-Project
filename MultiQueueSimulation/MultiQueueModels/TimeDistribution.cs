using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class TimeDistribution
    {

        public TimeDistribution(int time, decimal prob) {
            this.Time = time;
            this.Probability = prob;
        }


        public int Time { get; set; }
        public decimal Probability { get; set; }
        public decimal CummProbability { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }


        public static void allTimeDistribution(List<TimeDistribution> timeDis)
        {
            for (int i = 0; i < timeDis.Count; i++) {
                if (i == 0)
                {
                    timeDis[i].CummProbability = timeDis[i].Probability;
                    timeDis[i].MinRange = 1;

                    int temp = (int)(((timeDis[i].CummProbability * 100) / 2) * 2);

                    timeDis[i].MaxRange = temp;
                }
                else {
                    timeDis[i].CummProbability = timeDis[i].Probability + timeDis[i - 1].CummProbability;
                    timeDis[i].MinRange = timeDis[i-1].MaxRange + 1;

                    int temp = (int)(((timeDis[i].CummProbability * 100) / 2) * 2);

                    timeDis[i].MaxRange = timeDis[i].MinRange + temp;
                }
            }
        }

    }
}
