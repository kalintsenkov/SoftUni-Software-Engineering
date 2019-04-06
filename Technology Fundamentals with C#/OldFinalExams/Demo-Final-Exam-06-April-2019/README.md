# Problem 1. Dictionary

Your task is to take every word and **insert it** into the dictionary **with its definition**. A word may have **one or more definitions**. You will receive all the words and definitions, separated by **&quot; | &quot;** , and each word and its definition will be separated by **&quot;: &quot;**.

After this you will have to check the words you have in the dictionary. Now you will receive only words, again separated by **&quot; | &quot;**. For **each word** you get you will have to print it and **all of its definitions,** ordered by **length** of the definition **in descending order** ( **if it exists in the dictionary** ) in the following format:

**&quot;{word}:&quot;**

**&quot; –{definition1}&quot;**

**&quot; –{definition2}&quot;**

**&quot; –{definition3}&quot;**

**. . .**

In the end, you will receive one more command, which will be either **&quot;End&quot;** or **&quot;List&quot;**. If the command is **&quot;End&quot;** , you should break the program. If the command is **&quot;List&quot;** , you should print all of the words, ordered alphabetically, separated by space ( **&quot; &quot;** ).

## Input

Three **strings**. The first one will have pairs of words and descriptions, separated by **&quot; | &quot;** and each word separated from its description by **&quot;: &quot;**. The second **string** will have only words, separated by **&quot; | &quot;**. The third **string** will be a command – either **&quot;End&quot;** or **&quot;List&quot;**.

## Output

For **each word** that is called you have to print it **with all of its definitions ordered by their length (descending)**. In the end you have to print **all the words, ordered alphabetically** , separated by **a single space** if you have the command **&quot;List&quot;**.  For all of the words you have to print them in the format:

**&quot;{word}:&quot;**

**&quot; –{definition1}&quot;**

**&quot; –{definition2}&quot;**

**&quot; –{definition3}&quot;**

**. . .**

## Examples

| **Input** |
| --- |
| programmer: an animal, which turns coffee into code | developer: a magicianPesho | GoshoList |
| **Output** |
| developer programmer |

| **Input** |
| --- |
| tackle: the equipment required for a task or sport | code: write code for a computer program | bit: a small piece, part, or quantity of something | tackle: make determined efforts to deal with a problem | bit: a short time or distancebit | code | tackleEnd |
| **Output** |
| bit -a small piece, part, or quantity of something -a short time or distancecode -write code for a computer programtackle -make determined efforts to deal with a problem -the equipment required for a task or sport |

# Problem 2. Deciphering

You will receive **two lines**. The first one will have an **encrypted string** , which you will have to decode. On the second line you will receive **two letters or substrings** , separated by **a single space**.
First you will have to decode the first line by **reducing** the ASCII value of each character in it **by 3**. Then you should get the **two substrings** of the second line. You must find **every** occurrence of the **first substring** in the now decrypted text and replace it with the **second substring**.

Also, you don&#39;t know which book you have taken, so you must check if it is **valid**. A valid text contains only lowercase letters, from **&#39;d&#39;** onwards, and the symbols **&#39;{&#39;** , **&#39;}&#39;** , **&#39;|&#39;** , **&#39;#&#39;**. If the text is invalid, you should not try to decipher it and you should print **&quot;This is not the book you are looking for.&quot;**.

## Input

Two lines, one with text to decipher and one with two substrings to replace in the text.

## Output

One line with the deciphered text.

## Examples

| **Input** |
| --- |
| wkhfn#|rx#jhqfkr#phf#exw#|rxu#uholf#lv#khfgohg#lq#hfrwkhu#sohfhwec an |
| **Output** |
| thank you gencho man but your relic is handled in another planet |

| **Input** |
| --- |
| arx#vkdww#qrw#sdvvt l |
| **Output** |
| This is not the book you are looking for. |