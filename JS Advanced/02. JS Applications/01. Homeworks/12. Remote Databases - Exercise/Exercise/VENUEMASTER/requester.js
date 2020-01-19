const username = "guest";
const password = "pass";

const baseUrl = "https://baas.kinvey.com";
const appKey = "kid_BJ_Ke8hZg";

function makeHeaders(method, data) {
    const headers = {
        method: method,
        headers: {
            "Authorization": `Basic ${btoa(`${username}:${password}`)}`,
            "Content-Type": "application/json"
        }
    };

    if (method === "POST" || method === "PUT") {
        headers.body = JSON.stringify(data);
    }

    return headers;
}

function handleError(e) {
    if (!e.ok) {
        throw new Error(`${e.status} - ${e.statusText}`);
    }

    return e;
}

function serializeData(x) {
    return x.json();
}

function fetchRequest(kinveyModule, endpoint, headers) {
    const url = `${baseUrl}/${kinveyModule}/${appKey}/${endpoint}`;
    return fetch(url, headers)
        .then(handleError)
        .then(serializeData);
}

export function get(kinveyModule, endpoint) {
    const headers = makeHeaders("GET");
    return fetchRequest(kinveyModule, endpoint, headers);
}

export function post(kinveyModule, endpoint, data) {
    const headers = makeHeaders("POST", data);
    return fetchRequest(kinveyModule, endpoint, headers);
}