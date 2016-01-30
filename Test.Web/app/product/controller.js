(function () {

    'use-strict'

    angular.module('app')
    .controller('ProductController', function ($uibModal, toaster, productServices) {
        
        var vm          = this;
        this.products   = [];

        this.getProducts = function () {
            productServices.GetProducts()
            .success(function (data) {
                vm.products = data;
            })
            .error(function (error, status) {
                console.log('GetProducts\\error: ' + error + '\\status: ' + status)
            });
        };

        this.addNewProduct = function () {
            $uibModal.open({
                templateUrl: 'app/product/views/product-form.html',
                size: 'lg',
                backdrop: 'static',
                controller: function ($scope, $uibModalInstance) {

                    $scope.actionMode   = 'addNew';
                    $scope.product      = {};

                    $scope.ok = function (product) {
                        $uibModalInstance.close(product)
                    };

                    $scope.cancel = function () {
                        $uibModalInstance.dismiss()
                    };
                }
            })
            .result.then(function (product) {
                product.Image = product.Image != null ? product.Image.replace(/^data:image\/(png|jpeg);base64,/g, '') : null;
                productServices.AddNewProduct(product)
                .success(function (data) {
                    console.log(data)
                    toaster.pop("success", 'Add New Product', 'success');
                    vm.getProducts();
                })
                .error(function (error, status) {
                    console.log('AddNewProduct\error: ' + error + '\status: ' + status)
                });
            });
        };

        this.updateProduct = function (product) {
            $uibModal.open({
                templateUrl: 'app/product/views/product-form.html',
                size: 'lg',
                backdrop: 'static',
                controller: function ($scope, $uibModalInstance) {

                    $scope.actionMode   = 'edit';
                    $scope.product      = product;

                    $scope.ok = function (product) {
                        $uibModalInstance.close(product)
                    };

                    $scope.cancel = function () {
                        $uibModalInstance.dismiss()
                    };
                }
            })
            .result.then(function (product) {
                product.Image = product.Image != null ? product.Image.replace(/^data:image\/(png|jpeg);base64,/g, '') : null;
                productServices.UpdateProduct(product)
                .success(function (data) {
                    console.log(data)
                    vm.getProducts();
                    toaster.pop("success", 'Update Product', 'success');
                })
                .error(function (error, status) {
                    console.log('UpdateProduct\error: ' + error + '\status: ' + status)
                });
            });

        };

        this.deleteProduct = function (product) {
            productServices.DeleteProduct(product)
            .success(function (data) {
                console.log(data)
            })
            .error(function (error, status) {
                console.log('DeleteProduct\error: ' + error + '\status: ' + status)
            });
        };
    })
    .directive('appFilereader', function ($q) {
        var slice = Array.prototype.slice;

        return {
            restrict: 'A',
            require: '?ngModel',
            link: function (scope, element, attrs, ngModel) {
                if (!ngModel) return;

                ngModel.$render = function () { };

                element.bind('change', function (e) {
                    var element = e.target;

                    $q.all(slice.call(element.files, 0).map(readFile))
                        .then(function (values) {
                            if (element.multiple) ngModel.$setViewValue(values);
                            else ngModel.$setViewValue(values.length ? values[0] : null);
                        });

                    function readFile(file) {
                        var deferred = $q.defer();

                        var reader = new FileReader();
                        reader.onload = function (e) {
                            deferred.resolve(e.target.result);
                        };
                        reader.onerror = function (e) {
                            deferred.reject(e);
                        };
                        reader.readAsDataURL(file);

                        return deferred.promise;
                    }

                }); //change

            } //link
        }; //return
    });


})()