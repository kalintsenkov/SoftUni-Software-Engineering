'use strict'

function solve(length, previous) {
    const resultArr = [1];

    for (let i = 1; i < length; i++) {
        let previousNumbersSum = calculatePrev();
        resultArr.push(previousNumbersSum);
    }

    return resultArr.join(' ');

    function calculatePrev() {
        const len = resultArr.length <= previous ? resultArr.length : previous;
        let result = 0;
        for (let i = 1; i <= len; i++) {
            result += resultArr[resultArr.length - i];
        }

        return result;
    }
}