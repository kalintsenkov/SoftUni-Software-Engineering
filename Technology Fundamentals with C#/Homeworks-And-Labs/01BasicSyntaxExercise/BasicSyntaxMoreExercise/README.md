# 1.Sort Numbers

 Read three real numbers and sort them in descending order. Print each number on a new line.

### Examples

| **Input** | **Output** |
| --- | --- |
| 2 | 3 |
| 1 | 2 |
| 3 | 1 |
| **Input** | **Output** |
| -2 | 3 |
| 1 | 1 |
| 3 | -2 |
| **Input** | **Output** |
| 0 | 2 |
| 0 | 0 |
| 2 | 0 |

# 2.English Name of the Last Digit

Write a **method** that returns the **English name** of the last digit of a given number. Write a program that reads an integer and prints the returned value from this method.

### Examples

| **Input** | **Output** |
| --- | --- |
| 512 | two |
| 1 | one |
| 1643 | three |

# 3.Gaming Store

Write a program, whichhelps you buy the games. The **valid games** are the following games in this table:

| **Name** | **Price** |
| --- | --- |
| OutFall 4 | $39.99 |
| CS: OG | $15.99 |
| Zplinter Zell | $19.99 |
| Honored 2 | $59.99 |
| RoverWatch | $29.99 |
| RoverWatch Origins Edition | $39.99 |

On the first line, you will receive your **current balance** – a **floating-point** number in the range **[0.00…5000.00]**.

Until you receive the command &quot; **Game Time**&quot;, you have to keep **buying games**. When a **game** is **bought** , the user&#39;s **balance** decreases by the **price** of the game.

Additionally, the program should obey the following conditions:

- If a game the user is trying to buy is **not present** in the table above, print &quot; **Not Found**&quot; and **read the next line**.
- If at any point, the user has **$0** left, print &quot; **Out of money!**&quot; and **end the program**.
- Alternatively, if the user is trying to buy a game which they **can&#39;t afford** , print &quot; **Too Expensive**&quot; and **read the next line**.
- If the game exists and the player has the money for it, print **&quot;Bought {nameOfGame}&quot;**

When you receive &quot; **Game Time**&quot;, **print** the user&#39;s **remaining money** and **total spent on games** , **rounded** to the **2**nd **decimal place**.

### Examples

| **Input** | **Output** |
| --- | --- |
| 120 | Bought RoverWatch |
|RoverWatch| Bought Honored 2 |
|Honored 2| Total spent: $89.98. Remaining: $30.02 |
|Game Time |  |
| **Input** | **Output** |
| 19.99 | Not Found |
|Reimen origin| Too Expensive |
|RoverWatch| Bought Zplinter Zell |
|Zplinter Zell| Out of money! |
|Game Time |  |
| **Input** | **Output** |
| 79.99 | Bought OutFall 4 |
|OutFall 4 | Bought RoverWatch Origins Edition |
|RoverWatch Origins Edition | Total spent: $79.98. Remaining: $0.01 |
|Game Time |  |

# 4.Reverse String

Write a program which reverses a string and print it on the console.

### Examples

| **Input** | **Output** |
| --- | --- |
| Hello | olleH |
| SoftUni | inUtfoS |
| 1234 | 4321 |

# 5.Messages

Write a program, which emulates **typing an SMS** , following this guide:

| **1** | **2** abc | **3** def |
| --- | --- | --- |
| **4** ghi | **5** jkl | **6** mno |
| **7** pqrs | **8** tuv | **9** wxyz |
|   | **0** space |   |

Following the guide, **2** becomes &quot; **a**&quot;, **22** becomes &quot; **b**&quot; and so on.

### Examples

| **Input** | **Output** |
| --- | --- |
| 5 | hello |
| 44 | |
| 33 | |
| 555 | |
| 555 | |
| 666 |  | 
| **Input** | **Output** |
| 9 | hey there|
| 44 | |
| 33 | |
| 999 | |
| 0 | |
| 8 | |
| 44 | |
| 33 | |
| 777 | |
| 33 |  | 
| **Input** | **Output** |
| 7 | meet me |
| 6 | |
| 33 | |
| 33 | |
| 8 | |
| 0 | |
| 6 | |
| 33 | |
