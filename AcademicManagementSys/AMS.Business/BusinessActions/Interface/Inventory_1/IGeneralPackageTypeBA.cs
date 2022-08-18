using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralPackageTypeBA
    {
        IBaseEntityResponse<GeneralPackageType> InsertGeneralPackageType(GeneralPackageType item);
        IBaseEntityResponse<GeneralPackageType> UpdateGeneralPackageType(GeneralPackageType item);
        IBaseEntityResponse<GeneralPackageType> DeleteGeneralPackageType(GeneralPackageType item);
        IBaseEntityCollectionResponse<GeneralPackageType> GetBySearch(GeneralPackageTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPackageType> GetGeneralPackageTypeSearchList(GeneralPackageTypeSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPackageType> SelectByID(GeneralPackageType item);
    }
}

