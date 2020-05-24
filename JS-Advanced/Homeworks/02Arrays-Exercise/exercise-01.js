'use strict'

function printArray(arr) {
    const delimiter = arr[arr.length - 1];
    return arr.slice(0, arr.length - 1).join(delimiter);
}