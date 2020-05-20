"use strict"

function mathOperation(x, y, operator) {
    const operationsMap = {
        '+': (x, y) => x + y,
        '-': (x, y) => x - y,
        '*': (x, y) => x * y,
        '/': (x, y) => x / y,
        '%': (x, y) => x % y,
        '**': (x, y) => x ** y
    }
    
    console.log(operationsMap[operator](x, y));
}