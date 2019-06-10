angular.module('WebsiteBanGiay')
	.controller('CheckOutController', function ($scope, $window, $http, $state, GetAndSetCusInfo) {
		$scope.firstName = '';
		$scope.lastName = '';
		$scope.address = '';
		$scope.townCity = '';
		$scope.email = '';
		$scope.phone = '';
		$scope.isNull = false;
		$scope.message = '';
		$scope.note = '';
		$scope.getDateTime = new Date();
		
		$scope.checkContent = function () {
			if ($scope.firstName === '' || $scope.firstName === null || typeof $scope.firstName === 'undefined' || $scope.lastName === '' || $scope.lastName === null || typeof $scope.lastName === 'undefined' || $scope.townCity === '' || $scope.townCity === null || typeof $scope.townCity === 'undefined' || $scope.address === '' || $scope.address === null || typeof $scope.address === 'undefined' || $scope.email === '' || $scope.email === null || typeof $scope.email === 'undefined' || $scope.phone === null || $scope.phone === '' || typeof $scope.phone === 'undefined') {
				$scope.isNull = true;
				$scope.message = "Please fill in all the missing infomations, only order notes can be empty";
				$window.scrollTo(0, 0);
			}

			else {
				if (('' + $scope.phone).length !== 9) {
					console.log(('' + $scope.phone).length)
					$scope.isNull = true;
					$scope.message = "Phone number must have 10 number and start with 0";
					$window.scrollTo(0, 0);
				}

				
				if ($scope.carts.length === 0) {
					$scope.isNull = true;
					$scope.message = "Add something to your cart first";
				}

				if (('' + $scope.phone).length === 9 && $scope.carts.length !== 0) 
				{
					$scope.isNull = false;
					$scope.fullAddress = $scope.address + " " + $scope.townCity;
					GetAndSetCusInfo.setCusInfo($scope.firstName);
					GetAndSetCusInfo.setCusInfo($scope.lastName);
					GetAndSetCusInfo.setCusInfo($scope.fullAddress);
					GetAndSetCusInfo.setCusInfo($scope.email);
					GetAndSetCusInfo.setCusInfo($scope.phone);
					
					var customerInfo = { 'id': null, 'fullName': $scope.firstName + ' ' + $scope.lastName, 'address': $scope.address + ' ' + $scope.townCity, 'email': $scope.email, 'phone': $scope.phone, 'note': $scope.note, 'isDelete': false, total: $scope.setTotals() };

					$.ajax({
						dataType: 'json', //dataType: json, doesn't mean that you're posting json, but that you're expecting to receive json data from the server as a result of your request
						type: 'POST',
						url: 'SendOrder/CreateCustomerData',
						data: customerInfo,
						success: function (data) {
							$.ajax({
								dataType: 'text',
								type: 'POST',
								url: 'SendOrder/CreateBillDetail',
								data: { customerCart: $scope.carts, bill_Id: data },
								success: function () {
									console.log("Working");
								},

								failure: function () {
									console.log("Failed");
								}
							})
						},

						failure: function () {
							console.log("Something went wrong!");
						}
					});

					$state.go('orderReceived');
				}
				
			}
		}
	})

	.controller('ReceiveOrderController', function ($scope, GetAndSetCusInfo) {
		$scope.temp = GetAndSetCusInfo.getCusInfo();
		$scope.getDateTime = new Date();
		$scope.firstName = $scope.temp[0];
		$scope.lastName = $scope.temp[1];
		$scope.address = $scope.temp[2];
		$scope.email = $scope.temp[3];
		$scope.phone = $scope.temp[4];
	})