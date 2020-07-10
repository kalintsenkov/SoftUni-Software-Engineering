const stopIdElement = document.getElementById('stopId');
const stopNameDiv = document.getElementById('stopName');
const busesUl = document.getElementById('buses');

function getInfo() {
    stopNameDiv.innerHTML = '';
    busesUl.innerHTML = '';

    const stopId = stopIdElement.value;
    const url = `http://localhost:3000/businfo/${stopId}`;

    fetch(url)
        .then(response => response.json())
        .then(stop => {
            const stopName = stop.name;
            stopNameDiv.innerHTML = stopName;

            for (const id in stop.buses) {
                const li = document.createElement('li');
                li.innerHTML = `Bus ${id} arrives in ${stop.buses[id]} minutes`;
                busesUl.appendChild(li);
            }
        })
        .catch(_ => stopNameDiv.innerHTML = 'Error');
}