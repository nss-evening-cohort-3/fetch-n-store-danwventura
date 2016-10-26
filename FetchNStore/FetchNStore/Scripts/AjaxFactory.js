app.factory("AjaxFactory", function ($q, $http) {
    
    var time1 = Date.now();
    
    var MakeAjaxGetMethodCall = function (users_input_url) {
        
        return $q(function (resolve, reject) {
            $http({
                method: 'GET',
                url: `https://${users_input_url}`
            }).then(function (response) {

                var time2 = Date.now();

                
                response.calculatedTime = time2 - time1;
                var requestResponse = response;                              
                
                
                resolve(requestResponse);
            })
        })
    }

    var MakeAjaxHeadMethodCall = function (users_input_url) {

        return $q(function (resolve, reject) {
            $http({
                method: 'HEAD',
                url: `https://${users_input_url}`
            }).then(function (response) {

                var time2 = Date.now();


                response.calculatedTime = time2 - time1;
                var requestResponse = response;


                resolve(requestResponse);
        });
        })
    }



    return {MakeAjaxGetMethodCall:MakeAjaxGetMethodCall, MakeAjaxHeadMethodCall:MakeAjaxHeadMethodCall}
});