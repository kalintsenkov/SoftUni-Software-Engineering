"use strict"

function solve(num) {
    let areSame = true;
    let sum = 0;

    const arr = Array.from(num.toString());
    for (let i = 0; i < arr.length; i++) {
        const element = arr[i];
        sum += +element;

        if (i < arr.length - 1) {
            const nextElement = arr[i + 1];
            if (!areSame) {
                continue;
            }

            areSame = element == nextElement ? true : false;
        }
    }

    console.log(areSame);
    console.log(sum);
}