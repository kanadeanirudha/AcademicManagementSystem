using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Common;
using AMS.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public class InventoryEstimationMasterAndDetailsBR : IInventoryEstimationMasterAndDetailsBR
    {
		public InventoryEstimationMasterAndDetailsBR()
		{
		}
		/// <summary>
		/// Validate method to insert record from InventoryEstimationMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse InsertInventoryEstimationMasterAndDetailsValidate(InventoryEstimationMasterAndDetails item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateInsertInventoryEstimationMasterAndDetails(item))
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
		/// Validate method to update record from InventoryEstimationMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse UpdateInventoryEstimationMasterAndDetailsValidate(InventoryEstimationMasterAndDetails item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateUpdateInventoryEstimationMasterAndDetails(item))
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
		/// Validate method to delete record from InventoryEstimationMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse DeleteInventoryEstimationMasterAndDetailsValidate(InventoryEstimationMasterAndDetails item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateDeleteInventoryEstimationMasterAndDetails(item))
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
		/// Validation on insert InventoryEstimationMasterAndDetailsproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateInsertInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails request)
		{
			//We need to Implment this validation method properly
			 return true;
		}
		/// <summary>
		/// Validation on update InventoryEstimationMasterAndDetailsproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateUpdateInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails request)
		{
			//We need to Implment this validation method properly
            return true;
		}
		/// <summary>
		/// Validation on delete InventoryEstimationMasterAndDetailsproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateDeleteInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails request)
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
