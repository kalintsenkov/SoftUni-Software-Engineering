'use strict'

function rotateArray(arr) {
    const rotations = arr[arr.length - 1];

    arr = arr.slice(0, arr.length - 1);

    if (rotations % arr.length === 0) {
        return arr.join(' ');
    }

    for (let i = 1; i <= rotations; i++) {
        const lastItem = arr.pop();
        arr.unshift(lastItem);
    }

    return arr.join(' ');
}