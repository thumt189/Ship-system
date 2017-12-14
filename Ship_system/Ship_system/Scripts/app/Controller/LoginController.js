app.controller('loginCtrl', function ($scope, mainService) {
    var url = "/login/login";
    var regiter_url = "/login/regiter";

    $scope.username = "";
    $scope.password = "";
    $scope.regiter_name = "";
    $scope.regiter_pass = "";
    $scope.regiter_email = "";


    $scope.login = function () {
        var request_data = {};
        request_data['username'] = $scope.username;
        request_data['password'] = $scope.password;

        mainService.service(url, request_data).then(function (response) {
            console.log(response);
            if (response.status == true) {
                showNotify("Đăng nhập thành công", "success");
                window.location.href = "/";
            } else {
                return false;
            }
        });
    }

    $scope.regiter = function () {
        var request_data = {};
        request_data['username'] = $scope.regiter_name;
        request_data['password'] = $scope.regiter_pass;
        request_data['email'] = $scope.regiter_email;

        mainService.service(regiter_url, request_data).then(function (response) {

            if (response.status == true) {
                showNotify("Đăng ký thành công", 'success');
            }
            else {
                showNotify("Có lỗi xảy ra: " + response.error_message, "error");
            }
        });

    }
});