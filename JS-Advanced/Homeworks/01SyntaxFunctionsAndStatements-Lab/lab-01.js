"use strict"

function stringLength(...params) {
    let sumLen = 0;
    let avgLen = 0;

    params.forEach(param => { sumLen += param.length; });
    avgLen = Math.floor(sumLen / params.length);

    console.log(sumLen);
    console.log(avgLen);
}