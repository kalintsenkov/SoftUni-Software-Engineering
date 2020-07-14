const loadButton = document.querySelector('button.load');
const addButton = document.querySelector('button.add');

const catchesDiv = document.querySelector('#catches');

const anglerInput = document.querySelector('input.angler');
const weightInput = document.querySelector('input.weight');
const speciesInput = document.querySelector('input.species');
const locationInput = document.querySelector('input.location');
const baitInput = document.querySelector('input.bait');
const captureTimeInput = document.querySelector('input.captureTime');

function attachEvents() {
    loadButton.addEventListener('click', listAllCatches);
    addButton.addEventListener('click', createCatch);

    function listAllCatches() {
        catchesDiv.innerHTML = '';

        const url = 'https://fisher-game.firebaseio.com/catches.json';

        fetch(url)
            .then(response => response.json())
            .then(data => {
                for (const key in data) {
                    const catchObj = data[key];

                    const catchDiv = document.createElement('div');
                    catchDiv.className = 'catch';
                    catchDiv.dataset.id = key;

                    const anglerLabel = document.createElement('label');
                    anglerLabel.innerHTML = 'Angler';

                    const anglerInput = document.createElement('input');
                    anglerInput.className = 'angler';
                    anglerInput.type = 'text';
                    anglerInput.value = catchObj.angler;

                    const weightLabel = document.createElement('label');
                    weightLabel.innerHTML = 'Weight';

                    const weightInput = document.createElement('input');
                    weightInput.className = 'weight';
                    weightInput.type = 'number';
                    weightInput.value = catchObj.weight;

                    const speciesLabel = document.createElement('label');
                    speciesLabel.innerHTML = 'Species';

                    const speciesInput = document.createElement('input');
                    speciesInput.className = 'species';
                    speciesInput.type = 'text';
                    speciesInput.value = catchObj.species;

                    const locationLabel = document.createElement('label');
                    locationLabel.innerHTML = 'Location';

                    const locationInput = document.createElement('input');
                    locationInput.className = 'location';
                    locationInput.type = 'text';
                    locationInput.value = catchObj.location;

                    const baitLabel = document.createElement('label');
                    baitLabel.innerHTML = 'Bait';

                    const baitInput = document.createElement('input');
                    baitInput.className = 'bait';
                    baitInput.type = 'text';
                    baitInput.value = catchObj.bait;

                    const captureTimeLabel = document.createElement('label');
                    captureTimeLabel.innerHTML = 'Capture Time';

                    const captureTimeInput = document.createElement('input');
                    captureTimeInput.className = 'captureTime';
                    captureTimeInput.type = 'number';
                    captureTimeInput.value = catchObj.captureTime;

                    const updateBtn = document.createElement('button');
                    updateBtn.className = 'update';
                    updateBtn.innerHTML = 'Update';

                    const deleteBtn = document.createElement('button');
                    deleteBtn.className = 'delete';
                    deleteBtn.innerHTML = 'Delete';

                    const hr1 = document.createElement('hr');
                    const hr2 = document.createElement('hr');
                    const hr3 = document.createElement('hr');
                    const hr4 = document.createElement('hr');
                    const hr5 = document.createElement('hr');
                    const hr6 = document.createElement('hr');

                    catchDiv.appendChild(anglerLabel);
                    catchDiv.appendChild(anglerInput);
                    catchDiv.appendChild(hr1);

                    catchDiv.appendChild(weightLabel);
                    catchDiv.appendChild(weightInput);
                    catchDiv.appendChild(hr2);

                    catchDiv.appendChild(speciesLabel);
                    catchDiv.appendChild(speciesInput);
                    catchDiv.appendChild(hr3);

                    catchDiv.appendChild(locationLabel);
                    catchDiv.appendChild(locationInput);
                    catchDiv.appendChild(hr4);

                    catchDiv.appendChild(baitLabel);
                    catchDiv.appendChild(baitInput);
                    catchDiv.appendChild(hr5);

                    catchDiv.appendChild(captureTimeLabel);
                    catchDiv.appendChild(captureTimeInput);
                    catchDiv.appendChild(hr6);

                    catchDiv.appendChild(updateBtn);
                    catchDiv.appendChild(deleteBtn);

                    catchesDiv.appendChild(catchDiv);

                    updateBtn.addEventListener('click', updateCatch);
                    deleteBtn.addEventListener('click', deleteCatch);
                }
            });
    }

    function createCatch() {
        const url = 'https://fisher-game.firebaseio.com/catches.json';

        const catchObj = {
            angler: anglerInput.value,
            weight: weightInput.value,
            species: speciesInput.value,
            location: locationInput.value,
            bait: baitInput.value,
            captureTime: captureTimeInput.value
        };

        anglerInput.value = '';
        weightInput.value = '';
        speciesInput.value = '';
        locationInput.value = '';
        baitInput.value = '';
        captureTimeInput.value = '';

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(catchObj),
        }).then(listAllCatches());
    }

    function updateCatch(e) {
        const catchId = e.target.parentElement.dataset.id;
        const url = `https://fisher-game.firebaseio.com/catches/${catchId}.json`;

        const parentDiv = e.target.parentElement;

        const angler = parentDiv.querySelector('input.angler');
        const weight = parentDiv.querySelector('input.weight');
        const species = parentDiv.querySelector('input.species');
        const location = parentDiv.querySelector('input.location');
        const bait = parentDiv.querySelector('input.bait');
        const captureTime = parentDiv.querySelector('input.captureTime');

        const catchObj = {
            angler: angler.value,
            weight: weight.value,
            species: species.value,
            location: location.value,
            bait: bait.value,
            captureTime: captureTime.value
        };

        fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(catchObj)
        }).then(listAllCatches());
    }

    function deleteCatch(e) {
        const catchId = e.target.parentElement.dataset.id;
        const url = `https://fisher-game.firebaseio.com/catches/${catchId}.json`;

        fetch(url, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(listAllCatches());
    }
}

attachEvents();
