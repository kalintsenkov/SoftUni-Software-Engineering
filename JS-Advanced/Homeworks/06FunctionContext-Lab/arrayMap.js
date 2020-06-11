'use strict'

function arrayMap(array, fn) {
    return array.reduce((acc, curr) => {
        const result = fn.call(array, curr);
        return acc.concat(result);
    }, []);
}

const numbers = [1, 2, 3, 4, 5];
console.log(arrayMap(numbers, (item) => item * 2)); // [ 2, 4, 6, 8, 10 ]