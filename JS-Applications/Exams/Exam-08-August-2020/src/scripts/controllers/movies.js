import { showSuccess, showError } from '../notifications.js';
import { createMovie, editMovie, deleteMovie, getMovieById } from '../data.js';

export async function getCreate() {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs')
    };

    this.partial('./views/movies/create.hbs', this.app.userData);
}

export async function postCreate() {
    const title = this.params.title;
    const description = this.params.description;
    const imageUrl = this.params.imageUrl;

    const areValid = areParamsValid(title, description, imageUrl);

    if (!areValid) {
        return;
    }

    const movie = {
        title,
        description,
        imageUrl,
        creator: localStorage.getItem('email')
    };

    try {
        const result = await createMovie(movie);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Created successfully!');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function getDetails() {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs')
    };

    const data = await getMovieById(this.params.id);

    if (data.likes) {
        data.likesCount = data.likes.split(', ').length;
    }

    if (data.ownerId === this.app.userData.userId) {
        data.isMine = true;
    }

    Object.assign(data, this.app.userData);

    await this.partial('./views/movies/details.hbs', data);

    const likeBtn = document.querySelector('.btn.btn-primary');
    const likedSpan = document.querySelector('#liked');

    if (data.likes) {
        let likes = data.likes.split(', ');

        if (likes.includes(this.app.userData.email)) {
            likeBtn.style.display = 'none';
            likedSpan.style.display = '';
        } else {
            likedSpan.style.display = 'none';
            likeBtn.style.display = '';
        }
    } else {
        likedSpan.style.display = 'none';
        likeBtn.style.display = '';
    }
}

export async function getEdit() {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs')
    };

    const data = await getMovieById(this.params.id);

    Object.assign(data, this.app.userData);

    this.partial('./views/movies/edit.hbs', data);
}

export async function postEdit() {
    const movieId = this.params.id;
    const movie = await getMovieById(movieId);

    if (movie.ownerId !== this.app.userData.userId) {
        showError('You cannot edit this movie');
        return this.redirect('#/details/' + movieId);
    }

    const title = this.params.title;
    const description = this.params.description;
    const imageUrl = this.params.imageUrl;

    const areValid = areParamsValid(title, description, imageUrl);

    if (!areValid) {
        return;
    }

    const updated = {
        title,
        description,
        imageUrl
    };

    try {
        const result = await editMovie(movieId, updated);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Edited successfully.');

        this.redirect('#/details/' + result.objectId);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function getDelete() {
    const movieId = this.params.id;
    const confirmed = confirm('Are you sure you want to delete this movie?')

    if (!confirmed) {
        return this.redirect('#/details/' + movieId);
    }

    const movie = await getMovieById(movieId);

    if (movie.ownerId !== this.app.userData.userId) {
        showError('You cannot delete this movie');
        return this.redirect('#/details/' + movieId);
    }

    try {
        const result = await deleteMovie(movieId);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Deleted successfully');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function getLike() {
    const movieId = this.params.id;
    const confirmed = confirm('Are you sure you want to like this movie?');

    if (!confirmed) {
        return this.redirect('#/details/' + movieId);
    }

    try {
        const movie = await getMovieById(movieId);

        if (!this.app.userData.loggedIn) {
            showError('Please login');
            return this.redirect('#/login');
        }

        if (movie.ownerId === this.app.userData.userId) {
            showError('You cannot like movie, created by yourself');
            return this.redirect('#/details/' + movieId);
        }

        let likes = movie.likes;

        if (!likes) {
            likes = this.app.userData.email;
        } else {
            likes = likes.split(', ');

            if (likes.includes(this.app.userData.email)) {
                showError('You have already liked this movie');
                return this.redirect('#/details/' + movieId);
            }

            likes.push(this.app.userData.email);
            likes = likes.join(', ');
        }

        movie.likes = likes;

        const result = await editMovie(movieId, movie);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Liked successfully');

        this.redirect('#/details/' + movieId);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

function areParamsValid(title, description, imageUrl) {
    if (!title) {
        showError('Title shouldn’t be empty.');
        return false;
    }

    if (!description) {
        showError('Description shouldn’t be empty.');
        return false;
    }

    if (!imageUrl) {
        showError('Image URL shouldn’t be empty.');
        return false;
    }

    return true;
}
