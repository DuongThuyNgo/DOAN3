var app = angular.module('AppStudentManagement', ['angularUtils.directives.dirPagination']);
app.controller('KhoiHocCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {
    $scope.listKhoiHoc = [];
    $scope.Makhoihoc = 0;
    $scope.Tenkhoihoc = "";
    // $scope.GetHocSinh($scope.PageIndex);
    $scope.GetKhoiHoc = function () {
        $scope.listKhoiHoc = [];
        $http.get("/KhoiHoc/GetKhoiHocList")
            //K lỗi
            .then(function (response) {
                $scope.listKhoiHoc = response.data.list_KhoiHoc;
                
            }), function (response) {
                alert("có lỗi")
            };
    };
    //<authentication mode="Forms">
        //<forms loginUrl="~/Login/Login"></forms>  
    //</authentication>
    $('body').delegate('.btn-add', 'click', function () {
        $('#btnSubmit').find('span').html("Thêm mới");
        $('#modal-id .modal-title').text("Thêm mới khối học");
        $scope.ClearBeforeAdd();
    });
    $scope.ClearBeforeAdd = function () {
        $('#txtTenkhoihoc').val('');

    };
    //$('body').delegate('.btn-update', 'click', (function (e,$location) {
    //    e.preventDefault();
    //    var Makhoihoc = $(this).data('item');
    //    //debugger
    //    //console.log($scope.Makhoihoc)
    //            $http({
    //                method: 'POST',
    //                url: '/KhoiHoc/GetKhoiHocbyID?makh=' + Makhoihoc,
    //                datatype: 'json',
    //                data: {
    //                    makh  : Makhoihoc
                       
    //                }
    //            }).then(function (d) {
    //                var json = JSON.parse(d.data);
    //                $scope.TenKhoihoc = json.Tenkhoihoc;

                  
    //            });
    //   
            
            
    //}));


    $('body').delegate('#btnSubmit', 'click', function () {
        $scope.AjaxAdd();
    });
    $scope.AjaxAdd = function () {
        var action = $('#btnSubmit').find('span').html();

        if ($scope.Tenkhoihoc == null || $scope.Tenkhoihoc == '') {
            new PNotify({
                text: 'Chưa nhập tên khối học!',
                addclass: 'bg-success'
            });
            return;
        }
        var data = {
            "obj.Tenkhoihoc": $scope.Tenkhoihoc
        }
        if (action === "Thêm mới") {
            $http({
                method: 'POST',
                url: '/KhoiHoc/AjaxAddKhoiHoc',
                data: data
            }).then(function (response) {
                if (response.data == -1) {
                    new PNotify({
                        text: 'Có lỗi trong quá trình thêm!',
                        addclass: 'bg-danger'
                    });
                }
                else {
                    new PNotify({
                        text: 'Thêm thành công!',
                        addclass: 'bg-success'
                    });
                    $scope.ClearBeforeAdd();
                    $scope.GetKhoiHoc();
                }
            })
           
        }
    };
    

    $scope.Delete = function (item) {
        swal({//đối tượng
            title: 'Xóa bản ghi này ?',
            text: "Thao tác không thể phục hồi bạn có muốn tiếp tục ?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Xóa!',
            cancelButtonText: 'Bỏ qua!'
        });
        $http({
                method: 'POST',
                url: '/KhoiHoc/AjaxDeleteKhoiHoc',
                datatype: 'json',
                data: {
                    makhoihoc: item.Makhoihoc,
                }
            
        }).then(function (e) {
            var vt = $scope.listKhoiHoc.indexOf(item);
            $scope.listKhoiHoc.splice(vt, 1);
       
            if (e.data == -1) {
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
               // $scope.GetKhoiHoc();
          }
        });
       
    }

    $scope.Update = function () {
        
        $('#btnSubmit').find('span').html("Cập nhật");
        $('#modal-id .modal-title').text("Cập nhật khối học");
        var action = $('#btnSubmit').find('span').html();
        if (action === "Cập nhật") {
            $http({
                method: 'POST',
                url: '/KhoiHoc/AjaxUpdateKhoiHoc',
               // datatype: 'json',
                data: {
                    "obj.Tenkhoihoc": $scope.Tenkhoihoc
                }
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.listKhoiHoc;
                    for (var i = 0; i < index.length; i++) {
                        if ($scope.listKhoiHoc[i].Makhoihoc = $scope.Makhoihoc) {
                            $scope.listKhoiHoc[i].Tenkhoihoc = $scope.Tenkhoihoc;
                            break;
                        }
                    }                  
                }
            })//then(function (d) {
            //    if (d.data == 1) {
            //        new PNotify({
            //            text: 'Cập nhật thành công!',
            //            addclass: 'bg-success'
            //        })
            //    }
            //    else {
            //        new PNotify({
            //            text: 'Cập nhật không thành công!',
            //            addclass: 'bg-danger'
            //        })
            //    }
            //})
            $scope.ClearBeforeAdd();
            $scope.GetKhoiHoc();
        }
       
    }
    $scope.GetKhoiHoc();
}]);