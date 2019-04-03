Problem 1 – Concert
===================

*Mandy was hired to accept the group applications for the upcoming concert. She
thought that it would be easy but now she is in trouble. She needs a programmer
to make an application that will help her to safe the concert. She needs you.*

You will read commands until you receive **"start of concert"** command.

There are **two types** of commands:

-   "**Add; {bandName}; {member 1}, {member 2}, {member 3}"** - applies a band
    and a **list of members** to the concert. All members must be **unique** so
    don't add duplicates. If you receive the **same band** twice add only those
    members that **aren't present** in the list.

-   **"Play; {bandName}; {time}"** – the band with the given name plays an
    **amount of time** on the stage. If you receive a **band** that has
    **already applied** in the concert, just **increase** the band **time.**

If in both commands the band **does not exist**, add it.

At the end you have to print the **total time** and the bands ordered by the
**time** on stage in **descending** order, then by **band name** in
**ascending** order.

Also the **final input line** will be "**{bandName}**" and you have to print
**all members** for this band in **insertion order**.

Input / Constraints
-------------------

-   The **time** of the bands – **integer** in range **[0 – 231 - 1]**

-   There will always be at least one **member** in the group

-   The bands will always have **time** on stage

-   The final input line will always contain an **existing** band name

-   Input will always be valid and in the range specified. You don’t need to
    check it

Output
------

**Total time: {totalTime}**

**{firstBandName} -\> {firstBandTime}**

**{secondBandName} -\> {secondBandTime}**

**{thirdBandName} -\> {thirdBandTime}**

**…**

**{bandName}**

**=\> {firstMemberName}**

**=\> {secondMemberName}**

**=\> {thirdMemberName}**

**…**

Examples
--------

| **Input**                                                                                                                                                                                                                                                                                                                                                                                                                               | **Output**                                                                                                                                                                                               |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Play; The Beatles; 2584 Add; The Beatles; John Lennon, Paul McCartney, George Harrison, Ringo Starr Add; Eagles; Glenn Frey, Don Henley, Bernie Leadon, Randy Meisner Play; Eagles; 1869 Add; The Rolling Stones; Brian Jones, Mick Jagger, Keith Richards Add; The Rolling Stones; Brian Jones, Mick Jagger, Keith Richards, Bill Wyman, Charlie Watts, Ian Stewart Play; The Rolling Stones; 4239 start of concert The Rolling Stones | Total time: 8692 The Rolling Stones -\> 4239 The Beatles -\> 2584 Eagles -\> 1869 The Rolling Stones =\> Brian Jones =\> Mick Jagger =\> Keith Richards =\> Bill Wyman =\> Charlie Watts =\> Ian Stewart |
|                                                                                                                                                                                                                                                                                                                                                                                                                                         |                                                                                                                                                                                                          |
| Add; The Beatles; John Lennon, Paul McCartney Add; The Beatles; Paul McCartney, George Harrison Add; The Beatles; George Harrison, Ringo Starr Play; The Beatles; 3698 Play; The Beatles; 3828 start of concert The Beatles                                                                                                                                                                                                             | Total time: 7526 The Beatles -\> 7526 The Beatles =\> John Lennon =\> Paul McCartney =\> George Harrison =\> Ringo Starr                                                                                 |

Problem 02. Song Encryption
===========================

*Now that you've helped Mandy to accept the group applications it's time to
assist her with a security problem. You are tasked to encrypt all songs from the
set list so that if someone steals it they won't be able to leak it online.*

Your task is to write a program that encrypts information about artists and
their songs.

**Until** you receive the command **"end"** you should read lines in following
format :"**{artist}:{song}",** and check if it's **valid**, considering the
following rules:

-   **Artist** – **starts** with **capital letter**, followed by **lowercase
    letters.**

    -   It can also **contains apostrophe ( ' ),** and **whitespace " ";**

>   **Valid group name:** Red hot chili peppers, Eminem, Guns n' roses

>   **Invalid group name**: ReD Hot CiLly PePers, sLipKnot, guns n'roses

-   **Song – contains only capital letters, and whitespaces.**

>   **Valid songs:** BACK IN BLACK, BLEED IT OUT, KILLSHOT

>   **Invalid songs:** \#BaCk IN black, BLEED \$IT\$ OUTt, &KILLSHoT

After you validate the lines of an input, you should encrypt the information. In
order to do that, you have to follow the rules below:

-   **First you need to find a key for encryption.**

    -   Your key is the **length** of the **artist (e.g. "Eminem" – key: 6)**

-   You have to **increment** the **ASCII value** of each symbol of the input,
    with the **key length**

>   **(**e.g. "char" **'a'** -\> **'g')**

-   Be careful if your key length is **bigger** than the ASCII value of a letter
    **'z'** or **'Z'**. In this case you should start from a letter **'a'.
    (**e.g. key:6 letter – '**x**', encrypted letter – '**d**'**)**

-   You should **NOT ENCRYPT** the following characters: **whitespaces**, and
    **apostrophes**

-   You also should **replace ':'** with the sign **'\@'**

Input / Constraints
-------------------

Until you receive **"end"** command you should read from the console.

-   **Line of input** – Artist name and song, **separated** by **":"**,
    containing only **ASCII symbols.**

-   Allowed working time for your program: 0.1 seconds.

-   Allowed memory: 16 MB.

Output
------

After every line of input, you should print:

-   **If** line is valid – **encrypted information** in following format:

**"Successful encryption: {encryptedArtist}\@{encryptedSong}".**

-   **If** line is not valid – print the following message: **"Invalid input!"**

Examples
--------

| **Input**                                                                                                     | **Output**                                                                                                                                              |
|---------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| Eminem:VENOM Linkin park:NUMB Drake:NONSTOP Adele:HELLO end                                                   | Successful encryption: Ksotks\@BKTUS Successful encryption: Wtyvty alcv\@YFXM Successful encryption: Iwfpj\@STSXYTU Successful encryption: Fijqj\@MJQQT |
| **Input**                                                                                                     | **Output**                                                                                                                                              |
| Michael Jackson:ANOTHER PART OF ME Adele:ONE AND ONLY Guns n'roses:NOVEMBER RAIN Christina Aguilera: HuRt end | Invalid input! Successful encryption: Fijqj\@TSJ FSI TSQD Successful encryption: Sgze z'daeqe\@ZAHQYNQD DMUZ Invalid input!                             |
