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
    public class GetIngredientsListBA : IGetIngredientsListBA
    {
        IGetIngredientsListDataProvider _GetIngredientsListDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public GetIngredientsListBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _GetIngredientsListDataProvider = new GetIngredientsListDataProvider();
        }


        public IBaseEntityCollectionResponse<GetIngredientsList> GetIngredientsListSelfService(GetIngredientsListSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GetIngredientsList> entityResponse = new BaseEntityCollectionResponse<GetIngredientsList>();
            try
            {

                if (_GetIngredientsListDataProvider != null)
                {
                    entityResponse = _GetIngredientsListDataProvider.GetIngredientsListSelfService(searchRequest);
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
