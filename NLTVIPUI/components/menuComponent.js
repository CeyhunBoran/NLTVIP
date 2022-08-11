app.Components.menuComponent = function(data, getSubCategories) {
    this.data = data;
    let list = document.getElementById("sidebar-nav");

    // As long as <ul> has a child node, remove it
    while (list.hasChildNodes()) {
        list.removeChild(list.firstChild);
    }
    data.forEach((element, index) => {
        var node = document.createElement('li');
        node.appendChild(document.createTextNode(element));
        node.classList.add("menu-item");
        node.classList.add("menu-item-" + index);
        list.appendChild(node);

    });
    list.addEventListener("click", ev => {
        if (ev.target.classList.contains("active") || !ev.target.classList.contains("menu-item")) {

        }
        else {
            let prevActive = document.getElementsByClassName("active");
            if(prevActive.length != 0) {prevActive[0].classList.remove("active")};
            ev.target.classList.add("active");
            getSubCategories();
        }

    })

};
