DELETE FROM TravelCards
      WHERE JourneyId IN (SELECT TOP(3) j.Id
		            FROM Journeys AS j)

DELETE TOP(3) FROM Journeys
