"use strict"

function solve(arr) {
    let object = {};
    for (let i = 0; i < arr.length - 1; i++) {
        const element = arr[i];
        const nextElement = arr[i + 1];
        if (i % 2 == 0) {
            object[element] = +nextElement;
        }
    }

    return object;
}