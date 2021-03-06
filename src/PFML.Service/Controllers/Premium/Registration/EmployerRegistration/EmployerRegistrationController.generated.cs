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

namespace PFML.Service.Controllers.Premium.Registration
{

    public class EmployerRegistrationController : Controller
    {

        [HttpPost]
        [Route("Premium/Registration/EmployerRegistration/ValidateIntroduction")]
        [OperationMethodFilter]
        public PFML.Shared.ViewModels.Premium.Registration.EmployerRegistrationViewModel ValidateIntroduction([FromBody]PFML.Shared.ViewModels.Premium.Registration.EmployerRegistrationViewModel employerRegistrationViewModel)
        {
            return PFML.BusinessLogic.Premium.Registration.EmployerRegistrationLogic.ValidateIntroduction(employerRegistrationViewModel);
        }

        [HttpPost]
        [Route("Premium/Registration/EmployerRegistration/SubmitRegistration")]
        [OperationMethodFilter]
        public PFML.Shared.ViewModels.Premium.Registration.EmployerRegistrationViewModel SubmitRegistration([FromBody]PFML.Shared.ViewModels.Premium.Registration.EmployerRegistrationViewModel employerRegistrationViewModel)
        {
            return PFML.BusinessLogic.Premium.Registration.EmployerRegistrationLogic.SubmitRegistration(employerRegistrationViewModel);
        }

        [HttpPost]
        [Route("Premium/Registration/EmployerRegistration/ValidateAdminInfo")]
        [OperationMethodFilter]
        public PFML.Shared.ViewModels.Premium.Registration.EmployerRegistrationViewModel ValidateAdminInfo([FromBody]PFML.Shared.ViewModels.Premium.Registration.EmployerRegistrationViewModel employerRegistrationViewModel)
        {
            return PFML.BusinessLogic.Premium.Registration.EmployerRegistrationLogic.ValidateAdminInfo(employerRegistrationViewModel);
        }

    }

}
