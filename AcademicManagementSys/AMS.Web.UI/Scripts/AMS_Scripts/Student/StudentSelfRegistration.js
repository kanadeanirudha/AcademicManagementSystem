//this class contain methods related to nationality functionality
var StudentSelfRegistration = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        StudentSelfRegistration.constructor();
        //StudentSelfRegistration.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



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

        //$("#DateOfBirth").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd M yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()'           
        //});

       

        //var confirmCheck1 = $('input[name=confirmCheck1]:checked').val() ? true : false;
        //var checkChecbox = $('input[name=confirmCheck]:checked').val() ? true : false;

        $('#confirmCheck').change(function () {
            if (this.checked) {

                $('#confirmCheck1').attr("disabled", false);
                $('#enbldisbl').removeClass("disabled");

            }
            else {
                $('#divagreementpage').hide(true);
                $('#confirmCheck1').prop('checked', false);
                $('#confirmCheck1').attr("disabled", true);
                $('#enbldisbl').addClass("disabled");

            }

        });





        $('#confirmCheck1').change(function () {
            if (this.checked) {

                $('#divagreementpage').show(true);

            }
            else {
                $('#divagreementpage').hide(true);
            }

        });




        /*
       assigning keyup event to password field
       so everytime user type code will execute
   */

        $("#Password").on("keyup", (function () {
            
            $('#result').html(StudentSelfRegistration.checkStrength($('#Password').val()))
        })
        );

        // select for University
        $("#CenterCode").change(function () {
            
            var selectedItem = $(this).val();
            var $ddlUniversity = $("#UniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            if ($("#CenterCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentSelfRegistration/GetUniversityByCentreCode",
                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--Select University--</option>');

                        $.each(data, function (id, option) {

                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));

                        });
                        $UniversityProgress.hide();
                        $('#BranchDetailID').find('option').remove().end().append('<option value>--Select Branch--</option>');
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve University.');
                        $UniversityProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#UniversityID').find('option').remove().end().append('<option value>--Select University--</option>');
                $('#BranchDetailID').find('option').remove().end().append('<option value>--Select Branch--</option>');           
                // $('#btnCreate').hide();
            }
        });


        // select for Branch 
        $("#UniversityID").change(function () {
            var selectedItem = $(this).val();
            var centreCode = $("#CenterCode").val();
            var $ddlBranchDetails = $("#BranchDetailID");
            var $BranchDetailsProgress = $("#states-loading-progress");
            $BranchDetailsProgress.show();
            if ($("#UniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentSelfRegistration/GetBranchDetailByUniversityIDAndCentreCode",
                    data: { "SelectedUniversityID": selectedItem, "SelectedCentreCode": centreCode },
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
                $('#BranchDetailID').find('option').remove().end().append('<option value>--Select Branch--</option>');
                $('#btnCreate').hide();
            }
        });

        $("#BranchDetailID").change(function () {
            var selectedItem = $(this).val();
            var $ddlStandardNumber = $("#StandardNumber");
            var $StandardNumberProgress = $("#states-loading-progress");
            $StandardNumberProgress.show();
            if ($("#BranchDetailID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentSelfRegistration/GetStandardNumberByBranchDetailID",
                    data: { "SelectedBranchDetailID": selectedItem},
                    success: function (data) {
                        $ddlStandardNumber.html('');
                        $ddlStandardNumber.append('<option value="">--Select Standard--</option>');
                        $("#AdmissionPattern").prop('disabled', false);
                        $("#AdmissionPattern option[value='1']").remove();
                        $("#AdmissionPattern option[value='']").remove();
                        $.each(data, function (id, option) {

                            $ddlStandardNumber.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $StandardNumberProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Branch.');
                        $StandardNumberProgress.hide();
                    }
                });
            }
            else {
                
                $('#myDataTable tbody').empty();
                $ddlStandardNumber.html('');
                $ddlStandardNumber.append('<option value="">--Select Standard--</option>');
                $("#AdmissionPattern").prop('disabled', false);
                $("#AdmissionPattern option[value='1']").remove();
                $("#AdmissionPattern option[value='']").remove();
                $('#btnCreate').hide();
            }
        });
        // select for Region
        // select for Branch 
        $("#CountryID").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlRegionDetails = $("#RegionID");
            var $RegionDetailsProgress = $("#states-loading-progress");
            $RegionDetailsProgress.show();
            if ($("#CountryID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentSelfRegistration/GetGeneralRegionDetailByCountryID",

                    data: { "SelectedCountryID": selectedItem },
                    success: function (data) {
                        $ddlRegionDetails.html('');
                        $ddlRegionDetails.append('<option value="">--Select Region--</option>');
                        $.each(data, function (id, option) {

                            $ddlRegionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlRegionDetails.append('<option value="0">Other</option>');
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
                $('#RegionDetailID').find('option').remove().end().append('<option value>--Select Region--</option>');
                $('#btnCreate').hide();
            }
        });


        //for Caste

        $("#CategoryID").change(function () {
            var selectedItem = $(this).val();
            
            var $ddlCasteDetails = $("#CasteID");
            var $CasteDetailsProgress = $("#states-loading-progress");
            $CasteDetailsProgress.show();
            if ($("#CategoryID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentSelfRegistration/GetCastByCategoryID",

                    data: { "SelectedCategoryID": selectedItem },
                    success: function (data) {
                        $ddlCasteDetails.html('');
                        $ddlCasteDetails.append('<option value="">--Select Caste--</option>');
                        $.each(data, function (id, option) {

                            $ddlCasteDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlCasteDetails.append('<option value="0">Other</option>');
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
                $('#RegionDetailID').find('option').remove().end().append('<option value>--Select Region--</option>');
                $('#btnCreate').hide();
            }
        });

        $("#EmailID").focusout(function () {
            var emailID = $("#EmailID").val();
            if (emailID != '' && emailID.length > 5) {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentSelfRegistration/EmailVerification",
                    data: { "EmailID": emailID },
                    success: function (data) {
                        if (data == false) {
                            alert("Someone already has that username. Try another.");
                            $("#EmailID").val("")
                            $("#EmailID").focus();
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to verify Email ID');
                    }
                });
            }
        });


        // for Gender
        $("#RegionID").change(function () {
            
            var selectedRegionID = $(this).val();
            if (selectedRegionID == "0") {
                $("#OtherRegionDiv").show(true);
            }
            else {
                $("#OtherRegionDiv").hide(true);
            }

        });
        // for Gender
        //$("#Title").change(function () {
        //    
        //    var selectedTitle = $(this).val();
        //    if (selectedTitle == "Mr.") {
        //        $("#Male").prop('checked', true);
        //    }
        //    else {
        //        $("#Female").prop('checked', true);
        //    }

        //});
        // for Admission Pattern
        $("#StandardNumber").change(function () {
            
            var length = $('#AdmissionPattern > option').length;
            var selectedStandardNumber = $(this).val();
            if (selectedStandardNumber == "1") {
                $("#AdmissionPattern").prop('disabled', true);
                $("#AdmissionPattern").append($('<option></option>').val("1").html("New"));
                $('#AdmissionPattern').val("1");
                $("#AdmissionPattern option[value='2']").remove();
                $("#AdmissionPattern option[value='3']").remove();
                //    $("#AdmissionPattern option[value='4']").remove();

            }
            else {
                if (length == 1) {
                    $("#AdmissionPattern").prop('disabled', false);
                    $("#AdmissionPattern option[value='1']").remove();
                    $("#AdmissionPattern option[value='']").remove();
                    // $("#AdmissionPattern").append($('<option></option>').val("4").html("--Select Admission Pattern--"));
                    $("#AdmissionPattern").append($('<option></option>').val("3").html("Direct"));
                    $("#AdmissionPattern").append($('<option></option>').val("2").html("Tranfary"));

                }
                else if (length == 0) {
                    $("#AdmissionPattern").append($('<option></option>').val("3").html("Direct"));
                    $("#AdmissionPattern").append($('<option></option>').val("2").html("Tranfary"));
                }
            }

        });

        //Code for searchList
        //$("#FirstName").autocomplete({

        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/StudentSelfRegistration/GetLocationList",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, maxResults: 10}, //1 for current year student
        //            //{ term: request.term, maxResults: 10, courseYearID: $("#SelectedCourseYearId :selected").val(), sectionDetailID: $("#SelectedSectionDetailID :selected").val(), SessionID: $("#SelectedAcademicYear :selected").val() }, //1 for current year student
        //            success: function (data) {
        //                //alert(data)
        //                response($.map(data, function (item) {
        //                    return { label: item.LocationAddress, value: item.LocationAddress, id: item.id };

        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        //alert(ui.item.id);
        //        $(this).val(ui.item.label);                                             // display the selected text
        //       // $("#StudentId").val(ui.item.id);
        //    }
        //});
        //code end for searchlist

        // Create new record
        $('#CreateStudentSelfRegistrationRecord').on("click", function () {
            StudentSelfRegistration.ActionName = "Create";
            
            if ($('#Password').val() != $('#pass2').val()) {
                alert("password does not match!");
                return false;
            }
            else {
                
                StudentSelfRegistration.AjaxCallStudentSelfRegistration();
            }
            
        });
        $('#ContactNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable.fnFilter(this.value);
        });
        $('#Password').on("keydown", function (e) {
            $('#pass2').val("");


            var pass2 = document.getElementById('pass2');
            var message = document.getElementById('confirmMessage');
            var resultMessage = document.getElementById('result');
            var goodColor = "#ffffff";
            
            pass2.style.backgroundColor = goodColor;
            message.style.color = goodColor;
            message.innerHTML = "";
            resultMessage.innerHTML = "";



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

        $("#FirstName").on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $("#MiddleName").on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $("#LastName").on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

    },


    //Fire ajax call to insert update and delete record
    AjaxCallStudentSelfRegistration: function () {
        var StudentSelfRegistrationData = null;
       
        if (StudentSelfRegistration.ActionName == "Create") {
            $("#FormCreateStudentSelfRegistration").validate();
            if ($("#FormCreateStudentSelfRegistration").valid()) {
                $('#CreateStudentSelfRegistrationRecord').attr("disabled", true);
                StudentSelfRegistrationData = null;
                StudentSelfRegistrationData = StudentSelfRegistration.GetStudentSelfRegistration();
                ajaxRequest.makeRequest("/StudentSelfRegistration/Create", "POST", StudentSelfRegistrationData, StudentSelfRegistration.createSuccess, "CreateStudentSelfRegistrationRecord");
            }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetStudentSelfRegistration: function () {
        var Data = {
        };

        if (StudentSelfRegistration.ActionName == "Create") {
            Data.Title = $('#Title').val();
            Data.FirstName = $('#FirstName').val();
            Data.MiddleName = $('#MiddleName').val();
            Data.SelectedCountryID = $('#SelectedCountryID').val();
            Data.SelectedCasteID = $('#SelectedCasteID ').val();



            Data.LastName = $('#LastName').val();
            Data.EmailID = $('#EmailID').val();
            Data.Password = $('#Password').val();
            Data.Male = $('#Male').val();

            if ($('#Male').is(':checked')) {
                Data.Gender = "M";
            }
            else if ($('#Female').is(':checked')) {
                Data.Gender = "F";
            }

            Data.DateOfBirth = $('#DateOfBirth').val();
            Data.ContactNumber = $('#ContactNumber').val();
            Data.CenterCode = $('#CenterCode').val();
            Data.UniversityID = $('#UniversityID').val();
            Data.BranchDetailID = $('#BranchDetailID').val();
            Data.StandardNumber = $('#StandardNumber').val();
            Data.AdmissionPattern = $('#StandardNumber').val();



            //if ($('#New').is(':checked')) {
            //    Data.AdmissionPattern = "1";
            //}
            //else 
            //if ($('#Transfary').is(':checked')) {
            //    Data.AdmissionPattern = "2";
            //}
            //else if ($('#Direct').is(':checked')) {
            //    Data.AdmissionPattern = "3";
            //}

        }

        return Data;
    },



    //For Check Strength

    checkStrength: function (password) {
        //initial strength
        var strength = 0
        var goodColor = "#66cc66";
        var badColor = "#ff6666";
        //if the password length is less than 6, return message.
        if (password.length < 6) {
            $('#result').removeClass()
            $('#result').addClass('short')
            return 'Too short'
        }

        //length is ok, lets continue.

        //if length is 8 characters or more, increase strength value
        if (password.length > 7) strength += 1

        //if password contains both lower and uppercase characters, increase strength value
        if (password.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/)) strength += 1

        //if it has numbers and characters, increase strength value
        if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) strength += 1

        //if it has one special character, increase strength value
        if (password.match(/([!,%,&,@,#,$,^,*,?,_,~])/)) strength += 1

        //if it has two special characters, increase strength value
        if (password.match(/(.*[!,%,&,@,#,$,^,*,?,_,~].*[!,%,&,@,#,$,^,*,?,_,~])/)) strength += 1

        //now we have calculated strength value, we can return messages

        //if value is less than 2
        if (strength < 2) {
            $('#result').removeClass()
            $('#result').addClass('weak')
            return 'Weak'
        }
        else if (strength == 2) {
            $('#result').removeClass()
            $('#result').addClass('good')
            return 'Good'
        }
        else {
            $('#result').removeClass()
            $('#result').addClass('strong')
            return 'Strong'
        }
    },


    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {
        
        if (data == "True") {

            //debugger;

            //alert("You Have Registered Sucessfully...   And UserID & Password Send on your Mail...");
            var FirstName =  $('#FirstName').val();
            var EmailID =  $('#EmailID').val();
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
            $.ajax({
                cache: false,
                type: "GET",
                url: "/StudentSelfRegistration/RegistrationConfirmation",
                data: { "EmailID": EmailID, "FirstName": FirstName },
                success: function (data) {
                    $('#ViewData').html(data);
                },
            });
            //   alert("You Have Registered Sucessfully...!And UserID & Password Send on your Mail...!");
            //  window.location.href = 'http://localhost:1079/StudentLogin';
        }
        else {

            //alert("You Have Not Registered Successfully !!!!. Please Try Again..");

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
            alert("You Have Not Registered Successfully !!!!. Please Try Again..");
        }
    },
};

