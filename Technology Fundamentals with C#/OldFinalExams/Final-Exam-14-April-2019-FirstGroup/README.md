# 01. Arriving in Kathmandu

Write a program that **decrypts messages** , which containinformationaboutcoordinates. You are looking for **names of peaks** in the Himalayas and their [geohash](https://en.wikipedia.org/wiki/Geohash) coordinates. Keep reading lines until you receive the &quot;**Last note**&quot; message.

Here is your **cipher** :

- **Name of the peak**
  - It is consisted of **letters (upper and lower), numbers** and some of the following characters between its letters – &quot; **!**&quot; &quot; **@**&quot; &quot; **#**&quot; &quot; **$**&quot; &quot; **?**&quot;. Example for valid names: &quot;!@K?#2!#&quot; (K2).
- **The length of the geohashcode**
  - Begins **after** the &quot; **=**&quot; (equals) sign and is consisted only of numbers.
- **The geohash code**
  - Begins after these symbols – &quot; **<<**&quot;, may contain anything and the message always ends with it.

**Examples for valid input:**

&quot;!Ma$$ka!lu!@=9\&lt;\&lt;ghtucjdhs&quot; – all the components are there – **name of the peek** , **length** of the geohashcode and a **geohashcode**.

&quot;!@Eve?#rest!#=7\&lt;\&lt;vbnfhfg&quot;

**Examples of invalid input:**

&quot;anna@fg\&lt;\&lt;jhsd@bx!=4&quot; – **their order is wrong**. The name should be first, the length after and the code last.

&quot;#n...s!n-\&lt;\&lt;tyuhgf4&quot; – **the length is missing** and the **name contains dots.**

**&quot;** Nan$ga!Parbat=8\&lt;\&lt;gh2tn – **the**** length** of the geohash code doesn&#39;t match the given number.

The **geohash code** you are looking for is with **length**** exactly **as much as the** given length **in the message and the information must be in the** exact given order **, otherwise it is considered** invalid**. If you find it, print the following message:

&quot;**Coordinates found! {nameOfMountain} -> {geohashcode}**&quot;

Otherwise print: &quot;**Nothing found!**&quot; after every **invalid** message.

## Input / Constraints

- You will be receiving strings until you get the &quot;**Last note**&quot; message.

## Output

- If you find the right coordinates, print: &quot;**Coordinates found! {nameOfMountain} -> {geohashcode}**&quot;.
- If the message is invalid, print: &quot;**Nothing found!**&quot;.

## Examples

| **Input** | **Output** |
| --- | --- |
|!@Ma?na?sl!u@=7<<tv58ycb4845 |Nothing found!|
|E!ve?rest=.6<<tuvz26 |Nothing found!|
|!K@2.,##$=4<<tvnd |Nothing found!|
|!Shiha@pan@gma##9<<tgfgegu67 |Nothing found!|
|!###Anna@pur@na##=16<<tv5dekdz8x11ddkc |Coordinates found! Annapurna -> tv5dekdz8x11ddkc|
|Last note |  |
| **Input** | **Output** |
|Ka?!#nch@@en@ju##nga@=3<<thfbghvn|Nothing found!|
|=9Cho?@#Oyu<<thvb7ydht| Nothing found!|
|Nan??ga#Par!ba!t?=16<<twm03q2rx5hpmyr6| Coordinates found! NangaParbat -> twm03q2rx5hpmyr6|
|Dhau??la#gi@ri?!#=3<<bvnfhrtiuy| Nothing found! |
|Last note |  |

# 02. On the Way to Annapurna

Create a program, that lists **stores** and the **items** that can be found in them. You are going to be receiving **commands** with the information you need until you get the &quot;**END**&quot; command. There are **three possible commands** :

- &quot;**Add**->{Store}->{Item}&quot;
  - **Add** the **store** and the **item** in your diary. If the store already **exists** , add just the item.

- &quot;**Add**->{Store}->{Item},{Item1}…,{ItemN}&quot;
  - **Add the store and the items to** your notes. **If the store already exists** in the diary – **add just the items** to it.
- &quot;**Remove**->{Store}&quot;
  - **Remove the store** and its items from your diary, **if it exists**.

In the end, print the collection **sorted by the count of the items** in **descending order** and **then by the names of the stores** , again, **in descending order** in the following format:

**Stores list:**

**{Store}**

**<<{Item}>>**

**<<{Item}>>**

**<<{Item}>>**

## Input / Constraints

- You will be receiving information until the &quot;**END**&quot; command is given.
- There will always be **at least one** store in the diary.
- Input will always be **valid** , there is no need to check it explicitly.

## Output

- Print the list of stores in the format given above.

## Examples

| **Input** | **Output** |
| --- | --- |
|Add->PeakSports->Map,Navigation,Compass|Stores list:|
|Add->Paragon->Sunscreen|PeakSports|
|Add->Groceries->Dried-fruit,Nuts|\<\<Map\>\>|
|Add->Groceries->Nuts|\<\<Navigation\>\>|
|Add->Paragon->Tent|\<\<Compass\>\>|
|Remove->Paragon|Groceries|
|Add->Pharmacy->Pain-killers|\<\<Dried-fruit\>\>|
|END | |\<\<Nuts\>\>|
| |\<\<Nuts\>\>|
| |Pharmacy|
| |\<\<Pain-killers\>\>|
| **Input** | **Output** |
|Add->Peak->Waterproof,Umbrella|Stores list:|
|Add->Groceries->Water,Juice,Food|Peak|
|Add->Peak->Tent|\<\<Waterproof\>\>|
|Add->Peak->Sleeping-Bag|\<\<Umbrella\>\>|
|Add->Peak->Jacket|\<\<Tent\>\>|
|Add->Groceries->Lighter|\<\<Sleeping-Bag\>\>|
|Remove->Groceries|\<\<Jacket\>\>|
|Remove->Store| |
|END | |
