CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1;
	DECLARE @currentLetter CHAR;

	WHILE(@counter <= LEN(@word))
	BEGIN
		SET @currentLetter = SUBSTRING(@word, @counter, 1)

		DECLARE @charIndex INT = CHARINDEX(@currentLetter, @setOfLetters);

		IF (@charIndex <= 0)
		BEGIN
			RETURN 0;
		END

		SET @counter += 1;
	END

	RETURN 1;
END