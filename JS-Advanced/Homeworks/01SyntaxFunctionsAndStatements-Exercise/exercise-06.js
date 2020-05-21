"use strict"

function solve(arr) {
    let number = +arr[0];
    
    const operationsMap = {
        'chop': (x) => x / 2,
        'dice': (x) => Math.sqrt(x),
        'spice': (x) => x + 1,
        'bake': (x) => x * 3,
        'fillet': (x) => x - x * 0.2,
    }

    for (let i = 1; i < arr.length; i++) {
        const operation = arr[i];
        number = operationsMap[operation](number);
        console.log(number);
    }
}