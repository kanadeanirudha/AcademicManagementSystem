using AMS.Base.DTO;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
	public class StudentSectionChangeRequestBR : IStudentSectionChangeRequestBR
	{
		public StudentSectionChangeRequestBR()
		{
		}
		/// <summary>
		/// Validate method to insert record from StudentSectionChangeRequest.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse InsertStudentSectionChangeRequestValidate(StudentSectionChangeRequest item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateInsertStudentSectionChangeRequest(item))
				{
					 businessResponse.Passed = false;
					businessResponse.Message.Add(new MessageDTO
					{
						MessageType = MessageTypeEnum.Error,
						ErrorMessage = "pass error message"
					});
				}
				else
				{
					businessResponse.Passed = true;
				}
			}
			catch (Exception ex)
			{
				businessResponse.Message.Add(new MessageDTO
				{
					MessageType = MessageTypeEnum.Error,
					ErrorMessage = ex.Message
				});
			}
			return businessResponse;
		}
		/// <summary>
		/// Validate method to update record from StudentSectionChangeRequest.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse UpdateStudentSectionChangeRequestValidate(StudentSectionChangeRequest item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateUpdateStudentSectionChangeRequest(item))
				{
					 businessResponse.Passed = false;
					businessResponse.Message.Add(new MessageDTO
					{
						MessageType = MessageTypeEnum.Error,
						ErrorMessage = "pass error message"
					});
				}
				else
				{
					businessResponse.Passed = true;
				}
			}
			catch (Exception ex)
			{
				businessResponse.Message.Add(new MessageDTO
				{
					MessageType = MessageTypeEnum.Error,
					ErrorMessage = ex.Message
				});
			}
			return businessResponse;
		}
		/// <summary>
		/// Validate method to delete record from StudentSectionChangeRequest.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse DeleteStudentSectionChangeRequestValidate(StudentSectionChangeRequest item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateDeleteStudentSectionChangeRequest(item))
				{
					 businessResponse.Passed = false;
					businessResponse.Message.Add(new MessageDTO
					{
						MessageType = MessageTypeEnum.Error,
						ErrorMessage = "pass error message"
					});
				}
				else
				{
					businessResponse.Passed = true;
				}
			}
			catch (Exception ex)
			{
				businessResponse.Message.Add(new MessageDTO
				{
					MessageType = MessageTypeEnum.Error,
					ErrorMessage = ex.Message
				});
			}
			return businessResponse;
		}
		/// <summary>
		/// Validation on insert StudentSectionChangeRequestproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateInsertStudentSectionChangeRequest(StudentSectionChangeRequest request)
		{
			//We need to Implment this validation method properly
			 return true;
		}
		/// <summary>
		/// Validation on update StudentSectionChangeRequestproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateUpdateStudentSectionChangeRequest(StudentSectionChangeRequest request)
		{
			//We need to Implment this validation method properly
			 return true;
		}
		/// <summary>
		/// Validation on delete StudentSectionChangeRequestproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateDeleteStudentSectionChangeRequest(StudentSectionChangeRequest request)
		{
			try
			{
				return (!string.IsNullOrEmpty(Convert.ToString(request.ID)));
			}
			catch (Exception)
			{
				 return false;
			}
		}
	}
}
