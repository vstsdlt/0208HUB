using FACTS.Framework.Lookup;
using FACTS.Framework.Service;
using PFML.Shared.LookupTable;
using PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission;
using System;
using System.Collections.Generic;
using System.Linq;
using DbContext = PFML.DAL.Model.DbContext;
using PFML.DAL.Model.DbEntities;
using FACTS.Framework.Utility;
using PFML.Shared.Utility;

namespace PFML.BusinessLogic.Premium.WageDetail
{

    public static class WageSubmissionLogic
    {

        /// <summary>
        /// Get Wage Period details.
        /// </summary>
        /// <returns></returns>
        [OperationMethod]
        public static WageSubmissionViewModel GetWagePeriod()
        {
            WageSubmissionViewModel wageDetail = new WageSubmissionViewModel
            {
                ReportingYear = (short)DateTimeUtil.Now.Year,
                ContributionRate = GetCurrentContributionRate()
            };
            using (DbContext context = new DbContext())
            {
                //To do Map the Employerid from context.
                wageDetail.Employer = context.Employers.FirstOrDefault().ToDto();
            }
            for (int i = 1; i <= 25; i++)
            {
                WageSubmissionViewModel.WageUnitCustomDto wageUnitDetailDto = new WageSubmissionViewModel.WageUnitCustomDto
                {
                    SrNo = i,
                    EmployerId = wageDetail.Employer.EmployerId,
                    Employer = wageDetail.Employer
                };
                wageDetail.ListWageUnitDetailDto.Add(wageUnitDetailDto);
            }
            return wageDetail;
        }

        /// <summary>
        /// Validate Wage Submission Method
        /// </summary>
        /// <param name="wageDetail"></param>
        /// <returns></returns>
        [OperationMethod]
        public static WageSubmissionViewModel ValidateSelectionMethod(WageSubmissionViewModel wageDetail)
        {
            using (DbContext context = new DbContext())
            {
                if (context.TaxableAmountSums.Any(x => x.ReportingQuarter == wageDetail.ReportingQuarter && x.ReportingYear == wageDetail.ReportingYear && x.EmployerId == wageDetail.Employer.EmployerId))
                {
                    Context.ValidationMessages.AddError($"Original Employment and Wage Detail Report for this year  {wageDetail.ReportingYear} and quarter " + LookupUtil.GetValue(LookupTable.Quarter, wageDetail.ReportingQuarter)+ " has already been submitted.");
                }
            }

            wageDetail.AdjReasonDisplay = LookupUtil.GetValue(LookupTable.WageDetailAdjReasonCode, LookupTable_WageDetailAdjReasonCode.Original);
            wageDetail.AdjReasonCode = LookupTable_WageDetailAdjReasonCode.Original;

            return wageDetail;
        }

        /// <summary>
        /// Validate Manual Entry Submission
        /// </summary>
        /// <param name="wageDetail"></param>
        /// <returns></returns>
        [OperationMethod]
        public static WageSubmissionViewModel ValidateAndCalculateGrossWages(WageSubmissionViewModel wageDetail)
        {
            wageDetail.ListWageEmployerUnitSummary = new List<WageSubmissionViewModel.WageDetailSummaryViewModel>();
            wageDetail.FilingMethod = LookupTable_WageDetailFilingMethod.ManualEntry;
            foreach (var wageUnitDetail in wageDetail.ListWageUnitDetailDto)
            {
                if (wageUnitDetail.Ssn != null)
                {
                    wageUnitDetail.FilingMethod = wageDetail.FilingMethod;
                    wageUnitDetail.AdjReasonCode = wageDetail.AdjReasonCode;
                    wageUnitDetail.ReportingQuarter = wageDetail.ReportingQuarter;
                    wageUnitDetail.ReportingYear = wageDetail.ReportingYear;
                    wageUnitDetail.FilingMethod = wageDetail.FilingMethod;
                    wageUnitDetail.EmployerUnitId = Constants.DefaultUnitId;
                }
            }
           
            foreach (var unit in wageDetail.ListWageUnitDetailDto.Select(x => x.EmployerUnitId).Distinct())
            {
                if (unit > 0)
                {
                    Decimal grossWage = wageDetail.ListWageUnitDetailDto.Where(x => x.EmployerUnitId == unit).Select(x => x.WageAmount).Sum();
                    int NumberofRecords = wageDetail.ListWageUnitDetailDto.Count(x => x.Ssn != null && x.EmployerUnitId == unit);
                    wageDetail.ListWageEmployerUnitSummary.Add(new WageSubmissionViewModel.WageDetailSummaryViewModel
                    { EmployerUnitNo = unit, EntityName = wageDetail.Employer.EntityName, NumberofRecords = NumberofRecords, GrossWage = grossWage});
                }
            }
            wageDetail.GrossWages = wageDetail.ListWageEmployerUnitSummary.Select(x => x.GrossWage).Sum();
            wageDetail.NumberofRecords = wageDetail.ListWageUnitDetailDto.Count(x => x.Ssn != null);
            wageDetail.EmployerAccountTransactionDto.OwedAmount = (wageDetail.GrossWages)*(wageDetail.ContributionRate)*0.01m;
            wageDetail.EmployerAccountTransactionDto.UnpaidAmount = wageDetail.EmployerAccountTransactionDto.OwedAmount;
            return wageDetail;
        }

        /// <summary>
        /// Validate and Calculate Tax
        /// </summary>
        /// <param name="wageDetail"></param>
        /// <returns></returns>
        [OperationMethod]
        public static WageSubmissionViewModel CalculateAndSavePremiumData(WageSubmissionViewModel wageDetail)
        {

            wageDetail.EmployerAccountTransactionDto.EmployerId = wageDetail.Employer.EmployerId;
            wageDetail.EmployerAccountTransactionDto.ReportingQuarter = wageDetail.ReportingQuarter;
            wageDetail.EmployerAccountTransactionDto.ReportingYear = wageDetail.ReportingYear;
            wageDetail.EmployerAccountTransactionDto.TypeCode = LookupTable_TransactionType.ContributionsPrinciple;
            wageDetail.EmployerAccountTransactionDto.StatusCode = LookupTable_PaymentStatus.PaymentStatusUnpaid;
            wageDetail.EmployerAccountTransactionDto.DueDate = DateTimeUtil.Now.AddDays(Convert.ToDouble(LookupTable_PremiumPaymentDueDays.PremiumPaymentDueDays));

            wageDetail.TaxableAmountSumDto.EmployerId = wageDetail.Employer.EmployerId;
            wageDetail.TaxableAmountSumDto.ReportingQuarter = wageDetail.ReportingQuarter;
            wageDetail.TaxableAmountSumDto.ReportingYear = wageDetail.ReportingYear;
            wageDetail.TaxableAmountSumDto.StatusCode = LookupTable_TaxableAmSumStatus.Submitted;
            int quaterNumber = Convert.ToInt16(wageDetail.ReportingQuarter.ToString().Remove(0, 1));
            if (quaterNumber == 1)
            {
                wageDetail.TaxableAmountSumDto.Quarter1TaxableAmt = wageDetail.GrossWages;
                wageDetail.TaxableAmountSumDto.Quarter1GrossAmt = wageDetail.GrossWages;
            }
            if (quaterNumber == 2)
            {
                wageDetail.TaxableAmountSumDto.Quarter2TaxableAmt = wageDetail.GrossWages;
                wageDetail.TaxableAmountSumDto.Quarter2GrossAmt = wageDetail.GrossWages;
            }
            if (quaterNumber == 3)
            {
                wageDetail.TaxableAmountSumDto.Quarter3TaxableAmt = wageDetail.GrossWages;
                wageDetail.TaxableAmountSumDto.Quarter3GrossAmt = wageDetail.GrossWages;
            }
            if (quaterNumber == 4)
            {
                wageDetail.TaxableAmountSumDto.Quarter4TaxableAmt = wageDetail.GrossWages;
                wageDetail.TaxableAmountSumDto.Quarter4GrossAmt = wageDetail.GrossWages;
            }


            using (DbContext context = new DbContext())
            {
                    foreach (var wageUnitDetails in wageDetail.ListWageUnitDetailDto.Where(x => x.Ssn != null))
                    {
                        //To Do : Need to check 
                        wageUnitDetails.Employer = null;
                        WageUnitDetail.FromDto(context, wageUnitDetails);
                    }

                    EmployerAccountTransaction.FromDto(context, wageDetail.EmployerAccountTransactionDto);

                    TaxableAmountSum.FromDto(context, wageDetail.TaxableAmountSumDto);
                    context.SaveChanges();
            }

            return wageDetail;
        }

        #region Private Mehtods
        /// <summary>
        /// Get Current Tax Rate.
        /// </summary>
        /// <returns></returns>
        public static decimal GetCurrentContributionRate()
        {
            DateTime currentdate = DateTimeUtil.Now;
            using (DbContext context = new DbContext())
            {

                var premiumRate = (from rates in context.PremiumRates
                                   where rates.EffectiveBeginDate <= currentdate && currentdate <= rates.EffectiveEndDate
                                   select rates._PremiumRate).FirstOrDefault();


                return premiumRate;
            }
        }

        #endregion
    }


}

