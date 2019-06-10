angular.module('WebsiteBanGiay')
	.controller('ProfitCalController', function ($scope, $timeout) {
		$scope.billList = [];
		$scope.profit = 0;
		$scope.monthlyProfitShow = false;
		$scope.yearlyProfitShow = false;
		$scope.isCaution = false;
		$scope.message = '';
		$scope.isInputValid = true;
		$scope.MonthlyProfit = function (month) {
			console.log(month);
			if (month <= 0 || month >= 12) {
				$scope.isInputValid = false;
				$scope.isCaution = true;
				$scope.message = 'Month must between 1 and 12';
			}

			else {
				$scope.isInputValid = true;
				$scope.isCaution = false;
				$.ajax({
					dataType: 'json',
					url: '/Profit/GetBillByMonth',
					method: "POST",
					data: { month: month },
					success: function (data) {
						$scope.monthlyProfitShow = true;
						$scope.yearlyProfitShow = false;
						$scope.billList = data;
						$.ajax({
							dataType: 'text',
							url: '/Profit/MonthlyProfitCalculate',
							method: 'POST',
							data: { month: month },
							success: function (result) {
								$timeout(function () {
									$scope.profit = result;
								})
							},

							failure: function () {
								console.log("Error");
							}
						})
					},

					failure: function () {
						console.log("Failed");
					}
				});
			}
		}

		$scope.AnnualProfit = function (year) {
			if (year <= 1900 || year >= 3000) {
				$scope.isInputValid = false;
				$scope.isCaution = true;
				$scope.message = 'Year must between 1900 and 3000';
			}
			
			else {
				$scope.isInputValid = true;
				$scope.isCaution = false;
				$.ajax({
					dataType: 'json',
					url: '/Profit/GetBillByYear',
					method: 'POST',
					data: { year: year },
					success: function (data) {
						$scope.monthlyProfitShow = false;
						$scope.yearlyProfitShow = true;
						$scope.billList = data;
						$.ajax({
							dataType: 'text',
							url: '/Profit/YearlyProfitCalculate',
							method: 'POST',
							data: { year: year },
							success: function (result) {
								$timeout(function () {
									$scope.profit = result;
								})
							},

							failure: function () {
								console.log("Error");
							}
						})
					},

					failure: function () {
						console.log("Failed");
					}
				})
			}
		}
	})


			
