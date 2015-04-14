(function () {
    'use strict';

    var id = 'myApp';

    // TODO: Inject modules as needed.
    var app1 = angular.module(id, [
        // Angular modules 
        //'ngAnimate',        // animations
        'ngRoute',        // routing
        'ngResource'
        // Custom modules 

        // 3rd Party Modules
        
    ]);

    // Execute bootstrapping code and any dependencies.
    // TODO: inject services as needed.
    app1.run(['$q', '$rootScope',
        function ($q, $rootScope) {

        }]);
})();