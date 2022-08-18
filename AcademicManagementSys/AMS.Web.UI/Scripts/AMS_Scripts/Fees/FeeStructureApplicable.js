//this class contain methods related to nationality functionality
var FeeStructureApplicable = {
    //Member variables
    ActionName: null,
    IsLazyLoadActive: 0,
    PageLoadCount: 0,
    page: 0,
    indexNumber: 0,
    inCallback: false,
    hasReachedEndOfInfiniteScroll: false,
    scrollHandler: null,
    XMLstring: null,
    FeeApprovalXmlstring: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        FeeStructureApplicable.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        FeeStructureApplicable.PageLoadCount = FeeStructureApplicable.PageLoadCount + 1;
        $("#CreateFeeStructureApplicable").click(function () {
            var $btn = $(this);
            $btn.button("loading");
            // simulating a timeout
            setTimeout(function () {
                $btn.button('reset');;
            }, 20000);
        });



        $("#SelectedFeeCriteriaMasterID").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });

        $('#btnShowList').click(function () {
            var valueSelectedFeeCriteriaMasterID = $('#SelectedFeeCriteriaMasterID :selected').val();
            if (valueSelectedFeeCriteriaMasterID > 0) {
                FeeStructureApplicable.LoadListByFeeCriteriaMasterID(valueSelectedFeeCriteriaMasterID);
            }
            else if (valueSelectedFeeCriteriaMasterID <= 0) {
                $('#SuccessMessage').html("Please select fee criteria");
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
        });

      

        // FeeStructureApplicable.ShowList();

        $("#CreateFeeStructureApproval").on("click", function () {
            
            FeeStructureApplicable.ActionName = "FeeStructureRequestApproval";
            FeeStructureApplicable.GetFeeApprovalXmlData();
            if (FeeStructureApplicable.FeeApprovalXmlstring != "" && FeeStructureApplicable.FeeApprovalXmlstring != null) {
                FeeStructureApplicable.AjaxCallFeeStructureApplicable();
            } else {
                $('#msgDiv').html("No fee availble to approval.");
                $('#msgDiv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            }
        });



        $("#RejectFeeStructureApproval").on("click", function () {
            FeeStructureApplicable.ActionName = "FeeStructureReject";
            FeeStructureApplicable.GetFeeApprovalXmlData();
            FeeStructureApplicable.AjaxCallFeeStructureApplicable();
        });

        scrollHandler = function () {
            if (FeeStructureApplicable.hasReachedEndOfInfiniteScroll == false && ($(window).scrollTop() == $(document).height() - $(window).height()) && FeeStructureApplicable.IsLazyLoadActive == 1) {
                FeeStructureApplicable.loadMoreToInfiniteScrollTable();
            }
        }
    },

    //Get Data For Fee Approval in XML.
    GetFeeApprovalXmlData: function () {

        var DataArray = [];
        $('#tblFeeStructure tbody tr td input[type="text"]').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        var FeeApprovalXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            if (DataArray[i] > 0) {
                var CrDrflag = 'D'
            
                if (DataArray[i + 1] == "False")
                {
                    CrDrflag = 'C'
                }
                FeeApprovalXml = FeeApprovalXml
                                    + "<row>"
               		                + "<TransactionSubID>0</TransactionSubID>"
               		                + "<AccountID>" + DataArray[i + 0] + "</AccountID>"
               		                + "<DebitCreditFlag>" + CrDrflag + "</DebitCreditFlag>"
               		                + "<TransactionAmount>" + DataArray[i + 2] + "</TransactionAmount>"
               		                + "<ChequeNo></ChequeNo>"
               		                + "<ChequeDatetime></ChequeDatetime>"
               		                + "<NarrationDescription>Fee receivable</NarrationDescription>"
               		                + "<BankName></BankName>"
               		                + "<BranchName></BranchName>"
               		                + "<PersonID>" + DataArray[i + 3] + "</PersonID>"
               		                + "<PersonType>S</PersonType>"
               		                + "<IsActive>1</IsActive>"
               	                    + "</row>";
            }
        }
        if (FeeApprovalXml.length > 10) {
            FeeStructureApplicable.FeeApprovalXmlstring = FeeApprovalXml + "</rows>";
        }
        else {
            FeeStructureApplicable.FeeApprovalXmlstring = "";
        }
    },

    ShowList: function () {
        $("#removeStructListDiv").on("click", function () {
            $("#listViewDiv").show("slow");
            $("#structListDiv").hide("slow");
            FeeStructureApplicable.IsLazyLoadActive = 0;
        });
    },

    DatePickerValidation: function () {
        //$(".mydateclass").datepicker({
        //    dateFormat: 'd M yy',
        //    numberOfMonths: 1,
        //    onSelect: function (dateText, inst) {
        //        if ($(this).attr('id').split('~')[0] == 'installmentFromDate') {
        //            $(this).closest('tr').find('td input[id^=installmentUptoDate]').datepicker("change", { minDate: new Date($(this).val()) });
        //        }
        //        if ($(this).attr('id').split('~')[0] == 'installmentUptoDate') {
        //            $(this).closest('tr').find('td input[id^=installmentFromDate]').datepicker("change", { maxDate: new Date($(this).val()) });
        //        }
        //    }
        //});

        //$("#ApplicableFromDate").datepicker({
        //    dateFormat: 'd M yy',
        //    //minDate: new Date(),
        //    numberOfMonths: 1,
        //});
        InitAnimatedBorder();
        CloseAlert();
        $('#ApplicableFromDate').datetimepicker({
            format: 'DD MMMM YYYY',

        });
        $('.mydateclass').datetimepicker({
            format: 'DD MMMM YYYY',
            //orientation: 'auto top'
         });

        $(".mydateclass").on("dp.change", function (e) {
            
            if ($(this).attr('id').split('~')[0] == 'installmentFromDate') {
                $(this).closest('tr').find('td input[id^=installmentUptoDate]').datetimepicker("change", { minDate: new Date($(this).val()) });
            }
            if ($(this).attr('id').split('~')[0] == 'installmentUptoDate') {
                $(this).closest('tr').find('td input[id^=installmentFromDate]').datetimepicker("change", { maxDate: new Date($(this).val()) });
            }
        });

        //$(".mydateclass").on("dp.change", function (e) {
        //    //alert('e.date');                
        //    //$('#JobEndDate').val('');
        //    var minDate = new Date(e.date.valueOf());
        //    minDate.setDate(minDate.getDate());
        //    $('#ApplicableFromDate').data("DateTimePicker").maxDate(minDate);
        //    //$('#JobEndDate').data("DateTimePicker").minDate(e.date);

        //});

        $("#tblData2 tbody").on("keydown", "tr td input[id^=installmentFromDate]", function () {
            return false;
        });

        $("#tblData2 tbody").on("keydown", "tr td input[id^=installmentUptoDate]", function () {
            return false;
        });
        $("#ApplicableFromDate").on("keydown", function () {
            return false;
        });
    },


    //LoadList method is used to load List page
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        if (Balancesheet != null && Balancesheet != "NaN" && Balancesheet != "") {
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "html",
                url: '/FeeStructureApplicable/List',
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
    ReloadList: function (message, colorCode, actionMode, feeCriteriaMasterID) {
        $.ajax({
            cache: false,
            type: "POST",
            data: { actionMode: actionMode, feeCriteriaMasterID: feeCriteriaMasterID },
            dataType: "html",
            url: '/FeeStructureApplicable/List',
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
            url: '/FeeStructureApplicable/List',
            success: function (result) {
                //Rebind Grid Data                
                $('#ListViewModel').html(result);
            }
        });
    },

    LoadDatatable: function () {
        var oTable = $('#myDataTable').DataTable({
            "bServerSide": true,
            "sAjaxSource": "FeeStructureApplicable/AjaxHandler",
            "bJQueryUI": true,
            "sScrollY": false,
            "bProcessing": true,
            "sPaginationType": "full_numbers",
            "oLanguage": {
                "sInfoEmpty": "No entries to show",
            },
            "fnServerParams": function (aoData) {
                aoData.push({ "name": "selectedBalsheetID", "value": $("#selectedBalsheetID").val() }),
                   aoData.push({ "name": "selectedFeeCriteriaMasterID", "value": $("#SelectedFeeCriteriaMasterID").val() });
            },
            "columnDefs": [{
                "targets": 1,
                "bSortable": false,
            },
                   {
                       "targets": 2,
                       "bSortable": false,
                       "data": null,
                       "render": function (data, type, full, meta) {
                           var chkStatus = '';
                           if (data[2] == "True") {
                               chkStatus = 'checked';
                               var result = "<p class='checkbox'  style='margin-left:40%'>" + '<input id="IsActive" type="checkbox" disabled ' + chkStatus + ' /><i class="input-helper"></i>' + "</p>";
                           }
                           else {
                               var result = "<p class='checkbox'  style='margin-left:40%'>" + '<input id="IsActive"  type="checkbox" disabled ' + chkStatus + ' /><i class="input-helper"></i>' + "</p>";
                           }
                           return result;
                       }
                   },
                      {
                          "targets": 3,
                          "bSortable": false,
                          "data": null,
                          "render": function (data, type, full, meta) {
                              var chkStatus = '';
                              if (data[3] == "True") {
                                  chkStatus = 'checked';
                                  var result = "<p class='checkbox' style='margin-left:40%'>" + '<input id="IsActive" class="CheckBox" type="checkbox" disabled ' + chkStatus + ' /><i class="input-helper"></i>' + "</p>";
                              }
                              else {
                                  var result = "<p class='checkbox' style='margin-left:40%'>" + '<input id="IsActive" class="CheckBox" type="checkbox" disabled ' + chkStatus + ' /><i class="input-helper"></i>' + "</p>";
                              }
                              return result;
                          }
                      },
                  {
                      "targets": 4,
                      "bSortable": false,
                      "data": null,
                      "render": function (data, type, full, meta) {
                          var result = "<p  style='text-align: center; cursor:pointer'><i class='zmdi zmdi-plus btn' tag=" + data[4] + " title = 'Allocate Fee Structure'></i></p>";
                          return result;

                          //if (data[3] == "True") {

                          //    var result1 = '@Html.ActionLink("Edit1", "Edit", new { IDs="ID1" }, new { @class = "ajax  cboxElement" })';
                          //    result1 = result1.replace("ID1", data[4] + '~' + data[5]);
                          //    result1 = result1.replace("Edit1", '<i class="icon-edit" title = "@Resources.ToolTip_Edit"></i>');

                          //    var result2 = '@Html.ActionLink("Delete1", "Delete", new { ID="ID1" }, new { @class = "ajax  cboxElement" })';
                          //    result2 = result2.replace("ID1", data[5]);
                          //    result2 = result2.replace("Delete1", '<i class="icon-trash" title="@Resources.ToolTip_Delete"></i>');

                          //    var result = "<p  style='text-align:center; height:5px;'>" + result1 + "|" + result2 + "</p>";
                          //    return result;

                          //}
                          //else {
                          //    var result3 = '@Html.ActionLink("Create1", "Create", new {ID="ID1" }, new { @class = "ajax  cboxElement" })';
                          //    result3 = result3.replace('ID1', data[4]);
                          //    result3 = result3.replace("Create1", '<i class="icon-plus" style="cursor:pointer" title = "@Resources.ToolTip_Create"></i>');

                          //    var result = "<p  style='text-align: center; height:5px;cursor:pointer'><i class='icon-plus' tag=" + data[4] + " title = 'Allocate Fee Structure'></i></p>";
                          //    return result;
                          //}
                      }
                  }
            ],
        });
        DataTableSettings(oTable, "myDataTable", "toggleTableColumn");

    },

    ShowFeeStructureDetails: function () {
        $("#myDataTable tbody").on("click", "tr td p i", function () {
            $("#listViewDiv").hide("slow");
            $("#structListDiv").show("slow");
            var feeStructureID = $(this).attr("tag");
            
            $.ajax({
                cache: false,
                type: "GET",
                dataType: "html",
                data: { ID: feeStructureID },
                url: '/FeeStructureApplicable/Create',
                success: function (data) {
                    
                    //Rebind Grid Data
                    $('#structListDiv').html(data);
                   
                    $("#FeeStructureMasterID").val(feeStructureID);
                    FeeStructureApplicable.IsLazyLoadActive = 1;
                }
            });
        });
    },

    AllocateFeeStructure: function () {
        $('#CreateFeeStructureApplicable').on("click", function () {
            FeeStructureApplicable.ActionName = "Create";
            if ($("#FeeStructureSessionMasterID").val() == 0 && $("#IsInstallmentApplicable").val() == "True") {
                if (FeeStructureApplicable.IsValidInstallmentXml()) {
                        FeeStructureApplicable.AjaxCallFeeStructureApplicable();
                }
                else {
                    notify(" Please fill installment details properly.", "danger");
                }
                $("#CreateFeeStructureApplicable").attr("disabled", false);
            }
            else if ($("#FeeStructureSessionMasterID").val() == 0 && $("#IsInstallmentApplicable").val() == "False") {               
                    FeeStructureApplicable.AjaxCallFeeStructureApplicable();               
            }

            if ($("#FeeStructureSessionMasterID").val() > 0) {
                if ($("#tblData3 tbody tr").length >= 1) {
                    FeeStructureApplicable.AjaxCallFeeStructureApplicable();
                }
                else {
                    notify("No student available.", "danger");
                }
                $("#CreateFeeStructureApplicable").attr("disabled", false);
            }
            FeeStructureApplicable.XMLstring = "";
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallFeeStructureApplicable: function () {
        var FeeStructureApplicableData = null;
        if (FeeStructureApplicable.ActionName == "Create") {
            if ($("#FormCreateFeeStructureApplicable").valid()) {
                FeeStructureApplicableData = null;
                FeeStructureApplicableData = FeeStructureApplicable.GetFeeStructureApplicable();
                ajaxRequest.makeRequest("/FeeStructureApplicable/Create", "POST", FeeStructureApplicableData, FeeStructureApplicable.createSuccess, "CreateFeeStructureApplicable");
            }
        }
        if (FeeStructureApplicable.ActionName == "FeeStructureRequestApproval") {
            
            if ($("#FormFeeStructureRequestAppronal").valid()) {
                FeeStructureApplicableData = null;
                FeeStructureApplicableData = FeeStructureApplicable.GetFeeStructureApplicable();
                ajaxRequest.makeRequest("/FeeStructureApplicable/CreateFeeStructureRequestApproval", "POST", FeeStructureApplicableData, FeeStructureApplicable.success);
            }
        }
        if (FeeStructureApplicable.ActionName == "FeeStructureReject") {
           
            if ($("#FormFeeStructureRequestAppronal").valid()) {
                FeeStructureApplicableData = null;
                FeeStructureApplicableData = FeeStructureApplicable.GetFeeStructureApplicable();
                ajaxRequest.makeRequest("/FeeStructureApplicable/CreateFeeStructureRequestApproval", "POST", FeeStructureApplicableData, FeeStructureApplicable.success);
            }
        } 
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeStructureApplicable: function () {
        var Data = {
        };
        if (FeeStructureApplicable.ActionName == "Create") {
            Data.FeeStructureSessionMasterID = $('input[name=FeeStructureSessionMasterID]').val();
            Data.IsInstallmentApplicable = $('input[name=IsInstallmentApplicable]').val();
            Data.FeeStructureMasterID = $('input[name=FeeStructureMasterID]').val();
            
            Data.ApplicableFromDate = $('#ApplicableFromDate').val();
            Data.AccBalsheetID = $('input[id=selectedBalsheetID]').val();
            Data.SelectedFeeCriteriaMasterID = $('#SelectedFeeCriteriaMasterID :selected').val();
            Data.XMLstring = FeeStructureApplicable.XMLstring;
        }
        if (FeeStructureApplicable.ActionName == "FeeStructureRequestApproval" || FeeStructureApplicable.ActionName == "FeeStructureReject") {
            Data.FeeApprovalXmlstring = FeeStructureApplicable.FeeApprovalXmlstring;
            Data.FeeStructureMasterID = $('input[name=FeeStructureMasterID]').val();
            Data.AccBalanceSheetID = $('input[name=AccBalanceSheetID]').val();
            Data.AccountSessionID = $('input[name=AccountSessionID]').val();
            Data.FeeStructureApplicableHistoryID = $('input[name=FeeStructureApplicableHistoryID]').val();
            Data.StudentID = $('input[name=StudentID]').val();
            if (FeeStructureApplicable.ActionName == "FeeStructureRequestApproval") {
                Data.RequestApprovalStatus = 1;
            }
            else {
                Data.RequestApprovalStatus = 0;
            }
            
            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
        }
        return Data;
    },

    IsValidInstallmentXml: function () {
        var DataArray = [];
        $('#tblData2 tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
        TotalRecord = DataArray.length;
        ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            if (DataArray[i + 2].length >= 10 && DataArray[i + 3].length >= 10) {
                ParameterXml = ParameterXml + "<row><ID>0</ID><FeeStructureInstallmentMasterID>" + DataArray[i + 1] + "</FeeStructureInstallmentMasterID><InstallmentFromDate>" + DataArray[i + 2] + "</InstallmentFromDate><InstallmentToDate>" + DataArray[i + 3] + "</InstallmentToDate></row>";
            }
            else {
                ParameterXml = "";
                break;
            }
        }
        if (ParameterXml.length > 6) {
            FeeStructureApplicable.XMLstring = ParameterXml + "</rows>";
            return true;
        }
        else {
            FeeStructureApplicable.XMLstring = "";
            return false;
        }
    },

    loadMoreToInfiniteScrollTable: function (loadMoreRowsUrl) {
        if (FeeStructureApplicable.page > -1 && !FeeStructureApplicable.inCallback) {
            FeeStructureApplicable.inCallback = true;
            FeeStructureApplicable.page++;
            $("div#loading").show();
            $.ajax({
                type: 'GET',
                url: "/FeeStructureApplicable/GetStudentList",
                data: { "pageNum": FeeStructureApplicable.page, ID: $("#FeeStructureMasterID").val() },
                success: function (data, textstatus) {
                    if (String(data).length > 10) {
                        $("#tblData3.infinite-scroll > tbody").append(data);
                        $("#tblData3.infinite-scroll > tbody > tr:even").addClass("alt-row-class");
                        $("#tblData3.infinite-scroll > tbody > tr:odd").removeClass("alt-row-class");
                    }
                    else {
                        FeeStructureApplicable.page = -1;
                        FeeStructureApplicable.showNoMoreRecords()
                    }
                    FeeStructureApplicable.inCallback = false;
                    $("div#loading").hide();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }
    },

    showNoMoreRecords: function () {
        FeeStructureApplicable.hasReachedEndOfInfiniteScroll = true;
    },

    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {
        var feeCriteriaMasterID = data.SelectedFeeCriteriaMasterID;
        var splitData = data.errorMessage.split(',');
        FeeStructureApplicable.ReloadList(splitData[0], splitData[1], splitData[2], feeCriteriaMasterID);
    },

    deleteSuccess: function (data) {
        var feeCriteriaMasterID = data.SelectedFeeCriteriaMasterID;
        var splitData = data.errorMessage.split(',');
        FeeStructureApplicable.ReloadList(splitData[0], splitData[1], splitData[2], feeCriteriaMasterID);
        parent.$.colorbox.close();
    },

    success: function (data) {
        parent.$.colorbox.close();
    },
};

