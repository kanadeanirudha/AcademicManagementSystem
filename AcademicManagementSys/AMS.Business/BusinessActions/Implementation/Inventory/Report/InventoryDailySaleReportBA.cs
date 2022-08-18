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
    public class InventoryDailySaleReportBA: IInventoryDailySaleReportBA
    {
        IInventoryDailySaleReportDataProvider _InventoryDailySaleReportDataProvider;
        private ILogger _logException;

        public InventoryDailySaleReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryDailySaleReportDataProvider = new InventoryDailySaleReportDataProvider();
        }

        /// <summary>
        /// Select all record from Account Head Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDailySaleReport> GetInventoryDailySaleReportBySearch(InventoryDailySaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDailySaleReport> AdminMenuApplicableCollection = new BaseEntityCollectionResponse<InventoryDailySaleReport>();
            try
            {
                if (_InventoryDailySaleReportDataProvider != null)
                {
                    AdminMenuApplicableCollection = _InventoryDailySaleReportDataProvider.GetInventoryDailySaleReportBySearch(searchRequest);
                }
                else
                {
                    AdminMenuApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminMenuApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminMenuApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminMenuApplicableCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminMenuApplicableCollection;
        }

   }
}
