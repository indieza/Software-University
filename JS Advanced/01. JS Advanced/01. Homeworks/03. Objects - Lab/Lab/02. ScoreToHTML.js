function solve(json) {
    let text = JSON.parse(json);

    let result = new Array();

    result.push("<table>");
    result.push(`  <tr><th>${Object.keys(text[0])[0]}</th><th>${Object.keys(text[0])[1]}</th></tr>`);

    for (let i = 0; i < text.length; i++) {
        const element = text[i];

        let name = element.name
            .replace(/&/gim, '&amp;')
            .replace(/</gim, '&lt;')
            .replace(/>/gim, '&gt;')
            .replace(/"/gim, '&quot;')
            .replace(/'/gim, '&#39;');
        let score = Number(element.score);

        result.push(`  <tr><td>${name}</td><td>${score}</td></tr>`);
    }

    result.push("</table>");

    console.log(result.join("\n"));
}

solve(['[{"name":"Pesho","score":479}, {"name":"Gosho","score":205}]']);
solve(['[{"name":"Pesho & Kiro", "score":479}, {"name":"Gosho, Maria & Viki", "score":205}]']);