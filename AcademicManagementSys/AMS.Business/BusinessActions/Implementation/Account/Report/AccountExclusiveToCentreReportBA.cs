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
    public class AccountExclusiveToCentreReportBA : IAccountExclusiveToCentreReportBA
    {
        IAccountExclusiveToCentreReportDataProvider _accountExclusiveToCentreReportDataProvider;
        //     IAccountExclusiveToCentreReportBR _accountExclusiveToCentreReportBR;
        private ILogger _logException;
        public AccountExclusiveToCentreReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //   _accountExclusiveToCentreReportBR = new AccountExclusiveToCentreReportBR();
            _accountExclusiveToCentreReportDataProvider = new AccountExclusiveToCentreReportDataProvider();
        }

        /// <summary>
        /// Select all record from AccountExclusiveToCentreReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountExclusiveToCentreReport> GetBySearch(AccountExclusiveToCentreReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountExclusiveToCentreReport> AccountExclusiveToCentreReportCollection = new BaseEntityCollectionResponse<AccountExclusiveToCentreReport>();
            try
            {
                if (_accountExclusiveToCentreReportDataProvider != null)
                    AccountExclusiveToCentreReportCollection = _accountExclusiveToCentreReportDataProvider.GetBySearch(searchRequest);
                else
                {
                    AccountExclusiveToCentreReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountExclusiveToCentreReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountExclusiveToCentreReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountExclusiveToCentreReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountExclusiveToCentreReportCollection;
        }
        /// <summary>
        /// Select a record from AccountExclusiveToCentreReport table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountExclusiveToCentreReport> SelectByID(AccountExclusiveToCentreReport item)
        {
            IBaseEntityResponse<AccountExclusiveToCentreReport> entityResponse = new BaseEntityResponse<AccountExclusiveToCentreReport>();
            try
            {
                entityResponse = _accountExclusiveToCentreReportDataProvider.SelectByID(item);
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
