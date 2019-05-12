# 01. Animal Sanctuary

Create a program that decrypts messages about animals, their kind and the country they are in. You will be given a number **n** – the number of **lines** , which you will receive. Afterwards on the next **n lines** , you will receive the **messages**. You are looking for:

- **animalName**
  - contains **any ASCII character except for &quot;;&quot;**
- **animalKind**
  - contains **any ASCII character except for &quot;;&quot;**
- **animalCountry**
  - contains **only letters and spaces**

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
| 3 | |
|n:M5%ar4#le@y;t:B3#e!!a2#2r;c--Australia | Marley is a Bear from Australia |
|n:G3e%6org34e;t:Cˆ$at2%;c--Africa | George is a Cat from Africa |
|n:AlicE:Won;c-India | Total weight of animals: 34KG |
| **Input** | **Output** |
| 4 | |
|n:Bo^%4b35454bie#$;t:Ele5ph#$34a%nt;c--Africa | Bobbie is a Elephant from Africa |
|n:Honey;t:Ti^^5ger;c--India | Honey is a Tiger from India |
|bla;t:1234a;c--America |Total weight of animals: 42KG |
|n:A#$@545n;t:Cat241$@#23;cGermany |  |

# 02. Feed the Animals

Create a program that organizes the **daily feeding** of **animals**. You need to keep information about **animals** , their **daily food limit** and the **areas** of the Wildlife Refuge **they**** live ****in**. You will be receiving **lines** with commands until you receive the **&quot;Last Info&quot;** message.  There are two **possible** commands:

- **&quot;Add:{animalName}:{dailyFoodLimit}:{area}&quot;:**
  - Add **the** animal **and** its ****daily food limit** to your records. It is guaranteed that the **names** of the animals are **unique** and there will **never** be animals with the **same** name. **If** it already **exists** , just increase the value of the **daily**** food ****limit** with the **current** one that is **given**.
- **&quot;Feed:{animalName}:{food}:{area}&quot;:**
  - Check **if the animal** exists **and if** it does **,** reduce **its daily** food limit **with the given** food ****for**** feeding **. If its** limit **reaches** 0 **or** less **, the** animal **is considered** successfully fed **and you need to** remove **it from your** records **and** print **the following** message**:
    - **&quot;{animalName} was successfully fed&quot;**

You need to know **the count of**** hungry ****animals** there are left in **each area** in the end. If an animal has daily food **limit above 0** , it is considered **hungry**.

In the end, you have to **print each animal** with its **daily** food **limit** sorted in **descending order** by the **daily food limit** and **then by** its **name** in **ascending** order in the following format:

**Animals:**

**{animalName} -> {dailyFoodLimit}g**

**{animalName} -> {dailyFoodLimit}g**

Afterwards, **print** the **areas** with the **count of**  **animals** , which are **not fed** in **descending** order by the **count** of **animals**. If an **area** has **0 hungry animals** in it, **don&#39;t** print it. The **output** must be in the following **format** :

**Areas with hungry animals:**

**{areaName}&nbsp;:&nbsp;{countOfUnfedAnimals}**

**{areaName}&nbsp;:&nbsp;{countOfUnfedAnimals}**

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
|Add:Maya:7600:WaterfallArea | Adam was successfully fed |
|Add:Bobbie:6570:DeepWoodsArea | Jamie was successfully fed |
|Add:Adam:4500:ByTheCreek | Animals: |
|Add:Jamie:1290:RiverArea | Maya&nbsp;->&nbsp;8830g |
|Add:Gem:8730:WaterfallArea | Gem&nbsp;->&nbsp;8730g |
|Add:Maya:1230:WaterfallArea | Bobbie&nbsp;->&nbsp;270g |
|Add:Jamie:560:RiverArea | Areas with hungry animals: |
|Feed:Bobbie:6300:DeepWoodsArea | WaterfallArea&nbsp;:&nbsp;2 |
|Feed:Adam:4650:ByTheCreek | DeepWoodsArea&nbsp;:&nbsp;1 |
|Feed:Jamie:2000:RiverArea | |
|Last Info |  |
| **Input** | **Output** |
|Add:Bonie:3490:RiverArea |Sam was succesfully fed |
|Add:Sam:5430:DeepWoodsArea |Animals: |
|Add:Bonie:200:RiverArea |Maya&nbsp;->&nbsp;2170g |
|Add:Maya:4560:ByTheCreek |Bonie&nbsp;->&nbsp;190g |
|Feed:Maya:2390:ByTheCreek |Areas with hungry animals: |
|Feed:Bonie:3500:RiverArea |RiverArea&nbsp;:&nbsp;1 |
|Feed:Johny:3400:WaterFall |ByTheCreek&nbsp;:&nbsp;1 |
|Feed:Sam:5500:DeepWoodsArea | |
|Last Info |  |
