// ----------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a compiler emitter: FACTS.Framework.Analysis.Generators.OperationMethod.ControllerEmitter
//
// Changes to this file may cause incorrect behavior and will be lost when the code is regenerated.
// </auto-generated>
// ----------------------------------------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Mvc;
using FACTS.Framework.Service;

namespace PFML.Service.Controllers.Premium.WageDetail
{

    public class WageSubmissionController : Controller
    {

        [HttpPost]
        [Route("Premium/WageDetail/WageSubmission/GetWagePeriod")]
        [OperationMethodFilter]
        public PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission.WageSubmissionViewModel GetWagePeriod()
        {
            return PFML.BusinessLogic.Premium.WageDetail.WageSubmissionLogic.GetWagePeriod();
        }

        [HttpPost]
        [Route("Premium/WageDetail/WageSubmission/ValidateSelectionMethod")]
        [OperationMethodFilter]
        public PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission.WageSubmissionViewModel ValidateSelectionMethod([FromBody]PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission.WageSubmissionViewModel wageDetail)
        {
            return PFML.BusinessLogic.Premium.WageDetail.WageSubmissionLogic.ValidateSelectionMethod(wageDetail);
        }

        [HttpPost]
        [Route("Premium/WageDetail/WageSubmission/ValidateAndCalculateGrossWages")]
        [OperationMethodFilter]
        public PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission.WageSubmissionViewModel ValidateAndCalculateGrossWages([FromBody]PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission.WageSubmissionViewModel wageDetail)
        {
            return PFML.BusinessLogic.Premium.WageDetail.WageSubmissionLogic.ValidateAndCalculateGrossWages(wageDetail);
        }

        [HttpPost]
        [Route("Premium/WageDetail/WageSubmission/CalculateAndSavePremiumData")]
        [OperationMethodFilter]
        public PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission.WageSubmissionViewModel CalculateAndSavePremiumData([FromBody]PFML.Shared.ViewModels.Premium.WageDetail.WageSubmission.WageSubmissionViewModel wageDetail)
        {
            return PFML.BusinessLogic.Premium.WageDetail.WageSubmissionLogic.CalculateAndSavePremiumData(wageDetail);
        }

    }

}
