/// <reference path="../../bootstrap.min.js" />
//this class contain methods related to nationality functionality
var InventoryDumpAndShrinkMasterAndDetails = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        InventoryDumpAndShrinkMasterAndDetails.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $('#LocationID').on("change", function () {
            $('#myDataTable').html("");
            $("#divAddbtn").hide();
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });
        $('#btnShowList').click(function () {            
            var locationId = $('#LocationID :selected').val();
            if (locationId != "") {
                InventoryDumpAndShrinkMasterAndDetails.LoadListWithLocation();
            }
            else if (locationId == "") {
                $('#SuccessMessage').html("Please select Location");
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
        $("#ItemName").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/InventoryDumpAndShrinkMasterAndDetails/GetItemSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { "term": request.term, "locationID": $("#LocationID").val() },
                    success: function (data) {
                        response($.map(data, function (item) {

                            return { label: item.name, value: item.name, id: item.id, rate: item.rate, itemCode: item.itemCode, picture: item.picture, currencyCode: item.currencyCode, currentStockQty: item.currentStockQty, unitID: item.unitID, unitCode: item.unitCode };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);                                             // display the selected text
                $("#Rate").val(parseFloat(ui.item.rate).toFixed(2));
                $("#ItemID").val(parseInt(ui.item.id));
                $("#UnitCode").val(ui.item.unitCode);
                $("#CurrentQuantity").val(ui.item.currentStockQty);

                $('#ActualWeight').focus();
                //$("#UnitID").val(ui.item.unitID);
                //$("#AvailableStock").val(ui.item.currentStockQty);
            }
        });

        // Create new record
        $('#addItem').on("click", function () {
           

            var actualQty = parseFloat($("#CurrentQuantity").val());
            var allowedShrinkQty = actualQty * (3 / 100);
            var CurrentQuality = $("#CurrentQuantity").val();
            var shrinkQuality = $("#ShrinkQuantity").val();
            var currentQty = $("#DumpQuantity").val();
            var ActualWeight = $("#ActualWeight").val();
            var total = parseFloat(parseFloat(shrinkQuality) + parseFloat(currentQty) + parseFloat(ActualWeight)).toFixed(2);

            //code to restrict repeated entries in datatable
            
            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            var i = 0;
            for (var i = 0; i < TotalRecord; i = i + 5) {
                if (DataArray[i] == $('#ItemID').val()) {
                    $('#msgDiv').html("You Cannot Enter the same item Twice");
                    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    $("#ItemName").val("");
                    $("#Rate").val(0);
                    $("#UnitCode").val("");
                    $("#DumpQuantity").val(0);
                    $("#ShrinkQuantity").val(0);
                    $("#CurrentQuantity").val(0);
                    $("#ActualWeight").val(0);
                    $("#ItemID").val("");
                    $("#Remark").val("");
                    $('#ItemName').focus();


                    return false
                }
            }

            //EndCode code to restrict repeated entries in datatable


            if ($("#ItemID").val() == 0) {
                $('#msgDiv').html("Invalid item selected");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
            else if ($("#ItemName").val() == "") {
                $('#msgDiv').html("Please Enter Item Name.");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
           //else if ((parseFloat(shrinkQuality) <= 0))
           // {
           //     $('#msgDiv').html("enter shrink quantity");
           //     $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
           //     return false;
           // }
           // else if ((parseFloat(currentQty) <= 0)) {
           //     $('#msgDiv').html("enter Dump quantity");
           //     $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
           //     return false;
           // }
            //else if ((parseFloat(ActualWeight) <= 0)) {
            //    $('#msgDiv').html("enter Actual quantity");
            //    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //    return false;
            //}
            else if ($("#Remark").val() == "") {
                $('#msgDiv').html("Please Enter Remark.");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
            
          else  if ((parseFloat(CurrentQuality) < parseFloat(total))) {
              $('#msgDiv').html("Total Quantity cannot exceed than Current Quantity");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if ((parseFloat(CurrentQuality) > parseFloat(total))) {

                $('#msgDiv').html("Current Quality is more then Total Quantity");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if (parseFloat($("#ShrinkQuantity").val()) > allowedShrinkQty) {
                $('#msgDiv').html("Shrink Quantity is too high.");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }

          

           

            //if (parseFloat($('#AvailableStock').val()) > parseFloat($('#Quantity').val())) 
            if ($('#ItemName').val() != "" && $("#ItemID").val() > 0 && $("#Remark").val() != "" && ($("#DumpQuantity").val() > 0 || $("#ShrinkQuantity").val() > 0) && parseFloat($("#CurrentQuantity").val()) >= parseFloat($("#ActualWeight").val()) && parseFloat($("#CurrentQuantity").val()) >= parseFloat($("#DumpQuantity").val())) { //&&  parseFloat( $("#ShrinkQuantity").val()) <= allowedShrinkQty ) {
              
                $("#tblData tbody").append(
                    "<tr>" +
                    "<td ><input type='text' value=" + $('#ItemID').val() + " style='display:none' /> " + $('#ItemName').val() + "</td>" +
                    "<td><input type='text' value=" + $('#Rate').val() + " style='display:none' /> " + $('#Rate').val() + "</td>" +
                    "<td>" + $('#UnitCode').val() + "</td>" +
                    "<td><input id='itemDumpQty'  type='text' value=" + parseFloat($('#DumpQuantity').val() > 0 ? $('#DumpQuantity').val() : 0).toFixed(2) + "  style='width:60%;height:16px;text-align:right' disabled='disabled'/></td>" +
                    "<td><input id='itemShrinkQty' type='text' value=" + parseFloat($('#ShrinkQuantity').val() > 0 ? $('#ShrinkQuantity').val() : 0).toFixed(2) + " style='width:60%;height:16px;text-align:right' disabled='disabled'/></td>" +
                    "<td>" + parseFloat(parseFloat($('#Rate').val()).toFixed(2) * parseFloat(parseFloat($('#DumpQuantity').val() > 0 ? $('#DumpQuantity').val() : 0) + parseFloat($('#ShrinkQuantity').val() > 0 ? $('#ShrinkQuantity').val() : 0)).toFixed(2)).toFixed(2) + "</td>" +
                    "<td  style='text-align:center; '><input type='text' value=" + $('#Remark').val().replace(/ /g, "~") + " style='display:none' /><i class='icon-trash' title = Delete></td>" +
                    "</tr>");
                $("#ItemName").val("");
                $("#Rate").val(0);
                $("#UnitCode").val("");
                $("#DumpQuantity").val(0);
                $("#ShrinkQuantity").val(0);
                $("#CurrentQuantity").val(0);
                $("#ActualWeight").val(0);
                $("#ItemID").val("");
                $("#Remark").val("");
                $('#ItemName').focus();
              
                $('input[id*=ShrinkQuantity]').on("keydown", function (e) {
                    AMSValidation.AllowNumbersWithDecimalOnly(e);
                    AMSValidation.NotAllowSpaces(e);
                });
                $('input[id*=ShrinkQuantity]').on("keyup", function (e) {
                    parseFloat($(this).val()).toFixed(2);
                });
                $('input[id^=itemDumpQty]').on("keydown", function (e) {
                    AMSValidation.AllowNumbersWithDecimalOnly(e);
                });
                $('input[id^=itemDumpQty]').on("keyup", function (e) {
                    parseFloat($(this).val()).toFixed(2);
                });
                $('input[id^=itemShrinkQty]').on("keydown", function (e) {
                    AMSValidation.AllowNumbersWithDecimalOnly(e);
                });
                $('input[id^=itemShrinkQty]').on("keyup", function (e) {
                    parseFloat($(this).val()).toFixed(2);
                });
                InventoryDumpAndShrinkMasterAndDetails.TotalItem();
                InventoryDumpAndShrinkMasterAndDetails.TotalBillAmount();
            }
            //else if ($("#ItemID").val() == 0) {
            //    $('#msgDiv').html("Invalid item selected");
            //    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //}
            //else if ($("#ItemName").val() == "") {
            //    $('#msgDiv').html("Please Enter Item Name.");
            //    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //}
            //else if ($("#Quantity").val() == "" || $("#Quantity").val() == 0 || $("#Quantity").val() == '.') {
            //    $('#msgDiv').html("Please Enter Quantity.");
            //    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //}
            //else if (parseFloat($("#CurrentQuantity").val()) < parseFloat($("#DumpQuantity").val())) {
            //    $('#msgDiv').html("Dump quantity can not exceed than current quantity.");
            //    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //}
            //else if (parseFloat($("#CurrentQuantity").val()) < parseFloat($("#ActualWeight").val())) {
            //    $('#msgDiv').html("Actual quantity can not exceed than current quantity.");
            //    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //}

            //else if (parseFloat($("#ShrinkQuantity").val()) > allowedShrinkQty) {
            //    $('#msgDiv').html("Shrink quantity is too high.");
            //    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //}
            //else if ($("#Remark").val() == "") {
            //    $('#msgDiv').html("Please Enter Remark.");
            //    $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //}
            else if ($("#DumpQuantity").val() == typeof (null) || $("#DumpQuantity").val() == 0 || $("#DumpQuantity").val() == '.') {
                $('#msgDiv').html("Please Enter Waste Quantity.");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
            else if ($("#ShrinkQuantity").val() == typeof (null) || $("#ShrinkQuantity").val() == 0 || $("#ShrinkQuantity").val() == '.') {
                $('#msgDiv').html("Please Enter Shrink Quantity.");
                $('#msgDiv').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }


        });
        //On Dump Quantity Change
        $("#tblData tbody").on("keyup", "tr td input[id^=itemDumpQty]", function () {
            var dumpQuantity = parseFloat($(this).closest('tr').find('td input[id^=itemDumpQty]').val());
            var shrinkQuantity = parseFloat($(this).closest('tr').find('td input[id^=itemShrinkQty]').val());
            var rate = parseFloat($(this).closest('tr').find('td').eq(1).text());

            $(this).closest('tr').find('td').eq(5).text((dumpQuantity + shrinkQuantity) * rate);
            InventoryDumpAndShrinkMasterAndDetails.TotalBillAmount();
        });
        //On Shrink Quantity Change
        $("#tblData tbody").on("keyup", "tr td input[id^=itemShrinkQty]", function () {
            var shrinkQuantity = parseFloat($(this).closest('tr').find('td input[id^=itemShrinkQty]').val());
            var dumpQuantity = parseFloat($(this).closest('tr').find('td input[id^=itemDumpQty]').val());
            var rate = parseFloat($(this).closest('tr').find('td').eq(1).text());

            $(this).closest('tr').find('td').eq(5).text((shrinkQuantity + dumpQuantity) * rate);
            InventoryDumpAndShrinkMasterAndDetails.TotalBillAmount();
        });
        //Delete
        $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
            $(this).closest('tr').remove();
            InventoryDumpAndShrinkMasterAndDetails.TotalItem();
            InventoryDumpAndShrinkMasterAndDetails.TotalBillAmount();
        });

        $('#CreateInventoryDumpAndShrink').on("click", function () {            
            InventoryDumpAndShrinkMasterAndDetails.ActionName = "Create";
            InventoryDumpAndShrinkMasterAndDetails.GetXmlData();
            if (InventoryDumpAndShrinkMasterAndDetails.XMLstring != null && InventoryDumpAndShrinkMasterAndDetails.XMLstring != "") {
                $('#CreateInventoryDumpAndShrink').attr("disabled", true);
                InventoryDumpAndShrinkMasterAndDetails.AjaxCallInventoryDumpAndShrinkMasterAndDetails();
            }
            else {
                $('#SuccessMessage').html("No data available in table");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

            }
        });


        $('#CreateApproveDumpAndShrinkMasterAndDetails').on("click", function () {           
            //alert("asdfasdfasdf");
            InventoryDumpAndShrinkMasterAndDetails.ActionName = "ApproveDumpAndShrink";
            InventoryDumpAndShrinkMasterAndDetails.GetApprovedDumpAndShrinkXmlData();
            if (InventoryDumpAndShrinkMasterAndDetails.XMLstring != null && InventoryDumpAndShrinkMasterAndDetails.XMLstring != "") {
                $('#CreateApproveDumpAndShrinkMasterAndDetails').attr("disabled", true);
                InventoryDumpAndShrinkMasterAndDetails.AjaxCallInventoryDumpAndShrinkMasterAndDetails();
            }
            else {
                $('#SuccessMessage').html("No data available in table");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

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



        $('#DumpQuantity').on("keypress", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });
        $('#ActualWeight').on("keypress", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#ShrinkQuantity').on("keypress", function (event) {
            //AMSValidation.AllowNumbersWithDecimalOnly(e);
            //AMSValidation.NotAllowSpaces(e);
            //var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            //if (inputKeyCode == 45 || inputKeyCode == 95) {
            //    return false;
            //}          
            var $this = $(this);
            if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
            ((event.which < 48 || event.which > 57) &&
            (event.which != 0 && event.which != 8))) {
                event.preventDefault();
            }

            var text = $(this).val();
            if ((event.which == 46) && (text.indexOf('.') == -1)) {
                setTimeout(function () {
                    if ($this.val().substring($this.val().indexOf('.')).length > 3) {
                        $this.val($this.val().substring(0, $this.val().indexOf('.') + 3));
                    }
                }, 1);
            }
        });
        
        $("#ShrinkQuantity").on("keyup", function () {
            var CurrentQuality =  $("#CurrentQuantity").val();
            var shrinkQuality = $("#ShrinkQuantity").val();
            var DumpQty = $("#DumpQuantity").val();
            if (parseFloat(shrinkQuality) > parseFloat(CurrentQuality))
            {
                $("#ShrinkQuantity").val(0);
                $("#ActualWeight").val(0);
            }
            if ((parseFloat($("#ShrinkQuantity").val()) + parseFloat($("#DumpQuantity").val())) > parseFloat(CurrentQuality))
            {
                $("#ShrinkQuantity").val(0);
                $('#msgDiv').html("Total Quantity Exceeds Current Quantity");
                $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

            }
            var abc = parseFloat(parseFloat($("#ShrinkQuantity").val()) + parseFloat($("#DumpQuantity").val())).toFixed(2);
            var abc1 =  parseFloat(parseFloat(CurrentQuality) - parseFloat(abc)).toFixed(2);
            $("#ActualWeight").val(abc1);
        });

        $("#DumpQuantity").on("keyup", function () {
            var CurrentQuality = $("#CurrentQuantity").val();
            var shrinkQuality = $("#ShrinkQuantity").val();
            var DumpQty = $("#DumpQuantity").val();
            if (parseFloat(DumpQty) > parseFloat(CurrentQuality)) {
                $("#DumpQuantity").val(0);
            }
            if ((parseFloat($("#ShrinkQuantity").val()) + parseFloat($("#DumpQuantity").val())) > parseFloat(CurrentQuality)) {
                $("#DumpQuantity").val(0);
                $('#msgDiv').html("Total Quantity Exceeds Current Quantity");
                $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

            }
            var abc = parseFloat(parseFloat(shrinkQuality) + parseFloat($("#DumpQuantity").val())).toFixed(2);
            var abc1 = parseFloat(parseFloat(CurrentQuality) - parseFloat(abc)).toFixed(2);
            $("#ActualWeight").val(abc1);
        });
        $("#ItemName").on("keyup", function (e) {
            if(e.keyCode == 8 || e.keyCode == 46)
            {
                $("#ItemName").val("");
                $("#Rate").val(0);
                $("#UnitCode").val("");
                $("#DumpQuantity").val(0);
                $("#ShrinkQuantity").val(0);
                $("#CurrentQuantity").val(0);
                $("#ActualWeight").val(0);
                $("#ItemID").val("");
                $("#Remark").val("");
                $('#ItemName').focus();
            }
        });

        //$('#ActualWeight').on("keyup", function (e) {
        //    $("#ShrinkQuantity").val((parseFloat($("#CurrentQuantity").val()) - parseFloat($(this).val())).toFixed(2));
        //    $("#DumpQuantity").val(0);
        //});

        //$('#DumpQuantity').on("keyup", function (e) {
        //    var actualQty = $("#ActualWeight").val();
        //    var currentQty = $("#CurrentQuantity").val();
        //    var differenceQty = parseFloat(currentQty) - parseFloat(actualQty);

        //    if (parseFloat(differenceQty) >= $(this).val()) {
        //        $("#ShrinkQuantity").val((parseFloat(differenceQty) - parseFloat($(this).val())).toFixed(2));
        //    }
        //    else {
        //        $(this).val(0);
        //        $("#ShrinkQuantity").val(parseFloat(differenceQty).toFixed(2));
        //    }

        //});



    },
    TotalBillAmount: function () {        
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(5).text()).toFixed(2);
                a += parseFloat(x);
            }
        });
        $("#TotalBillAmount").val(a.toFixed(2));

    },
    TotalItem: function () {
        var length = $("#tblData tbody tr").length;
        $("#TotalItem").val(length);
    },
    //LoadList method is used to load List page
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        var locationId = $("#LocationID").val();
        if (Balancesheet != null) {
            $.ajax(
           {
               cache: false,
               type: "GET",
               data: { "selectedBalsheet": Balancesheet, "locationId": locationId },
               dataType: "html",
               url: '/InventoryDumpAndShrinkMasterAndDetails/List',
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
    //LoadList method is used to load List page
    LoadListWithLocation: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        var locationId = $("#LocationID").val();
        $.ajax(
       {
           cache: false,
           type: "GET",
           data: { "selectedBalsheet": Balancesheet, "locationId": locationId },
           dataType: "html",
           url: '/InventoryDumpAndShrinkMasterAndDetails/List',
           success: function (data) {
               //Rebind Grid Data
               $('#ListViewModel').html(data);
               $("#divAddbtn").show();
           }
       });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        
        var Balancesheet = $("#selectedBalsheetID").val();
        var locationId = $("#LocationID").val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { "selectedBalsheet": Balancesheet, "locationId": locationId, "actionMode": actionMode },
            dataType: "html",
            url: '/InventoryDumpAndShrinkMasterAndDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                $("#divAddbtn").show();
                ////twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },
    ReloadPendingRequestList: function (message, colorCode, actionMode) {
        
        var TaskCode = "DAST";
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "TaskCode": TaskCode },
            url: '/Home/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html('Request approved successfully');
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', '#9FEA7A');
            }
        });
    },
    //Method to create xml
    GetXmlData: function () {        
        var DataArray = [];
        $('#DivAddRowTable input[type=text]').each(function () {
            DataArray.push($(this).val());
        });

        var TotalRecord = DataArray.length;
       // de(DataArray + "----" + TotalRecord);
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 5) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i] + "</ItemID><Rate>" + parseFloat(DataArray[i + 1]).toFixed(2) + "</Rate><DumpQuantity>" + parseFloat(DataArray[i + 2]).toFixed(2) + "</DumpQuantity><ShrinkQuantity>" + parseFloat(DataArray[i + 3]).toFixed(2) + "</ShrinkQuantity><Remark>" + DataArray[i + 4].replace(/~/g,' ') + "</Remark></row>";
        }
        if (ParameterXml.length > 6)
            InventoryDumpAndShrinkMasterAndDetails.XMLstring = ParameterXml + "</rows>";
        else
            InventoryDumpAndShrinkMasterAndDetails.XMLstring = "";      
    },

    //Method to create xml
    GetApprovedDumpAndShrinkXmlData: function () {        
        var DataArray = [];
        $('#DivAddRowTable input[type=text]').each(function () {
            DataArray.push($(this).val());
        });

        var TotalRecord = DataArray.length;
        //alert(DataArray + "----" + TotalRecord);
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 5) {
            if (DataArray[i + 3] > 0 && DataArray[i + 4] > 0) {
                ParameterXml = ParameterXml + "<row><ID>" + DataArray[i].split('~')[1] + "</ID><DumpAndShrinkMasterID>" + DataArray[i].split('~')[0] + "</DumpAndShrinkMasterID><ItemID>" + DataArray[i].split('~')[2] + "</ItemID><ApprovedDumpQty>" + parseFloat(DataArray[i + 3]).toFixed(2) + "</ApprovedDumpQty><ApprovedShrinkQty>" + parseFloat(DataArray[i + 4]).toFixed(2) + "</ApprovedShrinkQty></row>";
            }
            else if (DataArray[i + 3] > 0 || DataArray[i + 4] > 0) {
                if (DataArray[i + 3] > 0) {
                    ParameterXml = ParameterXml + "<row><ID>" + DataArray[i].split('~')[1] + "</ID><DumpAndShrinkMasterID>" + DataArray[i].split('~')[0] + "</DumpAndShrinkMasterID><ItemID>" + DataArray[i].split('~')[2] + "</ItemID><ApprovedDumpQty>" + parseFloat(DataArray[i + 3]).toFixed(2) + "</ApprovedDumpQty><ApprovedShrinkQty>" + parseFloat(DataArray[i + 2]).toFixed(2) + "</ApprovedShrinkQty></row>";
                }
                else if (DataArray[i + 4] > 0) {
                    ParameterXml = ParameterXml + "<row><ID>" + DataArray[i].split('~')[1] + "</ID><DumpAndShrinkMasterID>" + DataArray[i].split('~')[0] + "</DumpAndShrinkMasterID><ItemID>" + DataArray[i].split('~')[2] + "</ItemID><ApprovedDumpQty>" + parseFloat(DataArray[i + 1]).toFixed(2) + "</ApprovedDumpQty><ApprovedShrinkQty>" + parseFloat(DataArray[i + 4]).toFixed(2) + "</ApprovedShrinkQty></row>";
                }
            }
            else {
                ParameterXml = ParameterXml + "<row><ID>" + DataArray[i].split('~')[1] + "</ID><DumpAndShrinkMasterID>" + DataArray[i].split('~')[0] + "</DumpAndShrinkMasterID><ItemID>" + DataArray[i].split('~')[2] + "</ItemID><ApprovedDumpQty>" + parseFloat(DataArray[i + 1]).toFixed(2) + "</ApprovedDumpQty><ApprovedShrinkQty>" + parseFloat(DataArray[i + 2]).toFixed(2) + "</ApprovedShrinkQty></row>";
            }
        }
        if (ParameterXml.length > 6)
            InventoryDumpAndShrinkMasterAndDetails.XMLstring = ParameterXml + "</rows>";
        else
            InventoryDumpAndShrinkMasterAndDetails.XMLstring = "";

        // alert(InventoryDumpAndShrinkMasterAndDetails.XMLstring);
    },
    //Fire ajax call to insert update and delete record
    AjaxCallInventoryDumpAndShrinkMasterAndDetails: function () {
        var InventoryDumpAndShrinkMasterAndDetailsData = null;
        if (InventoryDumpAndShrinkMasterAndDetails.ActionName == "Create") {
            $("#FormCreateInventorySalesAndTransaction").validate();
            if ($("#FormCreateInventorySalesAndTransaction").valid()) {
                InventoryDumpAndShrinkMasterAndDetailsData = null;
                InventoryDumpAndShrinkMasterAndDetailsData = InventoryDumpAndShrinkMasterAndDetails.GetInventoryDumpAndShrinkMasterAndDetails();
                ajaxRequest.makeRequest("/InventoryDumpAndShrinkMasterAndDetails/Create", "POST", InventoryDumpAndShrinkMasterAndDetailsData, InventoryDumpAndShrinkMasterAndDetails.Success);
            }
        }
        if (InventoryDumpAndShrinkMasterAndDetails.ActionName == "ApproveDumpAndShrink") {
            $("#FormApproveInventoryDumpAndShrinkMasterAndDetails").validate();
            if ($("#FormApproveInventoryDumpAndShrinkMasterAndDetails").valid()) {
                InventoryDumpAndShrinkMasterAndDetailsData = null;
                InventoryDumpAndShrinkMasterAndDetailsData = InventoryDumpAndShrinkMasterAndDetails.GetInventoryDumpAndShrinkMasterAndDetails();
                ajaxRequest.makeRequest("/InventoryDumpAndShrinkMasterAndDetails/RequestApproval", "POST", InventoryDumpAndShrinkMasterAndDetailsData, InventoryDumpAndShrinkMasterAndDetails.SuccessRequestList);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryDumpAndShrinkMasterAndDetails: function () {        
        var Data = {
        };
        Data.ID = $('input[name=ID]').val();
        Data.BillAmount = $('#TotalBillAmount').val();
        Data.DumpAndShrinkAmount = $('#TotalBillAmount').val();
        Data.BalanceSheetID = $("#selectedBalsheetID").val();
        Data.LocationID = $("#LocationID").val();
        Data.XMLstring = InventoryDumpAndShrinkMasterAndDetails.XMLstring;
        if (InventoryDumpAndShrinkMasterAndDetails.ActionName == "ApproveDumpAndShrink") {
            Data.TaskCode = "DAST";
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
            Data.BalanceSheetID = $("input[name=BalanceSheetID]").val();
            Data.LocationID = $("input[name=LocationID]").val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        $('#CreateInventoryDumpAndShrink').attr("disabled", false);
        InventoryDumpAndShrinkMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
    },

    SuccessRequestList: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        $('#CreateApproveDumpAndShrinkMasterAndDetails').attr("disabled", false);
        InventoryDumpAndShrinkMasterAndDetails.ReloadPendingRequestList(splitData[0], splitData[1], splitData[2]);
    },



};