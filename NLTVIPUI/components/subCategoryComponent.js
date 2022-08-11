app.Components.subCategoryComponent = function(data, callback) {
    this.data = data
    let parent = document.getElementById("categories");
    while (parent.hasChildNodes()) {
        parent.removeChild(parent.firstChild);
    }

    data.forEach(element => {
        var node = document.createElement('div');
        node.classList.add("category-row");
        var rowHeader = document.createElement('h2');
        rowHeader.classList.add("category-row-header");
        rowHeader.appendChild(document.createTextNode(element));
        node.appendChild(rowHeader);
        parent.appendChild(node);
    });
    callback();
};