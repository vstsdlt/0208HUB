using PFML.Shared.Model.DbDtos;
using System;
using System.Collections.Generic;

namespace PFML.Shared.ViewModels.Premium.Payments.MakePayment
{
    /// <summary>
    /// This class model beholds the values related to Employer Payment Details
    /// </summary>
    [Serializable]
    public class MakePaymentViewModel
    {
        public MakePaymentViewModel() => EmployerDto = new EmployerDto();

        /// <summary>
        /// Contains Employer DTO details
        /// </summary>
        public EmployerDto EmployerDto
        {
            get; set;
        }
        /// <summary>
        /// Get Pre Payment Amount Due
        /// </summary>
        public decimal PrePaymentAmount
        {
            get; set;
        }
        /// <summary>
        /// Get Amount Due 
        /// </summary>
        public decimal AmountDue
        {
            get; set;
        }

        /// <summary>
        /// Collection of Employer Account Transaction Details 
        /// </summary>
        public List<EmployerAccountTransactionDto> CollectionEmployerAccountTransactionDto
        {
            get; set;
        }

        /// <summary>
        /// Collection of Payment Details 
        /// </summary>
        public List<PaymentMainDto> CollectionPaymentMainDto
        {
            get; set;
        }

        /// <summary>
        /// Collection of Payment Profile
        /// </summary>
        public List<PaymentProfileDto> CollectionPaymentProfileDto
        {
            get; set;
        }
    }
}
