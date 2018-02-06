using FACTS.Framework.Service;
using FACTS.Framework.Utility;
using PFML.DAL.Model.DbEntities;
using PFML.Shared.LookupTable;
using PFML.Shared.Model.DbDtos;
using PFML.Shared.Utility;
using PFML.Shared.ViewModels.Premium.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using DbContext = PFML.DAL.Model.DbContext;

namespace PFML.BusinessLogic.Premium.Registration
{
    public static class EmployerRegistrationLogic
    {

        /// <summary>
        /// Validate FEIN in database and returns validation message if it already exists.
        /// </summary>
        /// <param name="employerRegistrationViewModel"></param>
        /// <returns></returns>
        [OperationMethod]
        public static EmployerRegistrationViewModel ValidateIntroduction(EmployerRegistrationViewModel employerRegistrationViewModel)
        {
            using (DbContext context = new DbContext())
            {
                if (context.Employers.Any(emp => emp.Fein == employerRegistrationViewModel.EmployerDto.Fein))
                {
                    Context.ValidationMessages.AddError("The FEIN entered already exists in the system for another employer account. Verify your records to ensure the information you entered is correct and re-enter the FEIN.", "Fein");
                }
            }

            return employerRegistrationViewModel;
        }

        /// <summary>
        /// Submits employer details to database during employer registration.
        /// </summary>
        /// <param name="employerRegistrationViewModel"></param>
        /// <returns></returns>
        [OperationMethod]
        public static EmployerRegistrationViewModel SubmitRegistration(EmployerRegistrationViewModel employerRegistrationViewModel)
        {
            using (DbContext context = new DbContext())
            {
                employerRegistrationViewModel.EmployerDto = SetPendingFieldsEmployerDto(employerRegistrationViewModel.EmployerDto, employerRegistrationViewModel.EmployerUnitDto);
                employerRegistrationViewModel.EmployerContactDto = SetPendingFieldsEmployerContactDto(employerRegistrationViewModel.EmployerContactDto);
                employerRegistrationViewModel.EmployerUnitDto = SetPendingFieldsEmployerUnitDto(employerRegistrationViewModel.EmployerUnitDto, employerRegistrationViewModel.ListAddressLinkDto);
                employerRegistrationViewModel.ListAddressLinkDto = SetPendingFieldsListAddressLinkDto(employerRegistrationViewModel.ListAddressLinkDto);

                var employer = Employer.FromDto(context, employerRegistrationViewModel.EmployerDto);
                var employerUnit = EmployerUnit.FromDto(context, employerRegistrationViewModel.EmployerUnitDto);
                employer.EmployerContacts.Add(EmployerContact.FromDto(context, employerRegistrationViewModel.EmployerContactDto));
                employerRegistrationViewModel.ListAddressLinkDto.ForEach(addressLinkDto => employerUnit.AddressLinks.Add(AddressLink.FromDto(context, addressLinkDto)));
                employer.EmployerUnits.Add(employerUnit);
                context.SaveChanges();
                employerRegistrationViewModel.EmployerDto = employer.ToDto();
                employerRegistrationViewModel.PremiumRateDto = GetCurrentContributionRate();
            }

            return employerRegistrationViewModel;
        }

        /// <summary>
        /// Validate username in database and returns validation message if it already exist.
        /// </summary>
        /// <param name="employerRegistrationViewModel"></param>
        /// <returns></returns>
        [OperationMethod]
        public static EmployerRegistrationViewModel ValidateAdminInfo(EmployerRegistrationViewModel employerRegistrationViewModel)
        {
            using (DbContext context = new DbContext())
            {
                if (context.Employers.Any(emp => emp.UserName == employerRegistrationViewModel.EmployerDto.UserName))
                {
                    Context.ValidationMessages.AddError("The Username entered already exists in the system for another employer account. Please re-enter different Username.", "EmployerRegistration.EmployerDto.UserName");
                }
            }

            return employerRegistrationViewModel;
        }

        #region Private Methods

        /// <summary>
        /// Set Pending Fields for ListAddressLinkDto
        /// </summary>
        /// <param name="listAddressLinkDto"></param>
        /// <returns></returns>
        private static List<AddressLinkDto> SetPendingFieldsListAddressLinkDto(List<AddressLinkDto> listAddressLinkDto)
        {
            foreach (var addressLinkDto in listAddressLinkDto)
            {
                addressLinkDto.Address.AddressVerificationCode = LookupTable_AddressVerificationType.Noaddressverificationperformed;
                addressLinkDto.StatusCode = LookupTable_EmployerStatus.Active;
                string phoneNumber = addressLinkDto.Address.PhoneNumber;
                if (phoneNumber?.Length > 10)
                {
                    addressLinkDto.Address.PhoneNumber = phoneNumber?.Substring(0, 10);
                    addressLinkDto.Address.PhoneNumberExtn = phoneNumber?.Substring(10);
                }
                if (addressLinkDto.Address.StateCode == null)
                {
                    addressLinkDto.Address.IntPhoneNumber = addressLinkDto.Address?.PhoneNumber;
                    addressLinkDto.Address.PhoneNumber = null;
                    addressLinkDto.Address.IntPhoneNumberExtn = addressLinkDto.Address?.PhoneNumberExtn;
                    addressLinkDto.Address.PhoneNumberExtn = null;
                    addressLinkDto.Address.IntFaxNumber = addressLinkDto.Address?.FaxNumber;
                    addressLinkDto.Address.FaxNumber = null;
                }
            }

            return listAddressLinkDto;
        }

        /// <summary>
        /// Set Pending Fields for EmployerUnitDto
        /// </summary>
        /// <param name="employerUnitDto"></param>
        /// <param name="listAddressLinkDto"></param>
        /// <returns></returns>
        private static EmployerUnitDto SetPendingFieldsEmployerUnitDto(EmployerUnitDto employerUnitDto, List<AddressLinkDto> listAddressLinkDto)
        {
            string countyCode = "0";
            AddressLinkDto physicalAddress = listAddressLinkDto.FirstOrDefault(addressLink => addressLink.AddressTypeCode == LookupTable_AddressType.Physical);
            employerUnitDto.DoingBusinessAsName = employerUnitDto.DoingBusinessAsName?.ToUpper();
            employerUnitDto.StatusCode = LookupTable_EmployerStatus.Active;
            employerUnitDto.StatusDate = DateTimeUtil.Now;
            employerUnitDto.CountyCode = physicalAddress?.Address?.CountyCode ?? countyCode;

            return employerUnitDto;
        }

        /// <summary>
        /// Set Pending Fields for EmployerContactDto
        /// </summary>
        /// <param name="employerContactDto"></param>
        /// <returns></returns>
        private static EmployerContactDto SetPendingFieldsEmployerContactDto(EmployerContactDto employerContactDto)
        {
            employerContactDto.ContactTypeCode = LookupTable_ContactType.Administrator;
            employerContactDto.StatusCode = LookupTable_EmployerStatus.Active;
            string phoneNumber = employerContactDto.PhoneNumber;
            string secondaryPhoneNumber = employerContactDto.SecondaryPhoneNumber;
            if (phoneNumber?.Length > 10)
            {
                employerContactDto.PhoneNumber = phoneNumber?.Substring(0, 10);
                employerContactDto.PhoneNumberExtn = phoneNumber?.Substring(10);
            }
            if (secondaryPhoneNumber?.Length > 10)
            {
                employerContactDto.SecondaryPhoneNumber = secondaryPhoneNumber?.Substring(0, 10);
                employerContactDto.SecondaryPhoneNumberExtn = secondaryPhoneNumber?.Substring(10);
            }

            return employerContactDto;
        }

        /// <summary>
        /// Set Pending Fields for EmployerDto
        /// </summary>
        /// <param name="employerDto"></param>
        /// <param name="employerUnitDto"></param>
        /// <returns></returns>
        private static EmployerDto SetPendingFieldsEmployerDto(EmployerDto employerDto, EmployerUnitDto employerUnitDto)
        {
            var employerLiabilityDto = employerDto.EmployerLiability;
            int liabilityIncurredYear = employerLiabilityDto.LiabilityAmountMetYear ?? 0;
            int liabilityIncurredQtr = employerLiabilityDto.LiabilityAmountMetQuarter != null ? Convert.ToInt32(DateUtil.GetQuarterNumber(employerLiabilityDto.LiabilityAmountMetQuarter)) : 0;
            GetLiabilityDate(liabilityIncurredYear, liabilityIncurredQtr, employerUnitDto.FirstWageDate, out DateTime? liabilityDate, out DateTime? liabilityIncurredDate);

            employerDto.RegistrationDate = DateTimeUtil.Now;
            employerDto.NaicsCode = LookupTable_Naics5.AbrasiveProductManufacturing;
            employerDto.LiabilityDate = liabilityDate;
            employerDto.LiabilityIncurredDate = liabilityIncurredDate;
            employerDto.ReportMethodCode = LookupTable_EmployerReportMethod.Contributory;
            employerDto.SubjectivityCode = LookupTable_EmployerReportMethod.Contributory;
            employerDto.StatusCode = LookupTable_EmployerStatus.Active;
            employerDto.StatusDate = DateTimeUtil.Now;

            return employerDto;
        }

        /// <summary>
        /// Get liability dates
        /// </summary>
        /// <param name="subjIncurYr"></param>
        /// <param name="subjIncurQtr"></param>
        /// <param name="entityTypeCd"></param>
        /// <param name="firstWageDate"></param>
        /// <returns></returns>
        private static void GetLiabilityDate(int liabilityIncurredYear, int liabilityIncurredQtr, DateTime? firstWageDate, out DateTime? liabilityDate, out DateTime? liabilityIncurredDate)
        {
            var liableQtr = ((firstWageDate.Value.Month - 1) / 3) + 1;
            liabilityDate = GetFirstDayOfQuarter(firstWageDate.Value.Year, liableQtr);
            liabilityIncurredDate = GetFirstDayOfQuarter(liabilityIncurredYear, liabilityIncurredQtr);
            if (liabilityDate.Value.Year != liabilityIncurredDate.Value.Year)
            {
                liabilityDate = new DateTime(liabilityIncurredDate.Value.Year, 1, 1);
            }
            else
            {
                int currentQuarter = ((DateTimeUtil.Now.Month - 1) / 3) + 1;
                int yearPast = DateTimeUtil.Now.Year - 4;
                if (firstWageDate.Value < new DateTime(yearPast, DateTimeUtil.Now.Month, DateTimeUtil.Now.Day))
                {
                    liabilityIncurredDate = GetFirstDayOfQuarter(DateTimeUtil.Now.Year - 4, currentQuarter);
                    liabilityDate = liabilityIncurredDate;
                }
            }
        }

        /// <summary>
        /// Get current premium rate present in database to be displayed on Employer Contributory screen
        /// </summary>
        /// <returns></returns>
        private static PremiumRateDto GetCurrentContributionRate()
        {
            using (DbContext context = new DbContext())
            {
                return context.PremiumRates.FirstOrDefault(pr => pr.EffectiveBeginDate <= DateTimeUtil.Now && pr.EffectiveEndDate >= DateTimeUtil.Now).ToDto();
            }
        }

        /// <summary>
        /// To get first day of quarter
        /// </summary>
        /// <param name="subjIncurYr"></param>
        /// <param name="subjIncurQtr"></param>
        /// <returns></returns>
        private static DateTime GetFirstDayOfQuarter(int subjIncurYr, int subjIncurQtr)
        {
            return new DateTime(subjIncurYr, 3 * subjIncurQtr - 2, 1);
        }

        #endregion
    }

}
