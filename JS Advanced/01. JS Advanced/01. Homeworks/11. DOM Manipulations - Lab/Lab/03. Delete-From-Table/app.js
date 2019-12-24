function deleteByEmail() {
    const cells = document.querySelectorAll("td");
    const targetEmail = document.getElementsByName("email")[0].value;
    const result = document.getElementById("result");

    let isFound = false;

    for (const cell of cells) {
        if (cell.innerHTML === targetEmail) {
            cell.parentNode.parentNode.removeChild(cell.parentNode);
            isFound = true;
        }
    }

    result.innerHTML = isFound === false ? "Not found." : "Deleted."
    document.getElementsByName("email")[0].value = "";
}