(function () {
    'use strict';

    var controllerId = 'homeController';

    // TODO: replace app with your module name
    angular.module('myApp').controller(controllerId,
        ['$scope', 'estimationService', homeController]);

    function homeController($scope, estimationService) {
        $scope.title = 'Remaining Work';
        $scope.stuff = estimationService.getData().get(
            { path: 'r17\\s2' }
        );

        $scope.$watchCollection('stuff', function (newval, oldval, $scope) {
            var comp = calculate($scope);
            $scope['total'] = comp;
        });

        $scope.total = calculate();

        function calculate() {
            var sum = 0;
            $.each($scope.stuff, function (idx, item) {
                sum += item.Hours;
            });
            return sum;
        }

        $scope.doSomething = function () {
            $scope.stuff = estimationService.getData().get(
            {
                path: $scope.path
            });
            $scope.total = calculate();
        }

    }
})();
