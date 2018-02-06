using System;
using System.Collections.Generic;
using System.Linq;
using FACTS.Framework.Web;
using FACTS.Framework.Lookup;
using FACTS.Framework.Support;
using PFML.Shared.LookupTable;
using FACTS.Framework.Utility;

namespace PFML.Web.Controllers.ControlLibraryTest
{

    public class ControlLibraryTestController : Controller
    {

        private Random random = new Random();

        public Microsoft.AspNetCore.Mvc.IActionResult Sample(int id)
        {
            return new Microsoft.AspNetCore.Mvc.ContentResult { Content = "https://www.google.com/?q=test123" };
        }

        public void MachineExecute()
        {
            Machine.SetMetadata("TabGroup", "tabGroup1", "activeTab", "tab1_2");
            Machine.InitMetadata("Basic", "panelBulletedList", "collapsed", "true");
            Machine.InitMetadata("Basic", "panelButtonGroup", "collapsed", "true");
        }

        public void MenuBasicExecute()
        {
            Machine["BasicCheckBoxBool"] = false;
            Machine["BasicCheckBoxString"] = "No";
            Machine["BasicCheckBoxStringMulti"] = "";
            Machine["BasicCheckBoxArray"] = new string[0];
            Machine["BasicCheckBoxList"] = new List<string>();

            Machine["BasicRadioButtonBool"] = false;
            Machine["BasicRadioButtonString"] = "No";
            Machine["BasicRadioButtonMulti"] = "One";

            Machine["BasicBulletedListData"] = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

            Machine["BasicDropDownList3"] = null;
            Machine["BasicDropDownList4"] = null;




            Random random = new Random();

            int valueIndex = 0;
            List<HtmlValueText> values = LookupUtil.GetValues(LookupTable.State, null, null, null);

            List<DataTableSimpleRecord> dataTableSimpleRecords = new List<DataTableSimpleRecord>();
            for (int i = 0; i < 10; i++)
            {
                if (valueIndex >= values.Count)
                {
                    valueIndex = 0;
                }
                DataTableSimpleRecord record = new DataTableSimpleRecord { Field1 = DateTimeUtil.Now.AddDays(random.Next(-100, 100)), Field2 = i + 1, Field3 = $"Row {i + 1} - Col 3", State = values[valueIndex++].Value.ToString() };

                record.Child = new DataTableSimpleRecord();
                record.Child.Field1 = DateTimeUtil.Now;
                record.Child.Field2 = i + 1;
                record.Child.Field3 = $"Child {i + 1} - Col 3";
                record.Child.State = record.State;

                record.Children = new List<DataTableSimpleRecord>();
                for (int j = 0; j < 3; j++)
                {
                    record.Children.Add(new DataTableSimpleRecord { Field1 = DateTimeUtil.Now.AddDays(random.Next(-100, 100)), Field2 = -(j + 1), Field3 = $"Row {-(j + 1)} - Col 3", State = values[valueIndex++].Value.ToString() });
                }

                dataTableSimpleRecords.Add(record);
            }
            Machine["BasicRepeaterRecords"] = dataTableSimpleRecords;
        }

        public void MenuDataTableFilterExecute()
        {
            MenuDataTableExecute();
            Machine["DataTableSourceChild1"] = Machine["DataTableSource"];
            Machine["DataTableSourceParent2"] = Machine["DataTableSource"];
            Machine["DataTableSourceChild2"] = Machine["DataTableSource"];
        }

        public void MenuDataTableExecute()
        {
            Random random = new Random();

            int valueIndex = 0;
            List<HtmlValueText> values = LookupUtil.GetValues(LookupTable.State, null, null, null);

            List<DataTableSimpleRecord> dataTableSimpleRecords = new List<DataTableSimpleRecord>();
            for (int i = 0; i < 500; i++)
            {
                if (valueIndex >= values.Count)
                {
                    valueIndex = 0;
                }
                DataTableSimpleRecord record = new DataTableSimpleRecord { Field1 = DateTimeUtil.Now.AddDays(random.Next(-1000, 1000)), Field2 = i + 1, Field3 = $"Row {i + 1}\n-\nCol 311", State = values[valueIndex++].Value.ToString() };

                record.Child = new DataTableSimpleRecord();
                record.Child.Field1 = DateTimeUtil.Now;
                record.Child.Field2 = i + 1;
                record.Child.Field3 = $"Child {i + 1} - Col 3";
                record.Child.State = record.State;

                dataTableSimpleRecords.Add(record);
            }
            Machine["DataTableRecords"] = dataTableSimpleRecords;
            Machine["DataTableSource"] = dataTableSimpleRecords;
            MenuTransferExecute();
        }

        private string RandomString(params string[] options)
        {
            int index = random.Next(0, options.Length);
            return options[index];
        }

        public List<object> DataTableDataMethod(ref PagingFilterCriteria pagingFilterCriteria)
        {
            return null;
            //return ServiceProxies.ControlLibraryTest.ControlLibraryTestProxy.ExamplePersonDataTableData(ref pagingFilterCriteria);
        }

        public void MenuFormatExecute()
        {
            Machine["FormatCurrency"] = 1234.56m;
            Machine["FormatDate"] = new DateTime(1974, 12, 22);
            Machine["FormatDateTime"] = new DateTime(1974, 12, 22, 1, 23, 45, 678);
            Machine["FormatEmail"] = "email@email.com";
            Machine["FormatFein"] = "011234567";
            Machine["FormatItin"] = "900701234";
            Machine["FormatNumber"] = 1234.56m;
            Machine["FormatPercent"] = 1234.56m;
            Machine["FormatPhone"] = "2345678910";
            Machine["FormatPostal"] = "123456789";
            Machine["FormatSsn"] = "123121234";
            Machine["FormatSsnOrItin"] = "123121234";
            Machine["FormatTextAlpha"] = "abcXYZ";
            Machine["FormatTextAlphaNumeric"] = "abcXYZ123";
            Machine["FormatTextNumeric"] = "123";
            Machine["FormatTime"] = new DateTime(1, 1, 1, 1, 23, 45, 678);
        }

        public void MenuLayoutExecute()
        {
            Machine["LayoutBulletedListData"] = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        }

        public void MenuLookupExecute()
        {
            Machine["LookupBasic"] = "FL";
            Machine["LookupBasicCheckBox"] = "FL";
            Machine["LookupBasicRadioButton"] = "FL";
            Machine["LookupInt"] = 2071;
        }

        public void MenuTransferExecute()
        {
            Machine["TransferOne"] = "TransferOne";
            Machine["TransferTwo"] = new DataTableSimpleRecord { Field1 = DateTimeUtil.Now };
        }

        public void ValidateServiceErrorExecute()
        {
            Machine["ValidateServiceType"] = "E";
            Context.ValidationMessages.AddError("Presentation Tier error message");
            Context.ValidationMessages.AddCritical("Presentation Tier critical message");
        }

        public void ValidateServiceWarningExecute()
        {
            Machine["ValidateServiceType"] = "W";
            Context.ValidationMessages.AddWarning("Presentation Tier warning message");
        }

        public void ValidateServiceInformationExecute()
        {
            Machine["ValidateServiceType"] = "I";
            Context.ValidationMessages.AddInformation("Presentation Tier information message");
        }

        public string[] LookupFilterStateEnumerable()
        {
            return new[] { LookupTable_State.NewMexico, LookupTable_State.Maryland, LookupTable_State.Kansas, LookupTable_State.Alabama, LookupTable_State.Minnesota, LookupTable_State.California, LookupTable_State.Massachusetts, LookupTable_State.Florida };
        }

        public string[] LookupFilterStateParamEnumerable(string code)
        {
            return new[] { code };
        }

        public void SecurityFilter()
        {
            Machine["SecurityFilterTextBoxTextBoxArea"] = "Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... Example test... ";
        }

        public bool SecurityFilterCheck(string value)
        {
            return (value == "ACTIVE");
        }

        public void AllRecords()
        {
            Machine["DataTableSource"] = Machine["DataTableRecords"];
        }

        public void OneRecord()
        {
            Machine["DataTableSource"] = ((List<DataTableSimpleRecord>)Machine["DataTableRecords"]).Take(1).ToList();
        }

        public void NoRecords()
        {
            Machine["DataTableSource"] = new List<DataTableSimpleRecord>();
        }

        public void DataTableRefresh()
        {
        }

    }

    [Serializable]
    public class DataTableSimpleRecord
    {
        public DateTime Field1 { get; set; }
        public decimal Field2 { get; set; }
        public string Field3 { get; set; }
        public string State { get; set; }
        public DataTableSimpleRecord Child { get; set; }
        public List<DataTableSimpleRecord> Children { get; set; }
    }

    [Serializable]
    public class ContributionHistoryItem
    {
        public int ReportedAgencyNum { get; set; }
        public string SelectInd { get; set; }
        public string ReportedPlanCode { get; set; }
        public string WorkPeriodCode { get; set; }
        public DateTime CheckMonthDate { get; set; }
        public DateTime ReportMonthDate { get; set; }
        public decimal SalaryAmt { get; set; }
        public decimal EmployerContribAmt { get; set; }
        public decimal EmployeeContribAmt { get; set; }
        public string StatusCode { get; set; }
        public string ErrorTypeCode { get; set; }
        public string SourceCode { get; set; }
        public string PositionNum { get; set; }
        public string ClassCode { get; set; }
        public string AdjTypeCode { get; set; }
        public string ReportTypeCode { get; set; }
        public string NewHireTransInd { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string MandatoryOrpInd { get; set; }
        public string QCStatusCode { get; set; }
        public decimal AnnualLeaveHour { get; set; }
        public string DepartmentNum { get; set; }
        public string EmailAddress { get; set; }
        public string Line1Address { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }
        public string ZipText { get; set; }
        public string FiscalYear { get; set; }
    }

}
