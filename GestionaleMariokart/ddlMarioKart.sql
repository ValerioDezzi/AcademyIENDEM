CREATE TABLE Giocatore (
    id INT PRIMARY KEY IDENTITY (1,1),
    nome_giocatore NVARCHAR(100) NOT NULL,
    crediti_budget INT NOT NULL DEFAULT 10
);

CREATE TABLE Personaggio (
    id INT PRIMARY KEY IDENTITY (1,1),
    nome_personaggio NVARCHAR(100) UNIQUE NOT NULL,
    categoria NVARCHAR(50) NOT NULL CHECK(categoria IN('50cc','100cc','150cc')),
    costo INT NOT NULL CHECK (costo BETWEEN 1 AND 4)
);
CREATE TABLE Squadra (
    id INT PRIMARY KEY IDENTITY (1,1),
    nome NVARCHAR(100) NOT NULL,
    personaggio50Rif INT NOT NULL,
    personaggio100Rif INT NOT NULL,
    personaggio150Rif INT NOT NULL,
    giocatoreRif INT NOT NULL,
    costoSquadra INT,
    FOREIGN KEY (personaggio50Rif) REFERENCES personaggio(Id),
    FOREIGN KEY (personaggio100Rif) REFERENCES personaggio(Id),
    FOREIGN KEY (personaggio150Rif) REFERENCES personaggio(Id),
    FOREIGN KEY (giocatoreRif) REFERENCES giocatore(Id)
);