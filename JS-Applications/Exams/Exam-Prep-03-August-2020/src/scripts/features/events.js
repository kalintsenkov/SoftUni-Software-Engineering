import { showSuccess, showError } from '../notification.js';
import { createEvent, editEvent, deleteEvent, getEventById, joinEvent } from '../data.js';

export async function createGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/events/organize.hbs', this.app.userData);
}

export async function createPost() {
    const areValid = areParamsValid(
        this.params.name,
        this.params.dateTime,
        this.params.description,
        this.params.imageURL);

    if (!areValid) {
        return;
    }

    const event = {
        name: this.params.name,
        dateTime: this.params.dateTime,
        description: this.params.description,
        imageURL: this.params.imageURL,
        organizer: this.app.userData.username,
        interested: 0
    };

    this.app.userData.hasEvents = true;

    try {
        const result = await createEvent(event);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Event created successfully.');
        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function details() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    const data = await getEventById(this.params.id);

    if (data.ownerId === this.app.userData.userId) {
        data.isMine = true;
    }

    Object.assign(data, this.app.userData);

    this.partial('./templates/events/details.hbs', data);
}

export async function editGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    const data = await getEventById(this.params.id);

    Object.assign(data, this.app.userData);

    this.partial('./templates/events/edit.hbs', data);
}

export async function editPost() {
    const areValid = areParamsValid(
        this.params.name,
        this.params.dateTime,
        this.params.description,
        this.params.imageURL);

    if (!areValid) {
        return;
    }

    const updatedPost = {
        name: this.params.name,
        dateTime: this.params.dateTime,
        description: this.params.description,
        imageURL: this.params.imageURL
    };

    try {
        const result = await editEvent(this.params.id, updatedPost);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Event edited successfully.');
        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function deleteGet() {
    const eventId = this.params.id;
    const confirmed = confirm('Are you sure you want to close this event?')

    if (!confirmed) {
        return this.redirect('#/details/' + eventId);
    }

    try {
        const result = await deleteEvent(eventId);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Event closed successfully.');
        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function join() {
    const eventId = this.params.id;
    const confirmed = confirm('Are you sure you want to join this event?')

    if (!confirmed) {
        return this.redirect('#/details/' + eventId);
    }

    try {
        const event = await getEventById(eventId);

        if (event.ownerId === this.app.userData.userId) {
            showError('You cannot join an event, organized by yourself.');
            return;
        }

        const interested = Number(event.interested);

        const result = await joinEvent(eventId, interested + 1);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('You join the event successfully.');
        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

function areParamsValid(name, dateTime, description, imageURL) {
    if (name.length < 6) {
        showError('Event name should be at least 6 characters long');
        return false;
    }

    if (dateTime.length == 0) {
        showError('Event date is required');
        return false;
    }

    if (description.length < 10) {
        showError('Event description should be at least 10 characters long.');
        return false;
    }

    if (!imageURL.startsWith('http://') && !imageURL.startsWith('https://')) {
        showError('Event image should be valid URL.');
        return false;
    }

    return true;
}