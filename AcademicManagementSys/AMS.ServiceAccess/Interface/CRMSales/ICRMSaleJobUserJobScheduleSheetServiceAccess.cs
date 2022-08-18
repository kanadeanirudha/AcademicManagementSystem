using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface ICRMSaleJobUserJobScheduleSheetServiceAccess
    {
        //CRMSaleAccountProgressTypeRule
        IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> InsertCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item);
        IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> UpdateCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item);
        IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> DeleteCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item);
        IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> SelectByCRMSaleJobUserJobScheduleSheetID(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetCRMSaleJobUserJobScheduleSheetSearchList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest);

        IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetEmployeeJobsList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetBySearchCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetGeneralOtherJobTypeList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest);


        //CRMSaleJobUserJobScheduleSheetUpdate
        IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetBySearchCRMSaleJobUserJobScheduleSheetUpdate(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest);

        IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> UpdateCRMSaleJobUserJobScheduleSheetUpdate(CRMSaleJobUserJobScheduleSheet item);
        //Get Employee From Job
        IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetAllocatedJobEmployeeList(CRMSaleJobUserJobScheduleSheetSearchRequest item);

        //IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetListTodaysMeetingSchedule(CRMSaleJobUserJobScheduleSheetSearchRequest item);
        
    }
}
