angular.module('WebsiteBanGiay')
.service('GetAndSetCusInfo', function () {
	var object = [];
	return {
		getCusInfo: function () {
			return object;
		},

		setCusInfo: function (value) {
			object.push(value);
		}
	}
})

.filter('range', function () {
	return function (input, total) {
		total = parseInt(total);
		for (var i = 0; i < total; i++)
			input.push(i);
		return input;
	};
})

.controller('ProductDetailsController', function ($scope, $http, $sce) {
	$scope.changed = false;
	$scope.imgActive = 1;
	$scope.topImage = function (id, image, active) {
		$scope.id = id;
		$scope.photo = image;
		$scope.changed = true;
		$scope.imgActive = active;
	};
})


.controller('rootController', function ($scope, $window, $http, $stateParams, $location) {
	// ----------get porduct id ---------
	$http.get("/Products/GetAllProduct")
		.then(function (response) {
			$scope.productList = response.data;

			function findProduct(Id) {
				var targetProduct = null;
				$scope.productList.forEach(function (product) {
					if (product.Id === Id) {
						targetProduct = product;
					}
				});
				return targetProduct;
			}

			function allProduct($scope, $stateParams) {
				var product = findProduct(parseInt($stateParams.Id));
				angular.extend($scope, product);
			}

			if ($stateParams.Id) {
				allProduct($scope, $stateParams);
			}

			$scope.redirect = function () {
				window.location.href = '/Home/SanPhamChiTiet';
			}

			$scope.quantity = 1;

			$scope.subQuantity = function () {
				if ($scope.quantity > 1) {
					$scope.quantity = $scope.quantity - 1;
				}
			}

			$scope.plusQuantity = function () {
				$scope.quantity = $scope.quantity + 1;
			}

			$scope.getSize = function (size) {
				$scope.size = size;
			}
		})

	//-----------shoping cart ---------
	$scope.saved = $window.localStorage.getItem('carts');
	$scope.savedLength = $window.localStorage.getItem('length');
	$scope.savedTotal = $window.localStorage.getItem('total');
	$scope.carts = ($window.localStorage.getItem('carts') !== null) ? JSON.parse($scope.saved) : [];
	$scope.total = ($window.localStorage.getItem('total') !== 0) ? $scope.savedTotal : 0;
	$scope.length = ($window.localStorage.getItem('length') !== 0) ? $scope.savedLength : 0;
	$window.localStorage.setItem('carts', JSON.stringify($scope.carts));
	$window.localStorage.setItem('total', $scope.total);
	$window.localStorage.setItem('length', $scope.length);
	$scope.addCart = function (Id, image, id_type, title, price, quantity, size) {
		if (typeof size === 'undefined')
		{
			size = 3;
		}
		$scope.carts = $scope.carts || [];
		$scope.total = $scope.total || 0;
		if ($scope.carts.length === 0) {
			$scope.carts.push({ Id: Id, image: image, id_type: id_type, title: title, price: price, quantity: quantity, size: size });
		}
		else {
			var keepGoing = true;
			for (var i = 0; i < $scope.carts.length; i++) {

				if (keepGoing) {
					if (title === $scope.carts[i].title && size === $scope.carts[i].size) {
						$scope.carts[i].quantity++;
						keepGoing = false;
					}

					else {
						keepGoing = true;
					}
				}
			}

			if (keepGoing === true) {
				$scope.carts.push({ Id: Id, image: image, id_type: id_type, title: title, price: price, quantity: quantity, size: size });
			}

		}

		$scope.length = $scope.carts.length || 0;
		$window.localStorage.setItem('carts', JSON.stringify($scope.carts));
		$window.localStorage.setItem('length', $scope.length);
		$window.localStorage.setItem('total', $scope.total);
		$window.location.reload();
	}

	$scope.cartQuantityInc = function (cart) {
		cart.quantity++;
		$window.localStorage.setItem('total', $scope.total);
		$window.localStorage.setItem('carts', JSON.stringify($scope.carts));
	}

	$scope.cartQuantityDesc = function (cart) {
		if (cart.quantity > 1) {
			cart.quantity--;
			$window.localStorage.setItem('total', $scope.total);
			$window.localStorage.setItem('carts', JSON.stringify($scope.carts));
		}
	}
	
	$scope.setTotals = function () {
		var sum = 0;
		for (var i = 0; i < $scope.carts.length; i++) {
			sum = ($scope.carts[i].price * $scope.cart[i].quantity);
			$scope.total += sum;
		}
		return $scope.total;
		$window.localStorage.setItem('total', $scope.total);
		$window.localStorage.setItem('carts', JSON.stringify($scope.carts));
	};

	$scope.setTotals = function (cart) {
		var priceCount = 0;
		$scope.carts.map((cart) => {
			priceCount += (cart.price * cart.quantity);
		});
		return priceCount;
	}

	$scope.removeCart = function (cart) {
		$scope.carts.splice($scope.carts.indexOf(cart), 1);
		$scope.total -= (cart.price * cart.quantity);
		$scope.length = $scope.carts.length;
		$window.localStorage.setItem('total', $scope.total);
		$window.localStorage.setItem('carts', JSON.stringify($scope.carts));
		$window.localStorage.setItem('length', $scope.length);
		$window.location.reload();
	}
})

.controller('NikeController', function ($scope, $http) {
	$http.get("/Products/GetNikeProduct")
		.then(function (response) {
			$scope.productList = response.data;
			var data = JSON.stringify($scope.productList);
			$scope.length = Object.keys($scope.productList).length;
			var length = $scope.length;
			if (length % 4 > 0)
			{
				$scope.repeatTime = (length / 4) + 1;
			}
			else
			{
				$scope.repeatTime = length / 4;
			}
		})
})

.controller('AdidasController', function ($scope, $http) {
	$http.get('/Products/GetAdidasProduct')
		.then(function (response) {
			$scope.productList = response.data
			var data = JSON.stringify($scope.productList);
			$scope.length = Object.keys($scope.productList).length;
			var length = $scope.length;
			if (length % 4 > 0) {
				$scope.repeatTime = (length / 4) + 1;
			}
			else {
				$scope.repeatTime = length / 4;
			}
		})
})

.controller('PumaController', function ($scope, $http) {
	$http.get('/Products/GetPumaProduct')
		.then(function (response) {
			$scope.productList = response.data
			var data = JSON.stringify($scope.productList);
			$scope.length = Object.keys($scope.productList).length;
			var length = $scope.length;
			if (length % 4 > 0) {
				$scope.repeatTime = (length / 4) + 1;
			}
			else {
				$scope.repeatTime = length / 4;
			}
		})
})

.controller('ConverseController', function ($scope, $http) {
	$http.get('/Products/GetConverseProduct')
		.then(function (response) {
			$scope.productList = response.data
			var data = JSON.stringify($scope.productList);
			$scope.length = Object.keys($scope.productList).length;
			var length = $scope.length;
			if (length % 4 > 0) {
				$scope.repeatTime = (length / 4) + 1;
			}
			else {
				$scope.repeatTime = length / 4;
			}
		})
})

.controller('ProductController', function ($scope, $http) {
	
})

.controller('CategoryController', function ($scope, $http) {
	$http.get('/Type_Product/GetAllTypeProduct')
			.then(function (response) {
				$scope.categoryList = response.data
			})
})

.controller('AllProductController', function ($scope, $http) {
	$scope.i === 0;
	$scope.Sort = function (sortValue) {
		if (sortValue === 'allProduct') {
			$http.get("/Products/GetAllProduct")
				.then(function (response) {
					$scope.productList = response.data;
				})
		}
	}
})


