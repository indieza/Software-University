function solution(n) {
    return function add5(x) {
        return n + x;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));

let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));