using System;
using System.Collections.Generic;
using System.Linq;
using FACTS.Framework.Lookup;
using FACTS.Framework.Service;
using PFML.DAL.Model;
using PFML.DAL.Model.DbEntities;
using PFML.Shared.LookupTable;
using PFML.Shared.Model.DbDtos;
using PFML.Shared.Utility;
using PFML.Shared.ViewModels.Premium.Payments.MakePayment;

namespace PFML.BusinessLogic.Premium.MakePayment
{
    public static class MakePaymentLogic
    {


        /// <summary>
        /// This method deletes the old Payment Profile
        /// if user wishes to save the new Payment Profile Info
        /// </summary>
        /// <param name="paymentProfileDetails"></param>
        private static void DeletePreviousPaymentProfile(PaymentProfileDto paymentProfileDetails)
        {
            using (DbContext context = new DbContext())
            {
                context.PaymentProfiles.RemoveRange(context.PaymentProfiles.AsEnumerable().Where(x => x.EmployerId == paymentProfileDetails.EmployerId));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// This method will fetch the Employer details, payment details on the basis of Employer ID
        /// </summary>
        /// <param name="EmployerID"></param>
        /// <returns></returns>
        [OperationMethod]
        public static MakePaymentViewModel GetEmployerDueAmount(int EmployerID)
        {
            var localPaymentViewModel = new MakePaymentViewModel();
            try
            {
                using (var context = new DbContext())
                {

                    if (context.Employers.FirstOrDefault() is null)
                    {
                        return localPaymentViewModel;
                    }

                    EmployerID = context.Employers.FirstOrDefault().EmployerId;

                    #region Filling Employee DTO

                    var localEmployerDto = context.Employers.FirstOrDefault()?.ToDto();
                    localPaymentViewModel.EmployerDto = localEmployerDto;

                    #endregion

                    #region Filling Employer Account Transaction

                    IOrderedEnumerable<EmployerAccountTransaction> localEmployerAccountTransactionItems = context.EmployerAccountTransactions.AsEnumerable().Where(x => x.EmployerId == EmployerID).OrderByDescending(y => y.EmployerId);
                    var colEmployerAccountTransactionDto = new List<EmployerAccountTransactionDto>();
                    colEmployerAccountTransactionDto.AddRange((localEmployerAccountTransactionItems.Select(x => x.ToDto())));
                    localPaymentViewModel.CollectionEmployerAccountTransactionDto = colEmployerAccountTransactionDto;

                    #endregion

                    #region Filling Payment Main

                    IOrderedEnumerable<PaymentMain> localPaymentMainDtoItems = context.PaymentMains.AsEnumerable().Where(x => x.EmployerId == EmployerID).OrderByDescending(y => y.PaymentMainId);
                    var colPaymentMainDto = new List<PaymentMainDto>();
                    colPaymentMainDto.AddRange((localPaymentMainDtoItems.Select(x => x.ToDto())));
                    localPaymentViewModel.CollectionPaymentMainDto = colPaymentMainDto;

                    #endregion

                    #region Filling Payment Profile

                    IOrderedEnumerable<PaymentProfile> localPaymentProfileDtoItems = context.PaymentProfiles.AsEnumerable().Where(x => x.EmployerId == EmployerID).OrderByDescending(y => y.PaymentProfileId);
                    var colPaymentProfileDto = new List<PaymentProfileDto>();
                    colPaymentProfileDto.AddRange(localPaymentProfileDtoItems.Select(x => x.ToDto()));
                    localPaymentViewModel.CollectionPaymentProfileDto = colPaymentProfileDto;

                    #endregion

                }
                CalculateAmount(ref localPaymentViewModel);
            }
            catch (Exception)
            {
                Context.ValidationMessages.AddError("An error occured while getting the Amount Due. Please try again.");
            }

            return localPaymentViewModel;
        }

        /// <summary>
        /// This method saves Payment done into Payment table
        /// </summary>
        /// <param name="PaymentMainDetails"></param>
        /// <returns></returns>
        [OperationMethod]
        public static PaymentMainDto SavePaymentDetail(PaymentMainDto PaymentMainDetails, PaymentProfileDto PaymentProfileDetails, bool SaveBankInformation)
        {
            try
            {
                DeletePreviousPaymentProfile(PaymentProfileDetails);

                using (var context = new DbContext())
                {

                    if (SaveBankInformation)
                    {
                        var localPaymentProfile = PaymentProfile.FromDto(context, PaymentProfileDetails);
                        if (localPaymentProfile == null)
                        {
                            return null;
                        }

                        context.SaveChanges();
                    }
                    var localPaymentDetail = PaymentMain.FromDto(context, PaymentMainDetails);
                    context.SaveChanges();
                    return localPaymentDetail.ToDto();
                }
            }
            catch (Exception)
            {
                Context.ValidationMessages.AddError("An error occured during 'Saving Payment'. Please try again.");
            }
            return default(PaymentMainDto);
        }

        #region Private Methods


        /// <summary>
        /// Calculate Amount Due and Pre Payment Amount
        /// </summary>
        /// <param name="localPaymentViewModel"></param>
        private static void CalculateAmount(ref MakePaymentViewModel localPaymentViewModel)
        {
            var rptQtr = DateUtil.GetQuarter(DateTime.Now.Month);

            var postDatedPmtAm = GetPostDatedPayment(localPaymentViewModel, DateUtil.GetLastDayOfQuarter(Convert.ToInt16(DateTime.Now.Year), rptQtr));

            localPaymentViewModel.AmountDue = GetTransactionBalance(localPaymentViewModel, DateUtil.GetLastDayOfQuarter(Convert.ToInt16(DateTime.Now.Year), rptQtr)) - postDatedPmtAm;
            //TO DO
            localPaymentViewModel.PrePaymentAmount = 0;
        }


        /// <summary>
        /// Return Post Dated Payment Amount
        /// </summary>
        /// <param name="localPaymentViewModel"></param>
        /// <param name="quarterEndDt"></param>
        /// <returns>Return Post Dated Payment Amount</returns>
        private static decimal GetPostDatedPayment(MakePaymentViewModel localPaymentViewModel, DateTime quarterEndDt)
        {
            var colPaymentMainDetails = localPaymentViewModel.CollectionPaymentMainDto
           .Where(x => x.EmployerId == localPaymentViewModel.EmployerDto.EmployerId && (x.PaymentStatusCode == Constants.Payment_Status_Pending || x.PaymentStatusCode == Constants.Payment_Status_Processed)
                  && x.PaymentTransactionDate < quarterEndDt.AddDays(1).Date
                  && x.PaymentMethodCode == LookupUtil.GetLookupCode(LookupTable.PaymentMethodType, LookupTable_PaymentMethodType.ACHDebit).Code
                   ).ToList();
            if (colPaymentMainDetails.Count == 0)
            {
                return 0m;
            }

            return (colPaymentMainDetails.Sum(y => y.PaymentAmount) > 0) ? colPaymentMainDetails.Sum(y => y.PaymentAmount) : 0;

        }


        /// <summary>
        /// Return transaction balance for a given employer.
        /// </summary>
        /// <param name="localPaymentViewModel"></param>
        /// <param name="quarterEndDt"></param>
        /// <returns>returns transaction balance.</returns>
        public static decimal GetTransactionBalance(MakePaymentViewModel localPaymentViewModel, DateTime quarterEndDt)
        {
            var amountDetails = localPaymentViewModel
                .CollectionEmployerAccountTransactionDto
                .Where(x => x.EmployerId == localPaymentViewModel.EmployerDto.EmployerId
                       && x.CreateDateTime.Date < quarterEndDt.AddDays(1)
                        ).ToList();
            return (amountDetails.Sum(y => y.OwedAmount));
        }
        #endregion
    }
}

