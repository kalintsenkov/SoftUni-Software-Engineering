CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(MAX), @destination NVARCHAR(MAX), @peopleCount INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @count INT 
    	DECLARE @sum DECIMAL(15, 2)

	IF (@peopleCount <= 0)
	BEGIN
		RETURN 'Invalid people count!'
	END

	SET @count = ( SELECT COUNT(*)
		         FROM Tickets AS t
		         JOIN Flights AS f
		           ON f.Id = t.FlightId
		        WHERE f.Origin = @origin
		          AND f.Destination = @destination)

    	IF (@count = 0)
	BEGIN
		RETURN 'Invalid flight!'
	END
	
	SET @sum = ( SELECT t.Price
		       FROM Tickets AS t
		       JOIN Flights AS f
		         ON f.Id = t.FlightId
		      WHERE f.Origin = @origin
		        AND f.Destination = @destination)

    	SET @sum *= @peopleCount

	RETURN 'Total price ' + CAST(@sum AS NVARCHAR)
END
