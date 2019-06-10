angular.module('WebsiteBanGiay')
	.factory('AuthenticationService', ['$http', '$cookies', '$rootScope', '$timeout', function ($http, $cookies, $rootScope, $timeout) {
		var service = {};

		service.Login = Login;
		service.SetCredentials = SetCredentials;
		service.ClearCredentials = ClearCredentials;

		return service;

		function Login(username, password, callback) {
			$http.post('/Users/Authenticate', { username: username, password: password })
				.then(function (response) {
					console.log(response.data);
					callback(response.data);
				});
		}

		function SetCredentials(username, password) {
			var full = username + ':' + password;
			var authdata = full;
			$rootScope.globals = {
				currentUser: {
					username: username,
					authdata: authdata
				}
			};

			// set default auth header for http requests
			$http.defaults.headers.common['Authorization'] = 'Basic ' + authdata;

			// store user details in globals cookie that keeps user logged in for 1 week (or until they logout)
			var cookieExp = new Date();
			cookieExp.setDate(cookieExp.getDate() + 7);
			$cookies.putObject('globals', $rootScope.globals, { expires: cookieExp });
		}

		function ClearCredentials() {
			$rootScope.globals = {};
			$cookies.remove('globals');
			$http.defaults.headers.common.Authorization = 'Basic';
		}
	}]);