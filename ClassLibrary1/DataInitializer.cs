using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Data.Sqlite;

namespace Data
{
    public class DatabaseInitializer
    {
        private readonly string _databasePath;
        private readonly string _connectionString;

        public DatabaseInitializer(string databaseName = "flight.db")
        {
            // Store the database in the application folder
            _databasePath = Path.Combine(Directory.GetCurrentDirectory(), databaseName);
            _connectionString = $"Data Source={_databasePath}";
        }

        public string ConnectionString => _connectionString;

        public bool Initialize()
        {
            try
            {
                bool newDatabase = !File.Exists(_databasePath);
               

                // Create database connection
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    // Create tables if new database
                    if (newDatabase)
                    {
                        CreateTables(connection);
                        InsertSampleData(connection);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Database initialization failed: {ex.Message}", ex);
                return false;
            }

        }

        private void CreateTables(SqliteConnection connection)
        {
            // Create tables exactly as per your schema
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
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
                        FOREIGN KEY (FlightID) REFERENCES Flights(FlightID)
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

                    -- BoardingPass table
                    CREATE TABLE BoardingPass (
                        BoardingPassID INTEGER   PRIMARY KEY NOT NULL,
                        PassengerID    INTEGER   NOT NULL,
                        FlightID       INTEGER   NOT NULL,
                        SeatID         INTEGER   NOT NULL,
                        IssuedAt       DATETIME  NOT NULL,
                        FOREIGN KEY (FlightID)    REFERENCES Flights(FlightID),
                        FOREIGN KEY (PassengerID) REFERENCES Passengers(PassengerID),
                        FOREIGN KEY (SeatID)      REFERENCES Seats(SeatID),
                        UNIQUE (PassengerID, FlightID)
                    );
                ";
                command.ExecuteNonQuery();
            }
        }

        private void InsertSampleData(SqliteConnection connection)
        {
            // Insert sample data
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    -- Insert sample flights
                    INSERT INTO Flights (FlightNumber, Departure, Arrival, DepartureTime, ArrivalTime, Status)
                    VALUES 
                    ('FL001', 'New York (JFK)', 'London (LHR)', '2023-07-15 08:00:00', '2023-07-15 20:30:00', 'Scheduled'),
                    ('FL002', 'Los Angeles (LAX)', 'Tokyo (HND)', '2023-07-16 14:30:00', '2023-07-17 19:45:00', 'Boarding'),
                    ('FL003', 'Paris (CDG)', 'Dubai (DXB)', '2023-07-15 22:15:00', '2023-07-16 06:20:00', 'Departed');

                    -- Insert sample seats for each flight
                    -- For flight 1 (FL001)
                    INSERT INTO Seats (FlightID, SeatNumber, IsAvailable)
                    VALUES 
                    (1, '1A', 1), (1, '1B', 1), (1, '1C', 1), (1, '1D', 1),
                    (1, '2A', 1), (1, '2B', 1), (1, '2C', 1), (1, '2D', 1),
                    (1, '3A', 1), (1, '3B', 1), (1, '3C', 1), (1, '3D', 0);

                    -- For flight 2 (FL002)
                    INSERT INTO Seats (FlightID, SeatNumber, IsAvailable)
                    VALUES 
                    (2, '1A', 1), (2, '1B', 1), (2, '1C', 0), (2, '1D', 1),
                    (2, '2A', 0), (2, '2B', 1), (2, '2C', 1), (2, '2D', 1),
                    (2, '3A', 1), (2, '3B', 0), (2, '3C', 1), (2, '3D', 1);

                    -- For flight 3 (FL003)
                    INSERT INTO Seats (FlightID, SeatNumber, IsAvailable)
                    VALUES 
                    (3, '1A', 0), (3, '1B', 0), (3, '1C', 0), (3, '1D', 0),
                    (3, '2A', 0), (3, '2B', 0), (3, '2C', 0), (3, '2D', 0),
                    (3, '3A', 0), (3, '3B', 0), (3, '3C', 0), (3, '3D', 0);

                    -- Insert sample passengers
                    INSERT INTO Passengers (FirstName, LastName, PassportNumber, FlightID)
                    VALUES 
                    ('John', 'Doe', 'AB123456', 1),
                    ('Jane', 'Smith', 'CD789012', 1),
                    ('Michael', 'Johnson', 'EF345678', 2),
                    ('Sophia', 'Williams', 'GH901234', 3),
                    ('Robert', 'Brown', 'IJ567890', 2);

                    -- Insert sample boarding passes
                    INSERT INTO BoardingPass (PassengerID, FlightID, SeatID, IssuedAt)
                    VALUES
                    -- John Doe has seat 3D on flight 1
                    (1, 1, 12, '2023-07-14 15:30:00'),
                    -- Michael Johnson has seat 1C on flight 2
                    (3, 2, 15, '2023-07-15 10:45:00'),
                    -- Sophia Williams has seat 1A on flight 3
                    (4, 3, 25, '2023-07-15 08:20:00');

                    -- Update seat availability based on boarding passes
                    UPDATE Seats SET IsAvailable = 0 WHERE SeatID IN (12, 15, 25);
                ";
                command.ExecuteNonQuery();
            }
        }
    }
}