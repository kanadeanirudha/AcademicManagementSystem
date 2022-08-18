//this class contain methods related to nationality functionality
var StudentQuickRegistration = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        StudentQuickRegistration.constructor();
        //StudentQuickRegistration.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });
        //$("#DateofBirth").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()'
        //});

        $('#DateofBirth').attr("readonly", true);

        $('#DateofBirth').datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,
            //yearRange: '1950:document.write(currentYear.getFullYear()'

        });

        $("#CentreCode").change(function () {
            var selectedItem = $(this).val();
            //   var selectedItem1 = $("#UniversityID");
            

            var $ddlSessionDetails = $("#AdmittedSessionID");
            var $ddlCurrentSessionDetails = $("#AcademicSessionID");

            var $SessionDetailsProgress = $("#states-loading-progress");
            var $CurrentSessionDetailsProgress = $("#states-loading-progress");
            var $ddlUniversity = $("#UniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();

            $SessionDetailsProgress.show();
            $CurrentSessionDetailsProgress.show();



            
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentQuickRegistration/GetUniversityByCentreCode",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--Select University--</option>');
                        $.each(data, function (id, option) {

                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $UniversityProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve University.');
                        $UniversityProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#UniversityID').find('option').remove().end().append('<option value>---Select University---</option>');
                $('#btnCreate').hide();
            }
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentQuickRegistration/GetAllSessionDetails",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlSessionDetails.html('');
                        $ddlSessionDetails.append('<option value="">--Select Session--</option>');
                        $.each(data, function (id, option) {

                            $ddlSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $SessionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Session.');
                        $SessionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#AdmittedSessionID').find('option').remove().end().append('<option value>---Select Session---</option>');
                $('#btnCreate').hide();
            }

            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentQuickRegistration/GetCurrentSessionDetails",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlCurrentSessionDetails.html('');
                        //   $ddlCurrentSessionDetails.append('<option value="">--Select Session--</option>');
                        $.each(data, function (id, option) {

                            $ddlCurrentSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $CurrentSessionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Session.');
                        $CurrentSessionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#AcademicSessionID').find('option').remove().end().append('<option value>---Select Session---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#BranchID").change(function () {
            var selectedItem1 = $(this).val();
            var selectedItem2 = $("#CentreCode").val();
            var selectedItem3 = $("#UniversityID").val();
            
            var $ddlSectionDetails = $("#SectionDetailID");
            var $SectionDetailsProgress = $("#states-loading-progress");
            $SectionDetailsProgress.show();
            if ($("#BranchID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentQuickRegistration/GetSectionDetails",
                    data: { "SelectedBranchID": selectedItem1, "CentreCode": selectedItem2, "UniversityID": selectedItem3 },
                    success: function (data) {
                        $ddlSectionDetails.html('');
                        $ddlSectionDetails.append('<option value="">--Select Section--</option>');
                        $.each(data, function (id, option) {
                            $ddlSectionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $SectionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Section.');
                        $SectionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SectionDetailID').find('option').remove().end().append('<option value>---Select Section---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#UniversityID").change(function () {
            var selectedItem1 = $(this).val();
            var selectedItem = $("#CentreCode").val();
            
            var $ddlBranchDetails = $("#BranchID");
            var $BranchDetailsProgress = $("#states-loading-progress");
            $BranchDetailsProgress.show();
            if ($("#UniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentQuickRegistration/GetBranchDetails",

                    data: { "CentreCode": selectedItem, "UniversityID": selectedItem1 },
                    success: function (data) {
                        $ddlBranchDetails.html('');
                        $ddlBranchDetails.append('<option value="">--Select Course--</option>');
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

        $("#IsBackStudent").change(function () {
            var selectedItem = $('input[name=IsBackStudent]:checked').val() ? true : false;
            var selectedItem2 = $("#CentreCode").val();
            
            var $ddlCurrentSessionDetails = $("#AcademicSessionID");
            var $CurrentSessionDetailsProgress = $("#states-loading-progress");
            $CurrentSessionDetailsProgress.show();

            var $ddlAdmittedSessionDetails = $("#AdmittedSessionID");
            var $AdmittedSessionDetailsProgress = $("#states-loading-progress");
            $AdmittedSessionDetailsProgress.show();

            if ($("#CentreCode").val() != "") {
                if (selectedItem == false) {

                    $.ajax({
                        cache: false,
                        type: "GET",

                        url: "/StudentQuickRegistration/GetCurrentSessionDetails",
                        data: { "CentreCode": selectedItem2 },
                        success: function (data) {
                            $ddlCurrentSessionDetails.html('');
                            //   $ddlCurrentSessionDetails.append('<option value="">--Select Session--</option>');
                            $.each(data, function (id, option) {

                                $ddlCurrentSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                            });
                            $CurrentSessionDetailsProgress.hide();
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert('Failed to retrieve Session.');
                            $CurrentSessionDetailsProgress.hide();
                        }
                    });


                    $.ajax({
                        cache: false,
                        type: "GET",

                        url: "/StudentQuickRegistration/GetAllSessionDetails",
                        data: { "CentreCode": selectedItem2 },
                        success: function (data) {
                            $ddlAdmittedSessionDetails.html('');
                            $ddlAdmittedSessionDetails.append('<option value="">--Select Session--</option>');
                            $.each(data, function (id, option) {

                                $ddlAdmittedSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                            });
                            $AdmittedSessionDetailsProgress.hide();
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert('Failed to retrieve Session.');
                            $AdmittedSessionDetailsProgress.hide();
                        }
                    });

                }
                else {

                    $.ajax({
                        cache: false,
                        type: "GET",

                        url: "/StudentQuickRegistration/GetSessionDetails",
                        data: { "CentreCode": selectedItem2 },
                        success: function (data) {
                            $ddlCurrentSessionDetails.html('');
                            $ddlCurrentSessionDetails.append('<option value="">--Select Session--</option>');
                            $.each(data, function (id, option) {

                                $ddlCurrentSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                            });
                            $CurrentSessionDetailsProgress.hide();
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert('Failed to retrieve Session.');
                            $CurrentSessionDetailsProgress.hide();
                        }
                    });

                    $.ajax({
                        cache: false,
                        type: "GET",

                        url: "/StudentQuickRegistration/GetSessionDetails",
                        data: { "CentreCode": selectedItem2 },
                        success: function (data) {
                            $ddlAdmittedSessionDetails.html('');
                            $ddlAdmittedSessionDetails.append('<option value="">--Select Session--</option>');
                            $.each(data, function (id, option) {

                                $ddlAdmittedSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                            });
                            $AdmittedSessionDetailsProgress.hide();
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert('Failed to retrieve Session.');
                            $AdmittedSessionDetailsProgress.hide();
                        }
                    });
                }
            }
            else {
                $('#myDataTable tbody').empty();
                $('#AcademicSessionID').find('option').remove().end().append('<option value>---Select Session---</option>');
                $('#btnCreate').hide();
            }


        });



        // Create new record

        $('#EditStudentQuickRegistrationRecord').on("click", function () {
             
            StudentQuickRegistration.ActionName = "Edit";
            StudentQuickRegistration.AjaxCallStudentQuickRegistration();
            
        });

        $('#MiddleName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentMobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#FirstName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#LastName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MotherName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#StudentEmailID').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

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

        InitAnimatedBorder();
        CloseAlert();
        //$(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/StudentQuickRegistration/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallStudentQuickRegistration: function () {
        var StudentQuickRegistrationData = null;
        if (StudentQuickRegistration.ActionName == "Edit") {
            
            $("#FormEditStudentQuickRegistration").validate();
            if ($("#FormEditStudentQuickRegistration").valid()) {
                
                StudentQuickRegistrationData = null;
                StudentQuickRegistrationData = StudentQuickRegistration.GetStudentQuickRegistration();
                ajaxRequest.makeRequest("/StudentQuickRegistration/Index", "POST", StudentQuickRegistrationData, StudentQuickRegistration.Success);
                StudentQuickRegistrationData = StudentQuickRegistration.Reset();
               
            }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetStudentQuickRegistration: function () {
        var Data = {
        };
        if (StudentQuickRegistration.ActionName == "Create" || StudentQuickRegistration.ActionName == "Edit") {
            
            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.UniversityID = $('#UniversityID').val();
            Data.BranchID = $('#BranchID').val();
          
            Data.AdmissionPattern = $('#AdmissionPattern').val();
            Data.AcademicSessionID = $('#AcademicSessionID').val();
            Data.AdmittedSessionID = $('#AcademicSessionID').val();
            //alert($('#AcademicSessionID').text());
            Data.AdmitAcademicYear = $('#AcademicSessionID').text();
            Data.SectionDetailID = $('#SectionDetailID').val();
            //data.AcademicYear = $('#AcademicYear').val();
            Data.Title = $('#Title').val();
            Data.FirstName = $('#FirstName').val();
            Data.MiddleName = $('#MiddleName').val();
            Data.LastName = $('#LastName').val();
            Data.MotherName = $('#MotherName').val();
            Data.StudentEmailID = $('#StudentEmailID').val();
            Data.StudentMobileNumber = $('#StudentMobileNumber').val();
            Data.DateofBirth = $('#DateofBirth').val();
            Data.StudentCode = $('#StudentCode').val();
            Data.CourseYearId = $('#CourseYearId').val();
            Data.studentAddress = $('#studentAddress').val();
            Data.IsBackStudent = $('input[name=IsBackStudent]:checked').val() ? true : false;

            Data.Male = $('#Male').val();

            if ($('#Male').is(':checked')) {
                Data.StudentGender = "M";
            }
            else if ($('#Female').is(':checked')) {
                Data.StudentGender = "F";
            }
        }
        else if (StudentQuickRegistration.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        //$('#SuccessMessage').html(splitData[0]);
        //$('#SuccessMessage').delay(400).slideDown(400).delay(3000).slideUp(400).css('background-color', splitData[1]);
        notify(splitData[0],"success");
    },

    Reset: function (data) {
        $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
        $('input:checkbox,input:radio').removeAttr('checked');
        $('#CentreCode').focus();
        $('#Title').val("");
        $('#FirstName').val("");
        $('#MiddleName').val("");
        $('#LastName').val("");
        $('#MotherName').val("");
        $('#StudentEmailID').val("");
        $('#StudentCode').val("");
        $('#StudentMobileNumber').val("");
        $('#CentreCode').val("");
        $('#Male').is(':checked');
        $('#IsBackStudent').removeAttr('checked');
        $('#UniversityID').find('option').remove().end().append('<option value>--Select University--</option>');
        $('#BranchID').find('option').remove().end().append('<option value>---Select Course--</option>');
        $('#AdmissionPattern').val("");
        $('#AdmittedSessionID').find('option').remove().end().append('<option value>---Select Session--</option>');

        $('#AcademicSessionID').find('option').remove().end().append('<option value>---Select Session--</option>');
        $('#SectionDetailID').find('option').remove().end().append('<option value>---Select section--</option>');
        return false;

    }


    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        StudentQuickRegistration.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {


    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        StudentQuickRegistration.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

