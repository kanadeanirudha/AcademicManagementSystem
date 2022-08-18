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
    public class FishItemLicenseRateBA : IFishItemLicenseRateBA
    {
        IFishItemLicenseRateDataProvider _fishItemLicenseRateDataProvider;
        IFishItemLicenseRateBR _fishItemLicenseRateBR;
        private ILogger _logException;
        public FishItemLicenseRateBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _fishItemLicenseRateBR = new FishItemLicenseRateBR();
            _fishItemLicenseRateDataProvider = new FishItemLicenseRateDataProvider();
        }
        /// <summary>
        /// Create new record of FishItemLicenseRate.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishItemLicenseRate> InsertFishItemLicenseRate(FishItemLicenseRate item)
        {
            IBaseEntityResponse<FishItemLicenseRate> entityResponse = new BaseEntityResponse<FishItemLicenseRate>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishItemLicenseRateBR.InsertFishItemLicenseRateValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishItemLicenseRateDataProvider.InsertFishItemLicenseRate(item);
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
        /// Update a specific record  of FishItemLicenseRate.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishItemLicenseRate> UpdateFishItemLicenseRate(FishItemLicenseRate item)
        {
            IBaseEntityResponse<FishItemLicenseRate> entityResponse = new BaseEntityResponse<FishItemLicenseRate>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishItemLicenseRateBR.UpdateFishItemLicenseRateValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishItemLicenseRateDataProvider.UpdateFishItemLicenseRate(item);
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
        /// Delete a selected record from FishItemLicenseRate.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishItemLicenseRate> DeleteFishItemLicenseRate(FishItemLicenseRate item)
        {
            IBaseEntityResponse<FishItemLicenseRate> entityResponse = new BaseEntityResponse<FishItemLicenseRate>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishItemLicenseRateBR.DeleteFishItemLicenseRateValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishItemLicenseRateDataProvider.DeleteFishItemLicenseRate(item);
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
        /// Select all record from FishItemLicenseRate table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishItemLicenseRate> GetBySearch(FishItemLicenseRateSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FishItemLicenseRate> FishItemLicenseRateCollection = new BaseEntityCollectionResponse<FishItemLicenseRate>();
            try
            {
                if (_fishItemLicenseRateDataProvider != null)
                    FishItemLicenseRateCollection = _fishItemLicenseRateDataProvider.GetFishItemLicenseRateBySearch(searchRequest);
                else
                {
                    FishItemLicenseRateCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FishItemLicenseRateCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FishItemLicenseRateCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FishItemLicenseRateCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FishItemLicenseRateCollection;
        }
        /// <summary>
        /// Select a record from FishItemLicenseRate table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishItemLicenseRate> SelectByID(FishItemLicenseRate item)
        {
            IBaseEntityResponse<FishItemLicenseRate> entityResponse = new BaseEntityResponse<FishItemLicenseRate>();
            try
            {
                entityResponse = _fishItemLicenseRateDataProvider.GetFishItemLicenseRateByID(item);
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
        /// Select all record from FishItemLicenseRate table with search iten name.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishItemLicenseRate> GetItemNameCentrewiseSearchList(FishItemLicenseRateSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FishItemLicenseRate> FishItemLicenseRateCollection = new BaseEntityCollectionResponse<FishItemLicenseRate>();
            try
            {
                if (_fishItemLicenseRateDataProvider != null)
                    FishItemLicenseRateCollection = _fishItemLicenseRateDataProvider.GetItemNameCentrewiseSearchList(searchRequest);
                else
                {
                    FishItemLicenseRateCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FishItemLicenseRateCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FishItemLicenseRateCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FishItemLicenseRateCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FishItemLicenseRateCollection;
        }
    }
}
