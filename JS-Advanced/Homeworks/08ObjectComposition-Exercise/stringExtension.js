'use strict'

(function () {
    String.prototype.ensureStart = function (str) {
        if (this.toString().startsWith(str)) {
            return this.toString();
        }

        return str + this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if (this.toString().endsWith(str)) {
            return this.toString();
        }

        return this.toString() + str;
    };

    String.prototype.isEmpty = function () {
        return this.toString().length === 0;
    };

    String.prototype.truncate = function (n) {
        if (n <= 3) {
            return ".".repeat(n);
        }

        if (this.length <= n) {
            return this.toString();
        } else {
            let lastIndex = this.toString().substring(0, n - 2).lastIndexOf(" ");

            if (lastIndex != -1) {
                return this.toString().substring(0, lastIndex) + "...";
            } else {
                return this.toString().substring(0, n - 3) + "...";
            }
        }
    };

    String.format = function (string, ...params) {
        var args = [...params];
        return string.replace(
            /{(\d+)}/g,
            (match, number) => typeof args[number] != 'undefined'
                ? args[number]
                : match);
    };
})();