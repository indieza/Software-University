function solve(input) {
    let editItem = str => str
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;');

    let result = "";

    result += "<table>\n";

    for (const item of input) {
        let json = JSON.parse(item);

        result += "\t<tr>\n";
        result += `\t\t<td>${editItem(json.name)}</td>\n`;
        result += `\t\t<td>${editItem(json.position)}</td>\n`;
        result += `\t\t<td>${json.salary}</td>\n`;
        result += "\t</tr>\n";
    }

    result += "</table>";

    console.log(result);
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'
]);