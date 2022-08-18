////this class contain methods related to nationality functionality
//var ToolTemplateRegistration = {
//    //Member variables
//    ActionName: null,
//    NumberOfSemester: null,
//    SelectedIDs: null,
//    Data1: null,
//    Data2: null,
//    Data3: null,
//    Data4: null,
//    Data5: null,
//    Data6: null,
//    Data7: null,
//    Data8: null,
//    Data9: null,
//    Data10: null,

//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        ToolTemplateRegistration.constructor();
//        //generalCountryMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {


//        $("input[type=checkbox]").prop("checked", true);

//        //1 For Title
//        $('.Title').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.Title1').prop("checked", true);
//                $('.Title1').attr("disabled", false);
//            }
//            else {
//                $('.Title1').prop("checked", false);
//                $('.Title1').attr("disabled", true);
//            }
//        });

//        //2 For UploadImages
//        $('.UploadImages').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.UploadImages1').prop("checked", true);
//                $('.UploadImages1').attr("disabled", false);
//            }
//            else {
//                $('.UploadImages1').prop("checked", false);
//                $('.UploadImages1').attr("disabled", true);
//            }
//        });
//        //3 For StudentPersonalInformation
//        $('.StudentPersonalInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.StudentPersonalInformation1').prop("checked", true);
//                $('.StudentPersonalInformation1').attr("disabled", false);
//            }
//            else {
//                $('.StudentPersonalInformation1').prop("checked", false);
//                $('.StudentPersonalInformation1').attr("disabled", true);
//            }
//        });
//        //4 For Father/HusbandPersonalInformation
//        $('.FatherHusbandPersonalInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.FatherHusbandPersonalInformation1').prop("checked", true);
//                $('.FatherHusbandPersonalInformation1').attr("disabled", false);
//            }
//            else {
//                $('.FatherHusbandPersonalInformation1').prop("checked", false);
//                $('.FatherHusbandPersonalInformation1').attr("disabled", true);
//            }
//        });
//        //5 For MotherPersonalInformation
//        $('.MotherPersonalInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.MotherPersonalInformation1').prop("checked", true);
//                $('.MotherPersonalInformation1').attr("disabled", false);
//            }
//            else {
//                $('.MotherPersonalInformation1').prop("checked", false);
//                $('.MotherPersonalInformation1').attr("disabled", true);
//            }
//        });
//        //6 For GuardianPersonalInformation
//        $('.GuardianPersonalInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.GuardianPersonalInformation1').prop("checked", true);
//                $('.GuardianPersonalInformation1').attr("disabled", false);
//            }
//            else {
//                $('.GuardianPersonalInformation1').prop("checked", false);
//                $('.GuardianPersonalInformation1').attr("disabled", true);
//            }
//        });
//        //7 For StudentSpecificInformation1
//        $('.StudentSpecificInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.StudentSpecificInformation1').prop("checked", true);
//                $('.StudentSpecificInformation1').attr("disabled", false);
//            }
//            else {
//                $('.StudentSpecificInformation1').prop("checked", false);
//                $('.StudentSpecificInformation1').attr("disabled", true);
//            }
//        });
//        //8 For InformationAsperLeavingCertificate
//        $('.InformationAsperLeavingCertificate').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.InformationAsperLeavingCertificate1').prop("checked", true);
//                $('.InformationAsperLeavingCertificate1').attr("disabled", false);
//            }
//            else {
//                $('.InformationAsperLeavingCertificate1').prop("checked", false);
//                $('.InformationAsperLeavingCertificate1').attr("disabled", true);
//            }
//        });
//        //9 For SocialReservationInformation
//        $('.SocialReservationInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.SocialReservationInformation1').prop("checked", true);
//                $('.SocialReservationInformation1').attr("disabled", false);
//            }
//            else {
//                $('.SocialReservationInformation1').prop("checked", false);
//                $('.SocialReservationInformation1').attr("disabled", true);
//            }
//        });
//        //10 For OtherInformationOfThe Student
//        $('.OtherInformationOfTheStudent').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.OtherInformationOfTheStudent1').prop("checked", true);
//                $('.OtherInformationOfTheStudent1').attr("disabled", false);
//            }
//            else {
//                $('.OtherInformationOfTheStudent1').prop("checked", false);
//                $('.OtherInformationOfTheStudent1').attr("disabled", true);
//            }
//        });
//        //11 For AddressInformation
//        $('.AddressInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.PermanentAddress').prop("checked", true);
//                $('.PermanentAddress1').prop("checked", true);
//                $('.CorrespondenceAddress').prop("checked", true);
//                $('.CorrespondenceAddress1').prop("checked", true);
//                $('.PermanentAddress').attr("disabled", false);
//                $('.PermanentAddress1').attr("disabled", false);
//                $('.CorrespondenceAddress').attr("disabled", false);
//                $('.CorrespondenceAddress1').attr("disabled", false);
//            }
//            else {
//                $('.PermanentAddress').prop("checked", false);
//                $('.PermanentAddress1').prop("checked", false);
//                $('.CorrespondenceAddress').prop("checked", false);
//                $('.CorrespondenceAddress1').prop("checked", false);
//                $('.PermanentAddress').attr("disabled", true);
//                $('.PermanentAddress1').attr("disabled", true);
//                $('.CorrespondenceAddress').attr("disabled", true);
//                $('.CorrespondenceAddress1').attr("disabled", true);
//            }
//        });
//        //11.1 For PermanentAddress 
//        $('.PermanentAddress').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.PermanentAddress1').prop("checked", true);
//                $('.PermanentAddress1').attr("disabled", false);
//            }
//            else {
//                $('.PermanentAddress1').prop("checked", false);
//                $('.PermanentAddress1').attr("disabled", true);
//            }
//        });
//        //11.2 For CorrespondenceAddress 
//        $('.CorrespondenceAddress').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.CorrespondenceAddress1').prop("checked", true);
//                $('.CorrespondenceAddress1').attr("disabled", false);
//            }
//            else {
//                $('.CorrespondenceAddress1').prop("checked", false);
//                $('.CorrespondenceAddress1').attr("disabled", true);
//            }
//        });

//        //11 A For QualifyingExamDetail 
//        $('.QualifyingExamDetail').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.QualifyingExamDetail1').prop("checked", true);
//                $('.QualifyingExamDetail1').attr("disabled", false);
//            }
//            else {
//                $('.QualifyingExamDetail1').prop("checked", false);
//                $('.QualifyingExamDetail1').attr("disabled", true);
//            }
//        });

//        //12 For QualificationDetails  
//        $('.QualificationDetails').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.GeneralDetails').prop("checked", true);
//                $('.GeneralDetails').attr("disabled", false);
//                $('.GeneralDetails1').prop("checked", true);
//                $('.GeneralDetails1').attr("disabled", false);

//                $('.SSCDetails').prop("checked", true);
//                $('.SSCDetails').attr("disabled", false);
//                $('.SSCDetails1').prop("checked", true);
//                $('.SSCDetails1').attr("disabled", false);

//                $('.HSCDetails').prop("checked", true);
//                $('.HSCDetails').attr("disabled", false);
//                $('.HSCDetails1').prop("checked", true);
//                $('.HSCDetails1').attr("disabled", false);

//                $('.DiplomaITIDetails').prop("checked", true);
//                $('.DiplomaITIDetails').attr("disabled", false);
//                $('.DiplomaITIDetails1').prop("checked", true);
//                $('.DiplomaITIDetails1').attr("disabled", false);

//                $('.DegreeDetails').prop("checked", true);
//                $('.DegreeDetails').attr("disabled", false);
//                $('.DegreeDetails1').prop("checked", true);
//                $('.DegreeDetails1').attr("disabled", false);

//                $('.PostGraduationDetails').prop("checked", true);
//                $('.PostGraduationDetails').attr("disabled", false);
//                $('.PostGraduationDetails1').prop("checked", true);
//                $('.PostGraduationDetails1').attr("disabled", false);


//            }
//            else {
//                $('.GeneralDetails').prop("checked", false);
//                $('.GeneralDetails').attr("disabled", true);
//                $('.GeneralDetails1').prop("checked", false);
//                $('.GeneralDetails1').attr("disabled", true);

//                $('.SSCDetails').prop("checked", false);
//                $('.SSCDetails').attr("disabled", true);
//                $('.SSCDetails1').prop("checked", false);
//                $('.SSCDetails1').attr("disabled", true);

//                $('.HSCDetails').prop("checked", false);
//                $('.HSCDetails').attr("disabled", true);
//                $('.HSCDetails1').prop("checked", false);
//                $('.HSCDetails1').attr("disabled", true);

//                $('.DiplomaITIDetails').prop("checked", false);
//                $('.DiplomaITIDetails').attr("disabled", true);
//                $('.DiplomaITIDetails1').prop("checked", false);
//                $('.DiplomaITIDetails1').attr("disabled", true);

//                $('.DegreeDetails').prop("checked", false);
//                $('.DegreeDetails').attr("disabled", true);
//                $('.DegreeDetails1').prop("checked", false);
//                $('.DegreeDetails1').attr("disabled", true);

//                $('.PostGraduationDetails').prop("checked", false);
//                $('.PostGraduationDetails').attr("disabled", true);
//                $('.PostGraduationDetails1').prop("checked", false);
//                $('.PostGraduationDetails1').attr("disabled", true);
//            }
//        });

//        //12.0   GeneralDetails
//        $('.GeneralDetails').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.GeneralDetails1').prop("checked", true);
//                $('.GeneralDetails1').attr("disabled", false);
//            }
//            else {
//                $('.GeneralDetails1').prop("checked", false);
//                $('.GeneralDetails1').attr("disabled", true);
//            }
//        });
//        //12.1   SSCDetails
//        $('.SSCDetails').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.SSCDetails1').prop("checked", true);
//                $('.SSCDetails1').attr("disabled", false);
//            }
//            else {
//                $('.SSCDetails1').prop("checked", false);
//                $('.SSCDetails1').attr("disabled", true);
//            }
//        });
//        //12.2   HSCDetails
//        $('.HSCDetails').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.HSCDetails1').prop("checked", true);
//                $('.HSCDetails1').attr("disabled", false);
//            }
//            else {
//                $('.HSCDetails1').prop("checked", false);
//                $('.HSCDetails1').attr("disabled", true);
//            }
//        });
//        //12.3   DiplomaITIDetails
//        $('.DiplomaITIDetails').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.DiplomaITIDetails1').prop("checked", true);
//                $('.DiplomaITIDetails1').attr("disabled", false);
//            }
//            else {
//                $('.DiplomaITIDetails1').prop("checked", false);
//                $('.DiplomaITIDetails1').attr("disabled", true);
//            }
//        });
//        //12.4   DegreeDetails 
//        $('.DegreeDetails').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.DegreeDetails1').prop("checked", true);
//                $('.DegreeDetails1').attr("disabled", false);
//            }
//            else {
//                $('.DegreeDetails1').prop("checked", false);
//                $('.DegreeDetails1').attr("disabled", true);
//            }
//        });
//        //12.5  PostGraduationDetails
//        $('.PostGraduationDetails').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.PostGraduationDetails1').prop("checked", true);
//                $('.PostGraduationDetails1').attr("disabled", false);
//            }
//            else {
//                $('.PostGraduationDetails1').prop("checked", false);
//                $('.PostGraduationDetails1').attr("disabled", true);
//            }
//        });
//        //13 For DTEScholarshipInformation
//        $('.DTEScholarshipInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.DTEInformation').prop("checked", true);
//                $('.DTEInformation1').prop("checked", true);
//                $('.ScholarshipInformation').prop("checked", true);
//                $('.ScholarshipInformation1').prop("checked", true);
//                $('.DTEInformation').attr("disabled", false);
//                $('.DTEInformation1').attr("disabled", false);
//                $('.ScholarshipInformation').attr("disabled", false);
//                $('.ScholarshipInformation1').attr("disabled", false);
//            }
//            else {
//                $('.DTEInformation').prop("checked", false);
//                $('.DTEInformation1').prop("checked", false);
//                $('.ScholarshipInformation').prop("checked", false);
//                $('.ScholarshipInformation1').prop("checked", false);
//                $('.DTEInformation').attr("disabled", true);
//                $('.DTEInformation1').attr("disabled", true);
//                $('.ScholarshipInformation').attr("disabled", true);
//                $('.ScholarshipInformation1').attr("disabled", true);
//            }
//        });
//        //13.1 For   DTEInformation
//        $('.DTEInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.DTEInformation1').prop("checked", true);
//                $('.DTEInformation1').attr("disabled", false);
//            }
//            else {
//                $('.DTEInformation1').prop("checked", false);
//                $('.DTEInformation1').attr("disabled", true);
//            }
//        });
//        //13.2 For ScholarshipInformation 
//        $('.ScholarshipInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.ScholarshipInformation1').prop("checked", true);
//                $('.ScholarshipInformation1').attr("disabled", false);
//            }
//            else {
//                $('.ScholarshipInformation1').prop("checked", false);
//                $('.ScholarshipInformation1').attr("disabled", true);
//            }
//        });

//        //14 For StudentDocumentsInformation   
//        $('.StudentDocumentsInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.AdmissionDocumentsInformation').prop("checked", true);
//                $('.AdmissionDocumentsInformation').attr("disabled", false);
//                $('.AdmissionDocumentsInformation1').prop("checked", true);
//                $('.AdmissionDocumentsInformation1').attr("disabled", false);

//                $('.PGStudents').prop("checked", true);
//                $('.PGStudents').attr("disabled", false);
//                $('.PGStudents1').prop("checked", true);
//                $('.PGStudents1').attr("disabled", false);

//                $('.Comments').prop("checked", true);
//                $('.Comments').attr("disabled", false);


//                $('.ScholarshipDocumentsInformation').prop("checked", true);
//                $('.ScholarshipDocumentsInformation').attr("disabled", false);
//                $('.ScholarshipDocumentsInformation1').prop("checked", true);
//                $('.ScholarshipDocumentsInformation1').attr("disabled", false);

//                $('.IfApplicable').prop("checked", true);
//                $('.IfApplicable').attr("disabled", false);
//                $('.IfApplicable1').prop("checked", true);
//                $('.IfApplicable1').attr("disabled", false);


//            }
//            else {
//                $('.AdmissionDocumentsInformation').prop("checked", false);
//                $('.AdmissionDocumentsInformation').attr("disabled", true);
//                $('.AdmissionDocumentsInformation1').prop("checked", false);
//                $('.AdmissionDocumentsInformation1').attr("disabled", true);

//                $('.PGStudents').prop("checked", false);
//                $('.PGStudents').attr("disabled", true);
//                $('.PGStudents1').prop("checked", false);
//                $('.PGStudents1').attr("disabled", true);

//                $('.Comments').prop("checked", false);
//                $('.Comments').attr("disabled", true);


//                $('.ScholarshipDocumentsInformation').prop("checked", false);
//                $('.ScholarshipDocumentsInformation').attr("disabled", true);
//                $('.ScholarshipDocumentsInformation1').prop("checked", false);
//                $('.ScholarshipDocumentsInformation1').attr("disabled", true);

//                $('.IfApplicable').prop("checked", false);
//                $('.IfApplicable').attr("disabled", true);
//                $('.IfApplicable1').prop("checked", false);
//                $('.IfApplicable1').attr("disabled", true);
//            }
//        });
//        //14.1   AdmissionDocumentsInformation 
//        $('.AdmissionDocumentsInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.AdmissionDocumentsInformation1').prop("checked", true);
//                $('.AdmissionDocumentsInformation1').attr("disabled", false);
//            }
//            else {
//                $('.AdmissionDocumentsInformation1').prop("checked", false);
//                $('.AdmissionDocumentsInformation1').attr("disabled", true);
//            }
//        });
//        //12.2   For PGStudents
//        $('.PGStudents').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.PGStudents1').prop("checked", true);
//                $('.PGStudents1').attr("disabled", false);
//            }
//            else {
//                $('.PGStudents1').prop("checked", false);
//                $('.PGStudents1').attr("disabled", true);
//            }
//        });
//        //12.3   ScholarshipDocumentsInformation
//        $('.ScholarshipDocumentsInformation').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.ScholarshipDocumentsInformation1').prop("checked", true);
//                $('.ScholarshipDocumentsInformation1').attr("disabled", false);
//            }
//            else {
//                $('.ScholarshipDocumentsInformation1').prop("checked", false);
//                $('.ScholarshipDocumentsInformation1').attr("disabled", true);
//            }
//        });
//        //12.4   IfApplicable 
//        $('.IfApplicable').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.IfApplicable1').prop("checked", true);
//                $('.IfApplicable1').attr("disabled", false);
//            }
//            else {
//                $('.IfApplicable1').prop("checked", false);
//                $('.IfApplicable1').attr("disabled", true);
//            }
//        });

//        $('.DegreeSynopsis').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.DegreeSynopsis1').prop("checked", true);
//                $('.DegreeSynopsis1').attr("disabled", false);
//            }
//            else {
//                $('.DegreeSynopsis1').prop("checked", false);
//                $('.DegreeSynopsis1').attr("disabled", true);
//            }
//        });
//        $('.WorkExperience').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.WorkExperience1').prop("checked", true);
//                $('.WorkExperience1').attr("disabled", false);
//            }
//            else {
//                $('.WorkExperience1').prop("checked", false);
//                $('.WorkExperience1').attr("disabled", true);
//            }
//        }); 
//        $('.FeesDetails').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $('.FeesDetails1').prop("checked", true);
//                $('.FeesDetails1').attr("disabled", false);
//            }
//            else {
//                $('.FeesDetails1').prop("checked", false);
//                $('.FeesDetails1').attr("disabled", true);
//            }
//        });

//        // Create new record
//        $('#CreateToolTemplateRegistrationRecord').on("click", function () {
//            ToolTemplateRegistration.ActionName = "Create";
//            // getValueUsingClass();
        
//            /* Get the checkboxes values based on the parent div id */

//            if ($('#TemplateName').val() != "" && $('#TemplateName').val() != null) {
//                ToolTemplateRegistration.getValueUsingParentTag_Check_UnCheck();
//                if (ToolTemplateRegistration.SelectedIDs != "") {
//                    ToolTemplateRegistration.AjaxCallToolTemplateRegistration();
//                }
//            }
//            else {
//                alert("Please enter template name");
//                //$('#DivSuccessMessage').html("Please enter template name");
//                //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
//            }
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();


//    },



//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/ToolTemplateRegistration/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": actionMode },
//            url: '/ToolTemplateRegistration/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallToolTemplateRegistration: function () {
//        var ToolTemplateRegistrationData = null;
//        if (ToolTemplateRegistration.ActionName == "Create") {
//            $("#FormCreateToolTemplateRegistration").validate();
//            if ($("#FormCreateToolTemplateRegistration").valid()) {
//                ToolTemplateRegistrationData = null;
//                ToolTemplateRegistrationData = ToolTemplateRegistration.GetToolTemplateRegistration();

//                ajaxRequest.makeRequest("/ToolTemplateRegistration/Create", "POST", ToolTemplateRegistrationData, ToolTemplateRegistration.createSuccess);
//            }


//        }
//        else if (ToolTemplateRegistration.ActionName == "Edit") {
//            $("#FormEditToolTemplateRegistration").validate();
//            if ($("#FormEditToolTemplateRegistration").valid()) {
//                ToolTemplateRegistrationData = null;

//                ToolTemplateRegistrationData = ToolTemplateRegistration.GetToolTemplateRegistration();
            
//                ajaxRequest.makeRequest("/ToolTemplateRegistration/Edit", "POST", ToolTemplateRegistrationData, ToolTemplateRegistration.editSuccess);

//            }
//        }
//        else if (ToolTemplateRegistration.ActionName == "Delete") {
//            ToolTemplateRegistrationData = null;
//            //$("#FormCreateToolTemplateRegistration").validate();
//            ToolTemplateRegistrationData = ToolTemplateRegistration.GetToolTemplateRegistration();
//            ajaxRequest.makeRequest("/ToolTemplateRegistration/Delete", "POST", ToolTemplateRegistrationData, ToolTemplateRegistration.deleteSuccess);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetToolTemplateRegistration: function () {
    
//        var Data = {
//        };
//        if (ToolTemplateRegistration.ActionName == "Create" || ToolTemplateRegistration.ActionName == "Edit") {
        
//            // Data.ID = $('input[name=ID]').val();
//            Data.TemplateName = $('#TemplateName').val();
//            Data.Data1 = ToolTemplateRegistration.SelectedIDs.substring(0, 3900);
//            Data.Data2 = ToolTemplateRegistration.SelectedIDs.substring(3900, 7800);
//            Data.Data3 = ToolTemplateRegistration.SelectedIDs.substring(7800, 11700);
//            Data.Data4 = ToolTemplateRegistration.SelectedIDs.substring(11700, 15600);
//            Data.Data5 = ToolTemplateRegistration.SelectedIDs.substring(15600, 19500);
//            Data.Data6 = ToolTemplateRegistration.SelectedIDs.substring(19500, 23400);
//            Data.Data7 = ToolTemplateRegistration.SelectedIDs.substring(23400, 27300);
//            Data.Data8 = ToolTemplateRegistration.SelectedIDs.substring(27300, 31200);
//            Data.Data9 = ToolTemplateRegistration.SelectedIDs.substring(31200, 35100);
//            Data.Data10 = ToolTemplateRegistration.SelectedIDs.substring(35100, 39000);
//            //alert(Data.Data1); alert(Data.Data2); alert(Data.Data3); alert(Data.Data4); alert(Data.Data5);
//            //alert(Data.Data6); alert(Data.Data7); alert(Data.Data8); alert(Data.Data9); alert(Data.Data10);
//        }
//        return Data;
//    },


//    getValueUsingParentTag_Check_UnCheck: function () {
//        var sList = "";
//        var xmlParamList = "<rows>"
//        $('#checkboxlist input[type=checkbox]').each(function () {
//            if ($(this).val() != "on") {
//                var sArray = [];
//                var bbb, aaa, ccc;
//                ccc = $(this).val() + '-ToolRegMstID';
//                aaa = $('#' + ccc).val();
//                bbb = ($(this).val() + "~" + aaa);
//                sArray = bbb.split("~");

//                if (this.checked == true) {
//                    //xmlInsert code here
//                    if (sArray[1] != "" && sArray[1] != null) {
//                        xmlParamList = xmlParamList + "<row>" + "<RegMstID>" + sArray[0] + "</RegMstID>" + "<Status>1</Status>" + "<Title>" + sArray[1] + "</Title>" + "</row>";
//                    }
//                    else {
//                        xmlParamList = "";
//                        alert("Each title must be fill.");
//                        return false;
//                    }
//                }
//                else {
//                    if (sArray[1] != "" && sArray[1] != null) {
//                        //xmlInsert code here
//                        xmlParamList = xmlParamList + "<row>" + "<RegMstID>" + sArray[0] + "</RegMstID>" + "<Status>0</Status>" + "<Title>" + sArray[1] + "</Title>" + "</row>";
//                    }
//                    else {
//                        xmlParamList = "";
//                        alert("Each title must be fill.");
//                        return false;
//                    }
//                }
//            }

//        });
    
//        if (xmlParamList == "") {
//            ToolTemplateRegistration.SelectedIDs = "";
//        }
//        else {
//            // xmlParamList = xmlParamList.replace("&", "And");
//            ToolTemplateRegistration.SelectedIDs = xmlParamList.replace("&", "And").toString() + "</rows>";
//        }
       
//       // alert(ToolTemplateRegistration.SelectedIDs.length)
//        //  var Data1, Data2, Data3, Data4, Data5, Data6, Data7, Data8, Data9, Data10;

//        //Data1 = ToolTemplateRegistration.SelectedIDs.substring(0, 3900);
//        //Data2 = ToolTemplateRegistration.SelectedIDs.substring(3900, 7800);
//        //Data3 = ToolTemplateRegistration.SelectedIDs.substring(7800, 11700);
//        //Data4 = ToolTemplateRegistration.SelectedIDs.substring(11700, 15600);
//        //Data5 = ToolTemplateRegistration.SelectedIDs.substring(15600, 19500);
//        //Data6 = ToolTemplateRegistration.SelectedIDs.substring(19500, 23400);
//        //Data7 = ToolTemplateRegistration.SelectedIDs.substring(23400, 27300);
//        //Data8 = ToolTemplateRegistration.SelectedIDs.substring(27300, 31200);
//        //Data9 = ToolTemplateRegistration.SelectedIDs.substring(31200, 35100);
//        //Data10 = ToolTemplateRegistration.SelectedIDs.substring(35100, 39000);
//        // alert(Data1); alert(Data2); alert(Data3); alert(Data4); alert(Data5);
//        //alert(Data6); alert(Data7); alert(Data8); alert(Data9); alert(Data10);
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    createSuccess: function (data) {
    
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            ToolTemplateRegistration.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            ToolTemplateRegistration.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//};

///////////////new js////////////////////////


//this class contain methods related to nationality functionality
var ToolTemplateRegistration = {
    //Member variables
    ActionName: null,
    NumberOfSemester: null,
    SelectedIDs: null,
    Data1: null,
    Data2: null,
    Data3: null,
    Data4: null,
    Data5: null,
    Data6: null,
    Data7: null,
    Data8: null,
    Data9: null,
    Data10: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ToolTemplateRegistration.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {


        $("input[type=checkbox]").prop("checked", true);

        //1 For Title
        $('.Title').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.Title1').prop("checked", true);
                $('.Title1').attr("disabled", false);
            }
            else {
                $('.Title1').prop("checked", false);
                $('.Title1').attr("disabled", true);
            }
        });

        //2 For UploadImages
        $('.UploadImages').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.UploadImages1').prop("checked", true);
                $('.UploadImages1').attr("disabled", false);
            }
            else {
                $('.UploadImages1').prop("checked", false);
                $('.UploadImages1').attr("disabled", true);
            }
        });
        //3 For StudentPersonalInformation
        $('.StudentPersonalInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.StudentPersonalInformation1').prop("checked", true);
                $('.StudentPersonalInformation1').attr("disabled", false);
            }
            else {
                $('.StudentPersonalInformation1').prop("checked", false);
                $('.StudentPersonalInformation1').attr("disabled", true);
            }
        });
        //4 For Father/HusbandPersonalInformation
        $('.FatherHusbandPersonalInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.FatherHusbandPersonalInformation1').prop("checked", true);
                $('.FatherHusbandPersonalInformation1').attr("disabled", false);
            }
            else {
                $('.FatherHusbandPersonalInformation1').prop("checked", false);
                $('.FatherHusbandPersonalInformation1').attr("disabled", true);
            }
        });
        //5 For MotherPersonalInformation
        $('.MotherPersonalInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.MotherPersonalInformation1').prop("checked", true);
                $('.MotherPersonalInformation1').attr("disabled", false);
            }
            else {
                $('.MotherPersonalInformation1').prop("checked", false);
                $('.MotherPersonalInformation1').attr("disabled", true);
            }
        });
        //6 For GuardianPersonalInformation
        $('.GuardianPersonalInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.GuardianPersonalInformation1').prop("checked", true);
                $('.GuardianPersonalInformation1').attr("disabled", false);
            }
            else {
                $('.GuardianPersonalInformation1').prop("checked", false);
                $('.GuardianPersonalInformation1').attr("disabled", true);
            }
        });
        //7 For StudentSpecificInformation1
        $('.StudentSpecificInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.StudentSpecificInformation1').prop("checked", true);
                $('.StudentSpecificInformation1').attr("disabled", false);
            }
            else {
                $('.StudentSpecificInformation1').prop("checked", false);
                $('.StudentSpecificInformation1').attr("disabled", true);
            }
        });
        //8 For InformationAsperLeavingCertificate
        $('.InformationAsperLeavingCertificate').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.InformationAsperLeavingCertificate1').prop("checked", true);
                $('.InformationAsperLeavingCertificate1').attr("disabled", false);
            }
            else {
                $('.InformationAsperLeavingCertificate1').prop("checked", false);
                $('.InformationAsperLeavingCertificate1').attr("disabled", true);
            }
        });
        //9 For SocialReservationInformation
        $('.SocialReservationInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.SocialReservationInformation1').prop("checked", true);
                $('.SocialReservationInformation1').attr("disabled", false);
            }
            else {
                $('.SocialReservationInformation1').prop("checked", false);
                $('.SocialReservationInformation1').attr("disabled", true);
            }
        });
        //10 For OtherInformationOfThe Student
        $('.OtherInformationOfTheStudent').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.OtherInformationOfTheStudent1').prop("checked", true);
                $('.OtherInformationOfTheStudent1').attr("disabled", false);
            }
            else {
                $('.OtherInformationOfTheStudent1').prop("checked", false);
                $('.OtherInformationOfTheStudent1').attr("disabled", true);
            }
        });
        //11 For AddressInformation
        $('.AddressInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.PermanentAddress').prop("checked", true);
                $('.PermanentAddress1').prop("checked", true);
                $('.CorrespondenceAddress').prop("checked", true);
                $('.CorrespondenceAddress1').prop("checked", true);
                $('.PermanentAddress').attr("disabled", false);
                $('.PermanentAddress1').attr("disabled", false);
                $('.CorrespondenceAddress').attr("disabled", false);
                $('.CorrespondenceAddress1').attr("disabled", false);
            }
            else {
                $('.PermanentAddress').prop("checked", false);
                $('.PermanentAddress1').prop("checked", false);
                $('.CorrespondenceAddress').prop("checked", false);
                $('.CorrespondenceAddress1').prop("checked", false);
                $('.PermanentAddress').attr("disabled", true);
                $('.PermanentAddress1').attr("disabled", true);
                $('.CorrespondenceAddress').attr("disabled", true);
                $('.CorrespondenceAddress1').attr("disabled", true);
            }
        });
        //11.1 For PermanentAddress 
        $('.PermanentAddress').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.PermanentAddress1').prop("checked", true);
                $('.PermanentAddress1').attr("disabled", false);
            }
            else {
                $('.PermanentAddress1').prop("checked", false);
                $('.PermanentAddress1').attr("disabled", true);
            }
        });
        //11.2 For CorrespondenceAddress 
        $('.CorrespondenceAddress').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.CorrespondenceAddress1').prop("checked", true);
                $('.CorrespondenceAddress1').attr("disabled", false);
            }
            else {
                $('.CorrespondenceAddress1').prop("checked", false);
                $('.CorrespondenceAddress1').attr("disabled", true);
            }
        });

        //11 A For QualifyingExamDetail 
        $('.QualifyingExamDetail').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.QualifyingExamDetail1').prop("checked", true);
                $('.QualifyingExamDetail1').attr("disabled", false);
            }
            else {
                $('.QualifyingExamDetail1').prop("checked", false);
                $('.QualifyingExamDetail1').attr("disabled", true);
            }
        });

        //12 For QualificationDetails  
        $('.QualificationDetails').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.GeneralDetails').prop("checked", true);
                $('.GeneralDetails').attr("disabled", false);
                $('.GeneralDetails1').prop("checked", true);
                $('.GeneralDetails1').attr("disabled", false);

                $('.SSCDetails').prop("checked", true);
                $('.SSCDetails').attr("disabled", false);
                $('.SSCDetails1').prop("checked", true);
                $('.SSCDetails1').attr("disabled", false);

                $('.HSCDetails').prop("checked", true);
                $('.HSCDetails').attr("disabled", false);
                $('.HSCDetails1').prop("checked", true);
                $('.HSCDetails1').attr("disabled", false);

                $('.DiplomaITIDetails').prop("checked", true);
                $('.DiplomaITIDetails').attr("disabled", false);
                $('.DiplomaITIDetails1').prop("checked", true);
                $('.DiplomaITIDetails1').attr("disabled", false);

                $('.DegreeDetails').prop("checked", true);
                $('.DegreeDetails').attr("disabled", false);
                $('.DegreeDetails1').prop("checked", true);
                $('.DegreeDetails1').attr("disabled", false);

                $('.PostGraduationDetails').prop("checked", true);
                $('.PostGraduationDetails').attr("disabled", false);
                $('.PostGraduationDetails1').prop("checked", true);
                $('.PostGraduationDetails1').attr("disabled", false);


            }
            else {
                $('.GeneralDetails').prop("checked", false);
                $('.GeneralDetails').attr("disabled", true);
                $('.GeneralDetails1').prop("checked", false);
                $('.GeneralDetails1').attr("disabled", true);

                $('.SSCDetails').prop("checked", false);
                $('.SSCDetails').attr("disabled", true);
                $('.SSCDetails1').prop("checked", false);
                $('.SSCDetails1').attr("disabled", true);

                $('.HSCDetails').prop("checked", false);
                $('.HSCDetails').attr("disabled", true);
                $('.HSCDetails1').prop("checked", false);
                $('.HSCDetails1').attr("disabled", true);

                $('.DiplomaITIDetails').prop("checked", false);
                $('.DiplomaITIDetails').attr("disabled", true);
                $('.DiplomaITIDetails1').prop("checked", false);
                $('.DiplomaITIDetails1').attr("disabled", true);

                $('.DegreeDetails').prop("checked", false);
                $('.DegreeDetails').attr("disabled", true);
                $('.DegreeDetails1').prop("checked", false);
                $('.DegreeDetails1').attr("disabled", true);

                $('.PostGraduationDetails').prop("checked", false);
                $('.PostGraduationDetails').attr("disabled", true);
                $('.PostGraduationDetails1').prop("checked", false);
                $('.PostGraduationDetails1').attr("disabled", true);
            }
        });

        //12.0   GeneralDetails
        $('.GeneralDetails').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.GeneralDetails1').prop("checked", true);
                $('.GeneralDetails1').attr("disabled", false);
            }
            else {
                $('.GeneralDetails1').prop("checked", false);
                $('.GeneralDetails1').attr("disabled", true);
            }
        });
        //12.1   SSCDetails
        $('.SSCDetails').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.SSCDetails1').prop("checked", true);
                $('.SSCDetails1').attr("disabled", false);
            }
            else {
                $('.SSCDetails1').prop("checked", false);
                $('.SSCDetails1').attr("disabled", true);
            }
        });
        //12.2   HSCDetails
        $('.HSCDetails').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.HSCDetails1').prop("checked", true);
                $('.HSCDetails1').attr("disabled", false);
            }
            else {
                $('.HSCDetails1').prop("checked", false);
                $('.HSCDetails1').attr("disabled", true);
            }
        });
        //12.3   DiplomaITIDetails
        $('.DiplomaITIDetails').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.DiplomaITIDetails1').prop("checked", true);
                $('.DiplomaITIDetails1').attr("disabled", false);
            }
            else {
                $('.DiplomaITIDetails1').prop("checked", false);
                $('.DiplomaITIDetails1').attr("disabled", true);
            }
        });
        //12.4   DegreeDetails 
        $('.DegreeDetails').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.DegreeDetails1').prop("checked", true);
                $('.DegreeDetails1').attr("disabled", false);
            }
            else {
                $('.DegreeDetails1').prop("checked", false);
                $('.DegreeDetails1').attr("disabled", true);
            }
        });
        //12.5  PostGraduationDetails
        $('.PostGraduationDetails').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.PostGraduationDetails1').prop("checked", true);
                $('.PostGraduationDetails1').attr("disabled", false);
            }
            else {
                $('.PostGraduationDetails1').prop("checked", false);
                $('.PostGraduationDetails1').attr("disabled", true);
            }
        });
        //13 For DTEScholarshipInformation
        $('.DTEScholarshipInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.DTEInformation').prop("checked", true);
                $('.DTEInformation1').prop("checked", true);
                $('.ScholarshipInformation').prop("checked", true);
                $('.ScholarshipInformation1').prop("checked", true);
                $('.DTEInformation').attr("disabled", false);
                $('.DTEInformation1').attr("disabled", false);
                $('.ScholarshipInformation').attr("disabled", false);
                $('.ScholarshipInformation1').attr("disabled", false);
            }
            else {
                $('.DTEInformation').prop("checked", false);
                $('.DTEInformation1').prop("checked", false);
                $('.ScholarshipInformation').prop("checked", false);
                $('.ScholarshipInformation1').prop("checked", false);
                $('.DTEInformation').attr("disabled", true);
                $('.DTEInformation1').attr("disabled", true);
                $('.ScholarshipInformation').attr("disabled", true);
                $('.ScholarshipInformation1').attr("disabled", true);
            }
        });
        //13.1 For   DTEInformation
        $('.DTEInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.DTEInformation1').prop("checked", true);
                $('.DTEInformation1').attr("disabled", false);
            }
            else {
                $('.DTEInformation1').prop("checked", false);
                $('.DTEInformation1').attr("disabled", true);
            }
        });
        //13.2 For ScholarshipInformation 
        $('.ScholarshipInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.ScholarshipInformation1').prop("checked", true);
                $('.ScholarshipInformation1').attr("disabled", false);
            }
            else {
                $('.ScholarshipInformation1').prop("checked", false);
                $('.ScholarshipInformation1').attr("disabled", true);
            }
        });

        //14 For StudentDocumentsInformation   
        $('.StudentDocumentsInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.AdmissionDocumentsInformation').prop("checked", true);
                $('.AdmissionDocumentsInformation').attr("disabled", false);
                $('.AdmissionDocumentsInformation1').prop("checked", true);
                $('.AdmissionDocumentsInformation1').attr("disabled", false);

                $('.PGStudents').prop("checked", true);
                $('.PGStudents').attr("disabled", false);
                $('.PGStudents1').prop("checked", true);
                $('.PGStudents1').attr("disabled", false);

                $('.Comments').prop("checked", true);
                $('.Comments').attr("disabled", false);


                $('.ScholarshipDocumentsInformation').prop("checked", true);
                $('.ScholarshipDocumentsInformation').attr("disabled", false);
                $('.ScholarshipDocumentsInformation1').prop("checked", true);
                $('.ScholarshipDocumentsInformation1').attr("disabled", false);

                $('.IfApplicable').prop("checked", true);
                $('.IfApplicable').attr("disabled", false);
                $('.IfApplicable1').prop("checked", true);
                $('.IfApplicable1').attr("disabled", false);


            }
            else {
                $('.AdmissionDocumentsInformation').prop("checked", false);
                $('.AdmissionDocumentsInformation').attr("disabled", true);
                $('.AdmissionDocumentsInformation1').prop("checked", false);
                $('.AdmissionDocumentsInformation1').attr("disabled", true);

                $('.PGStudents').prop("checked", false);
                $('.PGStudents').attr("disabled", true);
                $('.PGStudents1').prop("checked", false);
                $('.PGStudents1').attr("disabled", true);

                $('.Comments').prop("checked", false);
                $('.Comments').attr("disabled", true);


                $('.ScholarshipDocumentsInformation').prop("checked", false);
                $('.ScholarshipDocumentsInformation').attr("disabled", true);
                $('.ScholarshipDocumentsInformation1').prop("checked", false);
                $('.ScholarshipDocumentsInformation1').attr("disabled", true);

                $('.IfApplicable').prop("checked", false);
                $('.IfApplicable').attr("disabled", true);
                $('.IfApplicable1').prop("checked", false);
                $('.IfApplicable1').attr("disabled", true);
            }
        });
        //14.1   AdmissionDocumentsInformation 
        $('.AdmissionDocumentsInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.AdmissionDocumentsInformation1').prop("checked", true);
                $('.AdmissionDocumentsInformation1').attr("disabled", false);
            }
            else {
                $('.AdmissionDocumentsInformation1').prop("checked", false);
                $('.AdmissionDocumentsInformation1').attr("disabled", true);
            }
        });
        //12.2   For PGStudents
        $('.PGStudents').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.PGStudents1').prop("checked", true);
                $('.PGStudents1').attr("disabled", false);
            }
            else {
                $('.PGStudents1').prop("checked", false);
                $('.PGStudents1').attr("disabled", true);
            }
        });
        //12.3   ScholarshipDocumentsInformation
        $('.ScholarshipDocumentsInformation').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.ScholarshipDocumentsInformation1').prop("checked", true);
                $('.ScholarshipDocumentsInformation1').attr("disabled", false);
            }
            else {
                $('.ScholarshipDocumentsInformation1').prop("checked", false);
                $('.ScholarshipDocumentsInformation1').attr("disabled", true);
            }
        });
        //12.4   IfApplicable 
        $('.IfApplicable').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.IfApplicable1').prop("checked", true);
                $('.IfApplicable1').attr("disabled", false);
            }
            else {
                $('.IfApplicable1').prop("checked", false);
                $('.IfApplicable1').attr("disabled", true);
            }
        });

        $('.DegreeSynopsis').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.DegreeSynopsis1').prop("checked", true);
                $('.DegreeSynopsis1').attr("disabled", false);
            }
            else {
                $('.DegreeSynopsis1').prop("checked", false);
                $('.DegreeSynopsis1').attr("disabled", true);
            }
        });
        $('.WorkExperience').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.WorkExperience1').prop("checked", true);
                $('.WorkExperience1').attr("disabled", false);
            }
            else {
                $('.WorkExperience1').prop("checked", false);
                $('.WorkExperience1').attr("disabled", true);
            }
        });
        $('.FeesDetails').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $('.FeesDetails1').prop("checked", true);
                $('.FeesDetails1').attr("disabled", false);
            }
            else {
                $('.FeesDetails1').prop("checked", false);
                $('.FeesDetails1').attr("disabled", true);
            }
        });

        // Create new record
        $('#CreateToolTemplateRegistrationRecord').on("click", function () {
            ToolTemplateRegistration.ActionName = "Create";
            // getValueUsingClass();

            /* Get the checkboxes values based on the parent div id */

            if ($('#TemplateName').val() != "" && $('#TemplateName').val() != null) {
                ToolTemplateRegistration.getValueUsingParentTag_Check_UnCheck();
                if (ToolTemplateRegistration.SelectedIDs != "") {
                    ToolTemplateRegistration.AjaxCallToolTemplateRegistration();
                }
            }
            else {
                alert("Please enter template name");
                //$('#DivSuccessMessage').html("Please enter template name");
                //$('#DivSuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


    },



    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/ToolTemplateRegistration/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/ToolTemplateRegistration/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallToolTemplateRegistration: function () {
        var ToolTemplateRegistrationData = null;
        if (ToolTemplateRegistration.ActionName == "Create") {
            $("#FormCreateToolTemplateRegistration").validate();
            if ($("#FormCreateToolTemplateRegistration").valid()) {
                ToolTemplateRegistrationData = null;
                ToolTemplateRegistrationData = ToolTemplateRegistration.GetToolTemplateRegistration();

                ajaxRequest.makeRequest("/ToolTemplateRegistration/Create", "POST", ToolTemplateRegistrationData, ToolTemplateRegistration.createSuccess);
            }


        }
        else if (ToolTemplateRegistration.ActionName == "Edit") {
            $("#FormEditToolTemplateRegistration").validate();
            if ($("#FormEditToolTemplateRegistration").valid()) {
                ToolTemplateRegistrationData = null;

                ToolTemplateRegistrationData = ToolTemplateRegistration.GetToolTemplateRegistration();

                ajaxRequest.makeRequest("/ToolTemplateRegistration/Edit", "POST", ToolTemplateRegistrationData, ToolTemplateRegistration.editSuccess);

            }
        }
        else if (ToolTemplateRegistration.ActionName == "Delete") {
            ToolTemplateRegistrationData = null;
            //$("#FormCreateToolTemplateRegistration").validate();
            ToolTemplateRegistrationData = ToolTemplateRegistration.GetToolTemplateRegistration();
            ajaxRequest.makeRequest("/ToolTemplateRegistration/Delete", "POST", ToolTemplateRegistrationData, ToolTemplateRegistration.deleteSuccess);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetToolTemplateRegistration: function () {

        var Data = {
        };
        if (ToolTemplateRegistration.ActionName == "Create" || ToolTemplateRegistration.ActionName == "Edit") {
            debugger
            // Data.ID = $('input[name=ID]').val();
            Data.TemplateName = $('#TemplateName').val();
            Data.Data1 = ToolTemplateRegistration.SelectedIDs.substring(0, 3900);
            Data.Data2 = ToolTemplateRegistration.SelectedIDs.substring(3900, 7800);
            Data.Data3 = ToolTemplateRegistration.SelectedIDs.substring(7800, 11700);
            Data.Data4 = ToolTemplateRegistration.SelectedIDs.substring(11700, 15600);
            Data.Data5 = ToolTemplateRegistration.SelectedIDs.substring(15600, 19500);
            Data.Data6 = ToolTemplateRegistration.SelectedIDs.substring(19500, 23400);
            Data.Data7 = ToolTemplateRegistration.SelectedIDs.substring(23400, 27300);
            Data.Data8 = ToolTemplateRegistration.SelectedIDs.substring(27300, 31200);
            Data.Data9 = ToolTemplateRegistration.SelectedIDs.substring(31200, 35100);
            Data.Data10 = ToolTemplateRegistration.SelectedIDs.substring(35100, 39000);
            //alert(Data.Data1); alert(Data.Data2); alert(Data.Data3); alert(Data.Data4); alert(Data.Data5);
            //alert(Data.Data6); alert(Data.Data7); alert(Data.Data8); alert(Data.Data9); alert(Data.Data10);
        }
        return Data;
    },


    getValueUsingParentTag_Check_UnCheck: function () {
        debugger
        var sList = "";
        var xmlParamList = "<rows>"
        $('#checkboxlist input[type=checkbox]').each(function () {
            if ($(this).val() != "on") {
                var sArray = [];
                var bbb, aaa, ccc;
                ccc = $(this).val() + '-ToolRegMstID';
                aaa = $('#' + ccc).val();
                bbb = ($(this).val() + "~" + aaa);
                sArray = bbb.split("~");

                if (this.checked == true) {
                    //xmlInsert code here
                    if (sArray[1] != "" && sArray[1] != null) {
                        xmlParamList = xmlParamList + "<row>" + "<RegMstID>" + sArray[0] + "</RegMstID>" + "<Status>1</Status>" + "<Title>" + sArray[1] + "</Title>" + "</row>";
                    }
                    else {
                        xmlParamList = "";
                        alert("Each title must be fill.");
                        return false;
                    }
                }
                else {
                    if (sArray[1] != "" && sArray[1] != null) {
                        //xmlInsert code here
                        xmlParamList = xmlParamList + "<row>" + "<RegMstID>" + sArray[0] + "</RegMstID>" + "<Status>0</Status>" + "<Title>" + sArray[1] + "</Title>" + "</row>";
                    }
                    else {
                        xmlParamList = "";
                        alert("Each title must be fill.");
                        return false;
                    }
                }
            }

        });

        if (xmlParamList == "") {
            ToolTemplateRegistration.SelectedIDs = "";
        }
        else {
            // xmlParamList = xmlParamList.replace("&", "And");
            ToolTemplateRegistration.SelectedIDs = xmlParamList.replace("&", "And").toString() + "</rows>";
        }

        // alert(ToolTemplateRegistration.SelectedIDs.length)
        //  var Data1, Data2, Data3, Data4, Data5, Data6, Data7, Data8, Data9, Data10;

        //Data1 = ToolTemplateRegistration.SelectedIDs.substring(0, 3900);
        //Data2 = ToolTemplateRegistration.SelectedIDs.substring(3900, 7800);
        //Data3 = ToolTemplateRegistration.SelectedIDs.substring(7800, 11700);
        //Data4 = ToolTemplateRegistration.SelectedIDs.substring(11700, 15600);
        //Data5 = ToolTemplateRegistration.SelectedIDs.substring(15600, 19500);
        //Data6 = ToolTemplateRegistration.SelectedIDs.substring(19500, 23400);
        //Data7 = ToolTemplateRegistration.SelectedIDs.substring(23400, 27300);
        //Data8 = ToolTemplateRegistration.SelectedIDs.substring(27300, 31200);
        //Data9 = ToolTemplateRegistration.SelectedIDs.substring(31200, 35100);
        //Data10 = ToolTemplateRegistration.SelectedIDs.substring(35100, 39000);
        // alert(Data1); alert(Data2); alert(Data3); alert(Data4); alert(Data5);
        //alert(Data6); alert(Data7); alert(Data8); alert(Data9); alert(Data10);
    },


    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            ToolTemplateRegistration.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            ToolTemplateRegistration.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

