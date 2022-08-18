//this class contain methods related to nationality functionality
var OnlineExamSubjectGroupSchedule = {
    //Member variables
    ActionName: null,
    SelectedXMLstring: null,
    map: {},
    map2: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExamSubjectGroupSchedule.constructor();
        //OnlineExamSubjectGroupSchedule.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#ExaminationName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });
        $('#SelectedCentreCode').unbind("change").change(function () {
            var selectedItem = $(this).val();
            var $ddlExam = $("#SelectedExam");
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineExamSubjectGroupSchedule/GetOnlineExamGetExaminationListCentreWise",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $('#ListViewModel').empty();
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Exam-------</option>');
                        if (data == "0") {
                            notify('Session is not created for selected Center', 'warning');
                        } else if (data.length != 0) {
                            $.each(data, function (id, option) {

                                $ddlExam.append($('<option></option>').val(option.id).html(option.name));
                            });
                            if (data[0].length != 0) {
                                $("#SessionID").val(data[0].SessionID);
                            }
                        }

                        $ExamProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Exam');
                        $ExamProgress.hide();
                    }
                });
            }
        });

        $("#btnShowList").unbind("click").click(function () {
            var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
            var SelectedExam = $('#SelectedExam :selected').val();
            if (SelectedCentreCode == '') {
                notify('Please select Center', 'warning');
                return false;
            }
            if (SelectedExam == '') {
                notify('Please select Examination', 'warning');
                return false;
            }
            OnlineExamSubjectGroupSchedule.LoadList(SelectedCentreCode, SelectedExam);
        });
        // Create new record
        // Create new record
        //if ($("#IsNegavieMarking").val() == true) {
        //    debugger;
        //    alert($("#IsNegavieMarking").val());
        //    $("#MarksToBeDeducted").show;
        //}
        //else {
        //    $("#MarksToBeDeducted").css("display", "none");
        //}
        //$("#IsNegavieMarking").on("change", function () {
        //    debugger;
        //    if ($(this).val() == false) {
        //        $("#MarksToBeDeducted").css("display", "none");
        //    }
        //    else {
        //        $("#MarksToBeDeducted").show();

        //    }
        //})
        $("#IsNegavieMarking").change(function () {

            var selectedItem = $(this).val();
            if (selectedItem == 'true') {
                $("#MarksToBeDeductediv").show(true);
            }
            else {
                $("#MarksToBeDeductediv").hide(true);
            }

        });
        $("#IsTimeFlexible").on("click", function () {
            if ($(this).is(":checked")) {
                $("#ExaminationStartTime").attr("disabled", true);
                $("#ExaminationStartTime").val('');
                $("#ExaminationEndTime").attr("disabled", true);
                $("#ExaminationEndTime").val('');
            }
            else {
                $("#ExaminationStartTime").attr("disabled", false);
                $("#ExaminationEndTime").attr("disabled", false);
            }

        });
        //$('#MarksToBeDeducted').on("keydown", function (e) {
        //    AMSValidation.AllowNumbersWithDecimalOnly(e);
        //});
        $('#CreateOnlineExamSubjectGroupScheduleRecord').on("click", function () {
            var IsScheduleForAllSections = $('#IsScheduleForAllSections').is(":checked") ? "true" : "false";
            if (IsScheduleForAllSections == "false") {
                var IsStartDate = 0;                              //Validation for Examination Start Date
                $(".StartDate").each(function () {
                    if ($(this).val() == "") {
                        IsStartDate = 1;
                    }
                });
                if (IsStartDate == 1) {
                    $("#DisplaySectionErrorMessage p").text("Please Enter Examination Start Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }

                var IsEndDate = 0;                                 //Validation for Examination End Date
                $(".EndDate").each(function () {
                    if ($(this).val() == "") {
                        IsEndDate = 1;
                    }
                });
                if (IsEndDate == 1) {
                    $("#DisplaySectionErrorMessage p").text("Please Enter Examination End Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }

                var IsStartTime = 0;                              //Validation for Examination Start Time
                $(".StartTime").each(function () {
                    if ($(this).val() == "") {
                        IsStartTime = 1;
                    }
                });
                if (IsStartTime == 1) {
                    $("#DisplaySectionErrorMessage p").text("Please Enter Examination Start Time.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }

                var IsEndTime = 0;                                //Validation For Examination End Time
                $(".EndTime").each(function () {
                    if ($(this).val() == "") {
                        IsEndTime = 1;
                    }
                });
                if (IsEndTime == 1) {
                    $("#DisplaySectionErrorMessage p").text("Please Enter Examination End Time.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
            }
            OnlineExamSubjectGroupSchedule.ActionName = "Create";
            OnlineExamSubjectGroupSchedule.SelectedXMLstring();
            OnlineExamSubjectGroupSchedule.AjaxCallOnlineExamSubjectGroupSchedule();
        });

        $('#UpdateOnlineExamSubjectGroupScheduleRecord').on("click", function () {
            var IsScheduleForAllSections = $('#IsScheduleForAllSections').is(":checked") ? "true" : "false";
            if (IsScheduleForAllSections == "false") {
                var IsStartDate = 0;                              //Validation for Examination Start Date
                $(".StartDate").each(function () {
                    if ($(this).val() == "") {
                        IsStartDate = 1;
                    }
                });
                if (IsStartDate == 1) {
                    $("#DisplaySectionErrorMessage p").text("Please Enter Examination Start Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }

                var IsEndDate = 0;                                 //Validation for Examination End Date
                $(".EndDate").each(function () {
                    if ($(this).val() == "") {
                        IsEndDate = 1;
                    }
                });
                if (IsEndDate == 1) {
                    $("#DisplaySectionErrorMessage p").text("Please Enter Examination End Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }

                var IsStartTime = 0;                              //Validation for Examination Start Time
                $(".StartTime").each(function () {
                    if ($(this).val() == "") {
                        IsStartTime = 1;
                    }
                });
                if (IsStartTime == 1) {
                    $("#DisplaySectionErrorMessage p").text("Please Enter Examination Start Time.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }

                var IsEndTime = 0;                                //Validation For Examination End Time
                $(".EndTime").each(function () {
                    if ($(this).val() == "") {
                        IsEndTime = 1;
                    }
                });
                if (IsEndTime == 1) {
                    $("#DisplaySectionErrorMessage p").text("Please Enter Examination End Time.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
            }
            OnlineExamSubjectGroupSchedule.ActionName = "Edit";
            // OnlineExamSubjectGroupSchedule.SelectedXMLstring();
            OnlineExamSubjectGroupSchedule.AjaxCallOnlineExamSubjectGroupSchedule();
        });
        //$('#EditOnlineExamSubjectGroupScheduleRecord').on("click", function () {

        //    OnlineExamSubjectGroupSchedule.ActionName = "Edit";
        //    OnlineExamSubjectGroupSchedule.AjaxCallOnlineExamSubjectGroupSchedule();
        //});

        $('#DeleteOnlineExamSubjectGroupScheduleRecord').on("click", function () {
            OnlineExamSubjectGroupSchedule.ActionName = "Delete";
            OnlineExamSubjectGroupSchedule.AjaxCallOnlineExamSubjectGroupSchedule();
        });

        $('#IsScheduleForAllSections').on("click", function () {
            var IsScheduleForAllSections = $('#IsScheduleForAllSections').is(":checked") ? "true" : "false";
            CourseYearID = $('#CourseYearID').val();
            if (IsScheduleForAllSections == "false") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "CourseYearID": CourseYearID },
                    url: '/OnlineExamSubjectGroupSchedule/GetSectionListOnlineCourseYearWise',
                    success: function (data) {

                        $.each(data, function (id, option) {
                            //alert(data.length);
                            //for(i= 0; i < data.Count; i++){
                            $("#tblData tbody").append("<tr id='tr_" + option.id + "'></tr>");
                            $("#tr_" + option.id).append("<td><input id='SectionDetailID' type='hidden' value='" + option.id + "' style='display:none' /><span>" + option.name + "</span></td>");
                            $("#tr_" + option.id).append("<td><input id='ExaminationStartDateID' class='StartDate' type='text' style='width:50%' value=''/></td><td><input id='ExaminationEndDateID' class='EndDate' type='text' style='width:50%' value='' ></td>");
                            $("#tr_" + option.id).append("<td><input id='ExaminationStartTimeID' class='StartTime' type='text' style='width:50%' value=''/></td><td><input id='ExaminationEndTimeID' class='EndTime' type='text' style='width:50%' value='' ></td>");

                        });
                        $("#SectionDetails").show();

                        OnlineExamSubjectGroupSchedule.SectionWiseStartAndEndDate();

                    },
                });
            } else {
                $("#tblData tbody").empty();
                $("#SectionDetails").hide();
            }
        });

        InitAnimatedBorder();

        CloseAlert();
        $("#DisplaySectionErrorMessage button[class=close]").on("click", function () {
            $("#DisplaySectionErrorMessage").hide();
        });

        //$("#SubjectGroupId").change(function () {
        //    $('#myDataTable').html("");
        //    $('#myDataTable_info').text("No entries to show");
        //    //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        //    $('.pagination').html('');
        //    $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        //});
    },
    SectionWiseStartAndEndDate: function () {
        $(".StartDate").each(function () {
            var selectedStartDate = $(this).val();
            var selectedStartDateInDateFormat = new Date(selectedStartDate);
            var minDate = selectedStartDateInDateFormat;
            if (selectedStartDate == "" || selectedStartDateInDateFormat > moment()) {
                minDate = moment();
            }

            $(this).datetimepicker({
                format: 'DD MMM YYYY',
                minDate: minDate,
                useCurrent: false,
                ignoreReadonly: true
            }).on('dp.show', function () {

                var datepicker = $('body').find('.bootstrap-datetimepicker-widget:last');
                if (datepicker.hasClass('bottom')) {
                    var top = $(this).offset().top;
                    var left = $(this).offset().left;

                    datepicker.css({
                        'top': top + 'px',
                        'bottom': 'auto',
                        'left': left + 'px'
                    });
                } else if (datepicker.hasClass('top')) {
                    var top = $(this).offset().top - ((datepicker.outerHeight() * 1.5) + 40);
                    var left = $(this).offset().left - (datepicker.outerWidth() + (datepicker.outerWidth() / 16));

                    datepicker.css({
                        'top': top + 'px',
                        'bottom': 'auto',
                        'left': left + 'px'
                    });
                }
            }).on("dp.change", function (e) {
                var selectedNewStartDate = $(this).val();
                var selectedNewStartDateInDateFormat = new Date(selectedNewStartDate);
                $(this).parent().next().children().data("DateTimePicker").minDate(selectedNewStartDateInDateFormat);
            });
        });

        $(".EndDate").each(function () {

            var selectedStartDate = $(this).parent().prev().children().val();
            var selectedStartDateInDateFormat = new Date(selectedStartDate);
            var minDate = selectedStartDateInDateFormat;
            if (selectedStartDate == "" || selectedStartDateInDateFormat < moment()) {
                minDate = moment();
            }
            $(this).datetimepicker({
                format: 'DD MMM YYYY',
                minDate: minDate,
                useCurrent: false,
                ignoreReadonly: true
            }).on('dp.show', function () {
                var datepicker = $('body').find('.bootstrap-datetimepicker-widget:last');
                if (datepicker.hasClass('bottom')) {
                    var top = $(this).offset().top + ($(this).outerHeight() / 2);
                    var left = $(this).offset().left;
                    datepicker.css({
                        'top': top + 'px',
                        'bottom': 'auto',
                        'left': left + 'px'
                    });
                } else if (datepicker.hasClass('top')) {
                    var top = $(this).offset().top - ((datepicker.outerHeight() * 1.5) + 40);
                    var left = $(this).offset().left - (datepicker.outerWidth() + (datepicker.outerWidth() / 16));
                    datepicker.css({
                        'top': top + 'px',
                        'bottom': 'auto',
                        'left': left + 'px'
                    });
                }
            });
        });

        $(".StartTime").each(function () {
            $(this).datetimepicker({
                format: 'LT'
            }).on('dp.show', function () {
                var datepicker = $('body').find('.bootstrap-datetimepicker-widget:last');
                if (datepicker.hasClass('bottom')) {
                    var top = $(this).offset().top;
                    var left = $(this).offset().left;
                    datepicker.css({
                        'top': top + 'px',
                        'bottom': 'auto',
                        'left': left + 'px'
                    });
                } else if (datepicker.hasClass('top')) {
                    var top = $(this).offset().top - ((datepicker.outerHeight() * 2.5) + 40);
                    var left = $(this).offset().left - (datepicker.outerWidth() + (datepicker.outerWidth() / 16));
                    datepicker.css({
                        'top': top + 'px',
                        'bottom': 'auto',
                        'left': left + 'px'
                    });
                }
            });
        });

        $(".EndTime").each(function () {
            $(this).datetimepicker({
                format: 'LT'
            }).on('dp.show', function () {
                var datepicker = $('body').find('.bootstrap-datetimepicker-widget:last');
                if (datepicker.hasClass('bottom')) {
                    var top = $(this).offset().top + ($(this).outerHeight());
                    var left = $(this).offset().left;
                    datepicker.css({
                        'top': top + 'px',
                        'bottom': 'auto',
                        'left': left + 'px'
                    });
                } else if (datepicker.hasClass('top')) {
                    var top = $(this).offset().top - ((datepicker.outerHeight() * 2.5) + 40);
                    var left = $(this).offset().left - (datepicker.outerWidth() + (datepicker.outerWidth() / 16));
                    datepicker.css({
                        'top': top + 'px',
                        'bottom': 'auto',
                        'left': left + 'px'
                    });
                }
            });
        });
    },
    //LoadList method is used to load List page
    LoadList: function (SelectedCentreCode, SelectedExam) {
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { CentreCode: SelectedCentreCode, OnlineExamExaminationMasterID: SelectedExam },
             dataType: "html",
             url: '/OnlineExamSubjectGroupSchedule/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
        var SelectedExam = $('#SelectedExam :selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, CentreCode: SelectedCentreCode, OnlineExamExaminationMasterID: SelectedExam },
            url: '/OnlineExamSubjectGroupSchedule/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallOnlineExamSubjectGroupSchedule: function () {
        var OnlineExamSubjectGroupScheduleData = null;
        if (OnlineExamSubjectGroupSchedule.ActionName == "Create") {
            $("#FormCreateOnlineExamSubjectGroupSchedule").validate();
            if ($("#FormCreateOnlineExamSubjectGroupSchedule").valid()) {

                OnlineExamSubjectGroupScheduleData = OnlineExamSubjectGroupSchedule.GetOnlineExamSubjectGroupSchedule();
                ajaxRequest.makeRequest("/OnlineExamSubjectGroupSchedule/Create", "POST", OnlineExamSubjectGroupScheduleData, OnlineExamSubjectGroupSchedule.Success);
            }
        }
        else if (OnlineExamSubjectGroupSchedule.ActionName == "Edit") {
            $("#FormEditOnlineExamSubjectGroupSchedule").validate();
            if ($("#FormEditOnlineExamSubjectGroupSchedule").valid()) {
                OnlineExamSubjectGroupScheduleData = null;
                OnlineExamSubjectGroupScheduleData = OnlineExamSubjectGroupSchedule.GetOnlineExamSubjectGroupSchedule();
                ajaxRequest.makeRequest("/OnlineExamSubjectGroupSchedule/Edit", "POST", OnlineExamSubjectGroupScheduleData, OnlineExamSubjectGroupSchedule.Success);
            }
        }
        else if (OnlineExamSubjectGroupSchedule.ActionName == "Delete") {
            OnlineExamSubjectGroupScheduleData = null;
            $("#FormCreateOnlineExamSubjectGroupSchedule").validate();
            OnlineExamSubjectGroupScheduleData = OnlineExamSubjectGroupSchedule.GetOnlineExamSubjectGroupSchedule();
            ajaxRequest.makeRequest("/OnlineExamSubjectGroupSchedule/Delete", "POST", OnlineExamSubjectGroupScheduleData, OnlineExamSubjectGroupSchedule.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExamSubjectGroupSchedule: function () {
        var Data = {
        };
        if (OnlineExamSubjectGroupSchedule.ActionName == "Create" || OnlineExamSubjectGroupSchedule.ActionName == "Edit") {
            Data.ID = $('#OnlineExamSubjectGroupScheduleID').val();
            Data.OnlineExamExaminationCourseApplicableID = $('#OnlineExamExaminationCourseApplicableID').val();
            Data.SubjectID = $('#SubjectID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.SubjectGroupID = $('#SubjectGroupID').val();
            Data.CourseYearID = $('#CourseYearID').val();
            Data.ExaminationStartDate = $('#ExaminationStartDate').val();
            Data.ExaminationEndDate = $('#ExaminationEndDate').val();
            Data.ExaminationStartTime = $('#ExaminationStartTime').val();
            Data.ExaminationEndTime = $('#ExaminationEndTime').val();
            Data.TotalQuestions = $('#TotalQuestions').val();
            Data.TotalMarks = $('#TotalMarks').val();
            Data.PassingMarks = $('#PassingMarks').val();
            Data.MarksForEachQues = $('#MarksForEachQues').val();
            Data.Level1Marks = $('#Level1Marks').val();
            Data.Level2Marks = $('#Level2Marks').val();
            Data.Level3Marks = $('#Level3Marks').val();
            Data.Level1TimeInMinutes = $('#Level1TimeInMinutes').val();
            Data.Level2TimeInMinutes = $('#Level2TimeInMinutes').val();
            Data.Level3TimeInMinutes = $('#Level3TimeInMinutes').val();
            Data.Level4TimeInMinutes = $('#Level4TimeInMinutes').val();
            Data.FixedFlexibleTime = $('#FixedFlexibleTime').val();
            Data.ExamDuration = $('#ExamDuration').val();
            Data.DayOpenTime = $('#DayOpenTime').val();
            Data.DayCloseTime = $('#DayCloseTime').val();
            Data.ExaminationStatus = $('#ExaminationStatus').val();
            Data.OnlineExamExaminationMasterID = $('#OnlineExamExaminationMasterID').val();
            Data.TotalPaperSet = $('#TotalPaperSet').val();
            Data.ParameterXml = OnlineExamSubjectGroupSchedule.ParameterXml;
            Data.IsNegavieMarking = $('#IsNegavieMarking').val();
            Data.MarksToBeDeducted = $('#MarksToBeDeducted').val();
            Data.SectionScheduleList = $('#SectionScheduleList').val();
            Data.IsScheduleForAllSections = $('#IsScheduleForAllSections').is(":checked") ? "true" : "false";
            Data.IsTimeFlexible = $('#IsTimeFlexible').is(":checked") ? "true" : "false";
        }
        else if (OnlineExamSubjectGroupSchedule.ActionName == "Delete") {
            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        //alert( Data);
        return Data;

    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            OnlineExamSubjectGroupSchedule.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $.magnificPopup.close();
            OnlineExamSubjectGroupSchedule.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

    SelectedXMLstring: function () {
        var IsScheduleForAllSections = $('#IsScheduleForAllSections').is(":checked") ? "true" : "false";
        if (IsScheduleForAllSections == "false") {
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
                //alert(DataArray)
            });
            var TotalRecord = DataArray.length;
            //alert(TotalRecord);
            var ParameterXml = "<rows>";
            var fullDate = new Date()
            var currentDate = fullDate.getFullYear() + "-" + (fullDate.getMonth() + 1) + "-" + fullDate.getDate();
            for (var i = 0; i < TotalRecord; i = i + 5) {
                ParameterXml = ParameterXml + "<row><SectionDetailID>" + DataArray[i] + "</SectionDetailID><ExaminationStartDate>" + DataArray[i + 1] + "</ExaminationStartDate><ExaminationEndDate>" + DataArray[i + 2] + "</ExaminationEndDate><ExaminationStartTime>" + currentDate + " " + DataArray[i + 3] + "</ExaminationStartTime><ExaminationEndTime>" + currentDate + " " + DataArray[i + 4] + "</ExaminationEndTime></row>";
            }
            //alert(ParameterXml);
            if (ParameterXml.length >= 10)
                (OnlineExamSubjectGroupSchedule.ParameterXml = ParameterXml + "</rows>");

            else
                OnlineExamSubjectGroupSchedule.ParameterXml = " ";
        }
    },


};
//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       OnlineExamSubjectGroupSchedule.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        OnlineExamSubjectGroupSchedule.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


