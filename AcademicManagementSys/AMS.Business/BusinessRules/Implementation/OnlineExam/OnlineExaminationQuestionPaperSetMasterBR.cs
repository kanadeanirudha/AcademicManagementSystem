using AMS.Base.DTO;
using AMS.DTO;
using System;
using AMS.Common;
namespace AMS.Business.BusinessRules
{
	public class OnlineExaminationQuestionPaperSetMasterBR : IOnlineExaminationQuestionPaperSetMasterBR
	{
		public OnlineExaminationQuestionPaperSetMasterBR()
		{
		}
		/// <summary>
		/// Validate method to insert record from OnlineExaminationQuestionPaperSetMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse InsertOnlineExaminationQuestionPaperSetMasterValidate(OnlineExaminationQuestionPaperSetMaster item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateInsertOnlineExaminationQuestionPaperSetMaster(item))
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
		/// Validate method to update record from OnlineExaminationQuestionPaperSetMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse UpdateOnlineExaminationQuestionPaperSetMasterValidate(OnlineExaminationQuestionPaperSetMaster item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateUpdateOnlineExaminationQuestionPaperSetMaster(item))
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
		/// Validate method to delete record from OnlineExaminationQuestionPaperSetMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IValidateBusinessRuleResponse DeleteOnlineExaminationQuestionPaperSetMasterValidate(OnlineExaminationQuestionPaperSetMaster item)
			{
			IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
			try
			{
				//Check null exception
				if (item == null)
				{
					throw new ArgumentNullException(Resources.InvalidArgumentsError);
				}
				if (!ValidateDeleteOnlineExaminationQuestionPaperSetMaster(item))
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
		/// Validation on insert OnlineExaminationQuestionPaperSetMasterproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateInsertOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster request)
		{
			//We need to Implment this validation method properly
            return true;
		}
		/// <summary>
		/// Validation on update OnlineExaminationQuestionPaperSetMasterproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateUpdateOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster request)
		{
			//We need to Implment this validation method properly
			 return true;
		}
		/// <summary>
		/// Validation on delete OnlineExaminationQuestionPaperSetMasterproperty.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		private bool ValidateDeleteOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster request)
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
