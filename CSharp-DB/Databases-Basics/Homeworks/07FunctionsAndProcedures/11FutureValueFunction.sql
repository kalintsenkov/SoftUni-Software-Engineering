CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(8, 4), @interestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL (8, 4)
AS
BEGIN
	DECLARE @result DECIMAL(8, 4)
	SET @result = @sum * (POWER((1 + @interestRate), @numberOfYears)) 
	RETURN @result
END