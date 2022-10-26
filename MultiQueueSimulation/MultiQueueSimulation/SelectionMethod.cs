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
        public SelectionMethod()
        {

        }
        public static void TableCalculation(SimulationSystem sys)
        {

            Random rd = new Random();
            int size = 100 ;
            bool check = false;

            if (sys.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
                size = sys.StoppingNumber;
            else
                check = true;
                
            for (int i = 0; i < size; i++)
            {
                if (check == true && sys.TotalRunTime + sys.MaxService > sys.StoppingNumber)
                    break;
                sys.SimulationTable.Add(new SimulationCase());
                sys.SimulationTable[i].CustomerNumber = i + 1; //Column A

                if (i == 0)
                {
                    sys.SimulationTable[i].ArrivalTime = 0;
                    sys.SimulationTable[i].AssignedServer = sys.Servers[i];  // "i" here = 0
                    sys.SimulationTable[i].ServerID = 1;
                    sys.SimulationTable[i].StartTime = 0;
                    sys.SimulationTable[i].RandomInterArrival = 1;
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

                    for (int j = sys.SimulationTable[i].StartTime; j <= sys.SimulationTable[i].EndTime; j++)
                        sys.SimulationTable[i].AssignedServer.busy[j] = 1;

                    //--------------------------------------OutPut---------------------------------
                    sys.TotalRunTime += sys.SimulationTable[i].EndTime; // Sup of output
                    sys.SimulationTable[i].AssignedServer.TotalWorkingTime += sys.SimulationTable[i].ServiceTime;//OutPut
                    sys.SimulationTable[i].AssignedServer.TotalCustomers++;
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

                    sys.SimulationTable[i].RandomService = rd.Next(1, 100);
                    //------------------choose selection method-----------------------
                    if (sys.SelectionMethod == Enums.SelectionMethod.HighestPriority)
                        sys.SimulationTable[i].AssignedServer = prioritySelection(sys, sys.SimulationTable[i]); //priority server selection 
                    else if (sys.SelectionMethod == Enums.SelectionMethod.Random)
                        sys.SimulationTable[i].AssignedServer = randomSelection(sys, sys.SimulationTable[i]); //!!! in progress
                    else
                        sys.SimulationTable[i].AssignedServer = leastUtilization(sys, sys.SimulationTable[i]); //!!! in progress                                                                                                               //----------------------------------------------------------------
                    //-------------------------------OutPut-------------------------------------
                    sys.SimulationTable[i].AssignedServer.TotalWorkingTime += sys.SimulationTable[i].ServiceTime;

                    sys.SimulationTable[i].AssignedServer.TotalCustomers++;
                    sys.SimulationTable[i].ServerID = sys.SimulationTable[i].AssignedServer.ID;
                    sys.SimulationTable[i].TimeInQueue = sys.SimulationTable[i].StartTime - sys.SimulationTable[i].ArrivalTime;
                    sys.SimulationTable[i].EndTime = sys.SimulationTable[i].ServiceTime + sys.SimulationTable[i].StartTime;

                    sys.TotalTimeinQueue += sys.SimulationTable[i].TimeInQueue;

                    //Mabrouk
                    sys.TotalRunTime = Math.Max(sys.SimulationTable[i].EndTime, sys.TotalRunTime); // Sup of output


                    if (sys.SimulationTable[i].TimeInQueue != 0)
                        sys.NumOfWaitedCus++;

                    for (int j = sys.SimulationTable[i].StartTime; j <= sys.SimulationTable[i].EndTime; j++)
                        sys.SimulationTable[i].AssignedServer.busy[j] = 1;

                }

            }

            // code Mabrouk
            for (int i = 0; i<sys.SimulationTable.Count;i++)
            {
                int count = 0;
                for(int j=i; j<sys.SimulationTable.Count;j++)
                {
                    if (sys.SimulationTable[j].ArrivalTime <sys.SimulationTable[i].StartTime)
                    {
                        count++;
                    }
                }
                sys.PerformanceMeasures.MaxQueueLength = Math.Max(sys.PerformanceMeasures.MaxQueueLength, count);

            }
            //-------------------------------OutPut--------------------------------
            sys.AverageWaitingTime =(float) ((float) sys.TotalTimeinQueue /(float) sys.SimulationTable.Count) ;


            sys.WaitingProbability =(float) sys.NumOfWaitedCus /(float) sys.SimulationTable.Count ;


            for(int i = 0; i<sys.Servers.Count();i++)
            {
                int idle = sys.TotalRunTime - sys.Servers[i].TotalWorkingTime;

                sys.Servers[i].IdleProbability =((decimal)  idle / (decimal) sys.TotalRunTime);
                sys.Servers[i].Utilization = ((decimal)sys.Servers[i].TotalWorkingTime / (decimal)sys.TotalRunTime);

                if (sys.Servers[i].TotalCustomers > 0)
                    sys.Servers[i].AverageServiceTime =(decimal) sys.Servers[i].TotalWorkingTime /(decimal) sys.Servers[i].TotalCustomers;
                else
                    sys.Servers[i].AverageServiceTime = 0;
            }

            sys.PerformanceMeasures.AverageWaitingTime =(decimal) sys.AverageWaitingTime;
            sys.PerformanceMeasures.WaitingProbability =(decimal) sys.WaitingProbability;


        }

        public static Server randomSelection(SimulationSystem sys, SimulationCase scase)
        {
            Random rd = new Random();
            HashSet<int> set = new HashSet<int>();
            int min = 1000000;
            int index;
        //    scase.RandomService = rd.Next(1, 100); //column E

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
