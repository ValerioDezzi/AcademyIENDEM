DROP TABLE IF EXISTS Prodotti
CREATE TABLE Prodotti(
	prodottoId INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) NOT NULL DEFAULT NEWID(),
	nomeProdotto VARCHAR(250) NOT NULL,
	descrizione TEXT NOT NULL,
	prezzo DECIMAL (10,2) NOT NULL CHECK (prezzo>0),
	quantita INT NOT NULL,
	categoria VARCHAR(30) NOT NULL,
	data_creazione DATETIME DEFAULT CURRENT_TIMESTAMP
);
INSERT INTO Prodotti(nomeProdotto,descrizione,prezzo,quantita,categoria)
VALUES('cacciavite','fa una vitaccia',2.0,12,'bricolage');
SELECT * FROM Prodotti