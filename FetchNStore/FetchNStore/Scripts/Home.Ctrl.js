app.controller("HomeCtrl", function($scope, AjaxFactory) {

    
   
    

    $scope.URL;
    $scope.Method;
    $scope.Status_Code;
    $scope.Response_Time;
    $scope.TimeOfDay;
	

    $scope.GetAjaxResponseData = function (users_input_url, users_input_method) {
				
        

            $scope.URL = `www.${users_input_url}`
            $scope.Method = users_input_method;
            console.log("URL stuff", $scope.users_input_url)

            AjaxFactory.MakeAjaxGetMethodCall(users_input_url).then(function(requestResponse, calculatedTime) {
            
                $scope.Status_Code = requestResponse.status;
                $scope.Response_Time = `${requestResponse.calculatedTime} Milliseconds`;
                var date = new Date();
                $scope.TimeOfDay = new Date();
            })

			
            
       
    }


    $scope.GenerateAndPost = function () {
        console.log("GenerateAndPost");
        var response = {

            Method: $scope.Method,
            URL: $scope.URL,
            Status_Code: $scope.Status_Code,
            Response_Time: $scope.Response_Time,
            TimeOfDay: $scope.TimeOfDay
        }

        AjaxFactory.PostNewResponse(response);


    }
})