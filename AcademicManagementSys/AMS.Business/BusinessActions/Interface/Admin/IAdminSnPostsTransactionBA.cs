using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IAdminSnPostsTransactionBA
    {
        IBaseEntityResponse<AdminSnPostsTransaction> InsertAdminSnPostsTransaction(AdminSnPostsTransaction item);

        IBaseEntityResponse<AdminSnPostsTransaction> UpdateAdminSnPostsTransaction(AdminSnPostsTransaction item);

        IBaseEntityResponse<AdminSnPostsTransaction> DeleteAdminSnPostsTransaction(AdminSnPostsTransaction item);

        IBaseEntityCollectionResponse<AdminSnPostsTransaction> GetBySearch(AdminSnPostsTransactionSearchRequest searchRequest);
        
    }
}
