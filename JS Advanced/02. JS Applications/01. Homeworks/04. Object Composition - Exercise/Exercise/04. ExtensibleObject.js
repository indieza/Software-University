function solve() {
    let obj = {
        extend: function (template) {
            Object
                .keys(template)
                .forEach(prop => {
                    typeof (template[prop]) == "function" ?
                    Object.getPrototypeOf(obj)[prop] = template[prop]: obj[prop] = template[prop];
                });
        }
    }

    return obj;
}