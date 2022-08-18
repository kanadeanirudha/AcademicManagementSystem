//this class contain methods related to nationality functionality
var StudentRegistrationAcademicApproval = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        StudentRegistrationAcademicApproval.constructor();
        //StudentRegistrationAcademicApproval.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        
        $('#EditStudentRegistrationAcademicApprovalRecord').on("click", function () {
            
            if ($('#ApprovalStatus').val() == "1") {
                if ($('#SelectedSectionDetailID').val() != '') {
                    $('#EditStudentRegistrationAcademicApprovalRecord').attr("disabled",true);
                    StudentRegistrationAcademicApproval.ActionName = "Edit";
                    StudentRegistrationAcademicApproval.AjaxCallStudentRegistrationAcademicApproval();
                }
                else {
                    //alert("Please select admitted section");  
                    $('#diverrorMessage').text("Please select section.");
                    $('#diverrorMessage').show();
                    $('#SelectedSectionDetailID').focus();
                }
            }
            else {
                if ($('#ReasonIfRejected').val() != '') {
                    StudentRegistrationAcademicApproval.ActionName = "Edit";
                    StudentRegistrationAcademicApproval.AjaxCallStudentRegistrationAcademicApproval();
                }
                else {
                    $('#diverrorreason').text("Please specify reason of rejection");
                    $('#diverrorreason').show();
                    $('#ReasonIfRejected').focus();
                }
            }

        });
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
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

        $(".ajax").colorbox();

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
             url: '/StudentRegistrationAcademicApproval/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $(".ajax").colorbox();
        parent.$.colorbox.close();
        //  var TaskCode = $('input[name=TaskCode]').val();
        var TaskCode = "SRAA";
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "TaskCode": TaskCode },
            url: '/Home/Index',
            success: function (data) {
                //Rebind Grid Data
               
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallStudentRegistrationAcademicApproval: function () {
        var StudentRegistrationAcademicApprovalData = null;
        if (StudentRegistrationAcademicApproval.ActionName == "Edit") {
            // $("#FormEditStudentRegistrationAcademicApproval").validate();
            // if ($("#FormEditStudentRegistrationAcademicApproval").valid()) {
            //  StudentRegistrationAcademicApprovalData = null;
            StudentRegistrationAcademicApprovalData = StudentRegistrationAcademicApproval.GetStudentRegistrationAcademicApproval();
            ajaxRequest.makeRequest("/StudentRegistrationAcademicApproval/Edit", "POST", StudentRegistrationAcademicApprovalData, StudentRegistrationAcademicApproval.Success);
            //}
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetStudentRegistrationAcademicApproval: function () {
        var Data = {
        };
        if (StudentRegistrationAcademicApproval.ActionName == "Edit") {
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
        else if (StudentRegistrationAcademicApproval.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        if (data != null) {
          
            StudentRegistrationAcademicApproval.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            StudentRegistrationAcademicApproval.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    colorBoxClose: function () {
        parent.$.colorbox.close();
    },

};

