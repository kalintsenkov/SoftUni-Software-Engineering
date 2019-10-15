UPDATE Items
   SET Price += Price *	0.27
 WHERE CategoryId IN (1, 2, 3)