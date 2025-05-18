-- Flights table
CREATE TABLE Flights (
    FlightID      INTEGER      PRIMARY KEY NOT NULL,
    FlightNumber  VARCHAR(10)  NOT NULL UNIQUE,
    Departure     VARCHAR(50)  NOT NULL,
    Arrival       VARCHAR(50)  NOT NULL,
    DepartureTime DATETIME     NOT NULL,
    ArrivalTime   DATETIME     NOT NULL,
    Status        VARCHAR(20)  NOT NULL CHECK(Status IN ('Scheduled','Boarding','Departed','Cancelled'))
);

-- Passengers table
CREATE TABLE Passengers (
    PassengerID    INTEGER      PRIMARY KEY NOT NULL,
    FirstName      VARCHAR(50)  NOT NULL,
    LastName       VARCHAR(50)  NOT NULL,
    PassportNumber VARCHAR(20)  NOT NULL UNIQUE,
    FlightID       INTEGER      NOT NULL,
    FOREIGN KEY (FlightID) REFERENCES Flights(FlightID),
);

-- Seats table
CREATE TABLE Seats (
    SeatID      INTEGER     PRIMARY KEY NOT NULL,
    FlightID    INTEGER     NOT NULL,
    SeatNumber  VARCHAR(10) NOT NULL,
    IsAvailable BOOLEAN     NOT NULL DEFAULT 1,
    FOREIGN KEY (FlightID) REFERENCES Flights(FlightID),
    UNIQUE (FlightID, SeatNumber)
);

-- CheckIns table
CREATE TABLE BoardingPass (
    BoardingPassID    INTEGER   PRIMARY KEY NOT NULL,
    PassengerID  INTEGER   NOT NULL,
    FlightID     INTEGER   NOT NULL,
    SeatID       INTEGER   NOT NULL,
    IssuedAt  DATETIME  NOT NULL,
    FOREIGN KEY (FlightID)    REFERENCES Flights(FlightID),
    FOREIGN KEY (PassengerID) REFERENCES Passengers(PassengerID),
    FOREIGN KEY (SeatID)      REFERENCES Seats(SeatID),
    UNIQUE (PassengerID, FlightID)
);
