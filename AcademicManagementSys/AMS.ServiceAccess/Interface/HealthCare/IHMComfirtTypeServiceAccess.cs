using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IHMComfirtTypeServiceAccess
    {
        IBaseEntityResponse<HMComfirtType> InsertHMComfirtType(HMComfirtType item);
        IBaseEntityResponse<HMComfirtType> UpdateHMComfirtType(HMComfirtType item);
        IBaseEntityResponse<HMComfirtType> DeleteHMComfirtType(HMComfirtType item);
        IBaseEntityCollectionResponse<HMComfirtType> GetBySearch(HMComfirtTypeSearchRequest searchRequest);
        IBaseEntityResponse<HMComfirtType> SelectByID(HMComfirtType item);
        IBaseEntityCollectionResponse<HMComfirtType> GetHMComfirtTypeSearchList(HMComfirtTypeSearchRequest searchRequest);
    }
}
