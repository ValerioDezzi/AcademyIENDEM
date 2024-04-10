DROP TABLE IF EXISTS ContenitoreCeleste
CREATE TABLE ContenitoreCeleste(
	contenitoreID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL UNIQUE,
	codice VARCHAR(250) NOT NULL DEFAULT NEWID() UNIQUE,
	tipo VARCHAR(250) NOT NULL CHECK (tipo IN( 'Sistema planetario','Costellazione','Galassia'))
);
DROP TABLE IF EXISTS OggettoCeleste
CREATE TABLE OggettoCeleste(
	oggettoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL UNIQUE,
	codice VARCHAR(250) NOT NULL DEFAULT NEWID() UNIQUE,
	data_scoperta DATETIME NOT NULL,
	scopritore VARCHAR(250) NOT NULL DEFAULT 'N.D',
	tipologia VARCHAR(250) NOT NULL,
	distanza_terra BIGINT NOT NULL,
	coordinata_modulo FLOAT NOT NULL, 
	coordinata_azimut FLOAT NOT NULL
);
DROP TABLE IF EXISTS Contenitore_Oggetto
CREATE TABLE Contenitore_Oggetto(
  oggettoRif INT NOT NULL,
  contenitoreRif INT NOT NULL,
  PRIMARY KEY (oggettoRif, contenitoreRif),
  FOREIGN KEY (oggettoRif) REFERENCES OggettoCeleste(oggettoID) ON DELETE CASCADE,
  FOREIGN KEY (contenitoreRIF) REFERENCES ContenitoreCeleste(contenitoreID)ON DELETE CASCADE
);

INSERT INTO ContenitoreCeleste (nome,tipo) VALUES 
('Sistema Solare', 'Sistema planetario'),
('Orsa Maggiore', 'Costellazione'),
('Via Lattea', 'Galassia');
SELECT * FROM ContenitoreCeleste;
INSERT INTO OggettoCeleste (nome, data_scoperta, scopritore, tipologia, distanza_terra, coordinata_modulo, coordinata_azimut) VALUES 
('Terra','2024-04-05 00:00:00', 'John Doe', 'Pianeta', 1496000, 100, 60),
('Marte','2024-04-05 00:00:00', 'Jane Smith', 'Pianeta', 2279000, 98, 32),
('Sole', '2024-04-05 00:00:00', 'Alice Johnson', 'Stella', 1378936, 12, 24),
('Alfa Centauri','2024-04-05 00:00:00', 'Bob Brown', 'Stella', 12423625, 70, 30);
SELECT * FROM OggettoCeleste;
INSERT INTO Contenitore_Oggetto (oggettoRif, contenitoreRif) VALUES 
(1, 1), -- Terra nel Sistema Solare
(2, 1), -- Marte nel Sistema Solare
(3, 3), -- Sole nella Via Lattea
(3, 1); -- sole nel sistema solare
SELECT * FROM Contenitore_Oggetto;

