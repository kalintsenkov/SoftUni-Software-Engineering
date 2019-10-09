ALTER TABLE Tickets
DROP CONSTRAINT FK__Tickets__FlightI__1DE57479

DELETE FROM Flights
      WHERE Destination = 'Ayn Halagim'