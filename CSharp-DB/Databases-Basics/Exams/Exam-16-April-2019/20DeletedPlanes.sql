CREATE TRIGGER tr_DeletedPlanes ON Planes FOR DELETE
AS
BEGIN
	INSERT INTO DeletedPlanes(Id, [Name], Seats, [Range])
	     SELECT d.Id, d.[Name], d.Seats,d.[Range]
		   FROM deleted AS d
END