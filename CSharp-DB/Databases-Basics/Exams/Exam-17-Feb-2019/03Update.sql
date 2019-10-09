UPDATE StudentsSubjects
   SET Grade = 6.00
 WHERE SubjectId IN (1, 2)
   AND Grade >= 5.50