using FACTS.Framework.Lookup;
using FACTS.Framework.Support;
using FACTS.Framework.Utility;
using FACTS.Framework.Web;
using PFML.Shared.LookupTable;
using PFML.Shared.Utility;
using PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission;
using System;
using System.Collections.Generic;
using System.Linq;
using static PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission.WageSubmissionViewModel;

namespace PFML.Web.Controllers.Premium.WageDetail.WageSubmission
{
    public class WageSubmissionController : Controller
    {
        #region Page Load
        /// <summary>
        /// Method executes during page load
        /// </summary>
        public void MachineExecute()
        {
            Machine["ListSection"] = LookupUtil.GetValues(LookupTable.WizEmployerWageFiling, null, "{DisplaySortOrder}", null);
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerWageFiling, LookupTable_WizEmployerWageFiling.SelectFilingMethod);

            Machine["ShowHeader"] = true;
            Machine["ReportingYearList"] = DateUtil.PopulateYears(Convert.ToInt16(LookupTable_WageDetailUnitYears.YearsForWageFiling), 0, false);

            //Set Default Values for Year and Quarter
            SetReportingYearAndQuarterDefaultValues();
        }

        /// <summary>
        /// Method executes during page load for Confirmation Page
        /// </summary>
        public void WageDetailConfirmationExecute()
        {
            Machine["ReportingQuatertoDispay"] = LookupUtil.GetLookupCode(LookupTable.Quarter, Machine["WageUnitDetail.ReportingQuarter"].ToString()).Display;
        }

        #endregion

        #region Wizard Navigation methods
        public void DetailedSummaryNext()
        {
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerWageFiling, LookupTable_WizEmployerWageFiling.ProcessandCalculate);
        }

        public void DetailedSummaryPrevious()
        {
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerWageFiling, LookupTable_WizEmployerWageFiling.SubmitWageInformation);
        }

        public void ProcessAndCalculateTaxPrevious()
        {
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerWageFiling, LookupTable_WizEmployerWageFiling.ConfirmSubmission);
        }

        public void SelectFilingMethodNext()
        {
            int currentQtr = Convert.ToInt16(DateUtil.GetQuarterNumber(DateTimeUtil.Now.Month));
            DateTime subjDt = DateTimeUtil.Now;
            int selYr = Convert.ToInt16(Machine["WageUnitDetail.ReportingYear"]);
            int selQtr = Convert.ToInt16(Machine["WageUnitDetail.ReportingQuarter"].ToString().Remove(0, 1));

            if (subjDt.Year <= selYr && currentQtr < selQtr)
            {
                Context.ValidationMessages.AddError("Submission not allowed for future quarter.");
                return;
            }
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerWageFiling, LookupTable_WizEmployerWageFiling.SubmitWageInformation);
        }

        /// <summary>
        /// Method executes on Click of Next button on Manual Entry Screen
        /// </summary>
        public void ManualEntryNext()
        {
            WageSubmissionViewModel wageSubmissionViewModel = new WageSubmissionViewModel
            {
                ListWageUnitDetailDto = (List<WageUnitCustomDto>)Machine["WageUnitDetail.ListWageUnitDetailDto"]
            };

            if (!wageSubmissionViewModel.ListWageUnitDetailDto.Any(x => x.Ssn!=null))
            {
                Context.ValidationMessages.AddError("Please enter atleast one valid record.");
            }

            ValidateDuplicateSSN(wageSubmissionViewModel);

            //Validates Row information in Editable grid
            foreach (var wageUnitDetail in wageSubmissionViewModel.ListWageUnitDetailDto)
            {
                ValidateRowInformation(wageUnitDetail);
            }
            if (Context.ValidationMessages.Count(ValidationMessageSeverity.Error) > 0)
            {
                return;
            }
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerWageFiling, LookupTable_WizEmployerWageFiling.ConfirmSubmission);
        }

        public void ManualEntryPrevious()
        {
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerWageFiling, LookupTable_WizEmployerWageFiling.SelectFilingMethod);
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Set Default Values for Year and Quater Selectbox.
        /// </summary>
        public void SetReportingYearAndQuarterDefaultValues()
        {
            Machine["WageFilingDefaultQuarter"] = DateUtil.GetQuarter(DateTimeUtil.Now.Month);
            Machine["WageFilingDefaultYear"] = Convert.ToString(DateTimeUtil.Now.Year);
        }

        #endregion

        #region UI Validations
        /// <summary>
        ///  Validates Add' functionality step
        /// </summary>
        public void ManualEntryAdd()
        {
            WageSubmissionViewModel wageSubmissionViewModel = (WageSubmissionViewModel)Machine["WageUnitDetail"];

         
           if (wageSubmissionViewModel.ListWageUnitDetailDto.Any(x=>x.Ssn is null))
            { 
                    Context.ValidationMessages.AddError("You must complete page in full, before selecting 'Add'. If you have finished adding employees select 'Next'.");
                    return;
            }

            int rowCount = wageSubmissionViewModel.ListWageUnitDetailDto.Count;

            for (int i = rowCount + 1; i <= rowCount + 25; i++)
            {
                WageUnitCustomDto wageUnitDetailDto = new WageUnitCustomDto
                {
                    SrNo = i,
                    EmployerId = wageSubmissionViewModel.Employer.EmployerId,
                    Employer = wageSubmissionViewModel.Employer
                };
                wageSubmissionViewModel.ListWageUnitDetailDto.Add(wageUnitDetailDto);
            }
            Machine["WageUnitDetail.ListWageUnitDetailDto"] = wageSubmissionViewModel.ListWageUnitDetailDto;
        }

        /// <summary>
        /// Validates Duplicate SSN
        /// </summary>
        /// <param name="wageSubmissionViewModel"></param>
        private void ValidateDuplicateSSN(WageSubmissionViewModel wageSubmissionViewModel)
        {
            foreach (var wageUnitDetail in wageSubmissionViewModel.ListWageUnitDetailDto)
            {
                if (wageSubmissionViewModel.ListWageUnitDetailDto.Any((x => (x.Ssn != null) && (x.Ssn == wageUnitDetail.Ssn) &&
                (x.EmployerUnitId == wageUnitDetail.EmployerUnitId) && x.SrNo != wageUnitDetail.SrNo)))
                {
                    Context.ValidationMessages.AddError($"Duplicate Social Security Number {wageUnitDetail.Ssn} within Unit {wageUnitDetail.EmployerUnitId} on line {wageUnitDetail.SrNo}.");
                }
            }
        }

        /// <summary>
        /// Validates whether SSN is present in the row
        /// </summary>
        /// <param name="wageUnitDetail"></param>
        private void ValidateSSN(WageUnitCustomDto wageUnitDetail)
        {
            if ((String.IsNullOrWhiteSpace(wageUnitDetail.Ssn))
                && (!String.IsNullOrWhiteSpace(wageUnitDetail.LastName) || !String.IsNullOrWhiteSpace(wageUnitDetail.FirstName) ||
                !String.IsNullOrWhiteSpace(wageUnitDetail.Occupation)|| wageUnitDetail.HoursWorked>0 || wageUnitDetail.WageAmount>0))
            {
                Context.ValidationMessages.AddError($"Missing SSN on line {wageUnitDetail.SrNo}.");
            }

        }

        /// <summary>
        /// Validates Missing Last Name
        /// </summary>
        /// <param name="wageUnitDetail"></param>
        private void ValidateLastName(WageUnitCustomDto wageUnitDetail)
        {
            if ((String.IsNullOrWhiteSpace(wageUnitDetail.LastName)) && (!String.IsNullOrWhiteSpace(wageUnitDetail.Ssn)
                || !String.IsNullOrWhiteSpace(wageUnitDetail.FirstName) 
                || !String.IsNullOrWhiteSpace(wageUnitDetail.Occupation)||wageUnitDetail.HoursWorked > 0||wageUnitDetail.WageAmount > 0))
            {
                Context.ValidationMessages.AddError($"Missing Last Name on line {wageUnitDetail.SrNo}.");
            }

        }

        /// <summary>
        /// Validates Missing Last Name
        /// </summary>
        /// <param name="wageUnitDetail"></param>
        private void ValidateFirstName(WageUnitCustomDto wageUnitDetail)
        {
            if ((String.IsNullOrWhiteSpace(wageUnitDetail.FirstName)) && (!String.IsNullOrWhiteSpace(wageUnitDetail.Ssn)
                || !String.IsNullOrWhiteSpace(wageUnitDetail.LastName)
                || !String.IsNullOrWhiteSpace(wageUnitDetail.Occupation) || wageUnitDetail.HoursWorked > 0 || wageUnitDetail.WageAmount > 0))
            {
                Context.ValidationMessages.AddError($"Missing First Name on line {wageUnitDetail.SrNo}.");
            }

        }

        /// <summary>
        /// Validates Missing Occupation
        /// </summary>
        /// <param name="wageUnitDetail"></param>
        private void ValidateOccupation(WageUnitCustomDto wageUnitDetail)
        {
            if ((String.IsNullOrWhiteSpace(wageUnitDetail.Occupation)) && (!String.IsNullOrWhiteSpace(wageUnitDetail.Ssn)
                || !String.IsNullOrWhiteSpace(wageUnitDetail.LastName)
                || !String.IsNullOrWhiteSpace(wageUnitDetail.FirstName) || wageUnitDetail.HoursWorked > 0 || wageUnitDetail.WageAmount > 0))
            {
                Context.ValidationMessages.AddError($"Missing Occupation on line {wageUnitDetail.SrNo}.");
            }

        }


        /// <summary>
        /// Validates Missing Hours Worked
        /// </summary>
        /// <param name="wageUnitDetail"></param>
        private void ValidateHoursWorked(WageUnitCustomDto wageUnitDetail)
        {
            if ((wageUnitDetail.HoursWorked==0) && (!String.IsNullOrWhiteSpace(wageUnitDetail.Ssn)
                || !String.IsNullOrWhiteSpace(wageUnitDetail.LastName)
                || !String.IsNullOrWhiteSpace(wageUnitDetail.FirstName) || !String.IsNullOrWhiteSpace(wageUnitDetail.Occupation) || wageUnitDetail.WageAmount > 0))
            {
                Context.ValidationMessages.AddError($"Missing Hours Worked on line {wageUnitDetail.SrNo}.");
            }

        }

        /// <summary>
        /// Validates Gross Wages
        /// </summary>
        /// <param name="wageUnitDetail"></param>
        private void ValidateGrossWages(WageUnitCustomDto wageUnitDetail)
        {
            if ((wageUnitDetail.WageAmount == 0) && (!String.IsNullOrWhiteSpace(wageUnitDetail.Ssn)
               || !String.IsNullOrWhiteSpace(wageUnitDetail.LastName)
               || !String.IsNullOrWhiteSpace(wageUnitDetail.FirstName) || !String.IsNullOrWhiteSpace(wageUnitDetail.Occupation)
               || wageUnitDetail.HoursWorked > 0))
            {
                Context.ValidationMessages.AddError($"Missing Gross Wages on line {wageUnitDetail.SrNo}.");
            }
            if (wageUnitDetail.WageAmount > Convert.ToDecimal(999999999.99))
            {
                Context.ValidationMessages.AddError($"Gross Wages cannot exceed 999999999.99 on line {wageUnitDetail.SrNo}.");
            }
        }

        /// <summary>
        /// Validate Row information
        /// </summary>
        /// <param name="wageUnitDetail"></param>
        private void ValidateRowInformation(WageUnitCustomDto wageUnitDetail)
        {
            ValidateSSN(wageUnitDetail);
            ValidateFirstName(wageUnitDetail);
            ValidateLastName(wageUnitDetail);
            ValidateHoursWorked(wageUnitDetail);
            ValidateOccupation(wageUnitDetail);
            ValidateGrossWages(wageUnitDetail);
           
        }
        #endregion
    }
}
