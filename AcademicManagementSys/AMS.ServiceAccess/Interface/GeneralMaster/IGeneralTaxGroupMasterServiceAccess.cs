using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralTaxGroupMasterServiceAccess
    {
        IBaseEntityResponse<GeneralTaxGroupMaster> InsertGeneralTaxGroupMaster(GeneralTaxGroupMaster item);
        IBaseEntityResponse<GeneralTaxGroupMaster> UpdateGeneralTaxGroupMaster(GeneralTaxGroupMaster item);
        IBaseEntityResponse<GeneralTaxGroupMaster> DeleteGeneralTaxGroupMaster(GeneralTaxGroupMaster item);
        IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetBySearch(GeneralTaxGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTaxGroupMaster> SelectByID(GeneralTaxGroupMaster item);
        IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetGeneralTaxGroupMasterList(GeneralTaxGroupMasterSearchRequest searchRequest);
    }
}
