const contacts = [{
        id: 1,
        name: "John",
        phoneNumber: "0847759632",
        email: "john@john.com"
    },
    {
        id: 2,
        name: "Merrie",
        phoneNumber: "0845996111",
        email: "merrie@merrie.com"
    },
    {
        id: 3,
        name: "Adam",
        phoneNumber: "0866592475",
        email: "adam@stamat.com"
    },
    {
        id: 4,
        name: "Peter",
        phoneNumber: "0866592475",
        email: "peter@peter.com"
    },
    {
        id: 5,
        name: "Max",
        phoneNumber: "0866592475",
        email: "max@max.com"
    },
    {
        id: 6,
        name: "David",
        phoneNumber: "0866592475",
        email: "david@david.com"
    }
];

const html = {
    contactsData: () => document.getElementById("contacts"),
    contactDiv: (n) => document.getElementById(n)
};

function attachedEvents() {
    fetch(`http://127.0.0.1:5500/01.%20Homeworks/13.%20Templating%20-%20Lab/Lab/contact.hbs`)
        .then(resources => resources.text())
        .then(data => {
            const template = Handlebars.compile(data);
            html.contactsData().innerHTML = template({
                contacts
            });
        });
}

function showDetails(n) {
    const div = html.contactDiv(n);

    if (div.style.display === "none") {
        div.style.display = "block";
        div.parentNode.children[1].innerText = "LESS";
    } else {
        div.style.display = "none";
        div.parentNode.children[1].innerText = "DETAILS";
    }
}

attachedEvents();