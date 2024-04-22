
## Flight Management API

Flight Management API is a web application designed to manage flights, allowing users to browse, add, update, and delete flight information. The API is built using ASP.NET Core.


    
## Introduction

This project aims to provide a robust API for flight management, enabling users to perform CRUD (Create, Read, Update, Delete) operations on flight data. It incorporates features such as authentication using JWT tokens, input data validation, ORM integration using Entity Framework, and unit testing.


## Features

- Flight Management: Allows users to perform CRUD operations on flight data, including adding, reading, updating, and deleting flights.
- Authentication: Implements authentication mechanisms, such as JWT tokens, to secure API endpoints.
- Input Data Validation: Validates input data to ensure its integrity and adherence to specified rules.
- ORM Integration: Utilizes Entity Framework as an ORM (Object-Relational Mapper) for database interactions.
- Unit Testing: Includes a comprehensive set of unit tests to validate the correctness of core functionalities.


## Flight model

The Flight model includes the following properties:

- Id: Unique identifier for the flight.
- FlightNumber: Flight number assigned to the flight. (in the format "XX999")
- DepartureDate: Date and time of departure.
- DeparturePlace: Place of departure.
- ArrivalPlace: Destination of the flight.
- PlaneType: Type of aircraft used for the flight (PLL LOT fleet).


## Requirements

To run this application, ensure you have the following installed:

- .NET Core SDK version 5.0 or later
- Database runtime environment (e.g., SQL Server, SQLite)
    
## Installation and Usage
    1. Clone this repository to your local machine.
    2. Configure the database connection in the appsettings.json file (ConnectionStrings property).
    3. Run the application by executing the dotnet run command in the WebAPI project directory.
    4. Access the API endpoints using a web browser or API testing tool.

## Authentication with JWT Token
All actions in this API require authentication using a JWT token. To access the CRUD methods, you need to follow these steps:

    1. Register an Account: Start by registering an account in the system.
    2. Login: After registration, log in to your account to obtain a JWT token.
    3. Authorization: Use the obtained JWT token to authorize your requests. You can do this by clicking on the "Authorize" button and entering the token in the form.
Once you have successfully authenticated and, if applicable, have a role 2 or 3, you can access and utilize the CRUD functionalities.

## Testing
To run unit tests:

    1. Navigate to the WebAPI.Tests project directory.
    2. Execute the dotnet test command to run the unit tests.

