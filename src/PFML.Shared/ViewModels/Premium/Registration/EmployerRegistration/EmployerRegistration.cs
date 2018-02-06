using PFML.Shared.Model.DbDtos;
using System;
using System.Collections.Generic;

namespace PFML.Shared.ViewModels.Premium.Registration
{
    [Serializable]
    public class EmployerRegistrationViewModel
    {
        public EmployerDto EmployerDto { get; set; } = new EmployerDto() { EmployerLiability = new EmployerLiabilityDto(), EmployerPreference = new EmployerPreferenceDto() };
        public EmployerContactDto EmployerContactDto { get; set; } = new EmployerContactDto();
        public EmployerUnitDto EmployerUnitDto { get; set; } = new EmployerUnitDto();
        public List<AddressLinkDto> ListAddressLinkDto { get; set; } = new List<AddressLinkDto>();
        public PremiumRateDto PremiumRateDto { get; set; }
    }
}
