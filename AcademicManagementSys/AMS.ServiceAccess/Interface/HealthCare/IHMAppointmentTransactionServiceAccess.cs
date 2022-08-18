using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IHMAppointmentTransactionServiceAccess
    {
        IBaseEntityResponse<HMAppointmentTransaction> InsertHMAppointmentTransaction(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> UpdateHMAppointmentTransaction(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> DeleteHMAppointmentTransaction(HMAppointmentTransaction item);
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetBySearch(HMAppointmentTransactionSearchRequest searchRequest);
        IBaseEntityResponse<HMAppointmentTransaction> SelectByID(HMAppointmentTransaction item);
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetHMAppointmentTransactionSearchList(HMAppointmentTransactionSearchRequest searchRequest);
        IBaseEntityResponse<HMAppointmentTransaction> GetGeneralDataByGeneralPatientMasterId(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> LastcaseHistory(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> LastPrescription(HMAppointmentTransaction item);
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetListOfPatient(HMAppointmentTransactionSearchRequest searchRequest);

        //IBaseEntityResponse<HMAppointmentTransaction> GetGeneralDataByGeneralPatientMasterId(HMAppointmentTransaction hMAppointmentTransaction);
        
        //For Appointment Data
        IBaseEntityCollectionResponse<HMAppointmentTransaction>GetAppointmentData(HMAppointmentTransactionSearchRequest searchRequest);
    }
}
