//this class contain methods related to nationality functionality
var InventoryIssueMasterAndDetails = {
    //Member variables
    ActionName: null,
    ParameterXml : null,
    //Class intialisation method
    Initialize: function () {

        InventoryIssueMasterAndDetails.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $('#IssueFromLocationID').focus();
        $('#Quantity').val("");
        $("#TotalItem").val(0);
        $("#reset").click(function () {
            $("#tblData tbody tr").remove();
            $('#Quantity').val("");
            $('#IssueFromLocationID').val("");
            $('#IssueToLocationID').val("");
            $("#TotalItem").val(0);
            $('#ItemName').val("");
            $('#UnitCode').val("");
            return false;
        });

        $("#AddItemsDetails").click(function () {
            $("#IssueCreate").show();
            $("#ListViewData").hide();
            return false;
        });
        
        $("#closeIssue").click(function () {
            $("#IssueCreate").hide();
            $("#ListViewData").show();
            $("#tblData tbody tr").remove();
            //$('#CurrentStockQuantity').val("");
            $('#Quantity').val("");
            $('#IssueFromLocationID').val("");
            $('#IssueToLocationID').val("");
            $("#TotalItem").val(0);
            $('#ItemName').val("");
            $('#UnitCode').val("");
            return false;
        });


        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
        $("#ItemName").autocomplete({

            source: function (request, response) {
                $.ajax({

                    url: "/InventoryIssueMasterAndDetails/GetItemSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term, locationID: $("#IssueFromLocationID").val() },
                    success: function (data) {
                        response($.map(data, function (item) {

                            return { label: item.name, value: item.name, id: item.id, rate: item.rate, itemCode: item.itemCode, picture: item.picture, currencyCode: item.currencyCode, currentStockQty: item.currentStockQty, unitID: item.unitID, unitCode: item.unitCode };
                        }))
                    }
                })
            },
            select: function (event, ui) {

                $(this).val(ui.item.label);                                             // display the selected text
                //$("#createSales").show();
                //$("#Rate").val(parseFloat(ui.item.rate));
                $("#ItemID").val(ui.item.id);
                //$("#CurrentStockQuantity").val(ui.item.currentStockQty);
                $("#UnitCode").val(ui.item.unitCode);
                $("#UnitID").val(ui.item.unitID);
            }
        });

        // Create new record
        $('#AddRow').on("click", function () {
            
            //if (parseInt($("#CurrentStockQuantity").val()) >= parseInt($("#Quantity").val()) && $('#ItemName').val() != "" && $('#Quantity').val() != "" && $('#Quantity').val() != 0 && $('#UnitCode').val() && $("#IssueFromLocationID").val() != 0 && $("#IssueFromLocationID").val() != "" && $("#IssueToLocationID").val() != 0 && $("#IssueToLocationID").val() != "") {
              if ($('#ItemName').val() != "" && $('#Quantity').val() != "" && $('#Quantity').val() != 0 && $('#UnitCode').val() && $("#IssueFromLocationID").val() != 0 && $("#IssueFromLocationID").val() != "" && $("#IssueToLocationID").val() != 0 && $("#IssueToLocationID").val() != "") {
                    $("#tblData tbody").append(
                        "<tr>" +
                        "<td style='display:none' > <input style='text-align: right;width: 100px;' type='text' value =" + $('#ItemID').val() + "> </td>" +
                        "<td >" + $('#ItemName').val() + "</td>" +
                        //"<td> <input id='currentStockQty'  disabled = disabled style='text-align: right;width: 100px;' type='text' value =" + $('#CurrentStockQuantity').val() + "> </td>" +
                        "<td> <input id='itemQuantity' style='text-align: right;width: 100px;' type='text' value =" + $('#Quantity').val() + "> </td>" +
                        "<td>" + $('#UnitCode').val() + "</td>" +
                        "<td style='text-align:center; '>  <i class=icon-trash title = Delete> </i></td>" +
                        "</tr>");
                    $("#ItemID").val(0);
                    $('#ItemName').focus();
                    $('#ItemName').val("");
                    //$('#CurrentStockQuantity').val("");
                    $('#Quantity').val("");
                    $("#UnitID").val(0);
                    $('#UnitCode').val("");
                    $('input[id*=itemQuantity]').on("keydown", function (e) {
                        AMSValidation.AllowNumbersWithDecimalOnly(e);
                        AMSValidation.NotAllowSpaces(e);
                    });
                  
                    var totalItem = parseInt($("#TotalItem").val()) + 1;
                    $("#TotalItem").val(totalItem);
                }
                    //else if (parseInt($("#CurrentStockQuantity").val()) < parseInt($("#Quantity").val())) {
                    //    $('#SuccessMessage').html("Please Check Stock Quantity.");
                    //    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    //}
                else if ($("#IssueFromLocationID").val() == 0 || $("#IssueToLocationID").val() == 0 || $("#IssueFromLocationID").val() == "" || $("#IssueToLocationID").val() == 0) {
                    $('#SuccessMessage').html("Please Select Location Name.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
                else if ($("#ItemName").val() =="" ) {
                    $('#SuccessMessage').html("Please Enter Item Name.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
                else if ($("#UnitCode").val() == "") {
                    $('#SuccessMessage').html("Please Enter valid Item Name.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
                else if ($("#Quantity").val() == "" || $("#Quantity").val() == 0) {
                    $('#SuccessMessage').html("Please Enter Quantity.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }

            });

            //Delete
            $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
                $(this).closest('tr').remove();
                var totalItem = parseInt($("#TotalItem").val()) - 1;
                $("#TotalItem").val(totalItem);
            });
            $('#CreateInventoryIssueMasterAndDetailsRecord').on("click", function () {
                InventoryIssueMasterAndDetails.ActionName = "Create";
                InventoryIssueMasterAndDetails.getDataFromDataTable();
                InventoryIssueMasterAndDetails.AjaxCallInventoryIssueMasterAndDetails();
            });

            $('#EditInventoryIssueMasterAndDetailsRecord').on("click", function () {

                InventoryIssueMasterAndDetails.ActionName = "Edit";
                InventoryIssueMasterAndDetails.AjaxCallInventoryIssueMasterAndDetails();
            });

            $('#DeleteInventoryIssueMasterAndDetailsRecord').on("click", function () {

                InventoryIssueMasterAndDetails.ActionName = "Delete";
                InventoryIssueMasterAndDetails.AjaxCallInventoryIssueMasterAndDetails();
            });
            $("#Quantity").on("keydown", function (e) {
                AMSValidation.AllowNumbersWithDecimalOnly(e);
                AMSValidation.NotAllowSpaces(e);
            });
         
            $("#UserSearch").keyup(function () {
                var oTable = $("#myDataTable").dataTable();
                oTable.fnFilter(this.value);
            });

            $("#searchBtn").click(function () {
                $("#UserSearch").focus();
            });


            $("#showrecord").change(function () {
                var showRecord = $("#showrecord").val();
                $("select[name*='myDataTable_length']").val(showRecord);
                $("select[name*='myDataTable_length']").change();
            });

            $(".ajax").colorbox();


        },
    //LoadList method is used to load List page
            LoadList: function () {

                $.ajax(

                 {

                     cache: false,
                     type: "POST",

                     dataType: "html",
                     url: '/InventoryIssueMasterAndDetails/List',
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
                data: { "actionMode": actionMode },
                url: '/InventoryIssueMasterAndDetails/List',
                success: function (data) {
                    //Rebind Grid Data
               
                    $("#ListViewModel").empty().append(data);
                    //twitter type notification
                    $('#SuccessMessage').html(message);
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);

                }
           
            });
        },


        //Fire ajax call to insert update and delete record
        AjaxCallInventoryIssueMasterAndDetails: function () {
            var InventoryIssueMasterAndDetailsData = null;
            if (InventoryIssueMasterAndDetails.ActionName == "Create") {
           
                if (InventoryIssueMasterAndDetails.ParameterXml != ""&& $("#IssueToLocationID").val() != 0 && $("#IssueToLocationID").val() != "" && $("#IssueFromLocationID").val() != 0 && $("#IssueFromLocationID").val() != "") {
                    InventoryIssueMasterAndDetailsData = null;
                    InventoryIssueMasterAndDetailsData = InventoryIssueMasterAndDetails.GetInventoryIssueMasterAndDetails();
                    ajaxRequest.makeRequest("/InventoryIssueMasterAndDetails/Create", "POST", InventoryIssueMasterAndDetailsData, InventoryIssueMasterAndDetails.Success);
                }
                else if ($("#IssueFromLocationID").val() == 0 || $("#IssueToLocationID").val() == 0 || $("#IssueFromLocationID").val() == "" || $("#IssueToLocationID").val() == 0) {
                    $('#SuccessMessage').html("Please Select Location Name.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                  
                }
                else if (InventoryIssueMasterAndDetails.ParameterXml == "") {
                    $('#SuccessMessage').html("Please Enter Item Detalis.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
          
            }
            else if (InventoryIssueMasterAndDetails.ActionName == "Edit") {
                $("#FormEditInventoryIssueMasterAndDetails").validate();
                if ($("#FormEditInventoryIssueMasterAndDetails").valid()) {
                    InventoryIssueMasterAndDetailsData = null;
                    InventoryIssueMasterAndDetailsData = InventoryIssueMasterAndDetails.GetInventoryIssueMasterAndDetails();
                    ajaxRequest.makeRequest("/InventoryIssueMasterAndDetails/Edit", "POST", InventoryIssueMasterAndDetailsData, InventoryIssueMasterAndDetails.Success);
                }
            }
            else if (InventoryIssueMasterAndDetails.ActionName == "Delete") {
                InventoryIssueMasterAndDetailsData = null;
                InventoryIssueMasterAndDetailsData = InventoryIssueMasterAndDetails.GetInventoryIssueMasterAndDetails();
                ajaxRequest.makeRequest("/InventoryIssueMasterAndDetails/Delete", "POST", InventoryIssueMasterAndDetailsData, InventoryIssueMasterAndDetails.Success);

            }
        },

        getDataFromDataTable: function () {

            var DataArray = [];
            $('#DivAddRowTable input[type=text]').each(function () {

                DataArray.push($(this).val());
            });
     
            TotalRecord = DataArray.length;
            ParameterXml = "<rows>";
            for (var i = 0; i < TotalRecord; i = i + 2) {
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i] + "</ItemID><Quantity>" + DataArray[i+1] + "</Quantity></row>";
            }
            if (ParameterXml.length > 13) {
                InventoryIssueMasterAndDetails.ParameterXml = ParameterXml + "</rows>";
            }
            else {
                InventoryIssueMasterAndDetails.ParameterXml = "";
            }
      
        },
        //Get properties data from the Create, Update and Delete page
        GetInventoryIssueMasterAndDetails: function () {
            var Data = {
            };
            if (InventoryIssueMasterAndDetails.ActionName == "Create" || InventoryIssueMasterAndDetails.ActionName == "Edit") {
                // Data.ID = $('#ID').val();
                Data.IssueFromLocationID = $('#IssueFromLocationID').val();
                Data.IssueToLocationID = $('#IssueToLocationID').val();
                Data.ParameterXml = InventoryIssueMasterAndDetails.ParameterXml;
            }
            else if (InventoryIssueMasterAndDetails.ActionName == "Delete") {
                Data.ID = $('#ID').val();
            }
            return Data;
        },

        //this is used to for showing successfully record creation message and reload the list view
        Success: function (data) {
            ;
            var splitData = data.split(',');
            if (data != null) {
                //parent.$.colorbox.close();
                InventoryIssueMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
          
            } else {
                //parent.$.colorbox.close();
                InventoryIssueMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
         
            }
            $("#IssueCreate").hide();
            $("#ListViewData").show();
      
        },

        };

