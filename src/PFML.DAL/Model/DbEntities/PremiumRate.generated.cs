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

    /// <summary>[PremiumRate]</summary>
    [Table("PremiumRate", Schema="dbo")]
    public class PremiumRate : BaseEntity
    {

        /// <summary>[PremiumRate]</summary>
        [Required]
        [Column("PremiumRate")]
        public decimal _PremiumRate { get; set; }

        /// <summary>[CreateDateTime]</summary>
        [Required]
        [Column("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }

        /// <summary>[CreateUserId]</summary>
        [Required]
        [MaxLength(50)]
        [Column("CreateUserId")]
        public string CreateUserId { get; set; }

        /// <summary>[EffectiveBeginDate]</summary>
        [Required]
        [Column("EffectiveBeginDate")]
        public DateTime EffectiveBeginDate { get; set; }

        /// <summary>[EffectiveEndDate]</summary>
        [Column("EffectiveEndDate")]
        public DateTime? EffectiveEndDate { get; set; }

        /// <summary>[PremiumRateId]</summary>
        [Key]
        [Required]
        [Column("PremiumRateId", Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PremiumRateId { get; set; }

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
            builder.Entity<PremiumRate>().Property(x => x._PremiumRate).HasPrecision(6, 3);
            builder.Entity<PremiumRate>().Property(x => x.CreateUserId).IsUnicode(false);
            builder.Entity<PremiumRate>().Property(x => x.UpdateProcess).IsUnicode(false);
            builder.Entity<PremiumRate>().Property(x => x.UpdateUserId).IsUnicode(false);
        }

        /// <summary>Convert from PremiumRate entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant PremiumRate DTO</returns>
        public PremiumRateDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, null, dtoTypes, null);
        }

        /// <summary>Convert from PremiumRate entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant PremiumRate DTO</returns>
        public PremiumRateDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, PremiumRateDto dto, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, dto, dtoTypes, null);
        }

        internal PremiumRateDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, PremiumRateDto dto, Type[] dtoTypes, Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos)
        {
            entityDtos = entityDtos ?? new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            if (entityDtos.ContainsKey(this))
            {
                return (PremiumRateDto)entityDtos[this];
            }

            dto = ToDto(dto);
            entityDtos.Add(this, dto);

            System.Data.Entity.Infrastructure.DbEntityEntry<PremiumRate> entry = dbContext?.Entry(this);
            dto.IsNew = (entry?.State == EntityState.Added);
            dto.IsDeleted = (entry?.State == EntityState.Deleted);


            return dto;
        }

        /// <summary>Convert from PremiumRate entity to DTO w/o checking entity state or entity navigation</summary>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <returns>Resultant PremiumRate DTO</returns>
        public PremiumRateDto ToDto(PremiumRateDto dto = null)
        {
            dto = dto ?? new PremiumRateDto();
            dto.IsNew = false;

            dto._PremiumRate = _PremiumRate;
            dto.CreateDateTime = CreateDateTime;
            dto.CreateUserId = CreateUserId;
            dto.EffectiveBeginDate = EffectiveBeginDate;
            dto.EffectiveEndDate = EffectiveEndDate;
            dto.PremiumRateId = PremiumRateId;
            dto.UpdateDateTime = UpdateDateTime;
            dto.UpdateNumber = UpdateNumber;
            dto.UpdateProcess = UpdateProcess;
            dto.UpdateUserId = UpdateUserId;

            return dto;
        }

        /// <summary>Convert from PremiumRate DTO to entity</summary>
        /// <param name="dbContext">DB Context to use for attaching entity</param>
        /// <param name="dto">DTO to convert from</param>
        /// <returns>Resultant PremiumRate entity</returns>
        public static PremiumRate FromDto(FACTS.Framework.DAL.DbContext dbContext, PremiumRateDto dto)
        {
            return FromDto(dbContext, dto, dtoEntities: null);
        }

        internal static PremiumRate FromDto(FACTS.Framework.DAL.DbContext dbContext, PremiumRateDto dto, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            dtoEntities = dtoEntities ?? new Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity>();
            if (dtoEntities.ContainsKey(dto))
            {
                return (PremiumRate)dtoEntities[dto];
            }

            PremiumRate entity = new PremiumRate();
            dtoEntities.Add(dto, entity);
            FromDtoSet(dbContext, dto, entity, dtoEntities);

            if (dbContext != null && (!dto.IsDeleted || !dto.IsNew))
            {
                dbContext.Entry(entity).State = (dto.IsNew ? EntityState.Added : (dto.IsDeleted ? EntityState.Deleted : EntityState.Modified));
            }

            return entity;
        }

        protected static void FromDtoSet(FACTS.Framework.DAL.DbContext dbContext, PremiumRateDto dto, PremiumRate entity, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            entity._PremiumRate = dto._PremiumRate;
            entity.CreateDateTime = dto.CreateDateTime;
            entity.CreateUserId = dto.CreateUserId;
            entity.EffectiveBeginDate = dto.EffectiveBeginDate;
            entity.EffectiveEndDate = dto.EffectiveEndDate;
            entity.PremiumRateId = dto.PremiumRateId;
            entity.UpdateDateTime = dto.UpdateDateTime;
            entity.UpdateNumber = dto.UpdateNumber;
            entity.UpdateProcess = dto.UpdateProcess;
            entity.UpdateUserId = dto.UpdateUserId;

        }

    }

    /// <summary>Extension methods related to PremiumRate entity</summary>
    public static class PremiumRateExtension
    {

        /// <summary>Convert IEnumerable PremiumRate to list of DTOs</summary>
        /// <param name="entities">IEnumerable PremiumRates</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO PremiumRates</returns>
        public static List<PremiumRateDto> ToDtoListDeep(this IEnumerable<PremiumRate> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<PremiumRateDto> dtos = new List<PremiumRateDto>();
            foreach (PremiumRate entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<PremiumRateDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E PremiumRate to list of DTOs</summary>
        /// <param name="entities">L2E PremiumRates</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO PremiumRates</returns>
        public static List<PremiumRateDto> ToDtoListDeep(this IQueryable<PremiumRate> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<PremiumRateDto> dtos = new List<PremiumRateDto>();
            foreach (PremiumRate entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<PremiumRateDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E PremiumRate to list of customized DTOs</summary>
        /// <typeparam name="T">Custom DTO derived from PremiumRateDto</typeparam>
        /// <param name="entities">L2E PremiumRates</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO customized PremiumRates</returns>
        public static List<T> ToDtoListDeep<T>(this IQueryable<PremiumRate> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes) where T : PremiumRateDto, new()
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<T> dtos = new List<T>();
            foreach (PremiumRate entity in entities)
            {
                dtos.Add((T)entity.ToDtoDeep(dbContext, new T(), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert IEnumerable PremiumRate to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">IEnumerable PremiumRates</param>
        /// <returns>List of DTO PremiumRates</returns>
        public static List<PremiumRateDto> ToDtoList(this IEnumerable<PremiumRate> entities)
        {
            List<PremiumRateDto> dtos = new List<PremiumRateDto>();
            foreach (PremiumRate entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E PremiumRate to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">L2E PremiumRates</param>
        /// <returns>List of DTO PremiumRates</returns>
        public static List<PremiumRateDto> ToDtoList(this IQueryable<PremiumRate> entities)
        {
            List<PremiumRateDto> dtos = new List<PremiumRateDto>();
            foreach (PremiumRate entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E PremiumRate to list of customized DTOs w/o checking entity state or entity navigation</summary>
        /// <typeparam name="T">Custom DTO derived from PremiumRateDto</typeparam>
        /// <param name="entities">L2E PremiumRates</param>
        /// <returns>List of DTO customized PremiumRates</returns>
        public static List<T> ToDtoList<T>(this IQueryable<PremiumRate> entities) where T : PremiumRateDto, new()
        {
            List<T> dtos = new List<T>();
            foreach (PremiumRate entity in entities)
            {
                dtos.Add((T)entity.ToDto(new T()));
            }
            return dtos;
        }

    }

}
