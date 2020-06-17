'use strict'

function solve() {
    return {
        extend (template) {
            for (const property in template) {
            
                if (typeof template[property] === 'function') {
                    const proto = Object.getPrototypeOf(this);
                    proto[property] = template[property];
                } else {
    
                    this[property] = template[property];
                }
            }
        }
    };
}

const obj = solve();

obj.extend({
    extensionMethod: function () { },
    extensionProperty: 'someString'
});