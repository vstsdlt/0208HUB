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

    /// <summary>DTO object: [PremiumAppealDetail]</summary>
    [Serializable]
    public class PremiumAppealDetailDto : BaseDto
    {

        /// <summary>[AddressLinkId]</summary>
        public int AddressLinkId { get; set; }

        /// <summary>[ContactPersonName]</summary>
        public string ContactPersonName { get; set; }

        /// <summary>[CorrespondenceId]</summary>
        public int CorrespondenceId { get; set; }

        /// <summary>[CreateDateTime]</summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>[CreateUserId]</summary>
        public string CreateUserId { get; set; }

        /// <summary>[DeterminationCorrespondanceId]</summary>
        public int? DeterminationCorrespondanceId { get; set; }

        /// <summary>[IndividualFilingAppealName]</summary>
        public string IndividualFilingAppealName { get; set; }

        /// <summary>[IsTimely]</summary>
        public bool IsTimely { get; set; }

        /// <summary>[NonTimelyNoteSetId]</summary>
        public int? NonTimelyNoteSetId { get; set; }

        /// <summary>[PhoneNumber]</summary>
        public int PhoneNumber { get; set; }

        /// <summary>[PhoneNumberExtn]</summary>
        public int? PhoneNumberExtn { get; set; }

        /// <summary>[PremiumAppealDetailId]</summary>
        public int PremiumAppealDetailId { get; set; }

        /// <summary>[PremiumAppealHeaderId]</summary>
        public int PremiumAppealHeaderId { get; set; }

        /// <summary>[ReasonNoteSetId]</summary>
        public int? ReasonNoteSetId { get; set; }

        /// <summary>[StatusCode]</summary>
        public string StatusCode { get; set; }

        /// <summary>[StatusDate]</summary>
        public DateTime StatusDate { get; set; }

        /// <summary>[UpdateDateTime]</summary>
        public DateTime UpdateDateTime { get; set; }

        /// <summary>[UpdateNumber]</summary>
        public int? UpdateNumber { get; set; }

        /// <summary>[UpdateProcess]</summary>
        public string UpdateProcess { get; set; }

        /// <summary>[UpdateUserId]</summary>
        public string UpdateUserId { get; set; }

        //Navigational properties
        public virtual AddressLinkDto AddressLink { get; set; }
        public virtual CorrespondenceDto Correspondence { get; set; }
        public virtual NoteSetDto NoteSetNonTimelyNoteSetId { get; set; }
        public virtual NoteSetDto NoteSetReasonNoteSetId { get; set; }
        public virtual PremiumAppealHeaderDto PremiumAppealHeader { get; set; }

    }

}