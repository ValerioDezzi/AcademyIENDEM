DROP TABLE IF EXISTS Prestito
CREATE TABLE Libro(
	libroID INT PRIMARY KEY IDENTITY(1,1),
	titolo VARCHAR(250) NOT NULL,
	annoPubblicazione INT NOT NULL,
	isDisponibilita BIT DEFAULT 1,
	isbn VARCHAR(50) NOT NULL UNIQUE,
	deleted DATETIME
	
);
CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	email VARCHAR(250) ,
	codiceUtente VARCHAR(50) NOT NULL UNIQUE,
	deleted DATETIME
);
CREATE TABLE Prestito(
	prestitoID INT PRIMARY KEY IDENTITY(1,1),
	dataPrestito DATETIME DEFAULT CURRENT_TIMESTAMP,
	dataRitorno DATETIME,
	utenteRIF INT NOT NULL,
	libroRIF INT NOT NULL,
	FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID),
	FOREIGN KEY (libroRIF) REFERENCES Libro(libroID),
	deleted DATETIME
);
INSERT INTO Libro (titolo ,annoPubblicazione ,isbn)VALUES
('CASA',1973,'AB44');
SELECT * FROM Libro