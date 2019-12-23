function solve() {
    const button = document.getElementById("searchBtn");
    const rows = document.querySelectorAll("tbody > tr");

    button.addEventListener("click", function (e) {
        e.preventDefault();

        Array.from(rows).map(e => e.classList = "");

        const input = document.getElementById("searchField").value;

        for (let i = 0; i < rows.length; i++) {
            let row = rows[i];

            let cells = row.querySelectorAll("td");

            for (const cell of cells) {
                let cellValue = cell.innerHTML;

                if (cellValue.toLowerCase().includes(input.toLowerCase())) {
                    row.className = "select";
                }
            }
        }

        document.getElementById("searchField").value = "";
    });
}