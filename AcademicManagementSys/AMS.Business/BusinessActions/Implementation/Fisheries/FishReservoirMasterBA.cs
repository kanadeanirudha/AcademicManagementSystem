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
    public class FishReservoirMasterBA : IFishReservoirMasterBA
    {
        IFishReservoirMasterDataProvider _fishReservoirMasterDataProvider;
        IFishReservoirMasterBR _fishReservoirMasterBR;
        private ILogger _logException;
        public FishReservoirMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _fishReservoirMasterBR = new FishReservoirMasterBR();
            _fishReservoirMasterDataProvider = new FishReservoirMasterDataProvider();
        }
        /// <summary>
        /// Create new record of FishReservoirMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishReservoirMaster> InsertFishReservoirMaster(FishReservoirMaster item)
        {
            IBaseEntityResponse<FishReservoirMaster> entityResponse = new BaseEntityResponse<FishReservoirMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishReservoirMasterBR.InsertFishReservoirMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishReservoirMasterDataProvider.InsertFishReservoirMaster(item);
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
        /// Update a specific record  of FishReservoirMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishReservoirMaster> UpdateFishReservoirMaster(FishReservoirMaster item)
        {
            IBaseEntityResponse<FishReservoirMaster> entityResponse = new BaseEntityResponse<FishReservoirMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishReservoirMasterBR.UpdateFishReservoirMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishReservoirMasterDataProvider.UpdateFishReservoirMaster(item);
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
        /// Delete a selected record from FishReservoirMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishReservoirMaster> DeleteFishReservoirMaster(FishReservoirMaster item)
        {
            IBaseEntityResponse<FishReservoirMaster> entityResponse = new BaseEntityResponse<FishReservoirMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishReservoirMasterBR.DeleteFishReservoirMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishReservoirMasterDataProvider.DeleteFishReservoirMaster(item);
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
        /// Select all record from FishReservoirMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishReservoirMaster> GetBySearch(FishReservoirMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FishReservoirMaster> FishReservoirMasterCollection = new BaseEntityCollectionResponse<FishReservoirMaster>();
            try
            {
                if (_fishReservoirMasterDataProvider != null)
                    FishReservoirMasterCollection = _fishReservoirMasterDataProvider.GetFishReservoirMasterBySearch(searchRequest);
                else
                {
                    FishReservoirMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FishReservoirMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FishReservoirMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FishReservoirMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FishReservoirMasterCollection;
        }
        /// <summary>
        /// Select a record from FishReservoirMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishReservoirMaster> SelectByID(FishReservoirMaster item)
        {
            IBaseEntityResponse<FishReservoirMaster> entityResponse = new BaseEntityResponse<FishReservoirMaster>();
            try
            {
                entityResponse = _fishReservoirMasterDataProvider.GetFishReservoirMasterByID(item);
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
