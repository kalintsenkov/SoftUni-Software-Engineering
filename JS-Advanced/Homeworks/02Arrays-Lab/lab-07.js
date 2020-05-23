'use strict'

function maxNumber(matrix) {
    const array = [].concat(...matrix);
    return array.sort((a, b) => b - a).slice(0, 1)[0];
}