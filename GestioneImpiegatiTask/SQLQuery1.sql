CREATE TABLE Reparto (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome_reparto VARCHAR(100) NOT NULL
);

CREATE TABLE Provincia (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome_provincia VARCHAR(100) NOT NULL
);
DROP TABLE IF EXISTS citta
CREATE TABLE Citta (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome_citta VARCHAR(100) NOT NULL,
    provinciaRIF INT,
    FOREIGN KEY (provinciaRIF) REFERENCES Provincia(id)
);

CREATE TABLE Impiegati (
	id INT PRIMARY KEY IDENTITY (1,1),
    matricola VARCHAR(100) UNIQUE,
    nome VARCHAR(100) NOT NULL,
    cognome VARCHAR(100) NOT NULL,
    data_nascita DATE NOT NULL,
    ruolo VARCHAR(100),
    reparto VARCHAR(100) NOT NULL,
    indirizzo VARCHAR(255) NOT NULL,
    citta VARCHAR(100) NOT NULL,
);

-- Popolamento della tabella Reparto
INSERT INTO Reparto (nome_reparto)
VALUES ('Amministrazione'), ('Vendite'), ('Produzione'), ('Risorse Umane');

-- Popolamento della tabella Provincia
INSERT INTO Provincia (nome_provincia)
VALUES ('RM'), ('MI'), ('TO'), ('NA');

-- Popolamento della tabella Citta
INSERT INTO Citta (nome_citta, provinciaRIF)
VALUES ('Roma', 1), ('Milano', 2), ('Torino', 3), ('Napoli', 4);

-- Popolamento della tabella Impiegati
INSERT INTO Impiegati (matricola, nome, cognome, data_nascita, ruolo, reparto, indirizzo, citta)
VALUES 
('12345', 'Mario', 'Rossi', '1990-05-15', 'Manager', 'Amministrazione', 'Via Roma 1', 'Roma'),
('67890', 'Luigi', 'Bianchi', '1985-10-20', 'Venditore', 'Vendite', 'Via Milano 10', 'Milano'),
('54321', 'Giovanna', 'Verdi', '1992-02-28', 'Operatore', 'Produzione', 'Via Torino 5', 'Torino'),
('98765', 'Maria', 'Gialli', '1988-08-10', 'HR Manager', 'Risorse Umane', 'Via Napoli 20', 'Napoli');
select * from Impiegati
use GestioneImpiegati