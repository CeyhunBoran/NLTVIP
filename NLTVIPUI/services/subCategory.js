//app.dataAccess.subCategory
app.dataAccess.subCategory = (function () {
    //private
    var result;
    var subCategoryCache = new LRUCache(5);
    var loadSub = function () {
        if (document.getElementsByClassName("sidebar-nav")[0].hasChildNodes()) {
            let expression = document.getElementsByClassName("active")[0].textContent;
            if (subCategoryCache.get(expression) != -1) {
                var cachedResult = subCategoryCache.get(expression);
                app.Components.subCategoryComponent(cachedResult, app.dataAccess.moviesService.GetMovies);
            }
            else {
                app.dataAccess.get({
                    url: `Content/categories/bymenu/${expression}`, onSuccess: function (data) {
                        result = JSON.parse(data);
                        subCategoryCache.put(expression, result);
                        app.Components.subCategoryComponent(result, app.dataAccess.moviesService.GetMovies);
                    }, onError: function () { console.log("Request Failed") }
                });
            }
        }
    }
    //public
    return {
        GetSubCategories: function () {
            loadSub();
        }
    }

})();