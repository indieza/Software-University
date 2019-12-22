function createArticle() {
	const title = document.getElementById("createTitle").value;
	const content = document.getElementById("createContent").value;
	const articles = document.getElementById("articles");

	if (title !== "" && content !== "") {
		let article = document.createElement("article");
		let header = document.createElement("h3");
		let description = document.createElement("p");

		let headerText = document.createTextNode(title);
		header.appendChild(headerText);
		article.appendChild(header);

		let descriptionText = document.createTextNode(content);
		description.appendChild(descriptionText);
		article.appendChild(description);

		articles.appendChild(article);
	}

	document.getElementById("createTitle").value = "";
	document.getElementById("createContent").value = "";
}