module.exports.sum = (arr) => {
    let sum = 0;
    for (num of arr) {
        sum += Number(num);
    }

    return sum;
}