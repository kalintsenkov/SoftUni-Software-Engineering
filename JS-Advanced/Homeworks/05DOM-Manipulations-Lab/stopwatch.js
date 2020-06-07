function stopwatch() {
    const timeDiv = document.querySelector('#time');
    const startBtn = document.querySelector('#startBtn');
    const stopBtn = document.querySelector('#stopBtn');
    const disabledAttr = 'disabled';

    let minutes = 0;
    let seconds = 0;
    let intervalId = 0;

    startBtn.addEventListener('click', function (e) {
        e.preventDefault();
        timeDiv.textContent = '00:00';

        intervalId = setInterval(function () {
            if (seconds === 59) {
                minutes++;
                seconds = 0;
            }

            const minutesAsStr = pad(minutes);
            const secondsAsStr = pad(seconds++);
            
            timeDiv.textContent = `${minutesAsStr}:${secondsAsStr}`;
        }, 1000);

        stopBtn.removeAttribute(disabledAttr);
        startBtn.disabled = true;
    });

    stopBtn.addEventListener('click', function (e) {
        e.preventDefault();
        clearInterval(intervalId);

        startBtn.removeAttribute(disabledAttr);
        stopBtn.disabled = true;

        minutes = 0;
        seconds = 0;
    });

    function pad(num) {
        let s = num + "";
        if (s.length < 2) { s = "0" + s };
        return s;
    }
}