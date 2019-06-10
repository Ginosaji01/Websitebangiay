angular.module('WebsiteBanGiay')
	.factory('UserService', ['$http', function ($http) {
		var service = {};
		service.GetByUsername = GetByUsername;
		return service;

		function GetByUsername(username) {
			return $http.post('/Users/GetByUsername', { username: username }).then(handleSuccess, handleError('Error getting user by username'));
		}

		function handleSuccess(res) {
			return res.data;
		}

		function handleError(error) {
			return function () {
				return { success: false, message: error };
			};
		}
	}])