using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryManagementv3
{
        class Display
        {

            /// <summary>
            /// individual table row display.
            /// </summary>
            /// <param name="idOutput"></param>
            /// <param name="nameOutput"></param>
            /// <param name="annualSalaryOutput"></param>
            /// <param name="typeOutput"></param>
            public static void DisplayEmployee(int idOutput, string nameOutput, int annualSalaryOutput, string typeOutput)
            {
                Console.WriteLine();
                Console.WriteLine(Constants.tableRow, idOutput, nameOutput, annualSalaryOutput, typeOutput);

            }

            /// <summary>
            /// Displaying final result query solution.
            /// </summary>
            /// <param name="salEmp"></param>
            /// <param name="conEmp"></param>
            /// <param name="id"></param>
            /// <param name="month"></param>
            /// <param name="leavesOrWorkingHours"></param>
            public static void FinalResult(List<Employee> salEmp, string month, List<int> leavesOrWorkingHours)
            {
                //Boolean flag;
                Console.WriteLine(Constants.displayTag);
                ToFile(Constants.displayTag);
                foreach (Employee empObj in salEmp)
                {
                        empObj.CountSalary(month, leavesOrWorkingHours[empObj.id-1]);
                } 
            }

            /// <summary>
            /// printing to file.
            /// </summary>
            /// <param name="output"></param>
            public static void ToFile(string output)
            {
                string[] lines = { output };
                string n = string.Format("D:\\Monthly Salary Report-{0:yyyy-MM-dd}.txt", DateTime.Now);
                System.IO.File.AppendAllLines(n, lines);
            }

            /// <summary>
            /// Displaying table for user information.
            /// </summary>
            /// <param name="salEmp"></param>
            /// <param name="conEmp"></param>
            /// <param name="count"></param>
            public static void DisplayDB(List<Employee> salEmp, int count, List<int> type)
            {

                Console.WriteLine(Constants.nl + Constants.tableTag);

                for (int i = 0; i < count; i++)
                {

                    foreach (Employee empObj in salEmp)
                    {
                        if (empObj.IdCheck(i + 1))
                            empObj.DisplayUser(type);
                    }
                }
            }

            /// <summary>
            /// Asking user for month and number of leaves or working hours as per user choice.
            /// </summary>
            /// <param name="counter"></param>
            /// <param name="type"></param>
            /// <param name="month"></param>
            /// <param name="leavesOrWorkingHours"></param>
            /// <returns></returns>
            public static void menuPrint(ref int counter, List<int> type, ref string month, ref List<int> leavesOrWorkingHours, List<string> names)
            {
                Console.WriteLine(Constants.nl + Constants.menuHeader);
                int i = 1,k;
                Boolean flag =true;
               
                //Leaves or Working hours Input by user & further validation
                do
                {   do
                    {
                    int l1,l2 = 0;
                    string l;
                    if (type[i - 1].Equals(1))
                    { l1 = 22; l = Constants.leaves; }
                    else
                    { l1 = 45; l = Constants.workingDays; }


                        Console.WriteLine(names[i-1] + " : " + Constants.club, Constants.input, l);
                        if (int.TryParse(Console.ReadLine(), out k))
                            if (k > l1 || k < l2)
                            {
                                Console.WriteLine(Constants.invalid, Constants.leaves);
                                flag = true;
                            }
                            else
                            {
                                leavesOrWorkingHours.Add(k);
                                flag = false;
                                i++;
                            }
                        else
                        {
                            Console.WriteLine(Constants.invalid);
                            flag = true;
                        }

                } while (flag);
                }while(i<=counter);
            }
        }
    }
