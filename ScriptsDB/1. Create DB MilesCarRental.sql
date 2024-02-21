CREATE DATABASE MilesCarRental;
USE MilesCarRental;

CREATE TABLE Location(
	LocationId INT NOT NULL AUTO_INCREMENT,
    Location VARCHAR(50) NOT NULL,
    LocationDescription VARCHAR(200) NOT NULL,
    PRIMARY KEY(LocationId)
);

CREATE TABLE Vehicle(
	VehicleId INT NOT NULL AUTO_INCREMENT,
    Vehicle VARCHAR(50) NOT NULL,
    VehicleDescription VARCHAR(100) NOT NULL,
    PRIMARY KEY(VehicleId)
);

CREATE TABLE Market(
	MarketId INT NOT NULL AUTO_INCREMENT,
    LocationBeginId INT NOT NULL,
    LocationEndId INT NOT NULL,
    VehicleId INT NOT NULL,
    FOREIGN KEY (LocationBeginId) REFERENCES Location(LocationId),
    FOREIGN KEY (LocationEndId) REFERENCES Location(LocationId),
    FOREIGN KEY (VehicleId) REFERENCES Vehicle(VehicleId),
    PRIMARY KEY(MarketId)
);

