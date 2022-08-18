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
    public class EntranceExamInfrastructureDetailBA : IEntranceExamInfrastructureDetailBA
    {
        IEntranceExamInfrastructureDetailDataProvider _entranceExamInfrastructureDetailDataProvider;
        IEntranceExamInfrastructureDetailBR _entranceExamInfrastructureDetailBR;
        private ILogger _logException;
        public EntranceExamInfrastructureDetailBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _entranceExamInfrastructureDetailBR = new EntranceExamInfrastructureDetailBR();
            _entranceExamInfrastructureDetailDataProvider = new EntranceExamInfrastructureDetailDataProvider();
        }




        // EntranceExamAvailableCentres Method
        #region EntranceExamAvailableCentres

        /// Create new record of EntranceExamAvailableCentres.        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> entityResponse = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamInfrastructureDetailBR.InsertEntranceExamAvailableCentresValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamInfrastructureDetailDataProvider.InsertEntranceExamAvailableCentres(item);
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

        /// Update a specific record  of EntranceExamAvailableCentres.       
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> entityResponse = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamInfrastructureDetailBR.UpdateEntranceExamAvailableCentresValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamInfrastructureDetailDataProvider.UpdateEntranceExamAvailableCentres(item);
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

        /// Delete a selected record from EntranceExamAvailableCentres.        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> entityResponse = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamInfrastructureDetailBR.DeleteEntranceExamAvailableCentresValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamInfrastructureDetailDataProvider.DeleteEntranceExamAvailableCentres(item);
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

        /// Select all record from EntranceExamAvailableCentres table with search parameters.        
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> EntranceExamAvailableCentresCollection = new BaseEntityCollectionResponse<EntranceExamInfrastructureDetail>();
            try
            {
                if (_entranceExamInfrastructureDetailDataProvider != null)
                    EntranceExamAvailableCentresCollection = _entranceExamInfrastructureDetailDataProvider.GetEntranceExamAvailableCentresBySearch(searchRequest);
                else
                {
                    EntranceExamAvailableCentresCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamAvailableCentresCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamAvailableCentresCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamAvailableCentresCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamAvailableCentresCollection;
        }

        /// Select a record from EntranceExamAvailableCentres table by EntranceExamAvailableCentresID        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> SelectEntranceExamAvailableCentresByID(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> entityResponse = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
            try
            {
                entityResponse = _entranceExamInfrastructureDetailDataProvider.GetEntranceExamAvailableCentresByID(item);
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

        // Select all record from EntranceExamAvailableCentres table to search list.
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> EntranceExamAvailableCentresCollection = new BaseEntityCollectionResponse<EntranceExamInfrastructureDetail>();
            try
            {
                if (_entranceExamInfrastructureDetailDataProvider != null)
                    EntranceExamAvailableCentresCollection = _entranceExamInfrastructureDetailDataProvider.GetEntranceExamInfrastructureDetailBySearch(searchRequest);
                else
                {
                    EntranceExamAvailableCentresCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamAvailableCentresCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamAvailableCentresCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamAvailableCentresCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamAvailableCentresCollection;
        }

        #endregion


        // EntranceExamInfrastructureDetail Method
        #region EntranceExamInfrastructureDetail

        /// Create new record of EntranceExamInfrastructureDetail.        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> entityResponse = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamInfrastructureDetailBR.InsertEntranceExamInfrastructureDetailValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamInfrastructureDetailDataProvider.InsertEntranceExamInfrastructureDetail(item);
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
        
        /// Update a specific record  of EntranceExamInfrastructureDetail.       
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> entityResponse = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamInfrastructureDetailBR.UpdateEntranceExamInfrastructureDetailValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamInfrastructureDetailDataProvider.UpdateEntranceExamInfrastructureDetail(item);
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
        
        /// Delete a selected record from EntranceExamInfrastructureDetail.        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> entityResponse = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamInfrastructureDetailBR.DeleteEntranceExamInfrastructureDetailValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamInfrastructureDetailDataProvider.DeleteEntranceExamInfrastructureDetail(item);
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
        
        /// Select all record from EntranceExamInfrastructureDetail table with search parameters.        
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> EntranceExamInfrastructureDetailCollection = new BaseEntityCollectionResponse<EntranceExamInfrastructureDetail>();
            try
            {
                if (_entranceExamInfrastructureDetailDataProvider != null)
                    EntranceExamInfrastructureDetailCollection = _entranceExamInfrastructureDetailDataProvider.GetEntranceExamInfrastructureDetailBySearch(searchRequest);
                else
                {
                    EntranceExamInfrastructureDetailCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamInfrastructureDetailCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamInfrastructureDetailCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamInfrastructureDetailCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamInfrastructureDetailCollection;
        }
       
        /// Select a record from EntranceExamInfrastructureDetail table by ID        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> SelectEntranceExamInfrastructureDetailByID(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> entityResponse = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
            try
            {
                entityResponse = _entranceExamInfrastructureDetailDataProvider.GetEntranceExamInfrastructureDetailByID(item);
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


        // Select all record from EntranceExamInfrastructureDetail table to search list.
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> EntranceExamInfrastructureDetailCollection = new BaseEntityCollectionResponse<EntranceExamInfrastructureDetail>();
            try
            {
                if (_entranceExamInfrastructureDetailDataProvider != null)
                    EntranceExamInfrastructureDetailCollection = _entranceExamInfrastructureDetailDataProvider.GetEntranceExamInfrastructureDetailBySearch(searchRequest);
                else
                {
                    EntranceExamInfrastructureDetailCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamInfrastructureDetailCollection.CollectionResponse = null;
                }
            }
            catch(Exception ex)
            {
                EntranceExamInfrastructureDetailCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamInfrastructureDetailCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamInfrastructureDetailCollection;
        }

        #endregion
    }
}
