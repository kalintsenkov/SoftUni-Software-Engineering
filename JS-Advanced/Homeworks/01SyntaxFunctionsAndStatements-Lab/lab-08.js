"use strict"

function aggregateElements(arr) {
    let sum = 0;
    let inverseSum = 0;
    let concat = '';

    for (let i = 0; i < arr.length; i++) {
        const element = arr[i];
        sum += element;
        inverseSum += 1 / element;
        concat += element;
    }

    console.log(sum);
    console.log(inverseSum);
    console.log(concat);
}