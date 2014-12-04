using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryManagementv3
{
    class Constants
    {

        /// <summary>
        /// constants for easy word change
        /// </summary>

        public static string club = "{0} {1}";
        public static string invalid = "Invalid Input, Please re-enter :";
        public static string nl = "\n";
        public static string tb = "\t";
        public static string ap = "'s";
        public static string id = "ID";
        public static string name = "Name";
        public static string week = "this week";
        public static string month = "Month";
        public static string leaves = "Leaves";
        public static string salary = "Salary";
        public static string annual = "Annual";
        public static string workingDays = "Working Hours";
        public static string input = "Please Enter the employee's reporting";
        public static string monthInput = club + " in MMM format(e.g. AUG for august)";
        public static string menuHeader = month + " " + salary + " as per " + leaves + nl;
        public static string tableTag = id + tb + name + tb + tb + annual + "/Hourly " + salary + tb + "Type";
        public static string tableRow = "{0}" + tb + "{1}" + tb + tb + "{2}" + tb + tb + tb + "{3}";
        public static string displayTag = name + tb + tb + month + tb + tb + tb + tb + salary;
        public static string monthSalaryPrint = "{0}" + tb + tb + "{1}" + tb + tb + tb + "{2}";
        public static string[] types = { "Salaried Employee", "Consultant" };
    }
}
