"use strict"

function solve(arr) {
    const currentSpeed = arr[0];
    const area = arr[1];

    const areaLimitsMap = {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential': 20
    };

    let returnStr = '';
    const curretAreaLimit = areaLimitsMap[area];
    if (curretAreaLimit < currentSpeed) {
        const speedOverLimit = currentSpeed - curretAreaLimit;
        if (speedOverLimit <= 20) {
            returnStr = 'speeding';
        } else if (speedOverLimit > 20 && speedOverLimit <= 40) {
            returnStr = 'excessive speeding';
        } else {
            returnStr = 'reckless driving';
        }
    }

    return returnStr;
}