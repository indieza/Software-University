function solve() {
    const button = document.querySelector("button");
    const list = document.querySelectorAll("li");

    button.addEventListener("click", function (e) {
        e.preventDefault();

        let value = document.querySelector("input").value;
        let firstLetter = value[0].toUpperCase();
        let index = Number(firstLetter.charCodeAt()) - 65;
        let oldValue = list[index].innerHTML;

        let name = firstLetter + value.substring(1).toLocaleLowerCase()

        if (oldValue === "") {
            list[index].innerHTML = name;
        } else {
            list[index].innerHTML += `, ${name}`;
        }
    })
}