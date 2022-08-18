using AMS.Base.DTO;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
namespace AMS.Business.BusinessAction
{
    public class GeneralTimeZoneMasterBA : IGeneralTimeZoneMasterBA
    {
        IGeneralTimeZoneMasterDataProvider _GeneralTimeZoneMasterDataProvider;
        private ILogger _logException;
        public GeneralTimeZoneMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralTimeZoneMasterDataProvider = new GeneralTimeZoneMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralTimeZoneMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <summary>
        /// Select all record from GeneralTimeZoneMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTimeZoneMaster> GetGeneralTimeZoneMaster(GeneralTimeZoneMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTimeZoneMaster> GeneralTimeZoneMasterCollection = new BaseEntityCollectionResponse<GeneralTimeZoneMaster>();
            try
            {
                if (_GeneralTimeZoneMasterDataProvider != null)
                    GeneralTimeZoneMasterCollection = _GeneralTimeZoneMasterDataProvider.GetGeneralTimeZoneMaster(searchRequest);
                else
                {
                    GeneralTimeZoneMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTimeZoneMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTimeZoneMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTimeZoneMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTimeZoneMasterCollection;
        }
    }
}
