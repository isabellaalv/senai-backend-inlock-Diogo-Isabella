SELECT * FROM Usuarios;
SELECT * FROM TiposUsuarios;
SELECT * FROM Estudios;
SELECT * FROM Jogos;

SELECT Jogos.Nome, Jogos.Descricao, Estudios.Descricao AS NomeEstudio
FROM Jogos
INNER JOIN Estudios ON Estudios.Id = Jogos.EstudioId;

SELECT Jogos.Nome, Jogos.Descricao, Estudios.Descricao AS NomeEstudio
FROM Estudios
LEFT JOIN Jogos ON Jogos.Id = Estudios.Id;

SELECT * FROM Usuarios
WHERE Email = 'admi@adim.com' AND Senha = 'admin';

SELECT * FROM Jogos
WHERE Id = 1;

SELECT * FROM Estudios
WHERE Id = 1;