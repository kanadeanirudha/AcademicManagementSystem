//this class contain methods related to nationality functionality
var CRMCallEnquiryDetailsCallForward = {
    //Member variables
    ActionName: null,
    ParameterXml: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMCallEnquiryDetailsCallForward.constructor();
       
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CounterCode').focus();
            return false;
        });

        $("#CallerJobStatus").change(function () {

            var selectedCallerJobStatus = $(this).val();
            $("#CallStatus option[value='3']").remove();
            $("#CallStatus option[value='2']").remove();
            $("#CallStatus option[value='1']").remove();
            $("#CallStatus option[value='0']").remove();
            $("#DivNextCallDate").hide(true);
            if (selectedCallerJobStatus == "1") {
                $("#DivCallStatus").show(true);
                $("#CallStatus").append($('<option></option>').val("3").html("Failed"));
            }
            else if (selectedCallerJobStatus == "2") {
                $("#DivCallStatus").show(true);
                $("#CallStatus").append($('<option></option>').val("2").html("Callback"));
            }
            else if (selectedCallerJobStatus == "3") {
                $("#DivCallStatus").hide(true);
            }
            else {
                $("#DivCallStatus").hide(true);
            }
            $('#tbodyID').html("");
            $("#DivSubmitRecord").hide(true);

        });
        $("#CallStatus").change(function () {
            $('#tbodyID').html("");
            $("#DivSubmitRecord").hide(true);
        });
        $('#btnShowList').click(function () {
           
            var valuCallerJobStatus = $('#CallerJobStatus :selected').val();
            var ValuCallStatus = $('#CallStatus :selected').val();
            if (valuCallerJobStatus == "" || valuCallerJobStatus == null) {
                notify("Please select call type.", "danger");
                return false;


            }
            else if (ValuCallStatus == "") {
                notify("Please select call type.", "danger");
                return false;
            }
            else {
                $("#DivSubmitRecord").show(true);
                $.ajax(
                   {
                       cache: false,
                       type: "GET",
                       data: { CallerJobStatus: valuCallerJobStatus, CallStatus: ValuCallStatus },
                       dataType: "html",
                       url: '/CRMCallEnquiryDetailsCallForward/List',
                       success: function (result) {
                           $('#ListViewModel').html('');
                           //Rebind Grid Data                
                           $('#ListViewModel').html(result);
                       }
                   });
            }

        });

        // Create new record
        $('#CreateCRMCallEnquiryDetailsCallForwardRecord').on("click", function () {
          
            CRMCallEnquiryDetailsCallForward.ActionName = "Create";
            CRMCallEnquiryDetailsCallForward.GetXmlData();
            if (CRMCallEnquiryDetailsCallForward.ParameterXml == null || CRMCallEnquiryDetailsCallForward.ParameterXml == "") {
                notify("Employee not found.", "warning");
               return false;
            }
            else {
                
                CRMCallEnquiryDetailsCallForward.AjaxCallCRMCallEnquiryDetailsCallForward();
               
            }
        });

        InitAnimatedBorder();
        CloseAlert();
     },

    //LoadList method is used to load List page
    LoadList: function () {
        var CallerJobStatus = $('#CallerJobStatus :selected').val();
        var CallStatus = $('#CallStatus :selected').val();
        $.ajax(

         {
             cache: false,
             type: "POST",
             dataType: "html",
             data: { CallerJobStatus: CallerJobStatus, CallStatus: CallStatus },
             url: '/CRMCallEnquiryDetailsCallForward/Index',
             success: function (data) {
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {       
        var CallerJobStatus = $('#CallerJobStatus :selected').val();
        var CallStatus = $('#CallStatus :selected').val();
        $.ajax(
                 {
                     cache: false,
                     type: "GET",
                     data: { CallerJobStatus: CallerJobStatus, CallStatus: CallStatus, actionMode: actionMode },
                     dataType: "html",
                     url: '/CRMCallEnquiryDetailsCallForward/List',
                     success: function (result) {                        
                         ///$('#ListViewModel').html('');
                         //Rebind Grid Data                
                         
                         $("#ListViewModel").empty().append(result);
                         //twitter type notification
                         notify(message, colorCode);
                     }
                 });
    },
    //Method to create xml
    GetXmlData: function () {
        var DataArray = [];
        var data = $('#myDataTable tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
       //alert(DataArray);
        TotalRecord = DataArray.length;
        ParameterXml = "<rows>";
      
        for (var i = 0; i < TotalRecord; i = i + 8) {
            if (DataArray[i + 2] > parseInt("0") && DataArray[i + 1] != "") {
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><CRMCallMasterID>" + DataArray[i + 3] + "</CRMCallMasterID><JobAllocationID>" + DataArray[i + 4] + "</JobAllocationID><JobCreationMasterID>" + DataArray[i + 5] + "</JobCreationMasterID><CallEnquiryDetailID>" + DataArray[i + 6] + "</CallEnquiryDetailID><AdminRoleMasterID>" + DataArray[i + 7] + "</AdminRoleMasterID><EmployeeID>" + DataArray[i + 2] + "</EmployeeID></row>";
              
            }
        }
        //alert(ParameterXml);
        if (ParameterXml.length > 7)
            CRMCallEnquiryDetailsCallForward.ParameterXml = ParameterXml + "</rows>";

        else
            CRMCallEnquiryDetailsCallForward.ParameterXml = "";

    },

    //Fire ajax call to insert update and delete record
    AjaxCallCRMCallEnquiryDetailsCallForward: function () {
        var CRMCallEnquiryDetailsCallForwardData = null;
        if (CRMCallEnquiryDetailsCallForward.ActionName == "Create") {
            
            //$("#FormCreateCRMCallEnquiryDetailsCallForward").validate();
            //if ($("#FormCreateCRMCallEnquiryDetailsCallForward").valid()) {
            CRMCallEnquiryDetailsCallForwardData = null;
            CRMCallEnquiryDetailsCallForwardData = CRMCallEnquiryDetailsCallForward.GetCRMCallEnquiryDetailsCallForward();           
            ajaxRequest.makeRequest("/CRMCallEnquiryDetailsCallForward/List", "POST", CRMCallEnquiryDetailsCallForwardData, CRMCallEnquiryDetailsCallForward.Success, "CreateCRMCallEnquiryDetailsCallForwardRecord");
        }
        //}

    },

    //Get properties data from the Create, Update and Delete page
    GetCRMCallEnquiryDetailsCallForward: function () {
        var Data = {
        };
        if (CRMCallEnquiryDetailsCallForward.ActionName == "Create") {
            Data.ID = $('#ID').val();
            Data.CallerJobStatus = $('#CallerJobStatus').val();
            Data.CallStatus = $('#CallStatus').val();
            Data.CallMasterID = $('#CallMasterID').val();
            Data.JobAllocationID = $('#JobAllocationID').val();
            Data.EmployeeID = $('#EmployeeID').val();

            Data.XMLstring = CRMCallEnquiryDetailsCallForward.ParameterXml;
           //alert(Data.XMLstring);
        }
        else if (CRMCallEnquiryDetailsCallForward.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {       
        var splitData = data.split(',');
        //alert(splitData)
        if (data != null) {          
            CRMCallEnquiryDetailsCallForward.ReloadList(splitData[0], splitData[1], splitData[2]);
          
        } else {           
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }

    },


};

