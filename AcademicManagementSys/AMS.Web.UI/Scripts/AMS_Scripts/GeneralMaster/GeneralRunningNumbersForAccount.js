//this class contain methods related to nationality functionality
var GeneralRunningNumbersForAccount = {
    //Member variables
    ActionName: null,
    XMLstringParam: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralRunningNumbersForAccount.constructor();
        //GeneralRunningNumbersForAccount.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {


        

        // Create new record
        $('#CreateGeneralRunningNumbersForAccountRecord').on("click", function () {           
            GeneralRunningNumbersForAccount.ActionName = "Create";
            GeneralRunningNumbersForAccount.CreateXmlForDisplayFormat();
            GeneralRunningNumbersForAccount.AjaxCallGeneralRunningNumbersForAccount();
        });

        InitAnimatedBorder();
        CloseAlert();

    },
    //LoadList method is used to load List page
    LoadList: function (centreCode) {
        $.ajax({
            cache: false,
            type: "POST",
            data: { centreCode: centreCode },
            dataType: "html",
            url: '/GeneralRunningNumbersForAccount/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().html(data);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        
        var centreCode = $('input[id="CentreCode"]').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            //  data: { CallTypeID: CallTypeID, Status: Status, UploadDate: UploadDate, actionMode: actionMode },
            data: { centreCode: centreCode, actionMode: actionMode },
            url: '/GeneralRunningNumbersForAccount/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralRunningNumbersForAccount: function () {
        var GeneralRunningNumbersForAccountData = null;
        if (GeneralRunningNumbersForAccount.ActionName == "Create") {
            $("#FormCreateGeneralRunningNumbersForAccount").validate();
            if ($("#FormCreateGeneralRunningNumbersForAccount").valid()) {
                GeneralRunningNumbersForAccountData = null;
                GeneralRunningNumbersForAccountData = GeneralRunningNumbersForAccount.GetGeneralRunningNumbersForAccount();
                ajaxRequest.makeRequest("/GeneralRunningNumbersForAccount/Create", "POST", GeneralRunningNumbersForAccountData, GeneralRunningNumbersForAccount.Success, "CreateGeneralRunningNumbersForAccountRecord");
            }
        }
    },

    //create xml for display format
    CreateXmlForDisplayFormat: function () {
        GeneralRunningNumbersForAccount.XMLstringParam = '<CentreCode></CentreCode>' + $("#Seperator").val() + '<Prefix></Prefix>' + $("#Seperator").val() + '<YYYY></YYYY>' + $("#Seperator").val() + '<MM></MM>' + $("#Seperator").val() + '<CurrentCounter></CurrentCounter>';
    },

    //Get properties data from the Create, Update and Delete page
    GetGeneralRunningNumbersForAccount: function () {
        var Data = {
        };
        if (GeneralRunningNumbersForAccount.ActionName == "Create") {
            Data.Description = $('#Description').val();
            Data.KeyField = $('#KeyField').val();
            Data.FinancialYearID = $('#FinancialYearID').val();
            Data.FinancialYear = $('#FinancialYear').val();
            Data.StartNumber = $('#StartNumber').val();
            Data.Seperator = $('#Seperator').val();
            Data.Prefix1 = $('#Prefix1').val();
            Data.CentreCode = $('input[id="CentreCode"]').val();
            Data.DisplayFormat = GeneralRunningNumbersForAccount.XMLstringParam;
        }

        return Data;
    },

    InitAndValidateCentreList: function () {
        $("#CentreCode").change(function () {
            $("#divCardHeader").hide();
            $('#myDataTable').empty().append('<tbody><tr class="odd"><td valign="top" colspan="4" class="dataTables_empty">No data available in table</td></tr></tbody>');
            $('#myDataTable_info').text("No entries to show");
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });

        $('#btnShowList').click(function () {
            var centreCode = $('#CentreCode :selected').val();
            if (centreCode != '' && centreCode != null) {
                GeneralRunningNumbersForAccount.LoadList(centreCode);
                $("#divCardHeader").show();
            }
            else {
                notify("Please select centre", "warning");
            }
        });
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralRunningNumbersForAccount.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

