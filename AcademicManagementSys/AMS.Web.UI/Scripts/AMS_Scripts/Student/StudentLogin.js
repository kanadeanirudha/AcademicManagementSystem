//this class contain methods related to nationality functionality
var StudentLogin = {
    //Member variables
    ActionName: null,
    PromotedStudentList: null,
    AcademicYear: null,
    //Class intialisation method
    Initialize: function () {
        StudentLogin.constructor();
    },
    //Attach all event of page
    constructor: function () {


     
        //$('#btnSubmit').on("click", function () {
        //    StudentLogin.ActionName = "Login";
        //    StudentLogin.AjaxCallStudentLogin();
        //});

        
    },

  
    //Fire ajax call to insert update and delete record
    AjaxCallStudentLogin: function () {
        debugger;
        var StudentLoginData = null;
        if (StudentLogin.ActionName == "Losgin") {
            $("#FormStudentLogin").validate();
            if ($("#FormStudentLogin").valid()) {
                StudentLoginData = null;
                StudentLoginData = StudentLogin.GetStudentLogin();
               // ajaxRequest.makeRequest("/StudentLogin/Login", "POST", StudentLoginData, StudentLogin.Success);
                var form = $('#FormStudentLogin');
                var token = $('input[name="__RequestVerificationToken"]', form).val();
                alert(token);
                $.ajax({
                    contentType: "application/json; charset=utf-8",
                    url: "/StudentLogin/Login",
                    type: 'POST',
                    data: {
                        __RequestVerificationToken: token,
                        data: StudentLoginData
                    },
                    success: function (result) {
                       // alert(result.someValue);
                    }
                });
            }
        }
        else if (StudentLogin.ActionName == "PromotOtherThanFirstYearStudent") {
            $("#FormStudentLogin").validate();
            if ($("#FormStudentLogin").valid()) {
                StudentLoginData = null;
                StudentLoginData = StudentLogin.GetStudentLogin();
                ajaxRequest.makeRequest("/StudentLogin/List", "POST", StudentLoginData, StudentLogin.Success);
            }
        }
    },



    //Get properties data from the Create, Update and Delete page
    GetStudentLogin: function () {
        var Data = {
        };

        if (StudentLogin.ActionName == "Login") {
            Data.EmailID = $("#EmailID").val();
            Data.Password = $("#Password").val();

        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var selectedItem = $('input[name=IsFirstYearPromotion]:checked').val() ? true : false;
        if (selectedItem == true) {
            ReloadListFirstYearStudent();
            $("input[class=selectedAllCheck]").attr("checked", false);
        }
        else if (selectedItem == false) {
            ReloadListOtherThanFistYear();
        }
        var splitData = data.split(',');

        $('#SuccessMessage').html(splitData[0]);
        $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
    },

};









