function solve() {

    let totalMoney = 0;
    let shoppingCart = [];
    let endShopping = false;

    const output = document.querySelector("body > div > textarea");

    Object.values(document.getElementsByTagName('button')).map(b => b.addEventListener('click', function (t) {
        let clickedButton = t.target.className;
        if (clickedButton === 'add-product' && !endShopping) {
            addItem(t);
        } else if (clickedButton === 'checkout' && !endShopping) {
            checkout();
        }
    }));

    function addItem(t) {
        let items = listOfItems();
        let item = t.target.parentNode.parentNode.children[1].children[0].textContent;
        let info = `Added ${item} for ${items[item].toFixed(2)} to the cart.`;

        myCart(items, item);
        printResult(info);
    }

    function myCart(items, item) {
        totalMoney += items[item];

        if (!shoppingCart.includes(item)) {
            shoppingCart.push(item);
        }
    }

    function checkout() {
        let info = `You bought ${shoppingCart.join(', ')} for ${totalMoney.toFixed(2)}.`;
        endShopping = true;
        printResult(info);
    }

    function printResult(info) {
        output.textContent += `${info}\n`;
    }

    function listOfItems() {
        let products = {
            'Bread': 0.80,
            'Milk': 1.09,
            'Tomatoes': 0.99
        }
        return products;
    }
}