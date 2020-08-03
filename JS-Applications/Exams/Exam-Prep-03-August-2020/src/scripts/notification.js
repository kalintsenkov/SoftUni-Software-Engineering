const elements = {
    success: document.querySelector('#successBox'),
    error: document.querySelector('#errorBox'),
    loading: document.querySelector('#loadingBox')
};

elements.success.addEventListener('click', hideSuccess);
elements.error.addEventListener('click', hideError);

export function showSuccess(message) {
    elements.success.textContent = message;
    elements.success.style.display = 'block';

    setTimeout(hideSuccess, 3000);
}

export function showError(message) {
    elements.error.textContent = message;
    elements.error.style.display = 'block';

    setTimeout(hideError, 3000);
}

let requests = 0;

export function beginRequest() {
    requests++;
    elements.loading.style.display = 'block';
}

export function endRequest() {
    requests--;
    if (requests === 0) {
        elements.loading.style.display = 'none';
    }
}

function hideSuccess() {
    elements.success.style.display = 'none';
}

function hideError() {
    elements.error.style.display = 'none';
}