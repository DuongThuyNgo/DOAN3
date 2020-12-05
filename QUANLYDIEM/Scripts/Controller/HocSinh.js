var app = angular.module('AppStudentManagement', ['angularUtils.directives.dirPagination']);
app.controller('HocSinhCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {
    // $scope.current_url = "http://localhost:44359";
    $scope.listHocSinh = [];
    $scope.PageIndex = 1;
    $scope.RecordCount = 0;
    $scope.PageSize = '5';
    $scope.Mahocsinh = 0;
    $scope.Malop = 0;
    $scope.Tenhocsinh = "";
    $scope.Ngaysinh = "";
    $scope.Gioitinh = "";
    $scope.Quequan = "";
    $scope.Sodienthoai = "";
    $scope.Socmnd = "";
    $scope.srchQuequan = "";
    $scope.srchTenhocsinh = "";


    //$(window).load(function () {
    //    $('#slPageSize').val("5");
    //});
    // gọi bên cshtml

    //$scope.GetHocSinh = function (index) {
    //    $scope.listHocSinh = [];
    //    $http.get("/Home/GetHocSinhList",
    //        { params: { PageNo: index, PageSize: $scope.PageSize, Tenhocsinh: $scope.Tenhocsinh, Quequan: $scope.srchQuequan } })
    //        //K lỗi
    //        .then(function (response) {
    //            $scope.listHocSinh = response.data.list_HocSinh;
    //            $scope.RecordCount = response.data.TotalRecords;
    //            debugger
    //            console.log($scope.listHocSinh);
    //            console.log($scope.RecordCount);
    //        }).then(function (response) {//lỗi
    //        });
    //};
    $scope.GetHocSinh = function () {
        $scope.listHocSinh = [];
        $http.get("/Home/GetHocSinh")

            .then(function (response) {
                $scope.listHocSinh = response.data.list_HocSinh;

            }).then(function (response) {
            });
    };

    $('body').delegate('.btn-add', 'click', function () {
        $('#btnSubmit').find('span').html("Thêm mới");
        $('#modal-id .modal-title').text("Thêm mới học sinh");
        $scope.ClearBeforeAdd();
    });

    $('body').delegate('#btnSubmit', 'click', function () {
        $scope.AjaxAdd();
    });
    $('body').delegate('.btn-delete', 'click', (function (e) {//element
        e.preventDefault();
        $scope.Mahocsinh = $(this).data('item');
        swal({//đối tượng
            title: 'Xóa bản ghi này ?',
            text: "Thao tác không thể phục hồi bạn có muốn tiếp tục ?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Xóa!',
            cancelButtonText: 'Bỏ qua!'
        }).then(function () {
            if ($scope.Mahocsinh != '') {
                $scope.Delete($scope.Mahocsinh);
            }
        });
        }));
        $('body').delegate('.btn-update', 'click', (function (e) {
            e.preventDefault();
            $scope.Mahocsinh = $(this).data('item');
            if ($scope.Mahocsinh != '') {
                $http({//
                    method: 'POST',//đưa dl lên
                    url: $scope.current_url + '/Home/GetHocSinhbyID',
                    datatype: 'json',
                    data: {
                        Mahocsinh: $scope.Mahocsinh
                    }
                }).then(function (response) {
                    var json = JSON.parse(response.data);
                    $scope.Malop = json.Malop;
                    $scope.Tenhocsinh = json.Tenhocsinh;
                    $scope.Ngaysinh = json.Ngaysinh;
                    $scope.Gioitinh = json.Gioitinh;
                    $scope.Quequan = json.Quequan;
                    $scope.Sodienthoai = json.Sodienthoai;
                    $scope.Socmnd = json.Socmnd;
                });
            }
            $('#btnSubmit').find('span').html("Cập nhật");
            $('#modal-id .modal-title').text("Cập nhật thông tin học sinh");
        }));


        $scope.ClearBeforeAdd = function () {
            $('#txtTenhocsinh').val('');
            $('#txtMalop').val('');
            $('#txtGioitinh').val('');
            $('#txtSodienthoai').val('');
            $('#txtSocmnd').val('');
            $('#Quequan').val('');
        };
        $scope.AjaxAdd = function () {
            var action = $('#btnSubmit').find('span').html();
            if ($scope.Tenhocsinh == null || $scope.Tenhocsinh == '') {
                new PNotify({
                    text: 'Chưa nhập tên học sinh!',
                    addclass: 'bg-success'
                });
                return;
            }
            if ($scope.Malop == null) {
                new PNotify({
                    text: 'Chưa nhập mã lớp!',
                    addclass: 'bg-success'
                });
                return;
            }

            if ($scope.Ngaysinh == null) {
                new PNotify({
                    text: 'Chưa nhập ngày sinh!',
                    addclass: 'bg-success'
                });
                return;
            }

            if ($scope.Quequan == null || $scope.Quequan == '') {
                new PNotify({
                    text: 'Chưa nhập quê quán!',
                    addclass: 'bg-success'
                });
                return;
            }

            if ($scope.Sodienthoai == null || $scope.Sodienthoai == '') {
                new PNotify({
                    text: 'Chưa nhập số điện thoại!',
                    addclass: 'bg-success'
                });
                return;
            }

            if ($scope.Socmnd == null || $scope.Socmnd == '') {
                new PNotify({
                    text: 'Chưa nhập số chứng minh nhân dân!',
                    addclass: 'bg-success'
                });
                return;
            }
            //$scope.HocSinh = {};
            //$scope.HocSinh.Mahocsinh = $scope.Mahocsinh;
            //$scope.HocSinh.Tenhocsinh = $scope.Tenhocsinh;
            //$scope.HocSinh.Malop = $scope.Malop;
            //$scope.HocSinh.Ngaysinh = $scope.Ngaysinh;
            //$scope.HocSinh.Gioitinh = $scope.Gioitinh;
            //$scope.HocSinh.Quequan = $scope.Quequan;
            //$scope.HocSinh.Sodienthoai = $scope.Sodienthoai;
            //$scope.HocSinh.Socmnd = $scope.Socmnd;

            var data = {

               
                "obj.Tenhocsinh ": $scope.Tenhocsinh,
                "obj.Malop": $scope.Malop,
                "obj.Ngaysinh": $scope.Ngaysinh,
                "obj.Gioitinh": $scope.Gioitinh,
                "obj.Quequan": $scope.Quequan,
                "obj.Sodienthoai": $scope.Sodienthoai,
                "obj.Socmnd": $scope.Socmnd
            }

            if (action === "Thêm mới") {
                $http({
                    method: 'POST',
                    url: '/Home/AjaxAddHocSinh',
                    data: data


                }).then(function (response) {
                    if (response.data == -1) {
                        new PNotify({
                            text: 'Có lỗi trong quá trình thêm!',
                            addclass: 'bg-danger'
                        });
                    }
                    else {
                        $scope.ClearBeforeAdd();
                        $scope.GetHocSinh();
                    }
                });
            }

        };
        $scope.Delete = function (Mahocsinh) {
            $http({
                method: 'POST',
                url: $scope.current_url + '/Home/AjaxDeleteHocSinh',
                datatype: 'json',
                data: {
                    Mahocsinh: Mahocsinh
                }
            }).then(function (response) {
                if (response.data == -1) {
                    new PNotify({
                        title: 'Hệ thống có lỗi không thể xóa được',
                        icon: 'icon-checkmark3',
                        addclass: 'bg-success stack-bottom-right',
                        stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                    });
                }
                else {
                    new PNotify({
                        title: 'Đã xóa học sinh khỏi hệ thống',
                        icon: 'icon-checkmark3',
                        addclass: 'bg-success stack-bottom-right',
                        stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                    });
                    $scope.GetHocSinh();

                };
            })

        };

        // $scope.GetHocSinh($scope.PageIndex);
        $scope.GetHocSinh();
    }]).filter("filterdate", function () {
    var re = /\/Date\(([0-9]*)\)\//;
    return function (x) {
        var a = x.match(re);
        if(a)
            return new Date(parseInt(a[1]));
        else
            return null;
    }
});