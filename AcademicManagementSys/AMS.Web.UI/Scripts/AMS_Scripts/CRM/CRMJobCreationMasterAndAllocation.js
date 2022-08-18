//this class contain methods related to nationality functionality
var CRMJobCreationMasterAndAllocation = {
    //Member variables
    ActionName: null,
    map: {},
    SelectedJobAllocationDetailsXMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMJobCreationMasterAndAllocation.constructor();
        //CRMJobCreationMasterAndAllocation.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        //$('#JobStartDate').datetimepicker({
        //    format: 'DD MMMM YYYY',
        //    ignoreReadonly: true,
        //    minDate: moment()
        //});
        $(function () {
            $('#JobStartDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
                minDate: moment()
            });

            $('#JobEndDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
            });

            $("#JobStartDate").on("dp.change", function (e) {
                ////alert('e.date');                
                //$('#JobEndDate').val('');
                var minDate = new Date(e.date.valueOf());
                minDate.setDate(minDate.getDate());
                $('#JobEndDate').data("DateTimePicker").minDate(minDate);
                //$('#JobEndDate').data("DateTimePicker").minDate(e.date);

                $('#CallTypeID').val('');
                $('#JobName').val('');
                $('#PendingCalls').val('');
                $("#tblData tbody").html('');
                $('#divAllocateJob').fadeOut("slow");
                $("#EmployeeName").val("");
                $("#EmployeeID").val("");
               //// $('#EmployeeName').focus();
                $('#PerDayCallTarget').val("");

            });
            $("#JobEndDate").on("dp.change", function (e) {
                //alert('e.date');                
                //$('#JobEndDate').val('');
                var minDate = new Date(e.date.valueOf());
                minDate.setDate(minDate.getDate());
               // $('#JobStartDate').data("DateTimePicker").minDate(minDate);
                //$('#JobEndDate').data("DateTimePicker").minDate(e.date);

            });



        });

        //$(function () {

        //    $('#JobStartDate').datetimepicker({
        //        format: 'DD MMMM YYYY',
        //        ignoreReadonly: true,
        //        minDate: moment()


        //    });
        //});

        //$('#JobEndDate').datetimepicker({
        //    format: 'DD MMMM YYYY',
        //    minDate: moment(),
        //    ignoreReadonly: true,
        //});

        //$("#JobStartDate").datepicker({
        //    changeMonth: true,
        //    changeYear: true,
        //    minDate: '0',
        //    numberOfMonths: 1,
        //    todayHighlight: true,
        //    dateFormat: 'dd M yy',
        //    onSelect: function (selected) {
        //        $("#JobEndDate").datepicker("option", "minDate", selected)
        //        $('#JobEndDate').val('');
        //        $('#CallTypeID').val('');
        //        $('#JobName').val('');
        //        $('#PendingCalls').val('');
        //        $("#tblData tbody").html('');
        //        $('#divAllocateJob').fadeOut("slow");
        //        $("#EmployeeName").val("");
        //        $("#EmployeeID").val("");
        //        $('#EmployeeName').focus();
        //        $('#PerDayCallTarget').val("");
        //    }
        //});
        //$("#JobEndDate").datepicker({
        //    changeMonth: true,
        //    changeYear: true,
        //    minDate: '0',
        //    todayHighlight: true,
        //    numberOfMonths: 1,
        //    dateFormat: 'dd M yy',
        //    onSelect: function (selected) {
        //        $("#JobStartDate").datepicker("option", "maxDate", selected)
        //    }
        //});

        //$("#_JobEndDate").datepicker({
        //    changeMonth: true,
        //    changeYear: true,
        //    minDate: '0',
        //    todayHighlight: true,
        //    numberOfMonths: 1,
        //    dateFormat: 'dd M yy',
        //    onSelect: function (selected) {
        //        //$("#JobStartDate").datepicker("option", "maxDate", selected)
        //    }
        //});
        // Create new record
        $('#CreateCRMJobCreationMasterAndAllocationRecord').on("click", function () {
            
            CRMJobCreationMasterAndAllocation.ActionName = "Create";
            CRMJobCreationMasterAndAllocation.getDataFromDataTable();
            if (CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring != "" && $("#JobName").val() != "") {
               
                CRMJobCreationMasterAndAllocation.AjaxCallCRMJobCreationMasterAndAllocation();
            }
            else if ($("#JobName").val() == "") {
                notify('Please enter job name.', 'danger');
                return false;
            }
            else if (CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring == "") {
                //alert(CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring);
                notify('No employees has been selected.', 'danger');
                return false;
            }

        });

        $('#EditCRMJobCreationMasterAndAllocationRecord').on("click", function () {
            CRMJobCreationMasterAndAllocation.ActionName = "Edit";
            CRMJobCreationMasterAndAllocation.getDataFromDataTable();
            if (CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring != "") {
                CRMJobCreationMasterAndAllocation.AjaxCallCRMJobCreationMasterAndAllocation();
            }
            else if ($('#ExistingJobEndDate').val() != $('#_JobEndDate').val()) {
                CRMJobCreationMasterAndAllocation.AjaxCallCRMJobCreationMasterAndAllocation();
            }
            else {
                notify('No employees has been selected.', 'danger');
                return false;
            }
        });

        $('#DeleteCRMJobCreationMasterAndAllocationRecord').on("click", function () {

            CRMJobCreationMasterAndAllocation.ActionName = "Delete";
            CRMJobCreationMasterAndAllocation.AjaxCallCRMJobCreationMasterAndAllocation();
        });



        $('#CallTypeID').change(function () {
            if ($('#JobStartDate').val() == "") {
                $('#SuccessMessage').html("Please select start date");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                $('#CallTypeID').val('');
            }
            else if ($('#CallTypeID').val() != "") {
                var dt = new Date();
                var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();
                var selectedItem = $("#CallTypeID option:selected").text();
                selectedItem = selectedItem + '-' + $('#JobStartDate').val() + '-' + time;
                $('#JobName').val(selectedItem);
                $('#JobName').focus();


                var selectedCallTypeID = $("#CallTypeID option:selected").val();
                var data = new FormData();
                data.append("selectedCallTypeID", selectedCallTypeID);
                $.ajax({
                    url: "/CRMJobCreationMasterAndAllocation/GetPendingCallEnquiry",
                    type: "POST",
                    processData: false,
                    contentType: false,
                    data: data,               //Q => Question
                    dataType: 'json',
                    success: function (data) {
                        $('#PendingCalls').val(data);
                        if (data > 0) {
                            $('#divAllocateJob').fadeIn("slow");

                        }
                        else {
                            $('#divAllocateJob').fadeOut("slow");
                            $('#EmployeeName').val('');
                            $('#PendingCalls').val('');
                            $('#PerDayCallTarget').val(0);
                            $('#tblData tbody').html('');
                            //$('#SuccessMessage').html("There are no pending call enquires");
                            //$('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                            notify('There are no pending call enquires.', 'danger');
                            return false;

                        }
                    },
                    error: function (er) {
                        // alert(er);
                    }
                });
            }
            else if ($('#CallTypeID').val() == "") {
                $('#divAllocateJob').fadeOut("slow");
                $('#JobName').val('');
                $('#EmployeeName').val('');
                $('#PendingCalls').val('');
                $('#PerDayCallTarget').val(0);
                $('#tblData tbody').html('');
            }
        });


        //$('#JobStartDate').focusout(function () {
        //    if ($('#CallTypeID').val() == "") {

        //    }
        //    else {
        //        var selectedItem = $("#CallTypeID option:selected").text();
        //        selectedItem = selectedItem + '-' + $('#JobStartDate').val();
        //        $('#JobName').val(selectedItem);

        //    }
        //});

        $('#JobName').focusout(function () {
            var selectedjobName = $('#JobName').val();
            var data = new FormData();
            data.append("selectedjobName", selectedjobName);
            $.ajax({
                url: "/CRMJobCreationMasterAndAllocation/CheckForDuplicateJobName",
                type: "POST",
                processData: false,
                contentType: false,
                data: data,               //Q => Question
                dataType: 'json',
                success: function (data) {
                    if (data == 'True') {

                        notify('Job Name Already Exit.', 'danger')
                        return false;
                    }
                },
                error: function (er) {
                    // alert(er);
                }
            });
        });

        $('#IconShowList').click(function () {

            $('#IconShowList').fadeOut();
            $('#IconShowCreateJob').fadeIn();
            $.ajax(
           {
               cache: false,
               type: "Get",
               // data: { "selectedBalsheet": Balancesheet },
               dataType: "html",
               url: '/CRMJobCreationMasterAndAllocation/List',
               success: function (data) {
                   //Rebind Grid Data
                   $('#divContent').empty();
                   $('#divContent').html(data);
                   $('#divContent').fadeIn("slow");
               }
           });
        });







        //// Add new record in table
        //$('#btnAdd').on("click", function () {
        //    debugger;
        //    if ($('#PerDayCallTarget').val() != "" && $('#PerDayCallTarget').val() != 0 && $('#EmployeeID').val() != "") {
        //        if (parseInt($('#PerDayCallTarget').val()) <= parseInt($('#PendingCalls').val())) {
        //            $("#tblData tbody").append(
        //                                    "<tr>" +
        //                                    "<td><input id='roleID' type='text' value=" + $('#AdminRoleMasterID').val() + " style='display:none' /><input id='empID' type='text' value=" + $('#EmployeeID').val() + " style='display:none' /><input id='' type='text' value=" + $('#PerDayCallTarget').val() + " style='display:none' /> " + $('#EmployeeName').val() + "</td>" +
        //                                    "<td>" + $('#PerDayCallTarget').val() + "</td>" +
        //                                    "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer' id='" + $('#PerDayCallTarget').val() + "' title = Delete></td>" +
        //                                    "</tr>"
        //                                    );
        //            var a = parseInt($('#PendingCalls').val()) - parseInt($('#PerDayCallTarget').val());
        //            $('#PendingCalls').val(a);
        //            $("#EmployeeName").val("");
        //            $("#EmployeeID").val("");
        //            $('#PerDayCallTarget').val(0);
        //        }
        //        else {

        //            notify('Per day calls should not be greater than pending calls.', 'danger')
        //            $('#PerDayCallTarget').val('');
        //            $('#PerDayCallTarget').focus();
        //        }
        //    }
        //    else if ($('#EmployeeName').val() == "") {

        //        notify('Please select employee name.', 'danger')
        //    }
        //    else if ($('#PerDayCallTarget').val() == "" || $('#PerDayCallTarget').val() == 0) {

        //        notify('Per day call should be specified.', 'danger')
        //    }
        //});



        $("#JobEndDate_Clear").click(function () {
            $('#JobEndDate').val("");
            $('#_JobEndDate').val("");
            $("#JobStartDate").datepicker("option", "maxDate", null);
        });

        $('#PerDayCallTarget').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#EmployeeName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        //Delete record in table
        $("#tblData tbody").on("click", "tr td i", function () {
            //   var b = parseInt($('#PendingCalls').val()) + parseInt($(this).attr('id'));
            $('#PendingCalls').val(parseInt($('#PendingCalls').val()) + parseInt($(this).attr('id')));
            $(this).closest('tr').remove();
            $('#EmployeeName').val("");
            $('#PerDayCallTarget').val("");
        });
    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/CRMJobCreationMasterAndAllocation/List',
             success: function (data) {
                 //Rebind Grid Data              
                 $('#ListViewModel').html(data);

             }

         });
        //window.location = '/CRMJobCreationMasterAndAllocation';
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

      
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/CRMJobCreationMasterAndAllocation/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification

                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallCRMJobCreationMasterAndAllocation: function () {
        var CRMJobCreationMasterAndAllocationData = null;
        if (CRMJobCreationMasterAndAllocation.ActionName == "Create") {
         
            $("#FormCreateCRMJobCreationMasterAndAllocation").validate();
            if ($("#FormCreateCRMJobCreationMasterAndAllocation").valid()) {
                CRMJobCreationMasterAndAllocationData = null;
                CRMJobCreationMasterAndAllocationData = CRMJobCreationMasterAndAllocation.GetCRMJobCreationMasterAndAllocation();
                $("#ListViewModel").hide();
          
                ajaxRequest.makeRequest("/CRMJobCreationMasterAndAllocation/Create", "POST", CRMJobCreationMasterAndAllocationData, CRMJobCreationMasterAndAllocation.Success, "CreateCRMJobCreationMasterAndAllocationRecord");
            }
        }
        else if (CRMJobCreationMasterAndAllocation.ActionName == "Edit") {
            $("#FormEditCRMJobCreationMasterAndAllocation").validate();
            if ($("#FormEditCRMJobCreationMasterAndAllocation").valid()) {
                CRMJobCreationMasterAndAllocationData = null;
                CRMJobCreationMasterAndAllocationData = CRMJobCreationMasterAndAllocation.GetCRMJobCreationMasterAndAllocation();
                ajaxRequest.makeRequest("/CRMJobCreationMasterAndAllocation/Edit", "POST", CRMJobCreationMasterAndAllocationData, CRMJobCreationMasterAndAllocation.EditSuccess);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMJobCreationMasterAndAllocation: function () {
        var Data = {
        };
        if (CRMJobCreationMasterAndAllocation.ActionName == "Create") {
            Data.JobCreationMasterID = $('input[name=JobCreationMasterID]').val();
            Data.JobStartDate = $('#JobStartDate').val();
            Data.JobEndDate = $('#JobEndDate').val();
            Data.CallTypeID = $('#CallTypeID').val();
            Data.JobName = $("#JobName").val();
            Data.JobAllocationDetailsXMLstring = CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring;
        }
        else if (CRMJobCreationMasterAndAllocation.ActionName == "Edit") {
            Data.JobCreationMasterID = $('input[name=JobCreationMasterID]').val();
            Data.JobStartDate = $('#JobStartDate').val();
            Data.JobCode = $('input[name=JobCode]').val();
            Data.JobStartDate = $('#_JobStartDate').val();
            Data.JobEndDate = $('#_JobEndDate').val();
            Data.JobName = $("#JobName").val();
            Data.CallTypeID = $('#CallTypeID').val();
            Data.JobAllocationDetailsXMLstring = CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring;
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
       
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
         
            CRMJobCreationMasterAndAllocation.ReloadList(splitData[0], splitData[1], splitData[2]);

            $('#JobEndDate').val('');
            $('#CallTypeID').val('');
            $('#JobName').val('');
            $('#PendingCalls').val('');
            $("#tblData tbody").html('');
            $('#divAllocateJob').fadeOut("slow");
        }
            //if (data != null) {
            //    //parent.$.colorbox.close();
            //    //CRMJobCreationMasterAndAllocation.ReloadList(splitData[0], splitData[1], splitData[2]);

            //    //$('#SuccessMessage').html(splitData[0]);
            //    //$('#SuccessMessage').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', splitData[1]);
            //    //// $('#JobStartDate').val('');
            //    //$('#JobEndDate').val('');
            //    //$('#CallTypeID').val('');
            //    //$('#JobName').val('');
            //    //$('#PendingCalls').val('');
            //    //$("#tblData tbody").html('');
            //    //$('#divAllocateJob').fadeOut("slow");

        else {
            $('#JobStartDate').val('');
            $('#JobEndDate').val('');
            $('#CallTypeID').val('');
            $('#JobName').val('');
            $('#PendingCalls').val('');
            $("#tblData tbody").html('');
            $('#divAllocateJob').fadeOut("slow");
        }
    },
    EditSuccess: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            //CRMJobCreationMasterAndAllocation.ReloadList(splitData[0], splitData[1], splitData[2]);
            $('#SuccessMessage').html(splitData[0]);
            $('#SuccessMessage').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', splitData[1]);
        }
        else {
            parent.$.colorbox.close();
            //CRMJobCreationMasterAndAllocation.ReloadList(splitData[0], splitData[1], splitData[2]);
            $('#EditMessage').html(splitData[0]);
            $('#EditMessage').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', splitData[1]);
        }
    },
    getDataFromDataTable: function () {
        var DataArray = [];
        var table = $('#tblData').DataTable();
        var data = table.$('input,select,input tag').each(function () {
            DataArray.push($(this).val());
        });


        var xmlParamList = "<rows>";
        var aa = [];
        var x = 0;
        var Count = DataArray.length / 3;
        for (var i = 0; i < Count; i++) {
            //  aa = DataArray[x + 1].split('~');
            if (DataArray[x] != 0) {
                xmlParamList = xmlParamList + "<row><ID>0</ID><AdminRoleMasterID>" + DataArray[x] + "</AdminRoleMasterID>" + "<EmployeeID>" + DataArray[x + 1] + "</EmployeeID>" + "<PerDayCallTarget>" + DataArray[x + 2] + "</PerDayCallTarget>";
                xmlParamList = xmlParamList + "</row>";
                x = x + 3;
            }
        }
        table.destroy();
        if (xmlParamList.length > 6) {
            CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring = xmlParamList + "</rows>";
            //alert(CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring);

        }
        else {
            //alert(xmlParamList.length);
            CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring = "";
        }
        //alert(CRMJobCreationMasterAndAllocation.SelectedJobAllocationDetailsXMLstring);

    },
};

