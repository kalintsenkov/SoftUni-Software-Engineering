'use strict'

function lowestPriceInCities(input) {
    let products = new Map;
    for (let priceList of input) {
        let [town, product, price] = priceList.split(' | ');
        if (!products.has(product)) {
            products.set(product, new Map);
        }
        products.get(product).set(town, Number(price));
    }

    for (let [product, towns] of products) {
        let minPrice = Number.MAX_VALUE;
        let minPriceTown = '';
        
        for (let [town, price] of towns) {

            if (price < minPrice) {
                minPrice = price;
                minPriceTown = town;
            }
        }

        console.log(`${product} -> ${minPrice} (${minPriceTown})`);
    }
}