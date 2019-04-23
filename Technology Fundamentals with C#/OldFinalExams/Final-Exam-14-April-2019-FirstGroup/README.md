# Problem.1 Arriving in Kathmandu

Write a program that **decrypts messages** , which containinformationaboutcoordinates. You are looking for **names of peaks** in the Himalayas and their [geohash](https://en.wikipedia.org/wiki/Geohash) coordinates. Keep reading lines until you receive the &quot; **Last note**&quot; message.

Here is your **cipher** :

- **Name of the peak**
  - It is consisted of **letters (upper and lower), numbers** and some of the following characters between its letters – &quot; **!**&quot; &quot; **@**&quot; &quot; **#**&quot; &quot; **$**&quot; &quot; **?**&quot;. Example for valid names: &quot;!@K?#2!#&quot; (K2).
- **The length of the geohashcode**
  - Begins **after** the &quot; **=**&quot; (equals) sign and is consisted only of numbers.
- **The geohash code**
  - Begins after these symbols – &quot; **\&lt;\&lt;**&quot;, may contain anything and the message always ends with it.

**Examples for valid input:**

&quot;!Ma$$ka!lu!@=9\&lt;\&lt;ghtucjdhs&quot; – all the components are there – **name of the peek** , **length** of the geohashcode and a **geohashcode**.

&quot;!@Eve?#rest!#=7\&lt;\&lt;vbnfhfg&quot;

**Examples of invalid input:**

&quot;anna@fg\&lt;\&lt;jhsd@bx!=4&quot; – **their order is wrong**. The name should be first, the length after and the code last.

&quot;#n...s!n-\&lt;\&lt;tyuhgf4&quot; – **the length is missing** and the **name contains dots.**

**&quot;** Nan$ga!Parbat=8\&lt;\&lt;gh2tn – **the**** length** of the geohash code doesn&#39;t match the given number.

The **geohash code** you are looking for is with **length**** exactly **as much as the** given length **in the message and the information must be in the** exact given order **, otherwise it is considered** invalid**. If you find it, print the following message:

&quot; **Coordinates found! {nameOfMountain} -\&gt; {geohashcode}**&quot;

Otherwise print: &quot; **Nothing found!**&quot; after every **invalid** message.

## Input / Constraints

- You will be receiving strings until you get the &quot; **Last note**&quot; message.

## Output

- If you find the right coordinates, print: &quot; **Coordinates found! {nameOfMountain} -\&gt; {geohashcode}**&quot;.
- If the message is invalid, print: &quot; **Nothing found!**&quot;.

## Examples

| **Input** | **Output** |
| --- | --- |
| !@Ma?na?sl!u@=7\&lt;\&lt;tv58ycb4845E!ve?rest=.6\&lt;\&lt;tuvz26!K@2.,##$=4\&lt;\&lt;tvnd!Shiha@pan@gma##9\&lt;\&lt;tgfgegu67!###Anna@pur@na##=16\&lt;\&lt;tv5dekdz8x11ddkcLast note | Nothing found!Nothing found!Nothing found!Nothing found!Coordinates found! Annapurna -\&gt; tv5dekdz8x11ddkc |
| |
| Ka?!#nch@@en@ju##nga@=3\&lt;\&lt;thfbghvn=9Cho?@#Oyu\&lt;\&lt;thvb7ydhtNan??ga#Par!ba!t?=16\&lt;\&lt;twm03q2rx5hpmyr6Dhau??la#gi@ri?!#=3\&lt;\&lt;bvnfhrtiuyLast note | Nothing found!Nothing found!Coordinates found! NangaParbat -\&gt; twm03q2rx5hpmyr6Nothing found! |

# Problem 2. On the Way to Annapurna

Create a program, that lists **stores** and the **items** that can be found in them. You are going to be receiving **commands** with the information you need until you get the &quot; **End**&quot; command. There are **three possible commands** :

- &quot; **Add** -\&gt;{Store}-\&gt;{Item}&quot;
  - **Add** the **store** and the **item** in your diary. If the store already **exists** , add just the item.

- **&quot;Add** -\&gt;{Store}-\&gt;{Item},{Item1}…,{ItemN}&quot;
  - **Add the store and the items to** your notes. **If the store already exists** in the diary – **add just the items** to it.
- &quot; **Remove** -\&gt;{Store}&quot;
  - **Remove the store** and its items from your diary, **if it exists**.

In the end, print the collection **sorted by the count of the items** in **descending order** and **then by the names of the stores** , again, **in descending order** in the following format:

**Stores list:**

**{Store}**

**\&lt;\&lt;{Item}\&gt;\&gt;**

**\&lt;\&lt;{Item}\&gt;\&gt;**

**\&lt;\&lt;{Item}\&gt;\&gt;**

## Input / Constraints

- You will be receiving information until the &quot; **END**&quot; command is given.
- There will always be **at least one** store in the diary.
- Input will always be **valid** , there is no need to check it explicitly.

## Output

- Print the list of stores in the format given above.

## Examples

| **Input** | **Output** |
| --- | --- |
| Add-\&gt;PeakSports-\&gt;Map,Navigation,CompassAdd-\&gt;Paragon-\&gt;SunscreenAdd-\&gt;Groceries-\&gt;Dried-fruit,NutsAdd-\&gt;Groceries-\&gt;NutsAdd-\&gt;Paragon-\&gt;TentRemove-\&gt;ParagonAdd-\&gt;Pharmacy-\&gt;Pain-killersEND | Stores list:PeakSports\&lt;\&lt;Map\&gt;\&gt;\&lt;\&lt;Navigation\&gt;\&gt;\&lt;\&lt;Compass\&gt;\&gt;Groceries\&lt;\&lt;Dried-fruit\&gt;\&gt;\&lt;\&lt;Nuts\&gt;\&gt;\&lt;\&lt;Nuts\&gt;\&gt;Pharmacy\&lt;\&lt;Pain-killers\&gt;\&gt; |
| |
| Add-\&gt;Peak-\&gt;Waterproof,UmbrellaAdd-\&gt;Groceries-\&gt;Water,Juice,FoodAdd-\&gt;Peak-\&gt;TentAdd-\&gt;Peak-\&gt;Sleeping-BagAdd-\&gt;Peak-\&gt;JacketAdd-\&gt;Groceries-\&gt;LighterRemove-\&gt;GroceriesRemove-\&gt;StoreEND | Stores list:Peak\&lt;\&lt;Waterproof\&gt;\&gt;\&lt;\&lt;Umbrella\&gt;\&gt;\&lt;\&lt;Tent\&gt;\&gt;\&lt;\&lt;Sleeping-Bag\&gt;\&gt;\&lt;\&lt;Jacket\&gt;\&gt; |