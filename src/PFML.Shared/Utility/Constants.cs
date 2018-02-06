using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFML.Shared.Utility
{
    public static class Constants
    {
        /// <summary>Enumeration for expanded month names of an year</summary>
        public enum Months
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        };

        /// <summary>Enumeration for date entity. It could be a month, a year, a day, a hour, a minute, a second, etc.</summary>
        public enum DateTimeEntityType
        {
            Year,
            Month,
            Week,
            Day,
            Hour,
            Minute,
            Second,
            MilliSecond,
            DayOfMonth,
            DayOfWeek,
            DayOfYear,
            HourOfDay
        };

        public const int DefaultUnitId = 1;
        public const string January12thoftheMonth = "12th of the Month January";
        public const string February12thoftheMonth = "12th of the Month February";
        public const string March12thoftheMonth = "12th of the Month March";
        public const string April12thoftheMonth = "12th of the Month April";
        public const string May12thoftheMonth = "12th of the Month May";
        public const string June12thoftheMonth = "12th of the Month June";
        public const string July12thoftheMonth = "12th of the Month July";
        public const string August12thoftheMonth = "12th of the Month August";
        public const string September12thoftheMonth = "12th of the Month September";
        public const string October12thoftheMonth = "12th of the Month October";
        public const string November12thoftheMonth = "12th of the Month November";
        public const string December12thoftheMonth = "12th of the Month December";

        public const string StatusCode_UnPaid = "UNPD";
        public const string TypeCode_OUUU = "OUUU";
        public const string PaymentAmount_Partial = "Partial";
        public const string PaymentAmount_Full = "Full";
        public const string PaymentMethod_Online = "Online";
        public const string PaymentMethod_Paper = "Paper";
        public const string DueDateDetailsText = "Quarter 1 - April 30<br/>Quarter 2 - July 31<br/>Quarter 3 - October 31<br/>Quarter 4 - January 31";
        public const string PrepaymentDueDates = "10 calendar days after the start of the quarter";
        public const string ChecksPayableAt = "State Workforce Solutions";
        public const string MailingAddress = "PO BOX 2281 Seattle, WA 87103";
        public const string Payment_Staus_Paid = "PAID";
        public const string Payment_Status_Pending = "PEND";
        public const string Payment_Status_Processed = "PROC";
        public const string Employer_Account_Number = "XXXXX (must be written on check)";
        public const string Payment_Verification_Message = @"By paying your bill by way of this online service, you are authorizing the State to charge your {0} account for the amount you submitted.";
        public const string Bank_AccountType_Text_Saving = "Savings";
        public const string Bank_AccountType_Text_Checking = "Checking";

    }
}
