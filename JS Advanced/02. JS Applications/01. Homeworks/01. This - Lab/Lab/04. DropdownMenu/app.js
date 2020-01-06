function solve() {
    const dropDownMenu = document.getElementById("dropdown-ul");

    const button = document.getElementById("dropdown");
    const elements = document.querySelectorAll("#dropdown-ul > li");
    const box = document.getElementById("box");

    button.addEventListener("click", function (e) {
        e.preventDefault();

        if (dropDownMenu.style.display === "none" || dropDownMenu.style.display === "") {
            dropDownMenu.style.display = "block";

            for (const element of elements) {
                element.addEventListener("click", function (e) {
                    e.preventDefault();
                    const text = element.innerHTML;
                    box.style.backgroundColor = text;
                    box.style.color = "black";
                });
            }
        } else {
            dropDownMenu.style.display = "none";
            box.style.backgroundColor = "black";
            box.style.color = "white";
        }
    });
}