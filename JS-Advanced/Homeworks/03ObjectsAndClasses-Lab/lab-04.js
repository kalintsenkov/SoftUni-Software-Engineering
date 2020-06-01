'use strict'

function fromJSONToHTMLTable(input) {
    let result = '';

    const parsed = Array.from(JSON.parse(input));
    const keys = Array.from(getKeys(parsed));

    result += '<table>\n';
    result += `\t<tr><th>${keys.join('</th><th>')}</th></tr>\n`;

    parsed.forEach(element => {
        result += '\t<tr>';

        keys.forEach(key => {
            const value = escapeHtml(element[key]);
            result += `<td>${value}</td>`;
        });

        result += '</tr>\n';
    });

    return result + '</table>'

    function getKeys(arr) {
        const keys = new Set();
        for (const object of arr) {
            for (const key in object) {
                keys.add(key);
            }
        }

        return keys;
    }

    function escapeHtml(unsafe) {
        return unsafe.toString()
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;")
    }
}