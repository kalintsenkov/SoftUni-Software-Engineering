'use strict'

function solve(commands) {
    const arr = [1];
    let numberToAdd = arr[0];

    for (let i = 1; i < commands.length; i++) {
        numberToAdd++;
        commands[i] === 'add' ? arr.push(numberToAdd) : arr.pop();
    }

    return arr.length > 0 ? arr.join('\n') : 'Empty';
}