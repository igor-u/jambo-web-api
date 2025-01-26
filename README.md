# Jambo Web API
<p align="center">
<img src="https://github.com/user-attachments/assets/0ca148ca-5a98-4380-bdef-0df637753c46"/>
</p>

## Overview
This project serves as an experimental exploration of the ASP.NET Core framework within the context of photovoltaic solar energy. It focuses on three core model classes: solar panels, solar inverters, and solar power plants.

## Entity Relationship Diagram
```mermaid
%%{init: {
  "theme": "default",
  "themeCSS": [
    ".er.relationshipLabel { fill: white ; }",
    ".er.attributeBoxEven { fill : black; }",
    ".er.attributeBoxOdd { fill : black; }",
    ".er.attributeBoxEven { stroke : #e0e000; }",
    ".er.attributeBoxOdd { stroke : #e0e000; }",
    ".er.entityLabel { fill: white; }",
    ".er.relationshipLabelBox { fill: transparent; }", 
    ".er.entityBox { fill: black; }",
    ".er.entityBox { stroke: #e0e000; }"
    ]
}}%%
erDiagram
      SolarPowerPlant o|--|{ SolarPanel : has
      SolarPowerPlant o|--|{ SolarInverter : has
      SolarPowerPlant {
        bigint Id PK
        varchar(19) Coordinates
        int TotalSolarPanelWattage
        int TotalSolarInverterWattage
    }
      SolarPanel{
        varchar(12) SerialNumber PK
        int Power
        bigint SolarPowerPlantId
      }
      SolarInverter{
        varchar(12) SerialNumber PK
        int RatedPower
        int PeakPower
        bigint SolarPowerPlantId
      }
```

## Tools
- [.NET](https://dotnet.microsoft.com)
- [MySQL](https://www.mysql.com)
- [Docker](https://www.docker.com)
- [Postman](https://www.postman.com)

## Architecture
For this practice, MVC and REST were utilized separately. The view layer is responsible for displaying data (using the GET method), while the POST method is accessible through API testing platforms such as Postman or Insomnia. A collection of requests can be found in the [Jambo.postman_collection.json](https://github.com/igor-u/jambo-web-api/blob/main/Jambo.postman_collection.json) file. The collection can be imported into either tool to execute the requests after running the project.

## Objectives
- Learn about the C# programming language
- Learn more about object relational mapping
- Learn how to containerize a .NET application.

## Database
This project utilizes MySQL as the primary database. The connection between the ASP.NET application and the MySQL server is established using [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql), an open-source provider for Entity Framework Core that supports MySQL.

* Server: Localhost was used.
* MySQL Server: Ensure the MySQL server is operational:

<p align="center">
<img src="https://github.com/user-attachments/assets/1f3e7e7f-8d7f-4dd5-bb74-ffc5f18b15da"/>
</p>

**To create the database, along with its tables**:
- Navigate to the project's root directory in your terminal.
- Apply migrations:
```
dotnet ef database update
```

## Tests
To run the tests in this .NET application, execute the following command in the project's root directory:
```
dotnet test
```

## Running the Project
This project can be run in two ways:

1. Using `dotnet run`

- Navigate to the project's root directory in your terminal.
- Run the following command:
```
dotnet run
```
The application will start and be accessible through `http://localhost:5171`.

2. Using Docker

- Navigate to the project's root directory in your terminal.
- Build the Docker image:
```
docker build -t jambo-web-api .
```
Run a container using the built image:
```
docker run --network host jambo-web-api --rm
```
The `--network host`  parameter is used to make the container share the host machine's network. This allows the container to directly access local services, such as the database.

The application will start and be accessible through `http://localhost:8080`.
