using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralPackageTypeDataProvider
    {
        IBaseEntityResponse<GeneralPackageType> InsertGeneralPackageType(GeneralPackageType item);
        IBaseEntityResponse<GeneralPackageType> UpdateGeneralPackageType(GeneralPackageType item);
        IBaseEntityResponse<GeneralPackageType> DeleteGeneralPackageType(GeneralPackageType item);
        IBaseEntityCollectionResponse<GeneralPackageType> GetGeneralPackageTypeBySearch(GeneralPackageTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPackageType> GetGeneralPackageTypeSearchList(GeneralPackageTypeSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPackageType> GetGeneralPackageTypeByID(GeneralPackageType item);
    }
}
