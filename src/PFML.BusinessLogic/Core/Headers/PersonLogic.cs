using System;
using System.Collections.Generic;
using System.Linq;
using FACTS.Framework.DAL;
using FACTS.Framework.Formatters;
using FACTS.Framework.Service;
using FACTS.Framework.Utility;
using PFML.Shared.ViewModels.Core.Headers.Person;
using DbContext = PFML.DAL.Model.DbContext;
using PFML.Shared.LookupTable;

namespace PFML.BusinessLogic.Core.Headers
{

    public static class PersonLogic
    {

        /// <summary>Return a blank copy of search criteria</summary>
        /// <returns>New copy of search critiera object</returns>
        [OperationMethod]
        public static SearchCriteria BlankSearchCriteria()
        {
            return new SearchCriteria();
        }

        /// <summary>Search for people based on search critiera</summary>
        /// <param name="criteria">Criteria to use for filtering search results</param>
        /// <returns>List of people that match search criteria</returns>
        [OperationMethod]
        public static List<ResultRecord> Search(SearchCriteria criteria)
        {
            using (DbContext context = new DbContext())
            {
                //var query = (from p in context.People
                //             orderby p.LastName, p.FirstName, p.MiddleName
                //             select new
                //             {
                //                 p.FirstName,
                //                 p.LastName,
                //                 p.MiddleName,
                //                 p.SuffixCode,
                //                 p.Last4SsnEinID,
                //                 ResultRecord = new ResultRecord
                //                 {
                //                     Id = p.PersonID,
                //                     Ssn = p.SsnEinID,
                //                     AgencyNum = 0,         //TODO: ?? - need to assign agency
                //                     PlanCode = null,       //TODO: ?? - need to assign plan code
                //                     LastCheckDate = null,  //TODO: ?? - need to assign last check date
                //                     IsRetired = p.RetiredMemberInd == "Y",
                //                     DateOfBirth = p.BirthDate,
                //                     GenderCode = p.GenderCode
                //                 }
                //             });

                //query = query.ConditionalWhere(criteria?.Ssn?.Length == 9, q => q.ResultRecord.Ssn == criteria.Ssn);
                //query = query.ConditionalWhere(criteria?.Ssn?.Length == 4, q => q.Last4SsnEinID == criteria.Ssn);
                //query = query.ConditionalWhere(criteria.Name, q => q.FirstName.Contains(criteria.Name) || q.LastName.Contains(criteria.Name) || q.MiddleName.Contains(criteria.Name));  //TODO: ?? enhance to support case-insensitive searching for Oracle?

                //var records = query.Take(501).ToList();
                //foreach (var record in records)
                //{
                //    record.ResultRecord.Name = StringUtil.FormatName(record.FirstName, record.MiddleName, record.LastName, record.SuffixCode);
                //}

                //return records.Select(r => r.ResultRecord).ToList();
                return null;
            }
        }

        /// <summary>Fetch person record for setting into Context</summary>
        /// <param name="id">Id of record to fetch</param>
        /// <returns>Person record for setting into context</returns>
        [OperationMethod]
        public static Record Fetch(int id)
        {
            using (DbContext context = new DbContext())
            {
                //var query = (from p in context.People
                //             let a = p.Addresses.FirstOrDefault()
                //             let pc_email = p.PersonContacts.Where(pc => pc.InvalidContactInfoInd == "N" && pc.PersonContactTypeCode == LookupTable_PersonContactType.EmailAddress).OrderByDescending(pc => pc.PreferredContactInd).FirstOrDefault()
                //             let pc_phone = p.PersonContacts.Where(pc => pc.InvalidContactInfoInd == "N" && (pc.PersonContactTypeCode == LookupTable_PersonContactType.HomePhoneNumber || pc.PersonContactTypeCode == LookupTable_PersonContactType.MobilePhoneNumber)).OrderByDescending(pc => pc.PreferredContactInd).FirstOrDefault()
                //             orderby p.LastName, p.FirstName, p.MiddleName
                //             where p.PersonID == id
                //             select new
                //             {
                //                 p.FirstName,
                //                 p.LastName,
                //                 p.MiddleName,
                //                 p.SuffixCode,
                //                 a.Line1Address,
                //                 a.Line2Address,
                //                 a.City,
                //                 a.StateCode,
                //                 Postal = a.ZipCode,
                //                 Record = new Record
                //                 {
                //                     ID = p.PersonID,
                //                     Ssn = p.SsnEinID,
                //                     DateOfBirth = p.BirthDate,
                //                     DateOfDeath = p.DeathDate,
                //                     GenderCode = p.GenderCode,
                //                     Email = pc_email.PersonContactTypeText,
                //                     Phone = pc_phone.PersonContactTypeText
                //                 }
                //             });

                //var record = query.FirstOrDefault();

                //if (record != null)
                //{
                //    record.Record.Name = StringUtil.FormatName(record.FirstName, record.MiddleName, record.LastName, record.SuffixCode);
                //    record.Record.FormattedAddressLine1 = record.Line2Address;
                //    record.Record.FormattedAddressLine2 = record.City;
                //    record.Record.FormattedAddressLine2 += (!string.IsNullOrEmpty(record.Record.FormattedAddressLine2) ? ", " : "") + record.StateCode;
                //    record.Record.FormattedAddressLine2 += (!string.IsNullOrEmpty(record.Record.FormattedAddressLine2) ? " " : "") + FormatterUtil.Format(Formatter.Postal, record.Postal);
                //}

                //return record.Record;
                return null;
            }
        }

    }

}
