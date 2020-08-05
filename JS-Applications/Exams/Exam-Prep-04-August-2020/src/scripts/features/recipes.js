import { showSuccess, showError } from '../notifications.js';
import { share, edit, archive, getById, like } from '../data.js';

export async function getShare() {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs')
    };

    this.partial('./views/recipes/share.hbs', this.app.userData);
}

export async function postShare() {
    const meal = this.params.meal;
    const ingredients = this.params.ingredients;
    const prepMethod = this.params.prepMethod;
    const description = this.params.description;
    const foodImageURL = this.params.foodImageURL;
    const category = this.params.category;

    const areValid = areParamsValid(meal, ingredients, prepMethod, description, foodImageURL, category);

    if (!areValid) {
        return;
    }

    const receipt = {
        meal,
        ingredients,
        prepMethod,
        description,
        foodImageURL,
        category,
        likesCounter: 0,
        categoryImageURL: getCategoryImageURL(category)
    };

    try {
        const result = await share(receipt);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Recipe shared successfully!');

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

    const data = await getById(this.params.id);
    data.ingredients = data.ingredients.split(', ');

    if (data.ownerId === this.app.userData.userId) {
        data.isMine = true;
    }

    Object.assign(data, this.app.userData);

    this.partial('./views/recipes/details.hbs', data);
}

export async function getEdit() {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs')
    };

    const data = await getById(this.params.id);

    Object.assign(data, this.app.userData);

    this.partial('./views/recipes/edit.hbs', data);
}

export async function postEdit() {
    const meal = this.params.meal;
    const ingredients = this.params.ingredients;
    const prepMethod = this.params.prepMethod;
    const description = this.params.description;
    const foodImageURL = this.params.foodImageURL;
    const category = this.params.category;

    const areValid = areParamsValid(meal, ingredients, prepMethod, description, foodImageURL, category);

    if (!areValid) {
        return;
    }

    const updatedPost = {
        meal,
        ingredients,
        prepMethod,
        description,
        foodImageURL,
        category,
        categoryImageURL: getCategoryImageURL(category)
    };

    try {
        const result = await edit(this.params.id, updatedPost);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Recipe edited successfully.');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function getArchive() {
    const recipeId = this.params.id;
    const confirmed = confirm('Are you sure you want to archive this recipe?')

    if (!confirmed) {
        return this.redirect('#/details/' + recipeId);
    }

    try {
        const result = await archive(recipeId);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('Recipe archived successfully.');

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function getLike() {
    const recipeId = this.params.id;
    const confirmed = confirm('Are you sure you want to like this recipe?');

    if (!confirmed) {
        return this.redirect('#/details/' + recipeId);
    }

    try {
        const recipe = await getById(recipeId);

        if (!this.app.userData.loggedIn) {
            showError('Please login.');
            return this.redirect('#/details/' + recipeId);
        }

        if (recipe.ownerId === this.app.userData.userId) {
            showError('You cannot like recipe, shared by yourself.');
            return this.redirect('#/details/' + recipeId);
        }

        const likes = Number(recipe.likesCounter);

        const result = await like(recipeId, likes + 1);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('You liked that recipe.');

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

function areParamsValid(meal, ingredients, prepMethod, description, foodImageURL, category) {
    if (meal.length < 4) {
        showError('Meal should be at least 4 characters long');
        return false;
    }

    const ingredientsArr = ingredients.split(', ');

    if (ingredientsArr.length < 2) {
        showError('Ingredients should be at least 2');
        return false;
    }

    if (prepMethod.length < 10 || description.length < 10) {
        showError('Preparation method and description should be at least 10 characters long.');
        return false;
    }

    if (!foodImageURL.startsWith('http://') && !foodImageURL.startsWith('https://')) {
        showError(`Image URL should start with "http://" or "https://".`);
        return false;
    }

    if (!isCategoryValid(category)) {
        showError('Invalid category.');
        return false;
    }

    return true;
}

function isCategoryValid(category) {
    const validCategories = [
        'Vegetables and legumes/beans',
        'Fruits',
        'Grain Food',
        'Milk, cheese, eggs and alternatives',
        'Lean meats and poultry, fish and alternatives'
    ];

    return validCategories.includes(category);
}

function getCategoryImageURL(category) {
    const categoryImageMap = {
        'Vegetables and legumes/beans': 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/shopping-bag-full-of-fresh-vegetables-and-fruits-royalty-free-image-1128687123-1564523576.jpg?crop=1.00xw:0.751xh;0,0.212xh&resize=1200:*',
        'Grain Food': 'https://w7.pngwing.com/pngs/426/561/png-transparent-bread-and-pastry-illustration-carbohydrate-cereal-food-dietary-fiber-whole-grain-bagel-natural-foods-nutrition-eating.png',
        'Fruits': 'https://upload.wikimedia.org/wikipedia/commons/2/2f/Culinary_fruits_front_view.jpg',
        'Milk, cheese, eggs and alternatives': 'https://media.wsimag.com/attachments/e93e9eb9c2850d7ffe69d0383ed27baf224eafd3/store/fill/690/388/35defd11ef8de6b2a0af60645188fd44f1fdcc1e7ed397421e56f58cd7c7/Eggs-milk-and-cheese.jpg',
        'Lean meats and poultry, fish and alternatives': 'https://i2.wp.com/www.daybyday.website/wp-content/uploads/2018/10/Nuts-And-Lean-Meat.jpeg?resize=618%2C412&ssl=1'
    }

    return categoryImageMap[category];
}
