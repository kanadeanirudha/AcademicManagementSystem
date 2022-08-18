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
    public class AccountGroupMasterReportBA: IAccountGroupMasterReportBA
    {
        IAccountGroupMasterReportDataProvider _accountGroupMasterDataProvider;
        private ILogger _logException;

        public AccountGroupMasterReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountGroupMasterDataProvider = new AccountGroupMasterReportDataProvider();
        }

        /// <summary>
        /// Select all record from Account Group Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGroupMasterReport> GetBySearch(AccountGroupMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGroupMasterReport> AccountGroupMasterCollection = new BaseEntityCollectionResponse<AccountGroupMasterReport>();
            try
            {
                if (_accountGroupMasterDataProvider != null)
                {
                    AccountGroupMasterCollection = _accountGroupMasterDataProvider.GetAccountGroupMasterBySearch(searchRequest);
                }
                else
                {
                    AccountGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountGroupMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountGroupMasterCollection;
        }

                /// <summary>
        /// Select all record from Account Group Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGroupMasterReport> GetGroupList(AccountGroupMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGroupMasterReport> AccountGroupMasterCollection = new BaseEntityCollectionResponse<AccountGroupMasterReport>();
            try
            {
                if (_accountGroupMasterDataProvider != null)
                {
                    AccountGroupMasterCollection = _accountGroupMasterDataProvider.GetGroupList(searchRequest);
                }
                else
                {
                    AccountGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountGroupMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountGroupMasterCollection;
        }
    }
}
