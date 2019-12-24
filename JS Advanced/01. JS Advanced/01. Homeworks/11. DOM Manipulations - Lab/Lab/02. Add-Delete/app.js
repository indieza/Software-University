function addItem() {
    const items = document.getElementById("items");
    const value = document.getElementById("newText").value;

    let newItem = document.createElement("li");
    newItem.innerHTML = value;

    let deleteLink = document.createElement("a");
    deleteLink.innerHTML = "[Delete]";
    deleteLink.href = "#";

    deleteLink.addEventListener("click", function (e) {
        e.preventDefault();

        this.parentNode.parentNode.removeChild(this.parentNode);
    })

    newItem.appendChild(deleteLink);
    items.appendChild(newItem);

    document.getElementById("newText").value = "";
}