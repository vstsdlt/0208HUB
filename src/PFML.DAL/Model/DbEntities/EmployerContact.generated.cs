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

    /// <summary>[EmployerContact]</summary>
    [Table("EmployerContact", Schema="dbo")]
    public class EmployerContact : BaseEntity
    {

        /// <summary>[ContactTypeCode]</summary>
        [Required]
        [MaxLength(20)]
        [Column("ContactTypeCode")]
        public string ContactTypeCode { get; set; }

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

        /// <summary>[EmployerContactId]</summary>
        [Key]
        [Required]
        [Column("EmployerContactId", Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployerContactId { get; set; }

        /// <summary>[EmployerId]</summary>
        [Required]
        [Column("EmployerId")]
        public int EmployerId { get; set; }

        /// <summary>[FirstName]</summary>
        [Required]
        [MaxLength(30)]
        [Column("FirstName")]
        public string FirstName { get; set; }

        /// <summary>[LastName]</summary>
        [Required]
        [MaxLength(30)]
        [Column("LastName")]
        public string LastName { get; set; }

        /// <summary>[MiddleInitial]</summary>
        [MaxLength(1)]
        [Column("MiddleInitial")]
        public string MiddleInitial { get; set; }

        /// <summary>[PhoneNumber]</summary>
        [Required]
        [MaxLength(10)]
        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>[PhoneNumberExtn]</summary>
        [MaxLength(5)]
        [Column("PhoneNumberExtn")]
        public string PhoneNumberExtn { get; set; }

        /// <summary>[SecondaryPhoneNumber]</summary>
        [MaxLength(10)]
        [Column("SecondaryPhoneNumber")]
        public string SecondaryPhoneNumber { get; set; }

        /// <summary>[SecondaryPhoneNumberExtn]</summary>
        [MaxLength(5)]
        [Column("SecondaryPhoneNumberExtn")]
        public string SecondaryPhoneNumberExtn { get; set; }

        /// <summary>[StatusCode]</summary>
        [Required]
        [MaxLength(20)]
        [Column("StatusCode")]
        public string StatusCode { get; set; }

        /// <summary>[Title]</summary>
        [Required]
        [MaxLength(20)]
        [Column("Title")]
        public string Title { get; set; }

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
            builder.Entity<EmployerContact>().Property(x => x.ContactTypeCode).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.CreateUserId).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.Email).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.FirstName).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.LastName).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.MiddleInitial).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.PhoneNumber).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.PhoneNumberExtn).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.SecondaryPhoneNumber).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.SecondaryPhoneNumberExtn).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.StatusCode).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.Title).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.UpdateProcess).IsUnicode(false);
            builder.Entity<EmployerContact>().Property(x => x.UpdateUserId).IsUnicode(false);
            builder.Entity<EmployerContact>().HasRequired(x => x.Employer).WithMany(x => x.EmployerContacts).HasForeignKey(x => x.EmployerId);
        }

        /// <summary>Convert from EmployerContact entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant EmployerContact DTO</returns>
        public EmployerContactDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, null, dtoTypes, null);
        }

        /// <summary>Convert from EmployerContact entity to DTO</summary>
        /// <param name="dbContext">DB Context to use for setting DTO state</param>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>Resultant EmployerContact DTO</returns>
        public EmployerContactDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, EmployerContactDto dto, params Type[] dtoTypes)
        {
            return ToDtoDeep(dbContext, dto, dtoTypes, null);
        }

        internal EmployerContactDto ToDtoDeep(FACTS.Framework.DAL.DbContext dbContext, EmployerContactDto dto, Type[] dtoTypes, Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos)
        {
            entityDtos = entityDtos ?? new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            if (entityDtos.ContainsKey(this))
            {
                return (EmployerContactDto)entityDtos[this];
            }

            dto = ToDto(dto);
            entityDtos.Add(this, dto);

            System.Data.Entity.Infrastructure.DbEntityEntry<EmployerContact> entry = dbContext?.Entry(this);
            dto.IsNew = (entry?.State == EntityState.Added);
            dto.IsDeleted = (entry?.State == EntityState.Deleted);

            if (entry?.Reference(x => x.Employer)?.IsLoaded == true)
            {
                dto.Employer = Employer?.ToDtoDeep(dbContext, BaseEntity.ActivateDto<EmployerDto>(dtoTypes), dtoTypes, entityDtos);
            }

            return dto;
        }

        /// <summary>Convert from EmployerContact entity to DTO w/o checking entity state or entity navigation</summary>
        /// <param name="dto">DTO to use if already created instead of creating new one (can be inherited class instead as opposed to base class)</param>
        /// <returns>Resultant EmployerContact DTO</returns>
        public EmployerContactDto ToDto(EmployerContactDto dto = null)
        {
            dto = dto ?? new EmployerContactDto();
            dto.IsNew = false;

            dto.ContactTypeCode = ContactTypeCode;
            dto.CreateDateTime = CreateDateTime;
            dto.CreateUserId = CreateUserId;
            dto.Email = Email;
            dto.EmployerContactId = EmployerContactId;
            dto.EmployerId = EmployerId;
            dto.FirstName = FirstName;
            dto.LastName = LastName;
            dto.MiddleInitial = MiddleInitial;
            dto.PhoneNumber = PhoneNumber;
            dto.PhoneNumberExtn = PhoneNumberExtn;
            dto.SecondaryPhoneNumber = SecondaryPhoneNumber;
            dto.SecondaryPhoneNumberExtn = SecondaryPhoneNumberExtn;
            dto.StatusCode = StatusCode;
            dto.Title = Title;
            dto.UpdateDateTime = UpdateDateTime;
            dto.UpdateNumber = UpdateNumber;
            dto.UpdateProcess = UpdateProcess;
            dto.UpdateUserId = UpdateUserId;

            return dto;
        }

        /// <summary>Convert from EmployerContact DTO to entity</summary>
        /// <param name="dbContext">DB Context to use for attaching entity</param>
        /// <param name="dto">DTO to convert from</param>
        /// <returns>Resultant EmployerContact entity</returns>
        public static EmployerContact FromDto(FACTS.Framework.DAL.DbContext dbContext, EmployerContactDto dto)
        {
            return FromDto(dbContext, dto, dtoEntities: null);
        }

        internal static EmployerContact FromDto(FACTS.Framework.DAL.DbContext dbContext, EmployerContactDto dto, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            dtoEntities = dtoEntities ?? new Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity>();
            if (dtoEntities.ContainsKey(dto))
            {
                return (EmployerContact)dtoEntities[dto];
            }

            EmployerContact entity = new EmployerContact();
            dtoEntities.Add(dto, entity);
            FromDtoSet(dbContext, dto, entity, dtoEntities);

            if (dbContext != null && (!dto.IsDeleted || !dto.IsNew))
            {
                dbContext.Entry(entity).State = (dto.IsNew ? EntityState.Added : (dto.IsDeleted ? EntityState.Deleted : EntityState.Modified));
            }

            return entity;
        }

        protected static void FromDtoSet(FACTS.Framework.DAL.DbContext dbContext, EmployerContactDto dto, EmployerContact entity, Dictionary<FACTS.Framework.Dto.BaseDto, BaseEntity> dtoEntities)
        {
            entity.ContactTypeCode = dto.ContactTypeCode;
            entity.CreateDateTime = dto.CreateDateTime;
            entity.CreateUserId = dto.CreateUserId;
            entity.Email = dto.Email;
            entity.EmployerContactId = dto.EmployerContactId;
            entity.EmployerId = dto.EmployerId;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.MiddleInitial = dto.MiddleInitial;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.PhoneNumberExtn = dto.PhoneNumberExtn;
            entity.SecondaryPhoneNumber = dto.SecondaryPhoneNumber;
            entity.SecondaryPhoneNumberExtn = dto.SecondaryPhoneNumberExtn;
            entity.StatusCode = dto.StatusCode;
            entity.Title = dto.Title;
            entity.UpdateDateTime = dto.UpdateDateTime;
            entity.UpdateNumber = dto.UpdateNumber;
            entity.UpdateProcess = dto.UpdateProcess;
            entity.UpdateUserId = dto.UpdateUserId;

            var employer = (dto.Employer == null) ? null : Employer.FromDto(dbContext, dto.Employer, dtoEntities);
            entity.Employer = (dto.Employer == null || dto.Employer.IsDeleted) ? null : employer;
        }

    }

    /// <summary>Extension methods related to EmployerContact entity</summary>
    public static class EmployerContactExtension
    {

        /// <summary>Convert IEnumerable EmployerContact to list of DTOs</summary>
        /// <param name="entities">IEnumerable EmployerContacts</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO EmployerContacts</returns>
        public static List<EmployerContactDto> ToDtoListDeep(this IEnumerable<EmployerContact> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<EmployerContactDto> dtos = new List<EmployerContactDto>();
            foreach (EmployerContact entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<EmployerContactDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E EmployerContact to list of DTOs</summary>
        /// <param name="entities">L2E EmployerContacts</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO EmployerContacts</returns>
        public static List<EmployerContactDto> ToDtoListDeep(this IQueryable<EmployerContact> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes)
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<EmployerContactDto> dtos = new List<EmployerContactDto>();
            foreach (EmployerContact entity in entities)
            {
                dtos.Add(entity.ToDtoDeep(dbContext, BaseEntity.ActivateDto<EmployerContactDto>(dtoTypes), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert L2E EmployerContact to list of customized DTOs</summary>
        /// <typeparam name="T">Custom DTO derived from EmployerContactDto</typeparam>
        /// <param name="entities">L2E EmployerContacts</param>
        /// <param name="dbContext">DB Context to use for setting state of DTO</param>
        /// <param name="dtoTypes">Custom derived types to use for DTO's in hierarchy conversion</param>
        /// <returns>List of DTO customized EmployerContacts</returns>
        public static List<T> ToDtoListDeep<T>(this IQueryable<EmployerContact> entities, FACTS.Framework.DAL.DbContext dbContext, params Type[] dtoTypes) where T : EmployerContactDto, new()
        {
            Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto> entityDtos = new Dictionary<BaseEntity, FACTS.Framework.Dto.BaseDto>();
            List<T> dtos = new List<T>();
            foreach (EmployerContact entity in entities)
            {
                dtos.Add((T)entity.ToDtoDeep(dbContext, new T(), dtoTypes, entityDtos));
            }
            return dtos;
        }

        /// <summary>Convert IEnumerable EmployerContact to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">IEnumerable EmployerContacts</param>
        /// <returns>List of DTO EmployerContacts</returns>
        public static List<EmployerContactDto> ToDtoList(this IEnumerable<EmployerContact> entities)
        {
            List<EmployerContactDto> dtos = new List<EmployerContactDto>();
            foreach (EmployerContact entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E EmployerContact to list of DTOs w/o checking entity state or entity navigation</summary>
        /// <param name="entities">L2E EmployerContacts</param>
        /// <returns>List of DTO EmployerContacts</returns>
        public static List<EmployerContactDto> ToDtoList(this IQueryable<EmployerContact> entities)
        {
            List<EmployerContactDto> dtos = new List<EmployerContactDto>();
            foreach (EmployerContact entity in entities)
            {
                dtos.Add(entity.ToDto());
            }
            return dtos;
        }

        /// <summary>Convert L2E EmployerContact to list of customized DTOs w/o checking entity state or entity navigation</summary>
        /// <typeparam name="T">Custom DTO derived from EmployerContactDto</typeparam>
        /// <param name="entities">L2E EmployerContacts</param>
        /// <returns>List of DTO customized EmployerContacts</returns>
        public static List<T> ToDtoList<T>(this IQueryable<EmployerContact> entities) where T : EmployerContactDto, new()
        {
            List<T> dtos = new List<T>();
            foreach (EmployerContact entity in entities)
            {
                dtos.Add((T)entity.ToDto(new T()));
            }
            return dtos;
        }

    }

}
