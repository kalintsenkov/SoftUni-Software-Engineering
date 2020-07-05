module.exports.isSymmetric = (arr) => {
    if (!Array.isArray(arr)) {
        return false;
    }

    let reversed = arr.slice(0).reverse();

    return JSON.stringify(arr) == JSON.stringify(reversed);
}