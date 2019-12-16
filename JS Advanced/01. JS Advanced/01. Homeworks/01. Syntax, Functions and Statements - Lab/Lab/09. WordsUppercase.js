function solve(text) {
    let words = text.toUpperCase().split(/\W+/).filter(w => w != "");

    console.log(words.join(", "));
}

solve('Hi, how are you?');
solve('hello');