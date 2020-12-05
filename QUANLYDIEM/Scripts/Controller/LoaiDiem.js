var app = angular.module('AppStudentManagement', ['angularUtils.directives.dirPagination']);
app.controller('LoaiDiemCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {
    $scope.current_url = "http://localhost:44359";
    $scope.listLoaiDiem = [];
    $scope.Maloaidiem = 0;
    $scope.Tenloaidiem = "";
    $scope.Heso = 0;
    //gọi bên cshtml
    // $scope.GetHocSinh($scope.PageIndex);
    $scope.GetLoaiDiem = function () {
        $scope.listLoaiDiem = [];
        $http.get("/LoaiDiem/GetLoaiDiemList")
            //K lỗi
            .then(function (response) {
                $scope.listLoaiDiem = response.data.list_LoaiDiem;
               
            }).then(function (response) {//lỗi
            });
    };

    $('body').delegate('.btn-add', 'click', function () {
        $('#btnSubmit').find('span').html("Thêm mới");
        $('#modal-id .modal-title').text("Thêm mới loại điểm");
        $scope.ClearBeforeAdd();
    });
    $('body').delegate('#btnSubmit', 'click', function () {
        $scope.AjaxAdd();
    });
    $('body').delegate('.btn-delete', 'click', (function (e) {//element
        e.preventDefault();
        $scope.Maloaidiem = $(this).data('item');
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
            if ($scope.Maloaidiem != '') {
                $scope.Delete($scope.Maloaidiem);
            }
        });
    }));

    $('body').delegate('.btn-update', 'click', (function (e) {
        e.preventDefault();
        $scope.Maloaidiem = $(this).data('item');
        if ($scope.Maloaidiem != '') {
            $http({//
                method: 'POST',//đưa dl lên
                url: $scope.current_url + '/LoaiDiem/GetLoaiDiembyID',
                datatype: 'json',
                data: {
                    Maloaidiem: $scope.Maloaidiem
                }
            }).then(function (response) {
                var json = JSON.parse(response.data);
               
                $scope.Tenloaidiem = json.Tenloaidiem;
                $scope.Heso = json.Heso;

            });
        }
        $('#btnSubmit').find('span').html("Cập nhật");
        $('#modal-id .modal-title').text("Cập nhật thông tin loại điểm");
    }));


    $scope.ClearBeforeAdd = function () {
        $('#txtTenloaidiem').val('');
        $('#txtHeso').val('');

    };
    $scope.AjaxAdd = function () {
        var action = $('#btnSubmit').find('span').html();
        if ($scope.Tenloaidiem == null || $scope.Tenloaidiem == '') {
            new PNotify({
                text: 'Chưa nhập tên loại điểm!',
                addclass: 'bg-success'
            });
            return;
        }

        if ($scope.Heso == null || $scope.Heso == '') {
            new PNotify({
                text: 'Chưa nhập hệ số!',
                addclass: 'bg-success'
            });
            return;
        }

        var data = {
            "obj.tenloaidiem": $scope.Tenloaidiem,
            "obj.heso": $scope.Heso,
        }

        if (action === "Thêm mới") {
            $http({
                method: 'POST',
                url: $scope.current_url + '/LoaiDiem/AjaxAddLoaiDiem',
                //datatype: 'json',
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
                    $scope.GetMonHoc();
                }
            });
        }
        else {
            $http({
                method: 'POST',
                url: $scope.current_url + '/LoaiDiem/AjaxUpdateLoaiDiem',
                datatype: 'json',
                data: JSON.stringify($scope.LoaiDiem)
            }).then(function (response) {
                if (response.data == -1) {
                    new PNotify({
                        text: 'Không sửa được thông tin loại điểm!',
                        addclass: 'bg-danger'
                    });
                }
                else {
                    $('#modal-id').modal('toggle');
                    $scope.GetLoaiDiem();
                }
            });
        }
    };
    $scope.Delete = function (Maloaidiem) {
        $http({
            method: 'POST',
            url: $scope.current_url + '/LoaiDiem/AjaxDeleteLoaiDiem',
            datatype: 'json',
            data: {
                Maloaidiem: Maloaidiem
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
                    title: 'Đã xóa loại điểm khỏi hệ thống',
                    icon: 'icon-checkmark3',
                    addclass: 'bg-success stack-bottom-right',
                    stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                });
                $scope.GetLoaiDiem();
            }
        });
    };
    $scope.GetLoaiDiem();
}]);