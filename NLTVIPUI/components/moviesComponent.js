app.Components.moviesComponent = function(data, parent) {
    this.data = data;
    this.parent = parent;

    data.forEach(element => {
        var card = document.createElement("div");
        card.classList.add("card");
        var poster = document.createElement("img");
        var cardTitle = document.createElement("span");
        cardTitle.classList.add("card-title");
        poster.classList.add("card-poster");
        poster.setAttribute("src", element.poster);
        card.appendChild(poster);
        cardTitle.appendChild(document.createTextNode(element.title));
        card.appendChild(cardTitle);
        parent.appendChild(card);
        //modal
        var modal = document.getElementById("previewModal");
        card.addEventListener("click", ev => {
            modal.innerHTML = "";
            modal.style.display = "block";
            //overlay
            var modalOverlay = document.createElement("div");
            modalOverlay.classList.add("previewModal-overlay");
            //poster
            var modalPoster = document.createElement("a");
            modalPoster.classList.add("previewModal-poster")
            modalPoster.appendChild(document.createElement("img"));
            modalPoster.firstElementChild.setAttribute("src", element.poster);
            console.log(element);
            //header
            var modalHeader = document.createElement("div");
            modalHeader.classList.add("previewModal-header");
            modalHeader.innerHTML = `
                    <div class="header-details">

                        <div class="title">${element.title}</div>

                        <span class="rating">${element.imDbRating}</span>

                        <span class="director">Director: ${element.director}</span>

                    </div>
                `;
            //content
            var modalContent = document.createElement("div");
            modalContent.classList.add("previewModal-content");
            modalContent.innerHTML = `
      
            <div class="column1">
              <span class="tag">Genres: ${element.genre}</span>
            </div> <!-- end column1 -->
            
            <div class="column2">
              
              <p>${element.description}</p>
              
              
            </div> <!-- end column2 -->
                `;
            modalOverlay.append(modalPoster, modalHeader, modalContent);
            modal.appendChild(modalOverlay);
        })
        modal.addEventListener("click" , ev =>{
            if (ev.target == modal) {
                modal.innerHTML = "";
                modal.style.display = "none";
            }
        })
    });

}