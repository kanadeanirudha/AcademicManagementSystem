//this class contain methods related to nationality functionality
var HMOPDHealthCentre = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        HMOPDHealthCentre.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        //***************** For validations ****************
        $('#OPDName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        //***************** Get Center On dept****************
        $("#SelectedCentreCode").change(function () {
            debugger;
          //  alert('Hiii')
            var selectedItem = $(this).val();
            var $ddlDepartments = $("#SelectedDepartmentID");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/HMOPDHealthCentre/GetDepartmentByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartments.html('');
                        $ddlDepartments.append('<option value="">-----Select Department-----</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $departmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        $departmentProgress.hide();
                    }
                });

            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>-----Select Department-----</option>');
            }
           
        });
         
        //For Binding Center And Dept Together on Show Button
        $("#ShowList").on("click", function () {
            debugger;
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuDepartmentID = $('#SelectedDepartmentID :selected').val();

            if (valuCentreCode == "" ) {

                notify("Please select Centre", 'warning');
            }
                else if (valuDepartmentID == "") {
                    notify("Please select Department", 'warning');
                }
            else {
                    HMOPDHealthCentre.LoadList(valuCentreCode, valuDepartmentID);
                  
                
            }

        });
     
      
        //For Hidding Add Button on change CenterCode
        $("#SelectedCentreCode").change(function () {

            if ($("#SelectedCentreCode").val() != null && $("#SelectedDepartmentID").val() != null) {
                $("#CreateOPDInfo").hide();
            }
            else {
                $("#CreateOPDInfo").show();
            }

            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");


            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');


        });
        //For hidding Add button On change dept
        $("#SelectedDepartmentID").change(function () {

            if ($("#SelectedCentreCode").val() != null && $("#SelectedDepartmentID").val() != null) {
                $("#CreateOPDInfo").hide();
            }
            else {
                $("#CreateOPDInfo").show();
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
        $('#CreateHMOPDHealthCentreRecord').on("click", function () {
            HMOPDHealthCentre.ActionName = "Create";
            HMOPDHealthCentre.AjaxCallHMOPDHealthCentre();
        });
        $('#EditHMOPDHealthCentreRecord').on("click", function () {
            HMOPDHealthCentre.ActionName = "Edit";
            HMOPDHealthCentre.AjaxCallHMOPDHealthCentre();
        });
        $('#DeleteHMOPDHealthCentreRecord').on("click", function () {
            HMOPDHealthCentre.ActionName = "Delete";
            HMOPDHealthCentre.AjaxCallHMOPDHealthCentre();
        });
        InitAnimatedBorder();
        CloseAlert();
    },


    //LoadList method is used to load List page
    LoadList: function (SelectedCentreCode, SelectedDepartmentID) {
        debugger;
        var SelectedDepartmentID = $('#SelectedDepartmentID').val();
        var SelectedCentreCode = $('#SelectedCentreCode').val();
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { centerCode: SelectedCentreCode, departmentID: SelectedDepartmentID },
             dataType: "html",
             url: '/HMOPDHealthCentre/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
                 if (SelectedDepartmentID == null && SelectedCentreCode == null) {
                                              $("#CreateOPDInfo").hide();
                                          } else {
                                              $("#CreateOPDInfo").show();
                                          }
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
        var SelectedDepartmentID = $('#SelectedDepartmentID :selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "centerCode": SelectedCentreCode, "departmentID": SelectedDepartmentID },
            url: '/HMOPDHealthCentre/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                if (SelectedDepartmentID == null && SelectedCentreCode == null) {
                    $("#CreateOPDInfo").hide();
                } else {
                    $("#CreateOPDInfo").show();
                }
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //ReloadList: function (message, colorCode, actionMode) {
    //    $.ajax(
    //    {
    //        cache: false,
    //        type: "POST",
    //        dataType: "html",
    //        data: { actionMode: actionMode },
    //        url: '/HMOPDHealthCentre/List',
    //        success: function (data) {
    //            //Rebind Grid Data
    //            $("#ListViewModel").empty().append(data);
    //            //twitter type notification
    //            notify(message, colorCode);
    //        }
    //    });
    //},

    //Fire ajax call to insert update and delete record
    AjaxCallHMOPDHealthCentre: function () {
        var HMOPDHealthCentreData = null;
        if (HMOPDHealthCentre.ActionName == "Create") {
            $("#FormCreateHMOPDHealthCentre").validate();
            if ($("#FormCreateHMOPDHealthCentre").valid()) {
                HMOPDHealthCentreData = null;
                HMOPDHealthCentreData = HMOPDHealthCentre.GetHMOPDHealthCentre();
                ajaxRequest.makeRequest("/HMOPDHealthCentre/Create", "POST", HMOPDHealthCentreData, HMOPDHealthCentre.Success, "CreateHMOPDHealthCentreRecord");
            }
        }
        else if (HMOPDHealthCentre.ActionName == "Edit") {
            $("#FormEditHMOPDHealthCentre").validate();
            if ($("#FormEditHMOPDHealthCentre").valid()) {
                HMOPDHealthCentreData = null;
                HMOPDHealthCentreData = HMOPDHealthCentre.GetHMOPDHealthCentre();
                ajaxRequest.makeRequest("/HMOPDHealthCentre/Edit", "POST", HMOPDHealthCentreData, HMOPDHealthCentre.Success);
            }
        }
        else if (HMOPDHealthCentre.ActionName == "Delete") {
            HMOPDHealthCentreData = null;
            //$("#FormCreateHMOPDHealthCentre").validate();
            HMOPDHealthCentreData = HMOPDHealthCentre.GetHMOPDHealthCentre();
            ajaxRequest.makeRequest("/HMOPDHealthCentre/Delete", "POST", HMOPDHealthCentreData, HMOPDHealthCentre.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetHMOPDHealthCentre: function () {
        var Data = {
        };
        if (HMOPDHealthCentre.ActionName == "Create") {
            debugger;
            Data.OPDName = $('#OPDName').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.DepartmentID = $('#DepartmentID').val();
           
        }
        else if (HMOPDHealthCentre.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.OPDName = $('#OPDName').val();
          //  Data.CentreCode = $('#CentreCode').val();
          //  Data.DepartmentID = $('#DepartmentID').val();
          
        }
        else if (HMOPDHealthCentre.ActionName == "Delete") {
            Data.HMOPDHealthCentreID = $('input[name=HMOPDHealthCentreID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            HMOPDHealthCentre.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

