
//app.dataAccess.menuService
app.dataAccess.menuService = (function () {
    //private
    var result;
    var menuCache = new LRUCache(1);
    var loadMenu = function () {
        if (menuCache.get("menu") != -1) {
            var cachedResult = menuCache.get("menu");
            menuComponent(cachedResult, app.dataAccess.subCategory.GetSubCategories);
        }
        app.dataAccess.get({
            url: "Content/menu", onSuccess: function (data) {
                result = JSON.parse(data);
                menuCache.put("menu", result);
                menuComponent(result, app.dataAccess.subCategory.GetSubCategories);
            }, onError: function (status) { console.log("Request Failed" + status) }
        });

    }
    var loadMenuInit = function (cb) {
        app.dataAccess.get({
            url: "Content/menu", onSuccess: function (data) {
                result = JSON.parse(data);
                menuCache.put("menu", result);
                app.Components.menuComponent(result, app.dataAccess.subCategory.GetSubCategories);
                let list = document.getElementById("sidebar-nav");
                list.firstElementChild.classList.add("active");
                cb();
            }, onError: function (status) { console.log("Request Failed" + status) }
        });
    }
    //public
    return {
        GetMenuItems: function () {
            loadMenu();
        },
        GetMenuItemsInit: function () {
            loadMenuInit(app.dataAccess.subCategory.GetSubCategories);//callback yap
        },
    }

})();