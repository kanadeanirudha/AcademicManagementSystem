using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.DTO;
using AMS.Base.DTO;


namespace AMS.ServiceAccess
{
    public interface IGeneralLanguageMasterServiceAccess
    {
        IBaseEntityResponse<GeneralLanguageMaster> InsertGeneralLanguageMaster(GeneralLanguageMaster item);

        IBaseEntityResponse<GeneralLanguageMaster> UpdateGeneralLanguageMaster(GeneralLanguageMaster item);

        IBaseEntityResponse<GeneralLanguageMaster> DeleteGeneralLanguageMaster(GeneralLanguageMaster item);

        IBaseEntityCollectionResponse<GeneralLanguageMaster> GetBySearch(GeneralLanguageMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralLanguageMaster> GetBySearchList(GeneralLanguageMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralLanguageMaster> SelectByID(GeneralLanguageMaster item);
    }
}
