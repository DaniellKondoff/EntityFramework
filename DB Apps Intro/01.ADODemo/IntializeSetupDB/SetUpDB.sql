--Create DATABASE MinionsDB

USE MInionsDB


Create Table Towns
(
Id int Identity,
TownName varchar(35),
CountryName varchar(35),
Constraint PK_Towns Primary Key(Id)
)

Create Table Minions
(
Id int identity,
Name varchar(20),
Age int,
TownId int,
Constraint PK_Minions Primary Key(Id),
Constraint FK_Minions_Towns Foreign Key(TownId) references Towns(Id)
)

Create Table Villains
(
Id int Identity Primary Key,
Name varchar(20),
EvilnessFactor varchar(10),
Constraint CH_EvillnessFactor CHECK(EvilnessFactor in ('good','bad','evil','super evil'))
)

Create Table VillainsMinions
(
VillainId int,
MinionId int,
Constraint PK_VillainsMinions Primary Key(VillainId,MinionId),
CONSTRAINT FK_MinionsVillains_Minions FOREIGN KEY (MinionId) REFERENCES Minions(Id),
CONSTRAINT FK_MinionsVillains_Villains FOREIGN KEY (VillainId) REFERENCES Villains(Id)
)

Insert Into Towns(TownName,CountryName)
Values
('Sofia','Bulgaria'),
('Plovdiv','Bulgaria'),
('Berlin','Germany'),
('Paris','France'),
('Liverpool','England')

INSERT INTO Minions (Name, Age, TownId)
VALUES
('Kev', 11, 1),
('Bobb', 12, 2),
('Stew', 5, 3),
('Malk', 3, 5),
('Tosh', 1, 4)

INSERT INTO Villains (Name, EvilnessFactor)
VALUES
('Gosho', 'bad'),
('Tosho', 'good'),
('Misho', 'evil'),
('Gogo', 'super evil'),
('Jimmy', 'good')

INSERT INTO VillainsMinions (MinionId, VillainId)
VALUES	
(1, 2),
(2, 3),
(5, 2), 
(3, 3), 
(4, 3),
(2, 2),
(1, 1), 
(4, 2),
(1, 3)