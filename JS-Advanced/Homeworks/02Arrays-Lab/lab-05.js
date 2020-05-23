'use strict'

function solve(arr) {
    const result = arr.filter((_, i) => i % 2 !== 0).map(x => x * 2).reverse();
    return result.join(' ');
}