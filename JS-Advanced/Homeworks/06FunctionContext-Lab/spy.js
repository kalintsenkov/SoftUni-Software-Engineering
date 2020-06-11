'use strict'

function Spy(target, method) {
    const originalFunction = target[method];

    let result = {
        count: 0
    };

    target[method] = function () {
        result.count++;
        return originalFunction.apply(this, arguments);
    }

    return result;
}

const obj = {
    method: () => "invoked"
};

const spy = Spy(obj, "method");

obj.method();
obj.method();
obj.method();

console.log(spy) // { count: 3 }