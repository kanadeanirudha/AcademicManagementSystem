//this class contain methods related to nationality functionality
var OnlineExamExaminationCourseApplicable = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
   
        OnlineExamExaminationCourseApplicable.constructor();
        //OnlineExamExaminationCourseApplicable.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CourseYearID').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });
        $(function () {

            $('#ExaminationStartDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                //defaultDate: new Date(),
            });
            $("#ExaminationEndDate").datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
            })
            $('#ExaminationStartDate').on('dp.hide', function (e) {
                var minDate = new Date(e.date.valueOf());
                minDate.setDate(minDate.getDate());
                $("#ExaminationEndDate").data("DateTimePicker").minDate(minDate);

            })

            $("#ResultAnnounceDate").datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
            })

            
            $('#ExaminationEndDate').on('dp.hide', function (e) {
                var minDate = new Date(e.date.valueOf());
                minDate.setDate(minDate.getDate());
                $("#ResultAnnounceDate").data("DateTimePicker").minDate(minDate);

            })

        });


        // Create new record

        $('#CreateOnlineExamExaminationCourseApplicableRecord').on("click", function () {

            OnlineExamExaminationCourseApplicable.ActionName = "Create";
            OnlineExamExaminationCourseApplicable.AjaxCallOnlineExamExaminationCourseApplicable();
        });

        //$('#EditOnlineExamExaminationCourseApplicableRecord').on("click", function () {

        //    OnlineExamExaminationCourseApplicable.ActionName = "Edit";
        //    OnlineExamExaminationCourseApplicable.AjaxCallOnlineExamExaminationCourseApplicable();
        //});

        $('#DeleteOnlineExamExaminationCourseApplicableRecord').on("click", function () {

            OnlineExamExaminationCourseApplicable.ActionName = "Delete";
            OnlineExamExaminationCourseApplicable.AjaxCallOnlineExamExaminationCourseApplicable();
        });

        //$('#LevelDescription').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //$('#LevelCode').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});

        InitAnimatedBorder();

        CloseAlert();

        //For On click Event of Course Year , Semester Display 

        $("#CourseYearID").change(function () {
            //debugger;
            //debugger;

            var selectedListItem = $(this).val();
            var $ddlSemester = $("#Semester");
            var $SemesterProgress = $("#states-loading-progress");
           // $SemesterProgress.show();
           // alert($("#CourseYearID").val())
            if ($("#CourseYearID").val() > 0) {
                $.ajax({

                    cache: false,
                    type: "POST",
                    url: "/OnlineExamExaminationCourseApplicable/GetSemesterByCourseYear",

                    data: { "CourseYearID": selectedListItem },
                    success: function (data) {
                        $ddlSemester.html('');
                        $ddlSemester.append('<option value="">----Select Semester----</option>');
                        $.each(data, function (id, option) {

                            $ddlSemester.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $SemesterProgress.hide();
                    },

                    error: function (xhr, ajaxOptions, thrownError) {

                        alert('Failed to retrieve Semester.');
                        $SemesterProgress.hide();
                    }
                });



            }
            else 
            {
                $('#myDataTable tbody').empty();
                $('#Semester').find('option').remove().end().append('<option value>--Select Semester--</option>');

               

            }


            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');

        });

        $("#CourseYearID").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });

        /////second ajax call for department/////////////////////////

        //$("#ExaminationStatusID").change(function () {
        //    var selectedListItemID = $(this).val();
        //    alert(selectedListItemID);
        //});


        $("#CourseYearID").change(function () {
            //var selectedListItemID = $(this).val();
            //alert(selectedListItemID);
            debugger;
            //debugger;

            var selectedListItem = $(this).val();
            var $ddlDepartmentID = $("#DepartmentID");
            var $DepartmentIDProgress = $("#states-loading-progress");
            $DepartmentIDProgress.show();
           // alert($("#CourseYearID").val())
            if ($("#CourseYearID").val() > 0) {
                $.ajax({

                    cache: false,
                    type: "POST",
                    url: "/OnlineExamExaminationCourseApplicable/GetDepartmentByCourseYear",

                    data: { "CourseYearID": selectedListItem },
                    success: function (data) {
                        $ddlDepartmentID.html('');
                        $ddlDepartmentID.append('<option value="">----Select Department----</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartmentID.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $DepartmentIDProgress.hide();
                    },

                    error: function (xhr, ajaxOptions, thrownError) {

                        alert('Failed to retrieve Department.');
                        $DepartmentIDProgress.hide();
                    }
                });



            }
            else {
                $('#myDataTable tbody').empty();
                $('#DepartmentID').find('option').remove().end().append('<option value>--Select Department--</option>');



            }


            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');

        });

        $("#CourseYearID").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });

   
        ////end second ajax///////////


        //   $('#CountryName').on("keydown", function (e) {
        //AMSValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
        // });
        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        // $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {
       debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/OnlineExamExaminationCourseApplicable/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
       // debugger;
        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/OnlineExamExaminationCourseApplicable/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallOnlineExamExaminationCourseApplicable: function () {
        var OnlineExamExaminationCourseApplicableData = null;

        if (OnlineExamExaminationCourseApplicable.ActionName == "Create") {
            debugger;
            $("#FormCreateOnlineExamExaminationCourseApplicable").validate();
            ($("#FormCreateOnlineExamExaminationCourseApplicable").valid())
            {
                OnlineExamExaminationCourseApplicableData = null;
                OnlineExamExaminationCourseApplicableData = OnlineExamExaminationCourseApplicable.GetOnlineExamExaminationCourseApplicable();
                ajaxRequest.makeRequest("/OnlineExamExaminationCourseApplicable/Create", "POST", OnlineExamExaminationCourseApplicableData, OnlineExamExaminationCourseApplicable.Success, "CreateOnlineExamExaminationCourseApplicableRecord");
            }
        }
            //else if (OnlineExamExaminationCourseApplicable.ActionName == "Edit") {
            //    $("#FormEditOnlineExamExaminationCourseApplicable").validate();
            //    if ($("#FormEditOnlineExamExaminationCourseApplicable").valid()) {
            //        OnlineExamExaminationCourseApplicableData = null;
            //        OnlineExamExaminationCourseApplicableData = OnlineExamExaminationCourseApplicable.GetOnlineExamExaminationCourseApplicable();
            //        ajaxRequest.makeRequest("/OnlineExamExaminationCourseApplicable/Edit", "POST", OnlineExamExaminationCourseApplicableData, OnlineExamExaminationCourseApplicable.Success);
            //    }
            //}
        else if (OnlineExamExaminationCourseApplicable.ActionName == "Delete") {
            debugger;
            OnlineExamExaminationCourseApplicableData = null;
            $("#FormCreateOnlineExamExaminationCourseApplicable").validate();
            OnlineExamExaminationCourseApplicableData = OnlineExamExaminationCourseApplicable.GetOnlineExamExaminationCourseApplicable();
            ajaxRequest.makeRequest("/OnlineExamExaminationCourseApplicable/Delete", "POST", OnlineExamExaminationCourseApplicableData, OnlineExamExaminationCourseApplicable.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExamExaminationCourseApplicable: function () {
        debugger;
        var Data = {
        };

        if (OnlineExamExaminationCourseApplicable.ActionName == "Create") {

            Data.ID = $('#ID').val();
            Data.OnlineExamExaminationMasterId = $('#OnlineExamExaminationMasterId').val();
            Data.CourseYearID = $('#CourseYearID').val();
            //Data.SemesterMstID = $('#SemesterMstID').val();
            Data.SemesterMstID = $('#Semester').val();
            
            Data.DepartmentID = $('#DepartmentID').val();
            Data.ExaminationStatus = $('#ExaminationStatusID').val();
            Data.ExaminationStartDate = $('#ExaminationStartDate').val();
            Data.ExaminationEndDate = $('#ExaminationEndDate').val();
            Data.ResultAnnounceDate = $('#ResultAnnounceDate').val();
            // Data.IsActive = $("#IsActive").is(":checked") ? "true" : "false";

            //Data for OnlineExamExaminationMaster
            Data.ID = $('#ID').val();
            Data.ExaminationName = $('#ExaminationName').val();
            //Data.Purpose = $('#Purpose').val();
            //Data.AcadSessionId = $('#AcadSessionId').val();
            //Data.ExaminationFor = $('#ExaminationFor').val();
        }
        else if (OnlineExamExaminationCourseApplicable.ActionName == "Delete") {
            debugger;
            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            OnlineExamExaminationCourseApplicable.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       OnlineExamExaminationCourseApplicable.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        OnlineExamExaminationCourseApplicable.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


