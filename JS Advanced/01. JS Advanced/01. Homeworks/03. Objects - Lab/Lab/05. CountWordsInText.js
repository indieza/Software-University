function solve(text) {
    let obj = {};

    for (const item of text) {
        let words = item.match(/\w+/gim);

        for (const word of words) {
            if (obj.hasOwnProperty(word)) {
                obj[word]++;
            } else {
                obj[word] = 1;
            }
        }
    }

    console.log(JSON.stringify(obj));
}

solve(['Far too slow, you\'re far too slow.']);
solve(['JS devs use Node.js for server-side JS.-- JS for devs']);