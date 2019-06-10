var websiteBanGiay = angular.module('WebsiteBanGiay', ['ui.router', 'ngRoute', 'angularMoment', 'ngCookies']);

	websiteBanGiay.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {
		$urlRouterProvider.otherwise('/product');
		$stateProvider
		.state('home', {
			url: '/product',
			templateUrl: '/Home/RenderProduct',
			controller: 'rootController'
		})

		.state('contact', {
			url: '/contact',
			templateUrl: '/Home/Contact',
			controller: 'rootController'
		})

		.state('login', {
			url: '/login',
			templateUrl: '/Login/Login',
			controller: 'LoginController',
			controllerAs: 'vm'
		})

		.state('manage', {
			url: '/manage',
			templateUrl: '/Login/Manage',
			controller: 'LoggedInController',
			controllerAs: 'vm'
		})

		.state('adminManage', {
			url: '/manage',
			templateUrl: '/Manage/AdminManage',
			controller: 'rootController',
			controllerAs: 'vm'
		})

		.state('userManage', {
			url: '/manage',
			templateUrl: '/Manage/UserManage',
			controller: 'rootController',
			controllerAs: 'vm'
		})

		.state('productDetails', {
	  		url: '/product/:Id',
	  		templateUrl: '/Home/SanPhamDetail',
	  		controller: 'rootController'
		})

		.state('cartDetails', {
		 	url: '/cart',
		  	templateUrl: '/CheckOut/CartDetails',
		  	controller: 'rootController'
		})

		.state('checkOut', {
			url: '/cart/checkOut',
			templateUrl: '/CheckOut/CheckOut',
			controller: 'rootController'
		})

		.state('orderReceived', {
			url: '/cart/checkOut/orderReceived',
			templateUrl: '/CheckOut/OrderReceived',
			controller: 'rootController'
		})
	
		.state('allProductList', {
		 	url: '/allProductList',
		 	templateUrl: '/Home/All_Product_List',
		 	controller: 'AllProductController'
		})

		.state('allProductItem', {
	 		url: '/allProductItem',
	 		templateUrl: '/Home/All_Product_Item',
	 		controller: 'AllProductController'
		})

		.state('adidasProductList', {
			url: '/allAdidasProduct',
			templateUrl: '/Home/All_Adidas_Product_List',
			controller: 'AdidasController'
		})

		.state('adidasProductItem', {
			url: '/allAdidasProduct',
			templateUrl: '/Home/All_Adidas_Product_Item',
			controller: 'AdidasController'
		})

		.state('nikeProductList', {
			url: '/allNikeProduct',
			templateUrl: '/Home/All_Nike_Product_List',
			controller: 'NikeController'
		})

		.state('nikeProductItem', {
			url: '/allNikeProduct',
			templateUrl: '/Home/All_Nike_Product_Item',
			controller: 'NikeController'
		})

		.state('converseProductList', {
			url: '/allConverseProduct',
			templateUrl: '/Home/All_Converse_Product_List',
			controller: 'ConverseController'
		})

		.state('converseProductItem', {
			url: '/allConverseProduct',
			templateUrl: '/Home/All_Converse_Product_Item',
			controller: 'ConverseController'
		})

		.state('pumaProductList', {
			url: '/allPumaProduct',
			templateUrl: '/Home/All_Puma_Product_List',
			controller: 'PumaController'
		})

		.state('pumaProductItem', {
			url: '/allPumaProduct',
			templateUrl: '/Home/All_Puma_Product_Item',
			controller: 'PumaController'
		})
	}])
	

	websiteBanGiay.run(['$rootScope', '$location', '$cookies', '$http', function ($rootScope, $location, $cookies, $http) {
		$rootScope.globals = $cookies.getObject('globals') || {};
		if ($rootScope.globals.currentUser) {
			$http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata;
		}

		$rootScope.$on('$locationChangeStart', function (event, next, current) {
			// redirect to login page if not logged in and trying to access a restricted page
			var restrictedPage = $.inArray($location.path(), ['/manage']) !== -1;
			console.log($location.path());
			var loggedIn = $rootScope.globals.currentUser;
			if (restrictedPage && !loggedIn) {
				console.log('login blocked');
				$location.path('login');
			}
		});
	}])
