const username = "simeon";
const password = "simeon";

const baseUrl = "https://baas.kinvey.com";
const appKey = "kid_H1VFvdeb8";
const appSecret = "ed4869b0311d40d6abbcf07c59fd17d2";

function getHeaders(method, data) {
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

function fetchRequests(kinveyModule, endPoint, headers) {
    const url = `${baseUrl}/${kinveyModule}/${appKey}/${endPoint}`;

    return fetch(url, headers)
        .then(handleError)
        .then(serializeData);
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

export function get(kinveyModule, endPoint) {
    const headers = getHeaders("GET");
    return fetchRequests(kinveyModule, endPoint, headers);
}