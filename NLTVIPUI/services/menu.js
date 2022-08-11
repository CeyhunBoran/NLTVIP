//app.dataAccess.menuService
app.dataAccess.menuService = (function () {
    //private
    var result;
    var loadMenu = function () {
        app.dataAccess.get({
            url: "Content/menu", onSuccess: function (data) {
                result = JSON.parse(data);
                menuComponent(result, app.dataAccess.subCategory.getSubCategories);
            }, onError: function (status) { console.log("Request Failed" + status) }
        });
    }
    var loadMenuInit = function (cb) {
        app.dataAccess.get({
            url: "Content/menu", onSuccess: function (data) {
                result = JSON.parse(data);
                app.Components.menuComponent(result, app.dataAccess.subCategory.getSubCategories);
                let list = document.getElementById("sidebar-nav");
                list.firstElementChild.classList.add("active");
                cb();
            }, onError: function (status) { console.log("Request Failed" + status) }
        });
    }
    //public
    return {
        getMenuItems: function () {
            loadMenu();
        },
        getMenuItemsInit: function () {
            loadMenuInit(app.dataAccess.subCategory.getSubCategories);//callback yap
        },
    }

})();