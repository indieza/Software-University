function addItem() {
    const items = document.getElementById("items");
    const value = document.getElementById("newItemText").value;

    let newItem = document.createElement("li");
    newItem.innerHTML = value;

    items.appendChild(newItem);

    document.getElementById("newItemText").value = "";
}