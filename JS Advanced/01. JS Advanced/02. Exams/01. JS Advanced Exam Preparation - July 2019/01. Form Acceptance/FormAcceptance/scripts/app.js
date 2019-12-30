function acceptance() {
    const button = document.getElementById("acceptance");
    const warehouse = document.getElementById("warehouse");

    button.addEventListener("click", function (e) {
        e.preventDefault();

        const company = document.getElementsByTagName("input")[0].value;
        const name = document.getElementsByTagName("input")[1].value;
        const quantity = Number(document.getElementsByTagName("input")[2].value);
        const scrape = Number(document.getElementsByTagName("input")[3].value);

        if (company !== "" && name !== "" && quantity !== NaN && scrape !== NaN && quantity - scrape > 0) {
            const div = document.createElement("div");
            const p = document.createElement("p");
            const removeButton = document.createElement("button");

            p.textContent = `[${company}] ${name} - ${quantity - scrape} pieces`;
            removeButton.textContent = "Out of stock";

            div.appendChild(p);
            div.appendChild(removeButton);
            warehouse.appendChild(div);

            removeButton.addEventListener("click", function (e) {
                e.preventDefault();

                this.parentNode.parentNode.removeChild(this.parentNode);
            })
        }

        document.getElementsByTagName("input")[0].value = "";
        document.getElementsByTagName("input")[1].value = "";
        document.getElementsByTagName("input")[2].value = "";
        document.getElementsByTagName("input")[3].value = "";
    })
}