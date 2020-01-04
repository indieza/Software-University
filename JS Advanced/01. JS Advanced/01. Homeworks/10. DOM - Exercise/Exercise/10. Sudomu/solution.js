function solve() {
    const cells = document.querySelectorAll("td > input");
    const checkButton = document.getElementsByTagName("button")[0];
    const clearButton = document.getElementsByTagName("button")[1];
    const table = document.getElementsByTagName("table")[0];
    const message = document.getElementById("check");

    clearButton.addEventListener("click", function (e) {
        e.preventDefault();

        for (const item of cells) {
            item.value = "";
        }

        message.children[0].innerHTML = "";
        message.children[0].style.color = "";
        table.style.border = "";
    })

    checkButton.addEventListener("click", function (e) {
        e.preventDefault();

        let field = Array(Math.sqrt(cells.length))
            .fill()
            .map(() =>
                new Array(Math.sqrt(cells.length))
                .fill());

        let isValid = true;

        for (let row = 0; row < Math.sqrt(cells.length); row++) {
            for (let col = 0; col < Math.sqrt(cells.length); col++) {
                field[row][col] = Number(cells[row * Math.sqrt(cells.length) + col].value);
            }

            isValid = hasDuplicates(field[row]);

            if (!isValid) {
                break;
            }
        }

        for (let col = 0; col < Math.sqrt(cells.length); col++) {

            isValid = hasDuplicates(field.map(x => x[col]));

            if (!isValid) {
                break;
            }
        }

        if (isValid) {
            message.children[0].innerHTML = "You solve it! Congratulations!";
            message.children[0].style.color = "green";
            table.style.border = "2px solid green";
        } else {
            message.children[0].innerHTML = "NOP! You are not done yet...";
            message.children[0].style.color = "red";
            table.style.border = "2px solid red";
        }
    });

    function hasDuplicates(array) {
        return (new Set(array)).size === array.length;
    }
}