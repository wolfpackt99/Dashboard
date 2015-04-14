(function () {
    'use strict';

    var serviceId = 'estimationService';

    // TODO: replace app with your module name
    angular.module('myApp').factory(serviceId, ['$resource', estimationService]);

    function estimationService($resource) {
        // Define the functions and properties to reveal.
        var service = {
            getData: getData
        };

        return service;

        function getData(path) {
            return $resource('/api/service', {}, {
                get: {
                    method: 'GET',
                    isArray: true,
                    params: {path: path}
                }
            });
        }

        //#region Internal Methods        

        //#endregion
    }
})();