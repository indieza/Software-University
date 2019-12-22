let sum = 0;

function add(num) {
    sum += num;
    return add;
}

add(1);
console.log(sum);

add(1)(6)(-3);
console.log(sum);