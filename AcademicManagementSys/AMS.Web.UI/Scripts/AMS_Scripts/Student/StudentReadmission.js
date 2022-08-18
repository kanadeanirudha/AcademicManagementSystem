//this class contain methods related to nationality functionality
//var StudentReadmission  = {
//    //Member variables
//    ActionName: null,
//    rowCount: null,
//    SelectedXmlData: null,
//    //Class intialisation method
//    Initialize: function () {
//        StudentReadmission.constructor();
//        StudentReadmission.rowCount = 0;
//    },
//    //Attach all event of page
//    constructor: function () {



//        $("#SelectedCentreCode").change(function () {
//            var selectedItem = $(this).val();

//            if ($("#SelectedCentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/AuthoriseStudentSectionChangeRequest/GetSessionCentreWise",
//                    data: { "SelectedCentreCode": selectedItem },
//                    success: function (data) {
                        
//                        $("#SessionID").val(data[0].id)
//                        if (data[0].name != null && data[0].name != "") {
//                            $("#sessionName").val(data[0].name);
//                            $("#academicYear").val(data[0].name);
//                        }
//                        else {
//                            $("#sessionName").text("Session not defined !");
//                            $("#sessionName").css('color', 'red')
//                            $("#academicYear").val('');
//                        }
//                    }
//                });
//            }
//        });


//        $("#SelectedCentreCode").on("change", function () {
//            $("#admDetails").hide();
//            $("#StudentName").val('');
//        });

//        $("#IsCurrentYearStudent").on("change", function () {
//            $("#admDetails").hide();
//            $("#StudentName").val('');
//        });


//        $("#admDetails").hide();

//        //FOLLOWING FUNCTION IS SEARCHLIST OF ACCOUNT NAMES
//        $("#StudentName").autocomplete({
            
//            source: function (request, response) {
//                $.ajax({
//                    url: "/StudentReadmission/GetStudentSearchList",
//                    type: "POST",
//                    dataType: "json",
//                    data: { term: request.term, maxResults: 10, centreCode: $("#SelectedCentreCode :selected").val(), studentType: $("#IsCurrentYearStudent").val() },
//                    success: function (data) {
                        
//                        if (data.length > 0) {
//                            response($.map(data, function (item) {

//                                return { label: item.name, value: item.name, id: item.id, centreCode: item.centreCode };
//                            }))
//                        }
//                        else {
//                            $('#SuccessMessage').html("No data available");
//                            $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//                        }
                       
//                    }
//                })
//            },
//            select: function (event, ui) {

//                $(this).val(ui.item.label);                                             // display the selected text
//                var selectedItem = $("#IsCurrentYearStudent").val();
//                $.ajax(
//                {
//                    cache: false,
//                    type: "Get",
//                    data: { ID: ui.item.id, centreCode: ui.item.centreCode, studentType: selectedItem },
//                    dataType: "html",
//                    url: '/StudentReadmission/StudentDetails',
//                    success: function (data) {
//                        //Rebind Grid Data
                  
//                        $('#admDetails').html(data);
//                        $("input[id=AdmissionNumber]").val('');
//                        $("input[id=StudentName]").val(ui.item.label);
//                        $("#admDetails").show();
                      
//                    }
//                });
  
               
//            }
//        });

//        $("#FromSession").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            changeMonth: true,
//            changeYear:true,
//            onSelect: function (selected) {
//                $("#UptoSession").datepicker("option", "minDate", selected)
//            }
//        });
//        $("#UptoSession").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            onSelect: function (selected) {
//                $("#FromSession").datepicker("option", "maxDate", selected)
//            }
//        });
       
//        $("#AdmissionDate").datepicker({
//            dateFormat: 'd M yy',
//            numberOfMonths: 1,
//            changeMonth: true,
//            changeYear: true,
//        });

//        $("#example tbody tr").on("click keydown", "td i.icon-edit", function () {
//            var trLength = $('#example tbody tr').length;
            
//            $('#example tbody tr td input[type=text]').attr('disabled', true);
//            $(this).closest('tr').find('td input[type=text]').attr("disabled", false);
//            $('#example tbody').find('tr').eq(trLength - 2).find('td').eq(4).text('');
//            $('#example tbody').find('tr').eq(trLength - 2).find('td').eq(4).append('<i style="" class="icon-ok"></i>');

//            $("#example tbody tr").on("click keydown", "td i.icon-ok", function () {

//                $('#example tbody tr td input[type=text]').attr('disabled', true);
//                $(this).closest('tr').find('td input[type=text]').attr("disabled", false);
//            });

//        });

//        $('#CreateStudentReadmissionRecord').on("click", function () {
            
//            StudentReadmission.ActionName = "Create";
//            StudentReadmission.AjaxCallStudentReadmission();
//        });

//        $('#EditStudentReadmissionRecord').on("click", function () {
//            var _creditBal = 0, _debitBal = 0;
//            $('#example tbody tr').each(function (i) {
//                var rowCount = $('#example tbody tr').length;
//                if (i < parseInt(rowCount-1)) {
//                    var x;
//                    x = $(this).find('td input[id^=debitBal]').val();
//                    _debitBal += parseFloat(x);
                
//                    var y;
//                    y = $(this).find('td input[id^=creditBal]').val();
//                    _creditBal += parseFloat(y);
//                }
//            });

//            if (_debitBal == _creditBal) {
//                StudentReadmission.ActionName = "Edit";
//                StudentReadmission.getDataFromDataTable();
//                StudentReadmission.AjaxCallStudentReadmission();
//            }
//            else {
//                $('#TransactionMessage').html("Debit balance does not match with the Credit balance");
//                $('#TransactionMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//            }
//        });

//        $('#DeleteStudentReadmissionRecord').on("click", function () {

//            StudentReadmission.ActionName = "Delete";
//            StudentReadmission.AjaxCallStudentReadmission();
//        });

//        $("#UserSearch").on("keyup", function () {
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").on("click", function () {
//            $("#UserSearch").focus();
//        });

//        $("#showrecord").on("change", function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $('#reset').on("click", function () {
//            $("#StudentName").val('');
//            $("#StudentName").focus();
//            $("#admDetails").hide();
//        });

    

//        $('#StudentName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#AdmissionDate').on("keydown", function (e) {
//            var keyCode = (e.keyCode ? e.keyCode : e.which)
//            if (keyCode == 9) {
//                return true;
//            }
//            else {
//                return false;
//            }
            
//        });
//    },

  



//    //LoadList method is used to load List page
//    LoadReAdmissionForm: function () {
//        var Balancesheet = $("#selectedBalsheetID").val();
        
//        $.ajax(
//       {
//           cache: false,
//           type: "POST",
//           data: { "selectedBalsheet": Balancesheet },
//           dataType: "html",
//           url: '/StudentReadmission/List',
//           success: function (data) {
//               //Rebind Grid Data
//               $('#ListViewModel').html(data);
//           }
//       });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
        
//        var Balancesheet = $("#selectedBalsheetID").val();
//        var SelectedTransactionType = $('#SelectedTransactionType :selected').val();
//        var selectedTransactionTypeText = $('#SelectedTransactionType :selected').text();

//        $.ajax(
//        {
//            cache: false,
//            type: "GET",
//            data: { "selectedTransactionCode": SelectedTransactionType, "selectedTransactionTypeText": selectedTransactionTypeText, "selectedBalsheet": Balancesheet, "actionMode": actionMode },
//            dataType: "html",
//            url: '/StudentReadmission/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },
//    //LoadList method is used to load List page
//    LoadListBySelectedTransactionType: function () {
//        var Balancesheet = $("#selectedBalsheetID").val();
//        var SelectedTransactionType = $('#SelectedTransactionType :selected').val();
//        var selectedTransactionTypeText  = $('#SelectedTransactionType :selected').text();
//        $.ajax(
//         {
//             cache: false,
//             type: "GET",
//             dataType: "html",
//             data: { "selectedTransactionCode": SelectedTransactionType, "selectedTransactionTypeText": selectedTransactionTypeText ,"selectedBalsheet": Balancesheet },
//             url: '/StudentReadmission/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //Fire ajax call to insert update and delete record
//    AjaxCallStudentReadmission: function () {
        
//        var StudentReadmissionData = null;
//        if (StudentReadmission.ActionName == "Create") {
//            $("#FormCreateStudentReadmission").validate();
//            if ($("#FormCreateStudentReadmission").valid()) {
//                StudentReadmissionData = null;
//                StudentReadmissionData = StudentReadmission.GetStudentReadmission();
//                ajaxRequest.makeRequest("/StudentReadmission/StudentDetails", "POST", StudentReadmissionData, StudentReadmission.Success);
//            }
//        }
//        else if (StudentReadmission.ActionName == "Edit") {
//            StudentReadmissionData = null;
//            StudentReadmissionData = StudentReadmission.GetStudentReadmission();
//            ajaxRequest.makeRequest("/StudentReadmission/Edit", "POST", StudentReadmissionData, StudentReadmission.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetStudentReadmission: function () {
//        var Data = {
//        };
        
//        if (StudentReadmission.ActionName == "Create" || StudentReadmission.ActionName == "Edit") {
         
//            Data.SessionID = $("#SessionID").val();
//            Data.BranchId = $("#BranchId").val();
//            Data.SectionDetailID = $("#SectionDetailID").val();
//            Data.CourseYearId = $("#CourseYearId").val();
//            Data.StudentId = $("#StudentId").val();
//            Data.SelectedCentreCode = $("#SelectedCentreCode").val();
//            Data.AdmissionDate = $("#AdmissionDate").val();
//            Data.AcademicYear = $("#academicYear").val();
//            Data.IsCurrentYearStudent = $("#IsCurrentYearStudent").val()
//        }
//        return Data;
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//            var splitData = data.split(',');
//            $("#StudentName").val('');
//            $("#StudentName").focus();
//            $("#admDetails").hide();
//            $('#SuccessMessage').html(splitData[0]);
//            $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
//    },

//};


//////////////////new js//////////////////////

//this class contain methods related to nationality functionality
var StudentReadmission = {
    //Member variables
    ActionName: null,
    rowCount: null,
    SelectedXmlData: null,
    map: {},
    map2: {},
    //Class intialisation method
    Initialize: function () {
        StudentReadmission.constructor();
        StudentReadmission.rowCount = 0;
    },
    //Attach all event of page
    constructor: function () {



        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();

            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AuthoriseStudentSectionChangeRequest/GetSessionCentreWise",
                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {

                        $("#SessionID").val(data[0].id)
                        if (data[0].name != null && data[0].name != "") {
                            $("#sessionName").val(data[0].name);
                            $("#academicYear").val(data[0].name);
                        }
                        else {
                            $("#sessionName").text("Session not defined !");
                            $("#sessionName").css('color', 'red')
                            $("#academicYear").val('');
                        }
                    }
                });
            }
        });


        $("#SelectedCentreCode").on("change", function () {
            $("#admDetails").hide();
            $("#StudentName").val('');
        });

        $("#IsCurrentYearStudent").on("change", function () {
            $("#admDetails").hide();
            $("#StudentName").val('');
        });


        $("#admDetails").hide();

        //FOLLOWING FUNCTION IS SEARCHLIST OF ACCOUNT NAMES
        //$("#StudentName").autocomplete({

        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/StudentReadmission/GetStudentSearchList",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, maxResults: 10, centreCode: $("#SelectedCentreCode :selected").val(), studentType: $("#IsCurrentYearStudent").val() },
        //            success: function (data) {

        //                if (data.length > 0) {
        //                    response($.map(data, function (item) {

        //                        return { label: item.name, value: item.name, id: item.id, centreCode: item.centreCode };
        //                    }))
        //                }
        //                else {
        //                    $('#SuccessMessage').html("No data available");
        //                    $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
        //                }

        //            }
        //        })
        //    },
        //    select: function (event, ui) {

        //        $(this).val(ui.item.label);                                             // display the selected text
        //        var selectedItem = $("#IsCurrentYearStudent").val();
        //        $.ajax(
        //        {
        //            cache: false,
        //            type: "Get",
        //            data: { ID: ui.item.id, centreCode: ui.item.centreCode, studentType: selectedItem },
        //            dataType: "html",
        //            url: '/StudentReadmission/StudentDetails',
        //            success: function (data) {
        //                //Rebind Grid Data

        //                $('#admDetails').html(data);
        //                $("input[id=AdmissionNumber]").val('');
        //                $("input[id=StudentName]").val(ui.item.label);
        //                $("#admDetails").show();

        //            }
        //        });


        //    }
        //});


        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuCentreCode = $('#SelectedCentreCode :selected').val();
                var valuStudentType = $('#IsCurrentYearStudent').val();
                $.ajax({
                    url: "/StudentReadmission/GetStudentSearchList",
                    type: "POST",
                    data: { term: q, maxResults: 10, centreCode: valuCentreCode, studentType: valuStudentType },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array

                        //alert(data);
                        
                        

                        $.each(data, function (i, response) {
                            //alert(response.id);
                            if (substrRegex.test(response.name)) {
                                StudentReadmission.map[response.name] = response;
                                matches.push(response.name);
                                
                            } 
                        });

                        //old
                        //if (data.length > 0) {
                        //    response($.map(data, function (item) {

                        //        return { label: item.name, value: item.name, id: item.id, centreCode: item.centreCode };
                        //    }))
                        //}
                        //else {
                        //    //$('#SuccessMessage').html("No data available");
                        //    //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                        //    notify("No data available", "danger");
                        //}
                        //end old


                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#StudentName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {

            //alert(item.id);
            $(this).val(item.label);
            var selectedItem = $("#IsCurrentYearStudent").val();

            $.ajax(
                {
                    cache: false,
                    type: "Get",
                    data: { ID: StudentReadmission.map[item].id, centreCode: StudentReadmission.map[item].centreCode, studentType: selectedItem },
                    dataType: "html",
                    url: '/StudentReadmission/StudentDetails',
                    success: function (data) {
                        //Rebind Grid Data

                        $('#admDetails').html(data);
                        $("input[id=AdmissionNumber]").val('');
                        $("input[id=StudentName]").val(item.label);
                        $("#admDetails").show();

                    }
                });

        });
        //end new search functionality



        //$("#FromSession").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onSelect: function (selected) {
        //        $("#UptoSession").datepicker("option", "minDate", selected)
        //    }
        //});
        //$("#UptoSession").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    onSelect: function (selected) {
        //        $("#FromSession").datepicker("option", "maxDate", selected)
        //    }
        //});

        //$("#AdmissionDate").datepicker({
        //    dateFormat: 'd M yy',
        //    numberOfMonths: 1,
        //    changeMonth: true,
        //    changeYear: true,
        //});

        $('#FromSession').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
        });

        $('#UptoSession').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
        });

        $('#AdmissionDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //maxDate: moment(),
        });


        $("#example tbody tr").on("click keydown", "td i.icon-edit", function () {
            var trLength = $('#example tbody tr').length;

            $('#example tbody tr td input[type=text]').attr('disabled', true);
            $(this).closest('tr').find('td input[type=text]').attr("disabled", false);
            $('#example tbody').find('tr').eq(trLength - 2).find('td').eq(4).text('');
            $('#example tbody').find('tr').eq(trLength - 2).find('td').eq(4).append('<i style="" class="icon-ok"></i>');

            $("#example tbody tr").on("click keydown", "td i.icon-ok", function () {

                $('#example tbody tr td input[type=text]').attr('disabled', true);
                $(this).closest('tr').find('td input[type=text]').attr("disabled", false);
            });

        });

        $('#CreateStudentReadmissionRecord').on("click", function () {

            StudentReadmission.ActionName = "Create";
            StudentReadmission.AjaxCallStudentReadmission();
        });

        $('#EditStudentReadmissionRecord').on("click", function () {
            var _creditBal = 0, _debitBal = 0;
            $('#example tbody tr').each(function (i) {
                var rowCount = $('#example tbody tr').length;
                if (i < parseInt(rowCount - 1)) {
                    var x;
                    x = $(this).find('td input[id^=debitBal]').val();
                    _debitBal += parseFloat(x);

                    var y;
                    y = $(this).find('td input[id^=creditBal]').val();
                    _creditBal += parseFloat(y);
                }
            });

            if (_debitBal == _creditBal) {
                StudentReadmission.ActionName = "Edit";
                StudentReadmission.getDataFromDataTable();
                StudentReadmission.AjaxCallStudentReadmission();
            }
            else {
                //$('#TransactionMessage').html("Debit balance does not match with the Credit balance");
                //$('#TransactionMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                notify("Debit balance does not match with the Credit balance", "danger");
            }
        });

        $('#DeleteStudentReadmissionRecord').on("click", function () {

            StudentReadmission.ActionName = "Delete";
            StudentReadmission.AjaxCallStudentReadmission();
        });

        $("#UserSearch").on("keyup", function () {
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

        InitAnimatedBorder();
        CloseAlert();
        //$(".ajax").colorbox();

        $('#reset').on("click", function () {
            $("#StudentName").val('');
            $("#StudentName").focus();
            $("#admDetails").hide();
        });



        $('#StudentName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#AdmissionDate').on("keydown", function (e) {
            var keyCode = (e.keyCode ? e.keyCode : e.which)
            if (keyCode == 9) {
                return true;
            }
            else {
                return false;
            }

        });
    },





    //LoadList method is used to load List page
    LoadReAdmissionForm: function () {
        var Balancesheet = $("#selectedBalsheetID").val();

        $.ajax(
       {
           cache: false,
           type: "POST",
           data: { "selectedBalsheet": Balancesheet },
           dataType: "html",
           url: '/StudentReadmission/List',
           success: function (data) {
               //Rebind Grid Data
               $('#ListViewModel').html(data);
           }
       });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        var Balancesheet = $("#selectedBalsheetID").val();
        var SelectedTransactionType = $('#SelectedTransactionType :selected').val();
        var selectedTransactionTypeText = $('#SelectedTransactionType :selected').text();

        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { "selectedTransactionCode": SelectedTransactionType, "selectedTransactionTypeText": selectedTransactionTypeText, "selectedBalsheet": Balancesheet, "actionMode": actionMode },
            dataType: "html",
            url: '/StudentReadmission/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },
    //LoadList method is used to load List page
    LoadListBySelectedTransactionType: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        var SelectedTransactionType = $('#SelectedTransactionType :selected').val();
        var selectedTransactionTypeText = $('#SelectedTransactionType :selected').text();
        $.ajax(
         {
             cache: false,
             type: "GET",
             dataType: "html",
             data: { "selectedTransactionCode": SelectedTransactionType, "selectedTransactionTypeText": selectedTransactionTypeText, "selectedBalsheet": Balancesheet },
             url: '/StudentReadmission/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallStudentReadmission: function () {

        var StudentReadmissionData = null;
        if (StudentReadmission.ActionName == "Create") {
            $("#FormCreateStudentReadmission").validate();
            if ($("#FormCreateStudentReadmission").valid()) {
                StudentReadmissionData = null;
                StudentReadmissionData = StudentReadmission.GetStudentReadmission();
                ajaxRequest.makeRequest("/StudentReadmission/StudentDetails", "POST", StudentReadmissionData, StudentReadmission.Success);
            }
        }
        else if (StudentReadmission.ActionName == "Edit") {
            StudentReadmissionData = null;
            StudentReadmissionData = StudentReadmission.GetStudentReadmission();
            ajaxRequest.makeRequest("/StudentReadmission/Edit", "POST", StudentReadmissionData, StudentReadmission.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetStudentReadmission: function () {
        var Data = {
        };

        if (StudentReadmission.ActionName == "Create" || StudentReadmission.ActionName == "Edit") {

            Data.SessionID = $("#SessionID").val();
            Data.BranchId = $("#BranchId").val();
            Data.SectionDetailID = $("#SectionDetailID").val();
            Data.CourseYearId = $("#CourseYearId").val();
            Data.StudentId = $("#StudentId").val();
            Data.SelectedCentreCode = $("#SelectedCentreCode").val();
            Data.AdmissionDate = $("#AdmissionDate").val();
            Data.AcademicYear = $("#academicYear").val();
            Data.IsCurrentYearStudent = $("#IsCurrentYearStudent").val()
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        $("#StudentName").val('');
        $("#StudentName").focus();
        $("#admDetails").hide();
        $('#SuccessMessage').html(splitData[0]);
        $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
    },

};
