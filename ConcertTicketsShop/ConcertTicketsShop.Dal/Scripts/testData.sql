--Users

insert into Users(Firstname,Lastname,[Password],Username,DisplayName)
VALUES('Ion','Raileanu','test123','iraileanu','iraileanu') --1

--Venues

INSERT INTO Venues(VenueName,[Location],Capacity)
VALUES('Sala Palatului', 'Bucuresti', 2000); --1

INSERT INTO Venues(VenueName,[Location],Capacity)
VALUES('Casa de cultura a studentilor', 'Iasi', 200); --2

INSERT INTO Venues(VenueName,[Location],Capacity)
VALUES('Piata Revolutiei', 'Bucuresti', 50000); --3


INSERT INTO Venues(VenueName,[Location],Capacity)
VALUES('Filarmonica Iasi', 'Iasi', 500);--4

INSERT INTO Venues(VenueName,[Location],Capacity)
VALUES('National Arena', 'Bucuresti', 2000);--5

INSERT INTO Venues(VenueName,[Location],Capacity)
VALUES('Sala Polivalenta', 'Bucuresti', 5000);--6


INSERT INTO Venues(VenueName,[Location],Capacity)
VALUES('Arenele Romane', 'Bucuresti', 3000);--7

-- Genres


INSERT INTO Genres(GenreName)
VALUES('Pop'); --1

INSERT INTO Genres(GenreName)
VALUES('Rock'); --2

INSERT INTO Genres(GenreName)
VALUES('Muzica Populara'); --3

INSERT INTO Genres(GenreName)
VALUES('Electro'); --4

INSERT INTO Genres(GenreName)
VALUES('Jazz'); --5

INSERT INTO Genres(GenreName)
VALUES('Clasica'); --6

--Artists

INSERT INTO Artists(ArtistName, GenreId)
Values('Tiesto', 4); --1

INSERT INTO Artists(ArtistName, GenreId)
Values('David Guetta', 4); --2

INSERT INTO Artists(ArtistName, GenreId)
Values('Rihanna', 1); --3

INSERT INTO Artists(ArtistName, GenreId)
Values('R3HAB', 4); --4


INSERT INTO Artists(ArtistName, GenreId)
Values('Metallica', 2); --5


INSERT INTO Artists(ArtistName, GenreId)
Values('Queen', 4); --6

--TicketTypes

INSERT INTO TicketTypes(TypeName) Values('Regular'); --1
INSERT INTO TicketTypes(TypeName) Values('VIP'); --2

--Concerts

INSERT INTO Concerts(ConcertDate, ConcertStart, ConcertFinish, VenueId,Name)
Values ('01.06.2020','01.06.2020 18:00:00','01.06.2020 20:00:00',1,'Concert de Ziua Copilului');--1


INSERT INTO Concerts(ConcertDate, ConcertStart, ConcertFinish, VenueId,Name)
Values ('01.07.2020','01.07.2020 18:00:00','01.07.2020 20:00:00',5,'Concert Electro');--2


INSERT INTO Concerts(ConcertDate, ConcertStart, ConcertFinish, VenueId,Name)
Values ('05.06.2020','05.06.2020 18:00:00','05.06.2020 23:00:00',3,'Concert Rihanna Bucuresti');--3

--Concert Participants


INSERT INTO ConcertParticipants(ConcertId, ArtistId)
Values (1,1);
INSERT INTO ConcertParticipants(ConcertId, ArtistId)
Values (1,2);
INSERT INTO ConcertParticipants(ConcertId, ArtistId)
Values (1,3);


INSERT INTO ConcertParticipants(ConcertId, ArtistId)
Values (2,1);

INSERT INTO ConcertParticipants(ConcertId, ArtistId)
Values (2,2);

INSERT INTO ConcertParticipants(ConcertId, ArtistId)
Values (2,4);

INSERT INTO ConcertParticipants(ConcertId, ArtistId)
Values (3,3);