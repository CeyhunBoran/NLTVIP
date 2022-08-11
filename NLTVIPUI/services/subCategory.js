//app.dataAccess.subCategory
app.dataAccess.subCategory = (function () {
    //private
    var result;
    var loadSub = function() {
        if(document.getElementsByClassName("sidebar-nav")[0].hasChildNodes()){
            let expression = document.getElementsByClassName("active")[0].textContent;
            app.dataAccess.get({url:`Content/categories/bymenu/${expression}`, onSuccess: function(data){
                result = JSON.parse(data);
                app.Components.subCategoryComponent(result, app.dataAccess.moviesService.getMovies);
            }, onError: function(){console.log("Request Failed")} });
            
        }
    }
    //public
    return{
        getSubCategories : function() {
            loadSub();
        }  
    }
    
})();