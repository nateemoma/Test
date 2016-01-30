(function () {

    'use-strict'

    angular.module('app', ['ngRoute', 'ui.bootstrap', 'toaster'])
    .config(['$routeProvider',
      function ($routeProvider) {
          $routeProvider.
            when('/product', {
                templateUrl: 'app/product/views/product.html',
                controller: 'ProductController as ctrl'
            }).
            otherwise({
                redirectTo: '/product'
            });
      }]);

})();