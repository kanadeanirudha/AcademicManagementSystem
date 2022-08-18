using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GetIngredientsListServiceAccess : IGetIngredientsListServiceAccess
    {
        IGetIngredientsListBA  _GetIngredientsListBA = null;

        public GetIngredientsListServiceAccess()
        {
            _GetIngredientsListBA = new GetIngredientsListBA();
        }

        public IBaseEntityCollectionResponse<GetIngredientsList> GetIngredientsListSelfService(GetIngredientsListSearchRequest searchRequest)
        {
            return _GetIngredientsListBA.GetIngredientsListSelfService(searchRequest);
        }
      
    }
}
