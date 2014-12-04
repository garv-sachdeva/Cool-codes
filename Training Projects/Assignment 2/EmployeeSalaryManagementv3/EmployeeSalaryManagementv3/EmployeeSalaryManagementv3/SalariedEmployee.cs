using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryManagementv3
{
    class SalariedEmployee : Employee
    {
        public static int annualPay;
        private int leaves = 0;

        /// <summary>
        /// calling base class employee for saving all common employee parameters, and analysing annual salary.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        public SalariedEmployee(int p1, string p2, int p3)
            : base(p1, p2, p3)
        {
            // TODO: Complete member initialization
            annualPay = salary * 12;

        }

        /// <summary>
        /// setting all report printing parameters for salaried employee and calling base class count salary function to print report.
        /// </summary>
        /// <param name="monthInput"></param>
        /// <param name="leaves"></param>
        public override void CountSalary(string monthInput, int leaves)
        {
            DateTime.TryParseExact(monthInput, "MMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out month);
            this.leaves = leaves;
            month = DateTime.Now;
            salary -= ((salary / DateTime.DaysInMonth(DateTime.Now.Year, month.Month)) * this.leaves);
            monthInput = String.Format("{0:MMMM}", month);
            report = month.Month + " i.e. " + monthInput;
            base.CountSalary(monthInput, leaves);
        }

        public static void addNewUser(ref Boolean flag, ref List<string> name, ref List<int> salary, ref List<int> type)
        {
            do
            {
                if (flag == false)
                    Console.WriteLine("Please Provide Valid Input (Max Monthly Salary :300000)");
                Console.WriteLine("Please input Monthly Salary");
                int userSalary = Convert.ToInt32(Console.ReadLine());

                if (userSalary < 300001)
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
