using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;

namespace AMS.Business.BusinessAction
{
    public class InventoryRecipeDetailsBA : IInventoryRecipeDetailsBA
    {
        IInventoryRecipeDetailsDataProvider _InventoryRecipeDetailsDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public InventoryRecipeDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _InventoryRecipeDetailsDataProvider = new InventoryRecipeDetailsDataProvider();
        }

        public IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeMaster(InventoryRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeDetails> entityResponse = new BaseEntityCollectionResponse<InventoryRecipeDetails>();
            try
            {

                if (_InventoryRecipeDetailsDataProvider != null)
                {
                    entityResponse = _InventoryRecipeDetailsDataProvider.GetInventoryRecipeMaster(searchRequest);
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
        public IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryVariationMaster(InventoryRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeDetails> entityResponse = new BaseEntityCollectionResponse<InventoryRecipeDetails>();
            try
            {

                if (_InventoryRecipeDetailsDataProvider != null)
                {
                    entityResponse = _InventoryRecipeDetailsDataProvider.GetInventoryVariationMaster(searchRequest);
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

        public IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeFormulaDetails(InventoryRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeDetails> entityResponse = new BaseEntityCollectionResponse<InventoryRecipeDetails>();
            try
            {

                if (_InventoryRecipeDetailsDataProvider != null)
                {
                    entityResponse = _InventoryRecipeDetailsDataProvider.GetInventoryRecipeFormulaDetails(searchRequest);
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

