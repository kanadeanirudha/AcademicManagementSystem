using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IGeneralTypeOfAccountDataProvider
	{
		IBaseEntityResponse<GeneralTypeOfAccount> InsertGeneralTypeOfAccount(GeneralTypeOfAccount item);
		IBaseEntityResponse<GeneralTypeOfAccount> UpdateGeneralTypeOfAccount(GeneralTypeOfAccount item);
		IBaseEntityResponse<GeneralTypeOfAccount> DeleteGeneralTypeOfAccount(GeneralTypeOfAccount item);
		IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetGeneralTypeOfAccountBySearch(GeneralTypeOfAccountSearchRequest searchRequest);
		//IBaseEntityResponse<GeneralTypeOfAccount> GetGeneralTypeOfAccountByID(GeneralTypeOfAccount item);
        IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetListName(GeneralTypeOfAccountSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTypeOfAccount> SelectByID(GeneralTypeOfAccount item);
        IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetListAccountType(GeneralTypeOfAccountSearchRequest searchRequest);
    }
}
