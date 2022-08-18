//this class contain methods related to nationality functionality
var StudentRegistrationForm = {
    //Member variables
    ActionName: null,
    QualifyingExamSubjectDetailsIDs: null,
    QualificationExamSubjectGeneralDetailsIDs: null,
    QualificationExamSubjectSSCDetailsIDs: null,
    QualificationExamSubjectHSCDetailsIDs: null,
    // StudentSubmitedDocumentFlagIDs: null,
    StudentSubmitedDocumentIDs: null,
    Student_Qualification_DegreeDetails_Percent:0,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        StudentRegistrationForm.constructor();
        //StudentRegistrationForm.initializeValidation();
    },

    //Attach all event of page
    constructor: function () {

        StudentRegistrationForm.Student_Qualification_DegreeDetails_Percent = $('#Student_Qualification_DegreeDetails_Percent').val();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Title').focus();
            $('#Title').val("");
            $('#CenterCode').val("");
            $('#UniversityID').val("");
            $('#BranchDetailID').val("");
            $('#StandardNumber').val("");
            $('#AdmissionPattern').empty();


            var pass2 = document.getElementById('pass2');
            var message = document.getElementById('confirmMessage');
            var resultMessage = document.getElementById('result');
            var goodColor = "#ffffff";
            
            pass2.style.backgroundColor = goodColor;
            message.style.color = goodColor;
            message.innerHTML = "";
            resultMessage.innerHTML = "";


            return false;
        });

        $("#StudentMigrationDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'd-M-yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '1950:document.write(currentYear.getFullYear()'
        });

        //$('#StudentMigrationDate').attr("readonly", true);

        //$('#StudentMigrationDate').datetimepicker({
        //    format: 'DD MMMM YYYY',
        //    //minDate: moment({ yearRange: '1950:2013' }),
        //    //ignoreReadonly: true,

        //})
        $("#StudentDateofBirth").datepicker({
            numberOfMonths: 1,
            dateFormat: 'dd-MM-yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '1950:document.write(currentYear.getFullYear()'
        });


        /*
       assigning keyup event to password field
       so everytime user type code will execute
   */
        $("#StudentMigrationDate_Clear").click(function () {
            $('#StudentMigrationDate').val("");
        });
        $("#Password").on("keyup", (function () {
            
            $('#result').html(StudentRegistrationForm.checkStrength($('#Password').val()))
        })
        );

        // select for Caste
        $("#StudentCategoryID").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlCasteDetails = $("#StudentCasteID");
            var $CasteDetailsProgress = $("#states-loading-progress");
            $CasteDetailsProgress.show();
            if ($("#StudentCategoryID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRegistrationForm/GetCastByCategoryID",

                    data: { "SelectedCategoryID": selectedItem },
                    success: function (data) {
                        $ddlCasteDetails.html('');
                        $ddlCasteDetails.append('<option value="">--Select Caste--</option>');
                        $.each(data, function (id, option) {

                            $ddlCasteDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        //   $ddlCasteDetails.append('<option value="0">Other</option>');
                        $CasteDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Region.');
                        $CasteDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
                $('#btnCreate').hide();
            }
        });

        // select for Branch 
        $("#UniversityID").change(function () {
            var selectedItem = $(this).val();
            var $ddlBranchDetails = $("#BranchDetailID");
            var $BranchDetailsProgress = $("#states-loading-progress");
            $BranchDetailsProgress.show();
            if ($("#UniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRegistrationForm/GetBranchDetailByUniversityID",

                    data: { "SelectedUniversityID": selectedItem },
                    success: function (data) {
                        $ddlBranchDetails.html('');
                        $ddlBranchDetails.append('<option value="">--Select Branch--</option>');
                        $.each(data, function (id, option) {

                            $ddlBranchDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $BranchDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Branch.');
                        $BranchDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#BranchDetailID').find('option').remove().end().append('<option value>---Select Branch---</option>');
                $('#btnCreate').hide();
            }
        });

        // select for Region

        $("#Student_PermanentAddress_CountryId").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlRegionDetails = $("#Student_PermanentAddress_State");
            var $RegionDetailsProgress = $("#states-loading-progress");
            $RegionDetailsProgress.show();
            if ($("#Student_PermanentAddress_CountryId").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRegistrationForm/GetGeneralRegionDetailByCountryID",

                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegionDetails.html('');
                        $ddlRegionDetails.append('<option value="">--Select Region--</option>');
                        $.each(data, function (id, option) {

                            $ddlRegionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlRegionDetails.append('<option value="Other">Other</option>');
                        $RegionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Region.');
                        $RegionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
                $('#btnCreate').hide();
            }
        });

        //For City

        $("#Student_PermanentAddress_State").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlCityDetails = $("#Student_PermanentAddress_DistrictID");
            var $CityDetailsProgress = $("#states-loading-progress");
            $CityDetailsProgress.show();
            if ($("#Student_PermanentAddress_State").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRegistrationForm/GetGeneralCityByRegionID",

                    data: { "SelectedRegionID": selectedItem },
                    success: function (data) {
                        $ddlCityDetails.html('');
                        $ddlCityDetails.append('<option value="">--Select District --</option>');
                        $.each(data, function (id, option) {

                            $ddlCityDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlCityDetails.append('<option value="Other">Other</option>');
                        $CityDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        //   alert('Failed to retrieve District.');
                        $CityDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#Student_CorrespondenceAddress_State").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlCityDetails = $("#Student_CorrespondenceAddress_DistrictID");
            var $CityDetailsProgress = $("#states-loading-progress");
            $CityDetailsProgress.show();
            if ($("#Student_CorrespondenceAddress_State").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRegistrationForm/GetGeneralCityByRegionID",

                    data: { "SelectedRegionID": selectedItem },
                    success: function (data) {
                        $ddlCityDetails.html('');
                        $ddlCityDetails.append('<option value="">--Select District --</option>');
                        $.each(data, function (id, option) {

                            $ddlCityDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlCityDetails.append('<option value="Other">Other</option>');
                        $CityDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        //  alert('Failed to retrieve District.');
                        $CityDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
                $('#btnCreate').hide();
            }
        });


        $("#Student_PermanentAddress_DistrictID").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlLocationDetails = $("#Student_PermanentAddress_City_TahsilID");
            var $LocationDetailsProgress = $("#states-loading-progress");
            $LocationDetailsProgress.show();
            if ($("#Student_PermanentAddress_DistrictID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRegistrationForm/GetGeneralLocationByCityID",

                    data: { "SelectedCityID": selectedItem },
                    success: function (data) {
                        $ddlLocationDetails.html('');
                        $ddlLocationDetails.append('<option value="">--Select City --</option>');
                        $.each(data, function (id, option) {

                            $ddlLocationDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlLocationDetails.append('<option value="Other">Other</option>');
                        $LocationDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        // alert('Failed to retrieve City.');
                        $CityDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#Student_CorrespondenceAddress_DistrictID").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlLocationDetails = $("#Student_CorrespondenceAddress_City_TahsilID");
            var $LocationDetailsProgress = $("#states-loading-progress");
            $LocationDetailsProgress.show();
            if ($("#Student_CorrespondenceAddress_DistrictID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRegistrationForm/GetGeneralLocationByCityID",

                    data: { "SelectedCityID": selectedItem },
                    success: function (data) {
                        $ddlLocationDetails.html('');
                        $ddlLocationDetails.append('<option value="">--Select City --</option>');
                        $.each(data, function (id, option) {

                            $ddlLocationDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlLocationDetails.append('<option value="Other">Other</option>');
                        $LocationDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        //  alert('Failed to retrieve City.');
                        $CityDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#Student_CorrespondenceAddress_CountryId").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlRegionDetails = $("#Student_CorrespondenceAddress_State");
            var $RegionDetailsProgress = $("#states-loading-progress");
            $RegionDetailsProgress.show();
            if ($("#Student_CorrespondenceAddress_CountryId").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRegistrationForm/GetGeneralRegionDetailByCountryID",

                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegionDetails.html('');
                        $ddlRegionDetails.append('<option value="">--Select Region--</option>');
                        $.each(data, function (id, option) {

                            $ddlRegionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlRegionDetails.append('<option value="Other">Other</option>');
                        $RegionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        //alert('Failed to retrieve Region.');
                        $RegionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
                $('#btnCreate').hide();
            }
        });

        // select for Region

        $("#Student_QualifyingExamId").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlRegionDetails = $("#Student_PermanentAddress_State");
            var $RegionDetailsProgress = $("#states-loading-progress");
            $RegionDetailsProgress.show();
            if ($("#Student_QualifyingExamId").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRegistrationForm/GetGeneralRegionDetailByCountryID",

                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegionDetails.html('');
                        $ddlRegionDetails.append('<option value="">--Select Region--</option>');
                        $.each(data, function (id, option) {

                            $ddlRegionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlRegionDetails.append('<option value="Other">Other</option>');
                        $RegionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        //   alert('Failed to retrieve Region.');
                        $RegionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#RegionDetailID').find('option').remove().end().append('<option value>---Select Region---</option>');
                $('#btnCreate').hide();
            }
        });


        //$("#Student_Qualification_PostGraduationDetails_UniversityId").change(function () {
        //    
        //    var StudentUniversityId = $(this).val();
        //    if (StudentUniversityId == "Other") {
        //        $("#DivStudent_Qualification_PostGraduationDetails_UniversityNameOther").show(true);
        //        //   $("#DivStudentReligionID").hide(true);
        //    }
        //    else {
        //        $("#DivStudent_Qualification_PostGraduationDetails_UniversityNameOther").hide(true);
        //        //  $("#DivStudentReligionID").show(true);
        //    }

        //});
        //$("#Student_Qualification_DegreeDetails_UniversityId").change(function () {
        //    
        //    var StudentUniversityId = $(this).val();
        //    if (StudentUniversityId == "Other") {
        //        $("#DivStudent_Qualification_DegreeDetails_UniversityNameOther").show(true);
        //        //   $("#DivStudentReligionID").hide(true);
        //    }
        //    else {
        //        $("#DivStudent_Qualification_DegreeDetails_UniversityNameOther").hide(true);
        //        //  $("#DivStudentReligionID").show(true);
        //    }

        //});
        $("#Student_PermanentAddress_City_TahsilID").change(function () {
            
            var StudentID = $(this).val();
            if (StudentID == "Other") {
                $("#DivStudent_PermanentAddress_City_TahsilOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_PermanentAddress_City_TahsilOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });
        $("#Student_PermanentAddress_DistrictID").change(function () {
            
            var StudentReligionID = $(this).val();
            if (StudentReligionID == "Other") {
                $("#DivStudent_PermanentAddress_DistrictOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_PermanentAddress_DistrictOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });
        $("#Student_CorrespondenceAddress_City_TahsilID").change(function () {
            
            var StudentID = $(this).val();
            if (StudentID == "Other") {
                $("#DivStudent_CorrespondenceAddress_City_TahsilOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_CorrespondenceAddress_City_TahsilOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });
        $("#Student_CorrespondenceAddress_DistrictID").change(function () {
            
            var StudentReligionID = $(this).val();
            if (StudentReligionID == "Other") {
                $("#DivStudent_CorrespondenceAddress_DistrictOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_CorrespondenceAddress_DistrictOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });
        $("#Student_Qualification_Diploma_ITI_Details_State").change(function () {
            
            var StudentReligionID = $(this).val();
            if (StudentReligionID == "Other") {
                $("#DivStudent_Qualification_Diploma_ITI_Details_StateOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_Qualification_Diploma_ITI_Details_StateOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });

        $("#Student_Qualification_DegreeDetails_State").change(function () {
            
            var StudentReligionID = $(this).val();
            if (StudentReligionID == "Other") {
                $("#DivStudent_Qualification_DegreeDetails_StateOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_Qualification_DegreeDetails_StateOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });
        $("#Student_Qualification_PostGraduationDetails_State").change(function () {
            
            var StudentReligionID = $(this).val();
            if (StudentReligionID == "Other") {
                $("#DivStudent_Qualification_PostGraduationDetails_StateOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_Qualification_PostGraduationDetails_StateOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });
        $("#Student_PermanentAddress_State").change(function () {
            
            var StudentReligionID = $(this).val();
            if (StudentReligionID == "Other") {
                $("#DivStudent_PermanentAddress_StateOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_PermanentAddress_StateOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });

        $("#Student_CorrespondenceAddress_State").change(function () {
            
            var StudentReligionID = $(this).val();
            if (StudentReligionID == "Other") {
                $("#DivStudent_CorrespondenceAddress_StateOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_CorrespondenceAddress_StateOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });

        $("#StudentRegionID").change(function () {
            
            var StudentReligionID = $(this).val();
            if (StudentReligionID == "Other") {
                $("#DivStudentRegionOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudentRegionOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });

        $("#Student_Qualification_HSC_StreamID").change(function () {
            
            var StudentStreamID = $(this).val();
            if (StudentStreamID == "Other") {
                $("#DivStudent_Qualification_HSC_StreamOther").show(true);
                //   $("#DivStudentReligionID").hide(true);
            }
            else {
                $("#DivStudent_Qualification_HSC_StreamOther").hide(true);
                //  $("#DivStudentReligionID").show(true);
            }

        });
        // for Gender
        $("#Title").change(function () {
            
            var selectedTitle = $(this).val();
            if (selectedTitle == "Mr.") {
                $("#Male").prop('checked', true);
            }
            else {
                $("#Female").prop('checked', true);
            }

        });

        $("#SameAsPerPermanentAddress").change(function () {
            

            if (this.checked) {
                $("#Student_CorrespondenceAddress_PloteNo").val("");
                $("#Student_CorrespondenceAddress_StreeNo").val('');
                $("#Student_CorrespondenceAddress_Address1").val('');
                $("#Student_CorrespondenceAddress_Address2").val('');
                $("#Student_CorrespondenceAddress_CountryId").val('');
                $("#Student_CorrespondenceAddress_State").val('');
                $("#Student_CorrespondenceAddress_DistrictID").val('');
                $("#Student_CorrespondenceAddress_Tahsil").val('');
                $("#Student_CorrespondenceAddress_City_TahsilID").val('');
                $("#Student_CorrespondenceAddress_NearPoliceStation").val('');
                $("#Student_CorrespondenceAddress_City_Tahsil_Pattern").val('');
                $("#Student_CorrespondenceAddress_ZipCode").val('');
                $("#Student_CorrespondenceAddress_City_TahsilOther").val('');
                $("#Student_CorrespondenceAddress_StateOther").val('');
                $("#Student_CorrespondenceAddress_DistrictOther").val('');
                $("#Student_CorrespondenceAddress_City_TahsilName").val('');

                //$("#Student_CorrespondenceAddress_PloteNo").val($("#Student_PermanentAddress_PloteNo").val());
                //$("#Student_CorrespondenceAddress_StreeNo").val($("#Student_PermanentAddress_StreeNo").val());
                //$("#Student_CorrespondenceAddress_Address1").val($("#Student_PermanentAddress_Address1").val());
                //$("#Student_CorrespondenceAddress_Address2").val($("#Student_PermanentAddress_Address2").val());
                //$("#Student_CorrespondenceAddress_CountryId").val($("#Student_PermanentAddress_CountryId").val());
                //$("#Student_CorrespondenceAddress_State").val($("#Student_PermanentAddress_State").val());
                //$("#Student_CorrespondenceAddress_DistrictID").val($("#Student_PermanentAddress_DistrictID").val());
                //$("#Student_CorrespondenceAddress_Tahsil").val($("#Student_PermanentAddress_Tahsil").val());
                //$("#Student_CorrespondenceAddress_City_TahsilID").val($("#Student_PermanentAddress_City_TahsilID").val());
                //$("#Student_CorrespondenceAddress_NearPoliceStation").val($("#Student_PermanentAddress_NearPoliceStation").val());
                //$("#Student_CorrespondenceAddress_City_Tahsil_Pattern").val($("#Student_PermanentAddress_City_Tahsil_Pattern").val());
                //$("#Student_CorrespondenceAddress_ZipCode").val($("#Student_PermanentAddress_ZipCode").val());
               
                $('#Student_CorrespondenceAddress_PloteNo').attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_StreeNo").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_Address1").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_Address2").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_CountryId").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_State").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_DistrictID").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_Tahsil").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_City_TahsilID").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_NearPoliceStation").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_City_Tahsil_Pattern").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_ZipCode").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_City_TahsilName").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_City_TahsilOther").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_StateOther").attr("disabled", "disabled");
                $("#Student_CorrespondenceAddress_DistrictOther").attr("disabled", "disabled");



            }
            else {
                $("#Student_CorrespondenceAddress_PloteNo").val("");
                $("#Student_CorrespondenceAddress_StreeNo").val('');
                $("#Student_CorrespondenceAddress_Address1").val('');
                $("#Student_CorrespondenceAddress_Address2").val('');
                $("#Student_CorrespondenceAddress_CountryId").val('');
                $("#Student_CorrespondenceAddress_State").val('');
                $("#Student_CorrespondenceAddress_DistrictID").val('');
                $("#Student_CorrespondenceAddress_Tahsil").val('');
                $("#Student_CorrespondenceAddress_City_TahsilID").val('');
                $("#Student_CorrespondenceAddress_NearPoliceStation").val('');
                $("#Student_CorrespondenceAddress_City_Tahsil_Pattern").val('');
                $("#Student_CorrespondenceAddress_ZipCode").val('');
                $("#Student_CorrespondenceAddress_City_TahsilOther").val('');
                $("#Student_CorrespondenceAddress_StateOther").val('');
                $("#Student_CorrespondenceAddress_City_TahsilName").val('');
                  $("#Student_CorrespondenceAddress_DistrictOther").val('');

                //$("#Student_CorrespondenceAddress_City_TahsilName").val($("#Student_PermanentAddress_City_TahsilName").val());
                //$("#Student_CorrespondenceAddress_PloteNo").val($("#Student_PermanentAddress_PloteNo").val());
                //$("#Student_CorrespondenceAddress_StreeNo").val($("#Student_PermanentAddress_StreeNo").val());
                //$("#Student_CorrespondenceAddress_Address1").val($("#Student_PermanentAddress_Address1").val());
                //$("#Student_CorrespondenceAddress_Address2").val($("#Student_PermanentAddress_Address2").val());
                //$("#Student_CorrespondenceAddress_CountryId").val($("#Student_PermanentAddress_CountryId").val());
                //$("#Student_CorrespondenceAddress_State").val($("#Student_PermanentAddress_State").val());
                //$("#Student_CorrespondenceAddress_DistrictID").val($("#Student_PermanentAddress_DistrictID").val());
                //$("#Student_CorrespondenceAddress_Tahsil").val($("#Student_PermanentAddress_Tahsil").val());
                //$("#Student_CorrespondenceAddress_City_TahsilID").val($("#Student_PermanentAddress_City_TahsilID").val());
                //$("#Student_CorrespondenceAddress_NearPoliceStation").val($("#Student_PermanentAddress_NearPoliceStation").val());
                //$("#Student_CorrespondenceAddress_City_Tahsil_Pattern").val($("#Student_PermanentAddress_City_Tahsil_Pattern").val());
                //$("#Student_CorrespondenceAddress_ZipCode").val($("#Student_PermanentAddress_ZipCode").val());
                
                

                $('#Student_CorrespondenceAddress_PloteNo').removeAttr("disabled");
                $("#Student_CorrespondenceAddress_PloteNo").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_StreeNo").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_Address1").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_Address2").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_CountryId").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_State").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_DistrictID").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_Tahsil").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_City_TahsilID").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_NearPoliceStation").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_City_Tahsil_Pattern").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_ZipCode").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_City_TahsilName").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_City_TahsilOther").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_StateOther").removeAttr("disabled");
                $("#Student_CorrespondenceAddress_DistrictOther").removeAttr("disabled");
            }
        });

       
        //serachlistfor Location
        $("#Student_PermanentAddress_City_TahsilName").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/StudentRegistrationForm/GetLocationList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term, maxResults: 10, CityID: $("#SelectedCityID :selected").val(), RegionID: $("#SelectedRegionID :selected").val() }, //1 for current year student
                    //{ term: request.term, maxResults: 10, courseYearID: $("#SelectedCourseYearId :selected").val(), sectionDetailID: $("#SelectedSectionDetailID :selected").val(), SessionID: $("#SelectedAcademicYear :selected").val() }, //1 for current year student
                    success: function (data) {
                        //alert(data)
                        response($.map(data, function (item) {
                            return { label: item.LocationAddress, value: item.LocationAddress, id: item.id };

                        }))
                    }
                })
            },
            select: function (event, ui) {
                //alert(ui.item.id);
                $(this).val(ui.item.label);                                             // display the selected text
                $("#Student_PermanentAddress_City_TahsilID").val(ui.item.id);
            }
        });

        // End of serachlistfor Location
        //serachlistfor Location
        $("#Student_CorrespondenceAddress_City_TahsilName").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/StudentRegistrationForm/GetLocationList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term, maxResults: 10,CityID: $("#SelectedCityID :selected").val(), RegionID: $("#SelectedRegionID :selected").val()}, //1 for current year student
                    //{ term: request.term, maxResults: 10, courseYearID: $("#SelectedCourseYearId :selected").val(), sectionDetailID: $("#SelectedSectionDetailID :selected").val(), SessionID: $("#SelectedAcademicYear :selected").val() }, //1 for current year student
                    success: function (data) {
                        //alert(data)
                        response($.map(data, function (item) {
                            return { label: item.LocationAddress, value: item.LocationAddress, id: item.id };

                        }))
                    }
                })
            },
            select: function (event, ui) {
                //alert(ui.item.id);
                $(this).val(ui.item.label);                                             // display the selected text
                $("#Student_CorrespondenceAddress_City_TahsilID").val(ui.item.id);
            }
        });

        // End of serachlistfor Location



        //Validation For Email-Id
        $("#FatherEmailId").change(function () {
            
            var email = $("#FatherEmailId").val();
            var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
            if (!reg.test(email)) {
                alert("Please Enter Valid Father's Email ID");
                $("#FatherEmailId").val("");
                return false;
            }
        });
        $("#GuardianEmailId").change(function () {
            
            var email = $("#GuardianEmailId").val();
            var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
            if (!reg.test(email)) {
                alert("Please Enter Valid Guardian's Email ID");
                $("#GuardianEmailId").val("");
                return false;
            }
        });
        $("#MotherEmailId").change(function () {
            
            var email = $("#MotherEmailId").val();
            var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
            if (!reg.test(email)) {
                alert("Please Enter Valid Mother's Email ID");
                $("#MotherEmailId").val("");
                return false;
            }
        });



        //For Qualifying Exam
        $("#Student_QualifyingExamOutOffMark").change(function () {
            
            var ObtainedMark = (parseInt($("#Student_QualifyingExamTotalMarksPointsObtained").val()));
            var OutOfMark = (parseInt($("#Student_QualifyingExamOutOffMark").val()));
            if (ObtainedMark > OutOfMark) {
                //var result_num = parseFloat((ObtainedMark / OutOfMark) * 100);
                //$('#Student_Qualification_General_Percent').val(result_num);
                alert("Obtained mark is always less than out of mark");
                $("#Student_QualifyingExamTotalMarksPointsObtained").val('');
                $("#Student_QualifyingExamOutOffMark").val('');
            }
            else {
                //$("#Student_Qualification_General_Percent").val('');
            }
        });


        //Calculate the percentage

        //For Genral
        $("#Student_Qualification_General_OutOfMark").change(function () {
            
            var ObtainedMark = (parseInt($("#Student_Qualification_General_ObtainedMark").val()));
            var OutOfMark = (parseInt($("#Student_Qualification_General_OutOfMark").val()));
            if (ObtainedMark < OutOfMark) {
                var result_num = parseFloat((ObtainedMark / OutOfMark) * 100);
                $('#Student_Qualification_General_Percent').val(result_num);
            }
            else {
                alert("Obtained mark is always less than out of mark");
                $("#Student_Qualification_General_ObtainedMark").val('');
                $("#Student_Qualification_General_OutOfMark").val('');
                $("#Student_Qualification_General_Percent").val('');
            }
        });
        // For SSC
        $("#Student_Qualification_SSC_OutOfMark").change(function () {
            
            var ObtainedMark = (parseInt($("#Student_Qualification_SSC_ObtainedMark").val()));
            var OutOfMark = (parseInt($("#Student_Qualification_SSC_OutOfMark").val()));

            if (ObtainedMark < OutOfMark) {
                var result_num = parseFloat((ObtainedMark / OutOfMark) * 100);
                $('#Student_Qualification_SSC_Percent').val(result_num);
            }
            else {
                alert("Obtained mark is always less than out of mark");
                $("#Student_Qualification_SSC_ObtainedMark").val('');
                $("#Student_Qualification_SSC_OutOfMark").val('');
                $("#Student_Qualification_SSC_Percent").val('');

            }
        });
        //For HSC
        $("#Student_Qualification_HSC_OutOfMark").change(function () {
            
            var ObtainedMark = (parseInt($("#Student_Qualification_HSC_ObtainedMark").val()));
            var OutOfMark = (parseInt($("#Student_Qualification_HSC_OutOfMark").val()));

            if (ObtainedMark < OutOfMark) {
                var result_num = parseFloat((ObtainedMark / OutOfMark) * 100);
                $('#Student_Qualification_HSC_Percent').val(result_num);
            }
            else {
                alert("Obtained mark is always less than out of mark");
                $("#Student_Qualification_HSC_ObtainedMark").val('');
                $("#Student_Qualification_HSC_OutOfMark").val('');
                $("#Student_Qualification_HSC_Percent").val('');
            }
        });
        //For Diploma / ITI Details
        $("#Student_Qualification_Diploma_ITI_Details_OutOfMark").change(function () {
            
            var ObtainedMark = (parseInt($("#Student_Qualification_Diploma_ITI_Details_ObtainedMark").val()));
            var OutOfMark = (parseInt($("#Student_Qualification_Diploma_ITI_Details_OutOfMark").val()));

            if (ObtainedMark < OutOfMark) {
                var result_num = parseFloat((ObtainedMark / OutOfMark) * 100);
                $('#Student_Qualification_Diploma_ITI_Details_Percent').val(result_num);
            }
            else {
                alert("Obtained mark is always less than out of mark");
                $("#Student_Qualification_Diploma_ITI_Details_ObtainedMark").val('');
                $("#Student_Qualification_Diploma_ITI_Details_OutOfMark").val('');
                $("#Student_Qualification_Diploma_ITI_Details_Percent").val('');


            }
        });

        //For Degree Details
        $("#Student_Qualification_DegreeDetails_OutOfMark").change(function () {
            
            var ObtainedMark = (parseInt($("#Student_Qualification_DegreeDetails_ObtainedMark").val()));
            var OutOfMark = (parseInt($("#Student_Qualification_DegreeDetails_OutOfMark").val()));

            if (ObtainedMark < OutOfMark) {
                var result_num = parseFloat((ObtainedMark / OutOfMark) * 100);
                $('#Student_Qualification_DegreeDetails_Percent').val(result_num);
                StudentRegistrationForm.Student_Qualification_DegreeDetails_Percent = result_num;
            }
            else {
                alert("Obtained mark is always less than out of mark");
                $("#Student_Qualification_DegreeDetails_ObtainedMark").val('');
                $("#Student_Qualification_DegreeDetails_OutOfMark").val('');
                $("#Student_Qualification_DegreeDetails_Percent").val('');


            }
        });

        //For Post Graduation Details
        $("#Student_Qualification_PostGraduationDetails_OutOfMark").change(function () {
            
            var ObtainedMark = (parseInt($("#Student_Qualification_PostGraduationDetails_ObtainedMark").val()));
            var OutOfMark = (parseInt($("#Student_Qualification_PostGraduationDetails_OutOfMark").val()));

            if (ObtainedMark < OutOfMark) {
                var result_num = parseFloat((ObtainedMark / OutOfMark) * 100);
                $('#Student_Qualification_PostGraduationDetails_Percent').val(result_num);
            }
            else {
                alert("Obtained mark is always less than out of mark");
                $("#Student_Qualification_PostGraduationDetails_ObtainedMark").val('');
                $("#Student_Qualification_PostGraduationDetails_OutOfMark").val('');
                $('#Student_Qualification_PostGraduationDetails_Percent').val('');


            }
        });

        //For HSC Details  PCB Marks 
        $("#Student_Qualification_HSC_PCB_OutOfMark").change(function () {
            
            var ObtainedMark = (parseInt($("#Student_Qualification_HSC_PCB_ObtainedMark").val()));
            var OutOfMark = (parseInt($("#Student_Qualification_HSC_PCB_OutOfMark").val()));

            if (ObtainedMark > OutOfMark) {
                alert("Obtained mark is always less than out of mark");
                $("#Student_Qualification_HSC_PCB_ObtainedMark").val('');
                $("#Student_Qualification_HSC_PCB_OutOfMark").val('');
            }
        });


        //For HSC Details PCM/PVM Marks 
        $("#Student_Qualification_HSC_PCM_PVM_OutOfMark").change(function () {
            
            var ObtainedMark = (parseInt($("#Student_Qualification_HSC_PCM_PVM_ObtainedMark").val()));
            var OutOfMark = (parseInt($("#Student_Qualification_HSC_PCM_PVM_OutOfMark").val()));

            if (ObtainedMark > OutOfMark) {
                alert("Obtained mark is always less than out of mark");
                $("#Student_Qualification_HSC_PCM_PVM_ObtainedMark").val('');
                $("#Student_Qualification_HSC_PCM_PVM_OutOfMark").val('');
            }
        });




        $('#StudentMobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#StudentLandLineNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#StudentOfficeContactNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#StudentAnnualIncome').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#FatherMobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#FatherLandLineNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#FatherOfficeContactNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#FatherAnnualIncome').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#MotherMobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#MotherLandLineNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#MotherOfficeContactNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#MotherAnnualIncome').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#GuardianMobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#GuardianLandLineNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#GuardianOfficeContactNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Student_QualifyingExamTotalMarksPointsObtained').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_QualifyingExamOutOffMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_General_ObtainedMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_General_OutOfMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_General_Percent').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_SSC_ObtainedMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_SSC_OutOfMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_SSC_Percent').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Student_PermanentAddress_ZipCode').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_HSC_ObtainedMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_HSC_OutOfMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_HSC_Percent').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_HSC_PCM_PVM_ObtainedMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_HSC_PCM_PVM_OutOfMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_HSC_PCB_ObtainedMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_HSC_PCB_OutOfMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_Diploma_ITI_Details_ObtainedMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_Diploma_ITI_Details_OutOfMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_Diploma_ITI_Details_Percent').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_DegreeDetails_ObtainedMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_DegreeDetails_OutOfMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_DegreeDetails_Percent').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Student_Qualification_PostGraduationDetails_ObtainedMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_PostGraduationDetails_OutOfMark').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Student_Qualification_PostGraduationDetails_Percent').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Student_DTE_QualifyingExamMarks').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Student_Scholarship_Bank_AC_No').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Student_Scholarship_AnnualIncome').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });


        // For AllowCharacterOnly
        $('#StudentEmploymentSector').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentOccupation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentOrganizationName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentDesignation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#FatherEmploymentSector').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#FatherOccupation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#FatherOrganizationName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#FatherDesignation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#MotherEmploymentSector').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#MotherOccupation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#MotherDesignation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MotherOrganizationName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#GuardianEmploymentSector').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#GuardianOccupation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#GuardianDesignation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#GuardianOrganizationName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentDomicileStateofFather').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentDomicileStateofMother').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentPrevNameofStudent').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentReasonforNamechange').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentBirthPlace').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentLastSchool_College').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentNameAsPerMarkSheet').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentCasteAsPerTC_LC').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentIndicatetypeofCandidature').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentSchoolFromHSCExaminationpassed').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentsMKBCandidate').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentsNameOfDistrictWhereParentDomiciled').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_PermanentAddress_Tahsil').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_PermanentAddress_NearPoliceStation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_CorrespondenceAddress_Tahsil').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_CorrespondenceAddress_NearPoliceStation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_General_Region_Division_Board').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_General_NameofInstitution').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_SSC_Region_Division_Board').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_SSC_NameofInstitution').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_HSC_Region_Division_Board').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_HSC_NameofInstitution').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_Diploma_ITI_Details_BranchName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_Diploma_ITI_Details_NameofInstitution').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_Diploma_ITI_Details_Board').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_DegreeDetails_Degree').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_DegreeDetails_BranchName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_DegreeDetails_UniversityName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_DegreeDetails_NameofInstitution').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_PostGraduationDetails_PostGraduation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_PostGraduationDetails_BranchName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_PostGraduationDetails_NameofInstitution').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_Qualification_PostGraduationDetails_UniversityName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Student_DTE_DTESeatNo').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
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
        // Create new record
        $('#CreateStudentRegistrationFormRecord').on("click", function () {
            StudentRegistrationForm.ActionName = "Create";           
            StudentRegistrationForm.GetQualifyingExamSubjectDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectGeneralDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectSSCDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectHSCDetailsDataTable();
            StudentRegistrationForm.AjaxCallStudentRegistrationForm();
        });

        $('#EditStudentRegistrationFormRecord').on("click", function () {
            StudentRegistrationForm.ActionName = "Edit";            
            StudentRegistrationForm.GetQualifyingExamSubjectDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectGeneralDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectSSCDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectHSCDetailsDataTable();
            StudentRegistrationForm.AjaxCallStudentRegistrationForm();
        });
      
        $('#SaveStudentRegistrationFormRecord').on("click", function () {
            StudentRegistrationForm.ActionName = "Save";            
            StudentRegistrationForm.GetQualifyingExamSubjectDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectGeneralDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectSSCDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectHSCDetailsDataTable();
            StudentRegistrationForm.AjaxCallStudentRegistrationForm();
        });

        $('#UpdateStudentRegistrationFormRecord').on("click", function () {
            StudentRegistrationForm.ActionName = "Submit";           
            StudentRegistrationForm.GetQualifyingExamSubjectDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectGeneralDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectSSCDetailsDataTable();
            StudentRegistrationForm.GetQualificationExamSubjectHSCDetailsDataTable();
            StudentRegistrationForm.AjaxCallStudentRegistrationForm();
        });

    },


    //Fire ajax call to insert update and delete record
    AjaxCallStudentRegistrationForm: function () {

        var StudentRegistrationFormData = null;
        if (StudentRegistrationForm.ActionName == "Save") {
            //$("#FormCreateStudentRegistrationForm").validate();
            //if ($("#FormCreateStudentRegistrationForm").valid()) {
            StudentRegistrationFormData = null;
            StudentRegistrationFormData = StudentRegistrationForm.GetStudentRegistrationForm();            
            ajaxRequest.makeRequest("/StudentRegistrationForm/Create", "POST", StudentRegistrationFormData, StudentRegistrationForm.createSuccess);
            //}
        }
        else if (StudentRegistrationForm.ActionName == "Edit") {
            //$("#FormCreateStudentRegistrationForm").validate();
            //if ($("#FormCreateStudentRegistrationForm").valid()) {
            StudentRegistrationFormData = null;
            StudentRegistrationFormData = StudentRegistrationForm.GetStudentRegistrationForm();           
            ajaxRequest.makeRequest("/StudentRegistrationForm/Edit", "POST", StudentRegistrationFormData, StudentRegistrationForm.editSuccess);
            //}
        }
        else if (StudentRegistrationForm.ActionName == "Submit") {
            //$("#FormCreateStudentRegistrationForm").validate();
            //if ($("#FormCreateStudentRegistrationForm").valid()) {
            StudentRegistrationFormData = null;
            StudentRegistrationFormData = StudentRegistrationForm.GetStudentRegistrationForm();            
            ajaxRequest.makeRequest("/StudentRegistrationForm/Edit", "POST", StudentRegistrationFormData, StudentRegistrationForm.submitSuccess);
            //}
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetStudentRegistrationForm: function () {
        var Data = {
        };

        //if (StudentRegistrationForm.ActionName == "Create" || StudentRegistrationForm.ActionName == "Save") {
            //Student upload

            //For Image
            var StudentPhotoFileSize = null;
            var StudentPhotoType = null;
            var StudentPhotoFilename = null;
            var StudentPhotoFileWidth = null;
            var StudentPhotoFileHeight = null;
            
            var img = document.getElementById('previewStudentPhoto');
            if ($("#StudentPhotoFile").val() != "") {
                if (typeof ($("#StudentPhotoFile")[0].files) != "undefined") {
                    StudentPhotoFileSize = $("#StudentPhotoFile")[0].files[0].size;
                    StudentPhotoType = $('#StudentPhotoFile')[0].files[0].type;
                    StudentPhotoFilename = $('#StudentPhotoFile')[0].files[0].name;
                    StudentPhotoFileWidth = img.width;
                    StudentPhotoFileHeight = img.height;
                }

                
                if (StudentPhotoType == "image/jpeg") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/jpeg;base64,/g, '');
                }
                else if (StudentPhotoType == "image/png") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/png;base64,/g, '');
                }
                else if (StudentPhotoType == "image/gif") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/gif;base64,/g, '');
                }
                else if (StudentPhotoType == "image/jpg") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/jpg;base64,/g, '');
                }
                else if (StudentPhotoType == "image/bmp") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/bmp;base64,/g, '');
                }

                Data.StudentPhotoType = StudentPhotoType;
                Data.StudentPhotoFilename = StudentPhotoFilename;
                Data.StudentPhotoFileWidth = StudentPhotoFileWidth;
                Data.StudentPhotoFileHeight = StudentPhotoFileHeight;
                Data.StudentPhotoFileSize = StudentPhotoFileSize;
            }
            //For Signature

            var StudentSignatureFileSize = null;
            var StudentSignatureType = null;
            var StudentSignatureFilename = null;
            var StudentSignatureFileWidth = null;
            var StudentSignatureFileHeight = null;

            var img = document.getElementById('previewStudentSignature');
            if ($("#StudentSignatureFile").val() != "") {
                if (typeof ($("#StudentSignatureFile")[0].files) != "undefined") {
                    StudentSignatureFileSize = $("#StudentSignatureFile")[0].files[0].size;
                    StudentSignatureType = $('#StudentSignatureFile')[0].files[0].type;
                    StudentSignatureFilename = $('#StudentSignatureFile')[0].files[0].name;

                    StudentSignatureFileWidth = img.width;
                    StudentSignatureFileHeight = img.height;
                }

                
                if (StudentSignatureType == "image/jpeg") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/jpeg;base64,/g, '');
                }
                else if (StudentSignatureType == "image/png") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/png;base64,/g, '');
                }
                else if (StudentSignatureType == "image/gif") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/gif;base64,/g, '');
                }
                else if (StudentSignatureType == "image/jpg") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/jpg;base64,/g, '');
                }
                else if (StudentSignatureType == "image/bmp") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/bmp;base64,/g, '');
                }

                Data.StudentSignatureType = StudentSignatureType;
                Data.StudentSignatureFilename = StudentSignatureFilename;
                Data.StudentSignatureFileWidth = StudentSignatureFileWidth;
                Data.StudentSignatureFileHeight = StudentSignatureFileHeight;
                Data.StudentSignatureFileSize = StudentSignatureFileSize;
            }
            //For Thumb

            var StudentThumbFileSize = null;
            var StudentThumbType = null;
            var StudentThumbFilename = null;
            var StudentThumbFileWidth = null;
            var StudentThumbFileHeight = null;

            var img = document.getElementById('previewStudentThumb');
            if ($("#StudentSignatureFile").val() != "") {
                if (typeof ($("#StudentThumbFile")[0].files) != "undefined") {
                    StudentThumbFileSize = $("#StudentThumbFile")[0].files[0].size;
                    StudentThumbType = $('#StudentThumbFile')[0].files[0].type;
                    StudentThumbFilename = $('#StudentThumbFile')[0].files[0].name;

                    StudentThumbFileWidth = img.width;
                    StudentThumbFileHeight = img.height;
                }

                
                if (StudentThumbType == "image/jpeg") {
                    Data.StudentThumb = $('#previewStudentThumb').attr('src').replace(/data:image\/jpeg;base64,/g, '');
                }
                else if (StudentThumbType == "image/png") {
                    Data.StudentThumb = $('#previewStudentThumb').attr('src').replace(/data:image\/png;base64,/g, '');
                }
                else if (StudentThumbType == "image/gif") {
                    Data.StudentThumb = $('#previewStudentThumb').attr('src').replace(/data:image\/gif;base64,/g, '');
                }
                else if (StudentThumbType == "image/jpg") {
                    Data.StudentThumb = $('#previewStudentThumb').attr('src').replace(/data:image\/jpg;base64,/g, '');
                }
                else if (StudentThumbType == "image/bmp") {
                    Data.StudentThumb = $('#previewStudentThumb').attr('src').replace(/data:image\/bmp;base64,/g, '');
                }

                Data.StudentThumbType = StudentThumbType;
                Data.StudentThumbFilename = StudentThumbFilename;
                Data.StudentThumbFileWidth = StudentThumbFileWidth;
                Data.StudentThumbFileHeight = StudentThumbFileHeight;
                Data.StudentThumbFileSize = StudentThumbFileSize;
            }
            // Student Personal Information 
            Data.StudentTitle = $('#StudentTitle').val();
            Data.StudentFirstName = $('#StudentFirstName').val();
            Data.StudentMiddleName = $('#StudentMiddleName').val();
            Data.StudentLastName = $('#StudentLastName').val();
            Data.StudentEmailID = $('#StudentEmailID').val();
            
            Data.Male = $('#Male').val();

            if ($('#Male').is(':checked')) {
                Data.StudentGender = "M";
            }
            else if ($('#Female').is(':checked')) {
                Data.StudentGender = "F";
            }
            Data.StudentMobileNumber = $('#StudentMobileNumber').val();
            Data.StudentLandLineNumber = $('#StudentLandLineNumber').val();
            Data.StudentEmploymentSector = $('#StudentEmploymentSector').val();
            Data.StudentOccupation = $('#StudentOccupation').val();
            Data.StudentDesignation = $('#StudentDesignation').val();
            Data.StudentOrganizationName = $('#StudentOrganizationName').val();
            Data.StudentOfficeContactNo = $('#StudentOfficeContactNo').val();
            Data.StudentAnnualIncome = $('#StudentAnnualIncome').val();

            //Father/Husband Personal Information 
            Data.FatherTitle = $('#FatherTitle').val();
            Data.FatherHusbondType = $('#FatherHusbondType').val();
            Data.FatherFirstName = $('#FatherFirstName').val();
            Data.FatherMiddleName = $('#FatherMiddleName').val();
            Data.FatherLastName = $('#FatherLastName').val();
            Data.FatherEmailId = $('#FatherEmailId').val();
            Data.FatherMobileNumber = $('#FatherMobileNumber').val();
            Data.FatherLandLineNumber = $('#FatherLandLineNumber').val();
            Data.FatherEmploymentSector = $('#FatherEmploymentSector').val();
            Data.FatherOccupation = $('#FatherOccupation').val();
            Data.FatherDesignation = $('#FatherDesignation').val();
            Data.FatherOrganizationName = $('#FatherOrganizationName').val();
            Data.FatherOfficeContactNo = $('#FatherOfficeContactNo').val();
            Data.FatherAnnualIncome = $('#FatherAnnualIncome').val();

            //Mother Personal Information
            Data.MotherTitle = $('#MotherTitle').val();
            Data.MotherFirstName = $('#MotherFirstName').val();
            Data.MotherMiddleName = $('#MotherMiddleName').val();
            Data.MotherLastName = $('#MotherLastName').val();
            Data.MotherEmailId = $('#MotherEmailId').val();
            Data.MotherMobileNumber = $('#MotherMobileNumber').val();
            Data.MotherLandLineNumber = $('#MotherLandLineNumber').val();
            Data.MotherEmploymentSector = $('#MotherEmploymentSector').val();
            Data.MotherOccupation = $('#MotherOccupation').val();
            Data.MotherDesignation = $('#MotherDesignation').val();
            Data.MotherOrganizationName = $('#MotherOrganizationName').val();
            Data.MotherOfficeContactNo = $('#MotherOfficeContactNo').val();
            Data.MotherAnnualIncome = $('#MotherAnnualIncome').val();

            //Guardian Personal Information 
            Data.GuardianTitle = $('#GuardianTitle').val();
            Data.GuardianFirstName = $('#GuardianFirstName').val();
            Data.GuardianMiddleName = $('#GuardianMiddleName').val();
            Data.GuardianLastName = $('#GuardianLastName').val();
            Data.GuardianEmailId = $('#GuardianEmailId').val();
            Data.GuardianMobileNumber = $('#GuardianMobileNumber').val();
            Data.GuardianLandLineNumber = $('#GuardianLandLineNumber').val();
            Data.GuardianEmploymentSector = $('#GuardianEmploymentSector').val();
            Data.GuardianOccupation = $('#GuardianOccupation').val();
            Data.GuardianDesignation = $('#GuardianDesignation').val();
            Data.GuardianOrganizationName = $('#GuardianOrganizationName').val();
            Data.GuardianOfficeContactNo = $('#GuardianOfficeContactNo').val();
            Data.GuardianAnnualIncome = $('#GuardianAnnualIncome').val();

            //Student Specific Information 
            Data.StudentEnrollmentNo = $('#StudentEnrollmentNo').val();
            Data.StudentNRI_POI = $('#StudentNRI_POI').val();
            Data.StudentMigrationNumber = $('#StudentMigrationNumber').val();
            Data.StudentNationalityID = $('#StudentNationalityID').val();
            Data.StudentMigrationDate = $('#StudentMigrationDate').val();
            Data.StudentRegionID = $('#StudentRegionID').val();
            Data.StudentRegionOther = $('#StudentRegionOther').val();
            Data.StudentMaritalStatus = $('#StudentMaritalStatus').val();
            Data.StudentDomicileStateofFather = $('#StudentDomicileStateofFather').val();
            Data.StudentBloodGroup = $('#StudentBloodGroup').val();
            Data.StudentDomicileStateofMother = $('#StudentDomicileStateofMother').val();
            Data.PhysicallyHandicapped = $('#PhysicallyHandicapped').val();
            Data.StudentEmploymentStatus = $('#StudentEmploymentStatus').val();
            Data.StudentIdentificationMark = $('#StudentIdentificationMark').val();
            Data.StudentPrevNameofStudent = $('#StudentPrevNameofStudent').val();
            Data.StudentOrgandonor = $('#StudentOrgandonor').val();
            Data.StudentReasonforNamechange = $('#StudentReasonforNamechange').val();
            Data.Student_Domesile_CountryId = $('#Student_Domesile_CountryId').val();
            //Information As Per Leaving Certificate 
            Data.StudentDateofBirth = $('#StudentDateofBirth').val();
            Data.StudentBirthPlace = $('#StudentBirthPlace').val();
            Data.StudentReligionID = $('#StudentReligionID').val();
            Data.StudentCategoryID = $('#StudentCategoryID').val();
            Data.StudentCasteID = $('#StudentCasteID').val();
            Data.StudentCasteAsPerTC_LC = $('#StudentCasteAsPerTC_LC').val();
            Data.StudentMotherTongueID = $('#StudentMotherTongueID').val();
            Data.StudentNameAsPerMarkSheet = $('#StudentNameAsPerMarkSheet').val();
            Data.StudentLastSchool_College = $('#StudentLastSchool_College').val();
            Data.StudentPreviousLC_TCNo = $('#StudentPreviousLC_TCNo').val();

            //Social Reservation Information 

            Data.Student_Ex_Serviceman_Ward_of_Ex_Serviceman = $('input[name=Student_Ex_Serviceman_Ward_of_Ex_Serviceman]:checked').val() ? true : false;
            Data.Student_Active_Serviceman_Ward_of_Active_Serviceman = $('input[name=Student_Active_Serviceman_Ward_of_Active_Serviceman]:checked').val() ? true : false;
            Data.Student_FreedomFighterWardOfFreedomFighter = $('input[name=Student_FreedomFighterWardOfFreedomFighter]:checked').val() ? true : false;
            Data.Student_WardofPrimaryTeacher = $('input[name=Student_WardofPrimaryTeacher]:checked').val() ? true : false;
            Data.Student_WardofSecondaryTeacher = $('input[name=Student_WardofSecondaryTeacher]:checked').val() ? true : false;
            Data.Student_Deserted_Divorced_Widowed_Women = $('input[name=Student_Deserted_Divorced_Widowed_Women]:checked').val() ? true : false;
            Data.Student_MemberofProjectAffectedFamily = $('input[name=Student_MemberofProjectAffectedFamily]:checked').val() ? true : false;
            Data.Student_MemberofEarthquakeAffectedFamily = $('input[name=Student_MemberofEarthquakeAffectedFamily]:checked').val() ? true : false;
            Data.Student_MemberofFloodFamineAffectedFamily = $('input[name=Student_MemberofFloodFamineAffectedFamily]:checked').val() ? true : false;
            Data.Student_ResidentofTribalArea = $('input[name=Student_ResidentofTribalArea]:checked').val() ? true : false;
            Data.Student_KashmirMigrant = $('input[name=Student_KashmirMigrant]:checked').val() ? true : false;

            //Other Information Of The Student 
            Data.StudentIndicatetypeofCandidature = $('#StudentIndicatetypeofCandidature').val();
            Data.StudentSchoolFromHSCExaminationpassed = $('#StudentSchoolFromHSCExaminationpassed').val();
            Data.StudentEconomicallyBackwardClass = $('#StudentEconomicallyBackwardClass').val();
            Data.StudentsNameOfDistrictWhereParentDomiciled = $('#StudentsNameOfDistrictWhereParentDomiciled').val();
            Data.StudentsMKBCandidate = $('#StudentsMKBCandidate').val();

            //Address Information 
            //Permanent Address
            Data.Student_PermanentAddress_PloteNo = $('#Student_PermanentAddress_PloteNo').val();
            Data.Student_PermanentAddress_StreeNo = $('#Student_PermanentAddress_StreeNo').val();
            Data.Student_PermanentAddress_Address1 = $('#Student_PermanentAddress_Address1').val();
            Data.Student_PermanentAddress_Address2 = $('#Student_PermanentAddress_Address2').val();
            Data.Student_PermanentAddress_City_TahsilID = $('#Student_PermanentAddress_City_TahsilID').val();
            Data.Student_PermanentAddress_City_TahsilOther = $('#Student_PermanentAddress_City_TahsilOther').val();
            Data.Student_PermanentAddress_CountryId = $('#Student_PermanentAddress_CountryId').val();
            Data.Student_PermanentAddress_State = $('#Student_PermanentAddress_State').val();
            Data.Student_PermanentAddress_StateOther = $('#Student_PermanentAddress_StateOther').val();
            Data.Student_PermanentAddress_DistrictID = $('#Student_PermanentAddress_DistrictID').val();
            Data.Student_PermanentAddress_DistrictOther = $('#Student_PermanentAddress_DistrictOther').val();
            Data.Student_PermanentAddress_Tahsil = $('#Student_PermanentAddress_Tahsil').val();
            Data.Student_PermanentAddress_NearPoliceStation = $('#Student_PermanentAddress_NearPoliceStation').val();
            Data.Student_PermanentAddress_ZipCode = $('#Student_PermanentAddress_ZipCode').val();
            Data.Student_PermanentAddress_City_Tahsil_Pattern = $('#Student_PermanentAddress_City_Tahsil_Pattern').val();

            //Correspondence Address
            

            // Data.SameAsPerPermanentAddress = $('input[name=SameAsPerPermanentAddress]:checked').val() ? true : false;
            Data.SameAsPerPermanentAddress = $('#SameAsPerPermanentAddress:checked').val() ? true : false;
            Data.Student_CorrespondenceAddress_PloteNo = $('#Student_CorrespondenceAddress_PloteNo').val();
            Data.Student_CorrespondenceAddress_StreeNo = $('#Student_CorrespondenceAddress_StreeNo').val();
            Data.Student_CorrespondenceAddress_Address1 = $('#Student_CorrespondenceAddress_Address1').val();
            Data.Student_CorrespondenceAddress_Address2 = $('#Student_CorrespondenceAddress_Address2').val();
            Data.Student_CorrespondenceAddress_City_TahsilID = $('#Student_CorrespondenceAddress_City_TahsilID').val();
            Data.Student_CorrespondenceAddress_City_TahsilOther = $('#Student_CorrespondenceAddress_City_TahsilOther').val();
            Data.Student_CorrespondenceAddress_CountryId = $('#Student_CorrespondenceAddress_CountryId').val();
            Data.Student_CorrespondenceAddress_State = $('#Student_CorrespondenceAddress_State').val();
            Data.Student_CorrespondenceAddress_StateOther = $('#Student_CorrespondenceAddress_StateOther').val();
            Data.Student_CorrespondenceAddress_DistrictID = $('#Student_CorrespondenceAddress_DistrictID').val();
            Data.Student_CorrespondenceAddress_DistrictOther = $('#Student_CorrespondenceAddress_DistrictOther').val();
            Data.Student_CorrespondenceAddress_Tahsil = $('#Student_CorrespondenceAddress_Tahsil').val();
            Data.Student_CorrespondenceAddress_NearPoliceStation = $('#Student_CorrespondenceAddress_NearPoliceStation').val();
            Data.Student_CorrespondenceAddress_ZipCode = $('#Student_CorrespondenceAddress_ZipCode').val();
            Data.Student_CorrespondenceAddress_City_Tahsil_Pattern = $('#Student_CorrespondenceAddress_City_Tahsil_Pattern').val();

            //Qualifying Exam Details 
            Data.Student_QualifyingExamName = $('#Student_QualifyingExamName').val();
            Data.Student_QualifyingRollNo = $('#Student_QualifyingRollNo').val();
            Data.Student_QualifyingExamTotalMarksPointsObtained = $('#Student_QualifyingExamTotalMarksPointsObtained').val();
            Data.Student_QualifyingExamOutOffMark = $('#Student_QualifyingExamOutOffMark').val();
            Data.Student_QualifyingExamRank = $('#Student_QualifyingExamRank').val();

            //Qualification Details 
            //    General Details 
            Data.Student_Qualification_General_MediumOfInstitution = $('#Student_Qualification_General_MediumOfInstitution').val();
            Data.Student_Qualification_General_MonthOfPassing = $('#Student_Qualification_General_MonthOfPassing').val();
            Data.Student_Qualification_General_YearOfPassing = $('#Student_Qualification_General_YearOfPassing').val();
            Data.Student_Qualification_General_SingleAttempt = $('#Student_Qualification_General_SingleAttempt').val();
            Data.Student_Qualification_General_ObtainedMark = $('#Student_Qualification_General_ObtainedMark').val();
            Data.Student_Qualification_General_OutOfMark = $('#Student_Qualification_General_OutOfMark').val();
            //alert($('#Student_Qualification_General_Percent').val());
            Data.Student_Qualification_General_Percent = $('#Student_Qualification_General_Percent').val();

            //    SSC Details 
            Data.Student_Qualification_SSC_MediumOfInstitution = $('#Student_Qualification_SSC_MediumOfInstitution').val();
            Data.Student_Qualification_SSC_MonthOfPassing = $('#Student_Qualification_SSC_MonthOfPassing').val();
            Data.Student_Qualification_SSC_YearOfPassing = $('#Student_Qualification_SSC_YearOfPassing').val();
            Data.Student_Qualification_SSC_SingleAttempt = $('#Student_Qualification_SSC_SingleAttempt').val();
            Data.Student_Qualification_SSC_ObtainedMark = $('#Student_Qualification_SSC_ObtainedMark').val();
            Data.Student_Qualification_SSC_OutOfMark = $('#Student_Qualification_SSC_OutOfMark').val();
            Data.Student_Qualification_SSC_Percent = $('#Student_Qualification_SSC_Percent').val();
            Data.Student_Qualification_SSC_NameofInstitution = $('#Student_Qualification_SSC_NameofInstitution').val();
            Data.Student_Qualification_SSC_Region_Division_Board = $('#Student_Qualification_SSC_Region_Division_Board').val();

            //    HSC Details 
            Data.Student_Qualification_HSC_MediumOfInstitution = $('#Student_Qualification_HSC_MediumOfInstitution').val();
            Data.Student_Qualification_HSC_MonthOfPassing = $('#Student_Qualification_HSC_MonthOfPassing').val();
            Data.Student_Qualification_HSC_YearOfPassing = $('#Student_Qualification_HSC_YearOfPassing').val();
            Data.Student_Qualification_HSC_StreamID = $('#Student_Qualification_HSC_StreamID').val();
            Data.Student_Qualification_HSC_StreamOther = $('#Student_Qualification_HSC_StreamOther').val();
            Data.Student_Qualification_HSC_SingleAttempt = $('#Student_Qualification_HSC_SingleAttempt').val();
            Data.Student_Qualification_HSC_Class = $('#Student_Qualification_HSC_Class').val();
            Data.Student_Qualification_HSC_ObtainedMark = $('#Student_Qualification_HSC_ObtainedMark').val();
            Data.Student_Qualification_HSC_OutOfMark = $('#Student_Qualification_HSC_OutOfMark').val();
            Data.Student_Qualification_HSC_Percent = $('#Student_Qualification_HSC_Percent').val();
            Data.Student_Qualification_HSC_PCM_PVM_ObtainedMark = $('#Student_Qualification_HSC_PCM_PVM_ObtainedMark').val();
            Data.Student_Qualification_HSC_PCM_PVM_OutOfMark = $('#Student_Qualification_HSC_PCM_PVM_OutOfMark').val();
            Data.Student_Qualification_HSC_PCB_ObtainedMark = $('#Student_Qualification_HSC_PCB_ObtainedMark').val();
            Data.Student_Qualification_HSC_PCB_OutOfMark = $('#Student_Qualification_HSC_PCB_OutOfMark').val();
            Data.Student_Qualification_HSC_NameofInstitution = $('#Student_Qualification_HSC_NameofInstitution').val();
            Data.Student_Qualification_HSC_Region_Division_Board = $('#Student_Qualification_HSC_Region_Division_Board').val();

            //Diploma / ITI Details 
            Data.Student_Qualification_Diploma_ITI_Details_MediumOfInstitution = $('#Student_Qualification_Diploma_ITI_Details_MediumOfInstitution').val();
            Data.Student_Qualification_Diploma_ITI_Details_BranchName = $('#Student_Qualification_Diploma_ITI_Details_BranchName').val();
            Data.Student_Qualification_Diploma_ITI_Details_ExamPattern = $('#Student_Qualification_Diploma_ITI_Details_ExamPattern').val();
            Data.Student_Qualification_Diploma_ITI_Details_MonthOfPassing = $('#Student_Qualification_Diploma_ITI_Details_MonthOfPassing').val();
            Data.Student_Qualification_Diploma_ITI_Details_YearOfPassing = $('#Student_Qualification_Diploma_ITI_Details_YearOfPassing').val();
            Data.Student_Qualification_Diploma_ITI_Details_Class = $('#Student_Qualification_Diploma_ITI_Details_Class').val();
            Data.Student_Qualification_Diploma_ITI_Details_ObtainedMark = $('#Student_Qualification_Diploma_ITI_Details_ObtainedMark').val();
            Data.Student_Qualification_Diploma_ITI_Details_OutOfMark = $('#Student_Qualification_Diploma_ITI_Details_OutOfMark').val();
            Data.Student_Qualification_Diploma_ITI_Details_Percent = $('#Student_Qualification_Diploma_ITI_Details_Percent').val();
            Data.Student_Qualification_Diploma_ITI_Details_SingleAttempt = $('#Student_Qualification_Diploma_ITI_Details_SingleAttempt').val();
            Data.Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber = $('#Student_Qualification_Diploma_ITI_Details_BoardEnrollmentNumber').val();
            Data.Student_Qualification_Diploma_ITI_Details_NameofInstitution = $('#Student_Qualification_Diploma_ITI_Details_NameofInstitution').val();
            Data.Student_Qualification_Diploma_ITI_Details_Board = $('#Student_Qualification_Diploma_ITI_Details_Board').val();
            Data.Student_Qualification_Diploma_ITI_Details_State = $('#Student_Qualification_Diploma_ITI_Details_State').val();
            Data.Student_Qualification_Diploma_ITI_Details_StateOther = $('#Student_Qualification_Diploma_ITI_Details_StateOther').val();
            Data.Student_Qualification_Diploma_ITI_Details_CountryId = $('#Student_Qualification_Diploma_ITI_Details_CountryId').val();

            //    Degree Details 
            Data.Student_Qualification_DegreeDetails_MediumOfInstitution = $('#Student_Qualification_DegreeDetails_MediumOfInstitution').val();
            Data.Student_Qualification_DegreeDetails_Degree = $('#Student_Qualification_DegreeDetails_Degree').val();
            Data.Student_Qualification_DegreeDetails_BranchName = $('#Student_Qualification_DegreeDetails_BranchName').val();
            Data.Student_Qualification_DegreeDetails_ExamPattern = $('#Student_Qualification_DegreeDetails_ExamPattern').val();
            //alert($('#Student_Qualification_DegreeDetails_MonthOfPassing').val());
            Data.Student_Qualification_DegreeDetails_MonthOfPassing = $('#Student_Qualification_DegreeDetails_MonthOfPassing').val();
            Data.Student_Qualification_DegreeDetails_YearOfPassing = $('#Student_Qualification_DegreeDetails_YearOfPassing').val();
            Data.Student_Qualification_DegreeDetails_ObtainedMark = $('#Student_Qualification_DegreeDetails_ObtainedMark').val();
            Data.Student_Qualification_DegreeDetails_OutOfMark = $('#Student_Qualification_DegreeDetails_OutOfMark').val();           
            Data.Student_Qualification_DegreeDetails_Percent = StudentRegistrationForm.Student_Qualification_DegreeDetails_Percent;
            Data.Student_Qualification_DegreeDetails_Class = $('#Student_Qualification_DegreeDetails_Class').val();
            Data.Student_Qualification_DegreeDetails_SingleAttempt = $('#Student_Qualification_DegreeDetails_SingleAttempt').val();
            Data.Student_Qualification_DegreeDetails_BoardEnrollmentNumber = $('#Student_Qualification_DegreeDetails_BoardEnrollmentNumber').val();
            Data.Student_Qualification_DegreeDetails_NameofInstitution = $('#Student_Qualification_DegreeDetails_NameofInstitution').val();
            Data.Student_Qualification_DegreeDetails_UniversityId = $('#Student_Qualification_DegreeDetails_UniversityId').val();
            Data.Student_Qualification_DegreeDetails_UniversityName = $('#Student_Qualification_DegreeDetails_UniversityName').val();
            Data.Student_Qualification_DegreeDetails_State = $('#Student_Qualification_DegreeDetails_State').val();
            Data.Student_Qualification_DegreeDetails_StateOther = $('#Student_Qualification_DegreeDetails_StateOther').val();
            Data.Student_Qualification_DegreeDetails_CountryId = $('#Student_Qualification_DegreeDetails_CountryId').val();

            //Post Graduation Details 
            Data.Student_Qualification_PostGraduationDetails_MediumOfInstitution = $('#Student_Qualification_PostGraduationDetails_MediumOfInstitution').val();
            Data.Student_Qualification_PostGraduationDetails_PostGraduation = $('#Student_Qualification_PostGraduationDetails_PostGraduation').val();
            Data.Student_Qualification_PostGraduationDetails_BranchName = $('#Student_Qualification_PostGraduationDetails_BranchName').val();
            Data.Student_Qualification_PostGraduationDetails_ExamPattern = $('#Student_Qualification_PostGraduationDetails_ExamPattern').val();
            Data.Student_Qualification_PostGraduationDetails_MonthOfPassing = $('#Student_Qualification_PostGraduationDetails_MonthOfPassing').val();
            Data.Student_Qualification_PostGraduationDetails_YearOfPassing = $('#Student_Qualification_PostGraduationDetails_YearOfPassing').val();
            Data.Student_Qualification_PostGraduationDetails_ObtainedMark = $('#Student_Qualification_PostGraduationDetails_ObtainedMark').val();
            Data.Student_Qualification_PostGraduationDetails_OutOfMark = $('#Student_Qualification_PostGraduationDetails_OutOfMark').val();
            Data.Student_Qualification_PostGraduationDetails_Percent = $('#Student_Qualification_PostGraduationDetails_Percent').val();
            Data.Student_Qualification_PostGraduationDetails_Class = $('#Student_Qualification_PostGraduationDetails_Class').val();
            Data.Student_Qualification_PostGraduationDetails_SingleAttempt = $('#Student_Qualification_PostGraduationDetails_SingleAttempt').val();
            Data.Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber = $('#Student_Qualification_PostGraduationDetails_BoardEnrollmentNumber').val();
            Data.Student_Qualification_PostGraduationDetails_NameofInstitution = $('#Student_Qualification_PostGraduationDetails_NameofInstitution').val();
            Data.Student_Qualification_PostGraduationDetails_UniversityName = $('#Student_Qualification_PostGraduationDetails_UniversityName').val();
            Data.Student_Qualification_PostGraduationDetails_State = $('#Student_Qualification_PostGraduationDetails_State').val();
            Data.Student_Qualification_PostGraduationDetails_StateOther = $('#Student_Qualification_PostGraduationDetails_StateOther').val();
            Data.Student_Qualification_PostGraduationDetails_CountryId = $('#Student_Qualification_PostGraduationDetails_CountryId').val();


            //  DTE And Scholarship Information
            //  DTE Information
            //alert($('#Student_DTE_DTEUserID').val());
            Data.Student_DTE_DTEUserID = $('#Student_DTE_DTEUserID').val();
            Data.Student_DTE_DTEPassword = $('#Student_DTE_DTEPassword').val();
            Data.Student_DTE_DTESrNo = $('#Student_DTE_DTESrNo').val();
            Data.Student_DTE_DTEMeritNo = $('#Student_DTE_DTEMeritNo').val();
            Data.Student_DTE_AdmissionTypeId = $('#Student_DTE_AdmissionTypeId').val();
            Data.Student_DTE_AdmissionRound = $('#Student_DTE_AdmissionRound').val();
            Data.Student_DTE_AdmissionCategoryId = $('#Student_DTE_AdmissionCategoryId').val();
            Data.Student_DTE_DTESeatNo = $('#Student_DTE_DTESeatNo').val();
            Data.Student_QualifyingExamId = $('#Student_QualifyingExamId').val();
            //alert($('#Student_DTE_QualifyingExamName').val());
            Data.Student_DTE_QualifyingExamName = $('#Student_DTE_QualifyingExamName').val();
            Data.Student_DTE_QualifyingExamMarks = $('#Student_DTE_QualifyingExamMarks').val();

            //Scholarship Information
            Data.Student_Scholarship_ScholarshipId = $('#Student_Scholarship_ScholarshipId').val();
            Data.Student_Scholarship_ScholarshipType = $('#Student_Scholarship_ScholarshipType').val();
            Data.Student_Scholarship_CastCategoryId = $('#Student_Scholarship_CastCategoryId').val();
            Data.Student_Scholarship_AadhaarCardNo = $('#Student_Scholarship_AadhaarCardNo').val();
            Data.Student_Scholarship_AnnualIncome = $('#Student_Scholarship_AnnualIncome').val();
            Data.Student_Scholarship_NoofSibling = $('#Student_Scholarship_NoofSibling').val();
            Data.Student_Scholarship_ChildNoOutofSibling = $('#Student_Scholarship_ChildNoOutofSibling').val();
            Data.Student_Scholarship_HostelDayScholar = $('#Student_Scholarship_HostelDayScholar').val();
            Data.Student_Scholarship_Bank_BranchName = $('#Student_Scholarship_Bank_BranchName').val();
            Data.Student_Scholarship_Bank_AC_No = $('#Student_Scholarship_Bank_AC_No').val();
            Data.Student_Scholarship_Bank_IFSCCode = $('#Student_Scholarship_Bank_IFSCCode').val();
            Data.Student_Scholarship_Bank_MICRCode = $('#Student_Scholarship_Bank_MICRCode').val();
            
            //  var StudentDocumentFlagIDs = "<rows>"
            var StudentDocumentIDs = "<rows>"
            //Student Documents Information 
            Data.Student_AdmissionDocuments_JETMarkSheet = $('input[name=Student_AdmissionDocuments_JETMarkSheet]:checked').val() ? true : false;
            // StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_JETMarkSheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_JETMarkSheet + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_JETMarkSheet == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_JETMarkSheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_JETMarkSheet + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_AllotmentLetter = $('input[name=Student_AdmissionDocuments_AllotmentLetter]:checked').val() ? true : false;
            // StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_AllotmentLetter').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_AllotmentLetter + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_AllotmentLetter == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_AllotmentLetter').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_AllotmentLetter + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_TenthMarkSheet = $('input[name=Student_AdmissionDocuments_TenthMarkSheet]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_TenthMarkSheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_TenthMarkSheet + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_TenthMarkSheet == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_TenthMarkSheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_TenthMarkSheet + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_TwelvethMarkSheet = $('input[name=Student_AdmissionDocuments_TwelvethMarkSheet]:checked').val() ? true : false;
            // StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_TwelvethMarkSheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_TwelvethMarkSheet + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_TwelvethMarkSheet == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_TwelvethMarkSheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_TwelvethMarkSheet + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_AllDiplomaMarksheet = $('input[name=Student_AdmissionDocuments_AllDiplomaMarksheet]:checked').val() ? true : false;
            // StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_AllDiplomaMarksheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_AllDiplomaMarksheet + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_AllDiplomaMarksheet == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_AllDiplomaMarksheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_AllDiplomaMarksheet + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_LeavingCertificate = $('input[name=Student_AdmissionDocuments_LeavingCertificate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_LeavingCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_LeavingCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_LeavingCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_LeavingCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_LeavingCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_Domicile_BirthCertificate = $('input[name=Student_AdmissionDocuments_Domicile_BirthCertificate]:checked').val() ? true : false;
            //  StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Domicile_BirthCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Domicile_BirthCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_Domicile_BirthCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Domicile_BirthCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Domicile_BirthCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_NationalityCertificate = $('input[name=Student_AdmissionDocuments_NationalityCertificate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_NationalityCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_NationalityCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_NationalityCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_NationalityCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_NationalityCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_CasteCertificate = $('input[name=Student_AdmissionDocuments_CasteCertificate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_CasteCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_CasteCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_CasteCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_CasteCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_CasteCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_CasteValidityCertificate = $('input[name=Student_AdmissionDocuments_CasteValidityCertificate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_CasteValidityCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_CasteValidityCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_CasteValidityCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_CasteValidityCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_CasteValidityCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_NonCreamylayerCertificate = $('input[name=Student_AdmissionDocuments_NonCreamylayerCertificate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_NonCreamylayerCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_NonCreamylayerCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_NonCreamylayerCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_NonCreamylayerCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_NonCreamylayerCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_EquivalenceCertificate = $('input[name=Student_AdmissionDocuments_EquivalenceCertificate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_EquivalenceCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_EquivalenceCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_EquivalenceCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_EquivalenceCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_EquivalenceCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_MigrationCertificate = $('input[name=Student_AdmissionDocuments_MigrationCertificate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_MigrationCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_MigrationCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_MigrationCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_MigrationCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_MigrationCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_GapCertificate = $('input[name=Student_AdmissionDocuments_GapCertificate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_GapCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_GapCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_GapCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_GapCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_GapCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_AntiRaggingAffidavit = $('input[name=Student_AdmissionDocuments_AntiRaggingAffidavit]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_AntiRaggingAffidavit').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_AntiRaggingAffidavit + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_AntiRaggingAffidavit == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_AntiRaggingAffidavit').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_AntiRaggingAffidavit + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head = $('input[name=Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Proforma_Fand_F1_On_DoctorsLetter_Head + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_Proforma_I = $('input[name=Student_AdmissionDocuments_Proforma_I]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Proforma_I').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Proforma_I + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_Proforma_I == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Proforma_I').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Proforma_I + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_ProformaG1 = $('input[name=Student_AdmissionDocuments_ProformaG1]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_ProformaG1').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_ProformaG1 + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_ProformaG1 == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_ProformaG1').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_ProformaG1 + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_ProformaG2 = $('input[name=Student_AdmissionDocuments_ProformaG2]:checked').val() ? true : false;
            // StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_ProformaG2').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_ProformaG2 + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_ProformaG2 == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_ProformaG2').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_ProformaG2 + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_Proforma_C_D_E = $('input[name=Student_AdmissionDocuments_Proforma_C_D_E]:checked').val() ? true : false;
            // StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Proforma_C_D_E').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Proforma_C_D_E + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_Proforma_C_D_E == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Proforma_C_D_E').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Proforma_C_D_E + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_FathersIncomeCertificate = $('input[name=Student_AdmissionDocuments_FathersIncomeCertificate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_FathersIncomeCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_FathersIncomeCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_FathersIncomeCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_FathersIncomeCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_FathersIncomeCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_AadharCardXerox = $('input[name=Student_AdmissionDocuments_AadharCardXerox]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_AadharCardXerox').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_AadharCardXerox + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_AadharCardXerox == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_AadharCardXerox').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_AadharCardXerox + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_B_WPhoto_I_card_size = $('input[name=Student_AdmissionDocuments_B_WPhoto_I_card_size]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_B_WPhoto_I_card_size').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_B_WPhoto_I_card_size + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_B_WPhoto_I_card_size == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_B_WPhoto_I_card_size').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_B_WPhoto_I_card_size + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_Colour_photo = $('input[name=Student_AdmissionDocuments_Colour_photo]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Colour_photo').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Colour_photo + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_Colour_photo == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_Colour_photo').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_Colour_photo + "</IsChecked></row>";
            }



            //For PG Students
            Data.Student_AdmissionDocuments_PGStudents_DegreeMarksheet = $('input[name=Student_AdmissionDocuments_PGStudents_DegreeMarksheet]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_PGStudents_DegreeMarksheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_PGStudents_DegreeMarksheet + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_PGStudents_DegreeMarksheet == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_PGStudents_DegreeMarksheet').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_PGStudents_DegreeMarksheet + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_PGStudents_DegreeCertificate = $('input[name=Student_AdmissionDocuments_PGStudents_DegreeCertificate]:checked').val() ? true : false;
            // StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_PGStudents_DegreeCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_PGStudents_DegreeCertificate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_PGStudents_DegreeCertificate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_PGStudents_DegreeCertificate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_PGStudents_DegreeCertificate + "</IsChecked></row>";
            }

            Data.Student_AdmissionDocuments_PGStudents_GateScoreCard = $('input[name=Student_AdmissionDocuments_PGStudents_GateScoreCard]:checked').val() ? true : false;
            // StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_PGStudents_GateScoreCard').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_PGStudents_GateScoreCard + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_PGStudents_GateScoreCard == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_PGStudents_GateScoreCard').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_PGStudents_GateScoreCard + "</IsChecked></row>";
            }
            
            Data.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate = $('input[name=Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate]:checked').val() ? true : false;
            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate + "</IsChecked></row>";
            if (Data.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate == true) {
                StudentDocumentIDs = StudentDocumentIDs + "<row><DocumentName>" + $('#Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate').attr('class') + "</DocumentName><IsChecked>" + Data.Student_AdmissionDocuments_PGStudents_SponsorshipLetterforSponsoredCandidate + "</IsChecked></row>";
            }

            //StudentDocumentFlagIDs = StudentDocumentFlagIDs + "</rows>";
            StudentDocumentIDs = StudentDocumentIDs + "</rows>";

            //StudentRegistrationForm.StudentSubmitedDocumentFlagIDs = StudentDocumentFlagIDs;
            StudentRegistrationForm.StudentSubmitedDocumentIDs = StudentDocumentIDs;

            // Data.StudentSubmitedDocumentFlagIDs = StudentRegistrationForm.StudentSubmitedDocumentFlagIDs;
            Data.StudentSubmitedDocumentIDs = StudentRegistrationForm.StudentSubmitedDocumentIDs;
            Data.Student_AdmissionDocuments_Comments = $('#Student_AdmissionDocuments_Comments').val();



            //Scholarship Documents Information 
            //Data.Student_ScholarshipDocuments_IncomeCertificateOriginal = $('input[name=Student_ScholarshipDocuments_IncomeCertificateOriginal]:checked').val() ? true : false;
            //Data.)); = $('input[name=));]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_TwelvethMarkSheet = $('input[name=Student_ScholarshipDocuments_TwelvethMarkSheet]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_AdharCard = $('input[name=Student_ScholarshipDocuments_AdharCard]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_AdmissionConfirmationLetter = $('input[name=Student_ScholarshipDocuments_AdmissionConfirmationLetter]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_AllotmentLetter = $('input[name=Student_ScholarshipDocuments_AllotmentLetter]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_BankPassBookXerox = $('input[name=Student_ScholarshipDocuments_BankPassBookXerox]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_CastCertificate = $('input[name=Student_ScholarshipDocuments_CastCertificate]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_CastValidity = $('input[name=Student_ScholarshipDocuments_CastValidity]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_Domicile = $('input[name=Student_ScholarshipDocuments_Domicile]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_Receipt = $('input[name=Student_ScholarshipDocuments_Receipt]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_GateScoreCard = $('input[name=Student_ScholarshipDocuments_GateScoreCard]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_HandicapCertificate = $('input[name=Student_ScholarshipDocuments_HandicapCertificate]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_Icardsizephoto = $('input[name=Student_ScholarshipDocuments_Icardsizephoto]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_IDProof = $('input[name=Student_ScholarshipDocuments_IDProof]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_IncomeAffidavitOriginal = $('input[name=Student_ScholarshipDocuments_IncomeAffidavitOriginal]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_JEEMainScoreCard = $('input[name=Student_ScholarshipDocuments_JEEMainScoreCard]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_Leavingcertificate = $('input[name=Student_ScholarshipDocuments_Leavingcertificate]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_ParentsFromNo16 = $('input[name=Student_ScholarshipDocuments_ParentsFromNo16]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_LastYearMarksheet = $('input[name=Student_ScholarshipDocuments_LastYearMarksheet]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_MHCETScoreCard = $('input[name=Student_ScholarshipDocuments_MHCETScoreCard]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal = $('input[name=Student_ScholarshipDocuments_LastCollegeletterAboutScholarshipOriginal]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_RationCard = $('input[name=Student_ScholarshipDocuments_RationCard]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_Colourphoto = $('input[name=Student_ScholarshipDocuments_Colourphoto]:checked').val() ? true : false;

            ////  If Applicable
            //Data.Student_ScholarshipDocuments_IfApplicable_NonCreamylayer = $('input[name=Student_ScholarshipDocuments_IfApplicable_NonCreamylayer]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother = $('input[name=Student_ScholarshipDocuments_IfApplicable_DeathcertificateFatherMother]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate = $('input[name=Student_ScholarshipDocuments_IfApplicable_DisabilityAbilityCertificate]:checked').val() ? true : false;
            //Data.Student_ScholarshipDocuments_IfApplicable_GapCertificate = $('input[name=Student_ScholarshipDocuments_IfApplicable_GapCertificate]:checked').val() ? true : false;
            //Data.Student_DTE_DTEUserID = $('#Student_ScholarshipDocuments_Comments').val();

            //Suject Ids

            Data.QualifyingExamSubjectDetailsIDs = StudentRegistrationForm.QualifyingExamSubjectDetailsIDs;
            Data.QualificationExamSubjectGeneralDetailsIDs = StudentRegistrationForm.QualificationExamSubjectGeneralDetailsIDs
            Data.QualificationExamSubjectSSCDetailsIDs = StudentRegistrationForm.QualificationExamSubjectSSCDetailsIDs
            Data.QualificationExamSubjectHSCDetailsIDs = StudentRegistrationForm.QualificationExamSubjectHSCDetailsIDs


            //HiddenFor
            Data.Student_QualifyingExamId = $('input[name=Student_QualifyingExamId]').val();
            Data.BranchDetailID = $('input[name=BranchDetailID]').val();
            Data.StandardNumber = $('input[name=StandardNumber]').val();

            Data.AdmissionPattern = $('input[name=AdmissionPattern]').val();
            Data.Student_AcademicYearId = $('input[name=Student_AcademicYearId]').val();
            Data.Student_AcademicYear = $('#Student_AcademicYear').val();
            Data.Student_CourseYearId = $('input[name=Student_CourseYearId]').val();
            Data.Student_DateofRegistration = $('#Student_DateofRegistration').val();
            Data.UniversityID = $('input[name=UniversityID]').val();
            Data.CenterCode = $('input[name=CenterCode]').val();
            Data.ToolRegistrationTemplateMstID = $('input[name=ToolRegistrationTemplateMstID]').val();
            Data.StudentSelfRegistrationID = $('input[name=StudentSelfRegistrationID]').val();
            
            if (StudentRegistrationForm.ActionName == "Save") {
                Data.IsTaskGeneratedForApproval = false;
                //Data.StudentSelfRegistrationID = $('input[name=StudentSelfRegistrationID]').val();
            }
            else if (StudentRegistrationForm.ActionName == "Submit") {
                Data.IsTaskGeneratedForApproval = true;
                Data.ID = $('input[name=ID]').val();
            }
            else {
                Data.IsTaskGeneratedForApproval = false;
                Data.ID = $('input[name=ID]').val();
            }
               
        return Data;
    },

    GetQualifyingExamSubjectDetailsDataTable: function () {
        var DataArrayQualifyingExamSubjectDetails = [];

        $("#QualifyingExamSubjectDetails input:input").each(function () {
            DataArrayQualifyingExamSubjectDetails.push($(this).val());
        });
        QualifyingExamSubjectDetailsIDs = "<rows>";
        var TotalRecord = DataArrayQualifyingExamSubjectDetails.length;
        //alert(selected);
        //alert(TotalRecord);
        for (var i = 0; i < TotalRecord; i = i + 4) {

            QualifyingExamSubjectDetailsIDs = QualifyingExamSubjectDetailsIDs + "<row><SubjectID>" + DataArrayQualifyingExamSubjectDetails[i] + "</SubjectID><SubjectName>" + DataArrayQualifyingExamSubjectDetails[i + 1] + "</SubjectName><MarkObtained>" + DataArrayQualifyingExamSubjectDetails[i + 2] + "</MarkObtained><MarkOutOf>" + DataArrayQualifyingExamSubjectDetails[i + 3] + "</MarkOutOf></row>";

        }
        StudentRegistrationForm.QualifyingExamSubjectDetailsIDs = QualifyingExamSubjectDetailsIDs + "</rows>";


    },

    GetQualificationExamSubjectGeneralDetailsDataTable: function () {
        var DataArrayQualificationExamSubjectGeneralDetails = [];

        $("#QualificationExamSubjectGeneral input:input").each(function () {
            DataArrayQualificationExamSubjectGeneralDetails.push($(this).val());
        });
        QualificationExamSubjectGeneralDetailsIDs = "<rows>";
        var TotalRecord = DataArrayQualificationExamSubjectGeneralDetails.length;
        //alert(selected);
        //alert(TotalRecord);
        for (var i = 0; i < TotalRecord; i = i + 4) {

            QualificationExamSubjectGeneralDetailsIDs = QualificationExamSubjectGeneralDetailsIDs + "<row><SubjectID>" + DataArrayQualificationExamSubjectGeneralDetails[i] + "</SubjectID><SubjectName>" + DataArrayQualificationExamSubjectGeneralDetails[i + 1] + "</SubjectName><MarkObtained>" + DataArrayQualificationExamSubjectGeneralDetails[i + 2] + "</MarkObtained><MarkOutOf>" + DataArrayQualificationExamSubjectGeneralDetails[i + 3] + "</MarkOutOf></row>";

        }
        StudentRegistrationForm.QualificationExamSubjectGeneralDetailsIDs = QualificationExamSubjectGeneralDetailsIDs + "</rows>";

        //alert(StudentRegistrationForm.QualificationExamSubjectGeneralDetailsIDs);
    },

    GetQualificationExamSubjectSSCDetailsDataTable: function () {
        var DataArrayQualificationExamSubjectSSCDetails = [];

        $("#QualificationExamSubjectSSC input:input").each(function () {
            DataArrayQualificationExamSubjectSSCDetails.push($(this).val());
        });
        QualificationExamSubjectSSCDetailsIDs = "<rows>";
        var TotalRecord = DataArrayQualificationExamSubjectSSCDetails.length;
        //alert(selected);
        //alert(TotalRecord);
        for (var i = 0; i < TotalRecord; i = i + 4) {

            QualificationExamSubjectSSCDetailsIDs = QualificationExamSubjectSSCDetailsIDs + "<row><SubjectID>" + DataArrayQualificationExamSubjectSSCDetails[i] + "</SubjectID><SubjectName>" + DataArrayQualificationExamSubjectSSCDetails[i + 1] + "</SubjectName><MarkObtained>" + DataArrayQualificationExamSubjectSSCDetails[i + 2] + "</MarkObtained><MarkOutOf>" + DataArrayQualificationExamSubjectSSCDetails[i + 3] + "</MarkOutOf></row>";

        }
        StudentRegistrationForm.QualificationExamSubjectSSCDetailsIDs = QualificationExamSubjectSSCDetailsIDs + "</rows>";

        //alert(StudentRegistrationForm.QualificationExamSubjectSSCDetailsIDs);
    },

    GetQualificationExamSubjectHSCDetailsDataTable: function () {
        var DataArrayQualificationExamSubjectHSCDetails = [];

        $("#QualificationExamSubjectHSC input:input").each(function () {
            DataArrayQualificationExamSubjectHSCDetails.push($(this).val());
        });
        QualificationExamSubjectHSCDetailsIDs = "<rows>";
        var TotalRecord = DataArrayQualificationExamSubjectHSCDetails.length;
        //alert(selected);
        //alert(TotalRecord);
        for (var i = 0; i < TotalRecord; i = i + 4) {

            QualificationExamSubjectHSCDetailsIDs = QualificationExamSubjectHSCDetailsIDs + "<row><SubjectID>" + DataArrayQualificationExamSubjectHSCDetails[i] + "</SubjectID><SubjectName>" + DataArrayQualificationExamSubjectHSCDetails[i + 1] + "</SubjectName><MarkObtained>" + DataArrayQualificationExamSubjectHSCDetails[i + 2] + "</MarkObtained><MarkOutOf>" + DataArrayQualificationExamSubjectHSCDetails[i + 3] + "</MarkOutOf></row>";

        }
        StudentRegistrationForm.QualificationExamSubjectHSCDetailsIDs = QualificationExamSubjectHSCDetailsIDs + "</rows>";

        //alert(StudentRegistrationForm.QualificationExamSubjectHSCDetailsIDs);
    },

    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {
      
        if (data == "True") {            
                alert("Registration information save sucessfully.");
                window.location.pathname = 'StudentRegistrationForm/Edit';            
        }
        else {
            alert("You Have Not Registered Successfully !!!!. Please Try Again..");
            window.location.pathname = 'StudentLogin';
        }
    },

    editSuccess: function (data) {
        
        if (data == "True") {
            alert("You have registered successfully !!!!");            
        }
        else {
            alert("You Have Not Registered Successfully !!!!. Please Try Again..");        
        }
        window.location.pathname = 'StudentLogin';
    },

    submitSuccess: function (data) {      
        if (data == "True") {
            alert("You have successfully submitted the application !!!!");
        }
        else {
            alert("You have not successfully submit the application !!!!. Please Try Again..");
        }
        window.location.pathname = 'StudentLogin';
    }

};

