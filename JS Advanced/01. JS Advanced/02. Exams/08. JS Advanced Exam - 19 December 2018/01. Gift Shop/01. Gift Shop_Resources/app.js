function solution() {
	const addButton = document.getElementsByTagName("button")[0];
	const section = document.getElementById("christmasGiftShop");

	addButton.addEventListener("click", function (e) {
		e.preventDefault();

		const type = document.getElementById("toyType").value;
		const price = document.getElementById("toyPrice").value;
		const description = document.getElementById("toyDescription").value;

		if (type !== "" && !isNaN(parseInt(price)) && description !== "" && description.length >= 50) {
			const div = document.createElement("div");
			const img = document.createElement("img");
			const h2 = document.createElement("h2");
			const p = document.createElement("p");
			const buyButton = document.createElement("button");

			buyButton.addEventListener("click", function (e) {
				e.preventDefault();

				this.parentNode.parentNode.removeChild(this.parentNode);
			});

			div.classList.add("gift");
			img.src = "gift.png";
			h2.innerHTML = type;
			p.innerHTML = description;
			buyButton.innerHTML = `Buy it for $${price}`;

			div.appendChild(img);
			div.appendChild(h2);
			div.appendChild(p);
			div.appendChild(buyButton);
			section.appendChild(div);
		}
	});
}