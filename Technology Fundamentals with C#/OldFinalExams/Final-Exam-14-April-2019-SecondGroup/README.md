# Problem 1. The Isle of Man TT Race

Write a program that decrypts messages. You&#39;re going to receive a few notes that contain the following information:

- **Name of racer**
  - Consists only of letters. It is surrounded from the both sides by any of the following symbols – **&quot;#, $, %, \*, &amp;&quot;. Both symbols** – in the **beginning** and at the **end** f the name should **match**.
- **Length of geohashcode**
  - Begins after the **&quot;=&quot;** sign and it is consisted only of numbers.
- **Encrypted geohash code**
  - Begins after these symbols - **&quot;!!&quot;**. It may contain anything and the message always ends with it.

**Examples for valid input:**

#SteveHislop#=16!!tv5dekdz8x11ddkc
**Examples of invalid input:**

%GiacomoAgostini$=7!!tv58ycb – The length is the same, but the name is not surrounded by **matching signs**.

$GeoffDuke$=6!!tuvz26n35dhe4w4 – The length doesn&#39;t **match** the **lengh** of the code.

&amp;JoeyDunlop&amp;!!tvndjef67t=14 – The length should be **before** the code.

The information must be in the **given order** , otherwise it is considered **invalid**. The **geohash code** you are looking for is with length **exactly as much as the given length in the message**. To **decrypt** the code you need to **increase** the value of **each symbol** from the geohashcode with the **given length**. If you find a **match**, you have to **print** the following message:

&quot;**Coordinates found! {nameOfRacer} -> {geohashcode}**&quot;

and stop the program. Otherwise, after every **invalid** message print:

&quot;**Nothing found!**&quot;

## Input / Constraints

- You will be receiving strings.
- There will always be a valid message.

## Output

- If you find the right coordinates, print: &quot;Coordinates found! {nameOfRacer} -> {geohashcode}&quot;.
- Otherwise, print: &quot;Nothing found!&quot;.

## Examples

| **Input** | **Output** |
| --- | --- |
|%GiacomoAgostini%=7!!hbqw| Nothing found!
|&amp;GeoffDuke\*=6!!vjh]zi| Nothing found!
|JoeyDunlop=10!!lkd,rwazdr|Nothing found!
|Mike??Hailwood=5!![pliu| Nothing found!
|#SteveHislop#=16!!df%TU[Tj(h!!TT[S| Coordinates found! SteveHislop -> tv5dekdz8x11ddkc |
| **Input** | **Output** |
|Ian6Hutchinson=7!!\(58ycb4| Nothing found!|
|#MikeHailwood#!!&#39;gfzxgu6768=11|Nothing found!|
|slop%16!!plkdek/.8x11ddkc|Nothing found!|
|$Steve$=9Hhffjh| Coordinates found! DaveMolyneux -> tuvz26n35dhe4w4 |
|\*DavMolyneux\*=15!!efgk#&#39;\_$&amp;UYV%h%| |
|RichardQ^uayle=16!!fr5de5kd |  |

# Problem 2. Practice sessions

Write a program, that keeps information about **roads** and **the racers** who practice on them.  When the practice begins, you&#39;re going to start receiving data until you get the &quot;**END**&quot; message. There are three possible commands:

- &quot;Add->{road}->{racer}&quot;
  - Add the **road** if it **doesn&#39;t exist** in your collection and add the **racer** to it.
- &quot;Move->{currentRoad}->{racer}->{nextRoad}&quot;
  - Find the **racer** on the **current road** and move him to the **next one** , only if he **exists** in the **current road.** Both roads will always be **valid** and will **already exist**.
- &quot;Close->{road}&quot;
  - Find the **road** and **remove** it from the sessions, **along with** the **racers** on it **if it exists**.

In the end, print all of the **roads** with the **racers** who have practiced and **ordered by the count of the racers in descending order**, **then by** the **roads** in **ascending** order. The output must be in the following format:

**Practice sessions:**

**{road}**

**++{racer}**

**++{racer}**

**++{racer}**

………………………..

## Input / Constraints

- You will be receiving lines of information in the format described above, until you receive the **&quot;END&quot;** command.
- The input will always be in the right format.
- Both **roads** from the &quot;**Move**&quot; command will always be **valid** and you don&#39;t need to check them explicitly.

## Output

- Print the **roads** withtheir **racers** in the **format described above**.

## Examples

| **Input** | **Output** |
| --- | --- |
|Add-\>Glencrutchery Road-\>Giacomo Agostini|Practice sessions:|
|Add-\>Braddan-\>Geoff Duke|Peel road|
|Add-\>Peel road-\>Mike Hailwood|++Mike Hailwood|
|Add-\>Glencrutchery Road->Guy Martin|++Giacomo Agostini|
|Move-\>Glencrutchery Road-\>Giacomo Agostini->Peel road|Glencrutchery Road|
|Close-\>Braddan|++Guy Martin|
|END|  |
| **Input** | **Output** |
|Add-\>Glen Vine-\>Steve Hislop|Practice sessions:|
|Add-\>Ramsey road-\>John McGuinness |Braddan|
|Add-\>Glen Vine-\>Ian Hutchinson|++Geoff Duke|
|Add-\>Ramsey road-\>Dave Molyneux|++Mike Hailwood|
|Move-\>Ramsey road-\>Hugh Earnsson-\>Glen Vine|Glen Vine|
|Add-\>A18 Snaefell mountain road-\>Mike Hailwood|++Steve Hislop|
|Add-\>Braddan-\>Geoff Duke|++Ian Hutchinson|
|Move-\>A18 Snaefell mountain road-\>Mike Hailwood-\>Braddan|Ramsey road|
|Move-\>Braddan-\>John McGuinness-\>Glen Vine|++John McGuinness|
|Close-\>A18 Snaefell mountain road|++Dave Molyneux|
|END |  |
