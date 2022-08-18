using AMS.Base.DTO;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
namespace AMS.Business.BusinessAction
{
    public class StudyCentreMasterBA : IStudyCentreMasterBA
    {
        IStudyCentreMasterDataProvider _StudyCentreMasterDataProvider;
        private ILogger _logException;
        public StudyCentreMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _StudyCentreMasterDataProvider = new StudyCentreMasterDataProvider();
        }
        /// <summary>
        /// Create new record of StudyCentreMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <summary>
        /// Select all record from StudyCentreMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudyCentreMaster> GetStudyCentreMaster(StudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudyCentreMaster> StudyCentreMasterCollection = new BaseEntityCollectionResponse<StudyCentreMaster>();
            try
            {
                if (_StudyCentreMasterDataProvider != null)
                    StudyCentreMasterCollection = _StudyCentreMasterDataProvider.GetStudyCentreMaster(searchRequest);
                else
                {
                    StudyCentreMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudyCentreMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudyCentreMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudyCentreMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudyCentreMasterCollection;
        }
    }
}
