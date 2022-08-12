//app.dataAccess.moviesService
app.dataAccess.moviesService = (function () {
    //private
    var result;
    var moviesCache = new LRUCache(20);
    var loadMovies = function () {
        if (document.getElementById("categories").hasChildNodes()) {
            var active = document.getElementsByClassName("active")[0].textContent;
            var categories = document.getElementsByClassName("category-row");
            for (const element of categories) {
                var expression = active + "%2F" + element.firstElementChild.textContent;
                if (moviesCache.get(expression) != -1) {
                    var cachedResult = moviesCache.get(expression);
                    app.Components.moviesComponent(cachedResult, element);
                }
                else {
                    app.dataAccess.get({
                        url: `Content/movies/${expression}`, onSuccess: function (data) {
                            result = JSON.parse(data);
                            moviesCache.put(expression, result);
                            app.Components.moviesComponent(result, element);
                        }, onError: function () { console.log("Request Failed") }
                    });
                }
            }
        };
    }
    //public
    return {
        GetMovies: function () {
            loadMovies();
        }
    }
})();