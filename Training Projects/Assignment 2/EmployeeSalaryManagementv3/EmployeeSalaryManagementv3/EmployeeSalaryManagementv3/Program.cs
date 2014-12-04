using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryManagementv3
{
    class Program
    {
        /// <summary>
        /// initial fill up of databbase and creation of salaried and consultant class objects.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="salEmp"></param>
        /// <param name="conEmp"></param>
        /// <param name="names"></param>
        /// <param name="salary"></param>
        /// <param name="type"></param>
        public static void inputDB(ref int id, ref List<Employee> salEmp, List<string> names, List<int> salary, List<int> type)
        {

            foreach (int typeObj in type)
            {
                if (typeObj == 1)
                {
                    Employee salEmpObj = new SalariedEmployee(id, names[id], salary[id]);
                    salEmp.Add(salEmpObj);
                    id++;
                }
                if (typeObj == 2)
                {
                    Employee conEmpObj = new Consultant(id, names[id], salary[id]);
                    salEmp.Add(conEmpObj);
                    id++;
                }

            }
        }

        private static void InitializeDummyData(ref List<string> names, ref List<int> salary, ref List<int> type, ref int counter, ref string month, ref List<Employee> salEmp)
        {
            // asking user to add new users

            Employee.addNewUser(ref names, ref salary, ref type);

            //initializing static database values & creating employee class list and objects

            inputDB(ref counter, ref salEmp, names, salary, type);

            //Displaying the DB for user knowledge

            Display.DisplayDB(salEmp, counter, type);

        }

        static void Main(string[] args)
        {
            int counter = 0;

            string month = "";

            // Lists for Salaried Employee, Consultants. Also for static DB values.

            List<Employee> salEmp = new List<Employee>();

            List<string> names = new List<string>(new string[] { "Bill", "Steve", "Michael", "Cindy", "Linda", "Cleve", "Matt" });

            List<int> salary = new List<int>(new int[] { 100000, 50000, 150000, 200000, 50000, 500, 800 });

            List<int> type = new List<int>(new int[] { 1, 1, 1, 1, 1, 2, 2 });

            List<int> leavesOrWorkingHours = new List<int>();

            // Initialize dummy data

            InitializeDummyData(ref names, ref salary, ref type, ref counter, ref month, ref salEmp);

            //Menu option for user

            Display.menuPrint(ref counter, type, ref month, ref leavesOrWorkingHours, names);

            //Printing the final query result

            Display.FinalResult(salEmp, month, leavesOrWorkingHours);

            Console.ReadKey();
        }


    }
}
