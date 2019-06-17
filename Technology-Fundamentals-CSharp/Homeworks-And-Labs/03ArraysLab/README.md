# Lab: Arrays

## 1. Day of Week

Enter a day number [1…7] and print the name (in English) or &quot;Invalid day!&quot;

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 | Monday |
| 2 | Wednesday |
| 10 | Invalid day! |

## 2. Print Numbers in Reverse Order

Read n numbers and print them in reverse order.

### Examples


| **Input** | **Output** |
| --- | --- |
| 3 | 30 20 10
| 10 | |
| 20 | |
| 30 | |
| **Input** | **Output** |
| 3 | 10 20 30 |
| 30 | |
| 20 | |
| 10 | |
| **Input** | **Output** |
| 1 | 10 |
| 10 | |


## 3. Rounding Numbers

Read an array of real numbers (space separated), round them in &quot; **away from 0**&quot; style and print the output as in the examples:

### Examples

| **Input** | **Output** |
| --- | --- |
| 0.9 1.5 2.4 2.5 3.14 | 0.9 =\> 1 |
| | 1.5 =\> 2 |
| | 2.4 =\> 2 |
| | 2.5 =\> 3 |
| | 3.14 =\> 3 |
| **Input** | **Output** |
| -5.01 -1.599 -2.5 -1.50 0 | -5.01 =\> -5 |
| | -1.599 =\> -2 |
| | -2.5 =\> -3 |
| | -1.50 =\> -2 |
| | 0 =\> 0 |

## 4. Reverse Array of Strings

Read an array of strings (space separated values), reverse it and print its elements:

### Examples

| **Input** | **Output** |
| --- | --- |
| a b c d e | e d c b a |
| -1 hi ho w | w ho hi -1 |

## 5. Sum Even Numbers

Read an array from the console and sum only the even numbers.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 2 3 4 5 6 | 12 |
| 3 5 7 9 | 0 |
| 2 4 6 8 10 | 30 |

## 6. Even and Odd Subtraction

Write a program that calculates the difference between the sum of the even and the sum of the odd numbers in an array.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 2 3 4 5 6 | 3 |
| 3 5 7 9 | -24 |
| 2 4 6 8 10 | 30 |

## 7. Equal Arrays

Read two arrays and print on the console whether they are identical or not. Arrays are identical if their elements are equal. If the arrays are identical find the sum of the first one and print on the console following message: &quot;Arrays are identical. Sum: {sum}&quot;, otherwise find the first index where the arrays differ and print on the console following message: &quot;Arrays are not identical. Found difference at {index} index&quot;.

### Examples

| **Input** | **Output** |
| --- | --- |
| 10 20 30 | Arrays are identical. Sum: 60 |
| 10 20 30 |  |
| **Input** | **Output** |
| 1 2 3 4 5 | Arrays are not identical. Found difference at 2 index |
| 1 2 4 3 5 |  |
| **Input** | **Output** |
| 1 | Arrays are not identical. Found difference at 0 index |
| 10 | |

## 8. Condense Array to Number

Write a program to read **an array of integers** and **condense** them by **summing** adjacent couples of elements until a **single integer** is obtained. For example, if we have 3 elements {2, 10, 3}, we sum the first two and the second two elements and obtain {2+10, 10+3} = {12, 13}, then we sum again all adjacent elements and obtain {12+13} = {25}.

### Examples

| **Input** | **Output** |
| --- | --- |
| 2 10 3 | 25 |
| 5 0 4 1 2 | 35 |
| 1 | 1 |
