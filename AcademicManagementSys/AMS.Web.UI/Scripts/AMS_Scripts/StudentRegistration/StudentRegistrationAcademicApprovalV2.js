//this class contain methods related to nationality functionality
var StudentRegistrationAcademicApprovalV2 = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        StudentRegistrationAcademicApprovalV2.constructor();
        //StudentRegistrationAcademicApproval.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        
        $('#EditStudentRegistrationAcademicApprovalRecord').on("click", function () {
            
            if ($('#ApprovalStatus').val() == "1") {
                if ($('#SelectedSectionDetailID').val() != '') {
                    //$('#EditStudentRegistrationAcademicApprovalRecord').attr("disabled",true);
                    StudentRegistrationAcademicApprovalV2.ActionName = "Edit";
                    StudentRegistrationAcademicApprovalV2.AjaxCallStudentRegistrationAcademicApproval();
                }
                else {
                    //alert("Please select admitted section");  
                    swal("Please select section", "", "warning");
                    $('#SelectedSectionDetailID').focus();
                }
            }
            else {
                if ($('#ReasonIfRejected').val() != '') {
                    StudentRegistrationAcademicApprovalV2.ActionName = "Edit";
                    StudentRegistrationAcademicApprovalV2.AjaxCallStudentRegistrationAcademicApproval();
                }
                else {
                    swal("Please specify reason of rejection", "", "warning");
                    $('#ReasonIfRejected').focus();
                }
            }

        });
        $("#UserSearch").keyup(function () {
            var oTable = $("#MyDataTableStudentRegistrationAcademicApproval").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();

        $("#ApprovalStatus").change(function () {
            var selectedItem = $(this).val();
            if (selectedItem == "0") {
                $("#DivIfRejected").show(true)
                $('#diverrorMessage').hide(true);
                $('#divAdmittedSectionDetails').hide(true);
                $('#diverrorreason').text('');
                $('#diverrorreason').show();
            }
            else {
                $("#DivIfRejected").hide(true)
                $('#diverrorMessage').hide(true);
                $('#divAdmittedSectionDetails').show();
                $('#diverrorreason').hide(true);
            }

        });
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/StudentRegistrationAcademicApproval/ListV2',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        //$(".ajax").colorbox();
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        notify(message, colorCode);
        $('#SRAA').click();
        //  var TaskCode = $('input[name=TaskCode]').val();
        //var TaskCode = "SRAA";
        //$.ajax(
        //{
        //    cache: false,
        //    type: "POST",
        //    dataType: "html",
        //    data: { "actionMode": actionMode, "TaskCode": TaskCode },
        //    url: '/Home/NotificationListV2',
        //    success: function (data) {
        //        //Rebind Grid Data
        //        $('#content').empty().html(data);
        //        notify(message, colorCode);
        //    }
        //});
    },


    //Fire ajax call to insert update and delete record
    AjaxCallStudentRegistrationAcademicApproval: function () {
        var StudentRegistrationAcademicApprovalData = null;
        if (StudentRegistrationAcademicApprovalV2.ActionName == "Edit") {
            // $("#FormEditStudentRegistrationAcademicApproval").validate();
            // if ($("#FormEditStudentRegistrationAcademicApproval").valid()) {
            //  StudentRegistrationAcademicApprovalData = null;
            StudentRegistrationAcademicApprovalData = StudentRegistrationAcademicApprovalV2.GetStudentRegistrationAcademicApproval();
            ajaxRequest.makeRequest("/StudentRegistrationAcademicApproval/EditV2", "POST", StudentRegistrationAcademicApprovalData, StudentRegistrationAcademicApprovalV2.Success,"EditStudentRegistrationAcademicApprovalRecord");
            //}
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetStudentRegistrationAcademicApproval: function () {
        var Data = {
        };
        if (StudentRegistrationAcademicApprovalV2.ActionName == "Edit") {
            //  Data.ID = $('#ID').val();
            Data.Student_Domesile_CountryId = $('#Student_Domesile_CountryId').val();
            Data.StudentRegionOther = $('#StudentRegionOther').val();

            Data.RegistrationID = $('#RegistrationID').val();
            Data.StudentFirstName = $('#StudentFirstName').val();
            Data.StudentEmailID = $('#StudentEmailID').val();

            Data.Student_PermanentAddress_CountryId = $('#Student_PermanentAddress_CountryId').val();
            Data.Student_PermanentAddress_State = $('#Student_PermanentAddress_State').val();
            Data.Student_PermanentAddress_StateOther = $('#Student_PermanentAddress_StateOther').val();
            Data.Student_PermanentAddress_DistrictID = $('#Student_PermanentAddress_DistrictID').val();
            Data.Student_PermanentAddress_DistrictOther = $('#Student_PermanentAddress_DistrictOther').val();
            Data.Student_PermanentAddress_City_TahsilID = $('#Student_PermanentAddress_City_TahsilID').val();
            Data.Student_PermanentAddress_City_TahsilOther = $('#Student_PermanentAddress_City_TahsilOther').val();

            Data.Student_CorrespondenceAddress_CountryId = $('#Student_CorrespondenceAddress_CountryId').val();
            Data.Student_CorrespondenceAddress_State = $('#Student_CorrespondenceAddress_State').val();
            Data.Student_CorrespondenceAddress_StateOther = $('#Student_CorrespondenceAddress_StateOther').val();
            Data.Student_CorrespondenceAddress_DistrictID = $('#Student_CorrespondenceAddress_DistrictID').val();
            Data.Student_CorrespondenceAddress_DistrictOther = $('#Student_CorrespondenceAddress_DistrictOther').val();
            Data.Student_CorrespondenceAddress_City_TahsilID = $('#Student_CorrespondenceAddress_City_TahsilID').val();
            Data.Student_CorrespondenceAddress_City_TahsilOther = $('#Student_CorrespondenceAddress_City_TahsilOther').val();

            Data.Student_Qualification_Diploma_ITI_Details_CountryId = $('#Student_Qualification_Diploma_ITI_Details_CountryId').val();
            Data.Student_Qualification_Diploma_ITI_Details_StateOther = $('#Student_Qualification_Diploma_ITI_Details_StateOther').val();
            Data.Student_Qualification_DegreeDetails_CountryId = $('#Student_Qualification_DegreeDetails_CountryId').val();
            Data.Student_Qualification_DegreeDetails_StateOther = $('#Student_Qualification_DegreeDetails_StateOther').val();
            Data.Student_Qualification_PostGraduationDetails_CountryId = $('#Student_Qualification_PostGraduationDetails_CountryId').val();
            Data.Student_Qualification_PostGraduationDetails_StateOther = $('#Student_Qualification_PostGraduationDetails_StateOther').val();
            Data.ApprovalStatus = $('#ApprovalStatus').val();

            Data.ReasonIfRejected = $('#ReasonIfRejected').val();

            Data.StuRegistrationStudentPhotoSignThumb = $('#StuRegistrationStudentPhotoSignThumb').val();
            Data.StuRegistrationStudentSocialReservationInformation = $('#StuRegistrationStudentSocialReservationInformation').val();
            Data.StuRegistrationOtherInfoOfStudent = $('#StuRegistrationOtherInfoOfStudent').val();
            Data.stuRegistrationAddressDetails = $('#stuRegistrationAddressDetails').val();
            Data.StuRegistrationPreQualificationSchoolTransaction = $('#StuRegistrationPreQualificationSchoolTransaction').val();
            Data.StuRegistrationPreEntranceExaminationTransaction = $('#StuRegistrationPreEntranceExaminationTransaction').val();
            Data.StuRegistrationPreEntranceExaminationSubjectDetail = $('#StuRegistrationPreEntranceExaminationSubjectDetail').val();
            Data.StuRegistrationPreQualificationCollegeTransaction = $('#StuRegistrationPreQualificationCollegeTransaction').val();
            Data.StuRegistrationQualifyingSelectionInfo = $('#StuRegistrationQualifyingSelectionInfo').val();
            Data.StuRegistrationDocumentSubmitted = $('#StuRegistrationDocumentSubmitted').val();
            Data.SelectedSectionDetailID = $('#SelectedSectionDetailID').val();

            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();

        }
        else if (StudentRegistrationAcademicApprovalV2.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        if (data != null) {
          
            StudentRegistrationAcademicApprovalV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            StudentRegistrationAcademicApprovalV2.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    //colorBoxClose: function () {
    //    parent.$.colorbox.close();
    //},

};

