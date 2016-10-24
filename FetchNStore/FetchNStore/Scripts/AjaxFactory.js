app.factory("AjaxFactory", function ($q, $http) {

    
    var MakeAjaxGetMethodCall = function (users_input_url) {
        return $q(function (resolve, reject) {
            $http.get(users_input_url)
                .success(function (response) {
                    console.log("response", response);
                    resolve(response);
                })
        .error(function (error) {
            reject(error)
        });
        })
    }

    var MakeAjaxHeadMethodCall = function (users_input_url) {
        return $q(function (resolve, reject) {
            $http.head(users_input_url)
                .success(function (response) {
                    console.log("response", response);
                    resolve(response);
                })
                .error(function (error) {
                    reject(error)
        });
        })
    }



    return {MakeAjaxGetMethodCall:MakeAjaxGetMethodCall, MakeAjaxHeadMethodCall:MakeAjaxHeadMethodCall}
});