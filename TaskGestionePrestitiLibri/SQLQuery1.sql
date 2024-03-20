CREATE TABLE Libro(
	libroID INT PRIMARY KEY IDENTITY(1,1),
	titolo VARCHAR(250) NOT NULL,
	annoPubblicazione DATE NOT NULL,
	disponibilita BIT NOT NULL
	
);
CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL,
);
CREATE TABLE Prestito(
	prestitoID INT PRIMARY KEY IDENTITY(1,1),
	dataPrestito DATE NOT NULL,
	dataRitorno DATE NOT NULL,
	utenteRIF INT NOT NULL,
	libroRIF INT NOT NULL,
	FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID),
	FOREIGN KEY (libroRIF) REFERENCES Libro(libroID)
);
