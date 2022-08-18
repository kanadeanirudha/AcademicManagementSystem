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
    public class FishItemLicenseAllocationBA : IFishItemLicenseAllocationBA
    {
        IFishItemLicenseAllocationDataProvider _fishItemLicenseAllocationDataProvider;
        IFishItemLicenseAllocationBR _fishItemLicenseAllocationBR;
        private ILogger _logException;
        public FishItemLicenseAllocationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _fishItemLicenseAllocationBR = new FishItemLicenseAllocationBR();
            _fishItemLicenseAllocationDataProvider = new FishItemLicenseAllocationDataProvider();
        }
        /// <summary>
        /// Create new record of FishItemLicenseAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishItemLicenseAllocation> InsertFishItemLicenseAllocation(FishItemLicenseAllocation item)
        {
            IBaseEntityResponse<FishItemLicenseAllocation> entityResponse = new BaseEntityResponse<FishItemLicenseAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishItemLicenseAllocationBR.InsertFishItemLicenseAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishItemLicenseAllocationDataProvider.InsertFishItemLicenseAllocation(item);
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
        /// Update a specific record  of FishItemLicenseAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishItemLicenseAllocation> UpdateFishItemLicenseAllocation(FishItemLicenseAllocation item)
        {
            IBaseEntityResponse<FishItemLicenseAllocation> entityResponse = new BaseEntityResponse<FishItemLicenseAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishItemLicenseAllocationBR.UpdateFishItemLicenseAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishItemLicenseAllocationDataProvider.UpdateFishItemLicenseAllocation(item);
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
        /// Delete a selected record from FishItemLicenseAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishItemLicenseAllocation> DeleteFishItemLicenseAllocation(FishItemLicenseAllocation item)
        {
            IBaseEntityResponse<FishItemLicenseAllocation> entityResponse = new BaseEntityResponse<FishItemLicenseAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishItemLicenseAllocationBR.DeleteFishItemLicenseAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishItemLicenseAllocationDataProvider.DeleteFishItemLicenseAllocation(item);
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
        /// Select all record from FishItemLicenseAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishItemLicenseAllocation> GetBySearch(FishItemLicenseAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FishItemLicenseAllocation> FishItemLicenseAllocationCollection = new BaseEntityCollectionResponse<FishItemLicenseAllocation>();
            try
            {
                if (_fishItemLicenseAllocationDataProvider != null)
                    FishItemLicenseAllocationCollection = _fishItemLicenseAllocationDataProvider.GetFishItemLicenseAllocationBySearch(searchRequest);
                else
                {
                    FishItemLicenseAllocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FishItemLicenseAllocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FishItemLicenseAllocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FishItemLicenseAllocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FishItemLicenseAllocationCollection;
        }
        /// <summary>
        /// Select a record from FishItemLicenseAllocation table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishItemLicenseAllocation> SelectByID(FishItemLicenseAllocation item)
        {
            IBaseEntityResponse<FishItemLicenseAllocation> entityResponse = new BaseEntityResponse<FishItemLicenseAllocation>();
            try
            {
                entityResponse = _fishItemLicenseAllocationDataProvider.GetFishItemLicenseAllocationByID(item);
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
