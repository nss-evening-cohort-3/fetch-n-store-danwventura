app.controller("HomeCtrl", function($scope, AjaxFactory) {

    $scope.value = 6;
    $scope.users_input_url;
    $scope.users_input_method;

	

    $scope.GetAjaxResponseData = function (users_input_url, users_input_method) {
				
        if (users_input_method == "GET") {

            $scope.URL = `www.${users_input_url}`
            $scope.Method = users_input_method;
			

            AjaxFactory.MakeAjaxGetMethodCall(users_input_url).then(function(requestResponse, calculatedTime) {
            
                $scope.StatusCode = requestResponse.status;
                $scope.ResponseTime = `${requestResponse.calculatedTime} Milliseconds`;
			    
            })

			
            
        }
        else if (users_input_method == "HEAD") {
            $scope.URL = `www.${users_input_url}`
            $scope.Method = users_input_method;


            AjaxFactory.MakeAjaxHeadMethodCall(users_input_url).then(function (requestResponse, calculatedTime) {

                $scope.StatusCode = requestResponse.status;
                $scope.ResponseTime = `${requestResponse.calculatedTime} Milliseconds`;
            })

        }
        else
        {
            return null;
        }
    }
})