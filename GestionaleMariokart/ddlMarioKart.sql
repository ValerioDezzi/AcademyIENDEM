CREATE TABLE Giocatore (
    id INT PRIMARY KEY IDENTITY (1,1),
    nomeGiocatore NVARCHAR(100) NOT NULL,
    creditiBudget INT NOT NULL DEFAULT 10
);

CREATE TABLE Personaggio (
    id INT PRIMARY KEY IDENTITY (1,1),
    nomePersonaggio NVARCHAR(100) UNIQUE NOT NULL,
    categoria NVARCHAR(50) NOT NULL CHECK(categoria IN('50cc','100cc','150cc')),
    costo INT NOT NULL CHECK (costo BETWEEN 1 AND 4)
);
CREATE TABLE Squadra (
    id INT PRIMARY KEY IDENTITY (1,1),
    nome NVARCHAR(100)  UNIQUE NOT NULL,
    personaggio50Rif INT NOT NULL,
    personaggio100Rif INT NOT NULL,
    personaggio150Rif INT NOT NULL,
    giocatoreRif INT NOT NULL,
    costoSquadra INT,
    FOREIGN KEY (personaggio50Rif) REFERENCES personaggio(Id),
    FOREIGN KEY (personaggio100Rif) REFERENCES personaggio(Id),
    FOREIGN KEY (personaggio150Rif) REFERENCES personaggio(Id),
    FOREIGN KEY (giocatoreRif) REFERENCES giocatore(Id) ON DELETE CASCADE
);
drop table if exists Personaggio;
drop table if exists Giocatore;
drop table if exists Squadra;
use MarioKart
select*from Giocatore

INSERT INTO Giocatore (nomegiocatore, creditibudget)
VALUES ('mario', 10), ('mariottide', 10), ('maria', 10);

INSERT INTO Personaggio (nomePersonaggio, categoria, costo)
VALUES 
    ('TipoTimido', '50cc', 1),
    ('Toadette', '100cc', 2),
    ('Yoshi', '150cc', 3);

	INSERT INTO Squadra (nome, personaggio50Rif, personaggio100Rif, personaggio150Rif, giocatoreRif)
VALUES 
    ('Squadra1', 1, 2, 3, 3),
    ('Squadra2', 4, 5, 6, 2);

	SELECT * FROM Squadra
	SELECT * FROM Personaggio


	