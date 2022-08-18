//this class contain methods related to nationality functionality
var CRMSaleAllocateEmployeeInGroup = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMSaleAllocateEmployeeInGroup.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });


        // Create new record
        $('#CreateCRMSaleAllocateEmployeeInGroupRecord').on("click", function () {
            CRMSaleAllocateEmployeeInGroup.ActionName = "Create";
            CRMSaleAllocateEmployeeInGroup.AjaxCallCRMSaleAllocateEmployeeInGroup();
        });


        $('#EditCRMSaleAllocateEmployeeInGroupRecord').on("click", function () {
            CRMSaleAllocateEmployeeInGroup.ActionName = "Edit";
            CRMSaleAllocateEmployeeInGroup.CountValueUsingParentTag();
            CRMSaleAllocateEmployeeInGroup.getValueUsingParentTag_Check_UnCheck();
            CRMSaleAllocateEmployeeInGroup.AjaxCallCRMSaleAllocateEmployeeInGroup();
        });

        $('#DeleteCRMSaleAllocateEmployeeInGroupRecord').on("click", function () {
            CRMSaleAllocateEmployeeInGroup.ActionName = "Delete";
            CRMSaleAllocateEmployeeInGroup.AjaxCallCRMSaleAllocateEmployeeInGroup();
        });


        $("#btnShowList").on("click", function () {
            var valuCRMSaleGroupMasterID = $('#SelectedRMSaleGroupMasterID :selected').val();
            if (valuCRMSaleGroupMasterID != "" && valuCRMSaleGroupMasterID > 0) {
                CRMSaleAllocateEmployeeInGroup.LoadListByCRMGroupMasterID(valuCRMSaleGroupMasterID);
            }
            else if (valuCRMSaleGroupMasterID == "") {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectEmployee", "SuccessMessage", "#FFCC80");
                notify("Please select group", 'warning');
            }

        });
        $("#CRMSaleGroupMasterID").change(function () {
            var selectedItem = $(this).val();
            var $ddlEmployee = $("#EmployeeId");
            var $EmployeeProgress = $("#states-loading-progress");
            $EmployeeProgress.show();
            if ($("#CRMSaleGroupMasterID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/CRMSaleAllocateEmployeeInGroup/GetEmployeeListNotInGroup",
                    data: { "SelectedGroupMasterID": selectedItem },
                    success: function (data) {
                        $ddlEmployee.html('');
                        $ddlEmployee.append('<option value="">--Select Employee--</option>');

                        $.each(data, function (id, option) {

                            $ddlEmployee.append($('<option></option>').val(option.id).html(option.name));

                        });
                        $EmployeeProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve employee.');
                        $EmployeeProgress.hide();
                    }
                });
            }



        });

        $("#SelectedRMSaleGroupMasterID").change(function () {
            $('#myDataTable tbody').empty();
        });
        InitAnimatedBorder();

        CloseAlert();

    },



    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/CRMSaleAllocateEmployeeInGroup/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        var CRMSaleGroupMasterID = $('#SelectedRMSaleGroupMasterID :selected').val();
        
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { CRMSaleGroupMasterID: CRMSaleGroupMasterID, actionMode: actionMode },
            url: '/CRMSaleAllocateEmployeeInGroup/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    ReloadListNew: function (message, colorCode, actionMode, CRMSaleGroupMasterID) {
        if (CRMSaleGroupMasterID == null || CRMSaleGroupMasterID == 0) {
            CRMSaleGroupMasterID = $('#SelectedRMSaleGroupMasterID :selected').val();
        }
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { CRMSaleGroupMasterID: CRMSaleGroupMasterID, actionMode: actionMode },
            url: '/CRMSaleAllocateEmployeeInGroup/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    LoadListByCRMGroupMasterID: function (SelectedCRMGroupMasterID) {

        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { CRMSaleGroupMasterID: SelectedCRMGroupMasterID },
              dataType: "html",
              url: '/CRMSaleAllocateEmployeeInGroup/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
              }
          });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleAllocateEmployeeInGroup: function () {
        var CRMSaleAllocateEmployeeInGroupData = null;
        if (CRMSaleAllocateEmployeeInGroup.ActionName == "Create") {
            $("#FormCreateCRMSaleAllocateEmployeeInGroup").validate();
            if ($("#FormCreateCRMSaleAllocateEmployeeInGroup").valid()) {
                CRMSaleAllocateEmployeeInGroupData = null;
                CRMSaleAllocateEmployeeInGroupData = CRMSaleAllocateEmployeeInGroup.GetCRMSaleAllocateEmployeeInGroup();
                ajaxRequest.makeRequest("/CRMSaleAllocateEmployeeInGroup/Create", "POST", CRMSaleAllocateEmployeeInGroupData, CRMSaleAllocateEmployeeInGroup.Success, "CreateCRMSaleAllocateEmployeeInGroupRecord");
            }

        }
        else if (CRMSaleAllocateEmployeeInGroup.ActionName == "Edit") {
            $("#FormEditCRMSaleAllocateEmployeeInGroup").validate();
            if ($("#FormEditCRMSaleAllocateEmployeeInGroup").valid()) {
                CRMSaleAllocateEmployeeInGroupData = null;
                CRMSaleAllocateEmployeeInGroupData = CRMSaleAllocateEmployeeInGroup.GetCRMSaleAllocateEmployeeInGroup();
                ajaxRequest.makeRequest("/CRMSaleAllocateEmployeeInGroup/Edit", "POST", CRMSaleAllocateEmployeeInGroupData, CRMSaleAllocateEmployeeInGroup.Success);
            }
        }
        else if (CRMSaleAllocateEmployeeInGroup.ActionName == "Delete") {
            CRMSaleAllocateEmployeeInGroupData = null;
            //$("#FormCreateCRMSaleAllocateEmployeeInGroup").validate();
            CRMSaleAllocateEmployeeInGroupData = CRMSaleAllocateEmployeeInGroup.GetCRMSaleAllocateEmployeeInGroup();
            ajaxRequest.makeRequest("/CRMSaleAllocateEmployeeInGroup/Delete", "POST", CRMSaleAllocateEmployeeInGroupData, CRMSaleAllocateEmployeeInGroup.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMSaleAllocateEmployeeInGroup: function () {

        var Data = {
        };
        if (CRMSaleAllocateEmployeeInGroup.ActionName == "Create" || CRMSaleAllocateEmployeeInGroup.ActionName == "Edit") {

            Data.CRMSaleGroupMasterID = $('#CRMSaleGroupMasterID :selected').val();
            Data.EmployeeId = $('#EmployeeId').val();
        }
        else if (CRMSaleAllocateEmployeeInGroup.ActionName == "Delete") {
            Data.CRMSaleAllocateEmployeeInGroupID = $('input[name=CRMSaleAllocateEmployeeInGroupID]').val();
        }
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var CRMSaleGroupMasterID = data.CRMSaleGroupMasterID;//splitdata[1].split(":");
        var splitData = data.errorMessage.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleAllocateEmployeeInGroup.ReloadListNew(splitData[0], splitData[1], splitData[2], CRMSaleGroupMasterID);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

