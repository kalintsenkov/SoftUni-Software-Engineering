'use strict'

function solve(arr) {
    const result = arr.sort((a, b) => a - b).slice(0, 2);
    return result.join(' ');
}