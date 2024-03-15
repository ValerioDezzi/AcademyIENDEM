USE SistemaGestioneCinema;
CREATE TABLE Cinema (
	CinemaID INT PRIMARY KEY,
	Nome VARCHAR (100) NOT NULL,
	Indirizzo VARCHAR (255) NOT NULL,
	Phone VARCHAR (20)
);
 
CREATE TABLE Theater (
	TheaterID INT PRIMARY KEY,
	CinemaID INT,
	Nome VARCHAR(50) NOT NULL,
	Capacity INT NOT NULL,
	ScreenType VARCHAR(50),
	FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
); CREATE TABLE Movie (
	MovieID INT PRIMARY KEY,
	Title VARCHAR(255) NOT NULL,
	Director VARCHAR(100),
	ReleaseDate DATE,
	DurationMinutes INT,
	Rating VARCHAR(5)
); CREATE TABLE Showtime (
	ShowtimeID INT PRIMARY KEY,
	MovieID INT,
	TheaterID INT,
	ShowDateTime DATETIME NOT NULL,
	Price DECIMAL(5,2) NOT NULL,
	FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
	FOREIGN KEY (TheaterID) REFERENCES Theater(TheaterID)
); CREATE TABLE Customer (
	CustomerID INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(100),
	PhoneNumber VARCHAR(20)
); CREATE TABLE Ticket (
	TicketID INT PRIMARY KEY,
	ShowtimeID INT,
	SeatNumber VARCHAR(10) NOT NULL,
	PurchasedDateTime DATETIME NOT NULL,
	CustomerID INT,
	FOREIGN KEY (ShowtimeID) REFERENCES Showtime(ShowtimeID),
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
); CREATE TABLE Review (
	ReviewID INT PRIMARY KEY,
	MovieID INT,
	CustomerID INT,
	ReviewText TEXT,
	Rating INT CHECK (Rating >= 1 AND Rating <= 5),
	ReviewDate DATETIME NOT NULL,
	FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
); CREATE TABLE Employee (
	EmployeeID INT PRIMARY KEY,
	CinemaID INT,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Position VARCHAR(50),
	HireDate DATE,
	FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
)
INSERT INTO Cinema (CinemaID, Nome, Indirizzo, Phone)
VALUES
(1, 'Cinema City', 'Via Roma 123, Città', '+39 1234567890'),
(2, 'Cineplex', 'Via Milano 456, Città', '+39 0987654321');

INSERT INTO Theater (TheaterID, CinemaID, Nome, Capacity, ScreenType)
VALUES
(1, 1, 'Sala 1', 100, '2D'),
(2, 1, 'Sala 2', 80, '3D'),
(3, 2, 'Sala A', 120, '2D');

INSERT INTO Movie (MovieID, Title, Director, ReleaseDate, DurationMinutes, Rating)
VALUES
(1, 'Il Signore degli Anelli', 'Peter Jackson', '2001-12-19', 178, 'PG-13'),
(2, 'La La Land', 'Damien Chazelle', '2016-12-09', 128, 'PG-13');

INSERT INTO Showtime (ShowtimeID, MovieID, TheaterID, ShowDateTime, Price)
VALUES
(2, 1, 2, '2024-15-03 20:30:00', 12.50), --SIG ANELLI
(3, 2, 3, '2024-16-03 15:00:00', 9.00);  -- LA LA

INSERT INTO Customer (CustomerID, FirstName, LastName, Email, PhoneNumber)
VALUES
(1, 'Mario', 'Rossi', 'mario.rossi@example.com', '+39 123456789'),
(2, 'Giulia', 'Bianchi', 'giulia.bianchi@example.com', '+39 987654321');

INSERT INTO Ticket (TicketID, ShowtimeID, SeatNumber, PurchasedDateTime, CustomerID)
VALUES
(1, 1, 'A1', '2024-15-03 15:30:00', 1),
(2, 2, 'B3', '2024-15-03 19:00:00', 2)

INSERT INTO Review (ReviewID, MovieID, CustomerID, ReviewText, Rating, ReviewDate)
VALUES
(1, 1, 1, 'Fantastico film, lo consiglio vivamente!', 5, '2024-16-03 10:00:00'),
(2, 2, 2, 'Bellissima storia e ottime interpretazioni.', 4, '2024-17-03 09:30:00');

INSERT INTO Employee (EmployeeID, CinemaID, FirstName, LastName, Position, HireDate)
VALUES
(1, 1, 'Luca', 'Verdi', 'Manager', '2020-01-15'),
(2, 2, 'Chiara', 'Neri', 'Cassiere', '2023-05-20');
------------------------------------------------------------------------------------------------------
--Creare una vista FilmsInProgrammation che mostri i titoli dei film, la data di inizio
--programmazione, la durata e la classificazione per età. Questa vista aiuterà il personale e i clienti a
--vedere rapidamente quali film sono attualmente in programmazione.
CREATE VIEW FilmsInProgrammation AS
SELECT Title,ReleaseDate,DurationMinutes,Rating,ShowDateTime
	FROM Movie
	JOIN Showtime ON Movie.MovieID = Showtime.MovieID
;
SELECT * FROM FilmsInProgrammation;

-------------------------------------------------------------------------------------------------------
/*Creare una vista AvailableSeatsForShow che, per ogni spettacolo, mostri il numero totale di
posti nella sala e quanti sono ancora disponibili. Questa vista è essenziale per il personale alla
biglietteria per gestire le vendite dei biglietti.*/	CREATE VIEW AvailableSeatsForShow AS	SELECT Theater.Capacity -COUNT(Ticket.TicketID)  AS 'POSTI RIMANENTI',Movie.Title,Theater.Nome, Theater.Capacity	FROM Ticket 	JOIN Showtime ON Ticket.ShowtimeID=Showtime.ShowtimeID	JOIN Movie ON Showtime.MovieID=Movie.MovieID	JOIN Theater ON Showtime.TheaterID=Theater.TheaterID	GROUP BY Showtime.ShowtimeID,Movie.Title,Theater.Capacity,Theater.Nome	SELECT * FROM AvailableSeatsForShow;-----------------------------------------/*Generare una vista TotalEarningsPerMovie che elenchi ogni film insieme agli incassi totali
generati. Questa informazione è cruciale per la direzione per valutare il successo commerciale dei
film.*/	CREATE VIEW TotalEarningsPerMovie AS	SELECT SUM(PRICE) AS 'Incasso',Movie.Title	FROM Showtime	JOIN Movie ON Showtime.MovieID=Movie.MovieID	GROUP BY Movie.Title	SELECT * FROM TotalEarningsPerMovie;-------------------------------------------------------/*Creare una vista RecentReviews che mostri le ultime recensioni lasciate dai clienti, includendo il
titolo del film, la valutazione, il testo della recensione e la data. Questo permetterà al personale e
alla direzione di monitorare il feedback dei clienti in tempo reale.*/SELECT Movie.Title,Review.Rating,Review.ReviewText,Review.ReviewDate	FROM Review	JOIN Movie ON Review.MovieID=Movie.MovieID;	