# Lab: Data Types and Variables

## 1. Convert Meters to Kilometers

You will be given an integer that will be distance in meters. Write a program that converts meters to kilometers formatted to the second decimal point.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1852 | 1.85 |
| 798 | 0.80 |

## 2. Pounds to Dollars

Write a program that converts British pounds to US dollars formatted to 3th decimal point.

1 British Pound = 1.31 Dollars

### Examples

| **Input** | **Output** |
| --- | --- |
| 80 | 104.800 |
| 39 | 51.090 |

## 3. Exact Sum of Real Numbers

Write program to enter **n** numbers and calculate and print their **exact sum** (without rounding).

### Examples

| **Input** | **Output** |
| --- | --- |
| 3 | 1000000000000000015 |
| 1000000000000000000 | |
| 5 | |
| 10 |  |
| **Input** | **Output** |
| 2 | 333333333333.30000000003 |
| 0.00000000003 | |
| 333333333333.3 | |

### Hints

Use **BigInteger** to not lose precision.

## 4. Centuries to Minutes

Write program to enter an integer number of **centuries** and convert it to **years** , **days** , **hours** and **minutes**.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 | 1 centuries = 100 years = 36524 days = 876576 hours = 52594560 minutes |
| 5 | 5 centuries = 500 years = 182621 days = 4382904 hours = 262974240 minutes |

### Hints

- Use appropriate data type to fit the result after each data conversion.
- Assume that a year has 2422 days at average ([the Tropical year](https://en.wikipedia.org/wiki/Tropical_year)).

## 5. Special Numbers

A **number** is **special** when its **sum of digits is 5, 7 or 11**.

Write a program to read an integer **n** and for all numbers in the range **1…n** to print the number and if it is specialor not ( **True** / **False** ).

### Examples

| **Input** | **Output** |
| --- | --- |
| 15 | 1 -\> False |
| | 2 -\> False |
| | 3 -\> False |
| | 4 -\> False |
| | 5 -\> True |
| | 6 -\> False|
| | 7 -\> True|
| | 8 -\> False|
| | 9 -\> False|
| | 10 -\> False|
| | 11 -\> False|
| | 12 -\> False|
| | 13 -\> False|
| | 14 -\> True|
| | 15 -\> False |

### Hints

To calculate the sum of digits of given number **num** , you might repeat the following: sum the last digit ( **num** % **10** ) and remove it ( **sum** = **sum** / **10** ) until **num** reaches **0**.

## 6. Reversed Chars

Write a program that takes 3 lines of characters and prints them in reversed order with a space between them.

### Examples

| **Input** | **Output** |
| --- | --- |
| A | C B A |
| B | |
| C | |
| **Input** | **Output** |
| 1 | &amp; L 1 |
| L | |
| \& | |

## 7. Concat Names

Read two names and a delimiter. Print the names joined by the delimiter.

### Examples

| **Input** | **Output** |
| --- | --- |
| John | John-\>Smith |
| Smith | |
| -\> |  |
| **Input** | **Output** |
| Jan |
| White|
|\<-\> | Jan\<-\>White |
| **Input** | **Output** |
| Linda | Linda=\>Terry |
| Terry | |
| =\> |  |

## 8. Town Info

You will be given 3 lines of input. On the first line you will be given the name of the town, on the second – the population and on the third the area. Use the correct data types and print the result in the following format:

&quot; **Town {town name} has population of {population} and area {area} square km** &quot;.

### Examples

| **Input** | **Output** |
| --- | --- |
| Sofia | Town Sofia has population of 1286383 and area 492 square km. |
| 1286383 | |
| 492 |  |

## 9. Chars to String

Write a program that reads 3 lines of input. On each line you get a single character. Combine all the characters into one string and print it on the console.

### Examples

| **Input** | **Output** |
| --- | --- |
| a | abc |
| b | |
| c | |
| **Input** | **Output** |
| % | %2o |
| 2 | |
| o | |
| **Input** | **Output** |
| 1 | 15p |
| 5 | |
| p | |

## 10. Lower or Upper

Write a program that prints whether a given character is upper-case or lower case.

### Examples

| **Input** | **Output** |
| --- | --- |
| L | upper-case |
| f | lower-case |
