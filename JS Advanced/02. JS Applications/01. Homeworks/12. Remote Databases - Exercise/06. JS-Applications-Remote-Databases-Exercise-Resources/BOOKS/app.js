import {
    get,
    post,
    put,
    del
} from "./requester.js";

const html = {
    submitButton: () => document.getElementById("submit"),
    loadButton: () => document.getElementById("loadBooks"),
    updateButton: () => document.getElementsByClassName("update")[0],
    title: () => document.getElementById("title"),
    author: () => document.getElementById("author"),
    isbn: () => document.getElementById("isbn"),
    tableBody: () => document.getElementsByTagName("tbody")[0]
}

function attachedEvents() {
    html.tableBody().innerHTML = "";
    html.submitButton().disabled = true;
    html.updateButton().disabled = true;

    html.submitButton().addEventListener("click", createBook);
    html.loadButton().addEventListener("click", loadBooks);
    html.updateButton().addEventListener("click", updateBook);
}

async function loadBooks() {
    html.tableBody().innerHTML = "";
    html.submitButton().disabled = false;
    html.updateButton().disabled = true;

    const books = await get("appdata", "books");
    books.forEach(({
        _id,
        title,
        author,
        isbn
    }) => {
        const tr = createBookRow(title, author, isbn, _id);
        html.tableBody().append(tr);
    });
}

async function createBook(e) {
    e.preventDefault();
    const data = {
        title: html.title().value,
        author: html.author().value,
        isbn: html.isbn().value
    };

    await post("appdata", "books", data);

    html.title().value = "";
    html.author().value = "";
    html.isbn().value = "";

    loadBooks();
}

function createBookRow(title, author, isbn, id) {
    const tr = createDomElement("tr");
    id ? tr.id = id : tr;

    const titleItem = createDomElement("td", title);
    const authorItem = createDomElement("td", author);
    const isbnItem = createDomElement("td", isbn);
    const actions = createDomElement("td");
    const editButton = createDomElement("button", "Edit");
    editButton.addEventListener("click", readUpdateBookData)

    const deleteButton = createDomElement("button", "Delete");
    deleteButton.addEventListener("click", deleteBook);

    actions.append(editButton, deleteButton);
    tr.append(titleItem, authorItem, isbnItem, actions);

    return tr;
}

function createDomElement(element, text) {
    const item = document.createElement(element);

    if (text) {
        item.innerHTML = text;
    }

    return item;
}

async function deleteBook() {
    const id = this.parentNode.parentNode.id;
    html.tableBody().removeChild(this.parentNode.parentNode);
    await del("appdata", `books/${id}`);
    //loadBooks();
}

function readUpdateBookData() {
    html.submitButton().disabled = true;
    html.updateButton().disabled = false;

    const targetId = this.parentNode.parentNode.id;
    const targetRow = [...html.tableBody().children].find(x => x.id === targetId);

    const title = targetRow.children[0].innerText;
    const author = targetRow.children[1].innerText;
    const isbn = targetRow.children[2].innerText;

    html.title().value = title;
    html.author().value = author;
    html.isbn().value = isbn;

    html.updateButton().disabled = false;
    html.updateButton().id = targetId;
}

function updateBook() {
    const data = {
        title: html.title().value,
        author: html.author().value,
        isbn: html.isbn().value
    };

    put("appdata", `books/${this.id}`, data);

    html.title().value = "";
    html.author().value = "";
    html.isbn().value = "";

    loadBooks();
}

attachedEvents();