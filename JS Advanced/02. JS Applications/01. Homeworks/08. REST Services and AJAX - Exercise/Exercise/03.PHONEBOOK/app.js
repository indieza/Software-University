function attachEvents() {
    const url = "https://phonebook-nakov.firebaseio.com/phonebook.json";
    const phoneBookData = document.getElementById("phonebook");

    function createPhone() {
        const person = document.getElementById("person").value;
        const phone = document.getElementById("phone").value;
        const headers = {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                person,
                phone
            })
        };
        fetch(url, headers)
            .then(() => {
                document.getElementById("person").value = "";
                document.getElementById("phone").value = "";
                phoneBookData.innerHTML = "";
                loadPhoneBook();
            })
            .catch(() => console.log("Error"));
    }

    function loadPhoneBook() {
        fetch(url)
            .then(resources => resources.json())
            .then(data => {
                phoneBookData.innerHTML = "";

                Object.entries(data).forEach(([elementId, phoneBook]) => {
                    const {
                        person,
                        phone
                    } = phoneBook;

                    const li = document.createElement("li");
                    li.textContent = `${person}: ${phone}`;
                    const deleteButton = document.createElement("button");
                    deleteButton.textContent = "Delete";
                    deleteButton.id = elementId;
                    deleteButton.addEventListener("click", deletePhone);
                    li.appendChild(deleteButton);
                    phoneBookData.appendChild(li);
                });
            })
            .catch(() => console.log("Error"));
    }

    function deletePhone() {
        const id = this.getAttribute("id");
        const headers = {
            method: "DELETE"
        };

        fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${id}.json`, headers)
            .then(() => {
                phoneBookData.innerHTML = "";
                loadPhoneBook();
            })
            .catch(() => console.log("Error"));
    }

    return {
        loadPhoneBook,
        createPhone,
        deletePhone
    };
}

const result = attachEvents();