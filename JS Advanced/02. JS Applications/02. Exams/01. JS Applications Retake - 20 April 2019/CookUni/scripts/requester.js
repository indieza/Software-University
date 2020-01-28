const baseUrl = "https://baas.kinvey.com";
const appKey = "kid_ByTwhkA-8";
const appSecret = "a239f1dd95ff43dabd08152325b5cbeb";

function createAuthorization(type) {
    return type === 'Basic' ?
        `Basic ${btoa(`${appKey}:${appSecret}`)}` :
        `Kinvey ${sessionStorage.getItem('authtoken')}`
}

function makeHeaders(type, method, data) {
    const headers = {
        method: method,
        headers: {
            'Authorization': createAuthorization(type),
            'Content-Type': 'application/json'
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

export function get(kinveyModule, endpoint, type) {
    const headers = makeHeaders(type, "GET");
    return fetchRequest(kinveyModule, endpoint, headers);
}

export function post(kinveyModule, endpoint, data, type) {
    const headers = makeHeaders(type, "POST", data);
    return fetchRequest(kinveyModule, endpoint, headers);
}

export function put(kinveyModule, endpoint, data, type) {
    const headers = makeHeaders(type, "PUT", data);
    return fetchRequest(kinveyModule, endpoint, headers);
}

export function del(kinveyModule, endpoint, type) {
    const headers = makeHeaders(type, "DELETE");
    return fetchRequest(kinveyModule, endpoint, headers);
}