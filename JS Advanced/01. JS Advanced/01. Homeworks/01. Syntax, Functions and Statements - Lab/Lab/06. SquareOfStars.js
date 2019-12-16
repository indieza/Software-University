function solve(n){
    for (let i = 0; i < Number(n); i++) {
        let array = "";

        for (let j = 0; j < Number(n); j++) {
            array += "* ";          
        }

        console.log(String(array));
    }
}

solve(1);
solve(5);
solve(10);