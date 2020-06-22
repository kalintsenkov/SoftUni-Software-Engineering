'use strict'

(function() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }
    
    Array.prototype.skip = function (n) {
        const arr = [];
        for (let i = n; i < this.length; i++) {
            arr.push(this[i]);
        }
        return arr;
    }

    Array.prototype.take = function (n) {
        const arr = [];
        for (let i = 0; i < n; i++) {
            arr.push(this[i]);
        }
        return arr;
    }

    Array.prototype.sum = function () {
        let result = 0;
        this.map(i => result += Number(i));
        return result;
    }

    Array.prototype.average = function () {
        let result = 0;
        this.map(i => result += Number(i));
        return result / this.length;
    }
})();