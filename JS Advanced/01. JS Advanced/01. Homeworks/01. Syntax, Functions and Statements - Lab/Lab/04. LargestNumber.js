function solve(x, y, z){
    let result;

    if (x > y && x > z) {
        result = x;
    }
    else if (y > x && y > z) {  
        result = y;
    }
    else {
        result = z;
    }
    
    console.log(`The largest number is ${result}.`);
}

solve(5, -3, 16);
solve(-3, -5, -22.5);