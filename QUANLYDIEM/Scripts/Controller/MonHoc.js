var app = angular.module('AppStudentManagement', ['angularUtils.directives.dirPagination']);
app.controller('MonHocCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {
    $scope.current_url = "http://localhost:44359";
    $scope.listMonHoc = [];
    $scope.Mamonhoc = 0;
    $scope.Tenmonhoc = "";
    $scope.Sotiet = 0;
    //gọi bên cshtml
    // $scope.GetHocSinh($scope.PageIndex);
    $scope.GetMonHoc = function () {
        $scope.listMonHoc = [];
        $http.get("/MonHoc/GetMonHocList")
            //K lỗi
            .then(function (response) {
                $scope.listMonHoc = response.data.list_MonHoc;
                debugger
                console.log($scope.listMonHoc);
            }).then(function (response) {//lỗi
            });
    };

    $('body').delegate('.btn-add', 'click', function () {
        $('#btnSubmit').find('span').html("Thêm mới");
        $('#modal-id .modal-title').text("Thêm mới môn học");
        $scope.ClearBeforeAdd();
    });
    $('body').delegate('#btnSubmit', 'click', function () {
        $scope.AjaxAdd();
    });
    $('body').delegate('.btn-delete', 'click', (function (e) {//element
        e.preventDefault();
        $scope.Mamonhoc = $(this).data('item');
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
            if ($scope.Mamonhoc != '') {
                $scope.Delete($scope.Mamonhoc);
            }
        });
    }));

    $('body').delegate('.btn-update', 'click', (function (e) {
        e.preventDefault();
        $scope.Mamonhoc = $(this).data('item');
        if ($scope.Mamonhoc != '') {
            $http({//
                method: 'POST',//đưa dl lên
                url: $scope.current_url + '/MonHoc/GetMonHocbyID',
                datatype: 'json',
                data: {
                    Mamonhoc: $scope.Mamonhoc
                }
            }).then(function (response) {
                var json = JSON.parse(response.data);
                $scope.Mamonhoc = json.Mamonhoc;
                $scope.Tenmonhoc = json.Tenmonhoc;
                $scope.Sotiet = json.Sotiet;

            });
        }
        $('#btnSubmit').find('span').html("Cập nhật");
        $('#modal-id .modal-title').text("Cập nhật thông tin môn học");
    }));


    $scope.ClearBeforeAdd = function () {
        $('#txtTenmonhoc').val('');
        $('#txtSotiet').val('');

    };
    $scope.AjaxAdd = function () {
        var action = $('#btnSubmit').find('span').html();
        if ($scope.Tenmonhoc == null || $scope.Tenmonhoc == '') {
            new PNotify({
                text: 'Chưa nhập tên môn học!',
                addclass: 'bg-success'
            });
            return;
        }

        if ($scope.Sotiet == null || $scope.Sotiet == '') {
            new PNotify({
                text: 'Chưa nhập số tiết!',
                addclass: 'bg-success'
            });
            return;
        }

        $scope.MonHoc = {};
        $scope.MonHoc.Mamonhoc = $scope.Mamonhoc;
        $scope.MonHoc.Tenmonhoc = $scope.Tenmonhoc;
        $scope.MonHoc.Sotiet = $scope.Sotiet;

        if (action === "Thêm mới") {
            $http({
                method: 'POST',
                url: $scope.current_url + '/MonHoc/AjaxAddMonHoc',
                datatype: 'json',
                data: JSON.stringify($scope.MonHoc)
            }).then(function (response) {
                if (response.data == -1) {
                    new PNotify({
                        text: 'Có lỗi trong quá trình thêm!',
                        addclass: 'bg-danger'
                    });
                }
                else {
                    $scope.ClearBeforeAdd();
                    $scope.GetMonHoc();
                }
            });
        }
        else {
            $http({
                method: 'POST',
                url: $scope.current_url + '/MonHoc/AjaxUpdateMonHoc',
                datatype: 'json',
                data: JSON.stringify($scope.MonHoc)
            }).then(function (response) {
                if (response.data == -1) {
                    new PNotify({
                        text: 'Không sửa được thông tin môn học!',
                        addclass: 'bg-danger'
                    });
                }
                else {
                    $('#modal-id').modal('toggle');
                    $scope.GetMonHoc();
                }
            });
        }
    };
    $scope.Delete = function (Mamonhoc) {
        $http({
            method: 'POST',
            url: $scope.current_url + '/MonHoc/AjaxDeleteMonHoc',
            datatype: 'json',
            data: {
                Mamonhoc: Mamonhoc
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
                    title: 'Đã xóa khối học khỏi hệ thống',
                    icon: 'icon-checkmark3',
                    addclass: 'bg-success stack-bottom-right',
                    stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                });
                $scope.GetMonHoc();
            }
        });
    };
    $scope.GetMonHoc();
}]);