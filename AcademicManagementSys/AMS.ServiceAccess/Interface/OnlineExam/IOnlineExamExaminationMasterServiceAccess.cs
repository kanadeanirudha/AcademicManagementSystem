
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExamExaminationMasterServiceAccess
    {
        IBaseEntityResponse<OnlineExamExaminationMaster> InsertOnlineExamExaminationMaster(OnlineExamExaminationMaster item);
        IBaseEntityResponse<OnlineExamExaminationMaster> UpdateOnlineExamExaminationMaster(OnlineExamExaminationMaster item);
        IBaseEntityResponse<OnlineExamExaminationMaster> DeleteOnlineExamExaminationMaster(OnlineExamExaminationMaster item);
        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetBySearch(OnlineExamExaminationMasterSearchRequest searchRequest);
        //IBaseEntityResponse<OnlineExamExaminationMaster> GetSessionNameList(OnlineExamExaminationMaster item);
        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetOnlineExamExaminationMasterSearchList(OnlineExamExaminationMasterSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamExaminationMaster> SelectByID(OnlineExamExaminationMaster item);
        IBaseEntityCollectionResponse<OnlineExamExaminationMaster>GetExaminationNameList(OnlineExamExaminationMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> OnlineExamGetExaminationListCentreWise(OnlineExamExaminationMasterSearchRequest searchRequest);
    }
}
