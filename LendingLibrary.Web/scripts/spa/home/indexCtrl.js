(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function indexCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home';
        $scope.loadingTitles = true;

        $scope.selectedTitles = [];
        $scope.loadData = loadData;

        function loadData() {
            apiService.get('api/titles/latest', null,
                titlesLoadCompleted,
                titlesLoadFailed);
        }

        function titlesLoadCompleted(result) {
            $scope.selectedTitles = result.data;
            $scope.loadingTitles = false;
        }

        function titlesLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        loadData();
    }

})(angular.module('lendingLibrary'));
