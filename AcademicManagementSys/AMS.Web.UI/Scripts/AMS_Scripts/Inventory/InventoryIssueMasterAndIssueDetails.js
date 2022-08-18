
//this class contain methods related to Issue And Transaction Details functionality

var InventoryIssueMasterAndIssueDetails = {

    //Member variables
    ActionName: null,
    XMLstring: null,
    flag: true,

    //Class intialisation method
    Initialize: function () {
        InventoryIssueMasterAndIssueDetails.constructor();
    },

    //Attach all event of page
    constructor: function () {

        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
        $("#ItemName").autocomplete({
            source: function (request, response) {
                if ($("#FromLocationID").val() != "" && $("#UptoLocationID").val() != "") {
                    if ($("#FromLocationID").val() > 0 && $("#UptoLocationID").val() > 0) {
                        if ($("#TransactionDate").val() != "") {
                            $.ajax({
                                url: "/InventoryIssueMasterAndIssueDetails/GetItemSearchList",
                                type: "POST",
                                dataType: "json",
                                data: { "term": request.term, "locationID": $("#FromLocationID").val() },
                                success: function (data) {
                                    response($.map(data, function (item) {

                                        return { label: item.name, value: item.name, id: item.id, rate: item.rate, currentStockQty: item.currentStockQty };
                                    }))
                                }
                            })
                        }
                        else {
                            $('#msgDiv').html("Please select date.");
                            $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                            return false;
                        }
                    }
                    else {
                        $('#msgDiv').html("Please select both location first.");
                        $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                        return false;
                    }
                } else {

                    $("#tblData tbody tr").remove();
                    $("#ItemName").val("");
                    $("#AvailbleQuantity").val(0);
                    $("#IssueQuantity").val(0);
                    $("#ItemID").val("");

                    $('#msgDiv').html("Please select both location first 1.");
                    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);
                $("#ItemID").val(parseInt(ui.item.id));
                $("#AvailbleQuantity").val(ui.item.currentStockQty);
                $("#IssueQuantity").focus();
                //$("#UnitID").val(ui.item.unitID);
                //$("#AvailableStock").val(ui.item.currentStockQty);
            }
        });

        // Create new record
        $('#addItem').on("click", function () {
            var availbleQuantity = $("#AvailbleQuantity").val();
            var issueQuantity = $("#IssueQuantity").val();
            //to check duplication of item while adding the item        
            var DataArray = [];
            $('#DivAddRowTable input[type=text]').each(function () {
                DataArray.push($(this).val());
            });
           
            var TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 3) {
                if (DataArray[i] == $('#ItemID').val()) {
                    $('#msgDiv').html("You Cannot Enter the same item Twice");
                    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    $("#ItemName").val("");
                    $("#ItemID").val(0);
                    $("#AvailbleQuantity").val("");
                    $("#IssueQuantity").val("");
                    
                    return false
                }
            }
            //End of Code
            if (parseFloat(issueQuantity) > 0) {
                if (parseFloat(availbleQuantity) >= parseFloat(issueQuantity) && parseFloat(issueQuantity) > 0.00 && parseFloat($("#ItemID").val()) > 0) {

                    if ($("#FromLocationID").val() != "" && $("#UptoLocationID").val() != "") {
                        $("#tblData tbody").append(
                            "<tr>" +
                            "<td ><input type='text' value=" + $('#ItemID').val() + " style='display:none' /> " + $('#ItemName').val() + "</td>" +
                           "<td><input id='availbleQuantity' type='text' value=" + parseFloat(availbleQuantity).toFixed(2) + " style='display:none' /> " + parseFloat(availbleQuantity).toFixed(2) + "</td>" +
                            "<td><input id='issueQuantity' type='text' maxlength='8' value=" + parseFloat(issueQuantity).toFixed(2) + " style='width:60%;height:16px;text-align:right'/></td>" +

                            "<td  style='text-align:center; '><i class='icon-trash' style='cursor:pointer;'  title = Delete></td>" +
                            "</tr>");
                        $("#ItemName").val("");
                        $("#AvailbleQuantity").val(0);
                        $("#IssueQuantity").val(0);
                        $("#ItemID").val("");
                        $('#ItemName').focus();

                        $('input[id*=issueQuantity]').on("keydown", function (e) {
                            AMSValidation.AllowNumbersWithDecimalOnly(e);
                            AMSValidation.NotAllowSpaces(e);
                        });
                        $("#tblData tbody").on('keyup', "tr td input[id^=issueQuantity]", function (e) {
                            if (parseFloat($(this).closest('tr').find('td input[id^=issueQuantity]').val()) > parseFloat($(this).closest('tr').find('td input[id^=availbleQuantity]').val())) {

                                $(this).closest('tr').find('td input[id^=issueQuantity]').val(0);
                                $('#msgDiv').html("Please Issue less quantity then availble quantity.");
                                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                            }
                            AMSValidation.AllowNumbersWithDecimalOnly(e);
                            AMSValidation.NotAllowSpaces(e);
                        });

                        $('input[id^=issueQuantity]').on("keyup", function (e) {
                            parseFloat($(this).val()).toFixed(2);
                        });
                    }
                    else {
                        $("#tblData tbody tr").remove();
                        $("#ItemName").val("");
                        $("#AvailbleQuantity").val(0);
                        $("#IssueQuantity").val(0);
                        $("#ItemID").val("");
                        $('#ItemName').focus();
                        $('#msgDiv').html("Please check location");
                        $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    }
                }
                else if ($("#ItemID").val() == 0) {
                    $('#msgDiv').html("Invalid item selected");
                    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
                else if (availbleQuantity < issueQuantity || availbleQuantity == issueQuantity) {
                    $('#msgDiv').html("Issue Quantity Should be less then Availble quantity");
                    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
                else if ($("#AvailbleQuantity").val() == "" || $("#AvailbleQuantity").val() == 0 || $("#AvailbleQuantity").val() == '.') {
                    $('#msgDiv').html("Please Enter Issue Quantity.");
                    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
            }
            else {
                $('#msgDiv').html("Invalid issue quantity.");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        //Delete
        $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
            $(this).closest('tr').remove();
            InventoryIssueMasterAndIssueDetails.TotalItem();
        });

        $('#CreateInventoryIssueMasterAndIssueDetails').on("click", function () {
            //InventoryIssueMasterAndIssueDetails.GetXmlData();
            InventoryIssueMasterAndIssueDetails.ActionName = "Create";
            if ($("#FromLocationID").val() != "" && $("#UptoLocationID").val() != "") {
                InventoryIssueMasterAndIssueDetails.GetXmlData();

                if (InventoryIssueMasterAndIssueDetails.flag == true)
                {
                    if (InventoryIssueMasterAndIssueDetails.XMLstring != null && InventoryIssueMasterAndIssueDetails.XMLstring != "") {
                        $('#CreateInventoryIssueMasterAndIssueDetails').attr("disabled", true);
                        InventoryIssueMasterAndIssueDetails.AjaxCallInventoryIssueMasterAndIssueDetails();
                    }
                    else {
                        $('#msgDiv').html("No data available in table");
                        $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

                    }

                }
                
                 

            } else {
                $("#tblData tbody tr").remove();
                $("#ItemName").val("");
                $("#AvailbleQuantity").val(0);
                $("#IssueQuantity").val(0);
                $("#ItemID").val("");
                $('#ItemName').focus();
                $('#msgDiv').html("Please check location");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        $(".ajax").colorbox();

        $('#Quantity').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#Quantity').on("keyup", function (e) {
            $("#EstimationAmount").val((parseFloat($("#Rate").val()) * parseFloat($(this).val())).toFixed(2));
        });


        $('#FromLocationID').on("change", function () {
            if ($("#FromLocationID").val() == $("#UptoLocationID").val()) {

                $("#tblData tbody tr").remove();
                $("#ItemName").val("");
                $("#AvailbleQuantity").val(0);
                $("#IssueQuantity").val(0);
                $("#ItemID").val("");

                $('#msgDiv').html("Please select different  location.");
                $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                return false;
            } else {
                return true;
            }
        });
        $('#UptoLocationID').on("change", function () {
            if ($("#FromLocationID").val() == $("#UptoLocationID").val()) {

                $("#tblData tbody tr").remove();
                $("#ItemName").val("");
                $("#AvailbleQuantity").val(0);
                $("#IssueQuantity").val(0);
                $("#ItemID").val("");

                $('#msgDiv').html("Please select different  location.");
                $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                return false;
            } else {
                return true;
            }
        });

        $('#ItemName').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#ItemName").val("");
                $("#AvailbleQuantity").val(0);
                $("#IssueQuantity").val(0);
                $("#ItemID").val("");
                $("#ItemName").focus();
            }
        });

        $("#IssueQuantity").on("keydown", function (e) {
            
            //alert("hii");
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#TransactionDate').on("keydown", function (e) {
            $('#ItemName').focus();
            return false;
        });

        $('#ItemName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
     
        ////Date picker for Transaction Date
        //$('#TransactionDate').datepicker({
        //    dateFormat: 'd M yy',
        //    numberOfMonths: 1,
        //    minDate:0
        //})

        $('#IssueQuantity').on("keypress", function (e) {
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $("#tblData tbody").on("keypress", "tr td input[id^=issueQuantity]", function (e) {
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

    },

    TotalItem: function () {
        var length = $("#tblData tbody tr").length;
        $("#TotalItem").val(length);
    },

    //LoadList method is used to load List page
    LoadList: function () {
        var balancesheet = $("#selectedBalsheetID").val();
        if (balancesheet != null) {
            $.ajax(
           {
               cache: false,
               type: "GET",
               data: { "selectedBalsheet": balancesheet },
               dataType: "html",
               url: '/InventoryIssueMasterAndIssueDetails/List',
               success: function (data) {
                   //Rebind Grid Data
                   $('#ListViewModel').html(data);
               }
           });
        }
        else {
            $('#SuccessMessage').html("Please select balancesheet");
            $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
        }

    },

    ReloadList: function (message, colorCode, actionMode) {
        var balancesheet = $("#selectedBalsheetID").val();
        $.ajax({
            cache: false,
            type: "GET",
            data: { "selectedBalsheet": balancesheet },
            dataType: "html",
            url: '/InventoryIssueMasterAndIssueDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);

                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },

    //Method to create xml
    GetXmlData: function () {
        InventoryIssueMasterAndIssueDetails.flag = true;
        var DataArray = [];
        $('#DivAddRowTable input[type=text]').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        var ParameterXml = "<rows>";
    
        for (var i = 0; i < TotalRecord; i = i + 3) {
            if (parseFloat(DataArray[i + 2]).toFixed(2) > 0 ){
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i] + "</ItemID><Quantity>" + parseFloat(DataArray[i + 2]).toFixed(2) + "</Quantity></row>";
            }
            else {
                $('#msgDiv').html("Please Enter Issue Quantity");
                $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                InventoryIssueMasterAndIssueDetails.flag = false;
               // ParameterXml = "";
                break;
            }
        }
        if (ParameterXml.length > 6)
            InventoryIssueMasterAndIssueDetails.XMLstring = ParameterXml + "</rows>";
        else
            InventoryIssueMasterAndIssueDetails.XMLstring = "";
    },

    //Fire ajax call to insert update and delete record
    AjaxCallInventoryIssueMasterAndIssueDetails: function () {
        var InventoryIssueMasterAndIssueDetailsData = null;
        if (InventoryIssueMasterAndIssueDetails.ActionName == "Create") {
            $("#FormCreateInventoryEstimationMasterAndDetails").validate();
            if ($("#FormCreateInventoryEstimationMasterAndDetails").valid()) {
                InventoryIssueMasterAndIssueDetailsData = null;
                InventoryIssueMasterAndIssueDetailsData = InventoryIssueMasterAndIssueDetails.GetInventoryIssueMasterAndIssueDetails();
                ajaxRequest.makeRequest("/InventoryIssueMasterAndIssueDetails/Create", "POST", InventoryIssueMasterAndIssueDetailsData, InventoryIssueMasterAndIssueDetails.Success);
            }
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetInventoryIssueMasterAndIssueDetails: function () {
        var Data = {
        };
        Data.TransactionDate = $('#TransactionDate').val();
        Data.IssueFromLocationID = $('#FromLocationID').val();
        Data.IssueToLocationID = $('#UptoLocationID').val();
        Data.CentreCode = null;
        Data.BalanceSheetID = $("#selectedBalsheetID").val();
        Data.IssueDetails = InventoryIssueMasterAndIssueDetails.XMLstring;

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        $('#CreateInventoryIssueMasterAndIssueDetails').attr("disabled", false);
        InventoryIssueMasterAndIssueDetails.ReloadList("Record created successfully", "#9FEA7A", "0");
    },
};