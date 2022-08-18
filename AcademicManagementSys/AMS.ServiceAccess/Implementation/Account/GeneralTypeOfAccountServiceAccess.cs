using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class GeneralTypeOfAccountServiceAccess : IGeneralTypeOfAccountServiceAccess
	{
        IGeneralTypeOfAccountBA _GeneralTypeOfAccountBA = null;
		public GeneralTypeOfAccountServiceAccess()
		{
			_GeneralTypeOfAccountBA = new GeneralTypeOfAccountBA();
		}
		public IBaseEntityResponse<GeneralTypeOfAccount> InsertGeneralTypeOfAccount(GeneralTypeOfAccount item)
		{
			return _GeneralTypeOfAccountBA.InsertGeneralTypeOfAccount(item);
		}
		public IBaseEntityResponse<GeneralTypeOfAccount> UpdateGeneralTypeOfAccount(GeneralTypeOfAccount item)
		{
			return _GeneralTypeOfAccountBA.UpdateGeneralTypeOfAccount(item);
		}
		public IBaseEntityResponse<GeneralTypeOfAccount> DeleteGeneralTypeOfAccount(GeneralTypeOfAccount item)
		{
			return _GeneralTypeOfAccountBA.DeleteGeneralTypeOfAccount(item);
		}
		public IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetBySearch(GeneralTypeOfAccountSearchRequest searchRequest)
		{
			return _GeneralTypeOfAccountBA.GetBySearch(searchRequest);
		}
        public IBaseEntityResponse<GeneralTypeOfAccount> SelectByID(GeneralTypeOfAccount item)
        {
            return _GeneralTypeOfAccountBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetListName(GeneralTypeOfAccountSearchRequest searchRequest)
        {
            return _GeneralTypeOfAccountBA.GetListName(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetListAccountType(GeneralTypeOfAccountSearchRequest searchRequest)
        {
            return _GeneralTypeOfAccountBA.GetListAccountType(searchRequest);
        }


	}
}
