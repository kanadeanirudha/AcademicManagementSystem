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
    public class FishLicenseTypeBA : IFishLicenseTypeBA
    {
        IFishLicenseTypeDataProvider _fishLicenseTypeDataProvider;
        IFishLicenseTypeBR _fishLicenseTypeBR;
        private ILogger _logException;
        public FishLicenseTypeBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _fishLicenseTypeBR = new FishLicenseTypeBR();
            _fishLicenseTypeDataProvider = new FishLicenseTypeDataProvider();
        }
        /// <summary>
        /// Create new record of FishLicenseType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseType> InsertFishLicenseType(FishLicenseType item)
        {
            IBaseEntityResponse<FishLicenseType> entityResponse = new BaseEntityResponse<FishLicenseType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishLicenseTypeBR.InsertFishLicenseTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishLicenseTypeDataProvider.InsertFishLicenseType(item);
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
        /// Update a specific record  of FishLicenseType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseType> UpdateFishLicenseType(FishLicenseType item)
        {
            IBaseEntityResponse<FishLicenseType> entityResponse = new BaseEntityResponse<FishLicenseType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishLicenseTypeBR.UpdateFishLicenseTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishLicenseTypeDataProvider.UpdateFishLicenseType(item);
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
        /// Delete a selected record from FishLicenseType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseType> DeleteFishLicenseType(FishLicenseType item)
        {
            IBaseEntityResponse<FishLicenseType> entityResponse = new BaseEntityResponse<FishLicenseType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _fishLicenseTypeBR.DeleteFishLicenseTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _fishLicenseTypeDataProvider.DeleteFishLicenseType(item);
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
        /// Select all record from FishLicenseType table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishLicenseType> GetBySearch(FishLicenseTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FishLicenseType> FishLicenseTypeCollection = new BaseEntityCollectionResponse<FishLicenseType>();
            try
            {
                if (_fishLicenseTypeDataProvider != null)
                    FishLicenseTypeCollection = _fishLicenseTypeDataProvider.GetFishLicenseTypeBySearch(searchRequest);
                else
                {
                    FishLicenseTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FishLicenseTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FishLicenseTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FishLicenseTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FishLicenseTypeCollection;
        }
        /// <summary>
        /// Select a record from FishLicenseType table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseType> SelectByID(FishLicenseType item)
        {
            IBaseEntityResponse<FishLicenseType> entityResponse = new BaseEntityResponse<FishLicenseType>();
            try
            {
                entityResponse = _fishLicenseTypeDataProvider.GetFishLicenseTypeByID(item);
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


        public IBaseEntityCollectionResponse<FishLicenseType> GetBySearchList(FishLicenseTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FishLicenseType> fishLicenseTypeCollection = new BaseEntityCollectionResponse<FishLicenseType>();
            try
            {
                if (_fishLicenseTypeDataProvider != null)
                {
                    fishLicenseTypeCollection = _fishLicenseTypeDataProvider.GetFishLicenseTypeBySearchList(searchRequest);
                }
                else
                {
                    fishLicenseTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    fishLicenseTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                fishLicenseTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                fishLicenseTypeCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return fishLicenseTypeCollection;
        }

    }
}
