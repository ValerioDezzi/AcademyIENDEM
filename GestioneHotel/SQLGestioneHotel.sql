CREATE TABLE Albergo(
	albergoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
	indirizzo VARCHAR(100) NOT NULL UNIQUE,
	valutazione VARCHAR(50) NOT NULL CHECK(valutazione in('*','**','***','****','*****')),
);

CREATE TABLE Dipendenti(
	dipendenteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
	cognome VARCHAR(100) NOT NULL,
	posizione VARCHAR(100) NOT NULL CHECK(posizione IN('receptionist','manager','F & B','housekeeping')),
	contatto VARCHAR(100),
	albergoRIF INT NOT NULL,
	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID)  
);
CREATE TABLE Facilities(
	facilityID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL,
	descrizione TEXT,
	orario VARCHAR(100) NOT NULL,
	albergoRIF INT NOT NULL,
	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID)
	
);
CREATE TABLE Camere(
	cameraID INT PRIMARY KEY IDENTITY(1,1),
	numero VARCHAR(100) NOT NULL,
	tipo VARCHAR(100) NOT NULL,
	capacita_max INT NOT NULL,
	tariffa DECIMAL(5,2),
	albergoRIF INT NOT NULL,
	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID)
);
CREATE TABLE Clienti(
	clienteID INT PRIMARY KEY IDENTITY(1,1),
	cod_fis VARCHAR(16) NOT NULL UNIQUE,
	nome VARCHAR(100) NOT NULL,
	cognome VARCHAR(100) NOT NULL,
	contatto VARCHAR(100),
);
CREATE TABLE Prenotazioni(
	--prenotazioneID INT PRIMARY KEY IDENTITY(1,1),
	check_in DATETIME NOT NULL,
	check_out DATETIME NOT NULL,
	clienteRIF INT NOT NULL,
	cameraRIF INT NOT NULL,
	albergoRIF INT NOT NULL,
	FOREIGN KEY (clienteRIF) REFERENCES Clienti(clienteID),
	FOREIGN KEY (cameraRIF) REFERENCES Camere(cameraID),
	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID),

	PRIMARY KEY(cameraRIF,check_in,check_out,albergoRIF)
);

INSERT INTO Albergo (nome, indirizzo, valutazione)
VALUES
    ('Hotel Bella Vista', 'Via Roma 123, Roma, Italia', '****'),
    ('Grand Hotel', 'Piazza San Marco 1, Venezia, Italia', '*****'),
    ('Hotel Mare', 'Lungomare 45, Rimini, Italia', '***');

INSERT INTO Dipendenti (nome, cognome, posizione, contatto, albergoRIF)
VALUES
    ('Giuseppe', 'Rossi', 'receptionist', 'giuseppe@email.com', 1),
    ('Maria', 'Bianchi', 'manager', 'maria@email.com', 2),
    ('Luca', 'Verdi', 'F & B', 'luca@email.com', 3);

INSERT INTO Facilities (nome, descrizione, orario, albergoRIF)
VALUES
    ('Piscina', 'Piscina all aperto con vista panoramica', '9:00 - 20:00', 2),
    ('Palestra', 'Palestra completamente attrezzata', '6:00 - 22:00', 3),
    ('Ristorante', 'Ristorante gourmet con cucina locale', '12:00 - 22:00', 1);

INSERT INTO Camere (numero, tipo, capacita_max, tariffa, albergoRIF)
VALUES
    ('101', 'Singola', 1, 80.00, 1),
    ('202', 'Doppia', 2, 120.00, 2),
    ('305', 'Suite', 3, 200.00, 3);

INSERT INTO Clienti (cod_fis, nome, cognome, contatto)
VALUES
    ('ABC12345', 'Marco', 'Verdi', 'marco@email.com'),
    ('DEF67890', 'Laura', 'Bianchi', 'laura@email.com'),
    ('GHI24680', 'Paolo', 'Rossi', NULL);

INSERT INTO Prenotazioni (check_in, check_out, clienteRIF, cameraRIF,albergoRIF)
VALUES
    ('2024-02-02 10:00', '2024-02-08 12:00', 2, 2,2);

    
SELECT * FROM Prenotazioni;
    DROP TABLE Prenotazioni;
      