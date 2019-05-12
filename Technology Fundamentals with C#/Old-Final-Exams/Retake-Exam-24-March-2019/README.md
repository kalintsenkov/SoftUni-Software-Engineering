# 01. Bonus System

Create a program that calculates **bonus points** for each **student** , for a certain **course**. On the first line, you are going to receive **the count of the students** for this course. **On the second line** , you will receive **the count of the lectures** in the course. Every course has **an additional bonus**. You are going to receive it **on the third line**. On the next lines, you will be receiving the **count of attendances**** for each student**.

The bonus is calculated with the following **formula** :

**{totalBoonus}**  **=**  **{studentAttendances}**  **/**  **{courseLectures}** \* **(5 + {additionalBonus})**

Round the number to **the nearest bigger number**. Find the student with the **maximum bonus** and print him/her, along with **his attendances** in the following format:

**&quot;The maximum bonus score for this course is {maxBonusPoints}.The student has attended {studentAttendances} lectures.&quot;**

## Input / Consrtaints

- On the **first line** you are going to receive the count of the students – an integer number in the range [0…50]
- On the **second line** you are going to receive the count of the lectures – an integer number in the range [0...50].
- On the **third line** you are going to receive **the initial bonus** – an integer number in the range [0….100].
- **On the next lines** , you will be receiving the **attendances of each student**.
- There will **never** be **students with equal bonuses**.

## Output

- Print the maximum bonus points along with the attendances of the given student, **rounded** to the nearest **bigger** number, scored by a student in this course in the format described above.

## Examples

| **Input** | **Output** |
| --- | --- |
| 5 | The maximum bonus score for this course is 35.The student has attended 24 lectures. |
| 24 | |
| 30 | |
| 12 | |
| 19 | |
| 24 | |
| 16 | |
| 20 |  |
| **Input** | **Output** |
| 10 | The maximum bonus score for this course is 18.The student has attended 28 lectures. |
| 30 | |
| 14 | |
| 8 | |
| 23 | |
| 27 | |
| 28 | |
| 15 | |
| 17 | |
| 25 | |
| 26 | |
| 5 | |
| 18 |  |

# 02. Nascar Qualifications

The Nascar Qualifications are about to begin. You are tasked with creating a program that outputs **the results from the race**. On the **first** line you will be given **the names of the racers on their positions in the beginning of the race**. On the **next** line, you will be given the **following pairs** – **&quot;{command} {racer}|{command} {racer}……&quot;.**

You may receive the following types of commands:

- **Race {racer}** – add the pilot on the last position, if he isn&#39;t in the race.
- **Accident {racer}** – remove the racer from the race.
- **Box {racer}** – move the racer one position back, if he is in the race and he is not already last.
- **Overtake {racer} {racersCount}** – move the racer the given count of positions forward, if he is in the race and the position is valid.

Read commands until you receive &quot;end&quot;.

## Input / Consrtaints

- On the **first line** , you will be given **the names of the racers on their positions**.
- On the second line, you will be given the pairs – {command} {racer} in the format described above.
- There will always be at least one racer in the race.
- The commands will always be valid.

## Output

- At the end of the race, print the list with the names of the racers, separated by **&quot;~&quot;**.

## Examples

| **Input** | **Output** |
| --- | --- |
| Vetel Hamilton Raikonnen Botas Slavi | Vetel ~ Raikonnen ~ Hamilton ~ Ricardo |
| Box Hamilton | |
| Overtake LeClerc 2 | |
| Race Ricardo | |
| Accident Botas | |
| Overtake Ricardo 1| |
| Accident Slavi| |
| end |  |
| **Input** | **Output** |
| Vetel Hamilton Slavi | Hamilton ~ Vetel |
| Box Hamilton | |
| Overtake Hamilton 2 | |
| Accident Slavi | |
| end |  |

# 03. Emoji Sumator

Create a program, that finds all of the **emojis** in **a given message** and makes some calculations. You will receive a few lines of input **.** On the **first line**, you will receive a single** line of text (ASCII symbols). On the **next line** , you will receive an **emoji code** in the following format:

&quot;**number:number:number:(…)**&quot;

**Each number is the value of an ASCII symbol** and if you decrypt **all of the symbols** , you will receive a name of an emoji.

An emoji is **valid** when:

- --It is surrounded by **colons** and consists of **at least 4 lowercase letters** from the English alphabet.
- -- **Before** the emoji there is a **white space** and **after it** there is a **white space or any of the following punctuation marks:**&#39;,&#39;, &#39;. **&#39;, &#39;!&#39;, &#39;?&#39;.**

**Example for valid emojis :**

I hope you have a **:sunny:** day **:smiley:** **:smiley:**.

You must find all of the emojis and after that, calculate their total power. It is calculated **by summing the ASCII value of all letters between the colons**.

**Check** if any of the valid **emoji names is equal to the name** received form **the emoji code** and **if it is – multiply the total emoji power by 2**.

In the end print on the console all valid emojis, **separated by**  **à**  **comma and a white space in order of finding** and the total emoji power, each on a separate line.

**Example:**
**Emojis found: :sunny:, :smiley:, :smiley:**
**Total Emoji Power: {sum}**

## Input / Constraints

- On the first line – the message. **There can be any ASCII character inside the input.**
- Punctuation marks used will be only &#39;,&#39;, &#39;. **&#39;, &#39;!&#39;, &#39;?&#39;.**
- A valid emoji consists of at least **4 lowercase letters surrounded by colons**.

## Output

- **Print all**  **found emojis** , **separated by a comma and whitespace.**
- **Print**  **the sum of all emojis&#39; power.**
- Allowed working **time** / **memory** : **100ms** / **16MB**

## Examples

| **Input** | **Output** |
| --- | --- |
| Hello I am Mark from :England: and I am :one::seven: years old, I have a :hamster: as pet. | Emojis found: :seven:, :hamster:|
| 115:101:118:101:110 | Total Emoji Power: 2602 |
| **Input** | **Output** |
| In the Sofia Zoo there are many animals, such as :ti ger:, :elephan:t, :monk3y:, :goriLLa:, :fox:.| |
|97:101:117:114 | Total Emoji Power: 0 |

# 04. International SoftUniada

Create a program that lists the results from the International SoftUniada Competition. You will be receiving input lines in the following format:

 **&quot;{countryName} -\> {contestantName} -\> {contestantPoints}&quot;**

You must **calculate the total points of each country**, which are the total points of the contestants from this country. Every contestant can take part in **more than one** contest in the SoftUniada and you must keep his **total points** from the SoftUniada competition. Each of the contestants are allowed to compete for **only one country**. You will be receiving the **strings** with that information until the **&quot;END&quot;** command is given.

In the end, print the countries with their points and their contestantswith their points, ordered by thetotal points for the countries in descending order, in the following format:

**{country}: {totalPointsForCountry}**

**&nbsp;-- {contestantName} -\> {contestantTotalPoints}**

**&nbsp;-- {contestantName} -\> {contestantTotalPoints}**

**{country}: {totalPointsForCountry}**

**&nbsp;-- {contestantName} -\> {contestantTotalPoints}**

**&nbsp;-- {contestantName} -\> {contestantTotalPoints}**

…………………………………………………

### Input / Constraints

- You will be receiving strings in the format described above until you receive the &quot;**END**&quot; command.
- The **number** of **points** in the **input argument** will be valid positive number.
- There **will** be **no invalid** input.

### Output

- Print the **countries** with **their total points** and the **contestants**** and their total points **in the format described above,** ordered **by the** total points **for the** countries **in** descending** order.

### Examples

| **Input** | **Output** |
| --- | --- |
| Bulgaria -\> Ivan Ivanov -\> 25 | Bulgaria: 49 |
| Germany -\> Otto Muller -\> 4 | &nbsp;-- Ivan Ivanov -\> 25|
| England -\> John Addams -\> 10 | &nbsp;-- Georgi Georgiev -\> 24|
| Bulgaria -\> Georgi Georgiev -\> 18 |England: 18|
| England -\> Valteri Bottas -\> 8 |&nbsp;-- John Addams -\> 10|
| Bulgaria -\> Georgi Georgiev -\> 6 |&nbsp;-- Valteri Bottas -\> 8|
| END | Germany: 4 |
| |&nbsp;-- Otto Muller -\> 4 |
| **Input** | **Output** |
| Norway -\> Botel Audun -> 14 | France: 35|
| Switzerland -\> Alexis Andersson -\> 18 | &nbsp;-- Francois Arnaud -\> 13|
| France –\> Francois Arnaud -\> 10 | &nbsp;-- Pier Armand -\> 22|
| France -\> Pier Armand -\> 22 | Bulgaria: 31|
| Bulgaria -\> Peter Petrov -\> 25 | &nbsp;-- Peter Petrov -\> 31|
| France -\>Francois Arnaud -\> 3 | Switzerland: 18|
| Bulgaria -\> Peter Petrov -\> 6 | &nbsp;-- Alexis Andersson -\> 18|
| END | Norway: 14 |
| | &nbsp;-- Botel Audun -\> 14 |
