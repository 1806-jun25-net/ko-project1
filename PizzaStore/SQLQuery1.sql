CREATE SCHEMA PizzaStoreSchema

GO

-- SELECT * FROM Users;

-- DROP TABLE Users
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(128) NOT NULL,
	LastName NVARCHAR(128) NOT NULL,
	DefaultLocation INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL
);

-- DROP TABLE Locations
-- SELECT * FROM Locations
CREATE TABLE Locations
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Pepperoni INT NOT NULL,
	Chicken INT NOT NULL,
	Ham INT NOT NULL,
	Sausage INT NOT NULL,
	Mushroom INT NOT NULL,
	Onion INT NOT NULL,
	Pineapple INT NOT NULL,
	Jalapeno INT NOT NULL,
	Olive INT NOT NULL,
	Tomato INT NOT NULL
);
INSERT INTO Locations (Pepperoni, Chicken, Ham, Sausage, Mushroom, Onion, Pineapple, Jalapeno, Olive, Tomato)
VALUES (1,1,1,1,1,1,1,1,1,1)

INSERT INTO Locations (Pepperoni, Chicken, Ham, Sausage, Mushroom, Onion, Pineapple, Jalapeno, Olive, Tomato)
VALUES (2,2,2,2,2,2,2,2,2,2)

INSERT INTO Locations (Pepperoni, Chicken, Ham, Sausage, Mushroom, Onion, Pineapple, Jalapeno, Olive, Tomato)
VALUES (3,3,3,3,3,3,3,3,3,3)

INSERT INTO Locations (Pepperoni, Chicken, Ham, Sausage, Mushroom, Onion, Pineapple, Jalapeno, Olive, Tomato)
VALUES (4,4,4,4,4,4,4,4,4,4)

INSERT INTO Locations (Pepperoni, Chicken, Ham, Sausage, Mushroom, Onion, Pineapple, Jalapeno, Olive, Tomato)
VALUES (5,5,5,5,5,5,5,5,5,5)

-- SELECT * FROM Locations;


-- DROP TABLE Orders
-- SELECT * FROM Orders
CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	UserID INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	OrderTime Datetime NOT NULL,
	LocationID INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL,
	Price Money NOT NULL
);

-- DROP TABLE Pizzas

-- SELECT * FROM Pizzas
CREATE TABLE Pizzas
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	OrderId INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL,
	PizzaSize NVARCHAR(128) NOT NULL,
	Pepperoni BIT NOT NULL,
	Chicken BIT NOT NULL,
	Ham BIT NOT NULL,
	Sausage BIT NOT NULL,
	Mushroom BIT NOT NULL,
	Onion BIT NOT NULL,
	Pineapple BIT NOT NULL,
	Jalapeno BIT NOT NULL,
	Olive BIT NOT NULL,
	Tomato BIT NOT NULL
);