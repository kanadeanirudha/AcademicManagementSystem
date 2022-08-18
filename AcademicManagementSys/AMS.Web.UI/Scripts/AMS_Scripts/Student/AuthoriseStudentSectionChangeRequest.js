//this class contain methods related to nationality functionality
var AuthoriseStudentSectionChangeRequest = {
    //Member variables
    ActionName: null,
    map: {},
    map2: {},
    //Class intialisation method
    Initialize: function () {
        AuthoriseStudentSectionChangeRequest.constructor();
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
                        }
                        else {
                            $("#sessionName").text("Session not defined !");
                            $("#sessionName").css('color', 'red')
                        }
                    }
                });
            }
        });


        $("#SelectedCentreCode").on("change", function () {
            $("#admDetails").hide();
            $("#StudentName").val('');
        });


        $("#admDetails").hide();

        //FOLLOWING FUNCTION IS SEARCHLIST OF ACCOUNT NAMES
        //$("#StudentName").autocomplete({
            
        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/AuthoriseStudentSectionChangeRequest/GetStudentSearchList",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, maxResults: 10, centreCode: $("#SelectedCentreCode :selected").val() }, //1 for current year student
        //            success: function (data) {
        //                response($.map(data, function (item) {

        //                    return { label: item.name, value: item.name, id: item.id, centreCode: item.centreCode, courseYearID: item.courseYearID, sectionDetailID: item.sectionDetailID };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {

        //        $(this).val(ui.item.label);                                             // display the selected text

        //        $.ajax(
        //        {
        //            cache: false,
        //            type: "Get",
        //            data: { ID: ui.item.id, centreCode: ui.item.centreCode, courseYearID: ui.item.courseYearID, sectionDetailID: ui.item.sectionDetailID },
        //            dataType: "html",
        //            url: '/AuthoriseStudentSectionChangeRequest/StudentDetails',
        //            success: function (data) {
        //                //Rebind Grid Data
        //                $('#admDetails').html(data);
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
                //var valuStudentType = $('#IsCurrentYearStudent').val();
                $.ajax({
                    url: "/AuthoriseStudentSectionChangeRequest/GetStudentSearchList",
                    type: "POST",
                    data: { term: q, maxResults: 10, centreCode: valuCentreCode },
                    //data: { term: request.term, maxResults: 10, centreCode: $("#SelectedCentreCode :selected").val() },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array

                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.name)) {
                                AuthoriseStudentSectionChangeRequest.map[response.name] = response;
                                matches.push(response.name);
                            }
                        });

                        //old
                        //if (data.length > 0) {
                        //    response($.map(data, function (item) {

                        //        return { label: item.name, value: item.name, id: item.id, centreCode: item.centreCode, courseYearID: item.courseYearID, sectionDetailID: item.sectionDetailID };
                        //    }))
                        //}
                        //else {
                            
                        //    notify("No data available", "danger");
                        //}
                        


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

            $(this).val(item.label);
            var selectedItem = $("#IsCurrentYearStudent").val();

            $.ajax(
                {
                    cache: false,
                    type: "Get",
                    data: { ID: item.id, centreCode: item.centreCode, courseYearID: item.courseYearID, sectionDetailID: item.sectionDetailID },
                    dataType: "html",
                    url: '/AuthoriseStudentSectionChangeRequest/StudentDetails',
                    success: function (data) {
                        //Rebind Grid Data
                        $('#admDetails').html(data);
                        $("#admDetails").show();

                    }
                });

        });
        //end new search functionality



       //$("#AdmissionDate").datepicker({
       //     dateFormat: 'd M yy',
       //     numberOfMonths: 1,
       //     changeMonth: true,
       //     changeYear: true,
       //});

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

        $('#CreateAuthoriseStudentSectionChangeRequestRecord').on("click", function () {
            
            AuthoriseStudentSectionChangeRequest.ActionName = "Create";
            AuthoriseStudentSectionChangeRequest.AjaxCallAuthoriseStudentSectionChangeRequest();
        });

        $('#EditAuthoriseStudentSectionChangeRequestRecord').on("click", function () {
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
                AuthoriseStudentSectionChangeRequest.ActionName = "Edit";
                AuthoriseStudentSectionChangeRequest.getDataFromDataTable();
                AuthoriseStudentSectionChangeRequest.AjaxCallAuthoriseStudentSectionChangeRequest();
            }
            else {
                //$('#TransactionMessage').html("Debit balance does not match with the Credit balance");
                //$('#TransactionMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
                notify("Debit balance does not match with the Credit balance", "danger");
            }
        });

        $('#DeleteAuthoriseStudentSectionChangeRequestRecord').on("click", function () {

            AuthoriseStudentSectionChangeRequest.ActionName = "Delete";
            AuthoriseStudentSectionChangeRequest.AjaxCallAuthoriseStudentSectionChangeRequest();
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

        $('#SelectedTransactionType').on("change", function () {


            AuthoriseStudentSectionChangeRequest.LoadListBySelectedTransactionType();
        });

        $('#StudentName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
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
           url: '/AuthoriseStudentSectionChangeRequest/List',
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
            url: '/AuthoriseStudentSectionChangeRequest/List',
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
             url: '/AuthoriseStudentSectionChangeRequest/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAuthoriseStudentSectionChangeRequest: function () {

        var AuthoriseStudentSectionChangeRequestData = null;
        if (AuthoriseStudentSectionChangeRequest.ActionName == "Create") {
            $("#FormCreateAuthoriseStudentSectionChangeRequest").validate();
            if ($("#FormCreateAuthoriseStudentSectionChangeRequest").valid()) {
                AuthoriseStudentSectionChangeRequestData = null;
                AuthoriseStudentSectionChangeRequestData = AuthoriseStudentSectionChangeRequest.GetAuthoriseStudentSectionChangeRequest();
                ajaxRequest.makeRequest("/AuthoriseStudentSectionChangeRequest/StudentDetails", "POST", AuthoriseStudentSectionChangeRequestData, AuthoriseStudentSectionChangeRequest.Success);
            }
        }
        else if (AuthoriseStudentSectionChangeRequest.ActionName == "Edit") {
            AuthoriseStudentSectionChangeRequestData = null;
            AuthoriseStudentSectionChangeRequestData = AuthoriseStudentSectionChangeRequest.GetAuthoriseStudentSectionChangeRequest();
            ajaxRequest.makeRequest("/AuthoriseStudentSectionChangeRequest/Edit", "POST", AuthoriseStudentSectionChangeRequestData, AuthoriseStudentSectionChangeRequest.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAuthoriseStudentSectionChangeRequest: function () {
        var Data = {
        };

        if (AuthoriseStudentSectionChangeRequest.ActionName == "Create" || AuthoriseStudentSectionChangeRequest.ActionName == "Edit") {
            
            Data.SessionID = $("#SessionID").val();
            Data.StuAdmissionDetailID = $("#StuAdmissionDetailID").val();
            Data.SectionDetailID = $("#SectionDetailID").val();
            Data.StudentId = $("#StudentId").val();
            Data.SelectedCentreCode = $("#SelectedCentreCode").val();
            Data.AcademicYear = $("#AcademicYear").val();
            Data.AdmissionDate = $("#AdmissionDate").val();
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