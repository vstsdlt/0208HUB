// ----------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a compiler emitter: FACTS.Framework.Analysis.Generators.OperationMethod.ProxyEmitter
//
// Changes to this file may cause incorrect behavior and will be lost when the code is regenerated.
// </auto-generated>
// ----------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FACTS.Framework.Web;

namespace PFML.Web.ServiceProxies.Premium.MakePayment
{

    public static class MakePaymentProxy
    {

        ///<summary>URL base path location for web service</summary>
        private const string servicePath = "Premium/MakePayment";

        ///<summary>ASYNC Web Service call: unknown</summary>
        ///<returns>ASYNC task: unknown</returns>
        public static async Task<PFML.Shared.ViewModels.Premium.Payments.MakePayment.MakePaymentViewModel> GetEmployerDueAmountAsync(int EmployerID)
        {
            using (OperationClient client = new OperationClient(servicePath, "GetEmployerDueAmount"))
            {
                client.Value = EmployerID;
                return await client.ReadAsync<PFML.Shared.ViewModels.Premium.Payments.MakePayment.MakePaymentViewModel>();
            }
        }

        ///<summary>Web Service call: unknown</summary>
        public static PFML.Shared.ViewModels.Premium.Payments.MakePayment.MakePaymentViewModel GetEmployerDueAmount(int EmployerID)
        {
            return GetEmployerDueAmountAsync(EmployerID).Result;
        }

        ///<summary>ASYNC Web Service call: unknown</summary>
        ///<returns>ASYNC task: unknown</returns>
        public static async Task<PFML.Shared.Model.DbDtos.PaymentMainDto> SavePaymentDetailAsync(PFML.Shared.Model.DbDtos.PaymentMainDto PaymentMainDetails, PFML.Shared.Model.DbDtos.PaymentProfileDto PaymentProfileDetails, bool SaveBankInformation)
        {
            using (OperationClient client = new OperationClient(servicePath, "SavePaymentDetail"))
            {
                client.Value = new { PaymentMainDetails, PaymentProfileDetails, SaveBankInformation };
                return await client.ReadAsync<PFML.Shared.Model.DbDtos.PaymentMainDto>();
            }
        }

        ///<summary>Web Service call: unknown</summary>
        public static PFML.Shared.Model.DbDtos.PaymentMainDto SavePaymentDetail(PFML.Shared.Model.DbDtos.PaymentMainDto PaymentMainDetails, PFML.Shared.Model.DbDtos.PaymentProfileDto PaymentProfileDetails, bool SaveBankInformation)
        {
            return SavePaymentDetailAsync(PaymentMainDetails, PaymentProfileDetails, SaveBankInformation).Result;
        }

    }

}
