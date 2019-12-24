function solve() {
    const addButtons = Array.from(document.querySelectorAll("button")).filter(b => b.innerText === "Add");
    const checkoutButton = Array.from(document.querySelectorAll("button")).filter(b => b.innerText === "Checkout")[0];
    const box = document.querySelector("textarea");

    let boughtProducts = new Map();

    for (const addButton of addButtons) {
        addButton.addEventListener("click", function (e) {
            e.preventDefault();

            const productName =
                addButton.parentElement.parentElement.getElementsByClassName("product-title")[0].innerHTML;
            const productPrice =
                Number(addButton.parentElement.parentElement.getElementsByClassName("product-line-price")[0].innerHTML);

            box.innerHTML += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;

            if (!boughtProducts.get(productName)) {
                boughtProducts.set(productName, 0);
            }

            boughtProducts.set(productName, boughtProducts.get(productName) + productPrice);
        })
    }

    checkoutButton.addEventListener("click", function (e) {
        e.preventDefault();

        box.innerHTML +=
            `You bought ${[...boughtProducts]
                .map(x => x[0]).join(", ")} for ${[...boughtProducts]
                .reduce((a, b) => a + Number(b[1]), 0)
                .toFixed(2)}.`;

        checkoutButton.disabled = true;
        addButtons.forEach(b => {
            b.disabled = true;
        });
    })
}