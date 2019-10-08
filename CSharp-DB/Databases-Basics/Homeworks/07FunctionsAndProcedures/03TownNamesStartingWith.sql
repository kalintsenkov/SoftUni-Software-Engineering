CREATE PROC usp_GetTownsStartingWith(@text NVARCHAR(MAX))
AS
BEGIN
	SELECT t.[Name]
	  FROM Towns AS t
	 WHERE LEFT(t.[Name], LEN(@text)) = @text
END