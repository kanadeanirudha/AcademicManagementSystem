//this class contain methods related to nationality functionality
var StudentIdentityCard = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        StudentIdentityCard.constructor();
        //StudentIdentityCard.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {




        $("#DateOfBirth").datepicker({
            numberOfMonths: 1,
            dateFormat: 'dd-MM-yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '1950:document.write(currentYear.getFullYear()'
        });
        $("#CentreCode").change(function () {
            var selectedItem = $(this).val();


            var $ddlCurrentSessionDetails = $("#AcademicYear");
            var $CurrentSessionDetailsProgress = $("#states-loading-progress");
            var $ddlUniversity = $("#UniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            $CurrentSessionDetailsProgress.show();




            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentIdentityCard/GetUniversityByCentreCode",

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
                    url: "/StudentIdentityCard/GetCurrentSessionDetails",

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
                $('#AcademicYear').find('option').remove().end().append('<option value>---Select Session---</option>');
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
                    url: "/StudentIdentityCard/GetSectionDetails",
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

        $("#SectionDetailID").change(function () {
            var selectedItem1 = $(this).val();
            if (selectedItem1 != "") {
                $("#ShowStudentList").fadeIn(1000);

            }
            else {
                $("#DivStudentListInfo").fadeOut(1000);
                $("#ShowStudentList").fadeOut(1000);
            }
        });

        // Create new record



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
                    url: "/StudentIdentityCard/GetBranchDetails",

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
                $('#BranchID').find('option').remove().end().append('<option value>---Select Branch---</option>');
                $('#btnCreate').hide();
            }
        });
        $('#ShowStudentList').on("click", function () {
            var selectedItem1 = $("#SectionDetailID").val();
            var selectedItem2 = $("#CentreCode").val();
            var selectedItem3 = $("#AcademicYear").val();

            //$('#myDataTable').load('/StudentIdentityCard/AjaxHandler?sectionDetailsID=' + selectedItem1 + '&centreCode=' + selectedItem2 + '&AcademicYear=' + selectedItem3,);
            $.ajax({
                cache: false,
                type: "GET",
                url: "/StudentIdentityCard/StudentList",
                data: { "sectionDetailsID": selectedItem1, "centreCode": selectedItem2, "AcademicYear": selectedItem3 },
                success: function (data) {
                    $("#DivStudentListInfo").fadeIn(1000);
                    $('#StudentListDiv').html(data);
                },

            });

        });


        $('#EditStudentIdentityCardRecord').on("click", function () {

            StudentIdentityCard.ActionName = "Edit";
            StudentIdentityCard.AjaxCallStudentIdentityCard();
        });


        $('#StudentMobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
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


    },
    //LoadList method is used to load List page
    //LoadList: function () {

    //    $.ajax(

    //     {

    //         cache: false,
    //         type: "POST",

    //         dataType: "html",
    //         url: '/StudentIdentityCard/List',
    //         success: function (data) {
    //             //Rebind Grid Data
    //             $('#ListViewModel').html(data);
    //         }
    //     });
    //},

    //Fire ajax call to insert update and delete record
    AjaxCallStudentIdentityCard: function () {
        var StudentIdentityCardData = null;
        if (StudentIdentityCard.ActionName == "Edit") {
            $("#FormEditStudentIdentityCard").validate();
            if ($("#FormEditStudentIdentityCard").valid()) {
                StudentIdentityCardData = null;
                StudentIdentityCardData = StudentIdentityCard.GetStudentIdentityCard();
                ajaxRequest.makeRequest("/StudentIdentityCard/Index", "POST", StudentIdentityCardData, StudentIdentityCard.Success);
            }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetStudentIdentityCard: function () {
        var Data = {
        };
        if (StudentIdentityCard.ActionName == "Create" || StudentIdentityCard.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.UniversityID = $('#UniversityID').val();
            Data.BranchID = $('#BranchID').val();
            Data.AdmissionPattern = $('#AdmissionPattern').val();
            Data.AcademicSessionID = $('#AcademicSessionID').val();
            Data.AdmittedSessionID = $('#AdmittedSessionID').val();
            Data.SectionDetailID = $('#SectionDetailID').val();
            Data.Title = $('#Title').val();
            Data.FirstName = $('#FirstName').val();
            Data.MiddleName = $('#MiddleName').val();
            Data.LastName = $('#LastName').val();
            Data.MotherName = $('#MotherName').val();
            Data.StudentEmailID = $('#StudentEmailID').val();
            Data.StudentMobileNumber = $('#StudentMobileNumber').val();
            Data.DateofBirth = $('#DateofBirth').val();
            Data.StudentCode = $('#StudentCode').val();
            Data.IsBackStudent = $('input[name=IsBackStudent]:checked').val() ? true : false;

            Data.Male = $('#Male').val();

            if ($('#Male').is(':checked')) {
                Data.StudentGender = "M";
            }
            else if ($('#Female').is(':checked')) {
                Data.StudentGender = "F";
            }
        }
        else if (StudentIdentityCard.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        if (data != null) {
            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            //$('input:checkbox,input:radio').removeAttr('checked');
            //$('#Title').focus();
            //$('#Title').val("");
            //$('#CenterCode').val("");

            //$('#UniversityID').val("");
            return false;

        } else {

        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {



    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        StudentIdentityCard.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        StudentIdentityCard.ReloadList("Record Deleted Sucessfully.");
    //      //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

