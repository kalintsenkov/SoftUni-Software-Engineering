# Animal Sanctuary

Create a program that decrypts messages about animals, their kind and the country they are in. You will be given a number **n** – the number of **lines** , which you will receive. Afterwards on the next **n lines** , you will receive the **messages**. You are looking for:

- **animalName**
  - **oo** contains **any ASCII character except for &quot;;&quot;**
- **animalKind**
  - **oo** contains **any ASCII character except for &quot;;&quot;**
- **animalCountry**
  - **oo** contains **only letters and spaces**

A **valid** message is in the following **format** : **&quot;n:{animalName};t:{animalKind};c--{animalCountry}&quot;**

The **output names, kinds** and **countries** of the animals should contain **only letters** and **white spaces. For example:**
&quot; **K@o$5a#la Be^4a5r**&quot; is a **valid** match, but we need to print only – &quot; **Koala Bear**&quot;. After each **valid message** , you should print a line in the format:

&quot; **{animalName} is a {animalKind} from {country}&quot;**

You need to knowthe **total weight** of **all** the **animals.** The weight of **each**** animal alone **is** calculated **by the** sum **of** every digit **in the** name **andthe** kind **of** the animal **. In the end print a line in the following** format **with the following** message**:

**&quot;Total weight of all animals is {weight}KG&quot;**.

## Input / Constraints

- First line will be a number **n** in range [1…100].
- The next **n** lines will be **strings**.

## Output

- Print each **valid** message in the format described above.
- Print the **total weight** of **all animals**.

## Examples

| **Input** | **Output** |
| --- | --- |
| 3n:M5%ar4#le@y;t:B3#e!!a2#2r;c--Australian:G3e%6org34e;t:Cˆ$at2%;c--African:AlicE:Won;c-India | Marley is a Bear from AustraliaGeorge is a Cat from AfricaTotal weight of animals: 34KG |
| |
| 4n:Bo^%4b35454bie#$;t:Ele5ph#$34a%nt;c--African:Honey;t:Ti^^5ger;c--Indiabla;t:1234a;c--American:A#$@545n;t:Cat241$@#23;cGermany | Bobbie is a Elephant from AfricaHoney is a Tiger from IndiaTotal weight of animals: 42KG |

# Feed the Animals

Create a program that organizes the **daily feeding** of **animals**. You need to keep information about **animals** , their **daily food limit** and the **areas** of the Wildlife Refuge **they**** live ****in**. You will be receiving **lines** with commands until you receive the **&quot;Last Info&quot;** message.  There are two **possible** commands:

- **&quot;Add:{animalName}:{dailyFoodLimit}:{area}&quot;:**
  - **oo**** Add **the** animal **and** its ****daily food limit** to your records. It is guaranteed that the **names** of the animals are **unique** and there will **never** be animals with the **same** name. **If** it already **exists** , just increase the value of the **daily**** food ****limit** with the **current** one that is **given**.
- **&quot;Feed:{animalName}:{food}:{area}&quot;:**
  - **oo**** Check **if the animal** exists **and if** it does **,** reduce **its daily** food limit **with the given** food ****for**** feeding **. If its** limit **reaches** 0 **or** less **, the** animal **is considered** successfully fed **and you need to** remove **it from your** records **and** print **the following** message**:
    - **&quot;{animalName} was successfully fed&quot;**

You need to know **the count of**** hungry ****animals** there are left in **each area** in the end. If an animal has daily food **limit above 0** , it is considered **hungry**.

In the end, you have to **print each animal** with its **daily** food **limit** sorted in **descending order** by the **daily food limit** and **then by** its **name** in **ascending** order in the following format:

**Animals:**

**{animalName} -\&gt; {dailyFoodLimit}g**

**{animalName} -\&gt; {dailyFoodLimit}g**

Afterwards, **print** the **areas** with the **count of**  **animals** , which are **not**** fed **in** descending **order by the** count **of** animals. **If an** area **has** 0 ****hungry animals** in it, **don&#39;t** print it. The **output** must be in the following **format** :

**Areas**** with hungry animals:**

**{areaName} : {countOfUnfedAnimals}**

**{areaName} : {countOfUnfedAnimals}**

## Input / Consrtaints

- You will be receiving linesuntil you receive the **&quot;**** Last Info ****&quot;** command.
- The **food** comes in **grams** and is an **integer** number in the range [1...100000].
- The input will **always** be **valid**.
- There will never be a case, in which an animal is in two or more areas at the same time.

## Output

- Print the appropriate message after the **&quot;Feed&quot;** command, **if** an **animal** is **fed**.
- Print the animals with their **daily food limit** in the **format** described above.
- Print the **areas** with the **count of unfed**** animals **in them in the** format** described above.

## Examples

| **Input** | **Output** |
| --- | --- |
| Add:Maya:7600:WaterfallAreaAdd:Bobbie:6570:DeepWoodsAreaAdd:Adam:4500:ByTheCreekAdd:Jamie:1290:RiverAreaAdd:Gem:8730:WaterfallAreaAdd:Maya:1230:WaterfallAreaAdd:Jamie:560:RiverAreaFeed:Bobbie:6300:DeepWoodsAreaFeed:Adam:4650:ByTheCreekFeed:Jamie:2000:RiverAreaLast Info | Adam was successfully fedJamie was successfully fedAnimals:Maya -\&gt; 8830gGem -\&gt; 8730gBobbie -\&gt; 270gAreas with hungry animals:WaterfallArea : 2DeepWoodsArea : 1 |
| |
| Add:Bonie:3490:RiverAreaAdd:Sam:5430:DeepWoodsAreaAdd:Bonie:200:RiverAreaAdd:Maya:4560:ByTheCreekFeed:Maya:2390:ByTheCreekFeed:Bonie:3500:RiverAreaFeed:Johny:3400:WaterFallFeed:Sam:5500:DeepWoodsAreaLast Info | Sam was succesfully fedAnimals:Maya -\&gt; 2170gBonie -\&gt; 190gAreas with hungry animals:RiverArea : 1ByTheCreek : 1 |