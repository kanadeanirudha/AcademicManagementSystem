using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralMapTypeOfAccountServiceAccess : IGeneralMapTypeOfAccountServiceAccess
    {
        IGeneralMapTypeOfAccountBA _generalMapTypeOfAccountBA = null;
        public GeneralMapTypeOfAccountServiceAccess()
        {
            _generalMapTypeOfAccountBA = new GeneralMapTypeOfAccountBA();
        }
        public IBaseEntityResponse<GeneralMapTypeOfAccount> InsertGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item)
        {
            return _generalMapTypeOfAccountBA.InsertGeneralMapTypeOfAccount(item);
        }
        public IBaseEntityResponse<GeneralMapTypeOfAccount> UpdateGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item)
        {
            return _generalMapTypeOfAccountBA.UpdateGeneralMapTypeOfAccount(item);
        }
        public IBaseEntityResponse<GeneralMapTypeOfAccount> DeleteGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item)
        {
            return _generalMapTypeOfAccountBA.DeleteGeneralMapTypeOfAccount(item);
        }
        public IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GetBySearch(GeneralMapTypeOfAccountSearchRequest searchRequest)
        {
            return _generalMapTypeOfAccountBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<GeneralMapTypeOfAccount> SelectByID(GeneralMapTypeOfAccount item)
        {
            return _generalMapTypeOfAccountBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GetByModuleCode(GeneralMapTypeOfAccountSearchRequest searchRequest)
        {
            return _generalMapTypeOfAccountBA.GetByModuleCode(searchRequest);
        }
    }
}
