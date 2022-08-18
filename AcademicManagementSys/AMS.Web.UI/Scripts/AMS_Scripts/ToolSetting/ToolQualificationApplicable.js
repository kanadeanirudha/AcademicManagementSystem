//this class contain methods related to nationality functionality
var ToolQualificationApplicable = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ToolQualificationApplicable.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/ToolQualificationApplicable/GetUniversityByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--Select University-</option>');
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
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#StreamID').focus();
            var dt = new Date();
            $('#StreamID').val("");
            $('#PresentIntake').val(0);
            $('#IntroductionYear').val(dt.getFullYear());
            $('#BranchPrintingSequence').val('0');
            return false;
        });



        $('#SelectedUniversityID').on("change", function () {
            //    $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $("#CenterName").prop('readonly', true);
        $("#UniversityName").prop('readonly', true);
        $("#QualificationName").prop('readonly', true);
        $("#FromDate").prop('readonly', true);
        // $("#ToDate").attr("disabled", true);

        $("#FromDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'd-M-yy',
            minDate: 0,
        });

        $('#IntroductionYear').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PresentIntake').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        // Create new record
        $('#CreateToolQualificationApplicableRecord').on("click", function () {
            ToolQualificationApplicable.ActionName = "Create";
            ToolQualificationApplicable.AjaxCallToolQualificationApplicable();
        });

        $('#EditToolQualificationApplicableRecord').on("click", function () {
            
            ToolQualificationApplicable.ActionName = "Edit";
            ToolQualificationApplicable.AjaxCallToolQualificationApplicable();
        });

        $('#DeleteToolQualificationApplicableRecord').on("click", function () {

            ToolQualificationApplicable.ActionName = "Delete";
            ToolQualificationApplicable.AjaxCallToolQualificationApplicable();
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

        $('#btnShowList').click(function () {
            
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID').val();
            if (valuCentreCode != "" && valuUniversityID > 0) {
                //alert("1234");
                ToolQualificationApplicable.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
            }
            else if (valuCentreCode != "" && valuUniversityID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                // $('#DivCreateNew').hide(true);
            }
            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                //  $('#DivCreateNew').hide(true);
            }
        });

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/ToolQualificationApplicable/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, UniversityID, CentreCode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            data: { centerCode: CentreCode, universityID: UniversityID, actionMode: actionMode },
            dataType: "html",
            url: '/ToolQualificationApplicable/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }

        });

    },
    //ReloadList method is used to load List page
    //LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {
    //    
    //    //var selectedText = $('#SelectedUniversityID').text();
    //    //var selectedVal = $('#SelectedUniversityID').val();
        
    //    $.ajax(
    //      {
    //          cache: false,
    //          type: "POST",
    //          data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },

    //          dataType: "html",
    //          url: '/ToolQualificationApplicable/List',
    //          success: function (result) {
    //              //Rebind Grid Data                
    //              $('#ListViewModel').html(result);

    //          }
    //      });


    //},

    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {

        //var selectedText = $('#SelectedUniversityID').text();
        //var selectedVal = $('#SelectedUniversityID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },

              dataType: "html",
              url: '/ToolQualificationApplicable/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallToolQualificationApplicable: function () {
        var ToolQualificationApplicableData = null;
        if (ToolQualificationApplicable.ActionName == "Create") {
            $("#FormCreateToolQualificationApplicable").validate();
            if ($("#FormCreateToolQualificationApplicable").valid()) {
                ToolQualificationApplicableData = null;
                ToolQualificationApplicableData = ToolQualificationApplicable.GetToolQualificationApplicable();
                ajaxRequest.makeRequest("/ToolQualificationApplicable/Create", "POST", ToolQualificationApplicableData, ToolQualificationApplicable.createSuccess);
            }
        }
        else if (ToolQualificationApplicable.ActionName == "Edit") {
            $("#FormEditToolQualificationApplicable").validate();
            if ($("#FormEditToolQualificationApplicable").valid()) {
                ToolQualificationApplicableData = null;
                ToolQualificationApplicableData = ToolQualificationApplicable.GetToolQualificationApplicable();
                ajaxRequest.makeRequest("/ToolQualificationApplicable/Edit", "POST", ToolQualificationApplicableData, ToolQualificationApplicable.editSuccess);
            }
        }
        else if (ToolQualificationApplicable.ActionName == "Delete") {
            ToolQualificationApplicableData = null;
            //$("#FormCreateToolQualificationApplicable").validate();
            ToolQualificationApplicableData = ToolQualificationApplicable.GetToolQualificationApplicable();
            
            ajaxRequest.makeRequest("/ToolQualificationApplicable/Delete", "POST", ToolQualificationApplicableData, ToolQualificationApplicable.deleteSuccess);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetToolQualificationApplicable: function () {

        var Data = {
        };
        if (ToolQualificationApplicable.ActionName == "Create" || ToolQualificationApplicable.ActionName == "Edit") {
            Data.QualificationExamMstID = $('input[name=QualificationExamMstID]').val();
            Data.BranchDetailID = $('#BranchDetailID').val();
            Data.StandardNumber = $('#StandardNumber').val();
            Data.FromDate = $('#FromDate').val();
            Data.SelectedCentreCode = $('#SelectedCentreCode :selected').val();
            Data.SelectedUniversityID = $('#SelectedUniversityID').val();



        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {
        
        //var splitdata = data.split("::");
        //var dataSuccess = splitdata[0];
        var CentreCode = data.CentreCodeWithName;//splitdata[1].split(":");
        var UniversityID = data.UniversityIDWithName;//splitdata[2].split(":");
        var splitData = data.errorMessage.split(',');
        ToolQualificationApplicable.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
        parent.$.colorbox.close();
        //var splitCentreCode = splitdata[1].split(":");
        //var splitUniversityID = splitdata[2].split(":");
        //parent.$.colorbox.close();

        //if (dataSuccess == "True") {
        //    //Reload List
        //    ToolQualificationApplicable.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
        //} else {
        //    $("#update-message").show();
        //}
    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    var splitdata = data.split("::");
    //    var splitCentreCode = splitdata[1].split(":");
    //    var splitUniversityID = splitdata[2].split(":");
    //    parent.$.colorbox.close();
    //    ToolQualificationApplicable.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List

    //    var splitdata = data.split("::");
    //    var splitCentreCode = splitdata[1].split(":");
    //    var splitUniversityID = splitdata[2].split(":");
    //    parent.$.colorbox.close();
    //    // ToolQualificationApplicable.ReloadList("Record Deleted Sucessfully.");
    //    ToolQualificationApplicable.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
};

//////////////////new js///////////////

//this class contain methods related to nationality functionality
var ToolQualificationApplicable = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ToolQualificationApplicable.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/ToolQualificationApplicable/GetUniversityByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--Select University-</option>');
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
            $('#DivCreateNew').hide(true);
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#StreamID').focus();
            var dt = new Date();
            $('#StreamID').val("");
            $('#PresentIntake').val(0);
            $('#IntroductionYear').val(dt.getFullYear());
            $('#BranchPrintingSequence').val('0');
            return false;
        });



        $('#SelectedUniversityID').on("change", function () {
            //    $('#DivCreateNew').hide(true);
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $("#CenterName").prop('readonly', true);
        $("#UniversityName").prop('readonly', true);
        $("#QualificationName").prop('readonly', true);
        $("#FromDate").prop('readonly', true);
        // $("#ToDate").attr("disabled", true);

        //$("#FromDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd-M-yy',
        //    minDate: 0,
        //});

        $('#FromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            minDate: moment(),
        });

        $('#IntroductionYear').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PresentIntake').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        // Create new record
        $('#CreateToolQualificationApplicableRecord').on("click", function () {
            ToolQualificationApplicable.ActionName = "Create";
            ToolQualificationApplicable.AjaxCallToolQualificationApplicable();
        });

        $('#EditToolQualificationApplicableRecord').on("click", function () {

            ToolQualificationApplicable.ActionName = "Edit";
            ToolQualificationApplicable.AjaxCallToolQualificationApplicable();
        });

        $('#DeleteToolQualificationApplicableRecord').on("click", function () {

            ToolQualificationApplicable.ActionName = "Delete";
            ToolQualificationApplicable.AjaxCallToolQualificationApplicable();
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#btnShowList').click(function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID').val();
            if (valuCentreCode != "" && valuUniversityID > 0) {
                //alert("1234");
                ToolQualificationApplicable.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
            }
            else if (valuCentreCode != "" && valuUniversityID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                // $('#DivCreateNew').hide(true);
            }
            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                //  $('#DivCreateNew').hide(true);
            }
        });

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/ToolQualificationApplicable/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, UniversityID, CentreCode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            data: { centerCode: CentreCode, universityID: UniversityID, actionMode: actionMode },
            dataType: "html",
            url: '/ToolQualificationApplicable/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }

        });

    },
    

    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {

        //var selectedText = $('#SelectedUniversityID').text();
        //var selectedVal = $('#SelectedUniversityID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },

              dataType: "html",
              url: '/ToolQualificationApplicable/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallToolQualificationApplicable: function () {
        var ToolQualificationApplicableData = null;
        if (ToolQualificationApplicable.ActionName == "Create") {
            $("#FormCreateToolQualificationApplicable").validate();
            if ($("#FormCreateToolQualificationApplicable").valid()) {
                ToolQualificationApplicableData = null;
                ToolQualificationApplicableData = ToolQualificationApplicable.GetToolQualificationApplicable();
                ajaxRequest.makeRequest("/ToolQualificationApplicable/Create", "POST", ToolQualificationApplicableData, ToolQualificationApplicable.createSuccess);
            }
        }
        else if (ToolQualificationApplicable.ActionName == "Edit") {
            $("#FormEditToolQualificationApplicable").validate();
            if ($("#FormEditToolQualificationApplicable").valid()) {
                ToolQualificationApplicableData = null;
                ToolQualificationApplicableData = ToolQualificationApplicable.GetToolQualificationApplicable();
                ajaxRequest.makeRequest("/ToolQualificationApplicable/Edit", "POST", ToolQualificationApplicableData, ToolQualificationApplicable.editSuccess);
            }
        }
        else if (ToolQualificationApplicable.ActionName == "Delete") {
            ToolQualificationApplicableData = null;
            //$("#FormCreateToolQualificationApplicable").validate();
            ToolQualificationApplicableData = ToolQualificationApplicable.GetToolQualificationApplicable();

            ajaxRequest.makeRequest("/ToolQualificationApplicable/Delete", "POST", ToolQualificationApplicableData, ToolQualificationApplicable.deleteSuccess);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetToolQualificationApplicable: function () {

        var Data = {
        };
        if (ToolQualificationApplicable.ActionName == "Create" || ToolQualificationApplicable.ActionName == "Edit") {
            Data.QualificationExamMstID = $('input[name=QualificationExamMstID]').val();
            Data.BranchDetailID = $('#BranchDetailID').val();
            Data.StandardNumber = $('#StandardNumber').val();
            Data.FromDate = $('#FromDate').val();
            Data.SelectedCentreCode = $('#SelectedCentreCode :selected').val();
            Data.SelectedUniversityID = $('#SelectedUniversityID').val();



        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {

        //var splitdata = data.split("::");
        //var dataSuccess = splitdata[0];
        var CentreCode = data.CentreCodeWithName;//splitdata[1].split(":");
        var UniversityID = data.UniversityIDWithName;//splitdata[2].split(":");
        var splitData = data.errorMessage.split(',');
        ToolQualificationApplicable.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        
    },
    
};

