'use strict'

function solve(arr) {
    arr.sort(function (a, b) {
        if (a.length > b.length) { return 1; }
        if (a.length < b.length) { return -1; }
        return a.localeCompare(b);
    });

    return arr.join('\n');
}