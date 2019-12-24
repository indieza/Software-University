function addItem() {
    const text = document.getElementById("newItemText").value;
    const value = document.getElementById("newItemValue").value;
    const menu = document.getElementById("menu");
    const option = document.createElement("option");

    option.value = value;
    option.innerHTML = text;

    menu.appendChild(option);

    document.getElementById("newItemText").value = "";
    document.getElementById("newItemValue").value = "";
}