using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IHMRoomTypeServiceAccess
    {
        IBaseEntityResponse<HMRoomType> InsertHMRoomType(HMRoomType item);
        IBaseEntityResponse<HMRoomType> UpdateHMRoomType(HMRoomType item);
        IBaseEntityResponse<HMRoomType> DeleteHMRoomType(HMRoomType item);
        IBaseEntityCollectionResponse<HMRoomType> GetBySearch(HMRoomTypeSearchRequest searchRequest);
        IBaseEntityResponse<HMRoomType> SelectByID(HMRoomType item);
        IBaseEntityCollectionResponse<HMRoomType> GetHMRoomTypeSearchList(HMRoomTypeSearchRequest searchRequest);
    }
}
