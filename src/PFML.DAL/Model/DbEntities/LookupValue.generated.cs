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

    /// <summary>[LookupValue]</summary>
    [Table("LookupValue", Schema="dbo")]
    public class LookupValue : BaseEntity
    {

        /// <summary>[Code]</summary>
        [Key]
        [Required]
        [MaxLength(20)]
        [Column("Code", Order=2)]
        public string Code { get; set; }

        /// <summary>[CreateDateTime]</summary>
        [Required]
        [Column("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }

        /// <summary>[CreateUserId]</summary>
        [Required]
        [MaxLength(50)]
        [Column("CreateUserId")]
        public string CreateUserId { get; set; }

        /// <summary>[Description]</summary>
        [MaxLength(500)]
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>[Name]</summary>
        [Key]
        [Required]
        [MaxLength(50)]
        [Column("Name", Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }

        /// <summary>[Property]</summary>
        [Key]
        [Required]
        [MaxLength(50)]
        [Column("Property", Order=3)]
        public string Property { get; set; }

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

        /// <summary>[Value]</summary>
        [Required]
        [MaxLength(100)]
        [Column("Value")]
        public string Value { get; set; }

        public virtual LookupCode LookupCode { get; set; }

        public virtual LookupProperty LookupProperty { get; set; }

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
            builder.Entity<LookupValue>().Property(x => x.Code).IsUnicode(false);
            builder.Entity<LookupValue>().Property(x => x.CreateUserId).IsUnicode(false);
            builder.Entity<LookupValue>().Property(x => x.Description).IsUnicode(false);
            builder.Entity<LookupValue>().Property(x => x.Name).IsUnicode(false);
            builder.Entity<LookupValue>().Property(x => x.Property).IsUnicode(false);
            builder.Entity<LookupValue>().Property(x => x.UpdateProcess).IsUnicode(false);
            builder.Entity<LookupValue>().Property(x => x.UpdateUserId).IsUnicode(false);
            builder.Entity<LookupValue>().Property(x => x.Value).IsUnicode(false);
            builder.Entity<LookupValue>().HasRequired(x => x.LookupCode).WithMany(x => x.LookupValues).HasForeignKey(x => new { x.Name, x.Code });
            builder.Entity<LookupValue>().HasRequired(x => x.LookupProperty).WithMany(x => x.LookupValues).HasForeignKey(x => new { x.Name, x.Property });
        }

        /// <summary>Convert from LookupValue entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant LookupValue DTO</returns>
        public LookupValueDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, null, dtoTypes, null);
        }

        /// <summary>Convert from LookupValue entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant LookupValue DTO</returns>
        public LookupValueDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, LookupValueDto dto, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, dto, dtoTypes, null);
        }

        internal LookupValueDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, LookupValueDto dto, Type[] dtoTypes, Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos)
        {
            entityDtos = entityDtos ?? new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            if (entityDtos.ContainsKey(this))
            {
                return (LookupValueDto)entityDtos[this];
            }

            dto = ToDto(dto);
            entityDtos.Add(this, dto);

            System.Data.Entity.Infrastructure.DbEntityEntry<LookupValue> entry = dbContext?.Entry(this);
            dto.IsNew = (entry?.State == EntityState.Added);
            dto.IsDeleted = (entry?.State == EntityState.Deleted);

            if (entry?.Reference(x => x.LookupCode)?.IsLoaded == true)
            {
                dto.LookupCode = LookupCode?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<LookupCodeDto>(dtoTypes), dtoTypes, entityDtos);
            }
            if (entry?.Reference(x => x.LookupProperty)?.IsLoaded == true)
            {
                dto.LookupProperty = LookupProperty?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<LookupPropertyDto>(dtoTypes), dtoTypes, entityDtos);
            }

            return dto;
        }

        /// <summary>Convert from LookupValue entity to DTO w/o checking entity state or entity navigation</summary>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <returns>Resultant LookupValue DTO</returns>
        public LookupValueDto ToDto(LookupValueDto dto = null)
        {
            dto = dto ?? new LookupValueDto();
            dto.IsNew = false;

            dto.Code = Code;
            dto.CreateDateTime = CreateDateTime;
            dto.CreateUserId = CreateUserId;
            dto.Description = Description;
            dto.Name = Name;
            dto.Property = Property;
            dto.UpdateDateTime = UpdateDateTime;
            dto.UpdateNumber = UpdateNumber;
            dto.UpdateProcess = UpdateProcess;
            dto.UpdateUserId = UpdateUserId;
            dto.Value = Value;

            return dto;
        }

        /// <summary>Convert from LookupValue DTO to entity</summary>
        /// <param name="dbContext">DB Context to use for attaching entity</param>
        /// <param name="dto">DTO to convert from</param>
        /// <returns>Resultant LookupValue entity</returns>
        public static LookupValue FromDto(FACTS.Framework.DAL.DbContext dbContext, LookupValueDto dto)
        {
            return FromDto(dbContext, dto, dtoEntities: null);
        }

        internal static LookupValue FromDto(FACTS.Framework.DAL.DbContext dbContext, LookupValueDto dto, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            dtoEntities = dtoEntities ?? new Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity>();
            if (dtoEntities.ContainsKey(dto))
            {
                return (LookupValue)dtoEntities[dto];
            }

            LookupValue entity = new LookupValue();
            dtoEntities.Add(dto, entity);
            FromDtoSet(dbContext, dto, entity, dtoEntities);

            if (dbContext != null && (!dto.IsDeleted || !dto.IsNew))
            {
                dbContext.Entry(entity).State = (dto.IsNew ? EntityState.Added : (dto.IsDeleted ? EntityState.Deleted : EntityState.Modified));
            }

            return entity;
        }

        protected static void FromDtoSet(FACTS.Framework.DAL.DbContext dbContext, LookupValueDto dto, LookupValue entity, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            entity.Code = dto.Code;
            entity.CreateDateTime = dto.CreateDateTime;
            entity.CreateUserId = dto.CreateUserId;
            entity.Description = dto.Description;
            entity.Name = dto.Name;
            entity.Property = dto.Property;
            entity.UpdateDateTime = dto.UpdateDateTime;
            entity.UpdateNumber = dto.UpdateNumber;
            entity.UpdateProcess = dto.UpdateProcess;
            entity.UpdateUserId = dto.UpdateUserId;
            entity.Value = dto.Value;

            var lookupCode = (dto.LookupCode == null) ? null : LookupCode.FromDto(dbContext, dto.LookupCode, dtoEntities);
            entity.LookupCode = (dto.LookupCode == null || dto.LookupCode.IsDeleted) ? null : lookupCode;
            var lookupProperty = (dto.LookupProperty == null) ? null : LookupProperty.FromDto(dbContext, dto.LookupProperty, dtoEntities);
            entity.LookupProperty = (dto.LookupProperty == null || dto.LookupProperty.IsDeleted) ? null : lookupProperty;
        }

    }

    /// <summary>Extension methods related to LookupValue entity</summary>
    public static class LookupValueExtension
    {

        /// <summary>Convert IEnumerable LookupValue to list of DTOs</summary>
        /// <param name="entities">IEnumerable LookupValues</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO LookupValues</returns>
        public static List<LookupValueDto> ToDtoListDeep(this IEnumerable<LookupValue> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<LookupValueDto> dtos = new List<LookupValueDto>();
            foreach (LookupValue entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<LookupValueDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E LookupValue to list of DTOs</summary>
        /// <param name="entities">L2E LookupValues</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO LookupValues</returns>
        public static List<LookupValueDto> ToDtoListDeep(this IQueryable<LookupValue> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<LookupValueDto> dtos = new List<LookupValueDto>();
            foreach (LookupValue entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<LookupValueDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E LookupValue to list of customized DTOs</summary>
        /// <typeparam name="T">Custom DTO derived from LookupValueDto</typeparam>
        /// <param name="entities">L2E LookupValues</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO customized LookupValues</returns>
        public static List<T> ToDtoListDeep<T>(this IQueryable<LookupValue> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes) where T : LookupValueDto, new()
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<T> dtos = new List<T>();
            foreach (LookupValue entity in entities)
            {
                dtos.Add((T)entity.ToDtoDeep(dbContext, new T(), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert IEnumerable LookupValue to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">IEnumerable LookupValues</param>
        /// <returns>List of DTO LookupValues</returns>
        public static List<LookupValueDto> ToDtoList(this IEnumerable<LookupValue> entities)
        {
            List<LookupValueDto> dtos = new List<LookupValueDto>();
            foreach (LookupValue entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E LookupValue to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">L2E LookupValues</param>
        /// <returns>List of DTO LookupValues</returns>
        public static List<LookupValueDto> ToDtoList(this IQueryable<LookupValue> entities)
        {
            List<LookupValueDto> dtos = new List<LookupValueDto>();
            foreach (LookupValue entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E LookupValue to list of customized DTOs w/o checking entity state or entity navigation</summary>
        /// <typeparam name="T">Custom DTO derived from LookupValueDto</typeparam>
        /// <param name="entities">L2E LookupValues</param>
        /// <returns>List of DTO customized LookupValues</returns>
        public static List<T> ToDtoList<T>(this IQueryable<LookupValue> entities) where T : LookupValueDto, new()
        {
            List<T> dtos = new List<T>();
            foreach (LookupValue entity in entities)
            {
                dtos.Add((T)entity.ToDto(new T()));
            }
            return dtos;
        }

    }

}