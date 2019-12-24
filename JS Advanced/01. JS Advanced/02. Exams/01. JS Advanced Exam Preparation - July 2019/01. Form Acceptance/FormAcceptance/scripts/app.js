function acceptance() {
	let divCount = 1;

	const button = document.getElementById("acceptance");
	const warehouse = document.getElementById("warehouse");
	button.addEventListener("click", function (e) {
		e.preventDefault();

		const company = document.getElementsByName("shippingCompany")[0].value;
		const product = document.getElementsByName("productName")[0].value;
		const quantity = document.getElementsByName("productQuantity")[0].value;
		const scrape = document.getElementsByName("productScrape")[0].value;

		if (company !== "" && product !== "" && !isNaN(quantity) && !isNaN(scrape)) {
			let productQuantity = Number(quantity);
			let productScrape = Number(scrape);

			if (productQuantity - productScrape > 0) {
				let outOfStockButton = document.createElement("button");
				let buttonNode = document.createTextNode("Out of stock");
				outOfStockButton.appendChild(buttonNode);

				let div = document.createElement("div");
				div.id = `${divCount++}`;

				let createParagraph = document.createElement("p");
				let paragraphNode = document
					.createTextNode(`[${company}] ${product} - ${productQuantity - productScrape} pieces`);
				createParagraph.appendChild(paragraphNode);

				warehouse.appendChild(div);
				div.appendChild(createParagraph)
				div.appendChild(outOfStockButton);

				outOfStockButton.addEventListener("click", function (b) {
					b.preventDefault();
					warehouse.removeChild(document.getElementById(div.id));
				})
			}
		}

		document.getElementsByName("shippingCompany")[0].value = "";
		document.getElementsByName("productName")[0].value = "";
		document.getElementsByName("productQuantity")[0].value = "";
		document.getElementsByName("productScrape")[0].value = "";
	})
}