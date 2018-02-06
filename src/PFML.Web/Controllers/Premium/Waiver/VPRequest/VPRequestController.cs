using System;
using System.Collections.Generic;
using FACTS.Framework.Lookup;
using FACTS.Framework.Support;
using FACTS.Framework.Utility;
using FACTS.Framework.Web;
using PFML.Shared.LookupTable;
using PFML.Shared.Model.DbDtos;
using PFML.Shared.Utility;

namespace PFML.Web.Controllers.Premium.Waiver.VPRequest
{

	public class VPRequestController : Controller
	{

		public void MachineExecute()
		{
			Machine["EmployerId"] = 1;
		}

		public void EditUpload()
		{
			var request = (VoluntaryPlanWaiverRequestDto)Machine["Form"];
			if (request.FormAttachments.Count > 10)
			{
				Context.ValidationMessages.AddError("You can not upload more than 10 supporting documents");
			}
			else
			{
				//Making the Machine of Document and Description to be null otherwise upload document page is showing the pervious value
				Machine["DocumentDescription"] = null; // TODO : Kumar - Need to check with Dave to resovle this.
				Machine["DocumentName"] = null;
			}
		}

		public void UploadNext()
		{
			var form = (VoluntaryPlanWaiverRequestDto)Machine["Form"];
			form.FormAttachments.Add(new FormAttachmentDto()
			{
				Document = new DocumentDto()
				{
					DocumentDescription = Machine["DocumentDescription"].ToString(),
					DocumentName = Machine["DocumentName"].ToString()
				}
			});
		}

		public void EditSubmit()
		{
			var form = (VoluntaryPlanWaiverRequestDto)Machine["Form"];
			if (form.FormAttachments.Count == 0)
			{
				Context.ValidationMessages.AddError("Atleast one supporting document should upload to submit the request");
			}
			if (!form.IsVoluntaryPlanWaiverRequestAcknowledged)
			{
				Context.ValidationMessages.AddError("You must agree to the T&C to submit your request");
			}
			form.EmployerId = (int)Machine["EmployerId"];
			form.FormTypeCode = LookupTable_FormType.VPWaiverForm;
			form.StatusCode = LookupTable_WaiverRequestStatus.SavedasDraft;
			Machine["IsEdit"] = form.FormId > 0 ? true : false;
		}

		public void CancelYes()
		{
			VoluntaryPlanWaiverRequestDto form = (VoluntaryPlanWaiverRequestDto)Machine["Form"];
			form.VoluntaryPlanWaiverRequestTypes.RemoveAll(r => string.IsNullOrEmpty(r.LeaveTypeCode));

			if (form.FormId > 0 && Machine["LeaveTypes"] != null)
			{
				form.VoluntaryPlanWaiverRequestTypes.AddRange((List<VoluntaryPlanWaiverRequestTypeDto>)Machine["LeaveTypes"]);
			}
		}

		public void PresetNext()
		{
			VoluntaryPlanWaiverRequestDto form = (VoluntaryPlanWaiverRequestDto)Machine["Form"];
			if (form.FormId > 0)
			{
				List<VoluntaryPlanWaiverRequestTypeDto> leaveTypes = new List<VoluntaryPlanWaiverRequestTypeDto>();
				form.VoluntaryPlanWaiverRequestTypes.ForEach(x => leaveTypes.Add(x));
				leaveTypes.ForEach(x => form.VoluntaryPlanWaiverRequestTypes.Add(new VoluntaryPlanWaiverRequestTypeDto()
				{
					LeaveTypeCode = x.LeaveTypeCode,
					DurationInWeeksCode = x.DurationInWeeksCode,
					PercentagePaid = x.PercentagePaid
				}));
				form.VoluntaryPlanWaiverRequestTypes.RemoveAll(p => p.FormId > 0);
				leaveTypes.ForEach(p => p.IsDeleted = (p.FormId > 0));
				Machine["LeaveTypes"] = leaveTypes;
			}
			Machine["TypeMedicalIndex"] = GetLeaveTypeIndex(form, LookupTable_WaiverLeaveType.Medical);
			Machine["TypeBirthIndex"] = GetLeaveTypeIndex(form, LookupTable_WaiverLeaveType.PaternityBirthFather);
			Machine["TypeAdoptionIndex"] = GetLeaveTypeIndex(form, LookupTable_WaiverLeaveType.PaternityAdoption);
			Machine["TypeCaregiverIndex"] = GetLeaveTypeIndex(form, LookupTable_WaiverLeaveType.Caregiver);
			Machine["MinStartDate"] = form.FormId > 0 ? form.StartDate : DateTimeUtil.Today;
		}

		#region Private Methods
		private int GetLeaveTypeIndex(VoluntaryPlanWaiverRequestDto form, string leaveTypeCode)
		{
			int? index = form.VoluntaryPlanWaiverRequestTypes?.FindIndex(x => x.LeaveTypeCode == leaveTypeCode);
			if (!index.HasValue || index.Value < 0)
			{
				form.VoluntaryPlanWaiverRequestTypes.Add(new VoluntaryPlanWaiverRequestTypeDto());
				index = form.VoluntaryPlanWaiverRequestTypes.Count - 1;
			}
			return index.Value;
		}
		#endregion

	}

}