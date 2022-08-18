﻿//this class contain methods related to nationality functionality
var EntranceExamValidationParameter = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EntranceExamValidationParameter.constructor();
        //EntranceExamValidationParameter.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

       

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
           
            return false;
        });

        $('#CentreCode').on("change", function () {
            $('#LiSessionName').hide(true);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
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
                         url: '/EntranceExamValidationParameter/List',
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
        $('#CreateEntranceExamValidationParameterRecord').on("click", function () {
            EntranceExamValidationParameter.ActionName = "Create";
            EntranceExamValidationParameter.AjaxCallEntranceExamValidationParameter();
        });

        $('#EditEntranceExamValidationParameterRecord').on("click", function () {

            EntranceExamValidationParameter.ActionName = "Edit";
            EntranceExamValidationParameter.AjaxCallEntranceExamValidationParameter();
        });

        $('#DeleteEntranceExamValidationParameterRecord').on("click", function () {

            EntranceExamValidationParameter.ActionName = "Delete";
            EntranceExamValidationParameter.AjaxCallEntranceExamValidationParameter();
        });


        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $('#PreQualificationCutOff').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);

        });
        $('#PreQualificationCutOff').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);

        });
        $('#PreQualificationCutOff').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);

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
             url: '/EntranceExamValidationParameter/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedSessionID = $('#SelectedSessionID option:selected').val();
        var SelectedSessionName = $('#SelectedSessionID option:selected').text();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            data: { CentreCode: CentreCode, sessionID: SelectedSessionID, sessionName: SelectedSessionName, actionMode: actionMode },
            url: '/EntranceExamValidationParameter/List',
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
    AjaxCallEntranceExamValidationParameter: function () {
        var EntranceExamValidationParameterData = null;
        if (EntranceExamValidationParameter.ActionName == "Create") {
            $("#FormCreateEntranceExamValidationParameter").validate();
            if ($("#FormCreateEntranceExamValidationParameter").valid()) {
    
                EntranceExamValidationParameterData = null;
                EntranceExamValidationParameterData = EntranceExamValidationParameter.GetEntranceExamValidationParameter();
                ajaxRequest.makeRequest("/EntranceExamValidationParameter/Create", "POST", EntranceExamValidationParameterData, EntranceExamValidationParameter.Success);
            }
        }
        else if (EntranceExamValidationParameter.ActionName == "Edit") {
            $("#FormEditEntranceExamValidationParameter").validate();
            if ($("#FormEditEntranceExamValidationParameter").valid()) {
                EntranceExamValidationParameterData = null;
                EntranceExamValidationParameterData = EntranceExamValidationParameter.GetEntranceExamValidationParameter();
                ajaxRequest.makeRequest("/EntranceExamValidationParameter/Edit", "POST", EntranceExamValidationParameterData, EntranceExamValidationParameter.Success);
            }
        }
        else if (EntranceExamValidationParameter.ActionName == "Delete") {
            EntranceExamValidationParameterData = null;
            //$("#FormCreateEntranceExamValidationParameter").validate();
            EntranceExamValidationParameterData = EntranceExamValidationParameter.GetEntranceExamValidationParameter();
            ajaxRequest.makeRequest("/EntranceExamValidationParameter/Delete", "POST", EntranceExamValidationParameterData, EntranceExamValidationParameter.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEntranceExamValidationParameter: function () {
        var Data = {
        };
        if (EntranceExamValidationParameter.ActionName == "Create" || EntranceExamValidationParameter.ActionName == "Edit") {


            Data.ID = $('#ID').val();
            Data.FeeCriteriaValueCombinationMasterID = $('#FeeCriteriaValueCombinationMasterID').val();
           
            Data.PreQualificationCutOff = $('#PreQualificationCutOff').val();
            Data.EntranceExamFeeAmount = $('#EntranceExamFeeAmount').val();
            Data.EntranceExamCutOff = $('#EntranceExamCutOff').val();
            Data.FeeCriteriaValueCombinationMasterID = $('input[name=FeeCriteriaValueCombinationMasterID]').val();
            Data.CentreCode = $('#CentreCode :selected').val();
            Data.SessionID = $('#SessionID').val();
           // parseFloat($('#PreQualificationCutOff').val()).toFixed(2);
        }
        else if (EntranceExamValidationParameter.ActionName == "Delete") {
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
            EntranceExamValidationParameter.ReloadList(splitData[0], splitData[1], splitData[2],CentreCode, SessionID);
        } else {
            parent.$.colorbox.close();
            EntranceExamValidationParameter.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode, SessionID);
        }

    },


};

