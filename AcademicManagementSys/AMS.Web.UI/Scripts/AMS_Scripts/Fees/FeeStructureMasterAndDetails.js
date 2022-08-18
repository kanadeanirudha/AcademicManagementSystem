//this class contain methods related to nationality functionality
var FeeStructureMasterAndDetails = {
    //Member variables
    ActionName: null,
    XMLFeeStructureDetailsIDs: null,
    XMLFeeStructureInstallmentMasterIDs: null,
    XMLFeeStructureDetailsInstallmentWiseIDs: null,
    map: {},
    map2: {},

    //Class intialisation method
    Initialize: function () {

        FeeStructureMasterAndDetails.constructor();
    },
    //Attach all event of page
    constructor: function () {
        if ($("#PaymentMode").val() == "1") {
            $('#DivNumberOfInstallment').show(true);
            $('#DivLateFeeApplicable').show(true);
            if ($('#IsLateFeeApplicable').val == true) {
                $('#DivLateFeeApplicable').show(true);
            }
        }

            $("#SelectedFeeCriteriaMasterID").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            ///$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });

        InitAnimatedBorder();
        CloseAlert();

        $('#btnShowList').click(function () {
            var valueSelectedFeeCriteriaMasterID = $('#SelectedFeeCriteriaMasterID :selected').val();
            if (valueSelectedFeeCriteriaMasterID > 0) {
                FeeStructureMasterAndDetails.LoadListByFeeCriteriaMasterID(valueSelectedFeeCriteriaMasterID);
            }
            else if (valueSelectedFeeCriteriaMasterID <= 0) {
                notify("Please select fee criteria.", "danger");
                return false;
                $('#DivCreateNew').hide(true);
            }

        });

        $("#PaymentMode").change(function () {
            debugger;
            if ($("#PaymentMode :Selected").val() == "1") {
                $('#DivNumberOfInstallment').fadeIn('slow');
                $('#DivLateFeeApplicable').fadeIn('slow');
                $("#DivLumpsumFee").fadeOut('slow');
                //  $("#DivInstallMentFee").fadeIn('slow');
                $("#addFeeSubType").hide(true);
                $("#addFeeSubTypeInstallMent").show(true);
                $("#tblDataInstallMent thead tr").remove();
                $("#tblDataInstallMent tbody tr").remove();
                $("#tblDataLumpsum tbody tr").remove();
            }
            else {
                $('#DivNumberOfInstallment').fadeOut('slow');
                $('#DivLateFeeApplicable').fadeOut('slow');
                $('#LateFeeID').val('');
                $('#NumberOfInstallment').val('');
                $("#DivLumpsumFee").fadeIn('slow');
                $("#DivInstallMentFee").fadeOut('slow');
                $("#addFeeSubType").show(true);
                $("#addFeeSubTypeInstallMent").hide(true);
                $("#tblDataInstallMent thead tr").remove();
                $("#tblDataInstallMent tbody tr").remove();
                $("#tblDataLumpsum tbody tr").remove();
            }
            $("#TotalFeeAmount").val("");
            $("#FeeAccountSubTypeDesc").val("");
            $("#FeeAccountTypeMasterID").val("");
            $("#FeeAccountSubTypeMasterID").val("");
            $("#AccountID").val("");
            $("#TotalAmount").val("");
            $("#FeeSubTypeName").val("");
            $("#FeeSubTypeAmount").val(0);
        });

        $('#IsLateFeeApplicable').change(function () {
            if (this.checked) {
                $('#DivLateFeeID').fadeIn('slow');
            }
            else {
                $('#DivLateFeeID').fadeOut('slow');
                $('#LateFeeID').val('');
            }
        });




        $('#addFeeSubType').on("click", function () {
        
            var DataArray = [];
            $('#DivLumpsumFee input[type=text]').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            ParameterXml = "<rows>";
       

            for (var i = 0; i < TotalRecord; i = i + 6) {
                if ((DataArray[i] == ($('#FeeSubTypeID').val()))) {
                    $("#displayErrorMessage P").text("" + $('#FeeSubTypeName').val() + " already entered.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    $("#FeeSubTypeName").val("");
                    $("#FeeSubTypeAmount").val("");

                    return false
                }
            }


                if ($('#FeeSubTypeName').val() != "" && $('#FeeSubTypeAmount').val() != "" && $('#FeeSubTypeAmount').val() > 0 && $("#FeeSubTypeID").val() > 0) {
                    var CrDrStatus = 0;
                    var AccountType = "FeeType";
                    var Source = 1;
                    $("#tblDataLumpsum tbody").append(
                        "<tr>" +
                        "<td style='font-weight: bold;'><input type='text' value=" + $('#FeeSubTypeID').val() + " style='display:none' /> " + $('#FeeSubTypeName').val() + "</td>" +
                        "<td><input id='rowfeeSubTypeAmount' type='text' value=" + parseFloat($('#FeeSubTypeAmount').val()).toFixed(2) + " class='form-control fg-line'/>" +
                        "<input id='accountID' type='text' value=" + $('#AccountID').val() + " style='display:none' /><input id='crDrStatus' type='text' value=" + (CrDrStatus).toString() + " style='display:none' />" +
                        "<input id='accountType' type='text' value=" + (AccountType).toString() + " style='display:none' />" +
                        "<input id='accountType' type='text' value=" + (Source).toString() + " style='display:none' /></td>" +
                        "<td  style='text-align:center; '> <i style='cursor-pointer' class='zmdi zmdi-delete' id='delete' title = Delete></td>" +
                        "</tr>");
                    //alert($('#AccountID').val());
                    $("#FeeSubTypeName").val("");
                    $("#FeeSubTypeAmount").val(0);
                    $("#FeeSubTypeID").val("");
                    $('#AccountID').val("");
                    $("#FeeSubTypeName").focus();
                    ////$('#FeeSubTypeName').focus();
                    $('input[id*=rowfeeSubTypeAmount]').on("keydown", function (e) {
                        AMSValidation.AllowNumbersWithDecimalOnly(e);
                        AMSValidation.NotAllowSpaces(e);
                    });
                    FeeStructureMasterAndDetails.TotalFeeAmount();
                }
                else if ($("#FeeSubTypeName").val() == "") {

                    /////$("#displayErrorMessage p").text('Please Enter Fee SubType').closest('div').fadeIn().closest('div').addClass('alert-warning');
                    $("#displayErrorMessage P").text("Please enter fee sub type.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    //notify("Please Enter Fee SubType.", "warning");
                }
                else if ($("#FeeSubTypeID").val() == 0) {

                    //$("#displayErrorMessage p").text('Invalid Fee SubType selected').closest('div').fadeIn().closest('div').addClass('alert-warning');
                    $("#displayErrorMessage P").text("Invalid fee sub type selected.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    //notify("Invalid Fee SubType selected.", "warning");
                }
                else if ($("#FeeSubTypeAmount").val() == "" || $("#FeeSubTypeAmount").val() == 0 || $("#FeeSubTypeAmount").val() == '.') {
                    $("#displayErrorMessage P").text("Please Enter Fee Amount.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    /////$("#displayErrorMessage p").text('Please Enter Fee Amount').closest('div').fadeIn().closest('div').addClass('alert-warning');
                    //notify("Please Enter Fee Amount.", "warning");
                }
            
        });

        $('#tblDataLumpsum tbody').on('change keyup', "tr td input[id^=rowfeeSubTypeAmount]", function (e) {
            FeeStructureMasterAndDetails.TotalFeeAmount();
        });

        $("#tblDataLumpsum tbody").on("click", "tr td i[id='delete']", function () {
            $(this).closest('tr').remove();
            FeeStructureMasterAndDetails.TotalFeeAmount();
        });

        $("#NumberOfInstallment").change(function () {
            $("#tblDataInstallMent thead tr").remove();
            $("#tblDataInstallMent tbody tr").remove();
            $("#TotalFeeAmount").val("");
            $("#TotalAmount").val("");
            
            var numberOfInstallment = $("#NumberOfInstallment").val();
            var width = parseInt(65 / numberOfInstallment);
            var tableth = "";
            for (var i = 1 ; i <= numberOfInstallment ; i++) {
                tableth = tableth + "<th style='text-align: center;width:" + width + "%;'>Ins No" + i + "</th>"
            }
            $("#tblDataInstallMent thead").append(
                    "<tr>" +
                        "<th style='text-align: left;width:18%'>Fee SubType</th>" +
                       tableth +
                        "<th style='text-align: center;width:12%'>Fee Amount</th>" +
                        "<th style='text-align: center; width: 5%;'>Action</th>" +
                    "</tr>"
                    );
            $("#DivInstallMentFee").fadeIn('slow');
        });

        $('#addFeeSubTypeInstallMent').on("click", function () {
            debugger;
            var DataArray = [];
            $('#tblDataInstallMent input[type=text]').each(function () {
                DataArray.push($(this).val());
            });
            TotalRecord = DataArray.length;
            ParameterXml = "<rows>";
            for (var i = 0; i < TotalRecord; i = i + 8) {
                if (DataArray[i] == ($('#FeeSubTypeID').val() + "~" + $('#FeeSubTypeName').val().replace(' ', "`"))) {
                    $("#displayErrorMessage P").text("" + $('#FeeSubTypeName').val() + " already entered.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    $("#FeeSubTypeName").val("");
                    $("#FeeSubTypeAmount").val("");

                    return false
                }
            }

            var CrDrStatus = 0;
            var AccountType = "FeeType";
            var Source = 1;

            if ($('#FeeSubTypeName').val() != "" && $('#FeeSubTypeAmount').val() != "" && $('#FeeSubTypeAmount').val() > 0 && $("#FeeSubTypeID").val() > 0 && $("#NumberOfInstallment").val() > 0) {

                var numberOfInstallment = $("#NumberOfInstallment").val();
                var width = parseInt(65 / numberOfInstallment);
                // var tabletd = "<td style='text-align: right;width:" + width + ";'><input id='rowInstallmentAmount1' style='width:100%;height:16px;text-align:right; font-weight: bold;' value=" + $('#FeeSubTypeAmount').val() + " type='text'/> " + "</td>";
                var tabletd = "";
                for (var i = 1 ; i <= numberOfInstallment ; i++) {
                    tabletd = tabletd + "<td style='text-align: right;width:" + width + "%;'><div class='fg-line'><input id='rowInstallmentAmount" + i + "' class='input-sm form-control',  type='text'/></div> " + "</td>"
                }

                $("#tblDataInstallMent tbody").append(
                    "<tr>" +
                    "<td style='font-weight: bold;'><input type='text' value=" + $('#FeeSubTypeID').val() + "~" + $('#FeeSubTypeName').val().replace(' ', "`") + " style='display:none' /> " + $('#FeeSubTypeName').val() + "</td>" +
                    tabletd +
                    "<td><div class='fg-line'><input id='rowfeeSubTypeAmount' type='text' value=" + $('#FeeSubTypeAmount').val() + " class='form-control input-sm'/></div>" +
                     "<input id='accountID' type='text' value=" + $('#AccountID').val() + " style='display:none' /><input id='crDrStatus' type='text' value=" + (CrDrStatus).toString() + " style='display:none' />" +
                    "<input id='accountType' type='text' value=" + (AccountType).toString() + " style='display:none' />" +
                    "<input id='accountType' type='text' value=" + (Source).toString() + " style='display:none' /></td>" +
                    "<td  style='text-align:center; cursor:pointer; '> <i style='cursor:pointer' class='zmdi zmdi-delete' id='delete' title = Delete></td>" +
                    "</tr>");
                $("#FeeSubTypeName").val("");
                $("#FeeSubTypeAmount").val(0);
                $("#FeeSubTypeID").val("");
                //$('#FeeSubTypeName').focus();
                $('input[id*=rowfeeSubTypeAmount]').on("keydown", function (e) {
                    AMSValidation.AllowNumbersWithDecimalOnly(e);
                    AMSValidation.NotAllowSpaces(e);
                });
                for (var i = 1 ; i <= numberOfInstallment ; i++) {
                    $('input[id*=rowInstallmentAmount' + i + ']').on("keydown", function (e) {
                        AMSValidation.AllowNumbersWithDecimalOnly(e);
                        AMSValidation.NotAllowSpaces(e);
                    });
                }
                FeeStructureMasterAndDetails.TotalFeeInstallmentAmount();
            }
            else if ($("#NumberOfInstallment").val() == "0") {
                $("#displayErrorMessage p").text('Please Select Number Of Installment.').closest('div').fadeIn().closest('div').addClass('alert-warning');
                notify("Please Enter Fee Amount.", "warning");


            }
            else if ($("#FeeSubTypeName").val() == "") {
                $("#displayErrorMessage p").text('Please enter fee sub type.').closest('div').fadeIn().closest('div').addClass('alert-warning');
                //notify("Please Enter Fee SubType.", "warning");
            }
            else if ($("#FeeSubTypeID").val() == 0) {
                $("#displayErrorMessage p").text('Invalid fee sub type selected.').closest('div').fadeIn().closest('div').addClass('alert-warning');
                //notify("Invalid Fee SubType selected.", "warning");
            }
            else if ($("#FeeSubTypeAmount").val() == "" || $("#FeeSubTypeAmount").val() == 0 || $("#FeeSubTypeAmount").val() == '.') {
                $("#displayErrorMessage p").text('Please Enter Fee Amount').closest('div').fadeIn().closest('div').addClass('alert-warning');
                //notify("Please Enter Fee Amount.", "warning");
            }

        });
        $("#tblDataInstallMent tbody").on("click", "tr td i[id='delete']", function () {
            $(this).closest('tr').remove();
            FeeStructureMasterAndDetails.TotalFeeInstallmentAmount();
        });
        $('#FeeSubTypeAmount').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#tblDataInstallMent tbody').on('change keyup', "tr td input[id^=rowfeeSubTypeAmount]", function (e) {
            FeeStructureMasterAndDetails.TotalFeeInstallmentAmount();
        });

        // Create new record
        $('#CreateFeeStructureMasterAndDetailsRecord').on("click", function () {
            debugger;
            FeeStructureMasterAndDetails.ActionName = "Create";
            var length = $("#tblDataLumpsum tbody tr").length;
            if (parseInt(length) > 0) {
                FeeStructureMasterAndDetails.AjaxCallFeeStructureMasterAndDetails();
            }
            else {
                $("#displayErrorMessage p").text("No data available in table.").closest('div').fadeIn().closest('div').addClass('alert-warning');
            }
            //FeeStructureMasterAndDetails.ActionName = "Create";
           
            var length = $("#tblDataInstallMent tbody tr").length;
            if (parseInt(length)  > 0) {
                var calFeesAmount = 0; var numberOfInst = $("#NumberOfInstallment :selected").val();var totalFeesAmount =0;
                
                $("#tblDataInstallMent tbody tr").each(function (i) {

                    for (var i = 1; i <= numberOfInst; i++) {
                        calFeesAmount += parseFloat($(this).find('td').eq(i).find('div input[id^=rowInstallmentAmount]').val());
                    }

                    totalFeesAmount = parseFloat($(this).find('td').eq(parseInt(numberOfInst) + parseInt(1)).find('div input[id^=rowfeeSubTypeAmount]').val());
                  
                  
                    if (calFeesAmount == totalFeesAmount) {
                        FeeStructureMasterAndDetails.AjaxCallFeeStructureMasterAndDetails();
                        //calFeesAmount = 0;
                        //totalFeesAmount = 0;
                    }
                    else {
                        $("#displayErrorMessage p").text("Installment Total getting wrong.").closest('div').fadeIn().closest('div').addClass('alert-warning');
                    }
                  
                });
                //$("#TotalFeeAmount").val(a.toFixed(2));
                //$("#TotalAmount").val(a.toFixed(2));
            }
            else {
                $("#displayErrorMessage p").text("No data available in table").closest('div').fadeIn().closest('div').addClass('alert-warning');
            }
           


        });


        $('#DeleteFeeStructureMasterAndDetailsRecord').on("click", function () {
            FeeStructureMasterAndDetails.ActionName = "Delete";
            FeeStructureMasterAndDetails.AjaxCallFeeStructureMasterAndDetails();
        });




        //Search Fee Account Type
        //    $("#FeeAccountSubTypeDesc").autocomplete({
        //        source: function (request, response) {
        //            $.ajax({
        //                url: "/FeeStructureMasterAndDetails/GetFeeAccountTypeAndSubTypeList",
        //                type: "POST",
        //                dataType: "json",
        //                data: { term: request.term, feeAccountTypeCode: 1 },
        //                success: function (data) {
        //                    response($.map(data, function (item) {
        //                        return { label: item.feeAccountSubTypeDesc, id: item.feeAccountSubTypeMasterID, name: item.feeAccountSubTypeDesc };
        //                    }))
        //                }
        //            })
        //        },
        //        select: function (event, ui) {
        //            debugger;
        //            //alert((ui.item.id).split("~"));
        //             $(this).val(ui.item.label);                                            // display the selected text
        //            var data = (ui.item.id).split("~");
        //            $("#FeeAccountSubTypeMasterID").val(parseInt(data[0]));
        //            $("#FeeAccountSubTypeDesc").val(ui.item.name);
        //            $("#AccountIDForFeeAccountSubTypeMaster").val(parseInt(data[1]));
        //            $("#FeeAccountTypeMasterID").val(parseInt(data[2]));
        //        }
        //    });


        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;
                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');

                $.ajax({
                    url: "/FeeStructureMasterAndDetails/GetFeeSubTypeSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { term: q },
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        $.each(data, function (i, response) {
                            if (substrRegex.test(response.feeSubTypeDesc)) {
                                FeeStructureMasterAndDetails.map[response.feeSubTypeDesc] = response;
                                matches.push(response.feeSubTypeDesc);
                            }
                        });

                    },
                    async: false
                })

                cb(matches);
            };

        };


        $('#FeeSubTypeName').typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        },
        {
            name: 'states',
            source: getData()
        }).on("typeahead:selected", function (obj, item) {


            var data = (FeeStructureMasterAndDetails.map[item].feeSubTypeID).split("~");
            $('#FeeSubTypeID').val(parseInt(data[0]));
            $("#AccountID").val(parseInt(data[1]));
            $("#FeeSubTypeName").val(FeeStructureMasterAndDetails.map[item].feeSubTypeDesc);

        });

        /*--------------------------------------------------------fee account------------------------------------------------------------*/
        var getData1 = function () {
            return function findMatches(q, cb) {
                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');

                $.ajax({
                    url: "/FeeStructureMasterAndDetails/GetFeeAccountTypeAndSubTypeList",
                    type: "POST",
                    dataType: "json",
                    data: { term: q, feeAccountTypeCode: 1 },
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        $.each(data, function (i, response) {
                            if (substrRegex.test(response.feeAccountSubTypeDesc)) {
                                FeeStructureMasterAndDetails.map2[response.feeAccountSubTypeDesc] = response;
                                matches.push(response.feeAccountSubTypeDesc);
                            }
                        });

                    },
                    async: false
                })

                cb(matches);
            };

        };


        $('#FeeAccountSubTypeDesc').typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        },
        {
            name: 'states',
            source: getData1()
        }).on("typeahead:selected", function (obj, item) {
            //// alert(FeeStructureMasterAndDetails.map2[item].feeAccountSubTypeDesc);

            ////alert("hii"); return false;
            var data = (FeeStructureMasterAndDetails.map2[item].feeAccountSubTypeMasterID).split("~");
            ////alert(data); 
            $('#FeeAccountSubTypeMasterID').val(parseInt(data[0]));
            $("#AccountIDForFeeAccountSubTypeMaster").val(parseInt(data[1]));
            $("#FeeAccountTypeMasterID").val(parseInt(data[2]));
            //$("#FeeAccountSubTypeDesc").val(FeeStructureMasterAndDetails.map2[item].FeeAccountSubTypeDesc);

        });






    },
    //LoadList method is used to load List page

    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        if (Balancesheet != null && Balancesheet != "NaN" && Balancesheet != "") {
            $.ajax(
               {
                   cache: false,
                   type: "POST",
                   dataType: "html",
                   url: '/FeeStructureMasterAndDetails/List',
                   success: function (data) {
                       //Rebind Grid Data
                       $('#ListViewModel').html(data);
                   }
               });
        }
        else {
            notify("Please select balancesheet.", "danger");

        }
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, feeCriteriaId) {
        $.ajax({
            cache: false,
            type: "POST",
            data: { actionMode: actionMode, feeCriteriaMasterID: feeCriteriaId },
            dataType: "html",
            url: '/FeeStructureMasterAndDetails/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadListByFeeCriteriaMasterID: function (SelectedFeeCriteriaMasterID) {
        $.ajax({
            cache: false,
            type: "POST",
            data: { feeCriteriaMasterID: SelectedFeeCriteriaMasterID },
            dataType: "html",
            url: '/FeeStructureMasterAndDetails/List',
            success: function (result) {
                //Rebind Grid Data                
                $('#ListViewModel').html(result);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallFeeStructureMasterAndDetails: function () {
        var FeeStructureMasterAndDetailsData = null;
        if (FeeStructureMasterAndDetails.ActionName == "Create") {
            $("#FormCreateFeeStructureMasterAndDetails").validate();
            if ($("#FormCreateFeeStructureMasterAndDetails").valid()) {
                FeeStructureMasterAndDetailsData = null;
                if ($("#PaymentMode :Selected").val() == "0") {
                    FeeStructureMasterAndDetails.GetXmlDataForLumpsumFee();
                }
                else if ($("#PaymentMode :Selected").val() == "1") {
                    FeeStructureMasterAndDetails.GetXmlDataForInstallMentFee();
                }
                if (FeeStructureMasterAndDetails.XMLFeeStructureDetailsIDs != null && FeeStructureMasterAndDetails.XMLFeeStructureDetailsIDs != "") {
                    FeeStructureMasterAndDetailsData = FeeStructureMasterAndDetails.GetFeeStructureMasterAndDetails();
                    ajaxRequest.makeRequest("/FeeStructureMasterAndDetails/Create", "POST", FeeStructureMasterAndDetailsData, FeeStructureMasterAndDetails.createSuccess, "CreateFeeStructureMasterAndDetailsRecord");
                }
                else {
                    /// $('#SuccessMessage').html("No data available in table");
                    //// $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                    notify("No data available in table", "danger");
                }
            }
        }
        else if (FeeStructureMasterAndDetails.ActionName == "Delete") {
            FeeStructureMasterAndDetailsData = null;
            //$("#FormCreateFeeStructureMasterAndDetails").validate();
            FeeStructureMasterAndDetailsData = FeeStructureMasterAndDetails.GetFeeStructureMasterAndDetails();
            ajaxRequest.makeRequest("/FeeStructureMasterAndDetails/Delete", "POST", FeeStructureMasterAndDetailsData, FeeStructureMasterAndDetails.deleteSuccess, "DeleteFeeStructureMasterAndDetailsRecord");

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeStructureMasterAndDetails: function () {

        var Data = {
        };
        if (FeeStructureMasterAndDetails.ActionName == "Create") {
            Data.FeeCriteriaValueCombinationMasterID = $('input[name=FeeCriteriaValueCombinationMasterID]').val();
            Data.TotalFeeAmount = $('#TotalFeeAmount').val();
            Data.PaymentMode = $('#PaymentMode').val();
            Data.NumberOfInstallment = $('#NumberOfInstallment').val();
            Data.SelectedFeeCriteriaMasterID = $('#SelectedFeeCriteriaMasterID').val();
            Data.IsLateFeeApplicable = $('input[name=IsLateFeeApplicable]:checked').val() ? true : false;
            Data.LateFeeID = $('#LateFeeID').val();
            Data.XMLFeeStructureDetailsIDs = FeeStructureMasterAndDetails.XMLFeeStructureDetailsIDs;
            Data.XMLFeeStructureInstallmentMasterIDs = FeeStructureMasterAndDetails.XMLFeeStructureInstallmentMasterIDs;
            Data.XMLFeeStructureDetailsInstallmentWiseIDs = FeeStructureMasterAndDetails.XMLFeeStructureDetailsInstallmentWiseIDs;

            Data.FeeAccountSubTypeMasterID = $('#FeeAccountSubTypeMasterID').val();
            Data.AccountType = "FeeReceivable";
            Data.CrDrStatus = 1;
            Data.AccountIDForFeeAccountSubTypeMaster = $('#AccountIDForFeeAccountSubTypeMaster').val();
        }
        else if (FeeStructureMasterAndDetails.ActionName == "Delete") {
            Data.FeeStructureMasterID = $('input[name=FeeStructureMasterID]').val();
            Data.SelectedFeeCriteriaMasterID = $('#SelectedFeeCriteriaMasterID').val();
        }

        return Data;
    },
    ///Get Xml when fee is Lump sum.
    GetXmlDataForLumpsumFee: function () {
        debugger;
        var DataArray = [];
        $('#DivLumpsumFee input[type=text]').each(function () {
            DataArray.push($(this).val());
        });
        //alert(DataArray);
        TotalRecord = DataArray.length;
        ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 6) {
            ParameterXml = ParameterXml + "<row><FeeSubTypeID>" + DataArray[i] + "</FeeSubTypeID><FeeSubTypeAmount>" + DataArray[i + 1] +
                                          "</FeeSubTypeAmount><AccountID>" + DataArray[i + 2] + "</AccountID><CrDrStatus>" + DataArray[i + 3] +
                                          "</CrDrStatus><AccountType>" + DataArray[i + 4] + "</AccountType><Source>" + DataArray[i + 5] + "</Source></row>";
        }
        if (ParameterXml.length > 6) {
            FeeStructureMasterAndDetails.XMLFeeStructureDetailsIDs = ParameterXml + "</rows>";
            //alert(FeeStructureMasterAndDetails.XMLFeeStructureDetailsIDs);
        }
        else
            FeeStructureMasterAndDetails.XMLFeeStructureDetailsIDs = "";
    },

    //Get XML when Fees in Instollment.
    GetXmlDataForInstallMentFee: function () {
        debugger;
        var DataArray = [];
        var numberOfInstallment = $("#NumberOfInstallment").val();
        $('#DivInstallMentFee input[type=text]').each(function () {
            DataArray.push($(this).val());
        });

        TotalRecord = DataArray.length;
        var ParameterFeeStructureDetailsIDsXml = "<rows>";
        //=====================================================@xmlFeeStructureDetailsIDs==============================================================================================================================
        for (var i = 0; i < TotalRecord; i = i + parseInt(numberOfInstallment) + 6) {
            var feeType = DataArray[i].split('~');
            var sumOfIns = 0;
            for (var j = i ; j < parseInt(numberOfInstallment) + i; j++) {
                if (DataArray[j + 1] == "") {
                    DataArray[j + 1] = 0;
                }
                sumOfIns = sumOfIns + parseInt(DataArray[j + 1]);
            }

            if (DataArray[i + parseInt(numberOfInstallment) + 1] == "") {
                DataArray[i + parseInt(numberOfInstallment) + 1] = 0;
            }

            if (sumOfIns == DataArray[i + parseInt(numberOfInstallment) + 1] && DataArray[i + parseInt(numberOfInstallment) + 1] > 0) {

                ParameterFeeStructureDetailsIDsXml = ParameterFeeStructureDetailsIDsXml + "<row><FeeSubTypeID>" + feeType[0] + "</FeeSubTypeID><FeeSubTypeAmount>" + DataArray[i + parseInt(numberOfInstallment) + 1] +
                                                                                         "</FeeSubTypeAmount><AccountID>" + DataArray[i + parseInt(numberOfInstallment) + 2] + "</AccountID><CrDrStatus>" + DataArray[i + parseInt(numberOfInstallment) + 3] +
                                                                                         "</CrDrStatus><AccountType>" + DataArray[i + parseInt(numberOfInstallment) + 4] + "</AccountType><Source>" + DataArray[i + parseInt(numberOfInstallment) + 5] + "</Source></row>";
            }
            else if (DataArray[i + parseInt(numberOfInstallment) + 1] == 0) {
                ////$('#DivSuccessMessage').html("Please enter or delete Fee Amount of <strong>" + feeType[1].replace('`', ' ') + "</strong>");
                ////$('#DivSuccessMessage').delay(400).slideDown(400).delay(3500).slideUp(400).css('background-color', "#FFCC80");
                notify("Please enter or delete Fee Amount of <strong>" + feeType[1].replace('`', ' ') + "</strong>", "danger");

                return false;
            }
            else {
                ///$('#DivSuccessMessage').html("Total Installment Amount of <strong>" + feeType[1].replace('`', ' ') + "</strong> does not match with it's Fee Amount.");
                ///$('#DivSuccessMessage').delay(400).slideDown(400).delay(3500).slideUp(400).css('background-color', "#FFCC80");
                notify("Total Installment Amount of <strong>" + feeType[1].replace('`', ' ') + "</strong> does not match with it's Fee Amount.", "danger");
                return false;
            }
        }
        if (ParameterFeeStructureDetailsIDsXml.length > 6) {

            FeeStructureMasterAndDetails.XMLFeeStructureDetailsIDs = ParameterFeeStructureDetailsIDsXml + "</rows>";
        }
        else {
            FeeStructureMasterAndDetails.XMLFeeStructureDetailsIDs = "";
            // alert(FeeStructureMasterAndDetails.XMLFeeStructureDetailsIDs);
            //<rows><row><FeeSubTypeID></FeeSubTypeID><FeeSubTypeAmount></FeeSubTypeAmount></row></rows>
        }
        //=====================================================@xmlFeeStructureInstallmentMasterIDs==============================================================================================================================

        var IsLateFeeApplicable = $('input[name=IsLateFeeApplicable]:checked').val() ? true : false;
        var LateFeeID = 0;
        if (IsLateFeeApplicable == true) {
            IsLateFeeApplicable = 1;
            LateFeeID = $("#LateFeeID").val()
        }
        else {
            IsLateFeeApplicable = 0
        }

        var ParameterFeeStructureInstallmentMasterIDsXml = "<rows>";
        var countRow = TotalRecord / (parseInt(numberOfInstallment) + 6);

        for (var i = 0; i < parseInt(numberOfInstallment) ; i++) {
            var insAmt = 0, x = i + 1, y = 0;
            for (var j = 0 ; j < countRow; j++) {
                if (DataArray[x + y] == "") {
                    DataArray[x + y] = 0;
                }
                insAmt = insAmt + parseInt(DataArray[x + y]);
                y = y + parseInt(numberOfInstallment) + 6;
            }
            if (insAmt > 0) {
                ParameterFeeStructureInstallmentMasterIDsXml = ParameterFeeStructureInstallmentMasterIDsXml + "<row><InsNo>" + (parseInt(i) + 1) + "</InsNo><InsAmount>" + insAmt + "</InsAmount><IsLateFeeApplicable>" + IsLateFeeApplicable + "</IsLateFeeApplicable><LateFeeID>" + LateFeeID + "</LateFeeID></row>";
            }

        }
        if (ParameterFeeStructureInstallmentMasterIDsXml.length > 6)
            FeeStructureMasterAndDetails.XMLFeeStructureInstallmentMasterIDs = ParameterFeeStructureInstallmentMasterIDsXml + "</rows>";
        else
            FeeStructureMasterAndDetails.XMLFeeStructureInstallmentMasterIDs = "";
        // alert(FeeStructureMasterAndDetails.XMLFeeStructureInstallmentMasterIDs);
        // <rows><row><InsNo></InsNo><InsAmount></InsAmount><IsLateFeeApplicable></IsLateFeeApplicable><LateFeeID></LateFeeID></row></rows>
        //=====================================================@xmlFeeStructureDetailsInstallmentWiseIDs==============================================================================================================================

        var ParameterFeeStructureDetailsInstallmentWiseIDsXml = "<rows>";

        for (var i = 0; i < parseInt(numberOfInstallment) ; i++) {
            var x = i + 1, y = 0;
            for (var j = 0 ; j < countRow; j++) {
                if (DataArray[x + y] != "" && DataArray[x + y] != 0) {
                    var feeType = DataArray[x + y - i - 1].split('~');
                    ParameterFeeStructureDetailsInstallmentWiseIDsXml = ParameterFeeStructureDetailsInstallmentWiseIDsXml + "<row><InsMstID>0</InsMstID><InsNo>" + (parseInt(i) + 1) + "</InsNo><FeeSubTypeID>" + feeType[0] + "</FeeSubTypeID><FeeSubTypeAmount>" + DataArray[x + y] + "</FeeSubTypeAmount></row>";
                }
                y = y + parseInt(numberOfInstallment) + 6;
            }

        }
        if (ParameterFeeStructureDetailsInstallmentWiseIDsXml.length > 6)
            FeeStructureMasterAndDetails.XMLFeeStructureDetailsInstallmentWiseIDs = ParameterFeeStructureDetailsInstallmentWiseIDsXml + "</rows>";
        else
            FeeStructureMasterAndDetails.XMLFeeStructureDetailsInstallmentWiseIDs = "";
        //  alert(FeeStructureMasterAndDetails.XMLFeeStructureDetailsInstallmentWiseIDs);
        //<rows><row><InsMstID></InsMstID><InsNo></InsNo><FeeSubTypeID></FeeSubTypeID><FeeSubTypeAmount></FeeSubTypeAmount></row></rows>
    },

    TotalFeeAmount: function () {

        var length = $("#tblDataLumpsum tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalFeeAmount").val(0);
        $("#tblDataLumpsum tbody tr").each(function (i) {
            if (i < length) {
                a += parseFloat($(this).find('td input[id^=rowfeeSubTypeAmount]').val());
            }
        });
        
        $("#TotalFeeAmount").val(a.toFixed(2));
        $("#TotalAmount").val(a.toFixed(2));
    },

    TotalFeeInstallmentAmount: function () {
        // var numberOfInstallment = $("#NumberOfInstallment").val();
        var length = $("#tblDataInstallMent tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalFeeAmount").val(0);
        $("#tblDataInstallMent tbody tr").each(function (i) {
            if (i < length) {
                a += parseFloat($(this).find('td input[id^=rowfeeSubTypeAmount]').val());
            }
        });
        $("#TotalFeeAmount").val(a.toFixed(2));
        $("#TotalAmount").val(a.toFixed(2));
    },


    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {

        var feeCriteriaMasterID = data.SelectedFeeCriteriaMasterID;
        var splitData = data.errorMessage.split(',');

        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            FeeStructureMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2], feeCriteriaMasterID);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }

    },

    deleteSuccess: function (data) {

        var feeCriteriaMasterID = data.SelectedFeeCriteriaMasterID;
        var splitData = data.errorMessage.split(',');
        FeeStructureMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2], feeCriteriaMasterID);
        parent.$.colorbox.close();

    },

};

