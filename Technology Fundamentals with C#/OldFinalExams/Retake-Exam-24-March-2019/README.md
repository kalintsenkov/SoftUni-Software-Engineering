# Bonus System

[https://judge.softuni.bg/Contests/Practice/Index/1597#0](https://judge.softuni.bg/Contests/Practice/Index/1597%230)

Create a program that calculates **bonus points** for each **student** , for a certain **course**. On the first line, you are going to receive **the count of the students** for this course. **On the second line** , you will receive **the count of the lectures** in the course. Every course has **an additional bonus**. You are going to receive it **on the third line**. On the next lines, you will be receiving the **count of attendances**** for each student**.

The bonus is calculated with the following **formula** :

**{totalBoonus}**  **=**  **{studentA**** ttendances ****}**  **/**  **{courseLectures}** **\* (5 +**  **{additionalBonus}**** )**

Round the number to **the nearest bigger number**. Find the student with the **maximum bonus** and print him/her, along with **his attendances** in the following format:

**&quot;The maximum bonus score for this course is {maxBonusPoints}. The student has attended {studentAttendances} lectures.&quot;**

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
| 524301219241620 | The maximum bonus score for this course is 35.The student has attended 24 lectures. |
| **Comments** |
| First, we receive the **number of students** enrolled in the course – **5**. The total count of the lectures is **25** and the initial bonus is **30**. Then we calculate the bonus of the student with 12 attendances, which is **17.5**. We continue calculating **each of the student&#39;s bonuses**. The one **with 24 attendances** has the **highest bonus – 35** , so we print the appropriate message on the console. |
| 103014823272815172526518 | The maximum bonus score for this course is 18.The student has attended 28 lectures. |

## Nascar Qualifications

The Nascar Qualifications are about to begin. You are tasked with creating a program that outputs **the results from the race**. On the **first** line you will be given **the names of the racers on their positions in the beginning of the race**. On the **next** line, you will be given the **following pairs** – **&quot;{command} {racer}|{command} {racer}……&quot;.**

You may receive the following types of commands:

- Race {racer} – add the pilot on the last position, if he isn&#39;t in the race.
- Accident {racer} – remove the racer from the race.
- Box {racer} – move the racer one position back, if he is in the race and he is not already last.
- Overtake {racer} {racersCount} – move the racer the given count of positions forward, if he is in the race and the position is valid.

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
| Vetel Hamilton Raikonnen Botas SlaviBox HamiltonOvertake LeClerc 2Race RicardoAccident BotasOvertake Ricardo 1Accident Slaviend | Vetel ~ Raikonnen ~ Hamilton ~ Ricardo |
| **Comments** |
| First, we receive the command &quot;Box&quot; and we need to move Hamilton a position back in the list. Currently, **he is 2**
# nd
 **in the list** , and **he has to become 3**
# rd
, respectively, **the racer behind him** , **moves in front of him** and **becomes 2**
# nd
. After, that we receive a command about a racer, who is not in the race and we **skip** that command. Next, Ricardo begins the race **at the last position**. Botas has an accident and is **removed** from the race.Ricardo overtakes 1 racer, which means he **overtakes** Slavi, and moves **in from of him**. At last, Slavi undergoes through an **accident** and is **removed** from the race. |
| Vetel Hamilton SlaviBox HamiltonOvertake Hamilton 2Accident Slaviend | Hamilton ~ Vetel |

# Emoji Sumator

Create a program, that finds all of the **emojis** in **a given message** and makes some calculations. You will receive a few lines of input **.** On the **first**** line **, you will receive a single** line of text (ASCII symbols). **On the** next ****line** , you will receive an **emoji code** in the following format:

&quot;**number:number:number:(…)**&quot;

**Each number is the value of an ASCII symbol** and if you decrypt **all of the symbols** , you will receive a name of an emoji.

An emoji is **valid** when:

- --It is surrounded by **colons**** and **** consists of ****at least 4 lowercase letters** from the English alphabet.
- -- **Before** the emoji there is a **white space** and **after it** there isa **white space or any of the following punctuation marks:**&#39;,&#39;, &#39;. **&#39;, &#39;!&#39;, &#39;?&#39;.**

**Example for valid emojis**** :**

I hope you have a **:sunny:** day **:smiley:**** :smiley:**.

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

- **Print all**  **found emojis**** , **** separated by a comma and whitespace ****.**
- **Print**  **the sum of all emojis&#39; power****.**
- Allowed working **time** / **memory** : **100ms** / **16MB**

## Examples

| **Input** | **Output** | **Comment** |
| --- | --- | --- |
| Hello I am Mark from :England: and I am :one::seven: years old, I have a :hamster: as pet.115:101:118:101:110 | Emojis found: :seven:, :hamster:Total Emoji Power: 2602 | The only valid emojis here are :seven: and :hamster: because they are longer than 3 symbols and consist only of lowercase letters.
:England: is not a valid emoji because of the upper case &#39;E&#39;.
:one: is not a valid emoji because it is shorter than 4 symbols.
Then we sum all letters&#39; ASCII value:
&#39;h&#39; = 104, &#39;a&#39; = 97, &#39;m&#39; = 109, &#39;s&#39; = 115, &#39;t&#39; = 116, &#39;e&#39; = 101, &#39;r&#39; = 114. Total for :hamster: is 756.
Total for :seven: is 545. The total power is 1301.
After that we check if the emoji code corresponds to any emoji, and in this case it does correspond to :seven:, so we multiply the total emoji power and in the end it is 2602. |
| In the Sofia Zoo there are many animals, such as :ti ger:, :elephan:t, :monk3y:, :goriLLa:, :fox:.97:101:117:114 | Total Emoji Power: 0 | :ti ger:, :elephan:t, :monk3y:, :goriLLa:, :fox:are all invalid emojis, so we have 0 total emoji power. |

# 1.International SoftUniada

Create a program that lists the results from the International SoftUniada Competition. You will be receiving input lines in the following format:

 &quot;{countryName} -\&gt; {contestantName} -\&gt; {contestantPoints}&quot;

You must calculate the total points of each country, which are the total points of the contestants from this country. Every contestant can take part in more than one contest in the SoftUniada and you must keep his total points from the SoftUniada competition. Each of the contestants are allowed to compete for only one country. You will be receiving the strings with that information until the &quot;END&quot; command is given.

In the end, print the countries with their points and their contestantswith their points, ordered by thetotal points for the countries in descending order, in the following format:

{country}: {totalPointsForCountry}

-- {contestantName} -\&gt; {contestantTotalPoints}

-- {contestantName} -\&gt; {contestantTotalPoints}

{country}: {totalPointsForCountry}

-- {contestantName} -\&gt; {contestantTotalPoints}

-- {contestantName} -\&gt; {contestantTotalPoints}

…………………………………………………

### Input / Constraints

- You will be receiving strings in the format described above until you receive the &quot; **END**&quot; command.
- The **number** of **points** in the **input argument** will be valid positive number.
- There **will** be **no invalid**** input.**

### Output

- Print the **countries** with **their total points** and the **contestants**** and their total points **in the format described above,** ordered **by the** total points **for the** countries **in** descending** order.

### Examples

| **Input** | **Output** |
| --- | --- |
| Bulgaria -\&gt; Ivan Ivanov -\&gt; 25Germany -\&gt; Otto Muller -\&gt; 4England -\&gt; John Addams -\&gt; 10Bulgaria -\&gt; Georgi Georgiev -\&gt; 18England -\&gt; Valteri Bottas -\&gt; 8Bulgaria -\&gt; Georgi Georgiev -\&gt; 6END | Bulgaria: 49 -- Ivan Ivanov -\&gt; 25 -- Georgi Georgiev -\&gt; 24England: 18 -- John Addams -\&gt; 10 -- Valteri Bottas -\&gt; 8Germany: 4 -- Otto Muller -\&gt; 4 |
| **Comments** |
| We receive the first input line and keep the **name** of the **country** , as well as the **contestant** and his **points**. If we have a contestant, who takes part in a **few**** competitions **, like** Georgi Georgiev **, we have to** add the points **from the second competition to the ones from the first. In the end we have to** order **the collection by the** total points **for the** countries **in** descending order**. |
| Norway -\&gt; Botel Audun -\&gt; 14Switzerland -\&gt; Alexis Andersson -\&gt; 18France –\&gt; Francois Arnaud -\&gt; 10France -\&gt; Pier Armand -\&gt; 22Bulgaria -\&gt; Peter Petrov -\&gt; 25France -\&gt; Francois Arnaud -\&gt; 3Bulgaria -\&gt; Peter Petrov -\&gt; 6END | France: 35 -- Francois Arnaud -\&gt; 13 -- Pier Armand -\&gt; 22Bulgaria: 31 -- Peter Petrov -\&gt; 31Switzerland: 18 -- Alexis Andersson -\&gt; 18Norway: 14 -- Botel Audun -\&gt; 14 |