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
    public class FishFishermenMasterBA : IFishFishermenMasterBA
    {
        IFishFishermenMasterDataProvider _fishFishermenMasterDataProvider;
        IFishFishermenMasterBR _fishFishermenMasterBR;
        private ILogger _logException;
        public FishFishermenMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _fishFishermenMasterBR = new FishFishermenMasterBR();
            _fishFishermenMasterDataProvider = new FishFishermenMasterDataProvider();
        }
        /// <summary>
        /// Create new record of FishFishermenMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishFishermenMaster> InsertFishFishermenMaster(FishFishermenMaster item)
        {
            IBaseEntityResponse<FishFishermenMaster> entityResponse = new BaseEntityResponse<FishFishermenMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishFishermenMasterBR.InsertFishFishermenMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishFishermenMasterDataProvider.InsertFishFishermenMaster(item);
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
        /// <summary>
        /// Update a specific record  of FishFishermenMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishFishermenMaster> UpdateFishFishermenMaster(FishFishermenMaster item)
        {
            IBaseEntityResponse<FishFishermenMaster> entityResponse = new BaseEntityResponse<FishFishermenMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishFishermenMasterBR.UpdateFishFishermenMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishFishermenMasterDataProvider.UpdateFishFishermenMaster(item);
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
        /// <summary>
        /// Delete a selected record from FishFishermenMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishFishermenMaster> DeleteFishFishermenMaster(FishFishermenMaster item)
        {
            IBaseEntityResponse<FishFishermenMaster> entityResponse = new BaseEntityResponse<FishFishermenMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishFishermenMasterBR.DeleteFishFishermenMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishFishermenMasterDataProvider.DeleteFishFishermenMaster(item);
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
        /// <summary>
        /// Select all record from FishFishermenMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishFishermenMaster> GetBySearch(FishFishermenMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FishFishermenMaster> FishFishermenMasterCollection = new BaseEntityCollectionResponse<FishFishermenMaster>();
            try
            {
                if (_fishFishermenMasterDataProvider != null)
                    FishFishermenMasterCollection = _fishFishermenMasterDataProvider.GetFishFishermenMasterBySearch(searchRequest);
                else
                {
                    FishFishermenMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FishFishermenMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FishFishermenMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FishFishermenMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FishFishermenMasterCollection;
        }
        /// <summary>
        /// Select a record from FishFishermenMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishFishermenMaster> SelectByID(FishFishermenMaster item)
        {
            IBaseEntityResponse<FishFishermenMaster> entityResponse = new BaseEntityResponse<FishFishermenMaster>();
            try
            {
                entityResponse = _fishFishermenMasterDataProvider.GetFishFishermenMasterByID(item);
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
    }
}
