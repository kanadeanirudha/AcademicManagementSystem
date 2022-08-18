using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.DTO;
using AMS.Base.DTO;


namespace AMS.ServiceAccess
{
    public interface IGeneralReligionMasterServiceAccess
    {
        IBaseEntityResponse<GeneralReligionMaster> InsertGeneralReligionMaster(GeneralReligionMaster item);

        IBaseEntityResponse<GeneralReligionMaster> UpdateGeneralReligionMaster(GeneralReligionMaster item);

        IBaseEntityResponse<GeneralReligionMaster> DeleteGeneralReligionMaster(GeneralReligionMaster item);

        IBaseEntityCollectionResponse<GeneralReligionMaster> GetBySearch(GeneralReligionMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralReligionMaster> SelectByID(GeneralReligionMaster item);

        IBaseEntityCollectionResponse<GeneralReligionMaster> GetBySearchList(GeneralReligionMasterSearchRequest searchRequest);
    }
}
