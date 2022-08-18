using System;
using System.Collections.Generic;
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
    public class InventoryItemMasterBR : IInventoryItemMasterBR
    {
		public InventoryItemMasterBR()
		{
		}
		/// <summary>
		/// Validate method to insert record from InventoryItemMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse InsertInventoryItemMasterValidate(InventoryItemMaster item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateInsertInventoryItemMaster(item))
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
		/// Validate method to update record from InventoryItemMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse UpdateInventoryItemMasterValidate(InventoryItemMaster item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateUpdateInventoryItemMaster(item))
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
		/// Validate method to delete record from InventoryItemMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse DeleteInventoryItemMasterValidate(InventoryItemMaster item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateDeleteInventoryItemMaster(item))
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
		/// Validation on insert InventoryItemMasterproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateInsertInventoryItemMaster(InventoryItemMaster request)
		{
			//We need to Implment this validation method properly
			 return true;
		}
		/// <summary>
		/// Validation on update InventoryItemMasterproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateUpdateInventoryItemMaster(InventoryItemMaster request)
		{
			//We need to Implment this validation method properly
            return true;
		}
		/// <summary>
		/// Validation on delete InventoryItemMasterproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateDeleteInventoryItemMaster(InventoryItemMaster request)
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
