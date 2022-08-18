//this class contain methods related to nationality functionality
var CRMSaleTargetException = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMSaleTargetException.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });
        $("#CRMSaleTargetTypeId").change(function () {
            debugger;
            var selectedItem = $(this).val();
            var $ddlEmployee = $("#EmployeeId");
            var $EmployeeProgress = $("#states-loading-progress");
            $EmployeeProgress.show();
            if ($("#CRMSaleTargetTypeId").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/CRMSaleTargetException/GetEmployeeListNotInTargetException",
                    data: { "SelectedTargetTypeID": selectedItem },
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

        // Create new record
        $('#CreateCRMSaleTargetExceptionRecord').on("click", function () {
            CRMSaleTargetException.ActionName = "Create";
            CRMSaleTargetException.AjaxCallCRMSaleTargetException();
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
             url: '/CRMSaleTargetException/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/CRMSaleTargetException/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleTargetException: function () {
        var CRMSaleTargetExceptionData = null;
        if (CRMSaleTargetException.ActionName == "Create") {
            $("#FormCreateCRMSaleTargetException").validate();
            if ($("#FormCreateCRMSaleTargetException").valid()) {
                CRMSaleTargetExceptionData = null;
                CRMSaleTargetExceptionData = CRMSaleTargetException.GetCRMSaleTargetException();
                ajaxRequest.makeRequest("/CRMSaleTargetException/Create", "POST", CRMSaleTargetExceptionData, CRMSaleTargetException.Success, "CreateCRMSaleTargetExceptionRecord");
            }


        }
        else if (CRMSaleTargetException.ActionName == "Edit") {
            $("#FormEditCRMSaleTargetException").validate();
            if ($("#FormEditCRMSaleTargetException").valid()) {
                CRMSaleTargetExceptionData = null;

                CRMSaleTargetExceptionData = CRMSaleTargetException.GetCRMSaleTargetException();

                ajaxRequest.makeRequest("/CRMSaleTargetException/Edit", "POST", CRMSaleTargetExceptionData, CRMSaleTargetException.Success);

            }
        }
        else if (CRMSaleTargetException.ActionName == "Delete") {
            CRMSaleTargetExceptionData = null;
            //$("#FormCreateCRMSaleTargetException").validate();
            CRMSaleTargetExceptionData = CRMSaleTargetException.GetCRMSaleTargetException();
            ajaxRequest.makeRequest("/CRMSaleTargetException/Delete", "POST", CRMSaleTargetExceptionData, CRMSaleTargetException.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMSaleTargetException: function () {

        var Data = {
        };
        if (CRMSaleTargetException.ActionName == "Create" || CRMSaleTargetException.ActionName == "Edit") {

            Data.CRMSaleTargetTypeId = $('#CRMSaleTargetTypeId').val();
            Data.EmployeeId = $('#EmployeeId').val();
            Data.TargetValue = $('#TargetValue').val();
            Data.FromDate = $('#FromDate').val();
            Data.GeneralPeriodTypeMasterID = $("#GeneralPeriodTypeMasterID").val();
        }
        else if (CRMSaleTargetException.ActionName == "Delete") {
            Data.CRMSaleTargetExceptionID = $('input[name=CRMSaleTargetExceptionID]').val();

        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {        
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleTargetException.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

