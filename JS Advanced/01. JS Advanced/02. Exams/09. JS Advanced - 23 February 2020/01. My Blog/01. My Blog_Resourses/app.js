function solve() {
    const html = {
        authorInput: () => document.getElementById("creator"),
        titleInput: () => document.getElementById("title"),
        categoryInput: () => document.getElementById("category"),
        contentInput: () => document.getElementById("content"),
        createButton: () => document.querySelector("aside section form button"),
        articlesSection: () => document.querySelector("main section"),
        archiveSection: () => document.querySelector(".archive-section")
    }

    html.createButton().addEventListener("click", addPost);

    function addPost(e) {
        e.preventDefault();
        const author = html.authorInput().value;
        const title = html.titleInput().value;
        const category = html.categoryInput().value;
        const content = html.contentInput().value;

        const article = createDomElement("article", null, null, null);
        const h1 = createDomElement("h1", title, null, null);
        const pCategory = createDomElement("p", "Category:", null, null);
        const strongCategory = createDomElement("strong", category, null, null);
        const pAuthor = createDomElement("p", "Creator:", null, null);
        const strongAuthor = createDomElement("strong", author, null, null);
        const pContent = createDomElement("p", content, null, null);
        const divActions = createDomElement("div", null, ["buttons"], null);
        const deleteButton = createDomElement("button", "Delete", ["btn", "delete"], null);
        const archiveButton = createDomElement("button", "Archive", ["btn", "archive"], null);
        archiveButton.addEventListener("click", archivePost);
        deleteButton.addEventListener("click", deletePost);

        divActions.appendChild(deleteButton);
        divActions.appendChild(archiveButton);
        pCategory.appendChild(strongCategory);
        pAuthor.appendChild(strongAuthor);
        article.appendChild(h1);
        article.appendChild(pCategory);
        article.appendChild(pAuthor);
        article.appendChild(pContent);
        article.appendChild(divActions);
        html.articlesSection().appendChild(article);
    }

    function archivePost(e) {
        e.preventDefault();
        let isAdded = false;
        const titleValue = this.parentNode.parentNode.children[0].innerHTML;
        const li = createDomElement("li", titleValue, null, null);

        for (let i = 0; i < html.archiveSection().children[1].childElementCount; i++) {
            const currentArticle = html.archiveSection().children[1].getElementsByTagName("li")[i];

            if (titleValue.localeCompare(currentArticle.innerHTML) === -1) {
                html.archiveSection().children[1].insertBefore(li, currentArticle);
                isAdded = true;
                break;
            }
        }

        if (!isAdded) {
            html.archiveSection().children[1].appendChild(li);
        }

        this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
    }

    function deletePost(e) {
        e.preventDefault();
        this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
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