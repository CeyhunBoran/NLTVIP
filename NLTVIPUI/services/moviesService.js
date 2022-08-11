//app.dataAccess.moviesService
app.dataAccess.moviesService = (function () {
    //private
    var result;
    var loadMovies = function () {
        if (document.getElementById("categories").hasChildNodes()) {
            let expression = document.getElementsByClassName("active")[0].textContent;
            let categories = document.getElementsByClassName("category-row");
            for (const element of categories) {
                app.dataAccess.get({
                    url: `Content/movies/${expression + "%2F" +element.firstElementChild.textContent}`, onSuccess: function (data) {
                        result = JSON.parse(data);
                        app.Components.moviesComponent(result, element);
                    }, onError: function () { console.log("Request Failed") }
                });
            }

        };

    }
    //public
    return {
        getMovies: function () {
            loadMovies();
        }
    }
})();