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

%GiacomoAgostini$=7!!tv58ycb – The length is the same, but the name is not surrounded by **matching**** signs**.

$GeoffDuke$=6!!tuvz26n35dhe4w4 – The length doesn&#39;t **match** the **lengh** of the code.

&amp;JoeyDunlop&amp;!!tvndjef67t=14 – The length should be **before** the code.

The information must be in the **given order** , otherwise it is considered **invalid**. The **geohash code** you are looking for is with length **exactly**** as much as the given length in the message **. To** decrypt **the code you need to** increase **the value of** each symbol **from the geohashcode with the** given length **. If you find a** match **, you have to** print** the following message:

&quot; **Coordinates found! {nameOfRacer} -\&gt; {geohashcode}**&quot;

and stop the program. Otherwise, after every **invalid** message print:

&quot; **Nothing found!**&quot;

## Input / Constraints

- You will be receiving strings.
- There will always be a valid message.

## Output

- If you find the right coordinates, print: &quot;Coordinates found! {nameOfRacer} -\&gt; {geohashcode}&quot;.
- Otherwise, print: &quot;Nothing found!&quot;.

## Examples

| **Input** | **Output** |
| --- | --- |
| %GiacomoAgostini%=7!!hbqw&amp;GeoffDuke\*=6!!vjh]ziJoeyDunlop=10!!lkd,rwazdrMike??Hailwood=5!![pliu#SteveHislop#=16!!df%TU[Tj(h!!TT[S | Nothing found!Nothing found!Nothing found!Nothing found!Coordinates found! SteveHislop -\&gt; tv5dekdz8x11ddkc |
|   |
| Ian6Hutchinson=7!!\(58ycb4#MikeHailwood#!!&#39;gfzxgu6768=11slop%16!!plkdek/.8x11ddkc$Steve$=9Hhffjh\*DavMolyneux\*=15!!efgk#&#39;\_$&amp;UYV%h%RichardQ^uayle=16!!fr5de5kd | Nothing found!Nothing found!Nothing found!Coordinates found! DaveMolyneux -\&gt; tuvz26n35dhe4w4  |

# Problem 2. Practice sessions

Write a program, that keeps information about **roads** and **the racers** who practice on them.  When the practice begins, you&#39;re going to start receiving data until you get the &quot; **END**&quot; message. There are three possible commands:

- &quot;Add-\&gt;{road}-\&gt;{racer}&quot;
  - Add the **road** if it **doesn&#39;t exist** in your collection and add the **racer** to it.
- &quot;Move-\&gt;{currentRoad}-\&gt;{racer}-\&gt;{nextRoad}&quot;
  - Find the **racer** on the **current road** and move him to the **next one**** , **nly if he** exists **in the** current road. **Both roads will always be** valid **and will** already exist**.
- &quot;Close-\&gt;{road}&quot;
  - Find the **road** and **remove** it from the sessions, **along**** with **the** racers **on it** if it exists**.

In the end, print all of the **roads** with the **racers** who have practiced and **ordered by the count of the racers in descending order** , **then by** the **roads** in **ascending** order. The output must be in the following format:

**Practice sessions:**

**{road}**

**++{racer}**

**++{racer}**

**++{racer}**

………………………..

## Input / Constraints

- You will be receiving lines of information in the format described above, until you receive the **&quot;**** END ****&quot;** command.
- The input will always be in the right format.
- Both **roads** from the &quot; **Move**&quot; command will always be **valid** and you don&#39;t need to check them explicitly.

## Output

- Print the **roads** withtheir **racers** in the **format described above**.

## Examples

| **Input** | **Output** |
| --- | --- |
| Add-\&gt;Glencrutchery Road-\&gt;Giacomo AgostiniAdd-\&gt;Braddan-\&gt;Geoff DukeAdd-\&gt;Peel road-\&gt;Mike HailwoodAdd-\&gt;Glencrutchery Road-\&gt;Guy MartinMove-\&gt;Glencrutchery Road-\&gt;Giacomo Agostini-\&gt;Peel roadClose-\&gt;BraddanEND | Practice sessions:Peel road++Mike Hailwood++Giacomo AgostiniGlencrutchery Road++Guy Martin |
|   |
| Add-\&gt;Glen Vine-\&gt;Steve HislopAdd-\&gt;Ramsey road-\&gt;John McGuinness Add-\&gt;Glen Vine-\&gt;Ian HutchinsonAdd-\&gt;Ramsey road-\&gt;Dave MolyneuxMove-\&gt;Ramsey road-\&gt;Hugh Earnsson-\&gt;Glen VineAdd-\&gt;A18 Snaefell mountain road-\&gt;Mike HailwoodAdd-\&gt;Braddan-\&gt;Geoff DukeMove-\&gt;A18 Snaefell mountain road-\&gt;Mike Hailwood-\&gt;BraddanMove-\&gt;Braddan-\&gt;John McGuinness-\&gt;Glen VineClose-\&gt;A18 Snaefell mountain roadEND | Practice sessions:Braddan++Geoff Duke++Mike HailwoodGlen Vine++Steve Hislop++Ian HutchinsonRamsey road++John McGuinness++Dave Molyneux |