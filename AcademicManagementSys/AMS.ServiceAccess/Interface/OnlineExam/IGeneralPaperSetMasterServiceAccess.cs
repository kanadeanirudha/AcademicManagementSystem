
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralPaperSetMasterServiceAccess
    {
        IBaseEntityResponse<GeneralPaperSetMaster> InsertGeneralPaperSetMaster(GeneralPaperSetMaster item);
        IBaseEntityResponse<GeneralPaperSetMaster> UpdateGeneralPaperSetMaster(GeneralPaperSetMaster item);
        IBaseEntityResponse<GeneralPaperSetMaster> DeleteGeneralPaperSetMaster(GeneralPaperSetMaster item);
        IBaseEntityCollectionResponse<GeneralPaperSetMaster> GetBySearch(GeneralPaperSetMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPaperSetMaster> SelectByID(GeneralPaperSetMaster item);
        IBaseEntityCollectionResponse<GeneralPaperSetMaster> GetGeneralPaperSetMasterSearchList(GeneralPaperSetMasterSearchRequest searchRequest);
    }
}
