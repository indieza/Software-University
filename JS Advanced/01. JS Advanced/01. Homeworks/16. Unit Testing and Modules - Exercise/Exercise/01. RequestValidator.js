function result(data) {
    const methods = ["GET", "POST", "DELETE", "CONNECT"];
    const uriPattern = /^(\*|[a-zA-Z\d\.]+)$/gim;
    const versions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];
    const messagePattern = /^[^<>\\&'"]*$/gim;

    if (!methods.includes(data.method)) {
        throw new Error("Invalid request header: Invalid Method");
    }

    if (!uriPattern.test(data.uri) || !data.hasOwnProperty("uri")) {
        throw new Error("Invalid request header: Invalid URI");
    }

    if (!versions.includes(data.version)) {
        throw new Error("Invalid request header: Invalid Version");
    }

    if (!messagePattern.test(data.message) || !data.hasOwnProperty("message")) {
        throw new Error("Invalid request header: Invalid Message");
    }

    return data;
}

result({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
});

result({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
});

result({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
});