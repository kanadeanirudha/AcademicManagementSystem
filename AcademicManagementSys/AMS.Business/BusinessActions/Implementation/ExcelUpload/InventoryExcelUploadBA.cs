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
    public class InventoryExcelUploadBA : IInventoryExcelUploadBA
    {
        IInventoryExcelUploadDataProvider _InventoryExcelUploadDataProvider;
        IInventoryExcelUploadBR _InventoryExcelUploadBR;

        private ILogger _logException;

        public InventoryExcelUploadBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryExcelUploadDataProvider = new InventoryExcelUploadDataProvider();
            _InventoryExcelUploadBR = new InventoryExcelUploadBR();
        }

        public IBaseEntityResponse<InventoryExcelUpload> GetDataValidationListsForInventoryExcel(InventoryExcelUpload inventoryExcelUpload)
        {
            IBaseEntityResponse<InventoryExcelUpload> entityResponse = new BaseEntityResponse<InventoryExcelUpload>();
            try
            {
                if (_InventoryExcelUploadDataProvider != null)
                    entityResponse = _InventoryExcelUploadDataProvider.GetDataValidationListsForInventoryExcel(inventoryExcelUpload);
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

        public IBaseEntityResponse<InventoryExcelUpload> InsertVendorMasterMapCategoryExcel(InventoryExcelUpload item)
        {
            IBaseEntityResponse<InventoryExcelUpload> entityResponse = new BaseEntityResponse<InventoryExcelUpload>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryExcelUploadBR.InsertVendorMasterMapCategoryExcelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryExcelUploadDataProvider.InsertVendorMasterMapCategoryExcel(item);
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

        public IBaseEntityResponse<InventoryExcelUpload> InsertItemMasterMapCategoryExcel(InventoryExcelUpload item)
        {
            IBaseEntityResponse<InventoryExcelUpload> entityResponse = new BaseEntityResponse<InventoryExcelUpload>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryExcelUploadBR.InsertItemMasterMapCategoryExcelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryExcelUploadDataProvider.InsertItemMasterMapCategoryExcel(item);
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

        public IBaseEntityResponse<InventoryExcelUpload> InsertItemMasterStoreDataExcel(InventoryExcelUpload item)
        {
            IBaseEntityResponse<InventoryExcelUpload> entityResponse = new BaseEntityResponse<InventoryExcelUpload>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryExcelUploadBR.InsertItemMasterStoreDataExcelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryExcelUploadDataProvider.InsertItemMasterStoreDataExcel(item);
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


        public IBaseEntityResponse<InventoryExcelUpload> InsertItemMasterPriceReportExcel(InventoryExcelUpload item)
        {
            IBaseEntityResponse<InventoryExcelUpload> entityResponse = new BaseEntityResponse<InventoryExcelUpload>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryExcelUploadBR.InsertItemMasterPriceReportExcelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryExcelUploadDataProvider.InsertItemMasterPriceReportExcel(item);
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



    }
}
