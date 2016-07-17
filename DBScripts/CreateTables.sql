IF OBJECT_ID('Basket', 'U') IS NOT NULL DROP TABLE Basket;

CREATE TABLE Basket(
	BasketId int PRIMARY KEY IDENTITY NOT NULL, 
	BasketName nvarchar(75) NOT NULL, 
	BasketDescription nvarchar(max) NULL,
	BasketTheme nvarchar(255) NULL,
	Department nvarchar(255) NULL,
	BasketValue int NULL,
	StartingBid int NOT NULL,
	BidIncriment int NOT NULL,
	BidTime TimeStamp NOT NULL
);

IF OBJECT_ID('BasketItem', 'U') IS NOT NULL DROP TABLE BasketItem;

CREATE TABLE BasketItem(
	BasketItemId int PRIMARY KEY IDENTITY NOT NULL,
	ItemName nvarchar(75) NOT NULL,
	BasketId int NOT NULL,
	BidTime TimeStamp NOT NULL,
	CONSTRAINT fk_BasketItem_Basket FOREIGN KEY (BasketId)
	REFERENCES Basket(BasketId)
);

IF OBJECT_ID('Picture', 'U') IS NOT NULL DROP TABLE Picture;

CREATE TABLE Picture(
	PictureId int PRIMARY KEY IDENTITY NOT NULL,
	PictureLocation nvarchar(255) NOT NULL,
	BasketId int NOT NULL,
	BidTime TimeStamp NOT NULL,
	CONSTRAINT fk_Picture_Basket FOREIGN KEY (BasketId)
	REFERENCES Basket(BasketId)
);

IF OBJECT_ID('Bid', 'U') IS NOT NULL DROP TABLE Bid;

CREATE TABLE Bid(
	BidId int PRIMARY KEY IDENTITY NOT NULL,
	BidAmount int NOT NULL,
	FName nvarchar(50) NOT NULL,
	LName nvarchar(50) NOT NULL,
	ContactInfo nvarchar(255) NOT NULL,
	BasketId int NOT NULL,
	BidTime TimeStamp NOT NULL,CONSTRAINT fk_Bid_Basket FOREIGN KEY (BasketId)
	REFERENCES Basket(BasketId)

);