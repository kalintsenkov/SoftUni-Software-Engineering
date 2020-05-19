"use strict"

function calculateCircleArea(num) {
    var paramType = typeof(num);
    return paramType === "number" 
        ? (Math.pow(num, 2) * Math.PI).toFixed(2)
        : `We can not calculate the circle area, because we receive a ${paramType}.`;
}