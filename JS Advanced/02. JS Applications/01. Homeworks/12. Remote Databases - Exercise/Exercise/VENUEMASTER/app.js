import {
    get,
    post
} from "./requester.js";

import {
    venueTemplate,
    confirmationTemplate
} from "./templates.js";

const html = {
    getVenues: () => document.getElementById("getVenues"),
    getDate: () => document.getElementById("venueDate"),
    venuesCollection: () => document.getElementById("venue-info"),
    venueInfoButton: () => document.getElementsByClassName("info"),
    venuePurchaseButton: () => document.getElementsByClassName("purchase"),
    venueConfirmButton: () => document.getElementsByClassName("confirm")
}

function attachedEvents() {
    html.getVenues().addEventListener("click", getVenues);
}

async function getVenues() {
    html.venuesCollection().innerHTML = "";
    const date = html.getDate().value;
    const ids = await post("rpc", `custom/calendar?query=${date}`);

    ids.forEach(_id => {
        getTargetVenue(_id);
    });
}

async function getTargetVenue(_id) {
    const venue = await get("appdata", `venues/${_id}`);
    createVenue(venue);
}

function createVenue(venue) {
    let template = Handlebars.compile(venueTemplate());

    html.venuesCollection().innerHTML += template({
        venueId: venue._id,
        venueName: venue.name,
        venuePrice: venue.price,
        venueDescription: venue.description,
        venueStartingHour: venue.startingHour
    });

    [...html.venueInfoButton()].forEach(button => {
        button.addEventListener("click", showVenueInfo);
    });

    [...html.venuePurchaseButton()].forEach(button => {
        button.addEventListener("click", purchaseVenue);
    });
}

function showVenueInfo() {
    const targetVenue = this.parentNode.parentNode.childNodes[3];

    if (targetVenue.style.display === "none") {
        targetVenue.style.display = "block";
        this.value = "Less info";
    } else {
        targetVenue.style.display = "none";
        this.value = "More info";
    }
}

function purchaseVenue() {
    const venuePrice = parseInt(this.parentNode.parentNode.childNodes[1].innerText);
    const venueQuantity = parseInt(this.parentNode.parentNode.childNodes[3].childNodes[0].value);
    const name = this.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.childNodes[1].innerText;
    const id = this.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.childNodes[0].id;

    let template = Handlebars.compile(confirmationTemplate());

    html.venuesCollection().innerHTML = template({
        name: name,
        qty: venueQuantity,
        price: venuePrice,
        totalPrice: venuePrice * venueQuantity
    });

    const confirmButton = html.venuesCollection().childNodes[2].childNodes[7];
    confirmButton.setAttribute("venueId", id);
    confirmButton.setAttribute("venueQty", venueQuantity);
    confirmButton.addEventListener("click", confirmVenue);
}

async function confirmVenue() {
    const id = this.getAttribute("venueId");
    const qty = this.getAttribute("venueQty");

    const result = await post("rpc", `custom/purchase?venue=${id}&qty=${qty} `);;
    html.venuesCollection().innerHTML = "You may print this page as your ticket" + result.html;
}

attachedEvents();