import { createPost, editPost, deletePost, getPostById, getPosts } from '../data.js';

export async function create() {
    const post = {
        title: this.params.title,
        category: this.params.category,
        content: this.params.content
    };

    if (Object.values(post).some(value => value.length === 0)) {
        alert('All fields are required!');
        return;
    }

    try {
        const result = await createPost(post);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        alert(error.message);
    }
}

export async function details() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs')
    };

    const data = await getPostById(this.params.id);

    Object.assign(data, this.app.userData);

    this.partial('./templates/posts/details.hbs', data);
}

export async function editGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        postArticle: await this.load('./templates/posts/postArticle.hbs')
    };

    const post = await getPostById(this.params.id);
    const posts = await getPosts();

    const data = Object.assign({}, post, { posts }, this.app.userData);

    this.partial('./templates/posts/edit.hbs', data);
}

export async function edit() {
    const newPost = {
        title: this.params.title,
        category: this.params.category,
        content: this.params.content
    };

    if (Object.values(newPost).some(value => value.length === 0)) {
        alert('All fields are required!');
        return;
    }

    try {
        const result = await editPost(this.params.id, newPost);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        alert(error.message);
    }
}

export async function deleteGet() {
    const confirmed = confirm('Are you sure you want to delete this post?')

    if (!confirmed) {
        return this.redirect('#/home');
    }

    try {
        const result = await deletePost(this.params.id);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        alert(error.message);
    }
}