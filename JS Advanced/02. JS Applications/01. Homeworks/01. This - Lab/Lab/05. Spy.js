function Spy(obj, method) {
    let originalFunction = obj[method];

    let invoked = {
        count: 0
    }
    obj[method] = function () {
        invoked.count++;
        return originalFunction.apply(this, arguments)
    }

    return invoked;
}

let obj = {
    method: () => "invoked"
}
let spy = Spy(obj, "method");

obj.method();
obj.method();
obj.method();

console.log(spy) // { count: 3 }