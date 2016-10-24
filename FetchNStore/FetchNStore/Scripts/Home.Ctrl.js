app.controller("HomeCtrl", function($scope, AjaxFactory) {

	$scope.value = 6;
	$scope.users_input_url;
	$scope.users_input_method;

	

	$scope.GetAjaxResponseData = function (users_input_url, users_input_method) {
		console.log("url", users_input_url);
		console.log("method", users_input_method);
		
		if (users_input_method == "GET") {

			$scope.statusCode;
			$scope.URL;
			$scope.Method = users_input_method;
			$scope.responseTime;

			AjaxFactory.MakeAjaxGetMethodCall(users_input_url)
		}
		else
		{
			$scope.statusCode;
			$scope.URL;
			$scope.Method = users_input_method;
			$scope.responseTime;

			AjaxFactory.MakeAjaxHeadMethodCall(users_input_url)
		}
	}	
})