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

namespace AMS.Business.BusinessActions
{
    public class AccountBalancesheetReportBA : IAccountBalancesheetReportBA
    {
        IAccountBalancesheetReportDataProvider _accountBalancesheetReportDataProvider;
        private ILogger _logException;
        public AccountBalancesheetReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountBalancesheetReportDataProvider = new AccountBalancesheetReportDataProvider();
        }

        /// <summary>
        /// Select all record from AccountBalancesheetReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetReport> GetBySearch(AccountBalancesheetReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountBalancesheetReport> AccountBalancesheetReportCollection = new BaseEntityCollectionResponse<AccountBalancesheetReport>();
            try
            {
                if (_accountBalancesheetReportDataProvider != null)
                    AccountBalancesheetReportCollection = _accountBalancesheetReportDataProvider.GetAccountBalancesheetReportBySearch(searchRequest);
                else
                {
                    AccountBalancesheetReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountBalancesheetReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountBalancesheetReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountBalancesheetReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountBalancesheetReportCollection;
        }
    }
}
