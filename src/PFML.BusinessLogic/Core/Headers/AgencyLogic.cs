using System;
using System.Collections.Generic;
using System.Linq;
using FACTS.Framework.DAL;
using FACTS.Framework.Service;
using PFML.Shared.ViewModels.Core.Headers.Agency;
using DbContext = PFML.DAL.Model.DbContext;

namespace PFML.BusinessLogic.Core.Headers
{

    public static class AgencyLogic
    {

        /// <summary>Return a blank copy of search criteria</summary>
        /// <returns>New copy of search critiera object</returns>
        [OperationMethod]
        public static SearchCriteria BlankSearchCriteria()
        {
            return new SearchCriteria();
        }

        /// <summary>Search for agency based on search critiera</summary>
        /// <param name="criteria">Criteria to use for filtering search results</param>
        /// <returns>List of agencies that match search criteria</returns>
        [OperationMethod]
        public static List<ResultRecord> Search(SearchCriteria criteria)
        {
            using (DbContext context = new DbContext())
            {
                //var query = (from a in context.Agencies
                //             orderby a.AgencyName
                //             select new ResultRecord
                //             {
                //                Id = a.AgencyID,
                //                Name = a.AgencyName,
                //                Code = a.AgencyCode,
                //                Status = a.StatusCode
                //             });

                //query = query.ConditionalWhere(criteria.Name, q => q.Name.Contains(criteria.Name));

                //query = query.Take(501);
                //return query.ToList();
                return null;
            }
        }

        /// <summary>Fetch agency record for setting into Context</summary>
        /// <param name="id">Id of record to fetch</param>
        /// <returns>Agency record for setting into context</returns>
        [OperationMethod]
        public static Record Fetch(int id)
        {
            using (DbContext context = new DbContext())
            {
                //var query = (from a in context.Agencies
                //             where a.AgencyID == id
                //             select new Record
                //             {
                //                 ID = a.AgencyID,
                //                 Name = a.AgencyName,
                //                 Code = a.AgencyCode,
                //                 Status = a.StatusCode
                //             });

                //return query.FirstOrDefault();
                return null;
            }
        }

    }

}
