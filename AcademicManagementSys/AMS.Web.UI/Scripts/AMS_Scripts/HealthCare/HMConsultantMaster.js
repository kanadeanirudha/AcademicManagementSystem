//this class contain methods related to nationality functionality
var HMConsultantMaster = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        HMConsultantMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        //***************** For validations ****************
        //$('#Name').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});


        $("#ShowList").on("click", function () {
            debugger;

            var valuCentreCode = $('#CentreCode :selected').val();
            if (valuCentreCode == "") {
                $("#CreateConsultantMaster").hide();
                notify("Please select Centre", 'warning');
            }
            else {
                $("#CreateConsultantMaster").show();
                HMConsultantMaster.LoadList(valuCentreCode);

            }

        });
        //For Hidding Add button OnClicking on Select dept
        $("#CentreCode").change(function () {
            debugger;
            if (!$("#CentreCode").val()) {
                $("#CreateConsultantMaster").hide();
            }

            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");


            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');


        });
       

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });
        // Create new record
        $('#CreateHMConsultantMasterRecord').on("click", function () {
            HMConsultantMaster.ActionName = "Create";
            HMConsultantMaster.AjaxCallHMConsultantMaster();
        });
        $('#EditHMConsultantMasterRecord').on("click", function () {
            HMConsultantMaster.ActionName = "Edit";
            HMConsultantMaster.AjaxCallHMConsultantMaster();
        });
        $('#DeleteHMConsultantMasterRecord').on("click", function () {
            HMConsultantMaster.ActionName = "Delete";
            HMConsultantMaster.AjaxCallHMConsultantMaster();
        });
        InitAnimatedBorder();
        CloseAlert();
    },


    //LoadList method is used to load List page
    LoadList: function (SelectedCentreCode) {
        debugger;

        var SelectedCentreCode = $('#CentreCode').val();
        //   var SelectedDepartmentName = $('#DepartmentID').text();
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { centreCode: SelectedCentreCode },
             dataType: "html",
             url: '/HMConsultantMaster/List',
             success: function (data) {
                 //Rebind Grid Data

                 $('#ListViewModel').html(data);
                 if (SelectedCentreCode == null) {
                     $("#CreateConsultantMaster").hide();
                 } else {
                     $("#CreateConsultantMaster").show();
                 }
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;

        var SelectedCentreCode = $('#CentreCode :selected').val();
        //  var SelectedDepartmentName = $('#DepartmentID :selected').text();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { centreCode: SelectedCentreCode },
            url: '/HMConsultantMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                if (SelectedCentreCode == null) {
                    $("#CreateConsultantMaster").hide();
                } else {
                    $("#CreateConsultantMaster").show();
                }
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallHMConsultantMaster: function () {
        var HMConsultantMasterData = null;
        if (HMConsultantMaster.ActionName == "Create") {
            $("#FormCreateHMConsultantMaster").validate();
            if ($("#FormCreateHMConsultantMaster").valid()) {
                HMConsultantMasterData = null;
                HMConsultantMasterData = HMConsultantMaster.GetHMConsultantMaster();
                ajaxRequest.makeRequest("/HMConsultantMaster/Create", "POST", HMConsultantMasterData, HMConsultantMaster.Success, "CreateHMConsultantMasterRecord");
            }
        }
        else if (HMConsultantMaster.ActionName == "Edit") {
            $("#FormEditHMConsultantMaster").validate();
            if ($("#FormEditHMConsultantMaster").valid()) {
                HMConsultantMasterData = null;
                HMConsultantMasterData = HMConsultantMaster.GetHMConsultantMaster();
                ajaxRequest.makeRequest("/HMConsultantMaster/Edit", "POST", HMConsultantMasterData, HMConsultantMaster.Success);
            }
        }
        else if (HMConsultantMaster.ActionName == "Delete") {
            HMConsultantMasterData = null;
            //$("#FormCreateHMConsultantMaster").validate();
            HMConsultantMasterData = HMConsultantMaster.GetHMConsultantMaster();
            ajaxRequest.makeRequest("/HMConsultantMaster/Delete", "POST", HMConsultantMasterData, HMConsultantMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetHMConsultantMaster: function () {
        var Data = {
        };
        if (HMConsultantMaster.ActionName == "Create") {
            debugger;
    
            Data.ConsultantTypeMasterID = $('#Name').val();
            Data.EmployeeID = $('#EmployeeID').val();
           /// Data.EmployeeName = $('#EmployeeName').text();
            Data.Name = $('#Name').text();
           // Data.Name = $('#Name').val();

        }
        else if (HMConsultantMaster.ActionName == "Edit") {
            Data.ConsultantTypeMasterID = $('#Name').val();
            Data.EmployeeID = $('#EmployeeName').val();
            //  Data.CentreCode = $('#CentreCode').val();
            //  Data.DepartmentID = $('#DepartmentID').val();

        }
        else if (HMConsultantMaster.ActionName == "Delete") {
            Data.ID = $('input[name=HMConsultantMasterID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            HMConsultantMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

