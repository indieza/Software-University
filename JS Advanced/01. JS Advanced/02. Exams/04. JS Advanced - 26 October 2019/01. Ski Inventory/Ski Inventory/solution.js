function solve() {
    let totalPrice = 0;

    const html = {
        availableProductsList: () => document.querySelector("#products > ul"),
        myProductsList: () => document.querySelector("#myProducts > ul"),
        addButton: () => document.querySelector('#add-new button'),
        filterButton: () => document.querySelector("#products > div > button"),
        buyButton: () => document.querySelector("#myProducts > button"),
        productFilterInput: () => document.getElementsByTagName("input")[0],
        productNameInput: () => document.querySelectorAll("#add-new input")[0],
        productQuantityInput: () => document.querySelectorAll("#add-new input")[1],
        productPriceInput: () => document.querySelectorAll("#add-new input")[2],
        totalPriceField: () => document.querySelectorAll("h1")[1]
    };

    html.addButton().addEventListener("click", addProductToList);
    html.buyButton().addEventListener("click", buyProducts);
    html.filterButton().addEventListener("click", filterProducts);

    function addProductToList(e) {
        e.preventDefault();

        const name = html.productNameInput().value;
        const quantity = Number(html.productQuantityInput().value);
        const price = Number(html.productPriceInput().value);

        const liElement = createDomElement("li", null, null, null);
        const nameSpan = createDomElement("span", name, null, null);
        const quantityStrong = createDomElement("strong", `Available: ${quantity}`, null, null);
        const infoDiv = createDomElement("div", null, null, null);
        const priceStrong = createDomElement("strong", price.toFixed(2), null, null);
        const addButton = createDomElement("button", "Add to Client's List");
        addButton.addEventListener("click", addProductToBuy);

        infoDiv.appendChild(priceStrong);
        infoDiv.appendChild(addButton);
        liElement.appendChild(nameSpan);
        liElement.appendChild(quantityStrong);
        liElement.appendChild(infoDiv);
        html.availableProductsList().appendChild(liElement);

        html.productNameInput().value = "";
        html.productQuantityInput().value = "";
        html.productPriceInput().value = "";
    }

    function addProductToBuy(e) {
        e.preventDefault();
        const availableQuantity = parseInt(this.parentNode.parentNode.children[1].innerHTML.split(" ")[1]);

        if (availableQuantity === 1) {
            this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
            createBuyProduct(this);
        } else {
            this.parentNode.parentNode.children[1].innerHTML = `Available: ${availableQuantity - 1}`;
            createBuyProduct(this);
        }
    }

    function createBuyProduct(button) {
        const infoLi = createDomElement("li", button.parentNode.parentNode.children[0].innerHTML, null, null);
        const priceStrong = createDomElement("strong", Number(button.parentNode.children[0].innerHTML).toFixed(2), null, null);
        totalPrice += Number(priceStrong.innerHTML);
        html.totalPriceField().innerHTML = `Total Price: ${totalPrice.toFixed(2)}`;
        infoLi.appendChild(priceStrong);
        html.myProductsList().appendChild(infoLi);
    }

    function buyProducts(e) {
        e.preventDefault();

        totalPrice = 0;
        html.totalPriceField().innerHTML = `Total Price: ${totalPrice.toFixed(2)}`;
        html.myProductsList().innerHTML = "";
    }

    function filterProducts(e) {
        e.preventDefault();
        const filterValue = html.productFilterInput().value;
        const allAvailableProducts = document.querySelectorAll("#products ul li span");

		for (var i = 0; i < allAvailableProducts.length; i++) {
			const product = allAvailableProducts[i];
			if (!product.innerHTML.toUpperCase().includes(filterValue.toUpperCase())) {
						product.parentNode.style.display = "none";
					} else {
						product.parentNode.style.display = "block";
					}
		}

        html.productFilterInput().value = "";
    }

    /**
     * @param {string} type Type of the DOM element
     * @param {string} text Text of the DOM element
     * @param {Array} classes Array of all DOM classes
     * @param {Number} id Od of the DOM element
     */
    function createDomElement(type, text, classes, id) {
        let element = document.createElement(type);

        if (text) {
            element.innerHTML = text;
        }

        if (classes) {
            element.classList.add(...classes);
        }

        if (id) {
            element.id = id;
        }

        return element;
    }
}