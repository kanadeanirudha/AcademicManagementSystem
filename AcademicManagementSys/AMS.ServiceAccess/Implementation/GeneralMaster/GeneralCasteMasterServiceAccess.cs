using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessAction;

namespace AMS.ServiceAccess
{
   public class GeneralCasteMasterServiceAccess  : IGeneralCasteMasterServiceAccess
    {
        IGeneralCasteMasterBA _generalCasteMasterBA = null;

         public GeneralCasteMasterServiceAccess()
        {
            _generalCasteMasterBA = new GeneralCasteMasterBA();
        }

         public IBaseEntityResponse<GeneralCasteMaster> InsertGeneralCasteMaster(GeneralCasteMaster item)
        {
            return _generalCasteMasterBA.InsertGeneralCasteMaster(item);
        }

         public IBaseEntityResponse<GeneralCasteMaster> UpdateGeneralCasteMaster(GeneralCasteMaster item)
        {
            return _generalCasteMasterBA.UpdateGeneralCasteMaster(item);
        }

         public IBaseEntityResponse<GeneralCasteMaster> DeleteGeneralCasteMaster(GeneralCasteMaster item)
        {
            return _generalCasteMasterBA.DeleteGeneralCasteMaster(item);
        }

         public IBaseEntityCollectionResponse<GeneralCasteMaster> GetBySearch(GeneralCasteMasterSearchRequest searchRequest)
        {
            return _generalCasteMasterBA.GetBySearch(searchRequest);
        }

         public IBaseEntityCollectionResponse<GeneralCasteMaster> GetGeneralCasteMasterGetBySearchList(GeneralCasteMasterSearchRequest searchRequest)
         {
             return _generalCasteMasterBA.GetGeneralCasteMasterGetBySearchList(searchRequest);
         }

         public IBaseEntityResponse<GeneralCasteMaster> SelectByID(GeneralCasteMaster item)
        {
            return _generalCasteMasterBA.SelectByID(item);
        }
    }
}
