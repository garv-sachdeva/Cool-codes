using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryManagementv3
{
    /// <summary>
    /// Employee class for creating mew employees, contains salary as per leaves function
    /// </summary>
    public class Employee
    {
        public int id;
        public string name;
        protected int salary;
        public DateTime month = new DateTime();
        public string report;
        public int totalPay { get; set; }
        public string type;
        /// <summary>
        /// constructor method initialisation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        public Employee(int id, string name, int salary)
        {
            // TODO: Complete member initialization
            this.id = id + 1;
            this.name = name;
            this.salary = salary;
        }

        /// <summary>
        /// displaying individual table rows
        /// </summary>
        /// <param name="totalPay"></param>
        /// <param name="type"></param>
        public virtual void DisplayUser(List<int> types)
        {
            if (types[this.id - 1] == 1)
            { totalPay = SalariedEmployee.annualPay; type = Constants.types[0]; }
            else if (types[this.id-1] == 2)
            { totalPay = this.salary; type = Constants.types[1]; }

            Display.DisplayEmployee(id, name, totalPay, type);
        }

        /// <summary>
        /// Comparing id for user selected employee selection
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>

        public Boolean IdCheck(int i)
        {
            if (this.id == i)
                return true;
            else
                return false;
        }

        /// <summary>
        /// this is the calculate salary as per leaves in the month function
        /// </summary>
        /// <param name="idInput"></param>
        /// <param name="monthInput"></param>
        /// <param name="leavesOrWorkingDays"></param>
        public virtual void CountSalary(string monthInput, int leavesOrWorkingDays)
        {
            //string print = Constants.nl + (Constants.monthSalaryPrint, name, report, salary);
            string print = Constants.nl + this.name + Constants.tb + Constants.tb + this.report + Constants.tb + Constants.tb + Constants.tb + this.salary;
            Console.WriteLine(Constants.nl + Constants.monthSalaryPrint, this.name, this.report, this.salary);
            Display.ToFile(print);
        }

        /// <summary>
        /// Validating month's input by user
        /// </summary>
        /// <param name="monthInput"></param>
        /// <returns></returns>
        public static bool ValidMonth(string monthInput)
        {
            DateTime month = new DateTime();
            var formatStrings = new string[] { "MMM" };
            Boolean flag = DateTime.TryParseExact(monthInput, formatStrings, CultureInfo.InvariantCulture, DateTimeStyles.None, out month);
            if (!flag)
                Console.WriteLine(Constants.invalid, "Month");
            return flag;
            throw new NotImplementedException();
        }


        /// <summary>
        /// function to provide user an option add new users in hard coded list.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        /// <param name="type"></param>
        public static void addNewUser(ref List<string> name, ref List<int> salary, ref List<int> type)
        {
            Boolean flag = true;
            do
            {
                Console.WriteLine("Want to add new user Y/N");
                char check = Convert.ToChar(Console.ReadLine());
                if (check == 'y' || check == 'Y')
                {

                    Console.WriteLine("Please enter Name:");
                    string userName = Console.ReadLine();
                    name.Add(userName);

                    do
                    {
                        Console.WriteLine("Please enter type, '1' for Salaried employee & '2' for Consultant");
                        int userType = Convert.ToInt32(Console.ReadLine());
                        if (userType == 1)
                        {
                            type.Add(userType);
                            SalariedEmployee.addNewUser(ref flag, ref name, ref salary, ref type);


                        }
                        else
                            if (userType == 2)
                            {
                                type.Add(userType);
                                Consultant.addNewUser(ref flag, ref name, ref salary, ref type);

                            }
                            else
                                flag = false;
                    } while (!flag);
                    flag = true;
                }
                else
                    flag = false;
            } while (flag);
        }

        
    }
}
