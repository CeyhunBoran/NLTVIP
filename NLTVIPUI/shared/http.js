app.dataAccess = (function () {
    //private
    var operation = function(options) {
        var xhttp = new XMLHttpRequest();
        xhttp.onload = function () {
            if(xhttp.readyState == 4) {
                if(xhttp.status == 200) {
                    options.onSuccess(xhttp.responseText);
                }
                else{
                    options.onError(xhttp.responseText);
                }
            }   
        };
        xhttp.onerror = function() {
            options.onError();
        }
        xhttp.open("GET", dict.api+options.url, true);
        xhttp.send();
    }
    //public
    return{
        get : function(options) {
            operation(options);
        },
    
        post : function(options) {
            operation(options);
        },
        //sub namespace
        menuService : (function(){}),
        subCategory : (function(){})
    }
    
})();