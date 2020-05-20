"use strict"

function sumOfNumbersInRange(x, y) {
    let start = Number(x);
    let end = Number(y);
    
    let sum = 0;
    for (let i = start; i <= end; i++) {
        sum += i;
    }

    return sum;
}