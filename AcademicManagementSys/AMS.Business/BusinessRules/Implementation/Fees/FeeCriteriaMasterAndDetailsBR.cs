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
    public class FeeCriteriaMasterAndDetailsBR : IFeeCriteriaMasterAndDetailsBR
    {
		public FeeCriteriaMasterAndDetailsBR()
		{
		}
		/// <summary>
		/// Validate method to insert record from FeeCriteriaMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse InsertFeeCriteriaMasterAndDetailsValidate(FeeCriteriaMasterAndDetails item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateInsertFeeCriteriaMasterAndDetails(item))
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
		/// Validate method to update record from FeeCriteriaMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse UpdateFeeCriteriaMasterAndDetailsValidate(FeeCriteriaMasterAndDetails item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateUpdateFeeCriteriaMasterAndDetails(item))
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
		/// Validate method to delete record from FeeCriteriaMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse DeleteFeeCriteriaMasterAndDetailsValidate(FeeCriteriaMasterAndDetails item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateDeleteFeeCriteriaMasterAndDetails(item))
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
		/// Validation on insert FeeCriteriaMasterAndDetailsproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateInsertFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails request)
		{
			//We need to Implment this validation method properly
			 return true;
		}
		/// <summary>
		/// Validation on update FeeCriteriaMasterAndDetailsproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateUpdateFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails request)
		{
			//We need to Implment this validation method properly
            return true;
		}
		/// <summary>
		/// Validation on delete FeeCriteriaMasterAndDetailsproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateDeleteFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails request)
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
