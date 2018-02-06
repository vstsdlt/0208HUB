// ----------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a compiler emitter: FACTS.Framework.Analysis.Generators.DAL.EntityEmitter
//
// Changes to this file may cause incorrect behavior and will be lost when the code is regenerated.
// </auto-generated>
// ----------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using PFML.Shared.Model.DbDtos;
using FACTS.Framework.DAL;

namespace PFML.DAL.Model.DbEntities
{

    /// <summary>[PremiumAppealDetail]</summary>
    [Table("PremiumAppealDetail", Schema="dbo")]
    public class PremiumAppealDetail : BaseEntity
    {

        /// <summary>[AddressLinkId]</summary>
        [Required]
        [Column("AddressLinkId")]
        public int AddressLinkId { get; set; }

        /// <summary>[ContactPersonName]</summary>
        [Required]
        [MaxLength(160)]
        [Column("ContactPersonName")]
        public string ContactPersonName { get; set; }

        /// <summary>[CorrespondenceId]</summary>
        [Required]
        [Column("CorrespondenceId")]
        public int CorrespondenceId { get; set; }

        /// <summary>[CreateDateTime]</summary>
        [Required]
        [Column("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }

        /// <summary>[CreateUserId]</summary>
        [Required]
        [MaxLength(50)]
        [Column("CreateUserId")]
        public string CreateUserId { get; set; }

        /// <summary>[DeterminationCorrespondanceId]</summary>
        [Column("DeterminationCorrespondanceId")]
        public int? DeterminationCorrespondanceId { get; set; }

        /// <summary>[IndividualFilingAppealName]</summary>
        [Required]
        [MaxLength(160)]
        [Column("IndividualFilingAppealName")]
        public string IndividualFilingAppealName { get; set; }

        /// <summary>[IsTimely]</summary>
        [Required]
        [Column("IsTimely")]
        public bool IsTimely { get; set; }

        /// <summary>[NonTimelyNoteSetId]</summary>
        [Column("NonTimelyNoteSetId")]
        public int? NonTimelyNoteSetId { get; set; }

        /// <summary>[PhoneNumber]</summary>
        [Required]
        [Column("PhoneNumber")]
        public int PhoneNumber { get; set; }

        /// <summary>[PhoneNumberExtn]</summary>
        [Column("PhoneNumberExtn")]
        public int? PhoneNumberExtn { get; set; }

        /// <summary>[PremiumAppealDetailId]</summary>
        [Key]
        [Required]
        [Column("PremiumAppealDetailId", Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PremiumAppealDetailId { get; set; }

        /// <summary>[PremiumAppealHeaderId]</summary>
        [Required]
        [Column("PremiumAppealHeaderId")]
        public int PremiumAppealHeaderId { get; set; }

        /// <summary>[ReasonNoteSetId]</summary>
        [Column("ReasonNoteSetId")]
        public int? ReasonNoteSetId { get; set; }

        /// <summary>[StatusCode]</summary>
        [Required]
        [MaxLength(20)]
        [Column("StatusCode")]
        public string StatusCode { get; set; }

        /// <summary>[StatusDate]</summary>
        [Required]
        [Column("StatusDate")]
        public DateTime StatusDate { get; set; }

        /// <summary>[UpdateDateTime]</summary>
        [Required]
        [Column("UpdateDateTime")]
        public DateTime UpdateDateTime { get; set; }

        /// <summary>[UpdateNumber]</summary>
        [Column("UpdateNumber")]
        [ConcurrencyCheck]
        public int? UpdateNumber { get; set; }

        /// <summary>[UpdateProcess]</summary>
        [MaxLength(100)]
        [Column("UpdateProcess")]
        public string UpdateProcess { get; set; }

        /// <summary>[UpdateUserId]</summary>
        [Required]
        [MaxLength(50)]
        [Column("UpdateUserId")]
        public string UpdateUserId { get; set; }

        public virtual AddressLink AddressLink { get; set; }

        public virtual Correspondence Correspondence { get; set; }

        public virtual NoteSet NoteSetNonTimelyNoteSetId { get; set; }

        public virtual NoteSet NoteSetReasonNoteSetId { get; set; }

        public virtual PremiumAppealHeader PremiumAppealHeader { get; set; }

        public override void SetAuditFields(EntityState state)
        {
            string username = FACTS.Framework.Service.Context.UserName ?? "UNKNOWN";
            DateTime timestamp = FACTS.Framework.Utility.DateTimeUtil.Now;

            if (state == EntityState.Added)
            {
                CreateUserId = username;
                CreateDateTime = new System.Data.SqlTypes.SqlDateTime(timestamp).Value;
                UpdateUserId = username;
                UpdateDateTime = new System.Data.SqlTypes.SqlDateTime(timestamp).Value;
                UpdateNumber = 0;
                UpdateProcess = FACTS.Framework.Utility.StringUtil.CapLength(FACTS.Framework.Service.Context.Process.ToString(), 100);
            }
            else if (state == EntityState.Modified)
            {
                UpdateUserId = username;
                UpdateDateTime = new System.Data.SqlTypes.SqlDateTime(timestamp).Value;
                UpdateNumber = (UpdateNumber ?? 0) + 1;
                UpdateProcess = FACTS.Framework.Utility.StringUtil.CapLength(FACTS.Framework.Service.Context.Process.ToString(), 100);
            }
        }

        internal static void ModelCreating(DbModelBuilder builder)
        {
            builder.Entity<PremiumAppealDetail>().Property(x => x.ContactPersonName).IsUnicode(false);
            builder.Entity<PremiumAppealDetail>().Property(x => x.CreateUserId).IsUnicode(false);
            builder.Entity<PremiumAppealDetail>().Property(x => x.IndividualFilingAppealName).IsUnicode(false);
            builder.Entity<PremiumAppealDetail>().Property(x => x.StatusCode).IsUnicode(false);
            builder.Entity<PremiumAppealDetail>().Property(x => x.UpdateProcess).IsUnicode(false);
            builder.Entity<PremiumAppealDetail>().Property(x => x.UpdateUserId).IsUnicode(false);
            builder.Entity<PremiumAppealDetail>().HasRequired(x => x.AddressLink).WithMany(x => x.PremiumAppealDetails).HasForeignKey(x => x.AddressLinkId);
            builder.Entity<PremiumAppealDetail>().HasRequired(x => x.Correspondence).WithMany(x => x.PremiumAppealDetails).HasForeignKey(x => x.CorrespondenceId);
            builder.Entity<PremiumAppealDetail>().HasOptional(x => x.NoteSetNonTimelyNoteSetId).WithMany(x => x.PremiumAppealDetailsNonTimelyNoteSetId).HasForeignKey(x => x.NonTimelyNoteSetId);
            builder.Entity<PremiumAppealDetail>().HasOptional(x => x.NoteSetReasonNoteSetId).WithMany(x => x.PremiumAppealDetailsReasonNoteSetId).HasForeignKey(x => x.ReasonNoteSetId);
            builder.Entity<PremiumAppealDetail>().HasRequired(x => x.PremiumAppealHeader).WithMany(x => x.PremiumAppealDetails).HasForeignKey(x => x.PremiumAppealHeaderId);
        }

        /// <summary>Convert from PremiumAppealDetail entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant PremiumAppealDetail DTO</returns>
        public PremiumAppealDetailDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, null, dtoTypes, null);
        }

        /// <summary>Convert from PremiumAppealDetail entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant PremiumAppealDetail DTO</returns>
        public PremiumAppealDetailDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, PremiumAppealDetailDto dto, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, dto, dtoTypes, null);
        }

        internal PremiumAppealDetailDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, PremiumAppealDetailDto dto, Type[] dtoTypes, Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos)
        {
            entityDtos = entityDtos ?? new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            if (entityDtos.ContainsKey(this))
            {
                return (PremiumAppealDetailDto)entityDtos[this];
            }

            dto = ToDto(dto);
            entityDtos.Add(this, dto);

            System.Data.Entity.Infrastructure.DbEntityEntry<PremiumAppealDetail> entry = dbContext?.Entry(this);
            dto.IsNew = (entry?.State == EntityState.Added);
            dto.IsDeleted = (entry?.State == EntityState.Deleted);

            if (entry?.Reference(x => x.AddressLink)?.IsLoaded == true)
            {
                dto.AddressLink = AddressLink?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<AddressLinkDto>(dtoTypes), dtoTypes, entityDtos);
            }
            if (entry?.Reference(x => x.Correspondence)?.IsLoaded == true)
            {
                dto.Correspondence = Correspondence?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<CorrespondenceDto>(dtoTypes), dtoTypes, entityDtos);
            }
            if (entry?.Reference(x => x.NoteSetNonTimelyNoteSetId)?.IsLoaded == true)
            {
                dto.NoteSetNonTimelyNoteSetId = NoteSetNonTimelyNoteSetId?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<NoteSetDto>(dtoTypes), dtoTypes, entityDtos);
            }
            if (entry?.Reference(x => x.NoteSetReasonNoteSetId)?.IsLoaded == true)
            {
                dto.NoteSetReasonNoteSetId = NoteSetReasonNoteSetId?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<NoteSetDto>(dtoTypes), dtoTypes, entityDtos);
            }
            if (entry?.Reference(x => x.PremiumAppealHeader)?.IsLoaded == true)
            {
                dto.PremiumAppealHeader = PremiumAppealHeader?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<PremiumAppealHeaderDto>(dtoTypes), dtoTypes, entityDtos);
            }

            return dto;
        }

        /// <summary>Convert from PremiumAppealDetail entity to DTO w/o checking entity state or entity navigation</summary>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <returns>Resultant PremiumAppealDetail DTO</returns>
        public PremiumAppealDetailDto ToDto(PremiumAppealDetailDto dto = null)
        {
            dto = dto ?? new PremiumAppealDetailDto();
            dto.IsNew = false;

            dto.AddressLinkId = AddressLinkId;
            dto.ContactPersonName = ContactPersonName;
            dto.CorrespondenceId = CorrespondenceId;
            dto.CreateDateTime = CreateDateTime;
            dto.CreateUserId = CreateUserId;
            dto.DeterminationCorrespondanceId = DeterminationCorrespondanceId;
            dto.IndividualFilingAppealName = IndividualFilingAppealName;
            dto.IsTimely = IsTimely;
            dto.NonTimelyNoteSetId = NonTimelyNoteSetId;
            dto.PhoneNumber = PhoneNumber;
            dto.PhoneNumberExtn = PhoneNumberExtn;
            dto.PremiumAppealDetailId = PremiumAppealDetailId;
            dto.PremiumAppealHeaderId = PremiumAppealHeaderId;
            dto.ReasonNoteSetId = ReasonNoteSetId;
            dto.StatusCode = StatusCode;
            dto.StatusDate = StatusDate;
            dto.UpdateDateTime = UpdateDateTime;
            dto.UpdateNumber = UpdateNumber;
            dto.UpdateProcess = UpdateProcess;
            dto.UpdateUserId = UpdateUserId;

            return dto;
        }

        /// <summary>Convert from PremiumAppealDetail DTO to entity</summary>
        /// <param name="dbContext">DB Context to use for attaching entity</param>
        /// <param name="dto">DTO to convert from</param>
        /// <returns>Resultant PremiumAppealDetail entity</returns>
        public static PremiumAppealDetail FromDto(FACTS.Framework.DAL.DbContext dbContext, PremiumAppealDetailDto dto)
        {
            return FromDto(dbContext, dto, dtoEntities: null);
        }

        internal static PremiumAppealDetail FromDto(FACTS.Framework.DAL.DbContext dbContext, PremiumAppealDetailDto dto, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            dtoEntities = dtoEntities ?? new Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity>();
            if (dtoEntities.ContainsKey(dto))
            {
                return (PremiumAppealDetail)dtoEntities[dto];
            }

            PremiumAppealDetail entity = new PremiumAppealDetail();
            dtoEntities.Add(dto, entity);
            FromDtoSet(dbContext, dto, entity, dtoEntities);

            if (dbContext != null && (!dto.IsDeleted || !dto.IsNew))
            {
                dbContext.Entry(entity).State = (dto.IsNew ? EntityState.Added : (dto.IsDeleted ? EntityState.Deleted : EntityState.Modified));
            }

            return entity;
        }

        protected static void FromDtoSet(FACTS.Framework.DAL.DbContext dbContext, PremiumAppealDetailDto dto, PremiumAppealDetail entity, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            entity.AddressLinkId = dto.AddressLinkId;
            entity.ContactPersonName = dto.ContactPersonName;
            entity.CorrespondenceId = dto.CorrespondenceId;
            entity.CreateDateTime = dto.CreateDateTime;
            entity.CreateUserId = dto.CreateUserId;
            entity.DeterminationCorrespondanceId = dto.DeterminationCorrespondanceId;
            entity.IndividualFilingAppealName = dto.IndividualFilingAppealName;
            entity.IsTimely = dto.IsTimely;
            entity.NonTimelyNoteSetId = dto.NonTimelyNoteSetId;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.PhoneNumberExtn = dto.PhoneNumberExtn;
            entity.PremiumAppealDetailId = dto.PremiumAppealDetailId;
            entity.PremiumAppealHeaderId = dto.PremiumAppealHeaderId;
            entity.ReasonNoteSetId = dto.ReasonNoteSetId;
            entity.StatusCode = dto.StatusCode;
            entity.StatusDate = dto.StatusDate;
            entity.UpdateDateTime = dto.UpdateDateTime;
            entity.UpdateNumber = dto.UpdateNumber;
            entity.UpdateProcess = dto.UpdateProcess;
            entity.UpdateUserId = dto.UpdateUserId;

            var addressLink = (dto.AddressLink == null) ? null : AddressLink.FromDto(dbContext, dto.AddressLink, dtoEntities);
            entity.AddressLink = (dto.AddressLink == null || dto.AddressLink.IsDeleted) ? null : addressLink;
            var correspondence = (dto.Correspondence == null) ? null : Correspondence.FromDto(dbContext, dto.Correspondence, dtoEntities);
            entity.Correspondence = (dto.Correspondence == null || dto.Correspondence.IsDeleted) ? null : correspondence;
            var noteSetNonTimelyNoteSetId = (dto.NoteSetNonTimelyNoteSetId == null) ? null : NoteSet.FromDto(dbContext, dto.NoteSetNonTimelyNoteSetId, dtoEntities);
            entity.NoteSetNonTimelyNoteSetId = (dto.NoteSetNonTimelyNoteSetId == null || dto.NoteSetNonTimelyNoteSetId.IsDeleted) ? null : noteSetNonTimelyNoteSetId;
            var noteSetReasonNoteSetId = (dto.NoteSetReasonNoteSetId == null) ? null : NoteSet.FromDto(dbContext, dto.NoteSetReasonNoteSetId, dtoEntities);
            entity.NoteSetReasonNoteSetId = (dto.NoteSetReasonNoteSetId == null || dto.NoteSetReasonNoteSetId.IsDeleted) ? null : noteSetReasonNoteSetId;
            var premiumAppealHeader = (dto.PremiumAppealHeader == null) ? null : PremiumAppealHeader.FromDto(dbContext, dto.PremiumAppealHeader, dtoEntities);
            entity.PremiumAppealHeader = (dto.PremiumAppealHeader == null || dto.PremiumAppealHeader.IsDeleted) ? null : premiumAppealHeader;
        }

    }

    /// <summary>Extension methods related to PremiumAppealDetail entity</summary>
    public static class PremiumAppealDetailExtension
    {

        /// <summary>Convert IEnumerable PremiumAppealDetail to list of DTOs</summary>
        /// <param name="entities">IEnumerable PremiumAppealDetails</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO PremiumAppealDetails</returns>
        public static List<PremiumAppealDetailDto> ToDtoListDeep(this IEnumerable<PremiumAppealDetail> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<PremiumAppealDetailDto> dtos = new List<PremiumAppealDetailDto>();
            foreach (PremiumAppealDetail entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<PremiumAppealDetailDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E PremiumAppealDetail to list of DTOs</summary>
        /// <param name="entities">L2E PremiumAppealDetails</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO PremiumAppealDetails</returns>
        public static List<PremiumAppealDetailDto> ToDtoListDeep(this IQueryable<PremiumAppealDetail> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<PremiumAppealDetailDto> dtos = new List<PremiumAppealDetailDto>();
            foreach (PremiumAppealDetail entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<PremiumAppealDetailDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E PremiumAppealDetail to list of customized DTOs</summary>
        /// <typeparam name="T">Custom DTO derived from PremiumAppealDetailDto</typeparam>
        /// <param name="entities">L2E PremiumAppealDetails</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO customized PremiumAppealDetails</returns>
        public static List<T> ToDtoListDeep<T>(this IQueryable<PremiumAppealDetail> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes) where T : PremiumAppealDetailDto, new()
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<T> dtos = new List<T>();
            foreach (PremiumAppealDetail entity in entities)
            {
                dtos.Add((T)entity.ToDtoDeep(dbContext, new T(), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert IEnumerable PremiumAppealDetail to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">IEnumerable PremiumAppealDetails</param>
        /// <returns>List of DTO PremiumAppealDetails</returns>
        public static List<PremiumAppealDetailDto> ToDtoList(this IEnumerable<PremiumAppealDetail> entities)
        {
            List<PremiumAppealDetailDto> dtos = new List<PremiumAppealDetailDto>();
            foreach (PremiumAppealDetail entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E PremiumAppealDetail to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">L2E PremiumAppealDetails</param>
        /// <returns>List of DTO PremiumAppealDetails</returns>
        public static List<PremiumAppealDetailDto> ToDtoList(this IQueryable<PremiumAppealDetail> entities)
        {
            List<PremiumAppealDetailDto> dtos = new List<PremiumAppealDetailDto>();
            foreach (PremiumAppealDetail entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E PremiumAppealDetail to list of customized DTOs w/o checking entity state or entity navigation</summary>
        /// <typeparam name="T">Custom DTO derived from PremiumAppealDetailDto</typeparam>
        /// <param name="entities">L2E PremiumAppealDetails</param>
        /// <returns>List of DTO customized PremiumAppealDetails</returns>
        public static List<T> ToDtoList<T>(this IQueryable<PremiumAppealDetail> entities) where T : PremiumAppealDetailDto, new()
        {
            List<T> dtos = new List<T>();
            foreach (PremiumAppealDetail entity in entities)
            {
                dtos.Add((T)entity.ToDto(new T()));
            }
            return dtos;
        }

    }

}
