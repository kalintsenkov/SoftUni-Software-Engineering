'use strict'

function solve(jsonString) {
    let result = '<table>\n';

    for (const row of jsonString) {
        result += '\t<tr>\n';

        const object = JSON.parse(row);

        for (const key in object) {
            if (object.hasOwnProperty(key)) {
                result += `\t\t<td>${escapeHTML(object[key])}</td>\n`;
            }
        }

        result += '\t</tr>\n';
    }

    return result + '</table>';

    function escapeHTML(input) {
        return input.toString()
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }
}