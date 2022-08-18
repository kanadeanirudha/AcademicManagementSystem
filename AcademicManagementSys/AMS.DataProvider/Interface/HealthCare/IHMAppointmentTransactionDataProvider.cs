using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IHMAppointmentTransactionDataProvider
    {
        IBaseEntityResponse<HMAppointmentTransaction> InsertHMAppointmentTransaction(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> UpdateHMAppointmentTransaction(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> DeleteHMAppointmentTransaction(HMAppointmentTransaction item);
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetHMAppointmentTransactionBySearch(HMAppointmentTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetHMAppointmentTransactionSearchList(HMAppointmentTransactionSearchRequest searchRequest);
        IBaseEntityResponse<HMAppointmentTransaction> GetGeneralDataByGeneralPatientMasterId(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> LastcaseHistory(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> LastPrescription(HMAppointmentTransaction item);
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetListOfPatient(HMAppointmentTransactionSearchRequest searchRequest);                                             
        IBaseEntityResponse<HMAppointmentTransaction> GetHMAppointmentTransactionByID(HMAppointmentTransaction item);
        //For Appointment Transaction
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetAppointmentData(HMAppointmentTransactionSearchRequest searchRequest);                                             
    }
}
