INSERT INTO Teams (Nombre, Ciudad, Estadio, [AñoFundación])
VALUES (N'FC Barcelona', N'Barcelona', N'Camp Nou', 1899);

DECLARE @TeamId INT;
SELECT @TeamId = Id FROM Teams WHERE Nombre = N'FC Barcelona';

INSERT INTO Players (Nombre, [Posición], Edad, IdEquipo)
VALUES 
(N'Victor Valdes', N'Portero', 26, @TeamId),
(N'Carles Puyol', N'Defensa', 30, @TeamId),
(N'Gerard Pique', N'Defensa', 21, @TeamId),
(N'Dani Alves', N'Defensa', 25, @TeamId),
(N'Eric Abidal', N'Defensa', 28, @TeamId),
(N'Xavi Hernandez', N'Centrocampista', 28, @TeamId),
(N'Andres Iniesta', N'Centrocampista', 24, @TeamId),
(N'Sergio Busquets', N'Centrocampista', 20, @TeamId),
(N'Lionel Messi', N'Delantero', 21, @TeamId),
(N'Samuel Eto''o', N'Delantero', 27, @TeamId),
(N'Thierry Henry', N'Delantero', 30, @TeamId);
