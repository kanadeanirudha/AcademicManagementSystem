

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IOnlineExamExaminationMasterBA
    {
        IBaseEntityResponse<OnlineExamExaminationMaster> InsertOnlineExamExaminationMaster(OnlineExamExaminationMaster item);
        IBaseEntityResponse<OnlineExamExaminationMaster> UpdateOnlineExamExaminationMaster(OnlineExamExaminationMaster item);
        IBaseEntityResponse<OnlineExamExaminationMaster> DeleteOnlineExamExaminationMaster(OnlineExamExaminationMaster item);
        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetBySearch(OnlineExamExaminationMasterSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetSessionNameList(OnlineExamExaminationMaster searchRequest);
        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetOnlineExamExaminationMasterSearchList(OnlineExamExaminationMasterSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamExaminationMaster> SelectByID(OnlineExamExaminationMaster item);
        //For Staff Allocation
        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetExaminationNameList(OnlineExamExaminationMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamExaminationMaster> OnlineExamGetExaminationListCentreWise(OnlineExamExaminationMasterSearchRequest searchRequest);
    }
}

