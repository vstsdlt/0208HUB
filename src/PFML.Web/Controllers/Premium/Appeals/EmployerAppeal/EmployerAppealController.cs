using FACTS.Framework.Web;
using PFML.Shared.LookupTable;
using PFML.Shared.Model.DbDtos;
using PFML.Shared.ViewModels.Premium.Appeals.EmployerAppeal;
using System;

namespace PFML.Web.Controllers.Premium.Appeals.EmployerAppeal
{
    public class EmployerAppealController : Controller
    {
        /// <summary>
        /// Method executes during page load
        /// </summary>
        public void MachineExecute()
        {
            //Initialize EmployerAppeal object 
            Machine["AppealDetails"] = new EmployerAppealViewModel();
            Machine["PhysicalAddress"] = new AddressLinkDto() { Address = new AddressDto() { StateCode = LookupTable_StatePrvnc.Washington, CountryCode = LookupTable_Country.UnitedStates }, AddressTypeCode = LookupTable_AddressType.Physical };

        }

        #region UI Validations
        public void EnterInformationNext()
        {
         ValidateEmail(Machine["AppealDetails.AddressLinkDto.Address.Email"]?.ToString(), Machine["ReEnterEmail"]?.ToString());
        }
        #endregion

        #region Misc Methods
        /// <summary>
        /// Validate Email address
        /// </summary>
        /// <param name="email"></param>
        /// <param name="reEmail"></param>
        private static void ValidateEmail(string email, string reEmail)
        {
            if ((reEmail != null && email == null) || (email != null && !email.Equals(reEmail, StringComparison.OrdinalIgnoreCase)))
            {
                Context.ValidationMessages.AddError("'E-Mail' and 'Re-Enter E-Mail' must be same.");
            }
        }
        #endregion
    }


}