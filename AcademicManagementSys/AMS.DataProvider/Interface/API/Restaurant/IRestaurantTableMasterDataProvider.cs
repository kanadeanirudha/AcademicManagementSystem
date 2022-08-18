using System;

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IRestaurantTableMasterDataProvider
    {
        //IBaseEntityResponse<RestaurantTableMaster> InventoryCounterLogin(RestaurantTableMaster item);
        //IBaseEntityResponse<RestaurantTableMaster> PostOnline(RestaurantTableMaster item);
        //IBaseEntityResponse<RestaurantTableMaster> GetLocalInvoiceNo(RestaurantTableMaster item);
        IBaseEntityCollectionResponse<RestaurantTableMaster> RestaurantTableGetOnline(RestaurantTableMasterSearchRequest searchRequest);

        //Methods for RestaurantTableMaster form
        IBaseEntityResponse<RestaurantTableMaster> InsertRestaurantTableMaster(RestaurantTableMaster item);
        IBaseEntityResponse<RestaurantTableMaster> UpdateRestaurantTableMaster(RestaurantTableMaster item);
        IBaseEntityResponse<RestaurantTableMaster> DeleteRestaurantTableMaster(RestaurantTableMaster item);
        IBaseEntityCollectionResponse<RestaurantTableMaster> GetRestaurantTableMasterBySearch(RestaurantTableMasterSearchRequest searchRequest);
        IBaseEntityResponse<RestaurantTableMaster> GetRestaurantTableMasterByID(RestaurantTableMaster item);
        IBaseEntityCollectionResponse<RestaurantTableMaster> GetRestaurantCategory(RestaurantTableMasterSearchRequest searchRequest);
    }
}
