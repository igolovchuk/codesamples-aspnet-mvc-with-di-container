angular.module("oursite")
    .constant("baseUrl", "/api/items/")
        .controller("MessCtrl", function ($scope, $http, baseUrl) {
            
            $scope.refresh = function () {
                    // HTTP GET
                    $http.get(baseUrl).success(function (data) {
                        $scope.items = data;
                    });                  
            }
           

            $scope.delete = function (item) {
                // HTTP DELETE
                $http({
                    method: "DELETE",
                    url: baseUrl + item.messageId
                }).success(function () {
                    $scope.items.splice($scope.items.indexOf(item), 1);
                });
            }           

            $scope.refresh();


        });