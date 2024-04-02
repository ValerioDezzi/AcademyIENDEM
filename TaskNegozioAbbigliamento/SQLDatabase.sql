
CREATE TABLE Utenti(
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR (50) NOT NULL,
	cognome VARCHAR (50) NOT NULL,
	email VARCHAR (50) UNIQUE NOT NULL,
);
CREATE TABLE Ordini(
	ordineID INT PRIMARY KEY IDENTITY(1,1),
	data_ordine DATETIME DEFAULT CURRENT_TIMESTAMP,
	utenteRIF INT,
	FOREIGN KEY (utenteRIF) REFERENCES Utenti(utenteID)
);
DROP TABLE IF EXISTS Prodotti
CREATE TABLE Prodotti(
	prodottoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
    descrizione TEXT,
    immagineURL VARCHAR(255)
);
CREATE TABLE Categorie(
	categoriaID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100) UNIQUE NOT NULL,
);
DROP TABLE IF EXISTS Prodotti_Categorie
USE NegozioAbbigliamento
CREATE TABLE Prodotti_Categorie(
	prodottoRIF	INT,
	categoriaRIF INT,
	PRIMARY KEY(prodottoRIF,categoriaRIF),
	FOREIGN KEY (prodottoRIF) REFERENCES Prodotti(prodottoID) ON DELETE CASCADE,
	FOREIGN KEY (categoriaRIF) REFERENCES Categorie(categoriaID)ON DELETE CASCADE,
);
DROP TABLE IF EXISTS VariazioniProdotti
CREATE TABLE VariazioniProdotti(
	variazioneID INT PRIMARY KEY IDENTITY(1,1),
	colore VARCHAR(50) NOT NULL,
    taglia VARCHAR(10) NOT NULL,
    quantita INT NOT NULL,
	prezzoPieno DECIMAL(10, 2) NOT NULL,
    prezzoOfferta DECIMAL(10, 2),
    dataInizioOfferta DATETIME,
    dataFineOfferta DATETIME,
	prodottoRIF INT,
	FOREIGN KEY (prodottoRIF) REFERENCES Prodotti(prodottoID) ON DELETE CASCADE
);
DROP TABLE IF EXISTS DettagliOrdini
CREATE TABLE DettagliOrdini(
	dettaglioID INT PRIMARY KEY IDENTITY(1,1),
	ordineRIF INT,
	variazioneRIF INT,
	quantita INT NOT NULL,
	FOREIGN KEY (ordineRIF) REFERENCES Ordini(ordineID) ON DELETE CASCADE,
    FOREIGN KEY (variazioneRIF) REFERENCES VariazioniProdotti(variazioneID) on delete cascade
);

INSERT INTO Utenti (nome, cognome, email) VALUES
('Mario', 'Rossi', 'mario.rossi@example.com'),
('Luigi', 'Verdi', 'luigi.verdi@example.com'),
('Giovanna', 'Bianchi', 'giovanna.bianchi@example.com');

INSERT INTO Prodotti (nome, descrizione, immagineURL) VALUES
('Maglietta', 'Una maglietta semplice e comoda.', 'https://picsum.photos/200'),
('Pantaloni', 'Pantaloni eleganti adatti per ogni occasione.', 'https://picsum.photos/200'),
('Scarpe', 'Scarpe sportive leggere e confortevoli.', 'https://picsum.photos/200');

INSERT INTO Categorie (nome) VALUES
('Maglieria'),
('Pantaloni'),
('Scarpe');

INSERT INTO VariazioniProdotti (colore, taglia, quantita, prezzoPieno, prezzoOfferta, dataInizioOfferta, dataFineOfferta, prodottoRIF) VALUES
('Rosso', 'S', 15, 39.99, NULL, NULL, NULL, 2),
('Nero', 'L', 10, 49.99, 39.99, '15-01-2023', '15-02-2023', 3);

INSERT INTO Ordini (utenteRIF) VALUES
(1),
(2),
(3);

INSERT INTO DettagliOrdini (ordineRIF, variazioneRIF, quantita) VALUES
(2, 2,4 );
USE NegozioAbbigliamento

SELECT * FROM Ordini
SELECT * FROM VariazioniProdotti
SELECT * FROM Prodotti
SELECT * FROM Categorie
SELECT * FROM DettagliOrdini
DELETE FROM Prodotti  WHERE prodottoID=3;

