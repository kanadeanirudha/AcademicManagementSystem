using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface IGeneralTypeOfAccountBA
	{
		IBaseEntityResponse<GeneralTypeOfAccount> InsertGeneralTypeOfAccount(GeneralTypeOfAccount item);
		IBaseEntityResponse<GeneralTypeOfAccount> UpdateGeneralTypeOfAccount(GeneralTypeOfAccount item);
		IBaseEntityResponse<GeneralTypeOfAccount> DeleteGeneralTypeOfAccount(GeneralTypeOfAccount item);
		IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetBySearch(GeneralTypeOfAccountSearchRequest searchRequest);
		//IBaseEntityResponse<GeneralTypeOfAccount> SelectByID(GeneralTypeOfAccount item);
        IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetListName(GeneralTypeOfAccountSearchRequest searchRequest);
        //IBaseEntityResponse<GeneralTypeOfAccount> GetListName(GeneralTypeOfAccount item);
        IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetListAccountType(GeneralTypeOfAccountSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTypeOfAccount> SelectByID(GeneralTypeOfAccount item);
    }
}
