
//This class cantain methods for Entrance exam schedule and scdeule details funcationality.
var EntranceExamScheduleAndScheduleDetail = {

    //Member variables
    ActionName: null,
    SelectedUnAllotedStudentXml: null,
    TotalStudentApllicable: null,   
    //Class intialisation method
    Initialize: function () {
        EntranceExamScheduleAndScheduleDetail.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#OnlineExamExaminationQuestionPaperID').val('');            
        });

        $("#ScheduleTimeStart").timepicki();
        $("#ScheduleEndTime").timepicki();

        //Create New Record  
        $('#CreateEntranceExamScheduleAndScheduleDetailRecord').on("click", function () {
            
            EntranceExamScheduleAndScheduleDetail.ActionName = "Create";
            EntranceExamScheduleAndScheduleDetail.GetSelectedStudentForSchedule();

            EntranceExamScheduleAndScheduleDetail.AjaxCallEntranceExamScheduleAndScheduleDetail();
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


        //FOLLOWING FUNCTION IS SEARCHLIST OF ENTRANCE EXAM NAME.
        $("#ExaminationName").autocomplete({
            source: function (request, response) {

                $.ajax({
                    url: "/EntranceExamScheduleAndScheduleDetail/GetEntranceExamNameSearch",
                    type: "POST",
                    dataType: "json",
                    data: { searchText: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {                              
                            return { label: item.examinationName, value: item.examinationName, id: item.examinationID };                            
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);                                             // display the selected text
                $("#ExaminationID").val(ui.item.id);
            }
        });     
        
        //Date Picker for Date of Schedule.
        $("#ScheduleDate").datepicker({
            dateFormat: 'd M yy',
            numberOfMonths: 1,
            minDate: 0
        });      

        $(".ajax").colorbox();      


        $("#ShowList").click(function () {
            
            var selectedExaminationID = $('#ExaminationID').val();
            var selectedExam = $('#ExaminationName').val();
            if (selectedExaminationID > 0 && selectedExam != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    data: { actionMode: null, examName: selectedExam, examinationID: selectedExaminationID },
                    dataType: "html",
                    url: '/EntranceExamScheduleAndScheduleDetail/List',
                    success: function (result) {
                        //Rebind Grid Data                
                        $('#ListViewModel').html(result);
                    }
                });
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_PleaseSelectExamination", "SuccessMessage", "#FFCC80");
                EntranceExamScheduleAndScheduleDetail.LoadList();
            }
        });

        //Set Al Check box checked.
        $('#selectAllStudentID').change(function () {
            if (this.checked) {
                $('.abc1').prop('checked', true);
            }
            else {
                $('.abc1').prop('checked', false);
            }

        });       
    },


    //LoadList method is used to load List page
    LoadList: function () {        
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/EntranceExamScheduleAndScheduleDetail/List',
            data: { "actionMode": null, "examName": "", "examinationID": 0 },
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var selectedExaminationID = $('#ExaminationID').val();
        var selectedExam = $('#ExaminationName').val();
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "examName": selectedExam, "examinationID": selectedExaminationID },
            url: '/EntranceExamScheduleAndScheduleDetail/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
            }
        });
    },


    //Method to Create xml of Selected Student For Schedule.
    GetSelectedStudentForSchedule: function () {        
        var sList = "";
        var xmlParamList = "<rows>";      

        $('#myDataTableCreate input[type=checkbox]').each(function () {
            if ($(this).val() != "on") {
                var a = $(this).val();
                if (this.checked == true) {
                    xmlParamList = xmlParamList + "<row><ID>0</ID>" + "<StudentRegistrationId>" + $(this).val() + "</StudentRegistrationId>" + "</row>";
                    EntranceExamScheduleAndScheduleDetail.TotalStudentApllicable++;
                }
            }
        });
        if (xmlParamList.length > 6)
            EntranceExamScheduleAndScheduleDetail.SelectedUnAllotedStudentXml = xmlParamList + "</rows>";
        else
            EntranceExamScheduleAndScheduleDetail.SelectedUnAllotedStudentXml = "";
    },

    //Fire ajax call to insert update and delete record
    AjaxCallEntranceExamScheduleAndScheduleDetail: function () {
        var EntranceExamScheduleAndScheduleDetailData = null;
        if (EntranceExamScheduleAndScheduleDetail.ActionName == "Create") {

            $("#FormCreateEntranceExamScheduleAndScheduleDetail").validate();
            if ($("#FormCreateEntranceExamScheduleAndScheduleDetail").valid()) {
                EntranceExamScheduleAndScheduleDetailData = null;
                EntranceExamScheduleAndScheduleDetailData = EntranceExamScheduleAndScheduleDetail.GetEntranceExamScheduleAndScheduleDetail();
                ajaxRequest.makeRequest("/EntranceExamScheduleAndScheduleDetail/Create", "POST", EntranceExamScheduleAndScheduleDetailData, EntranceExamScheduleAndScheduleDetail.Success);
            }
        }
        else if (EntranceExamScheduleAndScheduleDetail.ActionName == "Edit") {
            $("#FormEditEntranceExamScheduleAndScheduleDetail").validate();
            if ($("#FormEditEntranceExamScheduleAndScheduleDetail").valid()) {
                EntranceExamScheduleAndScheduleDetailData = null;
                EntranceExamScheduleAndScheduleDetailData = EntranceExamScheduleAndScheduleDetail.GetEntranceExamScheduleAndScheduleDetail();
                ajaxRequest.makeRequest("/EntranceExamScheduleAndScheduleDetail/Edit", "POST", EntranceExamScheduleAndScheduleDetailData, EntranceExamScheduleAndScheduleDetail.Success);
            }
        }
        else if (EntranceExamScheduleAndScheduleDetail.ActionName == "Delete") {
            EntranceExamScheduleAndScheduleDetailData = null;
            EntranceExamScheduleAndScheduleDetailData = EntranceExamScheduleAndScheduleDetail.GetEntranceExamScheduleAndScheduleDetail();
            ajaxRequest.makeRequest("/EntranceExamScheduleAndScheduleDetail/Delete", "POST", EntranceExamScheduleAndScheduleDetailData, EntranceExamScheduleAndScheduleDetail.Success);
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetEntranceExamScheduleAndScheduleDetail: function () {
        var Data = {
        };
        if (EntranceExamScheduleAndScheduleDetail.ActionName == "Create") {
            
            Data.OnlineExamExaminationMasterID = $('input[name=OnlineExamExaminationMasterID]').val();
            Data.OnlineExamExaminationQuestionPaperID = $('#OnlineExamExaminationQuestionPaperID').val();
            Data.EntranceExamInfrastructureDetailID = $('input[name=EntranceExamInfrastructureDetailID]').val();
            Data.EntranceExamCenteApllicableToExamID = $('#EntranceExamCenteApllicableToExamID').val();
            Data.ScheduleName = $('#ScheduleName').val();
            Data.ScheduleDate = $('input[name=ScheduleDate]').val();
            Data.ScheduleTimeStart = EntranceExamScheduleAndScheduleDetail.hours_am_pm($("#ScheduleTimeStart").val());
            Data.ScheduleEndTime = EntranceExamScheduleAndScheduleDetail.hours_am_pm($("#ScheduleEndTime").val());
            if (EntranceExamScheduleAndScheduleDetail.SelectedUnAllotedStudentXml != null) {
                Data.SelectedUnAllotedStudentXml = EntranceExamScheduleAndScheduleDetail.SelectedUnAllotedStudentXml;
            }
            else
            {
                Data.StudentRegistrationID = 0;
            }

            if (EntranceExamScheduleAndScheduleDetail.TotalStudentApllicable != null) {
                Data.TotalStudentApllicable = EntranceExamScheduleAndScheduleDetail.TotalStudentApllicable;
            }
            else
            {
                Data.TotalStudentApllicable = 0;
            }
        }
        
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        EntranceExamScheduleAndScheduleDetail.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
    },

    hours_am_pm: function (time) {
        var time = (time).split(':');
        var hours = parseInt(time[0].trim());
        var minutes = parseInt(time[1].trim());
        var AMPM = time[2].trim();
        if (AMPM == "PM" && hours < 12 && hours != 00) hours = hours + 12;
        if (AMPM == "AM" && hours == 12 && hours != 00) hours = hours - 12;
        var sHours = hours.toString();
        var sMinutes = minutes.toString();
        if (hours < 10) sHours = "0" + sHours;
        if (minutes < 10) sMinutes = "0" + sMinutes;
        return (sHours + ":" + sMinutes + ":00");
    },

};