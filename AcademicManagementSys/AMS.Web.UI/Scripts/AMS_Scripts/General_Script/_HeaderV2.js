//this class contain methods related to nationality functionality
var _HeaderV2 = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    initialize: function () {
        //organisationStudyCentre.loadData();

        _HeaderV2.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        //$('#ModuleList').on("change", function () {
        //    
        //    alert("done");
        //    var ModuleID = $(this).val();
        //    var ModuleName = $(this).text;
        //    _HeaderV2.LoadMenuListByModuleID(ModuleID);
        //    $('#btnCreate').show();
        //});


        //$('ul#ModuleList li').click(function (e) {
        //    //alert($(this).find("span.t").text());
        //    alert("hi");
        //});

        //$("#ModuleList li").on("click", function () {
        //    alert("hi");
        //});

        $('#ddlRoles').on("change", function () {
            var AdminRoleMasterID = $(this).val();
            var RoleName = $(this).text;
            _HeaderV2.LoadModule(AdminRoleMasterID);
        });

    },

    LoadRole: function (AdminRoleMasterID) {

        $.ajax(
         {
             cache: false,
             type: "GET",
             data: {},

             dataType: "html",
             url: '_Header/_Header',
             success: function (result) {
                 //Rebind List Data                
                 $('#selectRole').html(result);
             }
         });
    },

    //Reload module list according to RoleID in Role List
    LoadModule: function (AdminRoleMasterID) {

        $.ajax(
         {
             cache: false,
             type: "GET",
             data: { AdminRoleMasterID: AdminRoleMasterID },

             dataType: "html",
             url: '_Header/_ModuleListV2',
             success: function (result) {
                 //Rebind List Data                
                 $('#ddlModule').html(result);
             }
         });
    },

    //ReloadList method is used to load List page
    LoadMenuListByModuleID: function (ModuleID, ModuleName) {
        //  var selectedText = $('#SelectedDepartmentIDforRoleMaster').text();
        // var selectedVal = $('#SelectedDepartmentIDforRoleMaster').val();

        $.ajax(
          {
              cache: false,
              type: "GET",
              data: { ModuleID: ModuleID, ModuleName: ModuleName },

              dataType: "html",
              url: '_Header/_MenuListV2',
              success: function (result) {
                  //Rebind Grid Data   

                  $('#moduleName').html('<i class="nav-icon list"></i>' + ModuleName);
             

                  $('#sidebar').html(result);
                  //$(".side-nav li ul").css("display", "initial");
                  $(".collapse").collapse()
                  _HeaderV2.LoadBalsheetByRoleID(ModuleName);
              }
          });
    },

    //ReloadList method is used to load List page
    LoadMenuListByModuleCode: function (ModuleCode, ModuleName) {
   
        //  var selectedText = $('#SelectedDepartmentIDforRoleMaster').text();
        // var selectedVal = $('#SelectedDepartmentIDforRoleMaster').val();
       
        $.ajax(
          {
              cache: false,
              type: "GET",
              data: { ModuleCode: ModuleCode, ModuleName: ModuleName },

              dataType: "html",
              url: '_Header/_MenuListV2',
              success: function (result) {
                  //Rebind Grid Data   
             
                  $('#moduleName').html('<i class="nav-icon list"></i>' + ModuleName);


                  $('#sidebar').html(result);
                  //$(".side-nav li ul").css("display", "initial");
                  $(".collapse").collapse()
                  _HeaderV2.LoadBalsheetByRoleID(ModuleName);
                  _HeaderV2.LoadDashboard();
                  //$.post('/Home/List/', function (result) {
                  //    $("#main-content").empty().append(result);
                  //});


              }
          });
    },



    LoadMenuWithActiveTab: function (path) {

        //  var selectedText = $('#SelectedDepartmentIDforRoleMaster').text();
        var selectedText = $('#ddlModule :selected').text();
        var selectedVal = $('input[id=DefaultModuleID]').val();

        $.ajax(
          {
              cache: false,
              type: "GET",
              data: { ModuleID: selectedVal, path: path },

              dataType: "html",
              url: 'Base/BuildMenu',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#_Sidebar').html(result);

              }
          });
    },

    //ReloadList method is used to load Balancesheet List
    LoadBalsheetByRoleID: function (ModuleName) {
   

        $.ajax(
          {
              cache: false,
              type: "GET",
              data: { ModuleName: ModuleName },

              dataType: "html",
              url: '_Header/_BalancesheetListV2',
              success: function (result) {
                  //Rebind List Data    
                  $('#ddlMfdsodule').html('');
                  $('#ddlMfdsodule').html(result);

              }
          });
    },

    LoadDashboard: function () {
        //   alert("hi");
        $.ajax(
         {
             cache: false,
             type: "GET",
             data: null,
             dataType: "html",
             url: '/Home/ListV2',
             success: function (result) {
                 //Rebind List Data                
                 $("#main-content").empty().append(result);

             }
         });

    },


    //ReloadList method is used to load List page in new theme
    LoadMenuListByModuleCodeV2: function (ModuleCode, ModuleName) {
       // alert(ModuleCode + "=> modulecode   ||  " + ModuleName + "=> moduleName")
        //  var selectedText = $('#SelectedDepartmentIDforRoleMaster').text();
        // var selectedVal = $('#SelectedDepartmentIDforRoleMaster').val();
        //$('.mCustomScrollbar').mCustomScrollbar("destroy")
        $.ajax(
          {
              cache: false,
              type: "GET",
              data: { ModuleCode: ModuleCode, ModuleName: ModuleName },

              dataType: "html",
              url: '_Header/_MenuListV2',
              success: function (result) {
                  //Rebind Grid Data   
             
                  $('#moduleName').html('<i class="nav-icon list"></i>' + ModuleName);


                  $('#mCSB_1_container').html(result);
                  //$(".side-nav li ul").css("display", "initial");
                  $(".collapse").collapse()
                  _HeaderV2.LoadBalsheetByRoleIDV2(ModuleName);
                  _HeaderV2.LoadDashboard();
                  //$.post('/Home/List/', function (result) {
                  //    $("#main-content").empty().append(result);
                  //});

                  //$(".mCustomScrollbar").mCustomScrollbar();
              }
          });
    },

    //ReloadList method is used to load Balancesheet List in new theme
    LoadBalsheetByRoleIDV2: function (ModuleName) {
   

        $.ajax(
          {
              cache: false,
              type: "GET",
              data: { ModuleName: ModuleName },

              dataType: "html",
              url: '_Header/_BalancesheetListV2',
              success: function (result) {
                  //Rebind List Data    
                  $('#ddlMfdsodule').html('');
                  $('#ddlMfdsodule').html(result);

              }
          });
    },
};

