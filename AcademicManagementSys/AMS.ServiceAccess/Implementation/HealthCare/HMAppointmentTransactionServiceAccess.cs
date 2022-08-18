using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class HMAppointmentTransactionServiceAccess : IHMAppointmentTransactionServiceAccess
    {
        IHMAppointmentTransactionBA _HMAppointmentTransactionBA = null;
        public HMAppointmentTransactionServiceAccess()
        {
            _HMAppointmentTransactionBA = new HMAppointmentTransactionBA();
        }
        public IBaseEntityResponse<HMAppointmentTransaction> InsertHMAppointmentTransaction(HMAppointmentTransaction item)
        {
            return _HMAppointmentTransactionBA.InsertHMAppointmentTransaction(item);
        }
        public IBaseEntityResponse<HMAppointmentTransaction> UpdateHMAppointmentTransaction(HMAppointmentTransaction item)
        {
            return _HMAppointmentTransactionBA.UpdateHMAppointmentTransaction(item);
        }
        public IBaseEntityResponse<HMAppointmentTransaction> DeleteHMAppointmentTransaction(HMAppointmentTransaction item)
        {
            return _HMAppointmentTransactionBA.DeleteHMAppointmentTransaction(item);
        }
        public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetBySearch(HMAppointmentTransactionSearchRequest searchRequest)
        {
            return _HMAppointmentTransactionBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetHMAppointmentTransactionSearchList(HMAppointmentTransactionSearchRequest searchRequest)
        {
            return _HMAppointmentTransactionBA.GetHMAppointmentTransactionSearchList(searchRequest);
        }
        public IBaseEntityResponse<HMAppointmentTransaction> SelectByID(HMAppointmentTransaction item)
        {
            return _HMAppointmentTransactionBA.SelectByID(item);
        }
        //For PatientList
        public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetListOfPatient(HMAppointmentTransactionSearchRequest searchRequest)
        {
            return _HMAppointmentTransactionBA.GetListOfPatient(searchRequest);
        }
        //For General
        public IBaseEntityResponse<HMAppointmentTransaction> GetGeneralDataByGeneralPatientMasterId(HMAppointmentTransaction item)
        {
            return _HMAppointmentTransactionBA.GetGeneralDataByGeneralPatientMasterId(item);
        }
        //For Last Case History
        public IBaseEntityResponse<HMAppointmentTransaction> LastcaseHistory(HMAppointmentTransaction item)
        {
            return _HMAppointmentTransactionBA.LastcaseHistory(item);
        }
        //For Last Priscription
        public IBaseEntityResponse<HMAppointmentTransaction> LastPrescription(HMAppointmentTransaction item)
        {
            return _HMAppointmentTransactionBA.LastPrescription(item);
        }
        //For Appointment  Data
        public IBaseEntityCollectionResponse<HMAppointmentTransaction>GetAppointmentData(HMAppointmentTransactionSearchRequest searchRequest)
        {
            return _HMAppointmentTransactionBA.GetAppointmentData(searchRequest);
        }
    }
}
