# Exercises: Arrays

## 1. Train

You will be given a count of wagons in a train **n**. On the next **n** lines you will receive how many people are going to get on each wagon. At the end print the whole train and after that the sum of the people in the train.

### Examples

| **Input** | **Output** |
| --- | --- |
| 3 | 13 24 8 |
| 13 | 45 |
| 24 | |
| 8 |  |
| **Input** | **Output** |
| 6 | 3 52 71 13 65 4 |
| 3 | 208 |
| 52 | |
| 71 | |
| 13 | |
| 65 | |
| 4 | |
| **Input** | **Output** |
| 1 | 100 |
|100 | 100 |

## 2.Common Elements

Write a program, which prints common elements in two arrays. You have to compare the elements of the second array to the elements of the first.

### Examples

| **Input** | **Output** |
| --- | --- |
| Hey hello 2 4 | 4 hello |
| 10 hey 4 hello |  |
| **Input** | **Output** |
| S of t un i | of i un |
| of i 10 un |  |
| **Input** | **Output** |
| i love to code | code i love to |
|code i love to |  |

## 3. Zig-Zag Arrays

Write a program which creates 2 arrays. You will be given an integer **n**. On the next **n** lines you get 2 integers. Form 2 arrays as shown below.

### Examples

| **Input** | **Output** |
| --- | --- |
| 4 | 1 10 31 20 |
| 1 5 |  5 9 81 41 |
| 9 10 | |
| 31 81 | |
| 41 20 | |
| **Input** | **Output** |
| 2 | 80 19 |
| 80 23 | 23 31 |
| 31 19 |  |

## 4. Array Rotation

Write a program that receives an array and number of rotations you have to perform (first element goes at the end) Print the resulting array.

### Examples

| **Input** | **Output** |
| --- | --- |
| 51 47 32 61 21 | 32 61 21 51 47 |
| 2 |  |
| **Input** | **Output** |
| 32 21 61 1 | 32 21 61 1 |
| 4 |  |
| **Input** | **Output** |
| 2 4 15 31 | 4 15 31 2 |
| 5 |  |

## 5. Top Integers

Write a program to find all the top integers in an array. A top integer is an integer which is **bigger** than all the elements to its right.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 4 3 2 | 4 3 2 |
| 14 24 3 19 15 17 | 24 19 17 |
| 27 19 42 2 13 45 48 | 48 |

## 6. Equal Sums

Write a program that determines if there **exists an element in the array** such that the **sum of the elements on its left** is **equal** to the **sum of the elements on its right**. If there are **no elements to the left / right** , their **sum is considered to be 0**. Print the **index** that satisfies the required condition or **&quot;no&quot;** if there is no such index.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 2 3 3 | 2 |
| 1 2 | no |
| 1 | 0 |
| 1 2 3 | no |
| 10 5 5 99 3 4 2 5 1 1 4 | 3 |

## 7. Max Sequence of Equal Elements

Write a program that finds the **longest sequence of equal elements** in an array of integers. If several longest sequences exist, print the leftmost one.

### Examples

| **Input** | **Output** |
| --- | --- |
| 2 1 1 2 3 3 **2 2 2** 1 | 2 2 2 |
| **1 1 1** 2 3 1 3 3 | 1 1 1 |
| **4 4 4 4** | 4 4 4 4 |
| 0 **1 1** 5 2 2 6 3 3 | 1 1 |

## 8. Magic Sum

Write a program, which prints all unique pairs in an array of integers whose sum is equal to a given number.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 7 6 2 19 23 | 1 7 |
| 8 | 6 2 |
| **Input** | **Output** |
| 14 20 60 13 7 19 8 | 14 13 |
| 27 | 20 7 |
| | 19 8 |

## 9. Kamino Factory

The clone factory in Kamino got another order to clone troops. But this time you are tasked to find **the best DNA** sequence to use in the production.

You will receive the **DNA length** and until you receive the command **&quot;Clone them!&quot;** you will be receiving a **DNA sequences of ones and zeroes, split by &quot;!&quot; (one or several).**

You should select the sequence with the **longest subsequence of ones**. If there are several sequences with **same length of subsequence of ones**, print the one with the **leftmost starting index** , if there are several sequences with same **length and starting index** , select the sequence with the **greater sum** of its elements.

After you receive the last command **&quot;Clone them!&quot;** you should print the collected information in the following format:

&quot;Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.&quot;

&quot;{DNA sequence, joined by space}&quot;

### Input / Constraints

- The **first line** holds the **length** of the **sequences** – **integer in range [1…100];**
- On the next lines until you receive **&quot;Clone them!&quot;** you will be receiving sequences (at least one) of ones and zeroes, **split by &quot;!&quot;** (one or several).

###  Output

The output should be printed on the console and consists of two lines in the following format:

&quot;Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.&quot;

&quot;{DNA sequence, joined by space}&quot;

###  Examples

| **Input** | **Output** |
| --- | --- |
| 5 | Best DNA sample 2 with sum: 2. |
| 1!0!**1!1**!0 | 0 1 1 0 0 |
| 0!**1!1**!0!0| |
| Clone them! |  |
| **Input** | **Output** |
| 4 | Best DNA sample 1 with sum: 3. |
| **1!1**!0!**1**| 1 1 0 1 |
| 1!0!0!1| |
| **1!1**!0!0| |
| Clone them! |  |

## 10. LadyBugs

You are **given a field size** and the **indexes of ladybugs** inside the field. After that on every new line **until the &quot;end&quot; command** is given, a **ladybug changes its position** either to its **left or to its right by a given fly length**.

A **command to a ladybug** looks like this: &quot;**0 right 1**&quot;. This means that the little insect placed on index 0 should fly one index to its right. If the ladybug **lands on a fellow ladybug**, it **continues to fly** in the same direction **by the same fly length**. If the ladybug **flies out of the field, it is gone**.

For example, imagine you are given a field with size 3 and ladybugs on indexes 0 and 1. If the ladybug on index 0 needs to fly to its right by the length of 1 (0 right 1) it will attempt to land on index 1 but as there is another ladybug there it will continue further to the right by additional length of 1, landing on index 2. After that, if the same ladybug needs to fly to its right by the length of 1 (2 right 1), it will land somewhere outside of the field, so it flies away:

If you are given ladybug index that does not have ladybug there, nothing happens. If you are given ladybug index that is outside the field, nothing happens.

Your job is to create the program, simulating the ladybugs flying around doing nothing. At the end, **print all cells in the field separated by blank spaces**. For each cell that has a ladybug on it print &#39; **1**&#39; and for each empty cells print &#39; **0**&#39;. For the example above, the output should be **&#39;0 1 0&#39;**.

### Input

- On the first line you will receive an integer - the size of the field
- On the second line you will receive the initial **indexes** of all ladybugs separated by a blank space. **The given indexes** may or may not be inside the field range
- On the next lines, until you get the &quot;end&quot; command you will receive commands in the format: &quot; **{ladybug index} {direction} {fly length}**&quot;

### Output

- Print the **all cells within the field in format: &quot;{cell} {cell} … {cell}&quot;**
  - If a cell has ladybug in it, print **&#39;1&#39;**
  - If a cell is empty, print **&#39;0&#39;**

### Constrains

- The size of the field will be in the range [0 … 1000]
- The ladybug indexes will be in the range [-2,147,483,647 … 2,147,483,647]
- The number of commands will be in the range [0 … 100]
- The fly length will be in the range [-2,147,483,647 … 2,147,483,647]

### Examples

| **Input** | **Output** |
| --- | --- |
| 3 | 0 1 0 |
| 0 1 | |
| 0 right 1 | |
| 2 right 1 | |
| end |  |
| **Input** | **Output** |
| 3 | 0 0 0 |
| 0 1 2 | |
| 0 right 1 | |
| 1 right 1 | |
| 2 right 1 | |
| end | |
| **Input** | **Output** |
| 5 | 0 0 0 1 0 |
| 3 | |
| 3 left 2| |
| 1 left -2| |
| end |  |
