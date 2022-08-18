//this class contain methods related to nationality functionality
var CRMCallEnquiryDetails = {
    //Member variables
    ActionName: null,
    XMLstringParam: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMCallEnquiryDetails.constructor();
        //CRMCallEnquiryDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#UploadDate').datetimepicker({
            format: 'DD MMMM YYYY',
             maxDate: moment(),
        });

        $("#UploadDate").on("keydown", function () {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                return false;
            }
        })

       if ($('input[name=errorMessage]').val() != "NoMessage")
        {
            var splitedMsg = ($('input[name=errorMessage]').val()).split(',');
            notify(splitedMsg[0], "warning");
            $('input[name=errorMessage]').val("NoMessage");
        }

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CounterCode').focus();
            return false;
        });
        $("#CallTypeID").change(function () {
            $('#UnallocatedTotal').val(0);
            $('#AllocatedTotal').val(0);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });
        $("#Status").change(function () {
            $('#UnallocatedTotal').val(0);
            $('#AllocatedTotal').val(0);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });

        $('#btnShowList').click(function () {
           
            var valuCallType = $('#CallTypeID :selected').val();
            var ValuStatus = $('#Status :selected').val();
            var ValuUploadDate = $('#UploadDate').val();
           
            if (valuCallType != "") {
                CRMCallEnquiryDetails.LoadList(valuCallType, ValuStatus, ValuUploadDate);
            }
            else {
                 notify("Please select call Type", "warning");
                return false;
            }

        });

       $("#MyFile").change(function () {
          
            ////  var filename = "OptionImageFile";
            //var MyFileType = $('#MyFile')[0].files[0].type;
            //var Extension = MyFileType.split('/');
            //MyFileFileName = $('#MyFile')[0].files[0].name;
            var file = $('#MyFile')[0].files[0];
            var MyFileFileName = file.name;
            var Extension = '.' + MyFileFileName.split('.').pop();
            if (MyFileFileName != "" && MyFileFileName != "undefined") {

                if (Extension == ".xls" || Extension == ".xlsx") {
                    var a = "";
                }
                else {
                    $("#displayErrorMessage p").text("Option excel only allows file types of xls and xlsx.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#MyFile").replaceWith($("#MyFile").val('').clone(true));
                    return false;
                }
            }
            else {
                alert();
                $("#displayErrorMessage p").text("The selected file does not appear to be an excel file.").closest('div').fadeIn().closest('div').addClass('alert-' + "success");
             
                $("#MyFile").replaceWith($("#MyFile").val('').clone(true));

            }
        });

       InitAnimatedBorder();
       CloseAlert();

    },
    //LoadList method is used to load List page
    LoadList: function () {
    $.ajax(

         {
             cache: false,
             type: "POST",
             //   data: { CallType: CallType, Status: Status, UploadDate: UploadDate },
             dataType: "html",
             url: '/CRMCallEnquiryDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });

    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var CallTypeID = $('#CallTypeID :selected').val();
        //var Status = $('#Status').val();
        //var UploadDate = $('#UploadDate').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            //  data: { CallTypeID: CallTypeID, Status: Status, UploadDate: UploadDate, actionMode: actionMode },
            data: { CallTypeID: CallTypeID, actionMode: actionMode },
            url: '/CRMCallEnquiryDetails/List',
            success: function (data) {
                $("#ListViewModel").empty().append(data);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallCRMCallEnquiryDetails: function () {
        var CRMCallEnquiryDetailsData = null;
        if (CRMCallEnquiryDetails.ActionName == "Create") {
            //$("#FormCreateCRMCallEnquiryDetails").validate();
            //if ($("#FormCreateCRMCallEnquiryDetails").valid()) {
            CRMCallEnquiryDetailsData = null;
            CRMCallEnquiryDetailsData = CRMCallEnquiryDetails.GetCRMCallEnquiryDetails();
            ajaxRequest.makeRequest("/CRMCallEnquiryDetails/Create", "POST", CRMCallEnquiryDetailsData, CRMCallEnquiryDetails.Success,"");
        }
        //}

    },
    //Get properties data from the Create, Update and Delete page
    GetCRMCallEnquiryDetails: function () {
        var Data = {
        };
        if (CRMCallEnquiryDetails.ActionName == "Create") {
            
            Data.ID = $('#ID').val();
            Data.CallTypeID = $('#CallTypeID').val();
            var data = new FormData();
            var files = $("#MyFile").get(0).files;
            if (files.length > 0) {
                data.append("MyFile", files[0]);
                $.ajax({
                    url: "/CRMCallEnquiryDetails/UploadQuestionFile",
                    type: "POST",
                    processData: false,
                    contentType: false,
                    data: data,               //Q => Question
                    dataType: 'json',
                    success: function (data) {
                      //  CRMCallEnquiryDetails.XMLstringParam = $.parseXML(data);
                        // Data.XMLstring = data;
                        //  alert(CRMCallEnquiryDetails.XMLstring);
                    },
                    error: function (er) {
                        alert(er.error);
                       
                    }

                });

            }

            // Data.XMLstring = CRMCallEnquiryDetails.XMLstringParam;
            //  alert(CRMCallEnquiryDetails.XMLstringParam);
        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMCallEnquiryDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }

    },


};

