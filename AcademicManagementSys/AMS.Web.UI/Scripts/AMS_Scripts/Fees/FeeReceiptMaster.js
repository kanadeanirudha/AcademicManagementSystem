var FeeReceiptMaster = {
    ActionName: null,
    map: {},
    XMLstring: null,
    Initialize: function () {
        FeeReceiptMaster.constructor();
    },
    constructor: function () {

        $("#divBankDetails").hide();
        $("#divReceiptDetails").hide();


        // Create new record
        $('#CreateFeeReceiptMasterRecord').on("click", function () {
            FeeReceiptMaster.ActionName = "Create";
            if ($("#ts3").is(':checked') == true) {
                if ($("#FeeBankName").val() == null || $("#FeeBankName").val() == "") {
                    notify("Bank Name should not be blank", "danger");
                    return false;
                }
                if ($("#BranchName").val() == null || $("#BranchName").val() == "") {
                    notify("Branch Name should not be blank", "danger");
                    return false;
                }
                if ($("#BranchCity").val() == null || $("#BranchCity").val() == "") {
                    notify("City should not be blank", "danger");
                    return false;
                }
                if ($("#FeeChequeOrDDNumber").val() == null || $("#FeeChequeOrDDNumber").val() == "") {
                    notify("Cheque Number Or DD Number should not be blank", "danger");                   
                    return false;
                }
                if ($("#FeeChequeOrDDDate").val() == null || $("#FeeChequeOrDDDate").val() == "") {
                    notify("Cheque Date Or DD Date should not be blank", "danger");
                    return false;
                }
                if (FeeReceiptMaster.IsPaymentDetailsValid()) {
                    FeeReceiptMaster.AjaxCallFeeReceiptMaster();
                }
            }
            else {
                if (FeeReceiptMaster.IsPaymentDetailsValid()) {
                    FeeReceiptMaster.AjaxCallFeeReceiptMaster();
                }
            }          
        });

        $('#FeeChequeOrDDDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true
        });

        $("#ts3").on("click", function () {
            if ($("#ts3").is(':checked') == true) {
                FeeReceiptMaster.BindAccountList($('#selectedBalsheetID').val()); // 2 for chequeOrdd
                $("#divBankDetails").show();
            }
            else {
                FeeReceiptMaster.BindAccountList($('#selectedBalsheetID').val()); // 1 for cash
                $("#divBankDetails").hide();
            }
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
                $("#divBankDetails").hide();
                $("#divReceiptDetails").hide();
                $("#ReceiptAmount").val('0');
                $("#ts3").prop("checked", false);
            }

        });

        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;
                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');

                if ($("#selectedBalsheetID").val() != "" && $("#selectedBalsheetID").val() != undefined) {
                    $.ajax({
                        url: "/FeeReceiptMaster/GetStudentDetailsForFeeReceipt",
                        type: "POST",
                        dataType: "json",
                        data: { term: q, balanceSheetID: $("#selectedBalsheetID").val() },
                        success: function (data) {
                            // iterate through the pool of strings and for any string that
                            // contains the substring `q`, add it to the `matches` array
                            $.each(data, function (i, response) {
                                if (substrRegex.test(response.studentName)) {
                                    FeeReceiptMaster.map[response.studentName] = response;
                                    matches.push(response.studentName);
                                }
                            });
                        },
                        async: false
                    })
                    cb(matches);
                }
                else {
                    notify("Balancesheet must be selected", "danger");
                }

            };
        };


        $('.typeahead').typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        },
        {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {

            


            $.ajax({
                url: "/FeeReceiptMaster/GetStudentPaymentDetails",
                type: "POST",
                dataType: "html",
                data: { studentID: FeeReceiptMaster.map[item].studentId },
                ajaxstart: function () {
                    $(".page-loader").show();
                },
                //complete: function () {
                //    $(".page-loader").hide();
                //},
                success: function (data) {
                    $("#divStudentPaymentDetails").html('');
                    $("#divStudentPaymentDetails").html(data);
                    $("#divReceiptDetails").show();
                },
                async: false
            })


            if (String(FeeReceiptMaster.map[item].studentPhoto) != "") {
                document.getElementById("imgStuPhoto").src = "data:" + FeeReceiptMaster.map[item].studentPhotoType + ";base64," + FeeReceiptMaster.map[item].studentPhoto;
            }
            else {
                document.getElementById("imgStuPhoto").src = "Content/materialtheme/img/login.png";
            }
            $("#stuName").html(FeeReceiptMaster.map[item].studentName + '<small id="stuEmailID">' + FeeReceiptMaster.map[item].studentEmailID + '</small>');
            $("#stuAcadYear").text(FeeReceiptMaster.map[item].sessionName);
            $("#stuCourse").text(FeeReceiptMaster.map[item].branchDescription);
            $("#stuSection").text(FeeReceiptMaster.map[item].sectionDetailsDesc);
            $("#stuAdmissionPattern").text(FeeReceiptMaster.map[item].admissionPattern);
            $("#stuGender").text(FeeReceiptMaster.map[item].gender);
            $("#stuEnrollNumber").text(FeeReceiptMaster.map[item].enrollmentNumber);
            $("#stuStdNumber").text(FeeReceiptMaster.map[item].standardNumber);
            $("#stuAdmitAcadYear").text(FeeReceiptMaster.map[item].admitAcademicYear);
            $("#StudentAmissionDetailID").val(FeeReceiptMaster.map[item].studentAmissionDetailID);
            $("#SectionDetailId").val(FeeReceiptMaster.map[item].sectionDetailID);
            $("#StandarNumber").val(FeeReceiptMaster.map[item].standardNumber);
            $("#LastSectionDetailID").val(FeeReceiptMaster.map[item].oldSectionDetailID);
            $("#StudentID").val(FeeReceiptMaster.map[item].studentId);

            FeeReceiptMaster.BindAccountList($('#selectedBalsheetID').val());
        });

        InitAnimatedBorder();

        CloseAlert();

        $("#displayMessage button[class=close]").on("click", function () {
            $("#displayMessage").hide();
        });

        $("#displayMessageBankValidation button[class=close]").on("click", function () {
            $("#displayMessageBankValidation").hide();
        });

        $("#ReceiptAmount").on("keyup", function () {

            var receivedAmount = parseFloat($(this).val());
            var totalDueAmount = parseFloat($("#tblStuPaymentDetails tbody tr:last td").eq(4).text());
            var isReceivedAmountRemaining = 1;

            $("#tblStuPaymentDetails tbody tr").each(function (i) {
                $(this).closest('tr').find('td').eq(5).find('input[type="text"]').val('0.00');
            });

            if (parseFloat(receivedAmount) <= parseFloat(totalDueAmount)) {
                $("#tblStuPaymentDetails tbody tr:last td").eq(5).find('input[type="text"]').val(receivedAmount.toFixed(2));

                $("#tblStuPaymentDetails tbody tr").each(function (i) {
                    var dueAmount = parseFloat($(this).closest('tr').find('td').eq(4).text());
                    if (parseFloat(dueAmount) > 0) {
                        if (parseInt(isReceivedAmountRemaining) == 1) {
                            if (parseFloat(dueAmount) >= parseFloat(receivedAmount)) {
                                $(this).closest('tr').find('td').eq(5).find('input[type="text"]').val(receivedAmount.toFixed(2))
                                isReceivedAmountRemaining = 0;
                            }
                            else {
                                $(this).closest('tr').find('td').eq(5).find('input[type="text"]').val(dueAmount.toFixed(2));
                                receivedAmount = receivedAmount - dueAmount;
                                isReceivedAmountRemaining = 1;
                            }
                        }
                    }
                });
                if ($("input[id='IsLumpsum']").val() == "False") {
                    $("#tblStuPaymentDetails tbody tr").each(function (i) {
                        var dueAmount = parseFloat($(this).closest('tr').find('td').eq(4).text());
                        var depositeAmount = parseFloat($(this).closest('tr').find('td').eq(5).find('input[type="text"]').val());
                        var trLength = parseInt($("#tblStuPaymentDetails tbody tr").length);
                        if (parseFloat(dueAmount) > 0 && parseFloat(depositeAmount) < parseFloat(dueAmount) && i < trLength - 1) {                           
                            $("#NextFeeReceivableDueListDetailsID").val($(this).closest('tr').find('td').eq(5).find('input[id="_feeReceivableDueListDetailsID"]').val());
                            return false;
                        }
                    });
                }
            }
            else if (String(receivedAmount) == "NaN") {
                notify("Please enter Amount Received", "danger");
            }
            else {
                notify("Amount received should not exceed than Total Due Amount", "danger");
            }
        });

    },



    BindAccountList: function (balancesheetID) {
        if (balancesheetID != null && balancesheetID != "") {
            var $ddlAccount = $("#AccountID");
            var isCashOrBankFlag = 0;
            if ($("#ts3").is(':checked') == true) {
                isCashOrBankFlag = 2; // for Bank
            }
            else {
                isCashOrBankFlag = 1; // for cash
            }

            $.ajax({
                url: "/FeeReceiptMaster/GetAccountListForFeeReceipt",
                type: "POST",
                dataType: "json",
                data: { balancesheetID: balancesheetID, isCashOrBankFlag: isCashOrBankFlag },
                success: function (data) {
                    $ddlAccount.empty().append('<option value="">----------------------Select Account--------------------------</option>');
                    $.each(data, function (id, option) {
                        $ddlAccount.append($('<option></option>').val(option.id).html(option.name));
                    });
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    notify("Failed to retrieve Accounts", "danger");
                    $ddlAccount.hide();
                },
                async: false
            })
        }
        else {
            notify("Please select Balancesheet","danger")
        }

    },


    //LoadList method is used to load List page
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        if (Balancesheet != null && Balancesheet != "NaN" && Balancesheet != "") {
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "html",
                url: '/FeeReceiptMaster/List',
                success: function (data) {
                    //Rebind Grid Data
                    $('#ListViewModel').html(data);
                }
            });
        }
        else {
            $('#SuccessMessage').html("Please select balancesheet");
            $('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
        }
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, feeCriteriaMasterID) {
        $.ajax({
            cache: false,
            type: "POST",
            data: { actionMode: actionMode, feeCriteriaMasterID: feeCriteriaMasterID },
            dataType: "html",
            url: '/FeeReceiptMaster/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },



    AllocateFeeStructure: function () {
        $('#CreateFeeReceiptMaster').on("click", function () {
            FeeReceiptMaster.ActionName = "Create";
            if ($("#FeeStructureSessionMasterID").val() == 0 && $("#IsInstallmentApplicable").val() == "True") {
                if (FeeReceiptMaster.IsValidInstallmentXml()) {
                    FeeReceiptMaster.AjaxCallFeeReceiptMaster();
                }
                else {
                    $('#SuccessMessage').html("Fill installment details properly");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                }
                $("#CreateFeeReceiptMaster").attr("disabled", false);
            }
            else if ($("#FeeStructureSessionMasterID").val() == 0 && $("#IsInstallmentApplicable").val() == "False") {
                if ($("#tblData3 tbody tr").length >= 1) {
                    FeeReceiptMaster.AjaxCallFeeReceiptMaster();
                }
                else {
                    $('#SuccessMessage').html("No student available");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                }
            }

            if ($("#FeeStructureSessionMasterID").val() > 0) {
                if ($("#tblData3 tbody tr").length >= 1) {
                    FeeReceiptMaster.AjaxCallFeeReceiptMaster();
                }
                else {
                    $('#SuccessMessage').html("No student available");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                }
                $("#CreateFeeReceiptMaster").attr("disabled", false);
            }
            FeeReceiptMaster.XMLstring = "";
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallFeeReceiptMaster: function () {
        var FeeReceiptMasterData = null;
        if (FeeReceiptMaster.ActionName == "Create") {
            $("#FormCreateFeeReceiptMaster").validate();
            if ($("#FormCreateFeeReceiptMaster").valid()) {
                FeeReceiptMasterData = null;
                FeeReceiptMasterData = FeeReceiptMaster.GetFeeReceiptMaster();
                ajaxRequest.makeRequest("/FeeReceiptMaster/Index", "POST", FeeReceiptMasterData, FeeReceiptMaster.success, "CreateFeeReceiptMasterRecord");
            }
        }
        if (FeeReceiptMaster.ActionName == "FeeStructureRequestApproval") {
            debugger;
            if ($("#FormFeeStructureRequestAppronal").valid()) {
                FeeReceiptMasterData = null;
                FeeReceiptMasterData = FeeReceiptMaster.GetFeeReceiptMaster();
                ajaxRequest.makeRequest("/FeeReceiptMaster/CreateFeeStructureRequestApproval", "POST", FeeReceiptMasterData, FeeReceiptMaster.success);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeReceiptMaster: function () {
        var Data = {
        };
        if (FeeReceiptMaster.ActionName == "Create") {
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.AccBalanceSheetID = $('#selectedBalsheetID').val();
            Data.FeeStructureMasterID = $('input[name=FeeStructureMasterID]').val();
            Data.AccountID = $('#AccountID :selected').val();
            Data.IsLumpsum = $('input[name=IsLumpsum]').val();
            Data.NextFeeReceivableDueListDetailsID = $('input[name=NextFeeReceivableDueListDetailsID]').val();
            Data.AccSessionId = $('input[name=AccSessionId]').val();
            Data.StudentID = $('input[id=StudentID]').val();
            Data.ReceiptAmount = $('#ReceiptAmount').val();
            if ($("#ts3").is(':checked') == true) {
                Data.ReceiptType = 2;
            }
            else {
                Data.ReceiptType = 1;
            }
            Data.FeeBankName = $('#FeeBankName').val();
            Data.BranchName = $('#BranchName').val();
            Data.BranchCity = $('#BranchCity').val();
            Data.FeeChequeOrDDNumber = $('#FeeChequeOrDDNumber').val();
            Data.FeeChequeOrDDDate = $('#FeeChequeOrDDDate').val();
            if ($("#IschequeORDD").is(':checked') == true) {
                Data.IschequeORDD = 1; //1 for cheque
            }
            else {
                Data.IschequeORDD = 0; //0 for DD
            }
            Data.LateFeeAmount = $('#LateFeeAmount').val();
            Data.XMLstring = FeeReceiptMaster.XMLstring;
        }
        return Data;
    },

    IsPaymentDetailsValid: function () {

        var receivedAmount = parseFloat($("#ReceiptAmount").val());
        var totalDueAmount = parseFloat($("#tblStuPaymentDetails tbody tr:last td").eq(4).text());
        var trLength = parseInt($("#tblStuPaymentDetails tbody tr").length);
        ParameterXml = "<rows>";
        if (parseFloat(receivedAmount) <= parseFloat(totalDueAmount)) {

            $("#tblStuPaymentDetails tbody tr").each(function (i) {
                var dueAmount = parseFloat($(this).closest('tr').find('td').eq(4).text());
                var depositeAmount = parseFloat($(this).closest('tr').find('td').eq(5).find('input[type="text"]').val());

                if (parseFloat(dueAmount) > 0 && parseFloat(depositeAmount) > 0 && i < trLength - 1) {

                    ParameterXml = ParameterXml
                                                + "<row>"
                                                + "<ID>0</ID>"
                                                + "<FeeReceivableDueListMasterID>" + parseFloat($(this).closest('tr').find('td').eq(5).find('input[id="_feeReceivableDueListMasterID"]').val()) + "</FeeReceivableDueListMasterID>"
                                                + "<FeeReceivableDueListDetailsID>" + parseFloat($(this).closest('tr').find('td').eq(5).find('input[id="_feeReceivableDueListDetailsID"]').val()) + "</FeeReceivableDueListDetailsID>"
                                                + "<FeeReceivableDueListFeeTypeDetailsID>" + parseFloat($(this).closest('tr').find('td').eq(5).find('input[id="_feeReceivableDueListFeeTypeDetailsID"]').val()) + "</FeeReceivableDueListFeeTypeDetailsID>"
                                                + "<InstallmentNumber>" + parseFloat($(this).closest('tr').find('td').eq(5).find('input[id="_installmentNumber"]').val()) + "</InstallmentNumber>"
                                                + "<FeeStructureInstallmentMasterIDOrStructureDetailsID>" + parseFloat($(this).closest('tr').find('td').eq(5).find('input[id="_feeStructureInstallmentMasterIDOrStructureDetailsID"]').val()) + "</FeeStructureInstallmentMasterIDOrStructureDetailsID>"
                                                + "<FeeSubTypeID>" + parseFloat($(this).closest('tr').find('td').eq(5).find('input[id="_feeSubTypeID"]').val()) + "</FeeSubTypeID>"
                                                + "<FeeSubTypeAmount>" + parseFloat($(this).closest('tr').find('td').eq(5).find('input[id="_feeSubTypeAmount"]').val()) + "</FeeSubTypeAmount>"
                                                + "<RecievedAmount>" + depositeAmount + "</RecievedAmount>"
                                                + "</row>";
                }
            });

            if (ParameterXml.length > 6) {
                FeeReceiptMaster.XMLstring = ParameterXml + "</rows>";
                return true;
            }
            else {
                FeeReceiptMaster.XMLstring = "";
                notify("Please add received amount", "danger");
                return false;
            }
        }
        else if (String(receivedAmount) == "NaN") {
            notify("Please enter Amount Received", "danger");
            return false;
        }
        else {
            notify("Amount received should not exceed than Total Due Amount", "danger");
            return false;
        }
    },


    //this is used to for showing successfully record creation message and reload the list view
    success: function (data) {
        var splitData = data.errorMessage.split(',');
        if (splitData[1] == "success") {
            $.ajax({
                url: "/FeeReceiptMaster/GetStudentPaymentDetails",
                type: "POST",
                dataType: "html",
                data: { studentID: $("#StudentID").val() },
                ajaxstart: function () {
                    $(".page-loader").show();
                },
                //complete: function () {
                //    $(".page-loader").hide();
                //},
                success: function (data) {
                    $("#divStudentPaymentDetails").html('');
                    $("#divStudentPaymentDetails").html(data);
                    $("#divReceiptDetails").show();
                },
                async: false
            });
            $("#ReceiptAmount").val('0');
            $("#LateFeeAmount").val('0');
            $("#FeeBankName").val('');
            $("#BranchCity").val('');
            $("#FeeChequeOrDDNumber").val('');
            $("#FeeChequeOrDDDate").val('');
            $("#IschequeORDD").prop("checked", false);
            $("#AccountID").val('');
            notify("Fees paid successfully", "success")
            
        }
        else {
            notify("Fees not paid successfully", "danger")
        }
 
    },

    deleteSuccess: function (data) {
        var feeCriteriaMasterID = data.SelectedFeeCriteriaMasterID;
        var splitData = data.errorMessage.split(',');
        FeeReceiptMaster.ReloadList(splitData[0], splitData[1], splitData[2], feeCriteriaMasterID);
        parent.$.colorbox.close();
    },
};

