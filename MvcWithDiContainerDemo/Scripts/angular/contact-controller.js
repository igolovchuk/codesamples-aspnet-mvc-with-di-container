
angular.module("oursite")
    .constant("baseUrl", "/api/items/")
        .controller("IndexCtrl", function ($scope, $http, baseUrl) {

    $scope.create = function (item) {
        $http.post(baseUrl, item).success(function (item) {
            $('.success').fadeIn(1000).delay(3000).fadeOut(1000);
            //$('#contact')[0].reset();
        });
    }   

    $scope.send = function (item) {
        $scope.msg = {};
        $scope.create(item);       
    }
// not using
    $scope.Validate = function(item) {
        var name = $('#name').val();
        var email = $('#email').val();
        var subject = $('#subject').val();
        var body = $('#text').val();
        if (name === '' || email === '' || subject === '' || body ==='') {
            $('#vallid').click();
        } else {
            $scope.send(item);

        }

    }});