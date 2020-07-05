# Exercises: Data Types and Variables

## 1. Integer Operations

Read four integer numbers. Add first to the second, divide (integer) the sum by the third number and multiply the result by the fourth number. Print the result.

### Constraints

- First number will be in the range [-2,147,483,648… 2,147,483,647]
- Second number will be in the range [-2,147,483,648… 2,147,483,647]
- Third number will be in the range [-2,147,483,648… 2,147,483,647]
- Fourth number will be in the range [-2,147,483,648… 2,147,483,647]

### Examples

| **Input** | **Output** |   
| --- | --- |
| 10| 30 |
|20| |
|3| |
|3  | |   
| **Input** | **Output** |
| 15| 42 |
|14| |
|2| |
|3 |  |

## 2. Sum Digits

You will be given a single **integer**. Your task is to find the sum of its digits.

### Examples

| **Input** | **Output** |
| --- | --- |
| 245678 | 32 |
| 97561 | 28 |
| 543 | 12 |

## 3. Elevator

Calculate how many courses will be needed to **elevate n persons** by using an elevator of **capacity of p persons**. The input holds two lines:the **number of people n** and the **capacity p** of the elevator.

### Examples

| **Input** | **Output** |
| --- | --- |
| 17| 6 |
|3 | |
| **Input** | **Output** |
| 4| 1 |
|5 |  |
| **Input** | **Output** |
| 10 | 2 |
| 5 | |

## 4. Sum of Chars

Write a program, which sums the ASCII codes of **n** characters and prints the **sum** on the console.

### Input

- On the **first**** line **, you will receive** n **– the number of** lines **, which will** follow**
- On the next **n lines** – you will receive letters from the **Latin** alphabet

### Output

Print the **total**** sum** in the following format:

The sum equals: {totalSum}

### Constraints

- **n** will be in the interval **[1…20]**.
- The **characters** will always be either **upper** or **lower** -case letters from the **English alphabet**
- You will always receive **one**** letter **per** line**

### Examples

| **Input** | **Output** |
| --- | --- |
| **5** |The sum equals: 399|
| A |  |
| b |  |
| C |  |
| d |  |
| E |  |   
| **Input** | **Output** |
| **12** |  The sum equals: 1263 |
| S| |
| o| |
| f| |
| t| |
| U| |
| n| |
| i| |
| R| |
| u| |
| l| |
| z| |
| z | |

## 5. Print Part of the ASCII Table

Find online more information about [ASCII](http://www.ascii-code.com/) (American Standard Code for Information Interchange) and write a program that **prints part of the ASCII table** of characters at the console.  On the first line of input you will receive **the char index you should start with** and on the **second line - the index of the last character** you should print.

### Examples

| **Input** | **Output** |
| --- | --- |
| 60 | \< = \> ? @ A |
| 65 |  |
| **Input** | **Output** |
| 69 | E F G H I J K L M N O |
| 79 |  |
| **Input** | **Output** |
| 97 |a b c d e f g h |
| 104 | |
| **Input** | **Output** |
| 40 |( ) \* + , - . / 0 1 2 3 4 5 6 7|
| 55 |  |

## 6. Triples of Latin Letters

Write a program to read an integer **n** and print all **triples** of the first **n small Latin letters** , ordered alphabetically:

### Examples

| **Input** | **Output** |
| --- | --- |
| 3 | aaa|
||aab|
||aac|
||aba|
||abb|
||abc|
||aca|
||acb|
||acc|
||baa|
||bab|
||bac|
||bba|
||bbb|
||bbc|
||bca|
||bcb|
||bcc|
||caa|
||cab|
||cac|
||cba|
||cbb|
||cbc|
||cca|
||ccb|
||ccc |

## 7. Water Overflow

You have a **water**** tank **with capacity of** 255 liters **. On the next** n **lines, you will receive** liters of water **, which you have to** pour **in your** tank **. If the** capacity **is** not enough **, print &quot;** Insufficient capacity! **&quot; and** continue reading **the next line. On the last line, print the** liters **in the** tank**.

### Input

The **input** will be on two lines:

- On the **first**** line **, you will receive** n **– the number of** lines **, which will** follow**
- On the next **n lines** – you receive **quantities** of water, which you have to **pour** in the **tank**

### Output

Every time you do not have **enough**** capacity **in the tank to pour the given liters,** print**:

Insufficient capacity!

On the last line, **print** only the **liters** in the **tank**.

### Constraints

- **n** will be in the interval **[1…20]**
- **liters** will be in the interval **[1…1000]**

### Examples

| **Input** | **Output** |
| --- | --- |
| **5** | Insufficient capacity!|
| 20 | 240 |
|100||
|100||
|100||
|20 | |
| **Input** | **Output** |
| **1** | Insufficient capacity! |
| 1000  | 0 |
| **Input** | **Output** |
| **7** | 105|
|10||
|20||
|30||
|10||
|5||
|10||
|20 |  |
| **Input** | **Output** |
|**4** |Insufficient capacity!|
|250| Insufficient capacity!|
|10|Insufficient capacity!|
|20|250|
|40 |  |

## 8. Beer Kegs

Write a program, which calculates the volume of **n** beer kegs. You will receive in total **3 \* n** lines. **Each three lines** will hold **information** for a **single** keg. First up is the **model** of the keg, after that is the **radius** of the keg, and lastly is the **height** of the keg.

Calculate the volume using the following formula: **? \* r^2 \* h**.

At the end, print the **model** of the **biggest** keg.

### Input

You will receive **3 \* n** lines. Each group of lines will be on a new line:

- First – **model** – **string**.
- Second – **radius** – **floating-point** number
- Third – **height** – **integer** number

### Output

Print the **model** of the **biggest** keg.

### Constraints

- **n** will be in the interval **[1…10]**
- The **radius** will be a **floating-point number** in the interval **[1…3.402823E+38]**
- The **height** will be an **integer** in the interval **[1…2147483647]**

### Examples

| **Input** | **Output** |
| --- | --- |
| **3** | Keg 2 |
|Keg 1| |
|10| |
|10| |
|Keg 2| |
|20| |
|20| |
|Keg 3| |
|10| |
|30 | |   
| **Input** | **Output** |
| **2** | Bigger Keg |
|Smaller Keg| |
|2.41| |
|10||
|Bigger Keg| |
|5.12| |
|20  | |

## 9. Spice Must Flow

_Spice is Love, Spice is Life. And most importantly, Spice must flow. It must be extracted from the scorching sands of Arrakis, under constant threat of giant sand worms. To make the work as efficient as possible, the Duke has tasked you with the creation of a management software._

Write a program that calculates the **total amount** of spice that can be extracted from a source. The source has a **starting yield** , which indicates how much spice can be mined on the **first day**. After it has been mined for a day, the **yield drops** by 10, meaning on the second day it&#39;ll produce 10 less spice than on the first, on the third day 10 less than on the second, and so on (see examples). A source is considered profitable only while its yield is **at least** 100 – when less than 100 spice is expected in a day, abandon the source.

The mining crew **consumes** 26 spice **every day** at the end of their shift and **an additional** 26 after the mine has been exhausted. Note that the workers cannot consume more spice than there is in storage.

When the operation is complete, print on the console on two separate lines how many days the mine has operated and the total amount of spice extracted.

### Input

You will receive a **number** , representing the **starting yield** of the source.

### Output

Print on the console on two separate lines how many **days** the mine has operated and the **total amount** of spice extracted.

###  Constraints

- The starting yield will be a positive **integer** within range [0 … 2 147 483 647]

### Examples

| **Input** | **Output** |
| --- | --- |
| 111 | 2 |
| | 134 |

## 10. Poke Mon

A Poke Mon is a special type of pokemon which likes to Poke others. But at the end of the day, the Poke Mon wants to keeps statistics, about how many pokes it has managed to make.

The Poke Mon pokes his target, and then proceeds to poke another target. The **distance** between his **targets**** reduces **his** poke power**.

You will be **given** the **poke power** the Poke Mon has, **N** – an **integer**.

Then you will be **given** the **distance** between the **poke targets** , **M** – an **integer**.

Then you will be **given** the **exhaustionFactor**** Y **– an** integer**.

Your task is to start **subtracting**** M **from** N **until** N **becomes** less than M**, i.e. the Poke Mon does not have enough power to reach the next target.
**Every time** you **subtract M** from **N** that means you&#39;ve reached a **target** and poked it successfully. **COUNT** how **many targets** you&#39;ve poked – **you&#39;ll need** that **count**.

The Poke Mon becomes gradually more exhausted. **IF**** N ****becomes equal** to **EXACTLY 50 %** of its **original value** , you must **divide**** N **by** Y **, if it is** POSSIBLE **.** This ****DIVISION** is between **integers**.

If a division is **not possible** , you should **NOT** do it. Instead, you should continue **subtracting**.

**After dividing** , you should **continue** subtracting from **N** , until it becomes **less** than **M**.

When **N** becomes **less** than **M** , you must take **what has remained** of **N** and the **count** of **targets** you&#39;ve poked, and print them as output.

**NOTE** : When you are **calculating percentages** , you should be **PRECISE** at **maximum**.

**Example** : **505** is **NOT EXACTLY 50 %** from **1000** , its **50.5 %**.

### Input

- The input consists of **3 lines**.
- On the **first line** you will receive **N** – an **integer**.
- On the **second line** you will receive **M** – an **integer**.
- On the **third line** you will receive **Y** – an **integer**.

### Output

- The output consists of **2 lines**.
- On the **first line** print **what has remained** of **N** , after **subtracting** from it.
- On the **second line** print the **count** of **targets** , you&#39;ve managed to poke.

### Constrains

- The integer **N** will be in the **range [1, 2.000.000.000]**.
- The integer **M** will be in the **range [1, 1.000.000]**.
- The integer **Y** will be in the **range [0, 9]**.
- Allowed time / memory: **16 MB / 100ms**.

### Examples

| **Input** | **Output** |
| --- | --- |
| 5 | 1 |
| 2 | 2 |
| 3 | |
| **Input** | **Output** |
| 10 | 2 |
| 5 | 1 |
| 2 | |

## 11. Snowballs

Tony and Andi love playing in the snow and having snowball fights, but they always argue which makes the best snowballs. Because they are girls (which means they are completely illogical), they have decided to involve you in their fray, by making you write a program which calculates snowball data, and outputs the best snowball value.

You will receive **N** – an **integer** , the **number** of **snowballs** being made by Tony and Andi.
**For each snowball** you will receive **3 input lines** :

- On the **first line** you will get the **snowballSnow** – an **integer**.
- On the **second line** you will get the **snowballTime** – an **integer**.
- On the **third line** you will get the **snowballQuality** – an **integer**.

**For each snowball** you must **calculate** its **snowballValue** by the following formula:

(snowballSnow / snowballTime) ^ snowballQuality

At the end you must print the **highest** calculated **snowballValue**.

### Input

- On the **first input line** you will receive **N** – the **number** of **snowballs**.
- On the **next N \* 3 input lines** you will be receiving **data** about **snowballs**.

### Output

- As output you must print the **highest** calculated **snowballValue** , by the formula, **specified above**.
- The output format is:
**{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})**

### Constraints

- The **number** of **snowballs** ( **N** ) will be an **integer** in **range [0, 100]**.
- The **snowballSnow** is an **integer** in **range [0, 1000]**.
- The **snowballTime** is an **integer** in **range [1, 500]**.
- The **snowballQuality** is an **integer** in **range [0, 100]**.

- Allowed working **time** / **memory** : **100ms** / **16MB**.

### Examples

| **Input** | **Output** |
| --- | --- |
| 2 | 10 : 2 = 125 (3) |
| 10 | |
| 2 | |
| 3 | |
| 5 | |
| 5 | |
| 5 | |
| **Input** | **Output** |
| 3|10 : 5 = 128 (7)|
|10||
|5||
|7||
|16||
|4||
|2||
|20|
|2||
|2 | |
