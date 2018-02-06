using FACTS.Framework.Service;
using FACTS.Framework.Support;
using FACTS.Framework.Utility;
using PFML.DAL.Model.DbEntities;
using PFML.Shared.LookupTable;
using PFML.Shared.Model.DbDtos;
using PFML.Shared.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using DbContext = PFML.DAL.Model.DbContext;

namespace PFML.BusinessLogic.Premium.Waiver.VPRequest
{

	public static class VPRequestLogic
	{
		/// <summary>
		/// Fetch the Summary of the VP Waiver Request by the Employer
		/// </summary>
		/// <param name="employerId">Employer ID</param>
		/// <returns>List<VoluntaryPlanWaiverRequestDto></returns>
		[OperationMethod]
		public static List<VoluntaryPlanWaiverRequestDto> FetchSummary(int? employerId)
		{
			if (employerId is null)
			{
				return new List<VoluntaryPlanWaiverRequestDto>();
			}
			else
			{
				using (DbContext context = new DbContext())
				{
					var query = (from vpwr in context.VoluntaryPlanWaiverRequests
								 where vpwr.EmployerId == employerId
								 orderby vpwr.UpdateDateTime descending
								 select vpwr)?.ToDtoListDeep(context);

					return query;
				}
			}
		}

		/// <summary>
		/// Fetch the VP Waiver Request along with Leave Type and Supporting Document collection
		/// </summary>
		/// <param name="form">VoluntaryPlanWaiverRequestDto</param>
		/// <returns>VoluntaryPlanWaiverRequestDto</returns>
		[OperationMethod]
		public static VoluntaryPlanWaiverRequestDto Fetch(VoluntaryPlanWaiverRequestDto form)
		{
			using (DbContext context = new DbContext())
			{
				var record = (from vpwr in context.VoluntaryPlanWaiverRequests
							  .Include("VoluntaryPlanWaiverRequestTypes")
							  .Include("FormAttachments.Document")
							  where vpwr.FormId == form.FormId
							  select vpwr).FirstOrDefault();
				VoluntaryPlanWaiverRequestDto result = record.ToDtoDeep(context);
				return result;
			}
		}

		/// <summary>
		/// Submit VP Waiver Form (New/Edit)
		/// </summary>
		/// <param name="form">VoluntaryPlanWaiverRequestDto</param>
		/// <returns>None</returns>
		[OperationMethod]
		public static void Submit(VoluntaryPlanWaiverRequestDto form, List<VoluntaryPlanWaiverRequestTypeDto> leaveRequestTypes)
		{
			ExecuteSubmitRequestRules(form);
			if (Context.ValidationMessages.Count(ValidationMessageSeverity.Error) > 0)
			{
				Context.ValidationMessages.ThrowCheck(ValidationMessageSeverity.Error);
			}
			using (DbContext context = new DbContext())
			{
				if (form.FormId > 0 && leaveRequestTypes.Any())
				{
					foreach (var item in leaveRequestTypes)
					{
						var requestType = context.VoluntaryPlanWaiverRequestTypes.FirstOrDefault(x => x.FormId == item.FormId && x.LeaveTypeCode == item.LeaveTypeCode);
						context.VoluntaryPlanWaiverRequestTypes.Remove(requestType);
					}
				}
				form.VoluntaryPlanWaiverRequestTypes.RemoveAll(r => (r.FormId == 0 && string.IsNullOrEmpty(r.LeaveTypeCode)));
				VoluntaryPlanWaiverRequest.FromDto(context, form);
				context.SaveChanges();
			}
		}

		/// <summary>
		/// Preset any value which support VP Waiver Form submit/load -- Placeholder
		/// </summary>
		/// <returns>VoluntaryPlanWaiverRequestDto</returns>
		[OperationMethod]
		public static VoluntaryPlanWaiverRequestDto Preset(VoluntaryPlanWaiverRequestDto form)
		{
			if (form.FormId == 0)
			{
				form = new VoluntaryPlanWaiverRequestDto
				{
					StartDate = DateTimeUtil.Now,
					EndDate = new DateTime(DateTimeUtil.Now.Year, 12, 31)
				};
			}
			return form;
		}

		/// <summary>
		/// Delete the attachment while editing the request
		/// </summary>
		/// <param name="form">Form</param>
		/// <param name="formAttachment">Document</param>
		/// <returns>VoluntaryPlanWaiverRequestDto</returns>
		[OperationMethod]
		public static VoluntaryPlanWaiverRequestDto Delete(VoluntaryPlanWaiverRequestDto form, FormAttachmentDto formAttachment)
		{
			if (form is null || formAttachment is null)
			{
				Context.ValidationMessages.AddError("Form or FormAttachment parameters are missing");
				Context.ValidationMessages.ThrowCheck(ValidationMessageSeverity.Error);
			}
			using (DbContext context = new DbContext())
			{
				form.VoluntaryPlanWaiverRequestTypes.RemoveAll(r => string.IsNullOrEmpty(r.LeaveTypeCode));
				form.FormAttachments.ForEach(x => x.Document.IsDeleted = (x.FormAttachmentId == formAttachment.FormAttachmentId));
				form.FormAttachments.ForEach(x => x.IsDeleted = (x.FormAttachmentId == formAttachment.FormAttachmentId));
				VoluntaryPlanWaiverRequest.FromDto(context, form);
				context.SaveChanges();
				return Fetch(form);
			}
		}

		#region Business Rules
		/// <summary>
		/// Business Rule to satisfy the VP Waiver Form
		/// </summary>
		/// <param name="VPRequestForm">VoluntaryPlanWaiverRequestDto</param>
		/// <retuns>None</retuns>
		private static void ExecuteSubmitRequestRules(VoluntaryPlanWaiverRequestDto VPRequestForm)
		{
			if (VPRequestForm.StartDate.Date < DateTime.Today.Date)
			{
				Context.ValidationMessages.AddError("Start Date cannot be before today.");
			}

			if (VPRequestForm.EndDate.Date < VPRequestForm.StartDate.Date)
			{
				Context.ValidationMessages.AddError("End date cannot be before Start date.");
			}

			if (VPRequestForm.EndDate.Date > VPRequestForm.StartDate.Date.AddYears(1).AddDays(-1))
			{
				Context.ValidationMessages.AddError("End Date cannot be more than 1 year after the Start Date");
			}

			if (!VPRequestForm.IsVoluntaryPlanWaiverRequestAcknowledged)
			{
				Context.ValidationMessages.AddError("You must acknowledge and agree to the T&C to submit your request");
			}

			if (VPRequestForm.VoluntaryPlanWaiverRequestTypes.All(p => p.LeaveTypeCode == null))
			{
				Context.ValidationMessages.AddError("Atleast one Leave Type should be selected");
				return;
			}

			if (VPRequestForm.VoluntaryPlanWaiverRequestTypes.Any(
				p => !string.IsNullOrWhiteSpace(p.LeaveTypeCode)
				&& (string.IsNullOrWhiteSpace(p.DurationInWeeksCode)
				|| (p.PercentagePaid <= 0)
				)))
			{
				Context.ValidationMessages.AddError("Weeks Available annually and/or Percentage of Wages Paid are required fields for the selected leave type");
			}
			else
			{
				if (VPRequestForm.VoluntaryPlanWaiverRequestTypes.Any(
					p => string.IsNullOrWhiteSpace(p.LeaveTypeCode)
					&& (!string.IsNullOrWhiteSpace(p.DurationInWeeksCode)
					&& (p.PercentagePaid > 0)
					)))
				{
					Context.ValidationMessages.AddError("Please select leave type for given Weeks and Precentage");
				}
				if (VPRequestForm.VoluntaryPlanWaiverRequestTypes.Any(
					p => string.IsNullOrWhiteSpace(p.LeaveTypeCode)
					&& (string.IsNullOrWhiteSpace(p.DurationInWeeksCode)
					&& (p.PercentagePaid > 0)
					)))
				{
					Context.ValidationMessages.AddError("Please select Weeks Available annually and select leave type");
				}
				if (VPRequestForm.VoluntaryPlanWaiverRequestTypes.Any(
					p => string.IsNullOrWhiteSpace(p.LeaveTypeCode)
					&& (!string.IsNullOrWhiteSpace(p.DurationInWeeksCode)
					&& (p.PercentagePaid <= 0)
					)))
				{
					Context.ValidationMessages.AddError("Please provide Percentage of wages paid and select leave type");
				}
			}
		}
		#endregion
	}
}
