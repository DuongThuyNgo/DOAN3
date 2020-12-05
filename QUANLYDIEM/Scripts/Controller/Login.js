var app = angular.module('AppDiemHocSinh', ['angularUtils.directives.dirPagination']);
app.controller("LoginCtrl", function ($rootScope, $window, $http) {
    $rootScope.Users = null;
    $rootScope.us = "";
    $rootScope.pw = "";
    $rootScope.quyenBGH = "";
    $rootScope.quyenGV = "";
    $rootScope.quyenHS = "";
    $rootScope.Login = function (us, pw) {
        
        
        $http({
            method: 'Post',
            params: { us: us, pw: pw },
            url: '/Login/Login'
        }).then(function (d) {
            console.log(d);
            if (d.data == null) {
                $rootScope.us = "";
                $rootScope.pw = "";
                alert("Tài khoản không đúng");
            }
            else {
                $rootScope.Users = d.data;
                debugger
                Console.log($rootScope.Users);
                if (d.data.TenRole == "BanGiamHieu") {
                    $rootScope.quyenBGH = "";
                    $rootScope.quyenGV = "KhongQuyen";
                    $rootScope.quyenHS = "KhongQuyen";
                }
                else if (d.data.TenRole == "GiaoVien") {
                    $rootScope.quyenBGH = "KhongQuyen";
                    $rootScope.quyenGV = "";
                    $rootScope.quyenHS = "KhongQuyen";
                }
                else {
                    $rootScope.quyenBGH = "KhongQuyen";
                    $rootScope.quyenGV = "KhongQuyen";
                    $rootScope.quyenHS = "";
                }
                $window.location.href = '/Home/Index';
            }
        }),function (e) { };
    };


    $rootScope.Logout = function () {
        $http({
            method: 'Post',
           
            url: '/Login/Login'
        }).then(function (e) { });
    }
})
