using FACTS.Framework.Lookup;
using FACTS.Framework.Support;
using FACTS.Framework.Web;
using PFML.Shared.LookupTable;
using PFML.Shared.Model.DbDtos;
using PFML.Shared.Utility;
using PFML.Shared.ViewModels.Premium.Registration;
using System;
using System.Collections.Generic;

namespace PFML.Web.Controllers.Premium.Registration
{

    public class EmployerRegistrationController : Controller
    {
        /// <summary>
        /// Method executes during page load
        /// </summary>
        public void MachineExecute()
        {
            //used to set wizard header
            Machine["ListSection"] = LookupUtil.GetValues(LookupTable.WizEmployerRegistration, null, "{DisplaySortOrder}", null);
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterLiabilityInformation);
            Machine["ShowHeader"] = false;

            //initialize EmployerRegistration object and required address objects
            Machine["EmployerRegistration"] = new EmployerRegistrationViewModel();
            Machine["EntityAddress"] = new AddressLinkDto() { Address = new AddressDto() { StateCode = LookupTable_StatePrvnc.Washington, CountryCode = LookupTable_Country.UnitedStates }, AddressTypeCode = LookupTable_AddressType.Mailing };
            Machine["PhysicalAddress"] = new AddressLinkDto() { Address = new AddressDto() { StateCode = LookupTable_StatePrvnc.Washington, CountryCode = LookupTable_Country.UnitedStates }, AddressTypeCode = LookupTable_AddressType.Physical };
            Machine["BusinessAddress"] = new AddressLinkDto() { Address = new AddressDto() { StateCode = LookupTable_StatePrvnc.Washington, CountryCode = LookupTable_Country.UnitedStates }, AddressTypeCode = LookupTable_AddressType.Business };
            Machine["YearList"] = DateUtil.PopulateYears(Convert.ToInt16(LookupTable_WageDetailUnitYears.YearsForWageFiling), 0, false);
        }

        #region Wizard Navigation methods

        public void ValidateIntroductionNext()
        {
            Machine["ShowHeader"] = true;
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterLiabilityInformation);
        }

        public void LiabilityWagesPrevious()
        {
            Machine["ShowHeader"] = false;
        }

        public void IsLiableWeeksCheckTrue()
        {
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterUsers);
        }

        public void AdminInfoPrevious()
        {
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterLiabilityInformation);
        }

        public void ValidateAdminInfoNext()
        {
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterEmployerInformation);
        }

        public void EmpIdentificationPrevious()
        {
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterUsers);
        }

        public void EnterBusinessInfoPrevious()
        {
            Machine["IsPublicEntity"] = false;
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterEmployerInformation);
        }

        public void SubmitRegistrationNext()
        {
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.Complete);

            var employerRegistration = (EmployerRegistrationViewModel)Machine["EmployerRegistration"];
            DateTime liabilityDate = Convert.ToDateTime(employerRegistration.EmployerDto.LiabilityDate);
            int currentQuarter = ((liabilityDate.Month - 1) / 3) + 1;
            Machine["LastDayCurrentQuarter"] = new DateTime(liabilityDate.Year, 3 * currentQuarter + 1, 1).AddDays(-1);
            Machine["PremiumRate"] = $"{(employerRegistration.PremiumRateDto._PremiumRate * 100).ToString()}%";
        }

        #endregion

        #region UI Validations

        /// <summary>
        /// Validates 'Introduction' wizard step
        /// </summary>
        public void IntroductionNext()
        {
            var employerRegistration = (EmployerRegistrationViewModel)Machine["EmployerRegistration"];
            if (employerRegistration.EmployerDto.IsServiceBegin == false)
            {
                Context.ValidationMessages.AddError("You are not required to register at this time because you do not have employment in this state. Return and register once employment begins.", "EmployerRegistration.EmployerDto.IsServiceBegin");
            }
            if (employerRegistration.EmployerDto.IsServiceBegin == true && (employerRegistration.EmployerDto.ServiceBeginDate > employerRegistration.EmployerUnitDto.FirstWageDate))
            {
                Context.ValidationMessages.AddError("'If yes, enter the date this employer first paid wages to those individuals performing services in State' must be equal to or after 'If yes, enter the date services were first performed for the employer in State'.", "EmployerRegistration.EmployerUnitDto.FirstWageDate");
            }

            //check for bad or invalid fein
            var isBadFeinCheck = IsBadFein(Machine["Fein"].ToString());
            if (isBadFeinCheck.isBad)
            {
                Context.ValidationMessages.AddError("The FEIN (Federal Employer Identification Number) is invalid. It cannot contain spaces or alphabetic characters and must be an existing FEIN. Valid format is XXXXXXXXX.", "Fein");
            }
            else
            {
                Machine["EmployerRegistration.EmployerDto.Fein"] = isBadFeinCheck.feinNumeric;
            }
        }

        /// <summary>
        /// Validates 'Liability Wages' wizard step
        /// </summary>
        public void LiabilityWagesNext()
        {
            var employerRegistration = (EmployerRegistrationViewModel)Machine["EmployerRegistration"];
            List<bool?> listUserInput = new List<bool?> { employerRegistration.EmployerDto.EmployerLiability.HasPaid450RegularWages, employerRegistration.EmployerDto.EmployerLiability.HasPaid1KDomesticWages, employerRegistration.EmployerDto.EmployerLiability.HasPaid20KAgriculturalLaborWages };
            if (listUserInput.FindAll(l => l.Equals(true))?.Count >= 2)
            {
                Context.ValidationMessages.AddError("Only one answer can be Yes. Select the question that occurred first as Yes and the other(s) as No.");
            }
            else if (listUserInput.FindAll(l => l.Equals(true))?.Count >= 1)
            {
                Machine["IsLiableWages"] = true;
                Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterUsers);
            }
            else
            {
                Machine["IsLiableWages"] = false;
                employerRegistration.EmployerDto.EmployerLiability.LiabilityAmountMetYear = null;
                employerRegistration.EmployerDto.EmployerLiability.LiabilityAmountMetQuarter = null;
            }
        }

        /// <summary>
        /// Validates 'Liability Weeks' wizard step
        /// </summary>
        public void LiabilityWeeksNext()
        {
            var employerRegistration = (EmployerRegistrationViewModel)Machine["EmployerRegistration"];
            List<bool?> listUserInput = new List<bool?> { employerRegistration.EmployerDto.EmployerLiability.HasEmployed1In20Weeks, employerRegistration.EmployerDto.EmployerLiability.HasEmployed10In20Weeks };
            if (listUserInput.FindAll(l => l.Equals(true))?.Count == 2)
            {
                Context.ValidationMessages.AddError("Only one answer can be Yes. Select the question that occurred first as Yes and the other(s) as No.");
            }
            else
            {
                Machine["IsLiableWeeks"] = (bool)employerRegistration.EmployerDto.EmployerLiability.HasEmployed1In20Weeks || (bool)employerRegistration.EmployerDto.EmployerLiability.HasEmployed10In20Weeks;
            }
        }

        /// <summary>
        /// Validates 'Administrator Info' wizard step
        /// </summary>
        public void AdminInfoNext()
        {
            ValidateEmail(Machine["EmployerRegistration.EmployerContactDto.Email"]?.ToString(), Machine["ReEmail"]?.ToString());
        }

        /// <summary>
        /// Validates 'Employer Identification' wizard step
        /// </summary>
        public void EmpIdentificationNext()
        {
            var employerRegistration = (EmployerRegistrationViewModel)Machine["EmployerRegistration"];
            if (employerRegistration.EmployerDto.EmployerLiability.HasPaid450RegularWages == true || employerRegistration.EmployerDto.EmployerLiability.HasEmployed1In20Weeks == true)
            {
                employerRegistration.EmployerDto.BusinessTypeCode = LookupTable_BusinessType.NonAgriculturalRegularEmployment;
            }
            if (employerRegistration.EmployerDto.EmployerLiability.HasPaid20KAgriculturalLaborWages == true || employerRegistration.EmployerDto.EmployerLiability.HasEmployed10In20Weeks == true)
            {
                employerRegistration.EmployerDto.BusinessTypeCode = LookupTable_BusinessType.Agricultural;
            }
            if (employerRegistration.EmployerDto.EmployerLiability.HasPaid1KDomesticWages == true)
            {
                employerRegistration.EmployerDto.BusinessTypeCode = LookupTable_BusinessType.Domestic;
            }

            //check if entity is public
            string entityTypeCode = employerRegistration.EmployerDto.EntityTypeCode;
            Machine["IsPublicEntity"] = entityTypeCode.Equals(LookupTable_LegalEntity.City) || entityTypeCode.Equals(LookupTable_LegalEntity.GovernmentStateAgency) || entityTypeCode.Equals(LookupTable_LegalEntity.LocalPublicBody) || entityTypeCode.Equals(LookupTable_LegalEntity.USMilitary) || entityTypeCode.Equals(LookupTable_LegalEntity.County);

            //validate address fields
            ValidateAddress((AddressDto)Machine["EntityAddress.Address"], Machine["LegalAddrReEmail"]?.ToString());
            if (Context.ValidationMessages.Count(ValidationMessageSeverity.Error) == 0)
            {
                Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterBusinessInformation);
            }
        }

        /// <summary>
        /// Validates 'Business Information Continued' wizard step
        /// </summary>
        public void EnterBusinessInfoContNext()
        {
            var employerRegistration = (EmployerRegistrationViewModel)Machine["EmployerRegistration"];
            if ((bool)Machine["IsPublicEntity"] && employerRegistration.EmployerDto.IsExemptUnderIRS501C3 == true)
            {
                Context.ValidationMessages.AddError("'Is this employer a non-profit organization (hospitals, schools, municipalities & counties) that holds an exemption from federal income taxes?' cannot be 'Yes' for the selected Legal Entity Type.", "EmployerRegistration.EmployerDto.IsExemptUnderIRS501C3");
            }
            if (!employerRegistration.EmployerDto.IsExemptUnderIRS501C3 == true && employerRegistration.EmployerDto.IsApplyingForREIM == true)
            {
                Context.ValidationMessages.AddError("Business type is not eligible for Reimbursable Cost Basis Financing.", "EmployerRegistration.EmployerDto.IsApplyingForREIM");
            }
            if (!employerRegistration.EmployerDto.IsPresentInMultipleLoc == true && employerRegistration.EmployerDto.NoOfLocation != null)
            {
                Context.ValidationMessages.AddError("'If yes, how many?' cannot be provided if 'Is there more than one physical location in State?' is selected as 'No'.", "EmployerRegistration.EmployerDto.NoOfLocation");
            }
        }

        /// <summary>
        /// Validates 'Physical Address' wizard step
        /// </summary>
        public void EnterPhysicalAddrNext()
        {
            var employerRegistration = (EmployerRegistrationViewModel)Machine["EmployerRegistration"];
            var physicalAddress = (AddressLinkDto)Machine["PhysicalAddress"];
            if (employerRegistration.EmployerDto.HasPhysicalLocation == false && Machine["SameAsPhyAddr"]?.ToString().Equals(LookupTable_AddressType.Mailing) == true)
            {
                Context.ValidationMessages.AddError("Cannot select mailing address if no physical address in Washington is selected.", "EmployerRegistration.EmployerDto.HasPhysicalLocation");
            }
            else if (employerRegistration.EmployerDto.HasPhysicalLocation == false && (physicalAddress?.Address?.AddressLine1 != null || physicalAddress?.Address?.AddressLine2 != null || physicalAddress?.Address?.City != null || physicalAddress?.Address?.Zip != null || physicalAddress?.Address?.PhoneNumber != null || physicalAddress?.Address?.FaxNumber != null || physicalAddress?.Address?.Email != null))
            {
                Context.ValidationMessages.AddError("Address fields must be blank if no physical address in Washington is selected.", "EmployerRegistration.EmployerDto.HasPhysicalLocation");
            }
            else if (employerRegistration.EmployerDto.HasPhysicalLocation == true && Machine["SameAsPhyAddr"]?.ToString().Equals(LookupTable_AddressType.Mailing) == true && (Machine["EntityAddress.Address.StateCode"] is null || !Machine["EntityAddress.Address.StateCode"]?.Equals(LookupTable_StatePrvnc.Washington) == true))
            {
                Context.ValidationMessages.AddError("Cannot select mailing address with State other than Washington, if physical address in Washington is selected as 'Yes'.", "EmployerRegistration.EmployerDto.HasPhysicalLocation");
            }
            else if (Machine["SameAsPhyAddr"]?.ToString().Equals(LookupTable_AddressType.Mailing) == true)
            {
                Machine["PhysicalAddress"] = Machine["EntityAddress"];
                Machine["PhysicalAddress.AddressTypeCode"] = LookupTable_AddressType.Physical;
                Machine["HasPhysicalAddress"] = true;
            }
            else
            {
                ValidateAddress((AddressDto)Machine["PhysicalAddress.Address"], Machine["PhyAddrReEmail"]?.ToString());
                if (Machine["PhysicalAddress.Address.AddressLine1"] != null)
                {
                    Machine["HasPhysicalAddress"] = true;
                }
                else
                {
                    Machine["HasPhysicalAddress"] = false;
                    Machine["SameAsBusiAddr"] = Machine["SameAsBusiAddr"]?.ToString().Equals(LookupTable_AddressType.Physical) == true ? null : Machine["SameAsBusiAddr"];
                }
            }
        }

        /// <summary>
        /// Validates 'Business Address' wizard step
        /// </summary>
        public void EnterBusiRcdsAddrNext()
        {
            if (Machine["SameAsBusiAddr"]?.ToString().Equals(LookupTable_AddressType.Mailing) == true)
            {
                Machine["BusinessAddress"] = Machine["EntityAddress"];
                Machine["BusinessAddress.AddressTypeCode"] = LookupTable_AddressType.Business;
            }
            else if (Machine["SameAsBusiAddr"]?.ToString().Equals(LookupTable_AddressType.Physical) == true)
            {
                Machine["BusinessAddress"] = Machine["PhysicalAddress"];
                Machine["BusinessAddress.AddressTypeCode"] = LookupTable_AddressType.Business;
            }
            else
            {
                ValidateAddress((AddressDto)Machine["BusinessAddress.Address"], Machine["BusiAddrReTypeEmail"]?.ToString());
            }

            if (Context.ValidationMessages.Count(ValidationMessageSeverity.Error) == 0)
            {
                Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.Summary);
            }
        }

        /// <summary>
        /// To handle Same as Drop down values
        /// </summary>
        public void EnterBusiRcdsAddrPrevious()
        {
            Machine["HasPhysicalAddress"] = false;
            if (Machine["SameAsPhyAddr"]?.ToString().Equals(LookupTable_AddressType.Mailing) == true)
            {
                Machine["PhysicalAddress"] = new AddressLinkDto() { Address = new AddressDto() { StateCode = LookupTable_StatePrvnc.Washington, CountryCode = LookupTable_Country.UnitedStates }, AddressTypeCode = LookupTable_AddressType.Physical };
            }
        }

        /// <summary>
        /// To set intialize BusinessAdress again
        /// </summary>
        public void RegistrationSummaryPrevious()
        {
            if (Machine["SameAsBusiAddr"]?.ToString().Equals(LookupTable_AddressType.Mailing) == true || Machine["SameAsBusiAddr"]?.ToString().Equals(LookupTable_AddressType.Physical) == true)
            {
                Machine["BusinessAddress"] = new AddressLinkDto() { Address = new AddressDto() { StateCode = LookupTable_StatePrvnc.Washington, CountryCode = LookupTable_Country.UnitedStates }, AddressTypeCode = LookupTable_AddressType.Business };
            }
            Machine["CurrentSection"] = LookupUtil.GetLookupCode(LookupTable.WizEmployerRegistration, LookupTable_WizEmployerRegistration.EnterBusinessInformation);
        }

        /// <summary>
        /// Fills Employer Registration object with required details, to be passed to BusinessLogic for submition  
        /// </summary>
        public void RegistrationSummarySubmit()
        {
            var employerRegistration = (EmployerRegistrationViewModel)Machine["EmployerRegistration"];
            employerRegistration.EmployerDto.EmployerPreference.Email = ((AddressLinkDto)Machine["EntityAddress"]).Address.Email;
            employerRegistration.ListAddressLinkDto = new List<AddressLinkDto>();
            var entityAddress = (AddressLinkDto)Machine["EntityAddress"];
            var physicalAddress = (AddressLinkDto)Machine["PhysicalAddress"];
            var businessAddress = (AddressLinkDto)Machine["BusinessAddress"];
            entityAddress.AddressTypeCode = LookupTable_AddressType.Mailing;
            physicalAddress.AddressTypeCode = LookupTable_AddressType.Physical;
            businessAddress.AddressTypeCode = LookupTable_AddressType.Business;
            employerRegistration.ListAddressLinkDto.Add(entityAddress);
            if (!string.IsNullOrEmpty(physicalAddress.Address.AddressLine1))
            {
                physicalAddress.Address.BusinessWebAddress = null;
                employerRegistration.ListAddressLinkDto.Add(physicalAddress);
            }
            if (!string.IsNullOrEmpty(businessAddress.Address.AddressLine1))
            {
                businessAddress.Address.BusinessWebAddress = null;
                employerRegistration.ListAddressLinkDto.Add(businessAddress);
            }
        }

        #endregion

        #region Misc Methods

        /// <summary>
        /// Validate Address fields
        /// </summary>
        /// <param name="address"></param>
        /// <param name="reEmail"></param>
        private void ValidateAddress(AddressDto address, String reEmail)
        {
            ValidateEmail(address.Email, reEmail);

            if (!address.CountryCode.Equals(LookupTable_Country.UnitedStates) && !address.CountryCode.Equals(LookupTable_Country.Canada) && address.StateCode != null)
            {
                Context.ValidationMessages.AddError("State should be blank if country is not United States or Canada.");
            }

            if ((address.CountryCode.Equals(LookupTable_Country.UnitedStates) || address.CountryCode.Equals(LookupTable_Country.Canada)) && address.StateCode == null)
            {
                Context.ValidationMessages.AddError("State is required if country is United States or Canada.");
            }
            if (!string.IsNullOrEmpty(address.AddressLine1) && (address.CountryCode.Equals(LookupTable_Country.UnitedStates) || address.CountryCode.Equals(LookupTable_Country.Canada)) && address.PhoneNumber == null)
            {
                Context.ValidationMessages.AddError("Phone Number is required if country is United States or Canada.");
            }
        }

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

        /// <summary>
        /// Address type lookup values
        /// </summary>
        /// <returns></returns>
        public string[] LookupFilterAddressType()
        {
            if ((bool)Machine["HasPhysicalAddress"])
            {
                return new[] { LookupTable_AddressType.Mailing, LookupTable_AddressType.Physical };
            }
            else
            {
                return new[] { LookupTable_AddressType.Mailing };
            }
        }

        /// <summary>
        /// Check if Fein provided is valid or not
        /// </summary>
        /// <param name="fein"></param>
        /// <returns></returns>
        private (bool isBad, long? feinNumeric) IsBadFein(string fein)
        {
            if (Int64.TryParse(fein, out long feinNumeric))
            {
                if (fein.Equals(LookupTable_BadFein._000000000) || fein.Equals(LookupTable_BadFein._111111111) || fein.Equals(LookupTable_BadFein._123456789) || fein.Equals(LookupTable_BadFein._222222222) || fein.Equals(LookupTable_BadFein._333333333) || fein.Equals(LookupTable_BadFein._444444444) || fein.Equals(LookupTable_BadFein._555555555) || fein.Equals(LookupTable_BadFein._666666666) || fein.Equals(LookupTable_BadFein._777777777) || fein.Equals(LookupTable_BadFein._888888888) || fein.Equals(LookupTable_BadFein._987654321) || fein.Equals(LookupTable_BadFein._999999999))
                {
                    return (isBad: true, feinNumeric: null);
                }
                else if (fein.StartsWith(LookupTable_BadFeinPrefix._00) || fein.StartsWith(LookupTable_BadFeinPrefix._07) || fein.StartsWith(LookupTable_BadFeinPrefix._08) || fein.StartsWith(LookupTable_BadFeinPrefix._09) || fein.StartsWith(LookupTable_BadFeinPrefix._17) || fein.StartsWith(LookupTable_BadFeinPrefix._18) || fein.StartsWith(LookupTable_BadFeinPrefix._19) || fein.StartsWith(LookupTable_BadFeinPrefix._28) || fein.StartsWith(LookupTable_BadFeinPrefix._29) || fein.StartsWith(LookupTable_BadFeinPrefix._49) || fein.StartsWith(LookupTable_BadFeinPrefix._69) || fein.StartsWith(LookupTable_BadFeinPrefix._70) || fein.StartsWith(LookupTable_BadFeinPrefix._78) || fein.StartsWith(LookupTable_BadFeinPrefix._79) || fein.StartsWith(LookupTable_BadFeinPrefix._89))
                {
                    return (isBad: true, feinNumeric: null);
                }
                else
                {
                    return (isBad: false, feinNumeric: feinNumeric);
                }
            }
            else
            {
                return (isBad: true, feinNumeric: null);
            }
        }

        #endregion
    }
}