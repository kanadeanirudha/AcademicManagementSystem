using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IUserDetailDataProvider
    {
        IBaseEntityCollectionResponse<UserDetail> GetUserDetailBySearch(UserDetailSearchRequest searchRequest);

        IBaseEntityResponse<UserDetail> GetUserDetailByID(int id);

        IBaseEntityResponse<UserDetail> InsertUserDetail(UserDetail item);

        IBaseEntityResponse<UserDetail> UpdateUserDetail(UserDetail item);

        IBaseEntityResponse<UserDetail> DeleteUserDetail(UserDetail item);
    }
}
