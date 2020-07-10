function solve() {
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const spanInfo = document.querySelector('div#info > span.info');

    let currentStop = '';
    let nextStop = '';

    function depart() {
        const info = spanInfo.innerHTML === 'Not Connected' ? 'depot' : nextStop;
        const url = `http://localhost:3000/schedule/${info}`;

        fetch(url)
            .then(response => response.json())
            .then(data => {
                currentStop = data.name;
                nextStop = data.next;

                spanInfo.innerHTML = `Next stop ${currentStop}`;
                departBtn.disabled = true;
                arriveBtn.disabled = false;
            })
            .catch(_ => {
                spanInfo.innerHTML = 'Error';
                departBtn.disabled = true;
                arriveBtn.disabled = true;
            });
    }

    function arrive() {
        spanInfo.innerHTML = `Arriving at ${currentStop}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();