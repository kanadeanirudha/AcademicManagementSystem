//this class contain methods related to nationality functionality
var HMConsultantTypeMaster = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        HMConsultantTypeMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        //***************** For validations ****************
        $('#Name').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
       

        $("#ShowList").on("click", function () {
            debugger;
       
            var valuDepartmentID = $('#DepartmentID :selected').val();
              if (valuDepartmentID == "") {
                $("#CreateConsultantType").hide();
                notify("Please select Department", 'warning');
            }
            else {
                $("#CreateConsultantType").show();
                HMConsultantTypeMaster.LoadList(valuDepartmentID);

            }

        });
        //For Hidding Add button OnClicking on Select dept
        $("#DepartmentID").change(function () {

            if (!$("#DepartmentID").val()) {
                $("#CreateConsultantType").hide();
            }

            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");


            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');


        });
        //////For hidding Add button On change dept

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });
        // Create new record
        $('#CreateHMConsultantTypeMasterRecord').on("click", function () {
            HMConsultantTypeMaster.ActionName = "Create";
            HMConsultantTypeMaster.AjaxCallHMConsultantTypeMaster();
        });
        $('#EditHMConsultantTypeMasterRecord').on("click", function () {
            HMConsultantTypeMaster.ActionName = "Edit";
            HMConsultantTypeMaster.AjaxCallHMConsultantTypeMaster();
        });
        $('#DeleteHMConsultantTypeMasterRecord').on("click", function () {
            HMConsultantTypeMaster.ActionName = "Delete";
            HMConsultantTypeMaster.AjaxCallHMConsultantTypeMaster();
        });
        InitAnimatedBorder();
        CloseAlert();
    },


    //LoadList method is used to load List page
    LoadList: function (SelectedDepartmentID) {
        debugger;
        
        var SelectedDepartmentID = $('#DepartmentID').val();
     //   var SelectedDepartmentName = $('#DepartmentID').text();
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { departmentID: SelectedDepartmentID },
             dataType: "html",
             url: '/HMConsultantTypeMaster/List',
             success: function (data) {
                 //Rebind Grid Data
             
                 $('#ListViewModel').html(data);
                 if (SelectedDepartmentID == null) {
                     $("#CreateConsultantType").hide();
                 } else {
                     $("#CreateConsultantType").show();
                 }
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
       
        var SelectedDepartmentID = $('#DepartmentID :selected').val();
      //  var SelectedDepartmentName = $('#DepartmentID :selected').text();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { departmentID: SelectedDepartmentID },
            url: '/HMConsultantTypeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                if (SelectedDepartmentID == null) {
                    $("#CreateConsultantType").hide();
                } else {
                    $("#CreateConsultantType").show();
                }
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
   
    //Fire ajax call to insert update and delete record
    AjaxCallHMConsultantTypeMaster: function () {
        var HMConsultantTypeMasterData = null;
        if (HMConsultantTypeMaster.ActionName == "Create") {
            $("#FormCreateHMConsultantTypeMaster").validate();
            if ($("#FormCreateHMConsultantTypeMaster").valid()) {
                HMConsultantTypeMasterData = null;
                HMConsultantTypeMasterData = HMConsultantTypeMaster.GetHMConsultantTypeMaster();
                ajaxRequest.makeRequest("/HMConsultantTypeMaster/Create", "POST", HMConsultantTypeMasterData, HMConsultantTypeMaster.Success, "CreateHMConsultantTypeMasterRecord");
            }
        }
        else if (HMConsultantTypeMaster.ActionName == "Edit") {
            $("#FormEditHMConsultantTypeMaster").validate();
            if ($("#FormEditHMConsultantTypeMaster").valid()) {
                HMConsultantTypeMasterData = null;
                HMConsultantTypeMasterData = HMConsultantTypeMaster.GetHMConsultantTypeMaster();
                ajaxRequest.makeRequest("/HMConsultantTypeMaster/Edit", "POST", HMConsultantTypeMasterData, HMConsultantTypeMaster.Success);
            }
        }
        else if (HMConsultantTypeMaster.ActionName == "Delete") {
            HMConsultantTypeMasterData = null;
            //$("#FormCreateHMConsultantTypeMaster").validate();
            HMConsultantTypeMasterData = HMConsultantTypeMaster.GetHMConsultantTypeMaster();
            ajaxRequest.makeRequest("/HMConsultantTypeMaster/Delete", "POST", HMConsultantTypeMasterData, HMConsultantTypeMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetHMConsultantTypeMaster: function () {
        var Data = {
        };
        if (HMConsultantTypeMaster.ActionName == "Create") {
            debugger;
            Data.Name = $('#Name').val();
          //  Data.CentreCode = $('#CentreCode').val();
            Data.DepartmentID = $('#DepartmentID').val();

        }
        else if (HMConsultantTypeMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Name = $('#Name').val();
            //  Data.CentreCode = $('#CentreCode').val();
            //  Data.DepartmentID = $('#DepartmentID').val();

        }
        else if (HMConsultantTypeMaster.ActionName == "Delete") {
            Data.ID = $('input[name=HMConsultantTypeMasterID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            HMConsultantTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

