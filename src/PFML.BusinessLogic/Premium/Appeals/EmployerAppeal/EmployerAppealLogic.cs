using FACTS.Framework.Service;
using PFML.Shared.LookupTable;
using PFML.Shared.Model.DbDtos;
using PFML.Shared.ViewModels.Premium.Appeals.EmployerAppeal;
using DbContext = PFML.DAL.Model.DbContext;
using System.Linq;

namespace PFML.BusinessLogic.Premium.Appeals
{
    public static class EmployerAppealLogic
    {
        /// <summary>
        /// Validate Document Document Id.
        /// </summary>
        /// <param name="employerAppealViewModel"></param>
        /// <returns></returns>
        [OperationMethod]
        public static EmployerAppealViewModel ValidateDocumentId(EmployerAppealViewModel employerAppealViewModel)
        {
           employerAppealViewModel.AddressLinkDto= new AddressLinkDto{ Address = new AddressDto() { StateCode = LookupTable_StatePrvnc.Washington, CountryCode = LookupTable_Country.UnitedStates }, AddressTypeCode = LookupTable_AddressType.Mailing };
           return employerAppealViewModel;
        }

        /// <summary>
        /// Submit Employer Appeal.
        /// </summary>
        /// <param name="employerAppealViewModel"></param>
        /// <returns></returns>
        [OperationMethod]
        public static EmployerAppealViewModel SubmitAppeal(EmployerAppealViewModel employerAppealViewModel)
        {
            return employerAppealViewModel;
        }

       
        /// <summary>
        /// Populate address based on the selection
        /// </summary>
        /// <param name="employerAppealViewModel"></param>
        /// <returns></returns>
        [OperationMethod]
        public static EmployerAppealViewModel PopulateAddress(EmployerAppealViewModel employerAppealViewModel)
        {
            using (DbContext context = new DbContext())
            {
                //To do Map the Employerid from context.
                var addressid = context.AddressLinks.Where(e=> e.AddressTypeCode == employerAppealViewModel.AddressLinkDto.AddressTypeCode && e.EmployerId==33).Select(e=>e.AddressId).FirstOrDefault();
                employerAppealViewModel.AddressLinkDto.Address = context.Addresses.FirstOrDefault(e => e.AddressId == addressid).ToDto();
                          }
            return employerAppealViewModel;
        }
    }
}
