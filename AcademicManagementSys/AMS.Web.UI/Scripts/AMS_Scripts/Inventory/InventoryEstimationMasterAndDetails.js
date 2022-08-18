/// <reference path="../../bootstrap.min.js" />
//this class contain methods related to nationality functionality
var InventoryEstimationMasterAndDetails = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    totalTaxString: 0,
    totalDiscountString: 0,
    EstimateLocationWiseXMLstring: null,
    flag: true,
    //Class intialisation method
    Initialize: function () {
        InventoryEstimationMasterAndDetails.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $("#CustomerName").focus();
       
        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
        $("#ItemName").autocomplete({

            source: function (request, response) {
                
                $.ajax({

                    url: "/InventoryEstimationMasterAndDetails/GetItemSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { "term": request.term, "locationID": $("#LocationID").val(), "selectedBalsheet": $("#selectedBalsheetID").val() },
                    success: function (data) {
                        response($.map(data, function (item) {

                            return { label: item.name, value: item.name, id: item.id, rate: item.rate, itemCode: item.itemCode, picture: item.picture, currencyCode: item.currencyCode, currentStockQty: item.currentStockQty, unitID: item.unitID, unitCode: item.unitCode, GenTaxGroupMasterID: item.GenTaxGroupMasterID, TaxRatePercentage: item.TaxRatePercentage, RateDecreaseByPercentage: item.RateDecreaseByPercentage };
                        }))
                    }
                })
            },
            select: function (event, ui) {

                $(this).val(ui.item.label);
              
                // display the selected text
                $("#Rate").val(parseFloat(ui.item.rate).toFixed(2));
                $("#ItemID").val(parseInt(ui.item.id));
                $("#UnitCode").val(ui.item.unitCode);
                
                $("#GenTaxGroupMasterID").val(ui.item.GenTaxGroupMasterID);
                $("#TotalTaxAmount").val(ui.item.TaxRatePercentage);
                $("#RateDecreaseByPercentage").val(ui.item.RateDecreaseByPercentage);
                $("#Quantity").focus();
                //$("#UnitID").val(ui.item.unitID);
                //$("#AvailableStock").val(ui.item.currentStockQty);

                if (ui.item.GenTaxGroupMasterID == 0) {
                    $("#TotalTaxAmount").prop("disabled", true);
                    $("#TotalTaxAmount").val("0");
                    //    $("#taxpercentage").val(ui.item.TaxRatePercentage);

                }
                else {
                    $("#TotalTaxAmount").prop("disabled", true);
                    $("#TotalTaxAmount").val("");
                    $("#TotalTaxAmount").val(ui.item.TaxRatePercentage);
                    $("#IsRateInclusiveTax").prop("disabled", false);

                }

            }
        });

       

        // Create new record
        $('#addItem').on("click", function () {
            
            var tax = $('#TotalTaxAmount').val();
            var totalestimate = parseFloat($('#EstimationAmount').val()).toFixed(2)
            var totalwithtax = ((totalestimate * tax) / 100).toFixed(2);

            var totaldiscount = $('#TotalDiscountAmount').val();
            var ratedownpercentage = $("#RateDecreaseByPercentage").val();
            if (parseFloat($("#TotalDiscountAmount").val()) > parseFloat($("#RateDecreaseByPercentage").val())) {
                $('#msgDiv').html("Maximum discount is " + parseFloat($("#RateDecreaseByPercentage").val()) + " %.");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else {
                var totalwithdiscount = ((totalestimate * totaldiscount) / 100);
            }
            var EstimationTotal = (totalestimate - totalwithdiscount);
            var EstimationTotal1 = parseFloat(parseFloat(EstimationTotal) + parseFloat(totalwithtax)).toFixed(2);
            $('#EstimationAmount').val(EstimationTotal1);

            //to check duplication of item while adding the item
            
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 8) {
                if (DataArray[i] == $('#ItemID').val()) {
                    $('#msgDiv').html("You Cannot Enter the same item Twice");
                    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    $("#ItemName").val("");
                    $("#ItemID").val(0);
                    $("#Quantity").val("");
                    $("#UnitCode").val("");
                    $("#Rate").val("");
                    $("#EstimationAmount").val("");
                    $("#TotalTaxAmount").val("");
                    $("#TotalDiscountAmount").val("");

                   
                    return false
                }
            }

            //End Of Code



            //if (parseFloat($('#AvailableStock').val()) > parseFloat($('#Quantity').val())) 
            if ($('#ItemName').val() != "" && $("#ItemID").val() > 0 && parseFloat($("#Quantity").val()) > 0) {
                $("#tblData tbody").append(
                    "<tr>" +
                    "<td ><input type='text' value=" + $('#ItemID').val() + " style='display:none' /> " + $('#ItemName').val() + "</td>" +
                    "<td><input type='text' value=" + $('#Rate').val() + " style='display:none' /> " + $('#Rate').val() + "</td>" +
                    "<td>" + $('#UnitCode').val() + "</td>" +
                    "<td><input id='quantity'  type='text' value=" + parseFloat($('#Quantity').val()).toFixed(2) + " style='width:60%;height:16px;text-align:right'/></td>" +
                    "<td>" + parseFloat($('#EstimationAmount').val()).toFixed(2) + "</td>" +

                  "<td style='display:none' > <input id='GenTaxGroupMasterID' type='text' value=" + $('#GenTaxGroupMasterID').val() + " /> </td>" +
                   "<td style='display:none'><input type='text' id='taxPercentage' value=" + $('#TotalTaxAmount').val() + " /> " + totalwithtax + "</td>" +
                    "<td style='display:none'><input id='discounts' type='text' value=" + $('#TotalDiscountAmount').val() + "> " + totalwithdiscount + "</td>" +
                    "<td  style='text-align:center; '><i class='icon-trash' style='cursor:pointer;'  title = Delete><input id='tax' type='hidden' value=" + totalwithtax + " /> <input id='discount' type='hidden' value=" + totalwithdiscount + " /></td>" +
                    "</tr>");
                $("#ItemName").val("");
                $("#Rate").val(0);
                $("#UnitCode").val("");
                $("#Quantity").val(0);
                $("#ItemID").val("");
                $("#EstimationAmount").val(0);
                $("#TotalTaxAmount").val(0);
                $("#TotalDiscountAmount").val(0);
                $('#ItemName').focus();

                $('input[id^=quantity]').on("keydown", function (e) {                    
                    AMSValidation.AllowNumbersWithDecimalOnly(e);
                    AMSValidation.NotAllowSpaces(e);
                });
                $('input[id^=quantity]').on("keyup", function (e) {
                    parseFloat($(this).val()).toFixed(2);
                });
                InventoryEstimationMasterAndDetails.TotalItem();
                InventoryEstimationMasterAndDetails.TotalBillAmount();
                InventoryEstimationMasterAndDetails.TotalTaxAmount();
                InventoryEstimationMasterAndDetails.TotalDiscountAmount();


            }
            else if ($("#ItemID").val() == 0) {
                $('#msgDiv').html("Invalid item selected");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
            else if ($("#ItemName").val() == "") {
                $('#msgDiv').html("Please Enter Item Name.");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
            else if ($("#Quantity").val() == "" || $("#Quantity").val() == 0 || $("#Quantity").val() == '.') {
                $('#msgDiv').html("Please Enter Quantity.");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
        });
        //On Dump Quantity Change
        $("#tblData tbody").on("keyup", "tr td input[id^=quantity]", function () {
            
            var quantity = parseFloat($(this).closest('tr').find('td input[id^=quantity]').val());
            var rate = parseFloat($(this).closest('tr').find('td').eq(1).text());
            if (parseFloat(quantity) == 0 || parseFloat(quantity) <= 0) {
                $('#msgDiv').html("Please enter Quantity.");
                $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

            }

            var totalamount = ((quantity * rate).toFixed(2));

            var taxRate = parseFloat($(this).closest('tr').find('td input[id^=taxPercentage]').val());
            var taxamount = ((totalamount * taxRate) / 100).toFixed(2);

            $(this).closest('tr').find('td input[id=tax]').val(taxamount);

            var discount = parseFloat($(this).closest('tr').find('td input[id^=discount]').val());
            var ratedown = $("#RateDecreaseByPercentage").val();
            if (discount > ratedown) {
                var discountamount = 0;
            }
            else {
                var discountamount = ((totalamount * discount) / 100).toFixed(2);
            }

            $(this).closest('tr').find('td input[id=discount]').val(discountamount);
            $(this).closest('tr').find('td').eq(4).text(parseFloat(parseFloat(totalamount - discountamount) + parseFloat(taxamount)).toFixed(2));
            InventoryEstimationMasterAndDetails.TotalBillAmount();
            $(this).closest('tr').find('td').eq(taxPercentage).text(parseFloat(taxamount).toFixed(2));
            InventoryEstimationMasterAndDetails.TotalTaxAmount();
            $(this).closest('tr').find('td').eq(discounts).text(parseFloat(discount).toFixed(2));
            InventoryEstimationMasterAndDetails.TotalDiscountAmount();
        });

        $('#ItemName').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#ItemName").val("");
                $("#UnitCode").val("");
                $("#Rate").val("");
                $("#Quantity").val("");
                $("#EstimationAmount").val("");
                $("#TotalTaxAmount").val("");
                $("#TotalDiscountAmount").val("0");
            }
        });
        $('#CustomerName').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#CustomerName").val("");
                $("#CustomerMobileNumber").val("");
                $("#CustomerAddress").val("");
            }
        });
        //Delete
        $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
            $(this).closest('tr').remove();
            InventoryEstimationMasterAndDetails.TotalItem();
            InventoryEstimationMasterAndDetails.TotalBillAmount();
            InventoryEstimationMasterAndDetails.TotalTaxAmount();
            InventoryEstimationMasterAndDetails.TotalDiscountAmount();
        });

        $('#CreateInventoryEstimationMasterAndDetails').on("click", function () {
            
            InventoryEstimationMasterAndDetails.ActionName = "Create";
            InventoryEstimationMasterAndDetails.GetXmlData();
            //if (InventoryEstimationMasterAndDetails.flag == true) {
            //    if (InventoryEstimationMasterAndDetails.XMLstring != null && InventoryEstimationMasterAndDetails.XMLstring != "") {
            InventoryEstimationMasterAndDetails.AjaxCallInventoryEstimationMasterAndDetails();
            //    }
            //    else {
            //        $('#msgDiv').html("No data available in table");
            //        $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            //    }
            //}
        });
        //FOLLOWING FUNCTION IS SEARCHLIST OF Customer list
        $("#CustomerName").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/InventoryEstimationMasterAndDetails/GetCustomerNameSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            
                            return { label: item.name, value: item.name, id: item.id, contactNumber: item.contactNumber, address: item.address };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);                                             // display the selected text
                $("#CustomerID").val(parseInt(ui.item.id));
               
                $("#CustomerMobileNumber").val(ui.item.contactNumber);
                $("#CustomerAddress").val(ui.item.address);
            }
        });

      
        $('#CreateInventoryEstimationLocationwise').on("click", function () {
            
            InventoryEstimationMasterAndDetails.ActionName = "CreateEstimateLocationWise";
            InventoryEstimationMasterAndDetails.GetXmlDataLocationwise();
            if (InventoryEstimationMasterAndDetails.EstimateLocationWiseXMLstring != null && InventoryEstimationMasterAndDetails.EstimateLocationWiseXMLstring != "") {
                InventoryEstimationMasterAndDetails.AjaxCallInventoryEstimationMasterAndDetails();
            }
            else {
                $('#msgDiv').html("No record selected");
                $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

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
        $('#CustomerName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        
        $('#TotalDiscountAmount').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#CustomerMobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#Quantity').on("keyup", function (e) {
            $("#EstimationAmount").val((parseFloat($("#Rate").val()) * parseFloat($(this).val())).toFixed(2));

        });

        $('#ItemName').on("keydown", function (e) {            
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#Quantity').on("keypress", function (e) {            
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#TotalDiscountAmount').on("keypress", function (e) {            
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $("#tblData tbody").on("keypress", "tr td input[id^=quantity]", function (e) {            
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode==95) {
                return false;
            }
        });

    },
    TotalBillAmount: function () {        
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(4).text()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalBillAmount").val(a.toFixed(2));

    },
    TotalTaxAmount: function () {
        
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmountt").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(6).text()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalTaxAmountt").val(a.toFixed(2));

    },
    TotalDiscountAmount: function () {
        
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalDiscountAmountt").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(7).text()).toFixed(2);
                a += parseFloat(x);
            }
        });

        $("#TotalDiscountAmountt").val(a.toFixed(2));

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
               url: '/InventoryEstimationMasterAndDetails/List',
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

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        
        var balancesheet = $("#selectedBalsheetID").val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { "selectedBalsheet": balancesheet, "actionMode": actionMode },
            dataType: "html",
            url: '/InventoryEstimationMasterAndDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                ////twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },
    //Method to create xml
    GetXmlData: function () {
        
        var DataArray = [];
        InventoryEstimationMasterAndDetails.flag = true;
        $('#DivAddRowTable input').each(function () {
            DataArray.push($(this).val());
        });
        var abc = 0;
        var abc1 = 0;
        var TotalRecord = DataArray.length;
        // alert(DataArray);
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 8) {
            if (DataArray[i + 2] != 0) {

                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i] + "</ItemID><Rate>" + parseFloat(DataArray[i + 1]).toFixed(2) + "</Rate><Quantity>" + parseFloat(DataArray[i + 2]).toFixed(2) + "</Quantity><TaxAmount>" + parseFloat(DataArray[i + 6]).toFixed(2) + "</TaxAmount><GenTaxGroupMasterID>" + DataArray[i + 3] + "</GenTaxGroupMasterID><DiscountAmount>" + parseFloat(DataArray[i + 7]).toFixed(2) + "</DiscountAmount></row>";
                abc = parseFloat(parseFloat(abc) + parseFloat(DataArray[i + 6]));
                abc1 = parseFloat(parseFloat(abc1) + parseFloat(DataArray[i + 7]));
            }
            else {
                $('#msgDiv').html("Please Enter Valid data");
                $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                InventoryEstimationMasterAndDetails.flag = false;
                break;
            }
            //InventoryEstimationMasterAndDetails.totalTaxString = parseFloat(InventoryEstimationMasterAndDetails.totalTaxString) + DataArray[i + 6]
            // InventoryEstimationMasterAndDetails.totalDiscountString = parseFloat((parseFloat(InventoryEstimationMasterAndDetails.totalDiscountString)) + (parseFloat(DataArray[i + 7]).toFixed(2)))
            
        }
        //  alert(ParameterXml);
        if (ParameterXml.length > 10)
            InventoryEstimationMasterAndDetails.XMLstring = ParameterXml + "</rows>",
            InventoryEstimationMasterAndDetails.totalTaxString = abc,
            InventoryEstimationMasterAndDetails.totalDiscountString = abc1;
        else
            InventoryEstimationMasterAndDetails.XMLstring = "";

        //alert(InventoryEstimationMasterAndDetails.XMLstring);
    },
    //Method to create xml locationwise
    GetXmlDataLocationwise: function () {
        
        var DataArray = [];
        $('#tblEstimateLocationwise input[type=checkbox]').each(function () {
            if (this.checked == true) {
                DataArray.push($(this).val());
            }
        });

        var TotalRecord = DataArray.length;
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i++) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i].split('~')[0] + "</ItemID><Rate>" + DataArray[i].split('~')[1] + "</Rate><Quantity>" + DataArray[i].split('~')[2] + "</Quantity></row>";
        }
        if (ParameterXml.length > 6)
            InventoryEstimationMasterAndDetails.EstimateLocationWiseXMLstring = ParameterXml + "</rows>";
        else
            InventoryEstimationMasterAndDetails.EstimateLocationWiseXMLstring = "";

        // alert(InventoryEstimationMasterAndDetails.EstimateLocationWiseXMLstring);
    },

    //Fire ajax call to insert update and delete record
    AjaxCallInventoryEstimationMasterAndDetails: function () {
        var InventoryEstimationMasterAndDetailsData = null;
        if (InventoryEstimationMasterAndDetails.ActionName == "Create") {
            $("#FormCreateInventoryEstimationMasterAndDetails").validate();
            if ($("#FormCreateInventoryEstimationMasterAndDetails").valid()) {
                if (InventoryEstimationMasterAndDetails.flag == true) {
                    if (InventoryEstimationMasterAndDetails.XMLstring != null && InventoryEstimationMasterAndDetails.XMLstring != "") {
                        InventoryEstimationMasterAndDetailsData = null;
                        InventoryEstimationMasterAndDetailsData = InventoryEstimationMasterAndDetails.GetInventoryEstimationMasterAndDetails();
                        ajaxRequest.makeRequest("/InventoryEstimationMasterAndDetails/Create", "POST", InventoryEstimationMasterAndDetailsData, InventoryEstimationMasterAndDetails.SuccessEstimate);
                    }
                    else {
                        $('#msgDiv').html("No data available in table");
                        $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                    }
                }
            }
        }
        else if (InventoryEstimationMasterAndDetails.ActionName == "CreateEstimateLocationWise") {
            $("#FormAllocateInventoryEstimationMasterAndDetails").validate();
            if ($("#FormAllocateInventoryEstimationMasterAndDetails").valid()) {
                InventoryEstimationMasterAndDetailsData = null;
                InventoryEstimationMasterAndDetailsData = InventoryEstimationMasterAndDetails.GetInventoryEstimationMasterAndDetails();
                ajaxRequest.makeRequest("/InventoryEstimationMasterAndDetails/AllocateEstimation", "POST", InventoryEstimationMasterAndDetailsData, InventoryEstimationMasterAndDetails.SuccessEstimate);
            }
        }
        },
        //Get properties data from the Create, Update and Delete page
        GetInventoryEstimationMasterAndDetails: function () {
            
            var Data = {
            };
            Data.CustomerID =$('input[name=CustomerID]').val();
            Data.CustomerName = $('#CustomerName').val();
            Data.CustomerMobileNumber = $('#CustomerMobileNumber').val();
            Data.CustomerAddress = $('#CustomerAddress').val();
            Data.EstimationAmount = $('#TotalBillAmount').val();
            Data.BalanceSheetID = $("#selectedBalsheetID").val();
            Data.TotalTaxAmount = InventoryEstimationMasterAndDetails.totalTaxString
            Data.TotalDiscountAmount = InventoryEstimationMasterAndDetails.totalDiscountString
            Data.XMLstring = InventoryEstimationMasterAndDetails.XMLstring;
        

            if (InventoryEstimationMasterAndDetails.ActionName == "CreateEstimateLocationWise") {
                Data.ID = $('input[name=ID]').val();
                Data.EstimateLocationWiseXMLstring = InventoryEstimationMasterAndDetails.EstimateLocationWiseXMLstring
                Data.LocationID = $("#LocationID").val();
            }

            return Data;
        },
        //this is used to for showing successfully record creation message and reload the list view
        Success: function (data) {

            //print function
            if (data != null) {
                var frame1 = $('<iframe />');
                frame1[0].name = "frame1";
                frame1.css({ "position": "absolute", "top": "-1000000px" });
                $("body").append(frame1);
                var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
                frameDoc.document.open();
                //Create a new HTML document.
                frameDoc.document.write('<html><head><meta charset="utf-8"><title>Bill</title>');
                //Append the external CSS .
                frameDoc.document.write('<style media="all" type="text/css">body { max-width: 300px;text-transform: uppercase; margin:0 auto; text-align:center; color:#000; font-family: Arial, Helvetica, sans-serif; font-size:12px; }#wrapper { min-width: 250px; margin: 0 auto; }#wrapper img { max-width: 300px; width: auto; }h2, h3, p { margin: 5px 0; }.left { width:60%; float:left; text-align:left; margin-bottom: 3px; }.right { width:40%; float:right; text-align:right; margin-bottom: 3px; }.table, .totals { width: 100%; margin:10px 0; }.table th { border-bottom: 1px solid #000; }.table td { padding:0; }.totals td { width: 24%; padding:0; }.table td:nth-child(2) { overflow:hidden; }@media print {body { text-transform: uppercase; }#buttons { display: none; }#wrapper { width: 100%; margin: 0; font-size:9px; }#wrapper img { max-width:300px; width: 80%; }#header,#footer {display:none}}</style>');
                frameDoc.document.write('</head><body>');
                //Append the DIV contents.
                //frameDoc.document.write(contents);
                frameDoc.document.write('<div id="wrapper"><img src="../Content/images/surbhifruitsfinallogo.jpg" style="width:50%;"><p>' + data[0].PrintingLine1 + '<br>' + data[0].PrintingLine2 + '</p>    	<span class="left">' + data[0].PrintingLine4 + '</span> <span class="left">Customer:' + data[0].CustomerName + ' </span> <span class="right">Date: ' + data[0].TransactionDate.split(' ')[0] + '</br>' + data[0].TransactionDate.split(' ')[1] + '</span>    <div style="clear:both;"></div><table cellspacing="0"  border="0" class="table"> <thead> <tr style="font-size:11px">  <th>Items</th> <th>Qty</th><th>Rate</th><th>Amount</th> </tr> </thead> <tbody style="font-size:11px">');
                var strCollection1 = '';
                for (var i = 0; i < data.length; i++) {
                    strCollection1 = strCollection1 + '<tr>' +
                                                    '<td style="text-align:left; width:180px;">' + data[i].ItemName + '</td>' +
                                                    '<td style="text-align:center; width:70px;">' + parseFloat(data[i].Quantity).toFixed(3) + '' + data[i].UnitCode + '</td>' +
                                                    '<td style="text-align:center; width:70px;">' + parseFloat(data[i].Rate).toFixed(2) + '</td>' +
                                                    '<td style="text-align:right; width:70px; ">' + parseFloat(parseFloat(data[i].Rate).toFixed(3) * parseFloat(data[i].Quantity)).toFixed(2) + '</td>' +
                                                    '</tr>'
                }
                frameDoc.document.write(strCollection1);
                frameDoc.document.write('</tbody></table> <table cellspacing="0" border="0" style="margin-bottom:5px;" class="totals"><tbody style="font-size:10px"><tr><td style="text-align:left;"></td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + " " + '</td><td style="text-align:left; padding-left:1.5%;">Total</td><td style="text-align:right;">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].EstimationAmount).toFixed(2) + '</td></tr><tr><td style="text-align:left; padding-left:1.5%;">Tax </td><td style="text-align:right;">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].TotalTaxAmount).toFixed(2) + '</td></tr><tr><td style="text-align:left;">Total Items</td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + data.length + '</td><td style="text-align:left; padding-left:1.5%;">Discount </td><td style="text-align:right;">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].TotalDiscountAmount).toFixed(2) + '</td></tr><tr><td style="text-align:left; font-weight:bold; border-top:1px solid #000; padding-top:5px;" colspan="2">Grand Total</td><td style="border-top:1px solid #000; padding-top:5px; text-align:right; font-weight:bold;" colspan="2">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].GrossAmount).toFixed(2) + '</td></tr></tbody></table><div style="border-top:1px solid #000; padding-top:10px;"><p>Thank You Visit Again !</p>    </div></div>');
                frameDoc.document.write('</body></html>');
                frameDoc.document.close();
                setTimeout(function () {
                    window.frames["frame1"].focus();
                    window.frames["frame1"].print();
                    frame1.remove();
                }, 500);
                InventorySalesMasterAndTransaction.ReloadList("Record created successfully", "#9FEA7A", "0");
            }


        },

        //this is used to for showing successfully record creation message and reload the list view
        SuccessEstimate: function (data) {
            
            var splitData = data.split(',');
            parent.$.colorbox.close();
            InventoryEstimationMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        },



        };


