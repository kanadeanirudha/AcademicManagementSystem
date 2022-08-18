//this class contain methods related to nationality functionality
var EntranceExamApplicableExamToCourse = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EntranceExamApplicableExamToCourse.constructor();
        //EntranceExamApplicableExamToCourse.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            return false;
        });

        //$("#CentreCode").change(function () {
        //    var selectedItem = $(this).val();
        //    //   var selectedItem1 = $("#UniversityID");
        //    


        //    var $ddlCurrentSessionDetails = $("#SessionID");

        //    var $SessionDetailsProgress = $("#states-loading-progress");

        //    $SessionDetailsProgress.show();

        //    


        //    if ($("#CentreCode").val() != "") {
        //        $.ajax({
        //            cache: false,
        //            type: "GET",
        //            url: "/EntranceExamApplicableExamToCourse/GetAllSessionDetails",

        //            data: { "CentreCode": selectedItem },
        //            success: function (data) {
        //                $ddlCurrentSessionDetails.html('');
        //                $ddlCurrentSessionDetails.append('<option value="">--Select Session--</option>');
        //                $.each(data, function (id, option) {

        //                    $ddlCurrentSessionDetails.append($('<option></option>').val(option.id).html(option.name));
        //                });

        //                $SessionDetailsProgress.hide();
        //            },
        //            error: function (xhr, ajaxOptions, thrownError) {
        //                alert('Failed to retrieve Session.');
        //                $SessionDetailsProgress.hide();
        //            }
        //        });
        //    }
        //    else {
        //        $('#myDataTable tbody').empty();
        //        $('#SessionID').find('option').remove().end().append('<option value>---Select Session---</option>');
        //        $('#btnCreate').hide();
        //    }

        //});
        $('#CentreCode').on("change", function () {
            $('#LiSessionName').hide(true);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $("#ExaminationName").autocomplete({

            source: function (request, response) {
                
                $.ajax({

                    url: "/EntranceExamApplicableExamToCourse/GetExaminationName",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term, maxResults: 10 }, //1 for current year student
                    //{ term: request.term, maxResults: 10, courseYearID: $("#SelectedCourseYearId :selected").val(), sectionDetailID: $("#SelectedSectionDetailID :selected").val(), SessionID: $("#SelectedAcademicYear :selected").val() }, //1 for current year student
                    success: function (data) {

                        response($.map(data, function (item) {
                            
                            return { label: item.ExaminationName, value: item.ExaminationName, id: item.id };

                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);
                // display the selected text
                $("#OnlineExamExaminationMasterID").val(ui.item.id);

            }
        });





        $("#btnShowList").on("click", function () {
            
            var SelectedCentreCode = $("#CentreCode").val();
            var SelectedCentreName = $("#CentreCode option:selected").text();
            var SessionID = $("#SessionID").val();
            if (SelectedCentreCode != "" && SelectedCentreName != "" && SessionID != "") {
                $.ajax(
                     {
                         cache: false,
                         type: "GET",
                         data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName, "SessionID": SessionID },
                         dataType: "html",
                         url: '/EntranceExamApplicableExamToCourse/List',
                         success: function (data) {
                             //Rebind Grid Data
                             $('#ListViewModel').html(data);
                             $('#LiSessionName').show(true);

                             //OrganisationCentrewiseSession.LoadList(SelectedCentreCode);
                         }
                     });
            }

            else if ((SelectedCentreCode == "" || SelectedCentreCode == null)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                $('#LiSessionName').hide(true);

            }



        });

        // Create new record
        $('#CreateEntranceExamApplicableExamToCourseRecord').on("click", function () {
            
            EntranceExamApplicableExamToCourse.ActionName = "Create";
            if ($('#OnlineExamExaminationMasterID').val() == 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterExamName", "DivSuccessMessage", "#FFCC80");
               // alert("Please select Proper Exam Name")
                return false;
            }
            else {
                EntranceExamApplicableExamToCourse.AjaxCallEntranceExamApplicableExamToCourse();

                }




        });

        $('#EditEntranceExamApplicableExamToCourseRecord').on("click", function () {

            EntranceExamApplicableExamToCourse.ActionName = "Edit";
            EntranceExamApplicableExamToCourse.AjaxCallEntranceExamApplicableExamToCourse();
        });

        $('#DeleteEntranceExamApplicableExamToCourseRecord').on("click", function () {

            EntranceExamApplicableExamToCourse.ActionName = "Delete";
            EntranceExamApplicableExamToCourse.AjaxCallEntranceExamApplicableExamToCourse();
        });


        //$('#FeeCriteriaParametersCode').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});
        $("#ExaminationUpToDate").prop('readonly', true);
        $("#ExaminationFromDate").prop('readonly', true);

        $('#ExaminationFromDate').datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy',
            minDate: 0,
            onSelect: function (selected) {
                $("#ExaminationUpToDate").datepicker("option", "minDate", selected)
            }
        })

        $('#ExaminationUpToDate').datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy',

            onSelect: function (selected) {
                $("#ExaminationFromDate").datepicker("option", "maxDate", selected)
            }
        })

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
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EntranceExamApplicableExamToCourse/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, CentreCode) {

        var SelectedSessionID = $('#SelectedSessionID option:selected').val();
        var SelectedSessionName = $('#SelectedSessionID option:selected').text();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            data: { CentreCode: CentreCode, sessionID: SelectedSessionID, sessionName: SelectedSessionName, actionMode: actionMode },
            url: '/EntranceExamApplicableExamToCourse/List',
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
    AjaxCallEntranceExamApplicableExamToCourse: function () {
        var EntranceExamApplicableExamToCourseData = null;
        if (EntranceExamApplicableExamToCourse.ActionName == "Create") {
            $("#FormCreateEntranceExamApplicableExamToCourse").validate();

            if ($("#FormCreateEntranceExamApplicableExamToCourse").valid()) {
                
                EntranceExamApplicableExamToCourseData = null;
                EntranceExamApplicableExamToCourseData = EntranceExamApplicableExamToCourse.GetEntranceExamApplicableExamToCourse();
                ajaxRequest.makeRequest("/EntranceExamApplicableExamToCourse/Create", "POST", EntranceExamApplicableExamToCourseData, EntranceExamApplicableExamToCourse.Success);
            }
        }
        else if (EntranceExamApplicableExamToCourse.ActionName == "Edit") {
            $("#FormEditEntranceExamApplicableExamToCourse").validate();
            if ($("#FormEditEntranceExamApplicableExamToCourse").valid()) {
                EntranceExamApplicableExamToCourseData = null;
                EntranceExamApplicableExamToCourseData = EntranceExamApplicableExamToCourse.GetEntranceExamApplicableExamToCourse();
                ajaxRequest.makeRequest("/EntranceExamApplicableExamToCourse/Edit", "POST", EntranceExamApplicableExamToCourseData, EntranceExamApplicableExamToCourse.Success);
            }
        }
        else if (EntranceExamApplicableExamToCourse.ActionName == "Delete") {
            EntranceExamApplicableExamToCourseData = null;
            //$("#FormCreateEntranceExamApplicableExamToCourse").validate();
            EntranceExamApplicableExamToCourseData = EntranceExamApplicableExamToCourse.GetEntranceExamApplicableExamToCourse();
            ajaxRequest.makeRequest("/EntranceExamApplicableExamToCourse/Delete", "POST", EntranceExamApplicableExamToCourseData, EntranceExamApplicableExamToCourse.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEntranceExamApplicableExamToCourse: function () {
        var Data = {
        };
        if (EntranceExamApplicableExamToCourse.ActionName == "Create" || EntranceExamApplicableExamToCourse.ActionName == "Edit") {
            
            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode :selected').val();
            Data.SessionID = $('#SessionID').val();
            Data.ExaminationName = $('#ExaminationName').val();
            Data.CourseName = $('#CourseName').val();
            Data.ExaminationFromDate = $('#ExaminationFromDate').val();
            Data.ExaminationUpToDate = $('#ExaminationUpToDate').val();
            Data.CourseYearDetailID = $('#CourseYearDetailID').val();
            
            Data.OnlineExamExaminationMasterID = $('#OnlineExamExaminationMasterID').val();

            //alert($('input[name=OnlineExamExaminationMasterID]').val());
            //Data.OnlineExamExaminationMasterID = $('input[name=OnlineExamExaminationMasterID]').val();
        }
        else if (EntranceExamApplicableExamToCourse.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var CentreCode = data.CentreCode;//splitdata[1].split(":");
        var SessionID = data.SessionID;//splitdata[2].split(":");
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            EntranceExamApplicableExamToCourse.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode, SessionID);
        } else {
            parent.$.colorbox.close();
            EntranceExamApplicableExamToCourse.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode, SessionID);
        }

    },


};

