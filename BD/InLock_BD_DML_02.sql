INSERT INTO TiposUsuarios (Descricao)
VALUES ('Administrador') 
, ('Cliente');


INSERT INTO Estudios (Descricao)
VALUES ('Blizzard') ,
('Rockstar Studio'),
('Square Enix');

SELECT * FROM Estudios;

INSERT INTO Usuarios (Email, Senha, TipoUsuarioId)
VALUES ('admin@admin.com' , 'admin' , 1),
('cliente@cliente.com', 'cliente', 2);


INSERT INTO Jogos (Nome, Descricao, DataLancamento, Valor, EstudioId)
VALUES ('Diablo 3', '� um jogo que cont�m bastante a��o e �
viciante, seja voc� um novato ou um f�', '2012/05/15', 99.00, 1),
('Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western',
'2018/10/26',120.00, 2);

UPDATE Usuarios
SET Email = 'admin@admin.com'
WHERE Id = 1;

