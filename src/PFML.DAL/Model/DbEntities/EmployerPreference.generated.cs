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

    /// <summary>[EmployerPreference]</summary>
    [Table("EmployerPreference", Schema="dbo")]
    public class EmployerPreference : BaseEntity
    {

        /// <summary>[CorrespondanceTypeCode]</summary>
        [Required]
        [MaxLength(20)]
        [Column("CorrespondanceTypeCode")]
        public string CorrespondanceTypeCode { get; set; }

        /// <summary>[CreateDateTime]</summary>
        [Required]
        [Column("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }

        /// <summary>[CreateUserId]</summary>
        [Required]
        [MaxLength(50)]
        [Column("CreateUserId")]
        public string CreateUserId { get; set; }

        /// <summary>[Email]</summary>
        [MaxLength(80)]
        [Column("Email")]
        public string Email { get; set; }

        /// <summary>[EmployerId]</summary>
        [Key]
        [Required]
        [Column("EmployerId", Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployerId { get; set; }

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

        public virtual Employer Employer { get; set; }

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
            builder.Entity<EmployerPreference>().Property(x => x.CorrespondanceTypeCode).IsUnicode(false);
            builder.Entity<EmployerPreference>().Property(x => x.CreateUserId).IsUnicode(false);
            builder.Entity<EmployerPreference>().Property(x => x.Email).IsUnicode(false);
            builder.Entity<EmployerPreference>().Property(x => x.UpdateProcess).IsUnicode(false);
            builder.Entity<EmployerPreference>().Property(x => x.UpdateUserId).IsUnicode(false);
            builder.Entity<EmployerPreference>().HasRequired(x => x.Employer).WithRequiredDependent(x => x.EmployerPreference);
        }

        /// <summary>Convert from EmployerPreference entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant EmployerPreference DTO</returns>
        public EmployerPreferenceDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, null, dtoTypes, null);
        }

        /// <summary>Convert from EmployerPreference entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant EmployerPreference DTO</returns>
        public EmployerPreferenceDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, EmployerPreferenceDto dto, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, dto, dtoTypes, null);
        }

        internal EmployerPreferenceDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, EmployerPreferenceDto dto, Type[] dtoTypes, Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos)
        {
            entityDtos = entityDtos ?? new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            if (entityDtos.ContainsKey(this))
            {
                return (EmployerPreferenceDto)entityDtos[this];
            }

            dto = ToDto(dto);
            entityDtos.Add(this, dto);

            System.Data.Entity.Infrastructure.DbEntityEntry<EmployerPreference> entry = dbContext?.Entry(this);
            dto.IsNew = (entry?.State == EntityState.Added);
            dto.IsDeleted = (entry?.State == EntityState.Deleted);

            if (entry?.Reference(x => x.Employer)?.IsLoaded == true)
            {
                dto.Employer = Employer?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<EmployerDto>(dtoTypes), dtoTypes, entityDtos);
            }

            return dto;
        }

        /// <summary>Convert from EmployerPreference entity to DTO w/o checking entity state or entity navigation</summary>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <returns>Resultant EmployerPreference DTO</returns>
        public EmployerPreferenceDto ToDto(EmployerPreferenceDto dto = null)
        {
            dto = dto ?? new EmployerPreferenceDto();
            dto.IsNew = false;

            dto.CorrespondanceTypeCode = CorrespondanceTypeCode;
            dto.CreateDateTime = CreateDateTime;
            dto.CreateUserId = CreateUserId;
            dto.Email = Email;
            dto.EmployerId = EmployerId;
            dto.UpdateDateTime = UpdateDateTime;
            dto.UpdateNumber = UpdateNumber;
            dto.UpdateProcess = UpdateProcess;
            dto.UpdateUserId = UpdateUserId;

            return dto;
        }

        /// <summary>Convert from EmployerPreference DTO to entity</summary>
        /// <param name="dbContext">DB Context to use for attaching entity</param>
        /// <param name="dto">DTO to convert from</param>
        /// <returns>Resultant EmployerPreference entity</returns>
        public static EmployerPreference FromDto(FACTS.Framework.DAL.DbContext dbContext, EmployerPreferenceDto dto)
        {
            return FromDto(dbContext, dto, dtoEntities: null);
        }

        internal static EmployerPreference FromDto(FACTS.Framework.DAL.DbContext dbContext, EmployerPreferenceDto dto, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            dtoEntities = dtoEntities ?? new Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity>();
            if (dtoEntities.ContainsKey(dto))
            {
                return (EmployerPreference)dtoEntities[dto];
            }

            EmployerPreference entity = new EmployerPreference();
            dtoEntities.Add(dto, entity);
            FromDtoSet(dbContext, dto, entity, dtoEntities);

            if (dbContext != null && (!dto.IsDeleted || !dto.IsNew))
            {
                dbContext.Entry(entity).State = (dto.IsNew ? EntityState.Added : (dto.IsDeleted ? EntityState.Deleted : EntityState.Modified));
            }

            return entity;
        }

        protected static void FromDtoSet(FACTS.Framework.DAL.DbContext dbContext, EmployerPreferenceDto dto, EmployerPreference entity, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            entity.CorrespondanceTypeCode = dto.CorrespondanceTypeCode;
            entity.CreateDateTime = dto.CreateDateTime;
            entity.CreateUserId = dto.CreateUserId;
            entity.Email = dto.Email;
            entity.EmployerId = dto.EmployerId;
            entity.UpdateDateTime = dto.UpdateDateTime;
            entity.UpdateNumber = dto.UpdateNumber;
            entity.UpdateProcess = dto.UpdateProcess;
            entity.UpdateUserId = dto.UpdateUserId;

            var employer = (dto.Employer == null) ? null : Employer.FromDto(dbContext, dto.Employer, dtoEntities);
            entity.Employer = (dto.Employer == null || dto.Employer.IsDeleted) ? null : employer;
        }

    }

    /// <summary>Extension methods related to EmployerPreference entity</summary>
    public static class EmployerPreferenceExtension
    {

        /// <summary>Convert IEnumerable EmployerPreference to list of DTOs</summary>
        /// <param name="entities">IEnumerable EmployerPreferences</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO EmployerPreferences</returns>
        public static List<EmployerPreferenceDto> ToDtoListDeep(this IEnumerable<EmployerPreference> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<EmployerPreferenceDto> dtos = new List<EmployerPreferenceDto>();
            foreach (EmployerPreference entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<EmployerPreferenceDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E EmployerPreference to list of DTOs</summary>
        /// <param name="entities">L2E EmployerPreferences</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO EmployerPreferences</returns>
        public static List<EmployerPreferenceDto> ToDtoListDeep(this IQueryable<EmployerPreference> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<EmployerPreferenceDto> dtos = new List<EmployerPreferenceDto>();
            foreach (EmployerPreference entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<EmployerPreferenceDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E EmployerPreference to list of customized DTOs</summary>
        /// <typeparam name="T">Custom DTO derived from EmployerPreferenceDto</typeparam>
        /// <param name="entities">L2E EmployerPreferences</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO customized EmployerPreferences</returns>
        public static List<T> ToDtoListDeep<T>(this IQueryable<EmployerPreference> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes) where T : EmployerPreferenceDto, new()
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<T> dtos = new List<T>();
            foreach (EmployerPreference entity in entities)
            {
                dtos.Add((T)entity.ToDtoDeep(dbContext, new T(), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert IEnumerable EmployerPreference to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">IEnumerable EmployerPreferences</param>
        /// <returns>List of DTO EmployerPreferences</returns>
        public static List<EmployerPreferenceDto> ToDtoList(this IEnumerable<EmployerPreference> entities)
        {
            List<EmployerPreferenceDto> dtos = new List<EmployerPreferenceDto>();
            foreach (EmployerPreference entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E EmployerPreference to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">L2E EmployerPreferences</param>
        /// <returns>List of DTO EmployerPreferences</returns>
        public static List<EmployerPreferenceDto> ToDtoList(this IQueryable<EmployerPreference> entities)
        {
            List<EmployerPreferenceDto> dtos = new List<EmployerPreferenceDto>();
            foreach (EmployerPreference entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E EmployerPreference to list of customized DTOs w/o checking entity state or entity navigation</summary>
        /// <typeparam name="T">Custom DTO derived from EmployerPreferenceDto</typeparam>
        /// <param name="entities">L2E EmployerPreferences</param>
        /// <returns>List of DTO customized EmployerPreferences</returns>
        public static List<T> ToDtoList<T>(this IQueryable<EmployerPreference> entities) where T : EmployerPreferenceDto, new()
        {
            List<T> dtos = new List<T>();
            foreach (EmployerPreference entity in entities)
            {
                dtos.Add((T)entity.ToDto(new T()));
            }
            return dtos;
        }

    }

}
