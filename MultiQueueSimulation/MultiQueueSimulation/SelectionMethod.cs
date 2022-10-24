//using MultiQueueModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MultiQueueSimulation
//{
//    internal class SelectionMethod
//    {
//        public static void TableCalculation(SimulationSystem sys) {

//            if (sys.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers) {
//                for (int i = 0; i < sys.StoppingNumber; i++)
//                {

//                    sys.SimulationTable.Add(new SimulationCase());
//                    Random rd = new Random();
//                    sys.SimulationTable[i].CustomerNumber = i + 1; //Column A

//                    if (i == 0)
//                    {
//                        sys.SimulationTable[i].ArrivalTime = 0;
//                        sys.SimulationTable[i].AssignedServer = sys.Servers[i];  // "i" here = 0

//                        sys.SimulationTable[i].RandomService = rd.Next(1, 100);
//                        sys.SimulationTable[i].StartTime = 0;

//                        List<TimeDistribution> temp_list = sys.SimulationTable[i].AssignedServer.TimeDistribution;

//                        for (int j = 0; j < temp_list.Count(); j++)
//                        {
//                            if (sys.SimulationTable[i].RandomService >= temp_list[j].MinRange && sys.SimulationTable[i].RandomService <= temp_list[j].MaxRange)
//                            {
//                                sys.SimulationTable[i].ServiceTime = temp_list[j].Time;
//                            }
//                        }

//                        sys.SimulationTable[i].EndTime =
//                            sys.SimulationTable[i].ServiceTime +
//                            sys.SimulationTable[i].StartTime;

//                        sys.Servers[i].FinishTime = sys.SimulationTable[i].EndTime;

//                        sys.SimulationTable[i].TimeInQueue = 0;
//                    }
//                    else {

//                        sys.SimulationTable[i].RandomInterArrival = rd.Next(1, 100); //Column B

//                        List<TimeDistribution> arr_timeDist = sys.InterarrivalDistribution;

//                        for (int j = 0; j < arr_timeDist.Count(); j++)
//                        {
//                            if (sys.SimulationTable[i].RandomInterArrival >= arr_timeDist[j].MinRange && sys.SimulationTable[i].RandomInterArrival <= arr_timeDist[j].MaxRange)
//                            {
//                                sys.SimulationTable[i].InterArrival = arr_timeDist[j].Time; //Column C
//                            }
//                        }

//                        sys.SimulationTable[i].ArrivalTime = sys.SimulationTable[i - 1].ArrivalTime + sys.SimulationTable[i].InterArrival; //column D



//                        sys.SimulationTable[i].RandomService = rd.Next(1, 100); //Column E



//                        //sys.SimulationTable[i].StartTime = ; //Column F

//                        sys.SimulationTable[i].TimeInQueue = sys.SimulationTable[i].StartTime - sys.SimulationTable[i].ArrivalTime; //Column L


//                    }
//                }
//            }
//            else {}


//        }
//    }
//}

using MultiQueueModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueSimulation
{
    internal class SelectionMethod
    {
        public static void TableCalculation(SimulationSystem sys)
        {

            Random rd = new Random();
            if (sys.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                for (int i = 0; i < sys.StoppingNumber; i++)
                {

                    sys.SimulationTable.Add(new SimulationCase());
                    sys.SimulationTable[i].CustomerNumber = i + 1; //Column A

                    if (i == 0)
                    {
                        sys.SimulationTable[i].ArrivalTime = 0;
                        sys.SimulationTable[i].AssignedServer = sys.Servers[i];  // "i" here = 0

                        sys.SimulationTable[i].StartTime = 0;

                        sys.SimulationTable[i].RandomService = rd.Next(1, 100);
                        List<TimeDistribution> temp_list = sys.SimulationTable[i].AssignedServer.TimeDistribution;

                        for (int j = 0; j < temp_list.Count(); j++)
                        {
                            if (sys.SimulationTable[i].RandomService >= temp_list[j].MinRange && sys.SimulationTable[i].RandomService <= temp_list[j].MaxRange)
                            {
                                sys.SimulationTable[i].ServiceTime = temp_list[j].Time;
                            }
                        }

                        sys.SimulationTable[i].EndTime = sys.SimulationTable[i].ServiceTime + sys.SimulationTable[i].StartTime;

                        sys.Servers[i].FinishTime = sys.SimulationTable[i].EndTime;

                        sys.SimulationTable[i].TimeInQueue = 0;
                    }
                    else
                    {

                        sys.SimulationTable[i].RandomInterArrival = rd.Next(1, 100); //Column B

                        List<TimeDistribution> arr_timeDist = sys.InterarrivalDistribution;

                        for (int j = 0; j < arr_timeDist.Count(); j++)
                        {
                            if (sys.SimulationTable[i].RandomInterArrival >= arr_timeDist[j].MinRange && sys.SimulationTable[i].RandomInterArrival <= arr_timeDist[j].MaxRange)
                            {
                                sys.SimulationTable[i].InterArrival = arr_timeDist[j].Time; //Column C
                            }
                        }

                        sys.SimulationTable[i].ArrivalTime = sys.SimulationTable[i - 1].ArrivalTime + sys.SimulationTable[i].InterArrival; //column D


                        //------------------choose selection method-----------------------
                        if (sys.SelectionMethod == Enums.SelectionMethod.HighestPriority)
                            sys.SimulationTable[i].AssignedServer = prioritySelection(sys, sys.SimulationTable[i]); //priority server selection 
                        else if (sys.SelectionMethod == Enums.SelectionMethod.Random)
                            sys.SimulationTable[i].AssignedServer = randomSelection(sys, sys.SimulationTable[i]); //!!! in progress
                        else
                            sys.SimulationTable[i].AssignedServer = leastUtilization(sys, sys.SimulationTable[i]); //!!! in progress
                        //----------------------------------------------------------------

                        //sys.SimulationTable[i].StartTime = sys.SimulationTable[i].AssignedServer.FinishTime; //Column F
                        //if (sys.SimulationTable[i].ArrivalTime <= sys.SimulationTable[i].AssignedServer.FinishTime)
                        //{

                        //    sys.SimulationTable[i].TimeInQueue = sys.SimulationTable[i].AssignedServer.FinishTime - sys.SimulationTable[i].ArrivalTime; //Column L
                        //}
                        //else
                        //{
                        //    sys.SimulationTable[i].TimeInQueue = 0;
                        //}

                        sys.SimulationTable[i].TimeInQueue = sys.SimulationTable[i].StartTime - sys.SimulationTable[i].ArrivalTime;


                        //sys.SimulationTable[i].StartTime = sys.SimulationTable[i].ArrivalTime + sys.SimulationTable[i].TimeInQueue; //Column F

                        //sys.SimulationTable[i].RandomService = rd.Next(1, 100); //column E

                        //for (int j = 0; j < sys.SimulationTable[i].AssignedServer.TimeDistribution.Count(); j++)
                        //{
                        //    if (sys.SimulationTable[i].RandomService >= sys.SimulationTable[i].AssignedServer.TimeDistribution[j].MinRange
                        //        && sys.SimulationTable[i].RandomService <= sys.SimulationTable[i].AssignedServer.TimeDistribution[j].MaxRange)
                        //    {
                        //        sys.SimulationTable[i].ServiceTime = sys.SimulationTable[i].AssignedServer.TimeDistribution[j].Time;
                        //    }
                        //}

                        sys.SimulationTable[i].EndTime = sys.SimulationTable[i].ServiceTime + sys.SimulationTable[i].StartTime;
                    }
                }
            }
            else { }


        }

        public static Server randomSelection(SimulationSystem sys, SimulationCase scase)
        {
            Random rd = new Random();
            HashSet<int> set = new HashSet<int>();
            int min = 1000000;
            int index;
            scase.RandomService = rd.Next(1, 100); //column E

            while (true)
            {
                index = rd.Next(0, sys.Servers.Count());
                if (sys.Servers[index].FinishTime <= scase.ArrivalTime)
                {
                    //test
                    for (int j = 0; j < sys.Servers[index].TimeDistribution.Count(); j++)
                    {
                        if (scase.RandomService >= sys.Servers[index].TimeDistribution[j].MinRange
                            && scase.RandomService <= sys.Servers[index].TimeDistribution[j].MaxRange)
                        {
                            scase.ServiceTime = sys.Servers[index].TimeDistribution[j].Time;
                        }
                    }

                    scase.StartTime = scase.ArrivalTime;

                    sys.Servers[index].FinishTime = scase.ArrivalTime + scase.ServiceTime;

                    //*****************************************

                    return sys.Servers[index];
                }
                else {
                    set.Add(index);
                    if (min > sys.Servers[index].FinishTime) {

                        min = sys.Servers[index].FinishTime;



                        if (set.Count() == sys.Servers.Count())
                        {
                            //test
                            for (int j = 0; j < sys.Servers[index].TimeDistribution.Count(); j++)
                            {
                                if (scase.RandomService >= sys.Servers[index].TimeDistribution[j].MinRange
                                    && scase.RandomService <= sys.Servers[index].TimeDistribution[j].MaxRange)
                                {
                                    scase.ServiceTime = sys.Servers[index].TimeDistribution[j].Time;
                                }
                            }

                            scase.StartTime = sys.Servers[index].FinishTime;

                            sys.Servers[index].FinishTime = sys.Servers[index].FinishTime + scase.ServiceTime;
                            //*****************************************


                            return sys.Servers[index];
                        }
                    }
                    
                }
            }

        }

        public static Server prioritySelection(SimulationSystem sys, SimulationCase scase)
        {
            int minimum = 1000000;
            int index = -1;

            //test
            Random rd = new Random();
            scase.RandomService = rd.Next(1, 100); //column E
            //***********************************


            for (int i = 0; i < sys.Servers.Count(); i++)
            {
                if (sys.Servers[i].FinishTime <= scase.ArrivalTime)
                {
                    //test
                    for (int j = 0; j < sys.Servers[i].TimeDistribution.Count(); j++)
                    {
                        if (scase.RandomService >= sys.Servers[i].TimeDistribution[j].MinRange
                            && scase.RandomService <= sys.Servers[i].TimeDistribution[j].MaxRange)
                        {
                            scase.ServiceTime = sys.Servers[i].TimeDistribution[j].Time;
                        }
                    }

                    scase.StartTime = scase.ArrivalTime;

                    sys.Servers[i].FinishTime = scase.ArrivalTime + scase.ServiceTime;

                    //*****************************************

                    return sys.Servers[i];
                }
                if (minimum > sys.Servers[i].FinishTime)
                {
                    minimum = sys.Servers[i].FinishTime;
                    index = i;
                }
            }


            //test
            for (int j = 0; j < sys.Servers[index].TimeDistribution.Count(); j++)
            {
                if (scase.RandomService >= sys.Servers[index].TimeDistribution[j].MinRange
                    && scase.RandomService <= sys.Servers[index].TimeDistribution[j].MaxRange)
                {
                    scase.ServiceTime = sys.Servers[index].TimeDistribution[j].Time;
                }
            }

            scase.StartTime = sys.Servers[index].FinishTime;

            sys.Servers[index].FinishTime = sys.Servers[index].FinishTime + scase.ServiceTime;
            //*****************************************


            return sys.Servers[index];
        }

        public static Server leastUtilization(SimulationSystem sys, SimulationCase scase)
        {
            return new Server(); //!!!!!!!
        }

    }
}
