"use strict"

function calculate(steps, footprintLen, speed) {
    const dist = steps * footprintLen;
    let time = Math.round(dist / speed * 3.6);
    time += Math.floor(dist / 500) * 60;

    const seconds = time % 60;
    time -= seconds;
    time /= 60;

    const minutes = time % 60;
    time -= minutes;
    time /= 60;

    const hours = time;

    return `${pad(hours)}:${pad(minutes)}:${pad(seconds)}`;

    function pad(num) {
        return num < 10 ? '0' + num : '' + num;
    }
}