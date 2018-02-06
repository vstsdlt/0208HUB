// ----------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a compiler emitter: FACTS.Framework.Analysis.Generators.DAL.DtoEmitter
//
// Changes to this file may cause incorrect behavior and will be lost when the code is regenerated.
// </auto-generated>
// ----------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using FACTS.Framework.Dto;

namespace PFML.Shared.Model.DbDtos
{

    /// <summary>DTO object: [Employer]</summary>
    [Serializable]
    public class EmployerDto : BaseDto
    {

        /// <summary>[BusinessTypeCode]</summary>
        public string BusinessTypeCode { get; set; }

        /// <summary>[CreateDateTime]</summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>[CreateUserId]</summary>
        public string CreateUserId { get; set; }

        /// <summary>[EmployerId]</summary>
        public int EmployerId { get; set; }

        /// <summary>[EntityName]</summary>
        public string EntityName { get; set; }

        /// <summary>[EntityTypeCode]</summary>
        public string EntityTypeCode { get; set; }

        /// <summary>[FEIN]</summary>
        public int? Fein { get; set; }

        /// <summary>[HasPhysicalLocation]</summary>
        public bool? HasPhysicalLocation { get; set; }

        /// <summary>[HasTelecommuters]</summary>
        public bool? HasTelecommuter { get; set; }

        /// <summary>[IsAcquired]</summary>
        public bool? IsAcquired { get; set; }

        /// <summary>[IsApplyingForREIM]</summary>
        public bool? IsApplyingForREIM { get; set; }

        /// <summary>[IsClientOfPEO]</summary>
        public bool? IsClientOfPEO { get; set; }

        /// <summary>[IsExemptUnderIRS501C3]</summary>
        public bool? IsExemptUnderIRS501C3 { get; set; }

        /// <summary>[IsIndividualContractor]</summary>
        public bool? IsIndividualContractor { get; set; }

        /// <summary>[IsPresentInMultipleLoc]</summary>
        public bool? IsPresentInMultipleLoc { get; set; }

        /// <summary>[IsProfessionalEmployerOrg]</summary>
        public bool? IsProfessionalEmployerOrg { get; set; }

        /// <summary>[IsServiceBegin]</summary>
        public bool? IsServiceBegin { get; set; }

        /// <summary>[LiabilityDate]</summary>
        public DateTime? LiabilityDate { get; set; }

        /// <summary>[LiabilityIncurredDate]</summary>
        public DateTime? LiabilityIncurredDate { get; set; }

        /// <summary>[NaicsCode]</summary>
        public string NaicsCode { get; set; }

        /// <summary>[NoOfEmployeesPaid]</summary>
        public int? NoOfEmployeesPaid { get; set; }

        /// <summary>[NoOfLocations]</summary>
        public int? NoOfLocation { get; set; }

        /// <summary>[RegistrationDate]</summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>[ReportMethodCode]</summary>
        public string ReportMethodCode { get; set; }

        /// <summary>[ServiceBeginDate]</summary>
        public DateTime? ServiceBeginDate { get; set; }

        /// <summary>[StatusCode]</summary>
        public string StatusCode { get; set; }

        /// <summary>[StatusDate]</summary>
        public DateTime StatusDate { get; set; }

        /// <summary>[SubjectivityCode]</summary>
        public string SubjectivityCode { get; set; }

        /// <summary>[UpdateDateTime]</summary>
        public DateTime UpdateDateTime { get; set; }

        /// <summary>[UpdateNumber]</summary>
        public int? UpdateNumber { get; set; }

        /// <summary>[UpdateProcess]</summary>
        public string UpdateProcess { get; set; }

        /// <summary>[UpdateUserId]</summary>
        public string UpdateUserId { get; set; }

        /// <summary>[UserName]</summary>
        public string UserName { get; set; }

        //Reverse navigational properties
        public virtual List<AddressLinkDto> AddressLinks { get; private set; } = new List<AddressLinkDto>();
        public virtual List<CorrespondenceDto> Correspondences { get; private set; } = new List<CorrespondenceDto>();
        public virtual List<EmployerAccountTransactionDto> EmployerAccountTransactions { get; private set; } = new List<EmployerAccountTransactionDto>();
        public virtual List<EmployerContactDto> EmployerContacts { get; private set; } = new List<EmployerContactDto>();
        public virtual EmployerLiabilityDto EmployerLiability { get; set; }
        public virtual EmployerPreferenceDto EmployerPreference { get; set; }
        public virtual List<EmployerUnitDto> EmployerUnits { get; private set; } = new List<EmployerUnitDto>();
        public virtual List<PaymentMainDto> PaymentMains { get; private set; } = new List<PaymentMainDto>();
        public virtual List<PaymentProfileDto> PaymentProfiles { get; private set; } = new List<PaymentProfileDto>();
        public virtual List<PremiumAppealHeaderDto> PremiumAppealHeaders { get; private set; } = new List<PremiumAppealHeaderDto>();
        public virtual List<TaxableAmountSumDto> TaxableAmountSums { get; private set; } = new List<TaxableAmountSumDto>();
        public virtual List<VoluntaryPlanWaiverRequestDto> VoluntaryPlanWaiverRequests { get; private set; } = new List<VoluntaryPlanWaiverRequestDto>();
        public virtual List<WageUnitDetailDto> WageUnitDetails { get; private set; } = new List<WageUnitDetailDto>();

    }

}
