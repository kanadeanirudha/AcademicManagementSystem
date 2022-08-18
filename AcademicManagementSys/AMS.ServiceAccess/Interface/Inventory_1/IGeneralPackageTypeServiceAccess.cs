using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralPackageTypeServiceAccess
    {
        IBaseEntityResponse<GeneralPackageType> InsertGeneralPackageType(GeneralPackageType item);
        IBaseEntityResponse<GeneralPackageType> UpdateGeneralPackageType(GeneralPackageType item);
        IBaseEntityResponse<GeneralPackageType> DeleteGeneralPackageType(GeneralPackageType item);
        IBaseEntityCollectionResponse<GeneralPackageType> GetBySearch(GeneralPackageTypeSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPackageType> SelectByID(GeneralPackageType item);
        IBaseEntityCollectionResponse<GeneralPackageType> GetGeneralPackageTypeSearchList(GeneralPackageTypeSearchRequest searchRequest);
    }
}
