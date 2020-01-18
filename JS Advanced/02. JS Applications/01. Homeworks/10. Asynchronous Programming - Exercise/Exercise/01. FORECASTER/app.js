import {
    fetchRequest
} from './fetch.js';

const html = {
    submitButton: () => document.getElementById("submit"),
    locationName: () => document.getElementById("location"),
    forecastSection: () => document.getElementById("forecast"),
    currentForecast: () => document.getElementById("current"),
    upcomingForecast: () => document.getElementById("upcoming")
};

const symbols = {
    sunny: "☀",
    partlysunny: "⛅",
    overcast: "☁",
    rain: "☂",
    degrees: "°"
};

function attachEvents() {
    html.submitButton().addEventListener("click", submit);
}

function submit() {
    const cityName = html.locationName().value;

    fetchRequest()
        .locationInfo()
        .then(data => findCity(data, cityName))
        .then(({
            name,
            code
        }) => requestCityInfo(code))
        .then(([currentDay, nextDay]) => proceedInfo(currentDay, nextDay))
        .catch(() => {
            html.forecastSection().style.display = "block";
            const div = createDomElement("div", ["error-cast"], "Error");
            html.forecastSection().appendChild(div);
        });
}

function findCity(data, cityName) {
    return data.find(s => s.name === cityName);
}

function requestCityInfo(code) {
    return Promise.all([fetchRequest().currentDay(code),
        fetchRequest().upcomingDay(code)
    ]);
}

function proceedInfo(currentDay, nextDay) {
    html.forecastSection().style.display = "block";

    proceedCurrentDayInfo(currentDay);
    proceedNextDayInfo(nextDay);
}

function proceedNextDayInfo(nextDay) {
    const forecastDiv = createDomElement("div", ["forecast-info"]);

    nextDay.forecast.forEach(day => {
        const upcomingSpan = createDomElement("span", ["upcoming"]);
        const symbolSpan = createDomElement("span", ["symbol"], symbols[editConditionName(day)]);
        const temperatureSpan = createDomElement("span",
            ["forecast-data"],
            `${day.high}${symbols.degrees}/${day.low}${symbols.degrees}`);
        const weatherNameSpan = createDomElement("span", ["forecast-data"], day.condition);

        upcomingSpan.append(symbolSpan, temperatureSpan, weatherNameSpan);
        forecastDiv.appendChild(upcomingSpan);
    });

    html.upcomingForecast().appendChild(forecastDiv);
}

function proceedCurrentDayInfo(currentDay) {
    const forecastDiv = createDomElement("div", ["forecasts"]);
    const conditionSymbol = createDomElement("span", ["condition", "symbol"], symbols[editConditionName(currentDay.forecast)]);
    const conditionSpan = createDomElement("span", ["condition"]);
    const townSpan = createDomElement("span", ["forecast-data"], currentDay.name);
    const temperatureSpan = createDomElement("span",
        ["forecast-data"],
        `${currentDay.forecast.high}${symbols.degrees}/${currentDay.forecast.low}${symbols.degrees}`);
    const weatherNameSpan = createDomElement("span", ["forecast-data"], currentDay.forecast.condition);

    conditionSpan.append(townSpan, temperatureSpan, weatherNameSpan);
    forecastDiv.append(conditionSymbol, conditionSpan);

    html.currentForecast().appendChild(forecastDiv);
}

function editConditionName(day) {
    return day.condition.toLowerCase().split("").filter(x => x !== " ").join("");
}

function createDomElement(tag, classes, text) {
    const item = document.createElement(tag);
    item.classList.add(...classes);

    if (text) {
        item.textContent = text;
    }

    return item;
}

attachEvents();