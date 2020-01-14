import {
    fetchData
} from './fetch.js';

const html = {
    loadButton: () => document.getElementsByClassName("load")[0],
    catchesCollection: () => document.getElementById("catches"),
    hr: () => document.createElement("hr"),
    addButton: () => document.getElementsByClassName("add")[0],
    anglerField: () => document.querySelector("fieldset > .angler"),
    weightField: () => document.querySelector("fieldset > .weight"),
    speciesField: () => document.querySelector("fieldset > .species"),
    locationField: () => document.querySelector("fieldset > .location"),
    baitField: () => document.querySelector("fieldset > .bait"),
    captureTimeField: () => document.querySelector("fieldset > .captureTime"),

}

function attachEvents() {
    html.loadButton().addEventListener("click", loadData);
    html.addButton().addEventListener("click", addData);
}

function loadData() {
    // html.catchesCollection().innerHTML = "";

    fetchData().loadData()
        .then(data => {
            Object.entries(data)
                .forEach(([id, item]) => {
                    const catchesDiv = document.createElement("div");
                    catchesDiv.classList.add("catch");
                    catchesDiv.setAttribute("data-id", id);

                    const anglerLabel = createDomLabel("label", "Angler");
                    const anglerInput = createDomInput("input", "text", ["angler"], item.angler);

                    const weightLabel = createDomLabel("label", "Weight");
                    const weightInput = createDomInput("input", "number", ["weight"], item.weight);

                    const speciesLabel = createDomLabel("label", "Species");
                    const speciesInput = createDomInput("input", "text", ["species"], item.species);

                    const locationLabel = createDomLabel("label", "Location");
                    const locationInput = createDomInput("input", "text", ["location"], item.location);

                    const baitLabel = createDomLabel("label", "Bait");
                    const baitInput = createDomInput("input", "text", ["bait"], item.bait);

                    const captureTimeLabel = createDomLabel("label", "Capture Time");
                    const captureTimeInput = createDomInput("input", "number", ["captureTime"], item.captureTime);

                    const updateButton = createDomButton("button", ["update"], "Update");
                    updateButton.addEventListener("click", updateCatch);

                    const deleteButton = createDomButton("button", ["delete"], "Delete");
                    deleteButton.addEventListener("click", deleteCatch);

                    catchesDiv.append(anglerLabel, anglerInput, html.hr(), weightLabel, weightInput, html.hr());
                    catchesDiv.append(speciesLabel, speciesInput, html.hr(), locationLabel, locationInput, html.hr());
                    catchesDiv.append(baitLabel, baitInput, html.hr(), captureTimeLabel, captureTimeInput, html.hr());
                    catchesDiv.append(updateButton, deleteButton);
                    html.catchesCollection().appendChild(catchesDiv);
                })
        })
        .catch(() => console.log("Error"));
}

function createDomLabel(element, text) {
    const label = document.createElement(element);
    label.textContent = text;

    return label;
}

function createDomInput(element, type, classes, itemValue) {
    const input = document.createElement(element);
    input.type = type;
    input.classList.add([...classes]);
    input.value = itemValue;

    return input;
}

function createDomButton(element, classes, text) {
    const button = document.createElement(element);
    button.classList.add([...classes]);
    button.textContent = text;

    return button;
}

function deleteCatch() {
    const id = this.parentNode.getAttribute("data-id");
    this.parentNode.parentNode.removeChild(this.parentNode);

    const headers = {
        method: "DELETE"
    };

    fetchData().deleteCatchesElement(id, headers)
        .then(() => {
            loadData();
        })
        .catch(() => console.log("Error"));
}

function updateCatch() {
    const id = this.parentNode.getAttribute("data-id");

    const headers = {
        method: "PUT",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify({
            "angler": this.parentNode.querySelector(".angler").value,
            "weight": this.parentNode.querySelector(".weight").value,
            "species": this.parentNode.querySelector(".species").value,
            "location": this.parentNode.querySelector(".location").value,
            "bait": this.parentNode.querySelector(".bait").value,
            "captureTime": this.parentNode.querySelector(".captureTime").value
        })
    };

    fetchData().updateCatch(id, headers)
        .then(() => {
            loadData();
        })
        .catch(() => console.log("Error"));
}

function addData() {
    const angler = html.anglerField().value;
    const weight = html.weightField().value;
    const species = html.speciesField().value;
    const location = html.locationField().value;
    const bait = html.baitField().value;
    const captureTime = html.captureTimeField().value;

    const headers = {
        method: "POST",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify({
            "angler": angler,
            "weight": weight,
            "species": species,
            "location": location,
            "bait": bait,
            "captureTime": captureTime
        })
    };

    fetchData().addCatch(headers)
        .then(() => {
            loadData();
        })
        .catch(() => console.log("Error"));
}

attachEvents();