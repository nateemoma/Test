(function () {

    'use-strict'

    angular.module('app')
    .factory('productServices', function ($http) {

        var serviceUrl = 'http://localhost:1625/api/Products';
        this.services = {};

        this.services.GetProducts = function () {
            return $http.get(serviceUrl + '/GetProducts')
        };

        this.services.AddNewProduct = function (product) {
            return $http.post(serviceUrl + '/InsertProduct', product);
        };

        this.services.UpdateProduct = function (product) {
            return $http.post(serviceUrl + '/UpdateProduct', product);
        };

        this.services.DeleteProduct = function (product) {
            return $http.post(serviceUrl + '/DeleteProduct', product);
        };

        return this.services;

    });

})()