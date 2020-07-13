const locationsUrl = 'https://judgetests.firebaseio.com/locations.json';

const locationInput = document.getElementById('location');
const getWeatherBtn = document.getElementById('submit');
const forecastDiv = document.getElementById('forecast');
const currentDiv = document.getElementById('current');
const upcomingDiv = document.getElementById('upcoming');

function attachEvents() {
    getWeatherBtn.addEventListener('click', getWeather);

    const conditionMap = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂',
        'Degrees': '°'
    };

    function getWeather() {
        forecastDiv.style.display = 'block';

        fetch(locationsUrl)
            .then(response => response.json())
            .then(data => {
                let code = '';

                [...data].forEach(location => {
                    if (location.name === locationInput.value) {
                        code = location.code;
                    }
                });

                if (code === '') {
                    throw new Error('Location not found');
                }

                return code;
            })
            .then(code => getCurrentForecast(code))
            .then(code => getUpcomingForecast(code))
            .catch(error => forecastDiv.innerHTML = error);
    }

    /**
     * @param {string} code 
     * @return {string} Current location code
     */
    function getCurrentForecast(code) {
        const currentForecastUrl = `https://judgetests.firebaseio.com/forecast/today/${code}.json`;

        fetch(currentForecastUrl)
            .then(response => response.json())
            .then(data => {
                const div = document.createElement('div');
                div.classList.add('forecasts');

                const conditionSymbolSpan = document.createElement('span');
                conditionSymbolSpan.className = 'condition symbol';
                conditionSymbolSpan.innerHTML = conditionMap[data.forecast.condition];

                const conditionSpan = document.createElement('span');
                conditionSpan.classList.add('condition');

                const locationNameSpan = document.createElement('span');
                locationNameSpan.classList.add('forecast-data');
                locationNameSpan.innerHTML = data.name;

                const hiLoSpan = document.createElement('span');
                hiLoSpan.classList.add('forecast-data');
                hiLoSpan.innerHTML = `${data.forecast.low}${conditionMap['Degrees']}/${data.forecast.high}${conditionMap['Degrees']}`;

                const conditionNameSpan = document.createElement('span');
                conditionNameSpan.classList.add('forecast-data');
                conditionNameSpan.innerHTML = data.forecast.condition;

                conditionSpan.appendChild(locationNameSpan);
                conditionSpan.appendChild(hiLoSpan);
                conditionSpan.appendChild(conditionNameSpan);

                div.appendChild(conditionSymbolSpan);
                div.appendChild(conditionSpan);

                currentDiv.append(div);
            });

        return code;
    }

    /**
     * @param {string} code 
     * @return {string} Current location code
     */
    function getUpcomingForecast(code) {
        const upcomingForecastUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;

        fetch(upcomingForecastUrl)
            .then(response => response.json())
            .then(data => {
                const div = document.createElement('div');
                div.classList.add('forecast-info');

                const forecasts = data.forecast;

                [...forecasts].forEach(forecast => {
                    const upcomingSpan = document.createElement('span');
                    upcomingSpan.classList.add('upcoming');

                    const symbolSpan = document.createElement('span');
                    symbolSpan.classList.add('symbol');
                    symbolSpan.innerText = conditionMap[forecast.condition];

                    const hiLoSpan = document.createElement('span');
                    hiLoSpan.classList.add('forecast-data');
                    hiLoSpan.innerHTML = `${forecast.low}${conditionMap['Degrees']}/${forecast.high}${conditionMap['Degrees']}`;

                    const conditionNameSpan = document.createElement('span');
                    conditionNameSpan.classList.add('forecast-data');
                    conditionNameSpan.innerHTML = forecast.condition;

                    upcomingSpan.appendChild(symbolSpan);
                    upcomingSpan.appendChild(hiLoSpan);
                    upcomingSpan.appendChild(conditionNameSpan);

                    div.appendChild(upcomingSpan);
                });

                upcomingDiv.append(div);
            });

        return code;
    }
}

attachEvents();