using System;
using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
     public class GeneralLanguageMasterServiceAccess : IGeneralLanguageMasterServiceAccess
    {
         IGeneralLanguageMasterBA _languageMasterBA = null;

        public GeneralLanguageMasterServiceAccess()
        {
            _languageMasterBA = new GeneralLanguageMasterBA();
        }

        public IBaseEntityResponse<GeneralLanguageMaster> InsertGeneralLanguageMaster(GeneralLanguageMaster item)
        {
            return _languageMasterBA.InsertGeneralLanguageMaster(item);
        }

        public IBaseEntityResponse<GeneralLanguageMaster> UpdateGeneralLanguageMaster(GeneralLanguageMaster item)
        {
            return _languageMasterBA.UpdateGeneralLanguageMaster(item);
        }

        public IBaseEntityResponse<GeneralLanguageMaster> DeleteGeneralLanguageMaster(GeneralLanguageMaster item)
        {
            return _languageMasterBA.DeleteGeneralLanguageMaster(item);
        }

        public IBaseEntityCollectionResponse<GeneralLanguageMaster> GetBySearch(GeneralLanguageMasterSearchRequest searchRequest)
        {
            return _languageMasterBA.GetBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<GeneralLanguageMaster> GetBySearchList(GeneralLanguageMasterSearchRequest searchRequest)
        {
            return _languageMasterBA.GetBySearchList(searchRequest);
        }

        public IBaseEntityResponse<GeneralLanguageMaster> SelectByID(GeneralLanguageMaster item)
        {
            return _languageMasterBA.SelectByID(item);
        }
    }
}
