using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAdminSnPostsTransactionDataProvider
    {
        IBaseEntityCollectionResponse<AdminSnPostsTransaction> GetAdminSnPostsTransactionBySearch(AdminSnPostsTransactionSearchRequest searchRequest);

        IBaseEntityResponse<AdminSnPostsTransaction> GetAdminSnPostsTransactionByID(int id);

        IBaseEntityResponse<AdminSnPostsTransaction> InsertAdminSnPostsTransaction(AdminSnPostsTransaction item);

        IBaseEntityResponse<AdminSnPostsTransaction> UpdateAdminSnPostsTransaction(AdminSnPostsTransaction item);

        IBaseEntityResponse<AdminSnPostsTransaction> DeleteAdminSnPostsTransaction(AdminSnPostsTransaction item);
    }
}
