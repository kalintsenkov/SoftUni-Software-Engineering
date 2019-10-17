CREATE FUNCTION udf_GetPromotedProducts 
		(@currentDate DATE, @startDate DATE, @endDate DATE, 
		@discount DECIMAL(15, 2), @firstItemId INT, 
		@secondItemId INT, @thirdItemId INT)
RETURNS VARCHAR(MAX)
AS
BEGIN

	IF (NOT EXISTS(
		SELECT * FROM Items
		WHERE Id = @firstItemId))
	BEGIN
		RETURN 'One of the items does not exists!'
	END

	IF (NOT EXISTS(
		SELECT * FROM Items
		WHERE Id = @secondItemId))
	BEGIN
		RETURN 'One of the items does not exists!'
	END

	IF (NOT EXISTS(
		SELECT * FROM Items
		WHERE Id = @thirdItemId))
	BEGIN
		RETURN 'One of the items does not exists!'
	END

	DECLARE @firstName VARCHAR(50) = (SELECT [Name]
					    FROM Items
					   WHERE Id = @firstItemId)
	DECLARE @secondName VARCHAR(50) = (SELECT [Name]
					     FROM Items
					    WHERE Id = @secondItemId)
	DECLARE @thirdName VARCHAR(50) = (SELECT [Name]
					    FROM Items
					   WHERE Id = @thirdItemId)

	DECLARE @firstDiscount DECIMAL(15, 2) = (SELECT Price
						   FROM Items
						  WHERE Id = @firstItemId)
	DECLARE @secondDiscount DECIMAL(15, 2) = (SELECT Price
						   FROM Items
						  WHERE Id = @secondItemId)
	DECLARE @thirdDiscount DECIMAL(15, 2) = (SELECT Price
						   FROM Items
						  WHERE Id = @thirdItemId)

	SET @firstDiscount -= @firstDiscount * (@discount / 100)
	SET @secondDiscount -= @secondDiscount * (@discount / 100)
	SET @thirdDiscount -= @thirdDiscount * (@discount / 100)

	IF (@currentDate NOT BETWEEN @startDate AND @endDate)
	BEGIN
		RETURN 'The current date is not within the promotion dates!'
	END

	RETURN CONCAT(@firstName, ' ', 'price: ', @firstDiscount, ' ', '<-> ', 
		      @secondName, ' ', 'price: ', @secondDiscount, ' ', '<-> ', 
		      @thirdName, ' ', 'price: ', @thirdDiscount)
END
