//this class contain methods related to nationality functionality
var FeeRefundMaster = {
    //Member variables
    map: {},
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        FeeRefundMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $("#ChequeDate").val("");
        $("#ChequeDate").prop("disabled", true);
        $("#ChequeNumber").val("");
        $("#ChequeNumber").prop("disabled", true);

        $("#ts4").on("change", function () {
            debugger;
            
            if ($("#ts4").is(':checked') == true) {
                FeeRefundMaster.BindAccountList($('#selectedBalsheetID').val(), 2); // 2 for chequeOrdd      
                $("#ChequeDate").val("");
                $("#ChequeDate").prop("disabled", false);
                $("#ChequeNumber").val("");
                $("#ChequeNumber").prop("disabled", false);
            }
            else {
                FeeRefundMaster.BindAccountList($('#selectedBalsheetID').val(), 1); // 1 for cash     
                $("#ChequeDate").val("");
                $("#ChequeDate").prop("disabled", true);
                $("#ChequeNumber").val("");
                $("#ChequeNumber").prop("disabled", true);
            }
        });

        $("#AccountID").on("change", function () {
            $("#tdPaymentFromAccountName").empty();
            $("#tdPaymentFromAccountName").text($("#AccountID :selected").text());
        });

        $("#StudentName").on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);

            if (e.keyCode == 8 || e.keyCode == 46) {
                document.getElementById("imgStuPhoto").src = "Content/materialtheme/img/login.png";
                $("#StudentName").val('');
                $("#stuName").html('Student Name <small id="stuEmailID">Email -Id </small>');
                $("#stuAcadYear").text('');
                $("#stuCourse").text('');
                $("#stuSection").text('');
                $("#stuAdmissionPattern").text('');
                $("#stuGender").text('');
                $("#stuEnrollNumber").text('');
                $("#stuStdNumber").text('');
                $("#stuAdmitAcadYear").text('');
                $("#StudentAmissionDetailID").val('');
                $("#SectionDetailId").val('');
                $("#StandarNumber").val('');
                $("#LastSectionDetailID").val('');
                $("#StudentID").val('');
            }

        });
        $("#ScholarSheepDocumentNumber").on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });


        $("#CreateFeeRefundMasterRecord").on("click", function () {
            if ($("#ts4").is(':checked') == true) {
                if ($("#ChequeDate").val() == null || $("#ChequeDate").val() == "") {
                    $("#displayErrorMessage p").text("Cheque date must be selected").closest('div').fadeIn().closest('div').addClass('alert-danger');
                    return false;
                }
                if ($("#ChequeNumber").val() == null || $("#ChequeNumber").val() == "") {
                    $("#displayErrorMessage p").text("Cheque number should not be blank").closest('div').fadeIn().closest('div').addClass('alert-danger');
                    return false;
                }
                FeeRefundMaster.ActionName = "Create";
                FeeRefundMaster.GetXml();
                FeeRefundMaster.AjaxCallFeeRefundMaster();
            }
            else {
                FeeRefundMaster.ActionName = "Create";
                FeeRefundMaster.GetXml();
                FeeRefundMaster.AjaxCallFeeRefundMaster();
            }

        });

        InitAnimatedBorder();
        
        CloseAlert();

    },

    BindAccountList: function (balancesheetID, isCashOrBankFlag) {
        
        if (balancesheetID != null && balancesheetID != "") {
            var $ddlAccount = $("#AccountID");
            $.ajax({
                url: "/FeeRefundMaster/GetAccountListForFeeRefund",
                type: "POST",
                dataType: "json",
                data: { balancesheetID: balancesheetID, isCashOrBankFlag: isCashOrBankFlag },
                success: function (data) {
                    $ddlAccount.empty();
                    $.each(data, function (id, option) {
                        $ddlAccount.append($('<option></option>').val(option.id).html(option.name));
                    });
                    $("#tdPaymentFromAccountName").text($("#AccountID :selected").text())
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    notify("Failed to retrieve Accounts", "danger");
                    $ddlAccount.hide();
                },
                async: false
            })
        }
        else {
            notify("Please select Balancesheet", "danger")
        }

    },

    //Get Data For Fee Approval in XML.
    GetXml: function () {

        var FeeRefundXml = "<rows>";
        if ($("#ts4").is(':checked') == true) {
            FeeRefundXml = FeeRefundXml +"<row><TransactionSubID>0</TransactionSubID><AccountID>"+ $("input[id='AccountIDForStudentOutStanding']").val() + "</AccountID><DebitCreditFlag>D</DebitCreditFlag><TransactionAmount>" + $("input[id='RefundAmount']").val() + "</TransactionAmount><ChequeNo></ChequeNo><ChequeDatetime></ChequeDatetime><NarrationDescription>Fee Refund</NarrationDescription><BankName></BankName><BranchName></BranchName><PersonID>" + $("input[id='StudentID']").val() + "</PersonID><PersonType>S</PersonType><IsActive>1</IsActive></row><row><TransactionSubID>0</TransactionSubID><AccountID>" + $("#AccountID :selected").val() + "</AccountID><DebitCreditFlag>C</DebitCreditFlag><TransactionAmount>" + $("input[id='RefundAmount']").val() + "</TransactionAmount><ChequeNo>" + $("#ChequeNumber").val() + "</ChequeNo><ChequeDatetime>" + $("#ChequeDate").val() + "</ChequeDatetime><NarrationDescription>Fee Refund</NarrationDescription><BankName></BankName><BranchName></BranchName><PersonID></PersonID><PersonType></PersonType><IsActive>1</IsActive></row></rows>";
        }
        else {
            FeeRefundXml = FeeRefundXml + "<row><TransactionSubID>0</TransactionSubID><AccountID>" + $("input[id='AccountIDForStudentOutStanding']").val() + "</AccountID><DebitCreditFlag>D</DebitCreditFlag><TransactionAmount>" + $("input[id='RefundAmount']").val() + "</TransactionAmount><ChequeNo></ChequeNo><ChequeDatetime></ChequeDatetime><NarrationDescription>Fee Refund</NarrationDescription><BankName></BankName><BranchName></BranchName><PersonID>" + $("input[id='StudentID']").val() + "</PersonID><PersonType>S</PersonType><IsActive>1</IsActive></row><row><TransactionSubID>0</TransactionSubID><AccountID>" + $("#AccountID :selected").val() + "</AccountID><DebitCreditFlag>C</DebitCreditFlag><TransactionAmount>" + $("input[id='RefundAmount']").val() + "</TransactionAmount><ChequeNo></ChequeNo><ChequeDatetime></ChequeDatetime><NarrationDescription>Fee Refund</NarrationDescription><BankName></BankName><BranchName></BranchName><PersonID></PersonID><PersonType></PersonType><IsActive>1</IsActive></row></rows>";
        }
        FeeRefundMaster.XMLstring = FeeRefundXml;

    },

    //LoadList method is used to load List page
    LoadList: function (centreCode) {
        $.ajax({
            cache: false,
            type: "POST",
            data: { centreCode: centreCode },
            dataType: "html",
            url: '/FeeRefundMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().html(data);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var centreCode = $('input[id="CentreCode"]').val();
        $.ajax({
            cache: false,
            type: "POST",
            data: { centreCode: centreCode, actionMode: actionMode },
            dataType: "html",
            url: '/FeeRefundMaster/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },



     //Fire ajax call to insert update and delete record
    AjaxCallFeeRefundMaster: function () {
        var FeeRefundMasterData = null;
        if (FeeRefundMaster.ActionName == "Create") {
            if ($("#FormCreateFeeRefundMaster").valid()) {
                FeeRefundMasterData = null;
                FeeRefundMasterData = FeeRefundMaster.GetFeeRefundMaster();
                ajaxRequest.makeRequest("/FeeRefundMaster/Create", "POST", FeeRefundMasterData, FeeRefundMaster.Success, "CreateFeeRefundMasterRecord");
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeRefundMaster: function () {
        var Data = {
        };
        if (FeeRefundMaster.ActionName == "Create") {

            Data.ID = $('input[id=ID]').val();
            Data.StudentID = $('input[name=StudentID]').val();
            Data.AccBalsheetID = $('input[name=AccBalsheetID]').val();
            Data.AccSessionID = $('input[id=AccSessionID]').val();
            Data.RefundAmount = $('input[id=RefundAmount]').val();
            Data.Remark = $('#Remark').val();
            Data.XmlString = FeeRefundMaster.XMLstring;

            if ($("#ts4").is(':checked') == true) {
                Data.IsRefundByCashOrBank = 1; //1 for cheque 
                Data.ChequeNumber = $('#ChequeNumber').val();
                Data.ChequeDate = $('#ChequeDate').val();
            }
            else {
                Data.IsRefundByCashOrBank = 0; // 0 for cash
                Data.ChequeNumber = "";
                Data.ChequeDate = "";
            }

           
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            FeeRefundMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

