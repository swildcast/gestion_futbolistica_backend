CREATE PROCEDURE sp_GetAllTeams
AS
BEGIN
    SELECT Id, Nombre, Ciudad, Estadio, AñoFundación
    FROM Teams
    ORDER BY Nombre
END
GO

CREATE PROCEDURE sp_GetAllPlayers
AS
BEGIN
    SELECT p.Id, p.Nombre, p.Posición, p.Edad, p.IdEquipo
    FROM Players p
    ORDER BY p.Nombre
END
GO

CREATE PROCEDURE sp_GetAllMatches
AS
BEGIN
    SELECT m.Id, m.Fecha, m.IdEquipoLocal, m.IdEquipoVisitante, m.GolesLocal, m.GolesVisitante
    FROM Matches m
    ORDER BY m.Fecha DESC
END
GO
