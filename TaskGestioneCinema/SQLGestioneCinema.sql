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

	DROP TABLE IF EXISTS Ticket; 
	CREATE TABLE Ticket (
	TicketID INT PRIMARY KEY IDENTITY(1,1),
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

INSERT INTO Ticket (ShowtimeID, SeatNumber, PurchasedDateTime, CustomerID)
VALUES
( 1, 'A1', '2024-15-03 15:30:00', 1),
( 2, 'B3', '2024-15-03 19:00:00', 2)

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
biglietteria per gestire le vendite dei biglietti.*/


	CREATE VIEW AvailableSeatsForShow AS
	SELECT Theater.Capacity -COUNT(Ticket.TicketID)  AS 'POSTI RIMANENTI',Movie.Title,Theater.Nome, Theater.Capacity
	FROM Ticket 
	JOIN Showtime ON Ticket.ShowtimeID=Showtime.ShowtimeID
	JOIN Movie ON Showtime.MovieID=Movie.MovieID
	JOIN Theater ON Showtime.TheaterID=Theater.TheaterID
	GROUP BY Showtime.ShowtimeID,Movie.Title,Theater.Capacity,Theater.Nome
	SELECT * FROM AvailableSeatsForShow;
-----------------------------------------
/*Generare una vista TotalEarningsPerMovie che elenchi ogni film insieme agli incassi totali
generati. Questa informazione è cruciale per la direzione per valutare il successo commerciale dei
film.*/

	CREATE VIEW TotalEarningsPerMovie AS
	SELECT SUM(Price) AS 'Incasso',Movie.Title
	FROM Showtime
	JOIN Movie ON Showtime.MovieID=Movie.MovieID
	JOIN Ticket ON Showtime.ShowtimeID=Ticket.ShowtimeID
	GROUP BY Movie.Title

	 
	SELECT * FROM TotalEarningsPerMovie;
-------------------------------------------------------
/*Creare una vista RecentReviews che mostri le ultime recensioni lasciate dai clienti, includendo il
titolo del film, la valutazione, il testo della recensione e la data. Questo permetterà al personale e
alla direzione di monitorare il feedback dei clienti in tempo reale.*/

SELECT Movie.Title,Review.Rating,Review.ReviewText,Review.ReviewDate
	FROM Review
	JOIN Movie ON Review.MovieID=Movie.MovieID;

	/*Creare una stored procedure PurchaseTicket che permetta di acquistare un biglietto per uno
spettacolo, specificando l'ID dello spettacolo, il numero del posto e l'ID del cliente. La procedura
dovrebbe verificare la disponibilità del posto e registrare l'acquisto.*/

				/*STORE PROCEDURE OER VEDERE POSTI BISPONIBILI MA NON L HO USATA
				DECLARE @postiDisponibili INT = 0;
			SELECT @postiDisponibili= Theater.Capacity - COUNT(Ticket.TicketID)
			FROM Ticket
			JOIN Showtime ON Ticket.ShowtimeID=Showtime.ShowtimeID
			JOIN Movie ON Showtime.MovieID=Movie.MovieID
			JOIN Theater ON Showtime.TheaterID=Theater.TheaterID
			WHERE Showtime.ShowtimeID=@inputShowID
			GROUP BY Showtime.ShowtimeID,Movie.Title,Theater.Capacity,Theater.Nome*/

DROP PROCEDURE IF EXISTS PurchaseTicket
CREATE PROCEDURE PurchaseTicket
@inputShowID INT,
@inputCostumerID INT,
@inputSeatNumber VARCHAR(10)
AS
BEGIN
	DECLARE @IsOccupato INT;
	 BEGIN TRY		
			BEGIN TRANSACTION
				SELECT @IsOccupato=COUNT(*)
					FROM Ticket
					JOIN Showtime ON Ticket.ShowtimeID=Showtime.ShowtimeID
					JOIN Theater ON Showtime.TheaterID=Theater.TheaterID
					Where Showtime.ShowtimeID = @inputShowID AND Ticket.SeatNumber=@inputSeatNumber
					

					IF @IsOccupato  >0
							THROW 50001, 'POSTO NON DISPONIBILE', 1;


							INSERT INTO Ticket( CustomerID,SeatNumber,PurchasedDateTime,ShowtimeID) 
							VALUES( @inputCostumerID,@inputSeatNumber,CURRENT_TIMESTAMP,@inputShowID);
							
							PRINT'BIGLIETTO ACQUISTATO'
							COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()
	END CATCH
END;
	
EXEC PurchaseTicket @inputShowID=1,
@inputCostumerID=2,
@inputSeatNumber="A2";



SELECT* FROM Ticket
	
	SELECT COUNT(*)
					FROM Ticket
					JOIN Showtime ON Ticket.ShowtimeID=Showtime.ShowtimeID
					JOIN Theater ON Showtime.TheaterID=Theater.TheaterID
					Where Showtime.ShowtimeID = 1 AND Ticket.SeatNumber='A1';
-----------------------------------------------------
/*2. Procedura di Aggiornamento Programmazione Film
Implementare una stored procedure UpdateMovieSchedule che permetta di aggiornare gli orari
degli spettacoli per un determinato film. Questo include la possibilità di aggiungere o rimuovere
spettacoli dall'agenda.*/

SELECT * FROM Showtime
WHERE ShowtimeID = 4 AND MovieID= 2 AND TheaterID= 2 AND ShowDateTime='2024-17-03 22:30:00.000';
DROP PROCEDURE IF EXISTS AddMovieSchedule
CREATE PROCEDURE AddMovieSchedule
@inputShowTimeID INT,
@inputMovieId INT,
@inputTheaterID INT,
@inputShowDateTime DATETIME,
@inputPrice DECIMAL(5,2)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		INSERT INTO Showtime(ShowtimeID,MovieID,TheaterID,ShowDateTime,Price) VALUES
		(@inputShowTimeID,@inputMovieId,@inputTheaterID,@inputShowDateTime,@inputPrice);
		COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION

			PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()
		END CATCH
END;
EXEC AddMovieSchedule 
		@inputShowTimeID=4,
		@inputMovieId=2,
		@inputTheaterID=2,
		@inputShowDateTime='2024-17-03 22:30:00',
		@inputPrice= 11.00

CREATE PROCEDURE removeMovieSchedule
	@inputShowTimeID INT,
	@inputMovieID INT,
	@inputTheater INT,
	@inputShowDateTime DATETIME
AS
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DECLARE @contatore INT=0;
				SELECT @contatore=COUNT(*) FROM Showtime
					WHERE ShowtimeID = @inputShowTimeID AND MovieID=@inputMovieID AND TheaterID= @inputTheater AND ShowDateTime=@inputShowDateTime; 
					If @contatore = 1
						BEGIN
						DELETE FROM Showtime
							WHERE ShowtimeID = @inputShowTimeID AND MovieID=@inputMovieID AND TheaterID= @inputTheater AND ShowDateTime=@inputShowDateTime;
						PRINT 'Showtime eliminato'
						END
						ELSE
						BEGIN
							SELECT 'ERROR' AS STATUS
							PRINT 'Non è STATO POSSIBILE ELIMINARE sHOWTIME'
						END
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()
		END CATCH
	END
SELECT * FROM Showtime;
EXEC removeMovieSchedule @inputShowTimeID=4,
	@inputMovieID= 2,
	@inputTheater= 2,
	@inputShowDateTime='2024-17-03 22:30:00'

CREATE PROCEDURE UpdateUpdateMovieSchedule
@inputShowTimeID INT,@newShowTimeID INT,
@inputMovieId INT,@newMovieId INT,
@inputTheaterID INT,@newTheaterID INT,
@inputShowDateTime DATETIME,@newShowDateTime DATETIME,
@inputPrice DECIMAL(5,2),@newPrice DECIMAL(5,2)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		EXEC removeMovieSchedule @inputShowTimeID,@inputMovieId,@inputTheaterID,@inputShowDateTime
		EXEC AddMovieSchedule @newShowTimeID,@newMovieId,@newTheaterID,@newShowDateTime,@newPrice
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT 'ERROR' AS STATUS
			PRINT 'Errore' + ERROR_MESSAGE()
	END CATCH
END;
	EXEC UpdateUpdateMovieSchedule
				@inputShowTimeID=3,@inputMovieId=2,@inputTheaterID=3,@inputShowDateTime='2024-16-03 15:00:00.000',@inputPrice=9.00,
				@newShowTimeID=3,@newMovieId=2,@newTheaterID=3,@newShowDateTime='2024-16-03 15:30:00.000',@newPrice=10.00
----------------------------------------------------------
/*Sviluppare una stored procedure InsertNewMovie che consenta di inserire un nuovo film nel
sistema, richiedendo tutti i dettagli pertinenti come titolo, regista, data di uscita, durata e
classificazione.*/
CREATE PROCEDURE InsertNewMovie
@inputMovieID INT,
@inputTitle VARCHAR(255),
@inputDirector VARCHAR(100),
@inputReleaseDate DATE,
@inputDurationMinutes INT,
@inputRating VARCHAR(5)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		INSERT INTO Movie (MovieID,Title,Director,ReleaseDate,DurationMinutes,Rating)VALUES
						  (@inputMovieID,@inputTitle,@inputDirector,@inputReleaseDate,@inputDurationMinutes,@inputRating);
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SELECT 'ERROR' AS STATUS
		PRINT 'ERRORE'+ ERROR_MESSAGE()
	END CATCH
END;
SELECT * FROM Movie;
EXEC InsertNewMovie @inputMovieID = 3,
    @inputTitle = 'Il mio film',
    @inputDirector = 'Regista',
    @inputReleaseDate = '2024-03-17',
    @inputDurationMinutes = 120,
    @inputRating = 'PG-13';
--------------------------------------
/*Creare una stored procedure SubmitReview che consenta ai clienti di lasciare una recensione per
un film, comprensiva di valutazione, testo e data. Questa procedura dovrebbe verificare che il
cliente abbia effettivamente acquistato un biglietto per il film in questione prima di permettere la
pubblicazione della recensione.*/

SELECT * FROM Review
SELECT COUNT(*) FROM Review WHERE CustomerID=2 AND MovieID=2
CREATE PROCEDURE SubmitReview
@inputReviewID INT ,
@inputMovieID INT,
@inputCustomerID INT,
@inputReviewText TEXT,
@inputRating INT ,
@inputReviewDate DATETIME 
AS
BEGIN
	BEGIN TRY
		DECLARE @contatore INT =0;
		SELECT @contatore=COUNT(*)
		FROM Review 
		JOIN Ticket ON Review.CustomerID=Ticket.CustomerID
		WHERE Customer.CustomerID=@inputCustomerID AND MovieID=@inputMovieID	AND Ticket.CustomerID=Customer.CustomerID
		
		BEGIN TRANSACTION
			IF @contatore>0
				BEGIN
					SELECT 'ERROR' AS STATUS
					PRINT 'iL CLIENTE HA GIA INSERITO UNA RECESIONE PER QUEL FILM' 
				END
			ELSE
				BEGIN
					INSERT INTO Review (ReviewID, MovieID, CustomerID, ReviewText, Rating, ReviewDate)
					VALUES
						(@inputReviewID, @inputMovieID, @inputCustomerID, @inputReviewText, @inputRating, @inputReviewDate)
				END	
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SELECT 'ERROR' AS STATUS
		PRINT 'ERRORE' + ERROR_MESSAGE()
	END CATCH
END
EXEC SubmitReview @inputReviewID=3, @inputMovieID=1, @inputCustomerID=2, @inputReviewText='Caruccio', @inputRating=3, @inputReviewDate='2024/17/03 09:45:00'




	
