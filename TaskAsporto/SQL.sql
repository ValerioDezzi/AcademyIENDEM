USE JustDezzi
CREATE TABLE Utente(
	ID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR (150) UNIQUE NOT NULL,
	pass	VARCHAR (8) NOT NULL CHECK (LEN(pass)=8),
	indirizzo VARCHAR (150) NOT NULL,
	email VARCHAR (150) UNIQUE NOT NULL
);
CREATE TABLE Ristorante(
	ID INT PRIMARY KEY IDENTITY (1,1),
	codice VARCHAR (150) UNIQUE NOT NULL,
	nome VARCHAR (150) NOT NULL,
	tipo VARCHAR (150) NOT NULL,
	apertura TIME NOT NULL,
	chiusura TIME NOT NULL,
	indirizzo VARCHAR (150) NOT NULL,
);





CREATE TABLE Piatto(
	ID INT PRIMARY KEY IDENTITY (1,1),
	codice VARCHAR (150) UNIQUE NOT NULL,
	nome VARCHAR (150) NOT NULL,
	descrizione TEXT NOT NULL,
	prezzo DECIMAL(10,2) NOT NULL CHECK(prezzo>0),
	ristoranteRIF INT NOT NULL,
	FOREIGN KEY (ristoranteRif) REFERENCES Ristorante(ID)ON DELETE CASCADE,
);


CREATE TABLE Carrello(
	ID INT PRIMARY KEY IDENTITY(1,1),
	utenteRIF INT NOT NULL,
	FOREIGN KEY (utenteRIF) REFERENCES Utente(ID) ON DELETE CASCADE
);
CREATE TABLE Carrello_Piatto (
    carrelloRIF INT NOT NULL,
    piattoRIF INT NOT NULL,
    quantita INT NOT NULL,
    FOREIGN KEY (carrelloRIF) REFERENCES Carrello(ID),
    FOREIGN KEY (piattoRIF) REFERENCES Piatto(ID),
    PRIMARY KEY (carrelloRIF, piattoRIF)
);
ALTER TABLE Carrello_Piatto
ADD CONSTRAINT FK_Carrello_Piatto_Carrello
FOREIGN KEY (carrelloRIF)
REFERENCES Carrello(ID)
ON DELETE CASCADE;

ALTER TABLE Carrello_Piatto
ADD CONSTRAINT FK_Carrello_Piatto_Piatto
FOREIGN KEY (piattoRIF)
REFERENCES Piatto(ID)
ON DELETE CASCADE;
DROP TABLE IF EXISTS Ordinazione
CREATE TABLE Ordinazione(
	ID INT PRIMARY KEY IDENTITY (1,1),
	codice VARCHAR (150) UNIQUE NOT NULL,
	data_ora DATETIME DEFAULT CURRENT_TIMESTAMP,
	istruzioni TEXT DEFAULT('N.D'),
	stato VARCHAR (20) NOT NULL CHECK(stato IN('in consegna', 'consegnato', 'annullato')),
	utenteRIF INT NOT NULL,
	ristoranteRIF INT NOT NULL,
	carrelloRIF INT NOT NULL,
	FOREIGN KEY (utenteRIF) REFERENCES Utente(ID) ON DELETE NO ACTION,
    FOREIGN KEY (carrelloRIF) REFERENCES Carrello(ID) ON DELETE NO ACTION ,
    FOREIGN KEY (ristoranteRIF) REFERENCES Ristorante(ID) ON DELETE NO ACTION
);

SELECT * FROM Utente
SELECT * FROM Ristorante
SELECT * FROM Piatto
SELECT * FROM Carrello
SELECT * FROM Carrello_Piatto
SELECT * FROM Ordinazione
DELETE  FROM Ordinazione

SELECT Ristorante.nome,Piatto.nome
FROM Ristorante
JOIN Piatto ON Ristorante.ID=Piatto.ristoranteRIF


INSERT INTO Carrello (utenteRIF)
VALUES (2);

-- Popolamento della tabella Carrello_Piatto per utente ID 1
INSERT INTO Carrello_Piatto (carrelloRIF, piattoRIF, quantita)
VALUES (1, 1, 2),
       (1, 2, 1),
       (1, 3, 3),
       (1, 4, 1),
       (1, 5, 2);

-- Popolamento della tabella Carrello_Piatto per utente ID 2
INSERT INTO Carrello_Piatto (carrelloRIF, piattoRIF, quantita)
VALUES (2, 3, 2),
       (2, 4, 1),
       (2, 5, 3);

INSERT INTO Utente (nome, pass, indirizzo, email)
VALUES ('Mario Rossi', '12345678', 'Via Roma 1', 'mario@example.com'),
       ('Giulia Bianchi', 'abcdefgh', 'Via Milano 2', 'giulia@example.com'),
       ('Luca Verdi', 'qwertyui', 'Via Venezia 3', 'luca@example.com'),
       ('Anna Neri', 'zxcvbnm1', 'Via Firenze 4', 'anna@example.com');
	   INSERT INTO Ristorante (codice, nome, tipo, apertura, chiusura, indirizzo)
VALUES ('ABC123', 'Ristorante da Mario', 'Italiano', '08:00', '22:00', 'Via Garibaldi 10'),
       ('DEF456', 'Pizzeria Giulia', 'Pizzeria', '11:00', '23:00', 'Corso Vittorio Emanuele 20'),
       ('GHI789', 'Trattoria Luca', 'Italiano', '12:00', '21:30', 'Piazza Duomo 5'),
       ('JKL012', 'Sushi Anna', 'Giapponese', '18:00', '23:30', 'Via dei Mille 15');
	   INSERT INTO Piatto (codice, nome, descrizione, prezzo, ristoranteRIF)
VALUES ('P1', 'Pizza Margherita', 'Pizza classica con pomodoro, mozzarella e basilico', 8.50, 1),
       ('P2', 'Spaghetti Carbonara', 'Spaghetti con pancetta, uova, pecorino e pepe nero', 10.00, 3),
       ('P3', 'Sushi Misto', 'Assortimento di sushi tradizionale giapponese', 15.00, 4),
       ('P4', 'Risotto ai Funghi', 'Risotto cremoso con funghi porcini e prezzemolo', 12.00, 3),
       ('P5', 'Bistecca alla Fiorentina', 'Bistecca di manzo alla griglia servita con patate arrosto', 20.00, 3),
       ('P6', 'Insalata Caprese', 'Insalata fresca con pomodori, mozzarella di bufala, basilico e olio extra vergine di oliva', 9.00, 1);

INSERT INTO Ordinazione (data_ora,codice, istruzioni, stato, utenteRIF, ristoranteRIF, carrelloRIF)
VALUES 
    (DEFAULT,'prova1', 'N.D', 'in consegna', 1, 1, 1),
    (DEFAULT,'prova2', 'N.D', 'consegnato', 2, 2, 2);
delete from Ordinazione
   