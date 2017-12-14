var app = angular.module('app', []);

app.factory('mainService', function ($http) {
    var factory = {};

    factory.service = function (url, data) {
        return $http.post(url, data)
            .then(function (response) {
                 return response.data;
            });
    };

    return factory;
});

function showNotify(text, type) {
    new PNotify({
        title: 'Thông báo',
        text: text,
        type: type
    });
};  