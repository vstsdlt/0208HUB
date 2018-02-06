using FACTS.Framework.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFML.Shared.Utility;
using FACTS.Framework.Utility;

namespace PFML.Shared.Utility
{
    public static class DateUtil
    {
        /// <summary>Returns the quarter of the year based on the month. Three months constitute a quarter.</summary>
        /// <param name="month">The month of an year.</param>
        /// <returns>The quarter of the month. If the month is an invalid month it returns 0.</returns>
        public static string GetQuarter(int month)
        {
            string quarter = "";

            if (month >= (int)Constants.Months.January && month <= (int)Constants.Months.March)
            {
                quarter = LookupTable.LookupTable_Quarter.JanuaryFebruaryMarchQ1;
            }
            else if (month >= (int)Constants.Months.April && month <= (int)Constants.Months.June)
            {
                quarter = LookupTable.LookupTable_Quarter.AprilMayJuneQ2;
            }
            else if (month >= (int)Constants.Months.July && month <= (int)Constants.Months.September)
            {
                quarter = LookupTable.LookupTable_Quarter.JulyAugustSeptemberQ3;
            }
            else if (month >= (int)Constants.Months.October && month <= (int)Constants.Months.December)
            {
                quarter = LookupTable.LookupTable_Quarter.OctoberNovemberDecemberQ4;
            }
            return quarter;
        }


        /// <summary>
        /// Populates the dropdown list with all the years that come in the specified category or range.
        /// </summary>
        /// <param name="goBackYears">The number of years to go back from the current year.</param>
        /// <param name="goForwardYears">The number of years to go forward from the current year.</param>
        /// <param name="sortAscending">A boolean value if, true: sorts the list in ascending order; false: in descending order.</param>
        public static List<HtmlValueText> PopulateYears(int goBackYears, int goForwardYears, bool sortAscending)
        {
            List<HtmlValueText> yearlist = new List<HtmlValueText>();
            if (sortAscending)
            {
                for (int year = DateTimeUtil.Now.Year - goBackYears; year <= DateTimeUtil.Now.Year + goForwardYears; year++)
                {
                    PopulateYears(yearlist, year);
                }
            }
            else
            {
                for (int year = DateTimeUtil.Now.Year + goForwardYears; year >= DateTimeUtil.Now.Year - goBackYears; year--)
                {
                    PopulateYears(yearlist, year);
                }
            }
            return yearlist;
        }

        private static void PopulateYears(List<HtmlValueText> yearlist, int year)
        {
            HtmlValueText item = new HtmlValueText(year.ToString(), year.ToString());
            yearlist.Add(item);
        }

        /// <summary>Gets a date that represents the first day of a quarter in a year.</summary>
        /// <param name="year">This year.</param>
        /// <param name="quarter">The quarter.</param>
        /// <returns>The date with the first day of the quarter the [dateTime] belongs to.</returns>
        public static DateTime GetFirstDayOfQuarter(int year, int quarter)
        {
            DateTime dateTime = DateTime.MinValue;

            if (quarter == 1)
            {
                dateTime = new DateTime(year, (int)Constants.Months.January, 1);
            }
            else if (quarter == 2)
            {
                dateTime = new DateTime(year, (int)Constants.Months.April, 1);
            }
            else if (quarter == 3)
            {
                dateTime = new DateTime(year, (int)Constants.Months.July, 1);
            }
            else if (quarter == 4)
            {
                dateTime = new DateTime(year, (int)Constants.Months.October, 1);
            }

            return dateTime;
        }

        /// <summary>Returns the quarter of the year based on the month. Three months constitute a quarter.</summary>
        /// <param name="month">The month of an year.</param>
        /// <returns>The quarter of the month. If the month is an invalid month it returns 0.</returns>
        public static int GetQuarterNumber(int month)
        {
            if (month >= (int)Constants.Months.January && month <= (int)Constants.Months.March)
            {
                return 1;
            }
            else if (month >= (int)Constants.Months.April && month <= (int)Constants.Months.June)
            {
                return 2;
            }
            else if (month >= (int)Constants.Months.July && month <= (int)Constants.Months.September)
            {
                return 3;
            }
            else if (month >= (int)Constants.Months.October && month <= (int)Constants.Months.December)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>Gets a date that represents the last day of a quarter within the quarter.</summary>
        /// <param name="year">The year.</param>
        /// <param name="quarter">The quarter.</param>
        /// <returns>The date with the last day of the quarter [quarter] in the year [year].</returns>
        public static DateTime GetLastDayOfQuarter(int year, string quarter)
        {
            DateTime dateTime = DateTime.MaxValue;

            if (quarter == LookupTable.LookupTable_Quarter.JanuaryFebruaryMarchQ1)
            {
                dateTime = new DateTime(year, (int)Constants.Months.March, 31);
            }
            else if (quarter == LookupTable.LookupTable_Quarter.AprilMayJuneQ2)
            {
                dateTime = new DateTime(year, (int)Constants.Months.June, 30);
            }
            else if (quarter == LookupTable.LookupTable_Quarter.JulyAugustSeptemberQ3)
            {
                dateTime = new DateTime(year, (int)Constants.Months.September, 30);
            }
            else if (quarter == LookupTable.LookupTable_Quarter.OctoberNovemberDecemberQ4)
            {
                dateTime = new DateTime(year, (int)Constants.Months.December, 31);
            }
            return dateTime;
        }


        /// <summary>
        /// Returns the quarter number for the given quarter
        /// Input can be Q1/Q2/Q3/Q4
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int GetQuarterNumber(string quarter)
        {
            switch (quarter)
            {
                case LookupTable.LookupTable_Quarter.JanuaryFebruaryMarchQ1:
                    return 1;

                case LookupTable.LookupTable_Quarter.AprilMayJuneQ2:
                    return 2;

                case LookupTable.LookupTable_Quarter.JulyAugustSeptemberQ3:
                    return 3;

                case LookupTable.LookupTable_Quarter.OctoberNovemberDecemberQ4:
                    return 4;
            }

            return 0;
        }
    }
}
