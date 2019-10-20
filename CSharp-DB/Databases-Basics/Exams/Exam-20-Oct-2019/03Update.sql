UPDATE Reports
   SET CloseDate = GETDATE()
 WHERE CloseDate IS NULL