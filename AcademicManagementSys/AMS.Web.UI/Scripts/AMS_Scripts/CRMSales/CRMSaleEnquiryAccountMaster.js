//this class contain methods related to nationality functionality
var CRMSaleEnquiryAccountMaster = {
    //Member variables
    ActionName: null,
    VisitingCardName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMSaleEnquiryAccountMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        // Create new record
        $('#CreateCRMSaleEnquiryAccountMasterRecord').on("click", function () {
            debugger;
            CRMSaleEnquiryAccountMaster.GetVisitingCard('CreateCRMSaleEnquiryAccountMasterRecord');
            if ($("input[name='AccountType']:checked").val() == 2 && (CRMSaleEnquiryAccountMaster.VisitingCardName == null || CRMSaleEnquiryAccountMaster.VisitingCardName == "")) {
                $("#displayErrorMessage p").text("Please upload visiting card.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            if ($('input[name=CRMSaleEnquiryAccountMasterID]').val() == 0) {
                $("#displayErrorMessage p").text("Invalid account! Please select proper account").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('input[name=CRMSaleEnquiryAccountContactPersonID]').val() == 0) {
                $("#displayErrorMessage p").text("Invalid account contact person! Please select proper contact person").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                CRMSaleEnquiryAccountMaster.ActionName = "Create";
                CRMSaleEnquiryAccountMaster.AjaxCallCRMSaleEnquiryAccountMaster();
            }
        });

        $('#showmyaccounts').unbind('click').on("click", function () {
            CRMSaleEnquiryAccountMaster.LoadList();
        });

        $('#showallaccounts').unbind('click').on("click", function () {
            CRMSaleEnquiryAccountMaster.LoadAllAccountList('');
        });

        $('#FirstName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#LastName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#Designation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#EmailId').on("keydown", function (e) {
            AMSValidation.validateEmail(e);
        });

        $('#EnquiryAccountContactPersonAddress').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });
        $('#Pin').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#EnquiryAccountContactPersonLocation').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#EnquiryAccountContactPersonCity').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $("#CreateCRMSaleEnquiryAccountContactPersonRecord").on("click", function () {
            CRMSaleEnquiryAccountMaster.GetVisitingCard('CreateCRMSaleEnquiryAccountContactPersonRecord');
            if (CRMSaleEnquiryAccountMaster.VisitingCardName == null || CRMSaleEnquiryAccountMaster.VisitingCardName == "") {
                $("#displayErrorMessage p").text("Please upload visiting card.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            CRMSaleEnquiryAccountMaster.ActionName = "CreateContactPerson";
            CRMSaleEnquiryAccountMaster.AjaxCallCRMSaleEnquiryCreateContactPerson();
        });

        $("#UpdateCRMSaleEnquiryAccountContactPersonRecord").on("click", function () {

            CRMSaleEnquiryAccountMaster.ActionName = "UpDateContactPerson";
            CRMSaleEnquiryAccountMaster.AjaxCallCRMSaleEnquiryCreateContactPerson();
        });

        $("#CreateAccountTransferRequest").on('click', function () {
            CRMSaleEnquiryAccountMaster.ActionName = "AccountTransferRequest";
            CRMSaleEnquiryAccountMaster.AjaxCallCRMSaleEnquiryAccountMaster();
        });

        $('#ApproxAnnualAmount').keydown(function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        InitAnimatedBorder();

        CloseAlert();

    },

    GetVisitingCard: function (eventClick) {
        var imgValue = new FormData();
        var files = $("#VisitingCard").get(0).files;
        if (files.length > 0 && (CRMSaleEnquiryAccountMaster.VisitingCardName == null || CRMSaleEnquiryAccountMaster.VisitingCardName == "")) {
            imgValue.append("MyImages", files[0]);

            $.ajax({
                url: "/CRMSaleJobUserJobScheduleUpdateStatus/UploadFile",
                type: "POST",
                processData: false,
                contentType: false,
                data: imgValue,
                dataType: 'json',
                success: function (imgValue) {
                    //code after success                       
                    $("#displayErrorMessage p").text("Uploading visiting card...").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    CRMSaleEnquiryAccountMaster.VisitingCardName = imgValue;
                    setTimeout(function () { $('#' + eventClick).click(); }, 3000);
                },
                error: function (er) {
                    alert(er);
                }
            });
        }
    },

    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/CRMSaleEnquiryAccountMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    LoadAllAccountList: function (ProgressTypeCheck) {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/CRMSaleEnquiryAccountMaster/ListAllAccounts?SearchQuery=' + ProgressTypeCheck,
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/CRMSaleEnquiryAccountMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    LoadListByEnquiryAccountType: function (SelectedEnquiryAccountType, TransactionDate) {

        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { SelectedEnquiryAccountType: SelectedEnquiryAccountType, TransactionDate: TransactionDate },
              dataType: "html",
              url: '/CRMSaleEnquiryAccountMaster/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
              }
          });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleEnquiryAccountMaster: function () {
        var CRMSaleEnquiryAccountMasterData = null;
        if (CRMSaleEnquiryAccountMaster.ActionName == "Create") {
            $("#FormCreateCRMSaleEnquiryAccountMaster").validate();
            if ($("#FormCreateCRMSaleEnquiryAccountMaster").valid()) {
                CRMSaleEnquiryAccountMasterData = null;
                CRMSaleEnquiryAccountMasterData = CRMSaleEnquiryAccountMaster.GetCRMSaleEnquiryAccountMaster();
                ajaxRequest.makeRequest("/CRMSaleEnquiryAccountMaster/Create", "POST", CRMSaleEnquiryAccountMasterData, CRMSaleEnquiryAccountMaster.Success, "CreateCRMSaleEnquiryAccountMasterRecord");
            }


        }
        else if (CRMSaleEnquiryAccountMaster.ActionName == "Edit") {
            $("#FormEditCRMSaleEnquiryAccountMaster").validate();
            if ($("#FormEditCRMSaleEnquiryAccountMaster").valid()) {
                CRMSaleEnquiryAccountMasterData = null;

                CRMSaleEnquiryAccountMasterData = CRMSaleEnquiryAccountMaster.GetCRMSaleEnquiryAccountMaster();

                ajaxRequest.makeRequest("/CRMSaleEnquiryAccountMaster/Edit", "POST", CRMSaleEnquiryAccountMasterData, CRMSaleEnquiryAccountMaster.Success);

            }
        }
        else if (CRMSaleEnquiryAccountMaster.ActionName == "Delete") {
            CRMSaleEnquiryAccountMasterData = null;
            //$("#FormCreateCRMSaleEnquiryAccountMaster").validate();
            CRMSaleEnquiryAccountMasterData = CRMSaleEnquiryAccountMaster.GetCRMSaleEnquiryAccountMaster();
            ajaxRequest.makeRequest("/CRMSaleEnquiryAccountMaster/Delete", "POST", CRMSaleEnquiryAccountMasterData, CRMSaleEnquiryAccountMaster.Success);

        }
        else if (CRMSaleEnquiryAccountMaster.ActionName == "AccountTransferRequest") {
            $("#FormAccountTransferRequest").validate();
            if ($("#FormAccountTransferRequest").valid()) {
                CRMSaleEnquiryAccountMasterData = null;
                CRMSaleEnquiryAccountMasterData = CRMSaleEnquiryAccountMaster.GetCRMSaleEnquiryAccountMaster();
                ajaxRequest.makeRequest("/CRMSaleEnquiryAccountMaster/AccountTransferRequest", "POST", CRMSaleEnquiryAccountMasterData, CRMSaleEnquiryAccountMaster.RequestSuccess);
            }
        }
    },

    //Fire ajax call to insert update and delete record for contact person.
    AjaxCallCRMSaleEnquiryCreateContactPerson: function () {
        var CRMSaleEnquiryContactPersonData = null;
        if (CRMSaleEnquiryAccountMaster.ActionName == "CreateContactPerson") {
            $("#FormCreateCRMSaleEnquiryAccountContactPerson").validate();
            if ($("#FormCreateCRMSaleEnquiryAccountContactPerson").valid()) {
                CRMSaleEnquiryContactPersonData = null;
                CRMSaleEnquiryContactPersonData = CRMSaleEnquiryAccountMaster.GetCRMSaleEnquiryCreateContactPerson();
                ajaxRequest.makeRequest("/CRMSaleEnquiryAccountMaster/CreateContactPerson", "POST", CRMSaleEnquiryContactPersonData, CRMSaleEnquiryAccountMaster.Success, "CreateCRMSaleEnquiryAccountContactPersonRecord");
            }
        }
        if (CRMSaleEnquiryAccountMaster.ActionName == "UpDateContactPerson") {
            debugger;
            $("#FormUpdateCRMSaleEnquiryAccountContactPerson").validate();
            if ($("#FormUpdateCRMSaleEnquiryAccountContactPerson").valid()) {
                CRMSaleEnquiryContactPersonData = null;
                CRMSaleEnquiryContactPersonData = CRMSaleEnquiryAccountMaster.GetCRMSaleEnquiryCreateContactPerson();
                ajaxRequest.makeRequest("/CRMSaleEnquiryAccountMaster/EditContactPerson", "POST", CRMSaleEnquiryContactPersonData, CRMSaleEnquiryAccountMaster.Success, "UpdateCRMSaleEnquiryAccountContactPersonRecord");
            }
        }
    },


    //Get properties data from the Create, Update and Delete page
    GetCRMSaleEnquiryCreateContactPerson: function () {
        var Data = {
        };
        if (CRMSaleEnquiryAccountMaster.ActionName == "CreateContactPerson") {
            Data.CRMSaleEnquiryAccountMasterID = $('#CRMSaleEnquiryAccountMasterID').val();
            Data.FirstName = $('#FirstName').val();
            Data.LastName = $('#LastName').val();
            Data.Designation = $('#Designation').val();
            Data.MobileNumber = $('#MobileNumber').val();
            Data.EmailId = $('#EmailId').val();
            Data.EnquiryAccountContactPersonAddress = $('#EnquiryAccountContactPersonAddress').val();
            Data.Pin = $('#Pin').val();
            //Data.EnquiryAccountContactPersonLocation = $('#EnquiryAccountContactPersonLocation').val();
            Data.EnquiryAccountContactPersonCity = $('#EnquiryAccountContactPersonCity').val();
            Data.EnquiryAccountContactPersonCountry = $('#EnquiryAccountContactPersonCountry').val();
            Data.VisitingCardName = CRMSaleEnquiryAccountMaster.VisitingCardName;
        }
        else if (CRMSaleEnquiryAccountMaster.ActionName == "UpDateContactPerson") {
            debugger;
            Data.CRMSaleEnquiryAccountContactPersonID = $('#CRMSaleEnquiryAccountContactPersonID').val();
            Data.FirstName = $('#FirstName').val();
            Data.LastName = $('#LastName').val();
            Data.Designation = $('#Designation').val();
            Data.MobileNumber = $('#MobileNumber').val();
            Data.EmailId = $('#EmailId').val();
            Data.EnquiryAccountContactPersonAddress = $('#EnquiryAccountContactPersonAddress').val();
            Data.EnquiryAccountContactPersonCity = $('#EnquiryAccountContactPersonCity').val();
            Data.EnquiryAccountContactPersonCountry = $('#EnquiryAccountContactPersonCountry').val();
            Data.Pin = $('#Pin').val();
        }
        return Data;
    },

    //Get properties data from the Create, Update and Delete page
    GetCRMSaleEnquiryAccountMaster: function () {

        var Data = {
        };
        if (CRMSaleEnquiryAccountMaster.ActionName == "Create" || CRMSaleEnquiryAccountMaster.ActionName == "Edit") {
            Data.AccountName = $('#AccountName').val();
            Data.ApproxAnnualAmount = $('#ApproxAnnualAmount').val();
            Data.GeneralIndustryMasterID = $('#GeneralIndustryMasterID').val();
            Data.CRMAccountProgressTypeID = $('#CRMAccountProgressTypeID').val();
            Data.EnquiryAccountMasterAddress = $('#EnquiryAccountMasterAddress').val();
            Data.EnquiryAccountMasterCity = $('#EnquiryAccountMasterCity').val();
            Data.EnquiryAccountMasterCountry = $('#EnquiryAccountMasterCountry').val();
            Data.FirstName = $('#FirstName').val();
            Data.LastName = $('#LastName').val();
            Data.Designation = $('#Designation').val();
            Data.MobileNumber = $('#MobileNumber').val();
            Data.EmailId = $('#EmailId').val();
            Data.EnquiryAccountContactPersonAddress = $('#EnquiryAccountContactPersonAddress').val();
            Data.Pin = $('#Pin').val();
            Data.EnquiryAccountContactPersonCity = $('#EnquiryAccountContactPersonCity').val();
            Data.EnquiryAccountContactPersonCountry = $('#EnquiryAccountContactPersonCountry').val();
            Data.AccountType = $('input[name=AccountType]:checked').val();
            Data.VisitingCardName = CRMSaleEnquiryAccountMaster.VisitingCardName;
        }
        else if (CRMSaleEnquiryAccountMaster.ActionName == "Delete") {
            Data.CRMSaleEnquiryAccountMasterID = $('input[name=CRMSaleEnquiryAccountMasterID]').val();

        } else if (CRMSaleEnquiryAccountMaster.ActionName == "AccountTransferRequest") {
            Data.CRMSaleEnquiryAccountMasterID = $('#CRMSaleEnquiryAccountMasterID').val();
            Data.AccountTransferRequestReason = $('#AccountTransferRequestReason').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');

        //if (splitData[1] == 'success') {
        $.magnificPopup.close();
        CRMSaleEnquiryAccountMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        //}
        //else {
        $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        //}
    },
    RequestSuccess: function (data) {
        var splitData = data.split(',');

        $.magnificPopup.close();
        notify(splitData[0], splitData[1]);

    },
};

