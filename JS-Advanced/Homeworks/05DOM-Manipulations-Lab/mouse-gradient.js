function attachGradientEvents() {
    const result = document.querySelector('#result');
    const gradient = document.querySelector('#gradient');

    gradient.addEventListener('mousemove', function (e) {
        const res = e.offsetX / (e.target.clientWidth - 1);
        const percent = Math.floor(res * 100);

        result.textContent = `${percent}%`;
    });
    gradient.addEventListener('mouseout', function () {
        result.textContent = '';
    });
}