const elements = {
    success: document.querySelector('#successBox'),
    error: document.querySelector('#errorBox')
};

elements.success.addEventListener('click', hideSuccess);
elements.error.addEventListener('click', hideError);

export function showSuccess(message) {
    elements.success.textContent = message;
    elements.success.parentElement.style.display = 'block';

    setTimeout(hideSuccess, 1000);
}

export function showError(message) {
    elements.error.textContent = message;
    elements.error.parentElement.style.display = 'block';

    setTimeout(hideError, 1000);
}

function hideSuccess() {
    elements.success.parentElement.style.display = 'none';
}

function hideError() {
    elements.error.parentElement.style.display = 'none';
}
