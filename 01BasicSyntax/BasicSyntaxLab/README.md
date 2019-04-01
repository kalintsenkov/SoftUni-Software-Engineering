# 1.Student Information

You will be given 3 lines of input – student name, age and average grade. Your task is to print all the info about the student in the following format: &quot; **Name: {student name}, Age: {student age}, Grade: {student grade}**&quot;.

### Examples

| **Input** | **Output** |
| --- | --- |
| John | |
| 15 | |
|5.40 | Name: John, Age: 15, Grade: 5.40 |
| **Input** | **Output** |
| Steve | |
| 16 | |
| 2.50 | Name: Steve, Age: 16, Grade: 2.50 |
| **Input** | **Output** |
| Marry | |
| 12 | |
|6.00 | Name: Marry, Age: 12, Grade: 6.00 |

# 2.Passed

Write a program, which takes as an input a **grade** and prints &quot; **Passed!**&quot; if the grade is **equal or more than 3.00**.

### Input

The **input** comes as a single floating-point number.

### Output

The **output** is either &quot; **Passed!**&quot; if the grade is **equal or more than 3.00** , otherwise you should print nothing.

### Examples

| **Input** | **Output** |   | **Input** | **Output** |
| --- | --- | --- | --- | --- |
| 5.32 | Passed! |   | 2.34 | _(no output)_ |

### Solution

We need to take as an input a floating-point number from the console. We will use **double.Parse()** to convert **string** to **double** , which we receive from **Console.ReadLine()**. After that we compare the grade with **3.00** and prints the result **only**** if **the condition returns** true**.



# 3.Passed or Failed

Modify the above program, so it will print &quot; **Failed**!&quot; if the grade is **lower than 3.00**.

### Input

The **input** comes as a single double number.

### Output

The **output** is either &quot; **Passed**!&quot; if the grade is **more than 2.99** , otherwise you should print &quot; **Failed**!&quot;.

### Examples

| **Input** | **Output** |   | **Input** | **Output** |
| --- | --- | --- | --- | --- |
| 5.32 | Passed! |   | 2.36 | Failed! |

### Solution

Again, we need to take **floating-point** number from the console. After that print in the **else** statement the appropriate message.

# 4.Back in 30 Minutes

Every time Stamat tries to pay his bills he sees on the cash desk the sign: **&quot;**** I will be back in 30 minutes ****&quot;**. One day Stamat was sick of waiting and decided he needs a program, which **prints the time** after **30**** minutes**. That way he won&#39;t have to wait on the desk and come at the appropriate time. He gave the assignment to you, so you have to do it.

### Input

The **input** will be on two lines. On the **first**** line **, you will receive the** hours **and on the** second **you will receive the** minutes**.

### Output

Print on the console the time after **30** minutes. The result should be in format **hh:mm**. The **hours** have **one or two**** numbers **and the** minutes **have always** two numbers (with leading zero)**.

### Constraints

- **??** The **hours** will be between **0 and 23**.
- **??** The **minutes** will be between **0 and 59**.

### Examples

| **Input** | **Output** |   | **Input** | **Output** |   | **Input** | **Output** |   | **Input** | **Output** |   | **Input** | **Output** |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 1  | 2:16 |   | 0  | 0:31 |  | 23  | 0:29 |   | 11  | 11:38 |   | 11  | 12:02 |
| 46 |      |   |01  |      |  | 59  |      |   | 08  |       |   | 32  |       |
# 5.Month Printer

Write a program, which takes an **integer** from the console and prints the corresponding **month**. If the number **is more than 12** or **less than 1** print &quot; **Error!**&quot;.

### Input

You will receive a **single**** integer **on a** single line**.

### Output

If the number is within the boundaries print the corresponding month, otherwise print &quot; **Error!**&quot;.

### Examples

| **Input** | **Output** |   | **Input** | **Output** |
| --- | --- | --- | --- | --- |
| 2 | February |   | 13 | Error! |

### Solution

# 6.Foreign Languages

Write a program, which prints the language, that a given country speaks. You can receive only the following combinations: English **is spoken** in England and USA; Spanish **is spoken** in Spain, Argentina and Mexico; for the others **,** we should print &quot;unknown&quot;.

### Input

You will receive a **single country name** on a **single line**.

### Output

**Print** the **language** , which the country **speaks** , or if it is **unknown** for your program, print **&quot;**** unknown ****&quot;**.

### Examples

| **Input** | **Output** |   | **Input** | **Output** |
| --- | --- | --- | --- | --- |
| USA | English |   | Germany | unknown |

### Hint

Think how you can **merge** multiple cases, in order to **avoid** writing more code than you need to.

# 7.Theatre Promotions

A theatre **is doing a ticket sale** , but they need a program **to** calculate the price of a single ticket. If the given age does not fit one of the categories **,** you should print &quot;Error!&quot;.  You can see the prices i **n** the table below:

| **Day / Age** | **0 <= age <= 18** | **18 < age <= 64** | **64 < age <= 122** |
| --- | --- | --- | --- |
| **Weekday** | 12$ | 18$ | 12$ |
| **Weekend** | 15$ | 20$ | 15$ |
| **Holiday** | 5$ | 12$ | 10$ |

### Input

The input comes in **two lines**. On the **first** line, you will receive the **type of day**. On the **second** – the **age** of the person.

### Output

Print the price of the ticket according to the table, or &quot; **Error!**&quot; if the age is not in the table.

### Constraints

- **??** The age will be in the interval **[-1000…1000]**.
- **??** The type of day will **always be**** valid**.

### Examples

| **Input** | **Output** |   | **Input** | **Output** |   | **Input** | **Output** |   | **Input** | **Output** |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Weekday |   |Holiday|      |Holiday|     |Weekend|
|42 | 18$ |   | -12 | Error! | 15 | 5$ |   | 122 | 15$ |

# 8.Divisible by 3

Write a program, which prints all the numbers from **1 to 100** , which are **divisible by 3**. You have to use a single **for** loop. The program should not receive input.

# 9.Sum of Odd Numbers

Write a program that prints the next **n**** odd numbers**(starting from 1) and on the**last row **prints the** sum of them**.

### Input

On the first line, you will receive a number – **n**. This number shows how many **odd numbers** you should print.

### Output

Print the next **n** odd numbers, starting from **1** , separated by **new lines**. On the last line, print the **sum** of these numbers.

### Constraints

- **??**** n **will be in the interval** [1…100]**

### Examples

| **Input** | **Output** |   | **Input** | **Output** |
| --- | --- | --- | --- | --- |
| 5 | 1 |          | 3 | 1 |
|   | 3 |          |   | 3 |
|   | 5 |          |   | 5 |
|   | 7 |          |   |   |
|   | 9 |          |   |   |
|   | Sum: 25 |    |   |Sum: 9|
# 10. Multiplication Table

You will receive an **integer** as an input from the console. Print the **10 times table** for this integer. See the examples below for more information.

### Output

Print every row of the table in the following format:

{theInteger} X {times} = {product}

### Constraints

- **??** The integer will be in the interval **[1…100]**

### Examples

| **Input** | **Output** |
| --- | --- |
| 5 |   5 X 1 = 5 |
|   |   5 X 2 = 10 |
|   |   5 X 3 = 15 |
|   |   5 X 4 = 20 |
|   |   5 X 5 = 25 |
|   |   5 X 6 = 30 |
|   |   5 X 7 = 35 |
|   |   5 X 8 = 40 |
|   |   5 X 9 = 45 |
|   |   5 X 10 = 50 | 
| **Input** | **Output** |
| 2 |   2 X 1 = 2 |
|   |   2 X 2 = 4 |
|   |   2 X 3 = 6 |
|   |   2 X 4 = 8 |
|   |   2 X 5 = 10 |
|   |   2 X 6 = 12 |
|   |   2 X 7 = 14 |
|   |   2 X 8 = 16 |
|   |   2 X 9 = 18 |
|   |   2 X 10 = 20 |

# 11.Multiplication Table 2.0

Rewrite you program so it can receive the **multiplier from the console**. Print the **table from the given multiplier to 10**. If the given multiplier is **more than 10** - print only one row with the **integer** , the given **multiplier** and the **product**. See the examples below for more information.

### Output

Print every row of the table in the following format:

{theInteger} X {times} = {product}

### Constraints

- **??** The integer will be in the interval **[1…100]**

### Examples

| **Input** | **Output** |
| --- | --- |
| 5 |   5 X 1 = 5 |
| 1 |   5 X 2 = 10 |
|   |   5 X 3 = 15 |
|   |   5 X 4 = 20 |
|   |   5 X 5 = 25 |
|   |   5 X 6 = 30 |
|   |   5 X 7 = 35 |
|   |   5 X 8 = 40 |
|   |   5 X 9 = 45 |
|   |   5 X 10 = 50 | 
| **Input** | **Output** |
| 2 | 2 X 5 = 10 |
| 5 | 2 X 6 = 12 |
| |  2 X 7 = 14 |
| |  2 X 8 = 16 |
| |  2 X 9 = 18 |
| |2 X 10 = 20 |   
| **Input** | **Output** |
| 2 | 2 X 14 = 28|
| 14 | |

# 12.Even Number

Take as an input an even number and **print its absolute value**. If the number is odd, print &quot;Please write an even number.&quot; and continue reading numbers.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 | Please write an even number.|
| 3 | Please write an even number.|
| 6 | The number is: 6 |
| **Input** | **Output** |
| -6 | The number is: 6  |

