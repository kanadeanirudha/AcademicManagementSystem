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
    public class FishLicenseRuleMasterBA : IFishLicenseRuleMasterBA
    {
        IFishLicenseRuleMasterDataProvider _fishLicenseRuleMasterDataProvider;
        IFishLicenseRuleMasterBR _fishLicenseRuleMasterBR;
        private ILogger _logException;
        public FishLicenseRuleMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _fishLicenseRuleMasterBR = new FishLicenseRuleMasterBR();
            _fishLicenseRuleMasterDataProvider = new FishLicenseRuleMasterDataProvider();
        }
        /// <summary>
        /// Create new record of FishLicenseRuleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseRuleMaster> InsertFishLicenseRuleMaster(FishLicenseRuleMaster item)
        {
            IBaseEntityResponse<FishLicenseRuleMaster> entityResponse = new BaseEntityResponse<FishLicenseRuleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishLicenseRuleMasterBR.InsertFishLicenseRuleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishLicenseRuleMasterDataProvider.InsertFishLicenseRuleMaster(item);
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
        /// Update a specific record  of FishLicenseRuleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseRuleMaster> UpdateFishLicenseRuleMaster(FishLicenseRuleMaster item)
        {
            IBaseEntityResponse<FishLicenseRuleMaster> entityResponse = new BaseEntityResponse<FishLicenseRuleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishLicenseRuleMasterBR.UpdateFishLicenseRuleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishLicenseRuleMasterDataProvider.UpdateFishLicenseRuleMaster(item);
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
        /// Delete a selected record from FishLicenseRuleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseRuleMaster> DeleteFishLicenseRuleMaster(FishLicenseRuleMaster item)
        {
            IBaseEntityResponse<FishLicenseRuleMaster> entityResponse = new BaseEntityResponse<FishLicenseRuleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishLicenseRuleMasterBR.DeleteFishLicenseRuleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishLicenseRuleMasterDataProvider.DeleteFishLicenseRuleMaster(item);
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
        /// Select all record from FishLicenseRuleMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishLicenseRuleMaster> GetBySearch(FishLicenseRuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FishLicenseRuleMaster> FishLicenseRuleMasterCollection = new BaseEntityCollectionResponse<FishLicenseRuleMaster>();
            try
            {
                if (_fishLicenseRuleMasterDataProvider != null)
                    FishLicenseRuleMasterCollection = _fishLicenseRuleMasterDataProvider.GetFishLicenseRuleMasterBySearch(searchRequest);
                else
                {
                    FishLicenseRuleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FishLicenseRuleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FishLicenseRuleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FishLicenseRuleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FishLicenseRuleMasterCollection;
        }
        /// <summary>
        /// Select a record from FishLicenseRuleMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseRuleMaster> SelectByID(FishLicenseRuleMaster item)
        {
            IBaseEntityResponse<FishLicenseRuleMaster> entityResponse = new BaseEntityResponse<FishLicenseRuleMaster>();
            try
            {
                entityResponse = _fishLicenseRuleMasterDataProvider.GetFishLicenseRuleMasterByID(item);
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
