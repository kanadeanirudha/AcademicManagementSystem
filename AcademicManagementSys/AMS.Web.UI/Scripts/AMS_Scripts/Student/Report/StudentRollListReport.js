//this class contain methods related to nationality functionality
var StudentRollListReport = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
    
        StudentRollListReport.constructor();
     
    },
    //Attach all event of page
    constructor: function () {
        $('#btnStudentRollListReportSubmit').on("click", function () {
            $("#IsPosted").val(true);
        });


        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();


            var $ddlCurrentSessionDetails = $("#SelectedAcademicYear");
            var $CurrentSessionDetailsProgress = $("#states-loading-progress");
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            $CurrentSessionDetailsProgress.show();




            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRollListReport/GetUniversityByCentreCode",

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
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---Select University---</option>');
                $('#btnCreate').hide();
            }
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRollListReport/GetAllSessionDetails",

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
                $('#SelectedAcademicYear').find('option').remove().end().append('<option value>---Select Session---</option>');
                $('#btnCreate').hide();
            }
        });



        $("#SelectedSectionDetailID").change(function () {
            var selectedItem1 = $(this).val();
            if (selectedItem1 != "") {
                $("#divShowStudentList").fadeIn(1000);

            }
            else {
                //   $("#DivStudentListInfo").fadeOut(1000);
                $("#divShowStudentList").fadeOut(1000);
            }
        });



        $("#Course_Section").change(function () {
            var selectedItem1 = $(this).val();
            if (selectedItem1 == "C") {
                $("#DivSectionLable").fadeOut(0);
                $("#DivSectionDropDown").fadeOut(0);

                $("#DivCourseYearLable").fadeIn(0);
                $("#DivCourseYearDropDown").fadeIn(0);
                //   $("#DivReportType").fadeIn(0);


            }
            else {
                $("#DivSectionLable").fadeIn(0);
                $("#DivSectionDropDown").fadeIn(0);
                //   $("#DivReportType").fadeOut(0);
                $("#DivCourseYearLable").fadeOut(0);
                $("#DivCourseYearDropDown").fadeOut(0);
            }
        });
        // Create new record



        $("#SelectedUniversityID").change(function () {

            var selectedItem1 = $(this).val();
            var selectedItem = $("#SelectedCentreCode").val();

            var $ddlCourseYearDetails = $("#SelectedCourseYearId");
            var $CourseYearDetailsProgress = $("#states-loading-progress");
            $CourseYearDetailsProgress.show();

            var $ddlSectionDetails = $("#SelectedSectionDetailID");
            var $SectionDetailsProgress = $("#states-loading-progress");
            $SectionDetailsProgress.show();

            if ($("#SelectedUniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRollListReport/GetSectionDetails",
                    data: { "CentreCode": selectedItem, "UniversityID": selectedItem1 },
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
                $('#SelectedSectionDetailID').find('option').remove().end().append('<option value>---Select Section---</option>');
                $('#btnCreate').hide();
            }


         
            if ($("#SelectedUniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentRollListReport/GetCourseYearDetails",

                    data: { "CentreCode": selectedItem, "UniversityID": selectedItem1 },
                    success: function (data) {
                        $ddlCourseYearDetails.html('');
                        $ddlCourseYearDetails.append('<option value="">--Select Course Year--</option>');
                        $.each(data, function (id, option) {

                            $ddlCourseYearDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $CourseYearDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Branch.');
                        $CourseYearDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedCourseYearId').find('option').remove().end().append('<option value>---Select Course Year---</option>');
                $('#btnCreate').hide();
            }
        });




        $('#ShowStudentList').on("click", function () {
         
            var SelectedCentreCode = $("#SelectedCentreCode").val();
            var SelectedUniversityID = $("#SelectedUniversityID").val();
            var Course_Section = $("#Course_Section").val();
         
            if (Course_Section == "S") {
                var SelectedSectionDetailID = $("#SelectedSectionDetailID").val();
                var SelectedCourseYearId = 0;
            }
            else {
                var SelectedSectionDetailID = 0;
                var SelectedCourseYearId = $("#SelectedCourseYearId").val();
            }
            var SelectedAcademicYear = $("#SelectedAcademicYear").val();
            var AdmissionStatus = $("#AdmissionStatus").val();
            var SortOrder = $("#AdmissionStatus").val();
            var ReportType = $('input[name=ReportType]:checked').val() ? true : false;

            StudentRollListReport.LoadList111(SelectedCentreCode, SelectedUniversityID, SelectedSectionDetailID, SelectedCourseYearId, SelectedAcademicYear, AdmissionStatus, SortOrder, ReportType);


        });


        $('#IsAllCourse').change(function () {
            if (this.checked) {
               $('#DivCourseSection').fadeOut('slow');
            }
            else {
                $('#DivCourseSection').fadeIn('slow');
            }

        });
    },

};

