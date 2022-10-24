//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using MultiQueueModels;

//namespace MultiQueueSimulation
//{
//    internal class Data
//    {
//        public Data(String data_path)
//        {
//            lines = File.ReadAllLines(data_path);
//            SimulationSystem sys = new SimulationSystem();

//            int count = -1;

//            for (int i = 0; i < lines.Count(); i++)
//            {
//                if (lines[i] == null || lines[i].Length == 0 || lines[i] == "")
//                {
//                    continue;
//                }

//                if (lines[i] == "NumberOfServers")
//                {
//                    sys.NumberOfServers = int.Parse(lines[i + 1]);
//                }
//                else if (lines[i] == "StoppingNumber")
//                {
//                    sys.StoppingNumber = int.Parse((lines[i + 1]));
//                }
//                else if (lines[i] == "StoppingCriteria")
//                {
//                    int cry = int.Parse((lines[i + 1]));

//                    switch (cry)
//                    {
//                        case 1:
//                            sys.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
//                            break;
//                        case 2:
//                            sys.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
//                            break;
//                    }

//                }
//                else if (lines[i] == "SelectionMethod")
//                {

//                    int selectMethod = int.Parse((lines[i + 1]));

//                    switch (selectMethod)
//                    {
//                        case 1:
//                            sys.SelectionMethod = Enums.SelectionMethod.HighestPriority;
//                            break;
//                        case 2:
//                            sys.SelectionMethod = Enums.SelectionMethod.Random;
//                            break;
//                        case 3:
//                            sys.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
//                            break;
//                    }

//                }
//                else if (lines[i] == "InterarrivalDistribution")
//                {
//                    for (int j = i + 1; j < lines.Length; j++)
//                    {
//                        if (lines[j] == null || lines[j].Length == 0 || lines[j] == "")
//                            break;

//                        int time = int.Parse(lines[j].Split(',')[0]);
//                        decimal prob = decimal.Parse(lines[j].Split(',')[1]);

//                        sys.InterarrivalDistribution.Add(new TimeDistribution(time, prob));
//                    }
//                }
//                else if (lines[i].Contains("ServiceDistribution")) {

//                    sys.Servers.Add(new Server(sys.Servers.Count + 1));
//                    count++;

//                    for (int j = i + 1; j < lines.Length; j++) {
//                        if (lines[j] == null || lines[j].Length == 0 || lines[j] == "")
//                            break;

//                        Console.WriteLine(lines[j].Split(',')[0]);
//                        Console.WriteLine(lines[j].Split(',')[1]);

//                        int time = int.Parse(lines[j].Split(',')[0]);
//                        decimal prob = decimal.Parse(lines[j].Split(',')[1]);

//                        sys.Servers[count].TimeDistribution.Add(new TimeDistribution(time, prob));
//                    }
//                }
//            }

//            //interarrival time
//            TimeDistribution.allTimeDistribution(sys.InterarrivalDistribution);

//            //server time
//            foreach(Server server in sys.Servers) {
//                TimeDistribution.allTimeDistribution(server.TimeDistribution);
//            }


//        }


//        public String[] lines { get; set; }

//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    internal class Data
    {
        public Data(String data_path, SimulationSystem sys)
        {
            lines = File.ReadAllLines(data_path);
            //SimulationSystem sys = new SimulationSystem();

            int count = -1;

            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i] == null || lines[i].Length == 0 || lines[i] == "")
                {
                    continue;
                }

                if (lines[i] == "NumberOfServers")
                {
                    sys.NumberOfServers = int.Parse(lines[i + 1]);
                }
                else if (lines[i] == "StoppingNumber")
                {
                    sys.StoppingNumber = int.Parse((lines[i + 1]));
                }
                else if (lines[i] == "StoppingCriteria")
                {
                    int cry = int.Parse((lines[i + 1]));

                    switch (cry)
                    {
                        case 1:
                            sys.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
                            break;
                        case 2:
                            sys.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
                            break;
                    }

                }
                else if (lines[i] == "SelectionMethod")
                {

                    int selectMethod = int.Parse((lines[i + 1]));

                    switch (selectMethod)
                    {
                        case 1:
                            sys.SelectionMethod = Enums.SelectionMethod.HighestPriority;
                            break;
                        case 2:
                            sys.SelectionMethod = Enums.SelectionMethod.Random;
                            break;
                        case 3:
                            sys.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
                            break;
                    }

                }
                else if (lines[i] == "InterarrivalDistribution")
                {
                    for (int j = i + 1; j < lines.Length; j++)
                    {
                        if (lines[j] == null || lines[j].Length == 0 || lines[j] == "")
                            break;

                        int time = int.Parse(lines[j].Split(',')[0]);
                        decimal prob = decimal.Parse(lines[j].Split(',')[1]);

                        sys.InterarrivalDistribution.Add(new TimeDistribution(time, prob));
                    }
                }
                else if (lines[i].Contains("ServiceDistribution"))
                {

                    sys.Servers.Add(new Server(sys.Servers.Count + 1));
                    count++;

                    for (int j = i + 1; j < lines.Length; j++)
                    {
                        if (lines[j] == null || lines[j].Length == 0 || lines[j] == "")
                            break;

                        Console.WriteLine(lines[j].Split(',')[0]);
                        Console.WriteLine(lines[j].Split(',')[1]);
                        int time = int.Parse(lines[j].Split(',')[0]);
                        decimal prob = decimal.Parse(lines[j].Split(',')[1]);

                        sys.Servers[count].TimeDistribution.Add(new TimeDistribution(time, prob));
                    }
                }
            }

            //interarrival time
            TimeDistribution.allTimeDistribution(sys.InterarrivalDistribution);

            //server time
            foreach (Server server in sys.Servers)
            {
                TimeDistribution.allTimeDistribution(server.TimeDistribution);
            }


        }


        public String[] lines { get; set; }

    }
}


