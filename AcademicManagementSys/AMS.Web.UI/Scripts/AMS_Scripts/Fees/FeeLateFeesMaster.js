//this class contain methods related to nationality functionality
var FeeLateFeesMaster = {
    //Member variables
    ActionName: null,
    XmlString :null,
    //Class intialisation method
    Initialize: function () {
        FeeLateFeesMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form

        $("#divSlabDetails").hide();

        $("#SlabFixedFlag").on("change", function () {
            if ($(this).val() == "1") {
                $("#divSlabDetails").hide();
                $("#divFixedDetails").show();
                $("#tblData tbody tr").remove();
                $("#LateFeeSlabFrom").val('');
                $("#LateFeeSlabTo").val('');
                $("#PeriodTypeForSlab").val('');
                $("#LateFeeAmountForSlab").val(0);
                FeeLateFeesMaster.XmlString = "";
            }
            else {
                $("#divSlabDetails").show();
                $("#divFixedDetails").hide();
                $("#LateFeeAmount").val(0);
            }
        });

        $('#CreateFeeLateFeesMasterRecord').on("click", function () {
            debugger;
            debugger;
            FeeLateFeesMaster.ActionName = "Create";
            
            if ($("#SlabFixedFlag").val() == 2) {
                if (FeeLateFeesMaster.IsValidXmlForSlab()) {
                    FeeLateFeesMaster.AjaxCallFeeLateFeesMaster();
                }
                else {
                    $("#displayErrorMessage p").text("Slab details are mandatory").closest('div').fadeIn().closest('div').addClass('alert-warning');
                }
            }
            else {
                FeeLateFeesMaster.AjaxCallFeeLateFeesMaster();
            }
            
        });
        



        $('#btnAddSlab').on("click", function () {
            debugger;
            if ($("#LateFeeSlabFrom").val() != "" && $("#LateFeeSlabTo").val() != "" && $("#LateFeeAmountForSlab").val() > 0) {
                var rowLength = $("#tblData tbody tr").length;
                $("#tblData tbody").append(
                                          "<tr >" +
                                               "<td >" + parseInt(rowLength + 1) + "</td>" +
                                               "<td ><input type='hidden' value='" + $("#LateFeeSlabFrom").val() + "' >" + $("#LateFeeSlabFrom").val() + "</td>" +
                                               "<td><input type='hidden' value='" + $("#LateFeeSlabTo").val() + "' >" + $("#LateFeeSlabTo").val() + "</td>" +
                                               "<td> <input type='hidden' value='" + $("#PeriodTypeForSlab :selected").val() + "' >" + $("#PeriodTypeForSlab :selected").text() + "</td>" +
                                               "<td><input type='hidden' value='" + $("#LateFeeAmountForSlab").val() + "' >" + $("#LateFeeAmountForSlab").val() + "</td>" +
                                               "<td> " + '<i class="zmdi zmdi-delete zmdi-hc-fw" style="cursor:pointer"></i>' + "</td>" +
                                          "</tr>"
                                              );

                $("#LateFeeSlabFrom").val('');
                $("#LateFeeSlabTo").val('');
                $("#PeriodTypeForSlab").val('1');
                $("#LateFeeAmountForSlab").val('0');
                FeeLateFeesMaster.DeleteRow();
            }
            else if ($("#LateFeeSlabFrom").val() == "") {
                $("#displayErrorMessage p").text("From date must be selected").closest('div').fadeIn().closest('div').addClass('alert-warning');
            }
            else if ($("#LateFeeSlabTo").val() == "") {
                $("#displayErrorMessage p").text("UpTo date must be selected").closest('div').fadeIn().closest('div').addClass('alert-warning');
            }
            else if ($("#LateFeeAmountForSlab").val() == "" || $("#LateFeeAmountForSlab").val() == 0) {
                $("#displayErrorMessage p").text("Late Fee should not be blank").closest('div').fadeIn().closest('div').addClass('alert-warning');
            }

        });



        $('#LateFeeAmountForSlab').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });



     
        //$('#BankLimitAmount').on("keydown", function (e) {
        //    AMSValidation.AllowNumbersWithDecimalOnly(e);
        //});

        //$('#RateOfInterest').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);
        //});

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
                url: '/FeeLateFeesMaster/List',
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
            type: "GET",
            data: { "actionMode": actionMode },
            dataType: "html",
            url: '/FeeLateFeesMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                ////twitter type notification
                notify(message, colorCode);
            }
        });
    },
    DeleteRow: function () {
        $("#tblData tbody").on("click", "tr td i", function () {
            $(this).closest('tr').remove();
            $("#tblData tbody tr").each(function (i) {
                $(this).find('td').eq(0).text(i+1);
            });
        });        
    },
    IsValidXmlForSlab: function () {
       
        var DataArray = [];
        $("#tblData tbody tr td input[type=hidden]").each(function () {
            DataArray.push($(this).val());
        });
        var XmlParam = '';
        count = DataArray.length / 4;
        XmlParam = "<rows>";
        var x = 0;
        for (var i = 0; i < count; i++) {

            XmlParam += "<row><LateFeeSlabFrom>" + DataArray[x + 0] + "</LateFeeSlabFrom><LateFeeSlabTo>" + DataArray[x + 1] + "</LateFeeSlabTo><PeriodTypeID>" + DataArray[x + 2] + "</PeriodTypeID><LateFeeValue>" + DataArray[x + 3] + "</LateFeeValue></row>"
            x = x + 4;
        }
        if (XmlParam.length > 6) {
            FeeLateFeesMaster.XmlString = XmlParam + "</rows>";
            return true;
        }
        else {
            FeeLateFeesMaster.XmlString = "";
            return false;
        }
    },
    //Fire ajax call to insert update and delete record
    AjaxCallFeeLateFeesMaster: function () {
        var FeeLateFeesMasterData = null;
        if (FeeLateFeesMaster.ActionName == "Create") {
            $("#FormCreateFeeLateFeesMaster").validate();
            if ($("#FormCreateFeeLateFeesMaster").valid()) {
                FeeLateFeesMasterData = null;
                FeeLateFeesMasterData = FeeLateFeesMaster.GetFeeLateFeesMaster();
                ajaxRequest.makeRequest("/FeeLateFeesMaster/Create", "POST", FeeLateFeesMasterData, FeeLateFeesMaster.Success, "CreateFeeLateFeesMasterRecord");
            }
        }
        else if (FeeLateFeesMaster.ActionName == "DeleteFeeType") {
            $("#FormDeleteFeeTypeMaster").validate();
            if ($("#FormDeleteFeeTypeMaster").valid()) {
                FeeLateFeesMasterData = null;
                FeeLateFeesMasterData = FeeLateFeesMaster.GetFeeLateFeesMaster();
                ajaxRequest.makeRequest("/FeeLateFeesMaster/Delete", "POST", FeeLateFeesMasterData, FeeLateFeesMaster.Success, "");
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeLateFeesMaster: function () {
        var Data = {
        };

        Data.LateFeeDescription = $('#LateFeeDescription').val();
        Data.LateFeeType = $('#LateFeeType :selected').val();
        Data.FeeSubTypeID = $('#FeeSubType :selected').val();
        Data.SlabFixedFlag = $("#SlabFixedFlag :selected").val();
        Data.LateFeeAmount = $("#LateFeeAmount").val();
        if (Data.SlabFixedFlag == "2") {
            Data.PeriodTypeID = 0;
        }
        else {
            Data.PeriodTypeID = $("#PeriodTypeID :selected").val();
        }
        Data.IsIncremental = $("#IsIncremental").is(':checked');
        Data.SelectedXml = FeeLateFeesMaster.XmlString;
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            FeeLateFeesMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }

    },
};