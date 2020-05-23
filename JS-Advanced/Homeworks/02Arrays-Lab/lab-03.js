'use strict'

function solve(arr) {
    const result = [];

    arr.forEach(num => num >= 0 
        ? result.push(num) 
        : result.unshift(num)
    );

    return result.map(item => console.log(item));
}