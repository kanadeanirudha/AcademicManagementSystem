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
    public class FeeLateFeesMasterBR : IFeeLateFeesMasterBR
    {
		public FeeLateFeesMasterBR()
		{
		}
		/// <summary>
		/// Validate method to insert record from FeeLateFeesMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse InsertFeeLateFeesMasterValidate(FeeLateFeesMaster item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateInsertFeeLateFeesMaster(item))
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
		/// Validate method to update record from FeeLateFeesMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse UpdateFeeLateFeesMasterValidate(FeeLateFeesMaster item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateUpdateFeeLateFeesMaster(item))
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
		/// Validate method to delete record from FeeLateFeesMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse DeleteFeeLateFeesMasterValidate(FeeLateFeesMaster item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateDeleteFeeLateFeesMaster(item))
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
		/// Validation on insert FeeLateFeesMasterproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateInsertFeeLateFeesMaster(FeeLateFeesMaster request)
		{
			//We need to Implment this validation method properly
			 return true;
		}
		/// <summary>
		/// Validation on update FeeLateFeesMasterproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateUpdateFeeLateFeesMaster(FeeLateFeesMaster request)
		{
			//We need to Implment this validation method properly
            return true;
		}
		/// <summary>
		/// Validation on delete FeeLateFeesMasterproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateDeleteFeeLateFeesMaster(FeeLateFeesMaster request)
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
