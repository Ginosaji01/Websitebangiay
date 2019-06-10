/*
angular.module('WebsiteBanGiay')
	.controller('LoginController', function ($scope, loginService, $http, $state, $window) {
		$scope.isLogedIn = false;
		$scope.Submitted = false;
		$scope.Message = '';
		$scope.isFormValid = false;
		
		$scope.loginData = {
			userName: '',
			password: '',
			role: '',
		};

		$scope.$watch('loginForm.$valid', function (newVal) {
			$scope.isFormValid = newVal;
		});

		$scope.Login = function () {
			$scope.Submitted = true;
			if ($scope.isFormValid === true) {
				loginService.GetUser($scope.loginData)
					.then(function (d) {
						if (d.data !== "") {
							$scope.isLogedIn = true;
							$scope.Message = "Welcome " + d.data.role;
							//$state.go('home'); //rediect to manage page
						}

						else {
							alert("User name or password fail");
						}
					});
			}
		};
	})

	.factory('loginService', function($http){
		var fac = {};
		fac.GetUser = function (d) {
			return $http({
				url: '/Login/UserLogin',
				method: 'POST',
				data: JSON.stringify(d),
				headers: { 'context-type': 'application/json' }
			});
		}
		return fac;
	})
*/


angular.module('WebsiteBanGiay')
	.controller('LoginController', ['$location', 'AuthenticationService', 'FlashService', '$state', function ($location, AuthenticationService, FlashService, $state) {
		var vm = this;

		vm.login = login;

		function initController() {
			// reset login status
			AuthenticationService.ClearCredentials();
		};

		function login() {
			vm.dataLoading = true;
			AuthenticationService.Login(vm.username, vm.password, function (response) {
				if (response.success) {
					AuthenticationService.SetCredentials(vm.username, vm.password);
					$state.go('manage');
				} else {
					window.alert("Username or password is incorrect");
					vm.dataLoading = false;
				}
			});
		};
	}])

	.controller('LoggedInController', ['UserService', '$rootScope', function (UserService, $rootScope) {

		var vm = this;

		vm.user = null;

		initController();
		function initController() {
			loadCurrentUser();
		}

		function loadCurrentUser() {
			UserService.GetByUsername($rootScope.globals.currentUser.username)
                .then(function (user) {
                	console.log($rootScope.globals.currentUser.username);
                	console.log(user);
                	vm.user = user;
                });
		}
	}])