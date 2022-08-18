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
    public class GeneralCounterPOSApllicableBA : IGeneralCounterPOSApllicableBA
    {
        IGeneralCounterPOSApllicableDataProvider _generalCounterPOSApllicableDataProvider;
        private ILogger _logException;
        public GeneralCounterPOSApllicableBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalCounterPOSApllicableDataProvider = new GeneralCounterPOSApllicableDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralCounterPOSApllicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <summary>
        /// Select all record from GeneralCounterPOSApllicable table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCounterPOSApllicable> GetGeneralCounterPOSApllicable(GeneralCounterPOSApllicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCounterPOSApllicable> GeneralCounterPOSApllicableCollection = new BaseEntityCollectionResponse<GeneralCounterPOSApllicable>();
            try
            {
                if (_generalCounterPOSApllicableDataProvider != null)
                    GeneralCounterPOSApllicableCollection = _generalCounterPOSApllicableDataProvider.GetGeneralCounterPOSApllicable(searchRequest);
                else
                {
                    GeneralCounterPOSApllicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralCounterPOSApllicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralCounterPOSApllicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralCounterPOSApllicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralCounterPOSApllicableCollection;
        }

        public IBaseEntityResponse<GeneralCounterPOSApllicable> PostPOSSelfAssignData(GeneralCounterPOSApllicable item)
        {
            IBaseEntityResponse<GeneralCounterPOSApllicable> entityResponse = new BaseEntityResponse<GeneralCounterPOSApllicable>();
            try
            {

                if (_generalCounterPOSApllicableDataProvider != null)
                {
                    entityResponse = _generalCounterPOSApllicableDataProvider.PostPOSSelfAssignData(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        public IBaseEntityResponse<GeneralCounterPOSApllicable> CheckPOSSelfAssignDataCount(GeneralCounterPOSApllicable item)
        {
            IBaseEntityResponse<GeneralCounterPOSApllicable> entityResponse = new BaseEntityResponse<GeneralCounterPOSApllicable>();
            try
            {

                if (_generalCounterPOSApllicableDataProvider != null)
                {
                    entityResponse = _generalCounterPOSApllicableDataProvider.CheckPOSSelfAssignDataCount(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
    }
}
