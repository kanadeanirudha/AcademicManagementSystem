using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public class EntranceExamScheduleAndScheduleDetailBA : IEntranceExamScheduleAndScheduleDetailBA
    {
        IEntranceExamScheduleAndScheduleDetailDataProvider _entranceExamScheduleAndScheduleDetailDataProvider;
        IEntranceExamScheduleAndScheduleDetailBR _entranceExamScheduleAndScheduleDetailBR;
        private ILogger _logException;

        public EntranceExamScheduleAndScheduleDetailBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _entranceExamScheduleAndScheduleDetailBR = new EntranceExamScheduleAndScheduleDetailBR();
            _entranceExamScheduleAndScheduleDetailDataProvider = new EntranceExamScheduleAndScheduleDetailDataProvider();
		}

       
        /// Create new record of EntranceExamSchedule.        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> InsertEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> entityResponse = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamScheduleAndScheduleDetailBR.InsertEntranceExamScheduleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamScheduleAndScheduleDetailDataProvider.InsertEntranceExamSchedule(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
       
        /// Update a specific record  of EntranceExamSchedule.        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> UpdateEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> entityResponse = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamScheduleAndScheduleDetailBR.UpdateEntranceExamScheduleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamScheduleAndScheduleDetailDataProvider.UpdateEntranceExamSchedule(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        /// Delete a selected record from EntranceExamSchedule.
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> DeleteEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> entityResponse = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamScheduleAndScheduleDetailBR.DeleteEntranceExamScheduleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamScheduleAndScheduleDetailDataProvider.DeleteEntranceExamSchedule(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        /// Select all record from EntranceExamSchedule table with search parameters.        
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleBySearch(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> EntranceExamScheduleCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                if (_entranceExamScheduleAndScheduleDetailDataProvider != null)
                    EntranceExamScheduleCollection = _entranceExamScheduleAndScheduleDetailDataProvider.GetEntranceExamScheduleBySearch(searchRequest);
                else
                {
                    EntranceExamScheduleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamScheduleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamScheduleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamScheduleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamScheduleCollection;
        }
       
        /// Select a record from EntranceExamSchedule table by ID        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> SelectEntranceExamScheduleByID(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> entityResponse = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                entityResponse = _entranceExamScheduleAndScheduleDetailDataProvider.GetEntranceExamScheduleByID(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        // Select all record from EntranceExamSchedule table to search list.        
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleSearchList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> EntranceExamScheduleCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                if (_entranceExamScheduleAndScheduleDetailDataProvider != null)
                    EntranceExamScheduleCollection = _entranceExamScheduleAndScheduleDetailDataProvider.GetEntranceExamScheduleBySearch(searchRequest);
                else
                {
                    EntranceExamScheduleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamScheduleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamScheduleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamScheduleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamScheduleCollection;
        }





        //EntranceExamScheduleDetail Method
        // Create new record of EntranceExamScheduleDetail.        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> InsertEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> entityResponse = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamScheduleAndScheduleDetailBR.InsertEntranceExamScheduleDetailValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamScheduleAndScheduleDetailDataProvider.InsertEntranceExamScheduleDetail(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        /// Update a specific record  of EntranceExamScheduleDetail.        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> UpdateEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> entityResponse = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamScheduleAndScheduleDetailBR.UpdateEntranceExamScheduleDetailValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamScheduleAndScheduleDetailDataProvider.UpdateEntranceExamScheduleDetail(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        /// Delete a selected record from EntranceExamScheduleDetail.
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> DeleteEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> entityResponse = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamScheduleAndScheduleDetailBR.DeleteEntranceExamScheduleDetailValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamScheduleAndScheduleDetailDataProvider.DeleteEntranceExamScheduleDetail(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        /// Select all record from EntranceExamScheduleDetail table with search parameters.
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailBySearch(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> EntranceExamScheduleDetailCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                if (_entranceExamScheduleAndScheduleDetailDataProvider != null)
                    EntranceExamScheduleDetailCollection = _entranceExamScheduleAndScheduleDetailDataProvider.GetEntranceExamScheduleDetailBySearch(searchRequest);
                else
                {
                    EntranceExamScheduleDetailCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamScheduleDetailCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamScheduleDetailCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamScheduleDetailCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamScheduleDetailCollection;
        }

        /// Select a record from EntranceExamScheduleDetail table by ID        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> SelectEntranceExamScheduleDetailByID(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> entityResponse = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                entityResponse = _entranceExamScheduleAndScheduleDetailDataProvider.GetEntranceExamScheduleDetailByID(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        //// Select all record from EntranceExamScheduleDetail table to search list.                
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailSearchList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> EntranceExamScheduleDetailCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                if (_entranceExamScheduleAndScheduleDetailDataProvider != null)
                    EntranceExamScheduleDetailCollection = _entranceExamScheduleAndScheduleDetailDataProvider.GetEntranceExamScheduleDetailBySearch(searchRequest);
                else
                {
                    EntranceExamScheduleDetailCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamScheduleDetailCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamScheduleDetailCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamScheduleDetailCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamScheduleDetailCollection;
        }
        
        //// Select Question Paper list.       
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetOnlineExamQuestionPaperSet(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> QuestionPaperCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                if (_entranceExamScheduleAndScheduleDetailDataProvider != null)
                    QuestionPaperCollection = _entranceExamScheduleAndScheduleDetailDataProvider.GetOnlineExamQuestionPaperSet(searchRequest);
                else
                {
                    QuestionPaperCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    QuestionPaperCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                QuestionPaperCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                QuestionPaperCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return QuestionPaperCollection;
        }


        //// Select Unalloted studenth list.       
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetAllotedStuentForScheduleAvailCentreList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> UnAllotedStudentCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                if (_entranceExamScheduleAndScheduleDetailDataProvider != null)
                    UnAllotedStudentCollection = _entranceExamScheduleAndScheduleDetailDataProvider.GetAllotedStuentForScheduleAvailCentreList(searchRequest);
                else
                {
                    UnAllotedStudentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UnAllotedStudentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UnAllotedStudentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UnAllotedStudentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UnAllotedStudentCollection;
        }














        //Get Alloted Student List For Centre.               
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetAllotedStudentListForCentre(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> AllotedStudentCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
            try
            {
                if (_entranceExamScheduleAndScheduleDetailDataProvider != null)
                    AllotedStudentCollection = _entranceExamScheduleAndScheduleDetailDataProvider.GetAllotedStudentListForCentre(searchRequest);
                else
                {
                    AllotedStudentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AllotedStudentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AllotedStudentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AllotedStudentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AllotedStudentCollection;
        }

    }
}
