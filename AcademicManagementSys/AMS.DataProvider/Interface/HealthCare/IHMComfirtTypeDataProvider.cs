using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IHMComfirtTypeDataProvider
    {
        IBaseEntityResponse<HMComfirtType> InsertHMComfirtType(HMComfirtType item);
        IBaseEntityResponse<HMComfirtType> UpdateHMComfirtType(HMComfirtType item);
        IBaseEntityResponse<HMComfirtType> DeleteHMComfirtType(HMComfirtType item);
        IBaseEntityCollectionResponse<HMComfirtType> GetHMComfirtTypeBySearch(HMComfirtTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMComfirtType> GetHMComfirtTypeSearchList(HMComfirtTypeSearchRequest searchRequest);
        IBaseEntityResponse<HMComfirtType> GetHMComfirtTypeByID(HMComfirtType item);
    }
}
