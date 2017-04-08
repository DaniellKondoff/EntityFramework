USE MinionsDB

EXEC usp_IncraseAge @MinionID

SELECT Name, Age
FROM Minions
WHERE Id = @MinionID