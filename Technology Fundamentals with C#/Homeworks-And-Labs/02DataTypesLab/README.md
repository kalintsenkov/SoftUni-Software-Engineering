# 1.Lab: Data Types and Variables

1. 1.Convert Meters to Kilometers

You will be given an integer that will be distance in meters. Write a program that converts meters to kilometers formatted to the second decimal point.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1852 | 1.85 |
| 798 | 0.80 |

1. 2.Pounds to Dollars

Write a program that converts British pounds to US dollars formatted to 3th decimal point.

1 British Pound = 1.31 Dollars

### Examples

| **Input** | **Output** |
| --- | --- |
| 80 | 104.800 |
| 39 | 51.090 |

1. 3.Exact Sum of Real Numbers

Write program to enter **n** numbers and calculate and print their **exact sum** (without rounding).

### Examples

| **Input** | **Output** |
| --- | --- |
| 31000000000000000000510 | 1000000000000000015  |
| 20.00000000003333333333333.3 | 333333333333.30000000003 |

### Hints

Use **BigInteger** to not lose precision.

1. 4.Centuries to Minutes

Write program to enter an integer number of **centuries** and convert it to **years** , **days** , **hours** and **minutes**.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 | 1 centuries = 100 years = 36524 days = 876576 hours = 52594560 minutes |
| 5 | 5 centuries = 500 years = 182621 days = 4382904 hours = 262974240 minutes |

### Hints

- Use appropriate data type to fit the result after each data conversion.
- Assume that a year has 2422 days at average ([the Tropical year](https://en.wikipedia.org/wiki/Tropical_year)).

1. 5.Special Numbers

A **number** is **special** when its **sum of digits is 5, 7 or 11**.

Write a program to read an integer **n** and for all numbers in the range **1…n** to print the number and if it is specialor not ( **True** / **False** ).

### Examples

| **Input** | **Output** |
| --- | --- |
| 15 | 1 -\&gt; False2 -\&gt; False3 -\&gt; False4 -\&gt; False5 -\&gt; True6 -\&gt; False7 -\&gt; True8 -\&gt; False9 -\&gt; False10 -\&gt; False11 -\&gt; False12 -\&gt; False13 -\&gt; False14 -\&gt; True15 -\&gt; False |

### Hints

To calculate the sum of digits of given number **num** , you might repeat the following: sum the last digit ( **num**** % ****10** ) and remove it ( **sum**** = ****sum**** / ****10** ) until **num** reaches **0**.

1. 6.Reversed Chars

Write a program that takes 3 lines of characters and prints them in reversed order with a space between them.

### Examples

| **Input** | **Output** |
| --- | --- |
| ABC | C B A |
| 1L&amp; | &amp; L 1 |

1. 7.Concat Names

Read two names and a delimiter. Print the names joined by the delimiter.

### Examples

| **Input** | **Output** |
| --- | --- |
| JohnSmith-\&gt; | John-\&gt;Smith |
| JanWhite\&lt;-\&gt; | Jan\&lt;-\&gt;White |
| LindaTerry=\&gt; | Linda=\&gt;Terry |

1. 8.Town Info

You will be given 3 lines of input. On the first line you will be given the name of the town, on the second – the population and on the third the area. Use the correct data types and print the result in the following format:

&quot; **Town {town name} has population of {population} and area {area} square km**&quot;.

### Examples

| **Input** | **Output** |
| --- | --- |
| Sofia1286383492 | Town Sofia has population of 1286383 and area 492 square km. |

1. 9.Chars to String

Write a program that reads 3 lines of input. On each line you get a single character. Combine all the characters into one string and print it on the console.

### Examples

| **Input** | **Output** |
| --- | --- |
| abc | abc |
| %2o | %2o |
| 15p | 15p |

1. 10.Lower or Upper

Write a program that prints whether a given character is upper-case or lower case.

### Examples

| **Input** | **Output** |
| --- | --- |
| L | upper-case |
| f | lower-case |