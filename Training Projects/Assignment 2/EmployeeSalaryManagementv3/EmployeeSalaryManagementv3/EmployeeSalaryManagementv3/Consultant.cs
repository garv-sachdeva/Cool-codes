using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryManagementv3
{
    class Consultant : Employee
    {

        /// <summary>
        /// calling base class employee for saving all common employee parameters
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        public Consultant(int p1, string p2, int p3)
            : base(p1, p2, p3)
        {
            // TODO: Complete member initialization
        }

        /// <summary>
        ///  setting all report printing parameters for consultants and calling base class count salary function to print report.
        /// </summary>
        /// <param name="monthInput"></param>
        /// <param name="workingHours"></param>
        public override void CountSalary(string monthInput, int workingHours)
        {
            salary *= workingHours;
            report = Constants.week;
            base.CountSalary(monthInput, workingHours);
        }

        internal static void addNewUser(ref bool flag, ref List<string> name, ref List<int> salary, ref List<int> type)
        {
            do
            {
                if (flag == false)
                    Console.WriteLine("Please Provide Valid Input (Max Hourly Salary:3000)");
                Console.WriteLine("Please input Hourly Rate");
                int userSalary = Convert.ToInt32(Console.ReadLine());

                if (userSalary < 3001)
                {
                    salary.Add(userSalary);
                    flag = true;
                }
                else flag = false;
            } while (!flag);
            flag = true;

        }
    }
}
