function solve() {
    const addButton = document.getElementsByTagName("button")[0];
    const [oldBooks, newBooks] = [document.getElementsByClassName("bookShelf")[0],
        document.getElementsByClassName("bookShelf")[1]
    ];
    const header = document.getElementsByTagName("h1")[1];
    let totalPrice = 0;

    addButton.addEventListener("click", function (e) {
        e.preventDefault();

        const [title, year, price] = [document.getElementsByTagName("input")[0].value,
            Number(document.getElementsByTagName("input")[1].value),
            Number(document.getElementsByTagName("input")[2].value)
        ];

        if (title !== "" && year > 0 && price > 0) {
            if (year > 2000) {
                const div = createBook(title, price, false, year);
                newBooks.appendChild(div);
            } else {
                const div = createBook(title, price, true, year);
                oldBooks.appendChild(div);
            }
        }
    })

    function createBook(title, price, isOld, year) {
        price = isOld ? price * 0.85 : price;

        const div = document.createElement("div");
        div.classList.add("book");

        const p = document.createElement("p");
        p.innerHTML = `${title} [${year}]`;

        const buyButton = document.createElement("button");
        buyButton.innerHTML = `Buy it only for ${price.toFixed(2)} BGN`;

        buyButton.addEventListener("click", function (e) {
            e.preventDefault();

            totalPrice += price;
            header.innerHTML = `Total Store Profit: ${totalPrice.toFixed(2)} BGN`;

            this.parentNode.parentNode.removeChild(this.parentNode);
        });

        div.appendChild(p);
        div.appendChild(buyButton);

        if (!isOld) {
            const moveButton = document.createElement("button");
            moveButton.innerHTML = "Move to old section";

            moveButton.addEventListener("click", function (e) {
                e.preventDefault();

                oldBooks.appendChild(createBook(title, price, true, year));
                this.parentNode.parentNode.removeChild(this.parentNode);
            });

            div.appendChild(moveButton);
        }

        return div;
    }
}