using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEntranceExamApplicableExamToCourseDataProvider
    {
        IBaseEntityResponse<EntranceExamApplicableExamToCourse> InsertEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item);
        IBaseEntityResponse<EntranceExamApplicableExamToCourse> UpdateEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item);
        IBaseEntityResponse<EntranceExamApplicableExamToCourse> DeleteEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item);
        IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> GetEntranceExamApplicableExamToCourseBySearch(EntranceExamApplicableExamToCourseSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamApplicableExamToCourse> GetEntranceExamApplicableExamToCourseByID(EntranceExamApplicableExamToCourse item);

        //searchlist Implemented For Examination name from table OnlineExamExaminationMaster
        IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> GetExaminationNameByCourseID(EntranceExamApplicableExamToCourseSearchRequest searchRequest);

    }
}
