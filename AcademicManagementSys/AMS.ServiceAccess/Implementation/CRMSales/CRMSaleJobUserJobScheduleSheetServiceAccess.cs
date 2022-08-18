using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMSaleJobUserJobScheduleSheetServiceAccess : ICRMSaleJobUserJobScheduleSheetServiceAccess
    {
        ICRMSaleJobUserJobScheduleSheetBA cRMSaleJobUserJobScheduleSheetBA = null;

        public CRMSaleJobUserJobScheduleSheetServiceAccess()
        {
            cRMSaleJobUserJobScheduleSheetBA = new CRMSaleJobUserJobScheduleSheetBA();
        }

        //CRMSaleJobUserJobScheduleSheet
        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> InsertCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item)
        {
            return cRMSaleJobUserJobScheduleSheetBA.InsertCRMSaleJobUserJobScheduleSheet(item);
        }

        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> UpdateCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item)
        {
            return cRMSaleJobUserJobScheduleSheetBA.UpdateCRMSaleJobUserJobScheduleSheet(item);
        }

        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> DeleteCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item)
        {
            return cRMSaleJobUserJobScheduleSheetBA.DeleteCRMSaleJobUserJobScheduleSheet(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetCRMSaleJobUserJobScheduleSheetSearchList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            return cRMSaleJobUserJobScheduleSheetBA.GetCRMSaleJobUserJobScheduleSheetSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetBySearchCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            return cRMSaleJobUserJobScheduleSheetBA.GetBySearchCRMSaleJobUserJobScheduleSheet(searchRequest);
        }
        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> SelectByCRMSaleJobUserJobScheduleSheetID(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            return cRMSaleJobUserJobScheduleSheetBA.SelectByCRMSaleJobUserJobScheduleSheetID(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetEmployeeJobsList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            return cRMSaleJobUserJobScheduleSheetBA.GetEmployeeJobsList(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetGeneralOtherJobTypeList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            return cRMSaleJobUserJobScheduleSheetBA.GetGeneralOtherJobTypeList(searchRequest);
        } 


        //CRMSaleJobUserJobScheduleSheetUpdate
        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetBySearchCRMSaleJobUserJobScheduleSheetUpdate(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            return cRMSaleJobUserJobScheduleSheetBA.GetBySearchCRMSaleJobUserJobScheduleSheetUpdate(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> UpdateCRMSaleJobUserJobScheduleSheetUpdate(CRMSaleJobUserJobScheduleSheet item)
        {
            return cRMSaleJobUserJobScheduleSheetBA.UpdateCRMSaleJobUserJobScheduleSheetUpdate(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetAllocatedJobEmployeeList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            return cRMSaleJobUserJobScheduleSheetBA.GetAllocatedJobEmployeeList(searchRequest);
        }

        //public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetListTodaysMeetingSchedule(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        //{
        //    return cRMSaleJobUserJobScheduleSheetBA.GetListTodaysMeetingSchedule(searchRequest);
        //} 

        
    }
}
