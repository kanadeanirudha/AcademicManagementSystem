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

namespace AMS.Business.BusinessActions
{
    public class FeeAccountTypeMasterBA : IFeeAccountTypeMasterBA
    {
        IFeeAccountTypeMasterDataProvider _FeeAccountTypeMasterDataProvider;
        IFeeAccountTypeMasterBR _FeeAccountTypeMasterBR;

        private ILogger _logException;
        public FeeAccountTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _FeeAccountTypeMasterBR = new FeeAccountTypeMasterBR();
            _FeeAccountTypeMasterDataProvider = new FeeAccountTypeMasterDataProvider();
        }

        /// Create new record of FeeAccountTypeMaster.
        public IBaseEntityResponse<FeeAccountTypeMaster> InsertFeeAccountTypeMaster(FeeAccountTypeMaster item)
        {
            IBaseEntityResponse<FeeAccountTypeMaster> entityResponse = new BaseEntityResponse<FeeAccountTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeAccountTypeMasterBR.InsertFeeAccountTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeAccountTypeMasterDataProvider.InsertFeeAccountTypeMaster(item);
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

        /// Update a specific record  of FeeAccountTypeMaster.
        public IBaseEntityResponse<FeeAccountTypeMaster> UpdateFeeAccountTypeMaster(FeeAccountTypeMaster item)
        {
            IBaseEntityResponse<FeeAccountTypeMaster> entityResponse = new BaseEntityResponse<FeeAccountTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeAccountTypeMasterBR.UpdateFeeAccountTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeAccountTypeMasterDataProvider.UpdateFeeAccountTypeMaster(item);
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

        /// Delete a selected record from FeeAccountTypeMaster.
        public IBaseEntityResponse<FeeAccountTypeMaster> DeleteFeeAccountTypeMaster(FeeAccountTypeMaster item)
        {
            IBaseEntityResponse<FeeAccountTypeMaster> entityResponse = new BaseEntityResponse<FeeAccountTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeAccountTypeMasterBR.DeleteFeeAccountTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeAccountTypeMasterDataProvider.DeleteFeeAccountTypeMaster(item);
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

        /// Select all record from FeeAccountTypeMaster table with search parameters.
        public IBaseEntityCollectionResponse<FeeAccountTypeMaster> GetBySearch(FeeAccountTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeAccountTypeMaster> FeeAccountTypeMasterCollection = new BaseEntityCollectionResponse<FeeAccountTypeMaster>();
            try
            {
                if (_FeeAccountTypeMasterDataProvider != null)
                    FeeAccountTypeMasterCollection = _FeeAccountTypeMasterDataProvider.GetFeeAccountTypeMasterBySearch(searchRequest);
                else
                {
                    FeeAccountTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeAccountTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeAccountTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeAccountTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeAccountTypeMasterCollection;
        }

        /// Select a record from FeeAccountTypeMaster table by ID.
        public IBaseEntityResponse<FeeAccountTypeMaster> SelectByID(FeeAccountTypeMaster item)
        {
            IBaseEntityResponse<FeeAccountTypeMaster> entityResponse = new BaseEntityResponse<FeeAccountTypeMaster>();
            try
            {
                entityResponse = _FeeAccountTypeMasterDataProvider.GetFeeAccountTypeMasterByID(item);
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

        public IBaseEntityCollectionResponse<FeeAccountTypeMaster> GetFeeAccountTypeMasterSearchList(FeeAccountTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeAccountTypeMaster> FeeAccountTypeMasterCollection = new BaseEntityCollectionResponse<FeeAccountTypeMaster>();
            try
            {
                if (_FeeAccountTypeMasterDataProvider != null)
                    FeeAccountTypeMasterCollection = _FeeAccountTypeMasterDataProvider.GetFeeAccountTypeMasterSearchList(searchRequest);
                else
                {
                    FeeAccountTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeAccountTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeAccountTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeAccountTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeAccountTypeMasterCollection;
        }
    }
}
