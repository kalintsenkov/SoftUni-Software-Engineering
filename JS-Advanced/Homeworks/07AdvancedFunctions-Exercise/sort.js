'use strict'

function solve(arr, sort) {
    if (sort === 'asc') {
        return arr.sort((a, b) => a - b);
    } else {
        return arr.sort((a, b) => b - a);
    }
}

console.log(solve([14, 7, 17, 6, 8], 'desc')); // [17, 14, 8, 7, 6]