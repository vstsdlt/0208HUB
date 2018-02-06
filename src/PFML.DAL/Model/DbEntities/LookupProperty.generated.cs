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

    /// <summary>[LookupProperty]</summary>
    [Table("LookupProperty", Schema="dbo")]
    public class LookupProperty : BaseEntity
    {

        /// <summary>[CreateDateTime]</summary>
        [Required]
        [Column("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }

        /// <summary>[CreateUserId]</summary>
        [Required]
        [MaxLength(50)]
        [Column("CreateUserId")]
        public string CreateUserId { get; set; }

        /// <summary>[DataType]</summary>
        [Required]
        [MaxLength(50)]
        [Column("DataType")]
        public string DataType { get; set; }

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
        [Column("Property", Order=2)]
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

        public virtual LookupName LookupName { get; set; }

        private ICollection<LookupValue> lookupValues { get; set; }
        public virtual ICollection<LookupValue> LookupValues { get { return lookupValues ?? (lookupValues = new Collection<LookupValue>()); } protected set { lookupValues = value; } }

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
            builder.Entity<LookupProperty>().Property(x => x.CreateUserId).IsUnicode(false);
            builder.Entity<LookupProperty>().Property(x => x.DataType).IsUnicode(false);
            builder.Entity<LookupProperty>().Property(x => x.Description).IsUnicode(false);
            builder.Entity<LookupProperty>().Property(x => x.Name).IsUnicode(false);
            builder.Entity<LookupProperty>().Property(x => x.Property).IsUnicode(false);
            builder.Entity<LookupProperty>().Property(x => x.UpdateProcess).IsUnicode(false);
            builder.Entity<LookupProperty>().Property(x => x.UpdateUserId).IsUnicode(false);
            builder.Entity<LookupProperty>().HasRequired(x => x.LookupName).WithMany(x => x.LookupProperties).HasForeignKey(x => x.Name);
        }

        /// <summary>Convert from LookupProperty entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant LookupProperty DTO</returns>
        public LookupPropertyDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, null, dtoTypes, null);
        }

        /// <summary>Convert from LookupProperty entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant LookupProperty DTO</returns>
        public LookupPropertyDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, LookupPropertyDto dto, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, dto, dtoTypes, null);
        }

        internal LookupPropertyDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, LookupPropertyDto dto, Type[] dtoTypes, Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos)
        {
            entityDtos = entityDtos ?? new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            if (entityDtos.ContainsKey(this))
            {
                return (LookupPropertyDto)entityDtos[this];
            }

            dto = ToDto(dto);
            entityDtos.Add(this, dto);

            System.Data.Entity.Infrastructure.DbEntityEntry<LookupProperty> entry = dbContext?.Entry(this);
            dto.IsNew = (entry?.State == EntityState.Added);
            dto.IsDeleted = (entry?.State == EntityState.Deleted);

            if (entry?.Reference(x => x.LookupName)?.IsLoaded == true)
            {
                dto.LookupName = LookupName?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<LookupNameDto>(dtoTypes), dtoTypes, entityDtos);
            }
            if (entry?.Collection(x => x.LookupValues)?.IsLoaded == true)
            {
                foreach (LookupValue lookupValue in LookupValues)
                {
                    dto.LookupValues.Add(lookupValue.ToDtoDeep(dbContext, BaseEntity.ActivateDto<LookupValueDto>(dtoTypes), dtoTypes, entityDtos));
                }
            }

            return dto;
        }

        /// <summary>Convert from LookupProperty entity to DTO w/o checking entity state or entity navigation</summary>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <returns>Resultant LookupProperty DTO</returns>
        public LookupPropertyDto ToDto(LookupPropertyDto dto = null)
        {
            dto = dto ?? new LookupPropertyDto();
            dto.IsNew = false;

            dto.CreateDateTime = CreateDateTime;
            dto.CreateUserId = CreateUserId;
            dto.DataType = DataType;
            dto.Description = Description;
            dto.Name = Name;
            dto.Property = Property;
            dto.UpdateDateTime = UpdateDateTime;
            dto.UpdateNumber = UpdateNumber;
            dto.UpdateProcess = UpdateProcess;
            dto.UpdateUserId = UpdateUserId;

            return dto;
        }

        /// <summary>Convert from LookupProperty DTO to entity</summary>
        /// <param name="dbContext">DB Context to use for attaching entity</param>
        /// <param name="dto">DTO to convert from</param>
        /// <returns>Resultant LookupProperty entity</returns>
        public static LookupProperty FromDto(FACTS.Framework.DAL.DbContext dbContext, LookupPropertyDto dto)
        {
            return FromDto(dbContext, dto, dtoEntities: null);
        }

        internal static LookupProperty FromDto(FACTS.Framework.DAL.DbContext dbContext, LookupPropertyDto dto, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            dtoEntities = dtoEntities ?? new Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity>();
            if (dtoEntities.ContainsKey(dto))
            {
                return (LookupProperty)dtoEntities[dto];
            }

            LookupProperty entity = new LookupProperty();
            dtoEntities.Add(dto, entity);
            FromDtoSet(dbContext, dto, entity, dtoEntities);

            if (dbContext != null && (!dto.IsDeleted || !dto.IsNew))
            {
                dbContext.Entry(entity).State = (dto.IsNew ? EntityState.Added : (dto.IsDeleted ? EntityState.Deleted : EntityState.Modified));
            }

            return entity;
        }

        protected static void FromDtoSet(FACTS.Framework.DAL.DbContext dbContext, LookupPropertyDto dto, LookupProperty entity, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            entity.CreateDateTime = dto.CreateDateTime;
            entity.CreateUserId = dto.CreateUserId;
            entity.DataType = dto.DataType;
            entity.Description = dto.Description;
            entity.Name = dto.Name;
            entity.Property = dto.Property;
            entity.UpdateDateTime = dto.UpdateDateTime;
            entity.UpdateNumber = dto.UpdateNumber;
            entity.UpdateProcess = dto.UpdateProcess;
            entity.UpdateUserId = dto.UpdateUserId;

            var lookupName = (dto.LookupName == null) ? null : LookupName.FromDto(dbContext, dto.LookupName, dtoEntities);
            entity.LookupName = (dto.LookupName == null || dto.LookupName.IsDeleted) ? null : lookupName;
            if (dto.LookupValues != null)
            {
                foreach (LookupValueDto lookupValueDto in dto.LookupValues)
                {
                    var lookupValue = DbEntities.LookupValue.FromDto(dbContext, lookupValueDto, dtoEntities);
                    if (lookupValueDto.IsDeleted)
                    {
                        continue;
                    }
                    entity.LookupValues.Add(lookupValue);
                }
            }
        }

    }

    /// <summary>Extension methods related to LookupProperty entity</summary>
    public static class LookupPropertyExtension
    {

        /// <summary>Convert IEnumerable LookupProperty to list of DTOs</summary>
        /// <param name="entities">IEnumerable LookupProperties</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO LookupProperties</returns>
        public static List<LookupPropertyDto> ToDtoListDeep(this IEnumerable<LookupProperty> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<LookupPropertyDto> dtos = new List<LookupPropertyDto>();
            foreach (LookupProperty entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<LookupPropertyDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E LookupProperty to list of DTOs</summary>
        /// <param name="entities">L2E LookupProperties</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO LookupProperties</returns>
        public static List<LookupPropertyDto> ToDtoListDeep(this IQueryable<LookupProperty> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<LookupPropertyDto> dtos = new List<LookupPropertyDto>();
            foreach (LookupProperty entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<LookupPropertyDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E LookupProperty to list of customized DTOs</summary>
        /// <typeparam name="T">Custom DTO derived from LookupPropertyDto</typeparam>
        /// <param name="entities">L2E LookupProperties</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO customized LookupProperties</returns>
        public static List<T> ToDtoListDeep<T>(this IQueryable<LookupProperty> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes) where T : LookupPropertyDto, new()
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<T> dtos = new List<T>();
            foreach (LookupProperty entity in entities)
            {
                dtos.Add((T)entity.ToDtoDeep(dbContext, new T(), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert IEnumerable LookupProperty to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">IEnumerable LookupProperties</param>
        /// <returns>List of DTO LookupProperties</returns>
        public static List<LookupPropertyDto> ToDtoList(this IEnumerable<LookupProperty> entities)
        {
            List<LookupPropertyDto> dtos = new List<LookupPropertyDto>();
            foreach (LookupProperty entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E LookupProperty to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">L2E LookupProperties</param>
        /// <returns>List of DTO LookupProperties</returns>
        public static List<LookupPropertyDto> ToDtoList(this IQueryable<LookupProperty> entities)
        {
            List<LookupPropertyDto> dtos = new List<LookupPropertyDto>();
            foreach (LookupProperty entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E LookupProperty to list of customized DTOs w/o checking entity state or entity navigation</summary>
        /// <typeparam name="T">Custom DTO derived from LookupPropertyDto</typeparam>
        /// <param name="entities">L2E LookupProperties</param>
        /// <returns>List of DTO customized LookupProperties</returns>
        public static List<T> ToDtoList<T>(this IQueryable<LookupProperty> entities) where T : LookupPropertyDto, new()
        {
            List<T> dtos = new List<T>();
            foreach (LookupProperty entity in entities)
            {
                dtos.Add((T)entity.ToDto(new T()));
            }
            return dtos;
        }

    }

}