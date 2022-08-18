
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IRestaurantTableMasterBA
    {
        IBaseEntityCollectionResponse<RestaurantTableMaster> RestaurantTableGetOnline(RestaurantTableMasterSearchRequest searchRequest);

        //Methods for RestaurantTableMaster Form
        IBaseEntityResponse<RestaurantTableMaster> InsertRestaurantTableMaster(RestaurantTableMaster item);
        IBaseEntityResponse<RestaurantTableMaster> UpdateRestaurantTableMaster(RestaurantTableMaster item);
        IBaseEntityResponse<RestaurantTableMaster> DeleteRestaurantTableMaster(RestaurantTableMaster item);
        IBaseEntityCollectionResponse<RestaurantTableMaster> GetBySearch(RestaurantTableMasterSearchRequest searchRequest);
        IBaseEntityResponse<RestaurantTableMaster> SelectByID(RestaurantTableMaster item);
        IBaseEntityCollectionResponse<RestaurantTableMaster> GetRestaurantCategory(RestaurantTableMasterSearchRequest searchRequest);
    }
}
