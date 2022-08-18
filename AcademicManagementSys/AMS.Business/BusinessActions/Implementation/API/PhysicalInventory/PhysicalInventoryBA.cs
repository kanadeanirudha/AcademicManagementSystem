using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;

namespace AMS.Business.BusinessAction
{
    public class PhysicalInventoryBA : IPhysicalInventoryBA
    {
        IPhysicalInventoryDataProvider _PhysicalInventoryDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public PhysicalInventoryBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _PhysicalInventoryDataProvider = new PhysicalInventoryDataProvider();
        }

        public IBaseEntityResponse<PhysicalInventory> PostPhysicalInventory(PhysicalInventory item)
        {
            IBaseEntityResponse<PhysicalInventory> entityResponse = new BaseEntityResponse<PhysicalInventory>();
            try
            {

                if (_PhysicalInventoryDataProvider != null)
                {
                    entityResponse = _PhysicalInventoryDataProvider.PostPhysicalInventory(item);
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

        public IBaseEntityCollectionResponse<PhysicalInventory> GetPhysicalInventory(PhysicalInventorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PhysicalInventory> entityResponse = new BaseEntityCollectionResponse<PhysicalInventory>();
            try
            {

                if (_PhysicalInventoryDataProvider != null)
                {
                    entityResponse = _PhysicalInventoryDataProvider.GetPhysicalInventory(searchRequest);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
    }
}
