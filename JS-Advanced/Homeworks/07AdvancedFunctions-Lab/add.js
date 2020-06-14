'use strict'

function solution(num) {
    return (numToAdd) => num + numToAdd;
}

let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));